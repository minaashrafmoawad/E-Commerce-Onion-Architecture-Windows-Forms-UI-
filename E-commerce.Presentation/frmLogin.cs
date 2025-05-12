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
//using Applications;
namespace E_commerce.Presentation
{
    public partial class frmLogin : Form
    {
        private readonly IUserService _userservice;
        ToolTip toolTip = new ToolTip();
        public frmLogin()
        {
            
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _userservice = container.Resolve<IUserService>();
            txtUserName.Select();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           System.Windows.Forms.Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _userservice.Login(txtUserName.Text, txtPassword.Text);


                if (user != null)
                {
                   
                    if (user.Role == "Admin")
                    {
                       
                        frmAdminstrator adminF = new frmAdminstrator(user);
                        adminF.Show();
                        this.Hide();
                       
                    }
                    else 
                    {

                        frmUserScreen adminF = new frmUserScreen(user);
                        adminF.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnLogIn_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnLogIn, "Click to Log in");
        }

        private void lblCreateNewAccount_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(lblCreateNewAccount, "Click here to create new account");
        }

        private void lblCreateNewAccount_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            this.Hide();
        }

        private void frmLogin_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pictureBox1, "Close");
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                btnLogIn.PerformClick();
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                txtPassword.Select();
            }
        }
        bool isPasswordHiden=true;
        private void button1_Click(object sender, EventArgs e)
        {
            isPasswordHiden= !isPasswordHiden;
            txtPassword.UseSystemPasswordChar = isPasswordHiden;
            btnDisplayPassword.Text = isPasswordHiden ? "😑" : "👁️‍🗨️";
        }
    }
}
