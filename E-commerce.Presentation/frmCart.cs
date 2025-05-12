using Application.Services;
using Applications.DTOs;
using Autofac;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class frmCart : Form
    {
        UserDTO _userDTO;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        public frmCart(UserDTO userDTO)
        {
            _userDTO = userDTO;
            var container = AutofacConfig.Configure();
            _cartService = container.Resolve<ICartService>();
            _orderService = container.Resolve<IOrderService>();


            InitializeComponent();
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvCart.DefaultCellStyle.BackColor = Color.White;
            dgvCart.DefaultCellStyle.ForeColor = Color.Black;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ReadOnly = true;


            LoadCart();
        }
        private void LoadCart()
        {
            dgvCart.DataSource = _cartService.GetCartItems(_userDTO.UserID);
            dgvCart.Columns["CartItemID"].Visible = false;
            dgvCart.Columns["ProductID"].Visible = false;
           
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("are you sure confirm order?", "Conform order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    _orderService.CreateOrder(_userDTO.UserID);
                    MessageBox.Show("Ordered succesfuuly");
                    LoadCart();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
