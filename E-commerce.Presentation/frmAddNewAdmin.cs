using Application.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Applications;
using Application.Services;
namespace E_commerce.Presentation
{
    public partial class frmAddNewAdmin : Form
    {
        private readonly IUserService _userservice;
        public frmAddNewAdmin()
        {
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _userservice = container.Resolve<IUserService>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region input validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Enter your first name.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastname.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                MessageBox.Show("Enter your last name.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Enter valid email.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Enter user name .", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Enter password.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            #region Adding new Admin account to database
            try
            {
                var user = _userservice.Register(new Models.User()
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastname.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    Role = UserRole.Admin,

                });

                MessageBox.Show("New admin added successfully.", "Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
            #endregion

        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtLastname.Select();
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtEmail.Select();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtUsername.Select();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtPassword.Select();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtConfirmPassword.Select();
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnAdd.PerformClick();
        }

        private void frmAddNewAdmin_Load(object sender, EventArgs e)
        {
            txtFirstName.Select();
        }
    }
}
