using Application.Services;
using Applications.DTOs;
using Autofac;
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
    public partial class frmUserScreen : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        List<ProductDTO> products;
        UserDTO _userDTO;

        public frmUserScreen(UserDTO user)
        {
            _userDTO = user;
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _productService = container.Resolve<IProductService>();
            _categoryService = container.Resolve<ICategoryService>();

            this.Location = new Point(900, 0);
            flowPanel.AutoScroll = true;

            var products = _productService.GetAllProducts();

            foreach (var product in products)
            {

                ProductControl productControl = new ProductControl(product, user);
                flowPanel.Controls.Add(productControl);
            }

        }
        public frmUserScreen()
        {

            InitializeComponent();
            var container = AutofacConfig.Configure();
            _productService = container.Resolve<IProductService>();


            this.Location = new Point(900, 0);
            flowPanel.AutoScroll = true;

        }

        private void addPeoductsToForm (List<ProductDTO> products)
        {
            //var products = _productService.GetAllProducts();
              flowPanel.Controls.Clear();
              foreach (var product in products)
                {

                    ProductControl productControl = new ProductControl(product, _userDTO);
                    flowPanel.Controls.Add(productControl);
                }
            
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void picCart_Click(object sender, EventArgs e)
        {
            frmCart cart = new frmCart(_userDTO);
            cart.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            addPeoductsToForm( _productService.Search(txtSearch.Text));

        }
    }
}
