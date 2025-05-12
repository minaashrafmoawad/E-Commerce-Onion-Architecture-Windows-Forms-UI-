namespace E_commerce.Presentation
{
    partial class frmAdminstrator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel4 = new Panel();
            btnLogOut = new Button();
            btnUsers = new Button();
            btnOrder = new Button();
            btnProduct = new Button();
            btnCategory = new Button();
            panel5 = new Panel();
            lblUserName = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            lblMain = new Label();
            pnlMain = new Panel();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(lblUserName);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 830);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnLogOut);
            panel4.Controls.Add(btnUsers);
            panel4.Controls.Add(btnOrder);
            panel4.Controls.Add(btnProduct);
            panel4.Controls.Add(btnCategory);
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 38);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 792);
            panel4.TabIndex = 1;
            // 
            // btnLogOut
            // 
            btnLogOut.BackgroundImageLayout = ImageLayout.None;
            btnLogOut.Cursor = Cursors.Hand;
            btnLogOut.Dock = DockStyle.Bottom;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.ForeColor = Color.FromArgb(0, 0, 64);
            btnLogOut.Location = new Point(0, 731);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(250, 61);
            btnLogOut.TabIndex = 5;
            btnLogOut.Text = "Log out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackgroundImageLayout = ImageLayout.None;
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.Dock = DockStyle.Top;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.ForeColor = Color.Transparent;
            btnUsers.Location = new Point(0, 363);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(250, 61);
            btnUsers.TabIndex = 4;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnOrder
            // 
            btnOrder.BackgroundImageLayout = ImageLayout.None;
            btnOrder.Cursor = Cursors.Hand;
            btnOrder.Dock = DockStyle.Top;
            btnOrder.FlatStyle = FlatStyle.Flat;
            btnOrder.ForeColor = Color.Transparent;
            btnOrder.Location = new Point(0, 302);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(250, 61);
            btnOrder.TabIndex = 3;
            btnOrder.Text = "Orders";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnProduct
            // 
            btnProduct.BackgroundImageLayout = ImageLayout.None;
            btnProduct.Cursor = Cursors.Hand;
            btnProduct.Dock = DockStyle.Top;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.ForeColor = Color.Transparent;
            btnProduct.Location = new Point(0, 241);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(250, 61);
            btnProduct.TabIndex = 2;
            btnProduct.Text = "Products";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCategory
            // 
            btnCategory.BackgroundImageLayout = ImageLayout.None;
            btnCategory.Cursor = Cursors.Hand;
            btnCategory.Dock = DockStyle.Top;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.ForeColor = Color.Transparent;
            btnCategory.Location = new Point(0, 180);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(250, 61);
            btnCategory.TabIndex = 1;
            btnCategory.Text = "Categories";
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(250, 180);
            panel5.TabIndex = 0;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Top;
            lblUserName.Location = new Point(0, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(178, 38);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Adminstrator";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(lblMain);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(250, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1397, 58);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackgroundImage = Properties.Resources.Cancel;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(1353, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 38);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblMain
            // 
            lblMain.AutoSize = true;
            lblMain.Location = new Point(25, 9);
            lblMain.Name = "lblMain";
            lblMain.Size = new Size(172, 38);
            lblMain.TabIndex = 0;
            lblMain.Text = "E-commerce";
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(250, 58);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1397, 772);
            pnlMain.TabIndex = 2;
            // 
            // frmAdminstrator
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1647, 830);
            Controls.Add(pnlMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAdminstrator";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adminstrator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel pnlMain;
        private Panel panel4;
        private Panel panel5;
        private Label lblUserName;
        private Label lblMain;
        //private Button button2;
        private Button btnCategory;
        private Button btnUsers;
        private Button btnOrder;
        private Button btnProduct;
        private PictureBox pictureBox1;
        public Button btnLogOut;
    }
}
