using Application.Dtos;
using Application.Services;
using Applications.DTOs;
using Autofac;
using System;
using System.Windows.Forms;

namespace ECommerceWinForms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly ILifetimeScope _scope; // Changed from IContainer
        private UserDTO _currentUser;

        public LoginForm(IUserService userService, ILifetimeScope scope)
        {
            _userService = userService;
            _scope = scope; // Store ILifetimeScope
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Login";
            this.Size = new System.Drawing.Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblUsername = new Label { Text = "Username:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(80, 20) };
            var txtUsername = new TextBox { Name = "txtUsername", Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
            var lblPassword = new Label { Text = "Password:", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(80, 20) };
            var txtPassword = new TextBox { Name = "txtPassword", Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20), UseSystemPasswordChar = true };
            var btnLogin = new Button { Text = "Login", Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(80, 30) };
            var btnRegister = new Button { Text = "Register", Location = new System.Drawing.Point(190, 80), Size = new System.Drawing.Size(80, 30) };

            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;

            this.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, btnLogin, btnRegister });
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var username = this.Controls["txtUsername"].Text;
                var password = this.Controls["txtPassword"].Text;

                _currentUser = _userService.Login(username, password);

                if (_currentUser.Role == "Admin")
                {
                    var adminForm = _scope.Resolve<AdminPanelForm>(); // Resolve using ILifetimeScope
                    adminForm.SetCurrentUser(_currentUser);
                    adminForm.Show();
                }
                else
                {
                    var clientForm = _scope.Resolve<ClientDashboardForm>();
                    clientForm.SetCurrentUser(_currentUser);
                    clientForm.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Form
            {
                Text = "Register",
                Size = new System.Drawing.Size(300, 300),
                StartPosition = FormStartPosition.CenterScreen
            };

            var lblUsername = new Label { Text = "Username:", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(80, 20) };
            var txtUsername = new TextBox { Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
            var lblPassword = new Label { Text = "Password:", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(80, 20) };
            var txtPassword = new TextBox { Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20), UseSystemPasswordChar = true };
            var lblEmail = new Label { Text = "Email:", Location = new System.Drawing.Point(20, 80), Size = new System.Drawing.Size(80, 20) };
            var txtEmail = new TextBox { Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(150, 20) };
            var lblFirstName = new Label { Text = "First Name:", Location = new System.Drawing.Point(20, 110), Size = new System.Drawing.Size(80, 20) };
            var txtFirstName = new TextBox { Location = new System.Drawing.Point(100, 110), Size = new System.Drawing.Size(150, 20) };
            var lblLastName = new Label { Text = "Last Name:", Location = new System.Drawing.Point(20, 140), Size = new System.Drawing.Size(80, 20) };
            var txtLastName = new TextBox { Location = new System.Drawing.Point(100, 140), Size = new System.Drawing.Size(150, 20) };
            var btnSave = new Button { Text = "Register", Location = new System.Drawing.Point(100, 170), Size = new System.Drawing.Size(80, 30) };

            btnSave.Click += (s, e2) =>
            {
                try
                {
                    var user = new Models.User
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        Email = txtEmail.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Role = Models.UserRole.Client
                    };
                    _userService.Register(user);
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    registerForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            registerForm.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, lblEmail, txtEmail, lblFirstName, txtFirstName, lblLastName, txtLastName, btnSave });
            registerForm.ShowDialog();
        }
    }
}