namespace E_commerce.Presentation.Resources
{
    partial class frmProductDisplay
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel2 = new Panel();
            dgvProducts = new DataGridView();
            panel3 = new Panel();
            lblProductID = new Label();
            cmbCategory = new ComboBox();
            yuyty7u = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            panel11 = new Panel();
            picProduct = new PictureBox();
            panel1 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel12 = new Panel();
            txtInStock = new TextBox();
            label4 = new Label();
            panel13 = new Panel();
            txtPrice = new TextBox();
            label2 = new Label();
            panel14 = new Panel();
            cmbCategoryEdit = new ComboBox();
            label1 = new Label();
            panel17 = new Panel();
            txtName = new TextBox();
            label3 = new Label();
            panel8 = new Panel();
            panel15 = new Panel();
            panel9 = new Panel();
            panel18 = new Panel();
            txtDescription = new TextBox();
            panel10 = new Panel();
            panel16 = new Panel();
            label5 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panel3.SuspendLayout();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel17.SuspendLayout();
            panel8.SuspendLayout();
            panel15.SuspendLayout();
            panel9.SuspendLayout();
            panel18.SuspendLayout();
            panel10.SuspendLayout();
            panel16.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvProducts);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(356, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(997, 633);
            panel2.TabIndex = 1;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.BlueViolet;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvProducts.Location = new Point(0, 43);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(997, 590);
            dgvProducts.TabIndex = 4;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // panel3
            // 
            panel3.BackgroundImage = Properties.Resources.Background;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(lblProductID);
            panel3.Controls.Add(cmbCategory);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(997, 43);
            panel3.TabIndex = 5;
            // 
            // lblProductID
            // 
            lblProductID.AutoSize = true;
            lblProductID.Location = new Point(28, 9);
            lblProductID.Name = "lblProductID";
            lblProductID.Size = new Size(92, 20);
            lblProductID.TabIndex = 1;
            lblProductID.Text = "lblProductID";
            lblProductID.Visible = false;
            // 
            // cmbCategory
            // 
            cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCategory.Dock = DockStyle.Right;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(686, 0);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(311, 28);
            cmbCategory.TabIndex = 0;
            cmbCategory.Text = "Category";
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // yuyty7u
            // 
            yuyty7u.Dock = DockStyle.Bottom;
            yuyty7u.Location = new Point(0, 617);
            yuyty7u.Name = "yuyty7u";
            yuyty7u.Size = new Size(356, 16);
            yuyty7u.TabIndex = 7;
            yuyty7u.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Dock = DockStyle.Bottom;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 567);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(356, 50);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DarkGreen;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Dock = DockStyle.Bottom;
            btnUpdate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(0, 524);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(356, 43);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Dock = DockStyle.Bottom;
            btnAdd.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(0, 481);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(356, 43);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel11
            // 
            panel11.Controls.Add(picProduct);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(356, 101);
            panel11.TabIndex = 13;
            // 
            // picProduct
            // 
            picProduct.Dock = DockStyle.Fill;
            picProduct.Location = new Point(0, 0);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(356, 101);
            picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            picProduct.TabIndex = 0;
            picProduct.TabStop = false;
            picProduct.Click += picProduct_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(yuyty7u);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 633);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 101);
            panel4.Name = "panel4";
            panel4.Size = new Size(356, 380);
            panel4.TabIndex = 14;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(356, 380);
            panel5.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(356, 380);
            panel6.TabIndex = 14;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel12);
            panel7.Controls.Add(panel13);
            panel7.Controls.Add(panel14);
            panel7.Controls.Add(panel17);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(356, 218);
            panel7.TabIndex = 8;
            // 
            // panel12
            // 
            panel12.BackColor = Color.MediumPurple;
            panel12.Controls.Add(txtInStock);
            panel12.Controls.Add(label4);
            panel12.Font = new Font("Segoe UI", 13.8F);
            panel12.ForeColor = Color.White;
            panel12.Location = new Point(12, 178);
            panel12.Name = "panel12";
            panel12.Size = new Size(340, 31);
            panel12.TabIndex = 12;
            // 
            // txtInStock
            // 
            txtInStock.Dock = DockStyle.Fill;
            txtInStock.Location = new Point(140, 0);
            txtInStock.Name = "txtInStock";
            txtInStock.PlaceholderText = "Stock";
            txtInStock.Size = new Size(200, 38);
            txtInStock.TabIndex = 2;
            txtInStock.KeyPress += txtInStock_KeyPress;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(140, 31);
            label4.TabIndex = 1;
            label4.Text = "In Stcok";
            // 
            // panel13
            // 
            panel13.BackColor = Color.MediumPurple;
            panel13.Controls.Add(txtPrice);
            panel13.Controls.Add(label2);
            panel13.Font = new Font("Segoe UI", 13.8F);
            panel13.ForeColor = Color.White;
            panel13.Location = new Point(9, 134);
            panel13.Name = "panel13";
            panel13.Size = new Size(340, 31);
            panel13.TabIndex = 13;
            // 
            // txtPrice
            // 
            txtPrice.Dock = DockStyle.Fill;
            txtPrice.Location = new Point(140, 0);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Price";
            txtPrice.Size = new Size(200, 38);
            txtPrice.TabIndex = 2;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(140, 31);
            label2.TabIndex = 1;
            label2.Text = "Price";
            // 
            // panel14
            // 
            panel14.BackColor = Color.MediumPurple;
            panel14.Controls.Add(cmbCategoryEdit);
            panel14.Controls.Add(label1);
            panel14.Font = new Font("Segoe UI", 13.8F);
            panel14.ForeColor = Color.White;
            panel14.Location = new Point(9, 89);
            panel14.Name = "panel14";
            panel14.Size = new Size(340, 31);
            panel14.TabIndex = 14;
            // 
            // cmbCategoryEdit
            // 
            cmbCategoryEdit.Dock = DockStyle.Fill;
            cmbCategoryEdit.FormattingEnabled = true;
            cmbCategoryEdit.Location = new Point(140, 0);
            cmbCategoryEdit.Name = "cmbCategoryEdit";
            cmbCategoryEdit.Size = new Size(200, 39);
            cmbCategoryEdit.TabIndex = 2;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 31);
            label1.TabIndex = 1;
            label1.Text = "Category";
            // 
            // panel17
            // 
            panel17.BackColor = Color.MediumPurple;
            panel17.Controls.Add(txtName);
            panel17.Controls.Add(label3);
            panel17.Font = new Font("Segoe UI", 13.8F);
            panel17.ForeColor = Color.White;
            panel17.Location = new Point(12, 37);
            panel17.Name = "panel17";
            panel17.Size = new Size(343, 31);
            panel17.TabIndex = 15;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(121, 0);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(222, 31);
            txtName.TabIndex = 2;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(121, 31);
            label3.TabIndex = 1;
            label3.Text = "Name";
            // 
            // panel8
            // 
            panel8.BackColor = Color.MediumPurple;
            panel8.Controls.Add(panel15);
            panel8.Dock = DockStyle.Bottom;
            panel8.Font = new Font("Segoe UI", 13.8F);
            panel8.ForeColor = Color.White;
            panel8.Location = new Point(0, 243);
            panel8.Name = "panel8";
            panel8.Size = new Size(356, 137);
            panel8.TabIndex = 7;
            // 
            // panel15
            // 
            panel15.Controls.Add(panel9);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(0, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(356, 137);
            panel15.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(panel18);
            panel9.Controls.Add(panel10);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(356, 137);
            panel9.TabIndex = 0;
            // 
            // panel18
            // 
            panel18.Controls.Add(txtDescription);
            panel18.Dock = DockStyle.Top;
            panel18.Location = new Point(0, 0);
            panel18.Name = "panel18";
            panel18.Size = new Size(356, 137);
            panel18.TabIndex = 15;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Location = new Point(0, 0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(356, 137);
            txtDescription.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel16);
            panel10.Location = new Point(9, 177);
            panel10.Name = "panel10";
            panel10.Size = new Size(341, 10);
            panel10.TabIndex = 14;
            // 
            // panel16
            // 
            panel16.BackColor = Color.MediumPurple;
            panel16.Controls.Add(label5);
            panel16.Dock = DockStyle.Left;
            panel16.Location = new Point(0, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(140, 10);
            panel16.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(131, 31);
            label5.TabIndex = 0;
            label5.Text = "Description";
            // 
            // frmProductDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1353, 633);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProductDisplay";
            Text = "frmProductDisplay";
            Load += frmProductDisplay_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel8.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel10.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private DataGridView dgvProducts;
        private Panel panel3;
        private ComboBox cmbCategory;
        private Button yuyty7u;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Panel panel11;
        private Panel panel1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel8;
        private Panel panel15;
        private Panel panel9;
        private Panel panel10;
        private Panel panel16;
        private Label label5;
        private PictureBox picProduct;
        private Panel panel7;
        private Panel panel12;
        private TextBox txtInStock;
        private Label label4;
        private Panel panel13;
        private TextBox txtPrice;
        private Label label2;
        private Panel panel14;
        private ComboBox cmbCategoryEdit;
        private Label label1;
        private Panel panel17;
        private TextBox txtName;
        private Label label3;
        private Panel panel18;
        private TextBox txtDescription;
        private Label lblProductID;
    }
}