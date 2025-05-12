using Application.Dtos;
using E_commerce.Presentation.Resources;
using Applications;
using System.Windows;
using Applications.DTOs;
namespace E_commerce.Presentation
{

    public partial class frmAdminstrator : Form
    {
       
        UserDTO _user;
        private void LoadCildForm(Form formToLoad)
        {
            pnlMain.Controls.Clear();
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(formToLoad);
            formToLoad.Show();
        }
        public frmAdminstrator()
        {
            InitializeComponent();
        }
        public frmAdminstrator( UserDTO user)
        {
            _user = user;
            InitializeComponent();
            lblUserName.Text=_user.Username;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            lblMain.Text = btnProduct.Text;
            LoadCildForm(new frmProductDisplay());

        }
        private void btnCategory_Click(object sender, EventArgs e)
        {
            lblMain.Text = btnCategory.Text;
            LoadCildForm(new frmCategoryDisplay());

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            lblMain.Text = btnOrder.Text;
            LoadCildForm(new frmOrdersDisplay());

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            lblMain.Text = btnUsers.Text;
            LoadCildForm(new frmUserDisplay());

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
           System.Windows.Forms.Application.Exit();

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Close();
          
        }
    }
}
