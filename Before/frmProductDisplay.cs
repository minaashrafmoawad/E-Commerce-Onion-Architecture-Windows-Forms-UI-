using Applications.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Models;
using Applications.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace E_commerce.Presentation.Resources
{
    public partial class frmProductDisplay : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private Product ProductFromInputs()
        {
            InputValidation();
            Product newProduct = new Product()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                UnitsInStock = int.Parse(txtInStock.Text),
                CategoryID = (int)cmbCategoryEdit.SelectedValue,
                ImagePath = picProduct.Image != null ? picProduct.ImageLocation : string.Empty
            };
            return newProduct;
        }
        private void Clear()
        {
            txtName.Text = string.Empty;

            txtPrice.Text = string.Empty;
            txtInStock.Text = string.Empty;
            txtDescription.Text = string.Empty;
            lblProductID.Text = string.Empty;

        }
        private void InputValidation()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter product name.", "In valid product name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Enter valid price (positive numbers only)", "In valid product price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtInStock.Text) || decimal.Parse(txtPrice.Text) < 0)
            {
                MessageBox.Show("Enter valid quantity (positive numbers only)", "In valid product quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInStock.Focus();
                return;
            }
        }


        public frmProductDisplay()
        {
            InitializeComponent();
            var container = AutofacConfig.Configure();

            // Resolve IProductService from the container
            _productService = container.Resolve<IProductService>();
            _categoryService = container.Resolve<ICategoryService>();
        }

        private void frmProductDisplay_Load(object sender, EventArgs e)
        {
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.DefaultCellStyle.BackColor = Color.White;
            dgvProducts.DefaultCellStyle.ForeColor = Color.Black;
            dgvProducts.EnableHeadersVisualStyles = false; //\Resources   D:\ITI 2025 R3\3- Visual c#\Project\Repo v.0\E-commerce.Presentation\Resources\Background.jpeg
                                                           // picProduct.Image = System.Drawing.Image.FromFile(@".\Resources\Background.jpeg");
            picProduct.Image = System.Drawing.Image.FromFile(@"C:\Users\mina_\OneDrive\Pictures\Screenshots 1\Screenshot 2025-04-06 203143.png");

            //dgvProducts.DataSource =
            //var categSource = _categoryService.GetAllCategories();
            cmbCategory.DataSource = _categoryService.GetAllCategories();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryID";

            cmbCategoryEdit.DataSource = _categoryService.GetAllCategories();
            cmbCategoryEdit.DisplayMember = "Name";
            cmbCategoryEdit.ValueMember = "CategoryID";

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out int categoryId))
                {
                    //var products = _productService.GetAllProducts();
                    var products = _productService.GetProductsByCategory(categoryId);
                    if (products != null)
                    {
                        dgvProducts.DataSource = products;

                    }

                }
                else
                {
                    dgvProducts.DataSource = null;
                    dgvProducts.Rows.Clear(); // Optional: Clear existing rows
                }
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void picProduct_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFile = new OpenFileDialog())
                {
                    openFile.Filter = "*Image Files|*.jpg;*.jpeg;*.png";
                    openFile.Title = "Select Prouduct Image";
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        using (Image img = Image.FromFile(openFile.FileName))
                        {
                            string imageName = Path.GetFileName(openFile.FileName);
                            File.Copy(openFile.FileName, Path.Combine("Resources/Products Images", imageName), true);
                            picProduct.Image = Image.FromFile(openFile.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Something Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                _productService.CreateProduct(ProductFromInputs());
                MessageBox.Show("Product added.");
                dgvProducts.DataSource = _productService.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Clear();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                // Get the selected row
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                // Cast the row's DataBoundItem to ProductDTO
                ProductDTO selectedProduct = (ProductDTO)row.DataBoundItem;
                lblProductID.Text = selectedProduct.ProductID.ToString();
                // Update controls with the selected product's data

                txtName.Text = selectedProduct.Name ?? string.Empty;
                txtDescription.Text = selectedProduct.Description ?? string.Empty;
                txtPrice.Text = selectedProduct.Price.ToString("F2") ?? "0.00"; // Format decimal with 2 decimal places
                txtInStock.Text = selectedProduct.UnitsInStock.ToString() ?? "0";
                picProduct.Image = !string.IsNullOrEmpty(selectedProduct.ImagePath) ? Image.FromFile(selectedProduct.ImagePath) : null;

                // Set ComboBox selected value based on CategoryName (assuming CategoryID is needed)
                cmbCategoryEdit.SelectedValue = _categoryService.GetAllCategories()
                    .FirstOrDefault(c => c.Name == selectedProduct.CategoryName)?.CategoryID ?? 0;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProducts_CellContentClick(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {


                try
                {
                    if (int.TryParse(dgvProducts.SelectedRows[0].Cells["ProductID"].Value?.ToString(), out int productId))
                    {
                        _productService.DeleteProduct(productId);
                        MessageBox.Show("Product deleted successfully.");
                        dgvProducts.Refresh();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message);
                }
                Clear();

            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var produuct = ProductFromInputs();
                produuct.ProductID = int.Parse(lblProductID.Text);
                _productService.UpdateProduct(produuct);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Clear();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Allow control characters like Backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow a single dot (and not as first character)
            if (e.KeyChar == '.' && !textBox.Text.Contains(".") && textBox.SelectionStart != 0)
                return;

            // Block everything else
            e.Handled = true;
        }

        private void txtInStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Allow control characters like Backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            

            // Block everything else
            e.Handled = true;
        }
    }
}
