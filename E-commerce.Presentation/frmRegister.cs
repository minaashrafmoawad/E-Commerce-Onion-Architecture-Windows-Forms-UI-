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
using Application.Services;
using Autofac;
using Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection.Metadata;
namespace E_commerce.Presentation
{
    public partial class frmRegister : Form
    {

        private readonly IUserService _userservice;

        ToolTip toolTip = new ToolTip();
        public frmRegister()
        {
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _userservice = container.Resolve<IUserService>();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region input validation
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                MessageBox.Show("Enter your first name.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstname.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                MessageBox.Show("Enter your last name.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastname.Focus();
                return;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Enter valid email.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Enter user name .", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Enter password.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Focus();
                return;
            }
            if (txtpassword.Text != txtConfirmpassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "In valid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            #region Adding new client to database
            try
            {
                var user = _userservice.Register(new Models.User()
                {
                    FirstName = txtFirstname.Text.Trim(),
                    LastName = txtLastname.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtpassword.Text
                });
                // open clien dashboard
                MessageBox.Show("Welcome 😊");
                frmUserScreen frmClient = new frmUserScreen(user);
                frmClient.Show();
                this.Close();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message,"Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
           frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void lblLogin_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(lblLogin, "Click to Log in");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pictureBox1, "Close");
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnSignUp, "Click to Log in");
        }
        bool isPasswordHiden = true;
        private void btnDisplayPassword_Click(object sender, EventArgs e)
        {
            isPasswordHiden = !isPasswordHiden;
            txtpassword.UseSystemPasswordChar = isPasswordHiden;
            txtConfirmpassword.UseSystemPasswordChar = isPasswordHiden;
            btnDisplayPassword.Text = isPasswordHiden ? "😑" : "👁️‍🗨️";
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                txtLastname.Select();
            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                txtEmail.Select();
            }
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                txtUsername.Select();
            }
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                txtpassword.Select();
            }
        }
        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
         { 
            if (e.KeyChar == ((char)Keys.Enter))
            {
                txtConfirmpassword.Select();
            }
            
         }
        private void txtConfirmpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                btnSignUp.PerformClick();
            }

        }

        
    }
}
