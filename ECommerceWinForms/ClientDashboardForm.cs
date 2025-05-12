using Application.Dtos;
using Application.Services;
using Applications.DTOs;
using Autofac;
using System;
using System.Windows.Forms;

namespace ECommerceWinForms
{
    public partial class ClientDashboardForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ILifetimeScope _scope; // Added for resolving LoginForm
        private UserDTO _currentUser;

        public ClientDashboardForm(IProductService productService, ICartService cartService, IOrderService orderService, IUserService userService, ILifetimeScope scope)
        {
            _productService = productService;
            _cartService = cartService;
            _orderService = orderService;
            _userService = userService;
            _scope = scope; // Initialize ILifetimeScope
            InitializeComponent();
        }

        public void SetCurrentUser(UserDTO user)
        {
            _currentUser = user;
        }

        private void InitializeComponent()
        {
            this.Text = "Client Dashboard";
            this.Size = new System.Drawing.Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblWelcome = new Label
            {
                Text = $"Welcome, Client",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(300, 20),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };

            var btnViewProducts = new Button { Text = "View Products", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(150, 30) };
            var btnViewCart = new Button { Text = "View Cart", Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(150, 30) };
            var btnOrderHistory = new Button { Text = "Order History", Location = new System.Drawing.Point(20, 130), Size = new System.Drawing.Size(150, 30) };
            var btnAccount = new Button { Text = "Account Details", Location = new System.Drawing.Point(20, 170), Size = new System.Drawing.Size(150, 30) };
            var btnLogout = new Button { Text = "Logout", Location = new System.Drawing.Point(20, 210), Size = new System.Drawing.Size(150, 30) };

            btnViewProducts.Click += (s, e) => ShowProductList();
            btnViewCart.Click += (s, e) => ShowCart();
            btnOrderHistory.Click += (s, e) => ShowOrderHistory();
            btnAccount.Click += (s, e) => ShowAccountDetails();
            btnLogout.Click += (s, e) =>
            {
                this.Close();
                var loginForm = _scope.Resolve<LoginForm>(); // Resolve using ILifetimeScope
                loginForm.Show();
            };

            this.Controls.AddRange(new Control[] { lblWelcome, btnViewProducts, btnViewCart, btnOrderHistory, btnAccount, btnLogout });
        }

        private void ShowProductList() // Req 4.1.01-02
        {
            var form = new Form
            {
                Text = "Product List",
                Size = new System.Drawing.Size(600, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var dgvProducts = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                AutoGenerateColumns = true,
                DataSource = _productService.GetAllProducts()
            };

            var btnDetails = new Button { Text = "View Details", Location = new System.Drawing.Point(20, 230), Size = new System.Drawing.Size(100, 30) };
            var btnAddToCart = new Button { Text = "Add to Cart", Location = new System.Drawing.Point(130, 230), Size = new System.Drawing.Size(100, 30) };

            btnDetails.Click += (s, e) =>
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    var product = (ProductDTO)dgvProducts.SelectedRows[0].DataBoundItem;
                    MessageBox.Show($"Name: {product.Name}\nDescription: {product.Description}\nPrice: ${product.Price}\nStock: {product.UnitsInStock}\nCategory: {product.CategoryName}", "Product Details");
                }
            };

            btnAddToCart.Click += (s, e) =>
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    var product = (ProductDTO)dgvProducts.SelectedRows[0].DataBoundItem;
                    var quantityForm = new Form { Text = "Add to Cart", Size = new System.Drawing.Size(200, 150) };
                    var txtQuantity = new TextBox { Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(100, 20) };
                    var btnSave = new Button { Text = "Add", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(80, 30) };
                    quantityForm.Controls.AddRange(new Control[] { new Label { Text = "Quantity:", Location = new System.Drawing.Point(20, 0) }, txtQuantity, btnSave });

                    btnSave.Click += (s2, e2) =>
                    {
                        if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                        {
                            try
                            {
                                _cartService.AddToCart(_currentUser.UserID, product.ProductID, quantity);
                                MessageBox.Show("Product added to cart!");
                                quantityForm.Close();
                            }
                            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                        }
                        else
                        {
                            MessageBox.Show("Invalid quantity.");
                        }
                    };
                    quantityForm.ShowDialog();
                }
            };

            form.Controls.AddRange(new Control[] { dgvProducts, btnDetails, btnAddToCart });
            form.ShowDialog();
        }

        private void ShowCart() // Req 4.1.03-05
        {
            var form = new Form
            {
                Text = "Shopping Cart",
                Size = new System.Drawing.Size(600, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var dgvCart = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                AutoGenerateColumns = true,
                DataSource = _cartService.GetCartItems(_currentUser.UserID)
            };

            var btnModify = new Button { Text = "Modify Quantity", Location = new System.Drawing.Point(20, 230), Size = new System.Drawing.Size(100, 30) };
            var btnRemove = new Button { Text = "Remove", Location = new System.Drawing.Point(130, 230), Size = new System.Drawing.Size(100, 30) };
            var btnCheckout = new Button { Text = "Checkout", Location = new System.Drawing.Point(240, 230), Size = new System.Drawing.Size(100, 30) };

            btnModify.Click += (s, e) =>
            {
                if (dgvCart.SelectedRows.Count > 0)
                {
                    var item = (CartItemDTO)dgvCart.SelectedRows[0].DataBoundItem;
                    var quantityForm = new Form { Text = "Modify Quantity", Size = new System.Drawing.Size(200, 150) };
                    var txtQuantity = new TextBox { Text = item.Quantity.ToString(), Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(100, 20) };
                    var btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(80, 30) };
                    quantityForm.Controls.AddRange(new Control[] { new Label { Text = "New Quantity:", Location = new System.Drawing.Point(20, 0) }, txtQuantity, btnSave });

                    btnSave.Click += (s2, e2) =>
                    {
                        if (int.TryParse(txtQuantity.Text, out int quantity) && quantity >= 0)
                        {
                            try
                            {
                                if (quantity == 0)
                                    _cartService.RemoveCartItem(item.CartItemID);
                                else
                                    _cartService.UpdateCartItem(item.CartItemID, quantity);
                                MessageBox.Show("Cart updated!");
                                quantityForm.Close();
                                dgvCart.DataSource = _cartService.GetCartItems(_currentUser.UserID);
                            }
                            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                        }
                        else
                        {
                            MessageBox.Show("Invalid quantity.");
                        }
                    };
                    quantityForm.ShowDialog();
                }
            };

            btnRemove.Click += (s, e) =>
            {
                if (dgvCart.SelectedRows.Count > 0)
                {
                    var item = (CartItemDTO)dgvCart.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _cartService.RemoveCartItem(item.CartItemID);
                        MessageBox.Show("Item removed from cart!");
                        dgvCart.DataSource = _cartService.GetCartItems(_currentUser.UserID);
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            btnCheckout.Click += (s, e) =>
            {
                try
                {
                    var order = _orderService.CreateOrder(_currentUser.UserID);
                    MessageBox.Show($"Order created! Order ID: {order.OrderID}, Total: ${order.TotalAmount}");
                    dgvCart.DataSource = _cartService.GetCartItems(_currentUser.UserID);
                }
                catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
            };

            form.Controls.AddRange(new Control[] { dgvCart, btnModify, btnRemove, btnCheckout });
            form.ShowDialog();
        }

        private void ShowOrderHistory() // Req 4.1.07
        {
            var form = new Form
            {
                Text = "Order History",
                Size = new System.Drawing.Size(600, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var dgvOrders = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                AutoGenerateColumns = true,
                DataSource = _orderService.GetUserOrders(_currentUser.UserID)
            };

            form.Controls.Add(dgvOrders);
            form.ShowDialog();
        }

        private void ShowAccountDetails() // Req 4.1.08-09
        {
            var form = new Form
            {
                Text = "Account Details",
                Size = new System.Drawing.Size(300, 300),
                StartPosition = FormStartPosition.CenterScreen
            };

            var user = _userService.GetUserById(_currentUser.UserID);
            var txtUsername = new TextBox { Text = user.Username, Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
            var txtEmail = new TextBox { Text = user.Email, Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20) };
            var txtFirstName = new TextBox { Text = user.FirstName, Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(150, 20) };
            var txtLastName = new TextBox { Text = user.LastName, Location = new System.Drawing.Point(100, 110), Size = new System.Drawing.Size(150, 20) };
            var txtPassword = new TextBox { Location = new System.Drawing.Point(100, 140), Size = new System.Drawing.Size(150, 20), UseSystemPasswordChar = true };
            var btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(100, 170), Size = new System.Drawing.Size(80, 30) };

            btnSave.Click += (s, e) =>
            {
                try
                {
                    var updatedUser = new Models.User
                    {
                        UserID = _currentUser.UserID,
                        Username = txtUsername.Text,
                        Email = txtEmail.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Password = string.IsNullOrEmpty(txtPassword.Text) ? null : txtPassword.Text,
                        Role = _currentUser.Role == "Admin" ? Models.UserRole.Admin : Models.UserRole.Client
                    };
                    _userService.UpdateUser(updatedUser);
                    MessageBox.Show("Account updated successfully!");
                    form.Close();
                }
                catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
            };

            form.Controls.AddRange(new Control[] {
                new Label { Text = "Username:", Location = new System.Drawing.Point(20, 20) }, txtUsername,
                new Label { Text = "Email:", Location = new System.Drawing.Point(20, 50) }, txtEmail,
                new Label { Text = "First Name:", Location = new System.Drawing.Point(20, 80) }, txtFirstName,
                new Label { Text = "Last Name:", Location = new System.Drawing.Point(20, 110) }, txtLastName,
                new Label { Text = "New Password:", Location = new System.Drawing.Point(20, 140) }, txtPassword,
                btnSave });
            form.ShowDialog();
        }
    }
}