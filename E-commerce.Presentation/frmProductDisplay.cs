using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using Applications.DTOs;
using Application.Services;

namespace E_commerce.Presentation.Resources
{
    public partial class frmProductDisplay : Form
    {
        private readonly IAdminService _adminService;

        private ProductDTO ProductFromInputs()
        {
            InputValidation();

            return new ProductDTO
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                UnitsInStock = int.Parse(txtInStock.Text),
                CategoryID = (int)cmbCategoryEdit.SelectedValue,
                ImagePath = picProduct.Image != null ? picProduct.ImageLocation : string.Empty
            };
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtInStock.Text = string.Empty;
            txtDescription.Text = string.Empty;
            lblProductID.Text = string.Empty;
            picProduct.Image = null;
        }

        private void InputValidation()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter product name.", "Invalid product name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Enter valid price (positive numbers only)", "Invalid product price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInStock.Text) || !int.TryParse(txtInStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Enter valid quantity (positive numbers only)", "Invalid product quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInStock.Focus();
                return;
            }
        }

        public frmProductDisplay()
        {
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _adminService = container.Resolve<IAdminService>();
        }

        private void frmProductDisplay_Load(object sender, EventArgs e)
        {
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.DefaultCellStyle.BackColor = Color.White;
            dgvProducts.DefaultCellStyle.ForeColor = Color.Black;
            dgvProducts.EnableHeadersVisualStyles = false;

            picProduct.Image = Image.FromFile(@"C:\Users\mina_\OneDrive\Pictures\Screenshots 1\Screenshot 2025-04-06 203143.png");

            var categories = _adminService.GetAllCategories();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryID";

            cmbCategoryEdit.DataSource = categories.ToList();
            cmbCategoryEdit.DisplayMember = "Name";
            cmbCategoryEdit.ValueMember = "CategoryID";

            dgvProducts.DataSource = _adminService.GetAllProducts();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out int categoryId))
                {
                    var products = _adminService.GetAllProducts().Where(p => p.CategoryID == categoryId).ToList();
                    dgvProducts.DataSource = products;
                }
                else
                {
                    dgvProducts.DataSource = null;
                    dgvProducts.Rows.Clear();
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
                    openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                    openFile.Title = "Select Product Image";

                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        string imageName = Path.GetFileName(openFile.FileName);
                        string relativeFolder = Path.Combine("Resources", "Products Images");
                        string folderPath = Path.Combine( System.Windows.Forms.Application.StartupPath, relativeFolder);

                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        string destPath = Path.Combine(folderPath, imageName);
                        File.Copy(openFile.FileName, destPath, true);

                        // Set PictureBox image
                        picProduct.Image = Image.FromFile(destPath);

                        // Save relative path only
                        picProduct.ImageLocation = Path.Combine(relativeFolder, imageName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _adminService.AddProduct(ProductFromInputs());
                MessageBox.Show("Product added.");
                dgvProducts.DataSource = _adminService.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var product = ProductFromInputs();
                product.ProductID = int.Parse(lblProductID.Text);
                _adminService.UpdateProduct(product);
                MessageBox.Show("Product updated.");
                dgvProducts.DataSource = _adminService.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                try
                {
                    if (int.TryParse(dgvProducts.SelectedRows[0].Cells["ProductID"].Value?.ToString(), out int productId))
                    {
                        _adminService.DeleteProduct(productId);
                        MessageBox.Show("Product deleted successfully.");
                        dgvProducts.DataSource = _adminService.GetAllProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message);
                }

                Clear();
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProducts_CellClick(sender, e);
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProducts.Rows[e.RowIndex];
                var selectedProduct = (ProductDTO)row.DataBoundItem;

                lblProductID.Text = selectedProduct.ProductID.ToString();
                txtName.Text = selectedProduct.Name ?? string.Empty;
                txtDescription.Text = selectedProduct.Description ?? string.Empty;
                txtPrice.Text = selectedProduct.Price.ToString("F2");
                txtInStock.Text = selectedProduct.UnitsInStock.ToString();
                picProduct.Image = !string.IsNullOrEmpty(selectedProduct.ImagePath) ? Image.FromFile(selectedProduct.ImagePath) : null;

                cmbCategoryEdit.SelectedValue = selectedProduct.CategoryID;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
                e.Handled = true;
        }

        private void txtInStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
