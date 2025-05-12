using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application.Services;
using Applications.DTOs;
using Autofac;

namespace E_commerce.Presentation
{
    public partial class ProductControl : UserControl
    {
        private readonly ICartService _cartService;
        private ProductDTO _product;
        private UserDTO _userDTO;
        private bool _isReserved;

        public ProductControl(ProductDTO productDTO, UserDTO userDTO)
        {
           

            var container = AutofacConfig.Configure();
            _cartService = container.Resolve<ICartService>();


          
            _product = productDTO ?? throw new ArgumentNullException(nameof(productDTO));
            _userDTO = userDTO ?? throw new ArgumentNullException(nameof(userDTO));

            _isReserved = _cartService.IsProductInCart(userDTO.UserID, productDTO.ProductID);
            this.Size = new Size(300, 200);
            this.BorderStyle = BorderStyle.FixedSingle;

            // Product Image
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(100, 100),
                Location = new Point(10, 50),
                Image = File.Exists(productDTO.ImagePath) ? Image.FromFile(productDTO.ImagePath) : null,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pictureBox.Click += (s, e) => new frmProductDetails(_product).ShowDialog();
            pictureBox.MouseHover += (s, e) => new frmProductDetails(_product).ShowDialog();
            this.Controls.Add(pictureBox);

            // Product Name
            Label lblName = new Label
            {
                Text = productDTO.Name,
                Location = new Point(120, 50),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            this.Controls.Add(lblName);

            // Description
            Label lblDescription = new Label
            {
                Text = productDTO.Description,
                Location = new Point(120, 70),
                AutoSize = true
            };
            this.Controls.Add(lblDescription);

            // Rating
            Label lblRating = new Label
            {
                Text = "4.4 ★ (8K)",
                Location = new Point(120, 90),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            this.Controls.Add(lblRating);

            // Price
            Label lblPrice = new Label
            {
                Text = $"{productDTO.Price} EGP",
                Location = new Point(120, 110),
                AutoSize = true,
                ForeColor = Color.Green
            };
            this.Controls.Add(lblPrice);

            // lbl In stock
            Label lblInStock = new Label
            {
                Text = $"In Stock: {_product.UnitsInStock}",
                Location = new Point(10, 155), // Positioned under the image
                AutoSize = true,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            this.Controls.Add(lblInStock);

            // Quantity Label
            Label lblQuantityToBuy = new Label
            {
                Text = "1",
                Location = new Point(170, 135),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            this.Controls.Add(lblQuantityToBuy);

            // Increase Quantity
            Button btnIncrease = new Button
            {
                Text = "+",
                Location = new Point(200, 130),
                Size = new Size(30, 25)
            };
            btnIncrease.Click += (s, e) =>
            {
                int quantity = int.Parse(lblQuantityToBuy.Text);
                lblQuantityToBuy.Text = (++quantity).ToString();
            };
            this.Controls.Add(btnIncrease);

            // Decrease Quantity
            Button btnDecrease = new Button
            {
                Text = "-",
                Location = new Point(130, 130),
                Size = new Size(30, 25)
            };
            btnDecrease.Click += (s, e) =>
            {
                int quantity = int.Parse(lblQuantityToBuy.Text);
                if (quantity > 1)
                    lblQuantityToBuy.Text = (--quantity).ToString();
            };
            this.Controls.Add(btnDecrease);

            // Remove Icon
            PictureBox picRemove = new PictureBox
            {
                Size = new Size(25, 25),
                Location = new Point(230, 160),
                Image = Image.FromStream(new MemoryStream(Properties.Resources.remove_png)),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Visible = _isReserved
            };
            picRemove.Click += (s, e) =>
            {
                if (_isReserved)
                {
                    _isReserved = false;
                    picRemove.Visible = false;
                    _cartService.DeleteProductFromCart(_userDTO.UserID, _product.ProductID);
                    MessageBox.Show($"{_product.Name} removed from cart.");
                    // Optional: Call Remove from cart service if implemented
                }
            };
            this.Controls.Add(picRemove);

            // Add to Cart Button
            Button btnAddToCart = new Button
            {
                Text = "Add To Cart",
                Location = new Point(120, 160),
                AutoSize = true
            };
            btnAddToCart.Click += (s, e) =>
            {
                try
                {
                    int quantity = int.Parse(lblQuantityToBuy.Text);
                    _cartService.AddToCart(_userDTO.UserID, _product.ProductID, quantity);
                    _isReserved = true;
                    picRemove.Visible = true;
                    MessageBox.Show($"{quantity} × {_product.Name} added to cart.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Add to Cart Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            this.Controls.Add(btnAddToCart);
        }
 
    }
}

