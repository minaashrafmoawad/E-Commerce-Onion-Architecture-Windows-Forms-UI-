using Application.Services;
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
    public partial class frmUserDisplay : Form
    {
        
        private readonly IUserService _userService;
        DataGridViewImageColumn btnActive;
        DataGridViewImageColumn btnDisactive;
        private void LoadAllClients()
        {
            dgvUsers.DataSource = _userService.GetAllClients();

            //btnActive.DisplayIndex = dgvUsers.ColumnCount - 2;
            //btnDisactive.DisplayIndex = dgvUsers.ColumnCount - 1;
            //dgvUsers.Columns["UserID"].Visible = false;
            SetButtons();
        }
        private void LoadAllAddmins()
        {
            dgvUsers.DataSource = _userService.GetAllAdmins();
            //btnActive.DisplayIndex = dgvUsers.ColumnCount - 2;
            //btnDisactive.DisplayIndex = dgvUsers.ColumnCount - 1;
            //dgvUsers.Columns["UserID"].Visible = false;
            SetButtons();
        }
        private void LoadUsers()
        {
            if (cmbRole.SelectedItem == "Admin")
                LoadAllAddmins();
            else if (cmbRole.SelectedItem == "Client")
                LoadAllAddmins();
        }
       

        private void SetButtons()
        {
            btnActive.DisplayIndex = dgvUsers.ColumnCount - 2;
            btnDisactive.DisplayIndex = dgvUsers.ColumnCount - 1;
            dgvUsers.Columns["UserID"].Visible = false;
        }
        public frmUserDisplay()
        {
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _userService = container.Resolve<IUserService>();
        }

        private void frmUserDisplay_Load(object sender, EventArgs e)
        {
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.DefaultCellStyle.BackColor=Color.White;
            dgvUsers.DefaultCellStyle.ForeColor=Color.Black;
            dgvUsers.DefaultCellStyle.Font = new Font("Arial", 12);

            //adding approve button
            
            btnActive = new DataGridViewImageColumn();
            btnActive.Name = "btnActive";
            btnActive.HeaderText = "Active";
           // btnActive.Image = Image.FromFile("Resources/approve.png");
            
            btnActive.Image = Image.FromFile(("Resources/approve.png"));
            dgvUsers.Columns.Add(btnActive);

            // adding deny button 

            btnDisactive = new DataGridViewImageColumn();
            btnDisactive.Name = "btnDisactive";
            btnDisactive.HeaderText = "Disactive";
            btnDisactive.Image = Image.FromFile("Resources/DenyOrder.png");
            dgvUsers.Columns.Add(btnDisactive);


            //// Set cmb Role 
            cmbRole.Items.Add("Admin");
            
           cmbRole.Items.Add("Client");

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvUsers.Columns[e.ColumnIndex].Name == "btnActive")
                {
                    // if btnApprove button clicked
                    if (MessageBox.Show("Are you sure you want to Active this user?", "Confirm user activation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (int.TryParse(dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value?.ToString(), out int id))
                        {
                            _userService.ActivateUser(id);
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("Invalid user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                // Handel clicking btnDeny button
                else if ((dgvUsers.Columns[e.ColumnIndex].Name == "btnDisactive"))

                    if (MessageBox.Show("Are you sure you want to disactive this order?", "Confirm user deactivation",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (int.TryParse(dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value?.ToString(), out int id))
                        {
                            _userService.DeactivateUser(id);
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("Invalid user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            picNewAdmin_Click(sender, e);
        }

        private void picNewAdmin_Click(object sender, EventArgs e)
        {
            frmAddNewAdmin frm = new frmAddNewAdmin();
            frm.ShowDialog();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRole.SelectedItem.ToString() == "Admin")
                    LoadAllAddmins();


                else if (cmbRole.SelectedItem == "Client")
                    LoadAllClients();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
