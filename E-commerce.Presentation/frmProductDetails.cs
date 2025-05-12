using Applications.DTOs;
using Application.Services;
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
    public partial class frmProductDetails : Form
    {
        ProductDTO _product = new ProductDTO();
        public frmProductDetails(ProductDTO product)
        {
            _product = product;
            InitializeComponent();
            lblName.Text = _product.Name;

            lblDescription.Text = _product.Description;

            if (_product.UnitsInStock > 0)
                lblStock.Text = $" {_product.UnitsInStock} In Stock";
            else
            {
                lblStock.ForeColor = Color.Red;
                lblStock.Text = "Out of stouck!";
            }
            lblPrice.Text = $"{_product.Price}";
            picProduct.Image = Image.FromFile(_product.ImagePath);
        }
        private void frmEditProduct_Load(object sender, EventArgs e)
        {

        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductDetails_MouseLeave(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
