using Application.Dtos;
using Application.Services;
using Applications.DTOs;
using Autofac;
using System;
using System.Windows.Forms;

namespace ECommerceWinForms
{
    public partial class AdminPanelForm : Form
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly ILifetimeScope _scope; // Added for resolving LoginForm
        private UserDTO _currentUser;

        public AdminPanelForm(IAdminService adminService, IUserService userService, ILifetimeScope scope)
        {
            _adminService = adminService;
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
            this.Text = "Admin Panel";
            this.Size = new System.Drawing.Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            var lblWelcome = new Label
            {
                Text = "Welcome, Admin",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(300, 20),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };

            var btnCategories = new Button { Text = "Manage Categories", Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(150, 30) };
            var btnProducts = new Button { Text = "Manage Products", Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(150, 30) };
            var btnOrders = new Button { Text = "Manage Orders", Location = new System.Drawing.Point(20, 130), Size = new System.Drawing.Size(150, 30) };
            var btnClients = new Button { Text = "Manage Clients", Location = new System.Drawing.Point(20, 170), Size = new System.Drawing.Size(150, 30) };
            var btnAdmins = new Button { Text = "Manage Admins", Location = new System.Drawing.Point(20, 210), Size = new System.Drawing.Size(150, 30) };
            var btnLogout = new Button { Text = "Logout", Location = new System.Drawing.Point(20, 250), Size = new System.Drawing.Size(150, 30) };

            btnCategories.Click += (s, e) => ShowCategoryManagement();
            btnProducts.Click += (s, e) => ShowProductManagement();
            btnOrders.Click += (s, e) => ShowOrderManagement();
            btnClients.Click += (s, e) => ShowClientManagement();
            btnAdmins.Click += (s, e) => ShowAdminManagement();
            btnLogout.Click += (s, e) =>
            {
                this.Close();
                var loginForm = _scope.Resolve<LoginForm>(); // Resolve using ILifetimeScope
                loginForm.Show();
            };

            this.Controls.AddRange(new Control[] { lblWelcome, btnCategories, btnProducts, btnOrders, btnClients, btnAdmins, btnLogout });
        }

        private void ShowCategoryManagement() // Req 4.2.02-05
        {
            var form = new Form
            {
                Text = "Category Management",
                Size = new System.Drawing.Size(600, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var dgvCategories = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                AutoGenerateColumns = true,
                DataSource = _adminService.GetAllCategories()
            };

            var btnAdd = new Button { Text = "Add Category", Location = new System.Drawing.Point(20, 230), Size = new System.Drawing.Size(100, 30) };
            var btnEdit = new Button { Text = "Edit Category", Location = new System.Drawing.Point(130, 230), Size = new System.Drawing.Size(100, 30) };
            var btnDelete = new Button { Text = "Delete Category", Location = new System.Drawing.Point(240, 230), Size = new System.Drawing.Size(100, 30) };

            btnAdd.Click += (s, e) =>
            {
                var addForm = new Form { Text = "Add Category", Size = new System.Drawing.Size(300, 200) };
                var txtName = new TextBox { Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
                var txtDesc = new TextBox { Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20) };
                var btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(80, 30) };
                addForm.Controls.AddRange(new Control[] { new Label { Text = "Name:", Location = new System.Drawing.Point(20, 20) }, txtName,
                    new Label { Text = "Description:", Location = new System.Drawing.Point(20, 50) }, txtDesc, btnSave });

                btnSave.Click += (s2, e2) =>
                {
                    try
                    {
                        _adminService.AddCategory(new CategoryDTO { Name = txtName.Text, Description = txtDesc.Text });
                        MessageBox.Show("Category added successfully!");
                        addForm.Close();
                        dgvCategories.DataSource = _adminService.GetAllCategories();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                };
                addForm.ShowDialog();
            };

            btnEdit.Click += (s, e) =>
            {
                if (dgvCategories.SelectedRows.Count > 0)
                {
                    var category = (CategoryDTO)dgvCategories.SelectedRows[0].DataBoundItem;
                    var editForm = new Form { Text = "Edit Category", Size = new System.Drawing.Size(300, 200) };
                    var txtName = new TextBox { Text = category.Name, Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
                    var txtDesc = new TextBox { Text = category.Description, Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20) };
                    var btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(80, 30) };
                    editForm.Controls.AddRange(new Control[] { new Label { Text = "Name:", Location = new System.Drawing.Point(20, 20) }, txtName,
                        new Label { Text = "Description:", Location = new System.Drawing.Point(20, 50) }, txtDesc, btnSave });

                    btnSave.Click += (s2, e2) =>
                    {
                        try
                        {
                            _adminService.UpdateCategory(new CategoryDTO { CategoryID = category.CategoryID, Name = txtName.Text, Description = txtDesc.Text });
                            MessageBox.Show("Category updated successfully!");
                            editForm.Close();
                            dgvCategories.DataSource = _adminService.GetAllCategories();
                        }
                        catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    };
                    editForm.ShowDialog();
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (dgvCategories.SelectedRows.Count > 0)
                {
                    var category = (CategoryDTO)dgvCategories.SelectedRows[0].DataBoundItem;
                    if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            _adminService.DeleteCategory(category.CategoryID);
                            MessageBox.Show("Category deleted successfully!");
                            dgvCategories.DataSource = _adminService.GetAllCategories();
                        }
                        catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    }
                }
            };

            form.Controls.AddRange(new Control[] { dgvCategories, btnAdd, btnEdit, btnDelete });
            form.ShowDialog();
        }

        private void ShowProductManagement() // Req 4.2.06-09
        {
            var form = new Form
            {
                Text = "Product Management",
                Size = new System.Drawing.Size(800, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var dgvProducts = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(740, 200),
                AutoGenerateColumns = true,
                DataSource = _adminService.GetAllProducts()
            };

            var btnAdd = new Button { Text = "Add Product", Location = new System.Drawing.Point(20, 230), Size = new System.Drawing.Size(100, 30) };
            var btnEdit = new Button { Text = "Edit Product", Location = new System.Drawing.Point(130, 230), Size = new System.Drawing.Size(100, 30) };
            var btnDelete = new Button { Text = "Delete Product", Location = new System.Drawing.Point(240, 230), Size = new System.Drawing.Size(100, 30) };

            btnAdd.Click += (s, e) =>
            {
                var addForm = new Form { Text = "Add Product", Size = new System.Drawing.Size(300, 300) };
                var txtName = new TextBox { Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
                var txtDesc = new TextBox { Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20) };
                var txtPrice = new TextBox { Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(150, 20) };
                var txtStock = new TextBox { Location = new System.Drawing.Point(100, 110), Size = new System.Drawing.Size(150, 20) };
                var txtCategoryId = new TextBox { Location = new System.Drawing.Point(100, 140), Size = new System.Drawing.Size(150, 20) };
                var txtImagePath = new TextBox { Location = new System.Drawing.Point(100, 170), Size = new System.Drawing.Size(150, 20) };
                var btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(100, 200), Size = new System.Drawing.Size(80, 30) };
                addForm.Controls.AddRange(new Control[] {
                    new Label { Text = "Name:", Location = new System.Drawing.Point(20, 20) }, txtName,
                    new Label { Text = "Description:", Location = new System.Drawing.Point(20, 50) }, txtDesc,
                    new Label { Text = "Price:", Location = new System.Drawing.Point(20, 80) }, txtPrice,
                    new Label { Text = "Stock:", Location = new System.Drawing.Point(20, 110) }, txtStock,
                    new Label { Text = "Category ID:", Location = new System.Drawing.Point(20, 140) }, txtCategoryId,
                    new Label { Text = "Image Path:", Location = new System.Drawing.Point(20, 170) }, txtImagePath,
                    btnSave });

                btnSave.Click += (s2, e2) =>
                {
                    try
                    {
                        _adminService.AddProduct(new ProductDTO
                        {
                            Name = txtName.Text,
                            Description = txtDesc.Text,
                            Price = decimal.Parse(txtPrice.Text),
                            UnitsInStock = int.Parse(txtStock.Text),
                            CategoryID = int.Parse(txtCategoryId.Text),
                            ImagePath = txtImagePath.Text
                        });
                        MessageBox.Show("Product added successfully!");
                        addForm.Close();
                        dgvProducts.DataSource = _adminService.GetAllProducts();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                };
                addForm.ShowDialog();
            };

            btnEdit.Click += (s, e) =>
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    var product = (ProductDTO)dgvProducts.SelectedRows[0].DataBoundItem;
                    var editForm = new Form { Text = "Edit Product", Size = new System.Drawing.Size(300, 300) };
                    var txtName = new TextBox { Text = product.Name, Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
                    var txtDesc = new TextBox { Text = product.Description, Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20) };
                    var txtPrice = new TextBox { Text = product.Price.ToString(), Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(150, 20) };
                    var txtStock = new TextBox { Text = product.UnitsInStock.ToString(), Location = new System.Drawing.Point(100, 110), Size = new System.Drawing.Size(150, 20) };
                    var txtCategoryId = new TextBox { Text = product.CategoryID.ToString(), Location = new System.Drawing.Point(100, 140), Size = new System.Drawing.Size(150, 20) };
                    var txtImagePath = new TextBox { Text = product.ImagePath, Location = new System.Drawing.Point(100, 170), Size = new System.Drawing.Size(150, 20) };
                    var btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(100, 200), Size = new System.Drawing.Size(80, 30) };
                    editForm.Controls.AddRange(new Control[] {
                        new Label { Text = "Name:", Location = new System.Drawing.Point(20, 20) }, txtName,
                        new Label { Text = "Description:", Location = new System.Drawing.Point(20, 50) }, txtDesc,
                        new Label { Text = "Price:", Location = new System.Drawing.Point(20, 80) }, txtPrice,
                        new Label { Text = "Stock:", Location = new System.Drawing.Point(20, 110) }, txtStock,
                        new Label { Text = "Category ID:", Location = new System.Drawing.Point(20, 140) }, txtCategoryId,
                        new Label { Text = "Image Path:", Location = new System.Drawing.Point(20, 170) }, txtImagePath,
                        btnSave });

                    btnSave.Click += (s2, e2) =>
                    {
                        try
                        {
                            _adminService.UpdateProduct(new ProductDTO
                            {
                                ProductID = product.ProductID,
                                Name = txtName.Text,
                                Description = txtDesc.Text,
                                Price = decimal.Parse(txtPrice.Text),
                                UnitsInStock = int.Parse(txtStock.Text),
                                CategoryID = int.Parse(txtCategoryId.Text),
                                ImagePath = txtImagePath.Text
                            });
                            MessageBox.Show("Product updated successfully!");
                            editForm.Close();
                            dgvProducts.DataSource = _adminService.GetAllProducts();
                        }
                        catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    };
                    editForm.ShowDialog();
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    var product = (ProductDTO)dgvProducts.SelectedRows[0].DataBoundItem;
                    if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            _adminService.DeleteProduct(product.ProductID);
                            MessageBox.Show("Product deleted successfully!");
                            dgvProducts.DataSource = _adminService.GetAllProducts();
                        }
                        catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    }
                }
            };

            form.Controls.AddRange(new Control[] { dgvProducts, btnAdd, btnEdit, btnDelete });
            form.ShowDialog();
        }

        private void ShowOrderManagement() // Req 4.2.10-12
        {
            var form = new Form
            {
                Text = "Order Management",
                Size = new System.Drawing.Size(800, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var txtStatusFilter = new TextBox { Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20), Text = "Pending" };
            var btnFilter = new Button { Text = "Filter", Location = new System.Drawing.Point(260, 20), Size = new System.Drawing.Size(80, 20) };
            var dgvOrders = new DataGridView
            {
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(740, 200),
                AutoGenerateColumns = true,
                DataSource = _adminService.GetAllOrders(txtStatusFilter.Text)
            };

            var btnApprove = new Button { Text = "Approve", Location = new System.Drawing.Point(20, 260), Size = new System.Drawing.Size(100, 30) };
            var btnDeny = new Button { Text = "Deny", Location = new System.Drawing.Point(130, 260), Size = new System.Drawing.Size(100, 30) };

            btnFilter.Click += (s, e) =>
            {
                try
                {
                    dgvOrders.DataSource = _adminService.GetAllOrders(txtStatusFilter.Text);
                }
                catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
            };

            btnApprove.Click += (s, e) =>
            {
                if (dgvOrders.SelectedRows.Count > 0)
                {
                    var order = (OrderDTO)dgvOrders.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _adminService.UpdateOrderStatus(order.OrderID, "Approved");
                        MessageBox.Show("Order approved successfully!");
                        dgvOrders.DataSource = _adminService.GetAllOrders(txtStatusFilter.Text);
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            btnDeny.Click += (s, e) =>
            {
                if (dgvOrders.SelectedRows.Count > 0)
                {
                    var order = (OrderDTO)dgvOrders.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _adminService.UpdateOrderStatus(order.OrderID, "Denied");
                        MessageBox.Show("Order denied successfully!");
                        dgvOrders.DataSource = _adminService.GetAllOrders(txtStatusFilter.Text);
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            form.Controls.AddRange(new Control[] { new Label { Text = "Filter by Status:", Location = new System.Drawing.Point(20, 20) }, txtStatusFilter, btnFilter, dgvOrders, btnApprove, btnDeny });
            form.ShowDialog();
        }

        private void ShowClientManagement() // Req 4.2.13-15
        {
            var form = new Form
            {
                Text = "Client Management",
                Size = new System.Drawing.Size(600, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var dgvClients = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                AutoGenerateColumns = true,
                DataSource = _adminService.GetAllClients()
            };

            var btnActivate = new Button { Text = "Activate", Location = new System.Drawing.Point(20, 230), Size = new System.Drawing.Size(100, 30) };
            var btnDeactivate = new Button { Text = "Deactivate", Location = new System.Drawing.Point(130, 230), Size = new System.Drawing.Size(100, 30) };

            btnActivate.Click += (s, e) =>
            {
                if (dgvClients.SelectedRows.Count > 0)
                {
                    var client = (UserDTO)dgvClients.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _adminService.ActivateUser(client.UserID);
                        MessageBox.Show("Client activated successfully!");
                        dgvClients.DataSource = _adminService.GetAllClients();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            btnDeactivate.Click += (s, e) =>
            {
                if (dgvClients.SelectedRows.Count > 0)
                {
                    var client = (UserDTO)dgvClients.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _adminService.DeactivateUser(client.UserID);
                        MessageBox.Show("Client deactivated successfully!");
                        dgvClients.DataSource = _adminService.GetAllClients();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            form.Controls.AddRange(new Control[] { dgvClients, btnActivate, btnDeactivate });
            form.ShowDialog();
        }

        private void ShowAdminManagement() // Req 4.2.16-18
        {
            var form = new Form
            {
                Text = "Admin Management",
                Size = new System.Drawing.Size(600, 400),
                StartPosition = FormStartPosition.CenterScreen
            };

            var dgvAdmins = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(540, 200),
                AutoGenerateColumns = true,
                DataSource = _adminService.GetAllAdmins()
            };

            var btnAdd = new Button { Text = "Add Admin", Location = new System.Drawing.Point(20, 230), Size = new System.Drawing.Size(100, 30) };
            var btnActivate = new Button { Text = "Activate", Location = new System.Drawing.Point(130, 230), Size = new System.Drawing.Size(100, 30) };
            var btnDeactivate = new Button { Text = "Deactivate", Location = new System.Drawing.Point(240, 230), Size = new System.Drawing.Size(100, 30) };

            btnAdd.Click += (s, e) =>
            {
                var addForm = new Form { Text = "Add Admin", Size = new System.Drawing.Size(300, 300) };
                var txtUsername = new TextBox { Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(150, 20) };
                var txtPassword = new TextBox { Location = new System.Drawing.Point(100, 50), Size = new System.Drawing.Size(150, 20), UseSystemPasswordChar = true };
                var txtEmail = new TextBox { Location = new System.Drawing.Point(100, 80), Size = new System.Drawing.Size(150, 20) };
                var txtFirstName = new TextBox { Location = new System.Drawing.Point(100, 110), Size = new System.Drawing.Size(150, 20) };
                var txtLastName = new TextBox { Location = new System.Drawing.Point(100, 140), Size = new System.Drawing.Size(150, 20) };
                var btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(100, 170), Size = new System.Drawing.Size(80, 30) };
                addForm.Controls.AddRange(new Control[] {
                    new Label { Text = "Username:", Location = new System.Drawing.Point(20, 20) }, txtUsername,
                    new Label { Text = "Password:", Location = new System.Drawing.Point(20, 50) }, txtPassword,
                    new Label { Text = "Email:", Location = new System.Drawing.Point(20, 80) }, txtEmail,
                    new Label { Text = "First Name:", Location = new System.Drawing.Point(20, 110) }, txtFirstName,
                    new Label { Text = "Last Name:", Location = new System.Drawing.Point(20, 140) }, txtLastName,
                    btnSave });

                btnSave.Click += (s2, e2) =>
                {
                    try
                    {
                        _adminService.CreateAdmin(new UserDTO
                        {
                            Username = txtUsername.Text,
                            Password = txtPassword.Text,
                            Email = txtEmail.Text,
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            Role = "Admin"
                        });
                        MessageBox.Show("Admin added successfully!");
                        addForm.Close();
                        dgvAdmins.DataSource = _adminService.GetAllAdmins();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                };
                addForm.ShowDialog();
            };

            btnActivate.Click += (s, e) =>
            {
                if (dgvAdmins.SelectedRows.Count > 0)
                {
                    var admin = (UserDTO)dgvAdmins.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _adminService.ManageAdminUser(admin.UserID, true);
                        MessageBox.Show("Admin activated successfully!");
                        dgvAdmins.DataSource = _adminService.GetAllAdmins();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            btnDeactivate.Click += (s, e) =>
            {
                if (dgvAdmins.SelectedRows.Count > 0)
                {
                    var admin = (UserDTO)dgvAdmins.SelectedRows[0].DataBoundItem;
                    try
                    {
                        _adminService.ManageAdminUser(admin.UserID, false);
                        MessageBox.Show("Admin deactivated successfully!");
                        dgvAdmins.DataSource = _adminService.GetAllAdmins();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                }
            };

            form.Controls.AddRange(new Control[] { dgvAdmins, btnAdd, btnActivate, btnDeactivate });
            form.ShowDialog();
        }
    }
}