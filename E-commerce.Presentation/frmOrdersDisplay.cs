using Application.Services;
using Autofac;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class frmOrdersDisplay : Form
    {
        private readonly IOrderService _orderService;
        private readonly IAdminService _adminService;

        private DataGridViewImageColumn btnApprove;
        private DataGridViewImageColumn btnDeny;

        public frmOrdersDisplay()
        {
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _orderService = container.Resolve<IOrderService>();
            _adminService = container.Resolve<IAdminService>();
        }

        private void frmOrdersDisplay_Load(object sender, EventArgs e)
        {
            // Initialize DataGridView UI
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvOrders.DefaultCellStyle.BackColor = Color.White;
            dgvOrders.DefaultCellStyle.ForeColor = Color.Black;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add Approve button
            btnApprove = new DataGridViewImageColumn
            {
                Name = "btnApprove",
                HeaderText = "Approve",
                Image = Image.FromFile("Resources/approve.png")
            };
            dgvOrders.Columns.Add(btnApprove);

            // Add Deny button
            btnDeny = new DataGridViewImageColumn
            {
                Name = "btnDeny",
                HeaderText = "Deny",
                Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "DenyOrder.png"))
            };
            dgvOrders.Columns.Add(btnDeny);

            // Load Enum values
            cmbOrderStatus.DataSource = Enum.GetValues(typeof(OrderStatus));
            cmbOrderStatus.SelectedIndexChanged += cmbOrderStatus_SelectedIndexChanged;

            // Load Orders
            loadOrders();
        }

        private void loadOrders()
        {
            var selectedStatus = cmbOrderStatus.SelectedItem?.ToString();
            dgvOrders.DataSource = _adminService.GetAllOrders(selectedStatus);

            // Show/hide buttons based on order status
            if (Enum.TryParse<OrderStatus>(selectedStatus, out var status) && status == OrderStatus.Pending)
            {
                btnDeny.Visible = true;
                btnApprove.Visible = true;
                btnDeny.DisplayIndex = dgvOrders.Columns.Count - 1;
                btnApprove.DisplayIndex = dgvOrders.Columns.Count - 2;
            }
            else
            {
                btnApprove.Visible = false;
                btnDeny.Visible = false;
            }
        }

        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadOrders();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dgvOrders.Columns[e.ColumnIndex].Name;
            var row = dgvOrders.Rows[e.RowIndex];
            if (!int.TryParse(row.Cells["OrderId"].Value?.ToString(), out int orderId))
            {
                MessageBox.Show("Invalid Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (columnName == "btnApprove")
            {
                var confirm = MessageBox.Show("Are you sure you want to approve this order?", "Confirm order approval",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    _adminService.UpdateOrderStatus(orderId, OrderStatus.Approved.ToString());
                    loadOrders();
                }
            }
            else if (columnName == "btnDeny")
            {
                var confirm = MessageBox.Show("Are you sure you want to deny this order?", "Confirm Order Denial",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    _adminService.UpdateOrderStatus(orderId, OrderStatus.Denied.ToString());
                    loadOrders();
                }
            }
        }
    }
}
