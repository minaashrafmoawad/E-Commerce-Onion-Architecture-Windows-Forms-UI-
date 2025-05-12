namespace E_commerce.Presentation
{
    partial class frmProductDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            picCancel = new PictureBox();
            lblName = new Label();
            panel3 = new Panel();
            lblDescription = new Label();
            lblRating = new Label();
            panel6 = new Panel();
            picProduct = new PictureBox();
            lblPrice = new Label();
            lblStock = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCancel).BeginInit();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BlueViolet;
            panel1.Controls.Add(picCancel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 53);
            panel1.TabIndex = 0;
            // 
            // picCancel
            // 
            picCancel.BackgroundImage = Properties.Resources.Cancel;
            picCancel.BackgroundImageLayout = ImageLayout.Stretch;
            picCancel.Dock = DockStyle.Right;
            picCancel.InitialImage = Properties.Resources.Cancel;
            picCancel.Location = new Point(976, 0);
            picCancel.Name = "picCancel";
            picCancel.Size = new Size(58, 53);
            picCancel.TabIndex = 0;
            picCancel.TabStop = false;
            picCancel.Click += picCancel_Click;
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(12, 287);
            lblName.Name = "lblName";
            lblName.Size = new Size(414, 49);
            lblName.TabIndex = 1;
            lblName.Text = ".";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblDescription);
            panel3.Font = new Font("Segoe UI", 13.8F);
            panel3.Location = new Point(442, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(565, 356);
            panel3.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Dock = DockStyle.Fill;
            lblDescription.Location = new Point(0, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(565, 356);
            lblDescription.TabIndex = 0;
            // 
            // lblRating
            // 
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRating.Location = new Point(12, 336);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(199, 31);
            lblRating.TabIndex = 2;
            lblRating.Text = "4.4 ★ (8K)";
            // 
            // panel6
            // 
            panel6.Controls.Add(picProduct);
            panel6.Font = new Font("Segoe UI", 13.8F);
            panel6.Location = new Point(12, 59);
            panel6.Name = "panel6";
            panel6.Size = new Size(414, 215);
            panel6.TabIndex = 4;
            // 
            // picProduct
            // 
            picProduct.Dock = DockStyle.Fill;
            picProduct.Location = new Point(0, 0);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(414, 215);
            picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            picProduct.TabIndex = 2;
            picProduct.TabStop = false;
            // 
            // lblPrice
            // 
            lblPrice.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Green;
            lblPrice.Location = new Point(12, 378);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(199, 31);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Egp ";
            // 
            // lblStock
            // 
            lblStock.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStock.ForeColor = Color.Blue;
            lblStock.Location = new Point(12, 409);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(199, 31);
            lblStock.TabIndex = 2;
            lblStock.Text = "Egp ";
            // 
            // frmProductDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1034, 458);
            Controls.Add(lblStock);
            Controls.Add(lblPrice);
            Controls.Add(lblRating);
            Controls.Add(lblName);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(panel1);
            ForeColor = Color.DarkSlateGray;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProductDetails";
            Text = "frmEditUser";
            Load += frmEditProduct_Load;
            MouseLeave += frmProductDetails_MouseLeave;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCancel).EndInit();
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox picCancel;
        
        private Label lblName;
        private Panel panel3;
        private Panel panel6;
        private PictureBox picProduct;
        private Label lblRating;
        private Panel panel4;
       
        private Label label7;
        private Label lblPrice;
        private Label lblStock;
        private Label lblDescription;
    }
}