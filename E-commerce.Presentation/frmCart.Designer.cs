namespace E_commerce.Presentation
{
    partial class frmCart
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            picCancel = new PictureBox();
            btnOrder = new Button();
            dgvCart = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnOrder, 0, 2);
            tableLayoutPanel1.Controls.Add(dgvCart, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.15974F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.84026F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.Size = new Size(925, 457);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.BlueViolet;
            panel1.Controls.Add(picCancel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(919, 39);
            panel1.TabIndex = 0;
            // 
            // picCancel
            // 
            picCancel.Image = Properties.Resources.Cancel;
            picCancel.Location = new Point(874, 3);
            picCancel.Name = "picCancel";
            picCancel.Size = new Size(36, 25);
            picCancel.SizeMode = PictureBoxSizeMode.StretchImage;
            picCancel.TabIndex = 5;
            picCancel.TabStop = false;
            picCancel.Click += picCancel_Click;
            // 
            // btnOrder
            // 
            btnOrder.BackColor = Color.Green;
            btnOrder.Dock = DockStyle.Fill;
            btnOrder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrder.ForeColor = Color.White;
            btnOrder.Location = new Point(3, 411);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(919, 43);
            btnOrder.TabIndex = 1;
            btnOrder.Text = "Order";
            btnOrder.UseVisualStyleBackColor = false;
            btnOrder.Click += btnOrder_Click;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(3, 48);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(300, 188);
            dgvCart.TabIndex = 2;
            // 
            // frmCart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(925, 457);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCart";
            Text = "frmCart";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnOrder;
        private DataGridView dgvCart;
        private PictureBox picCancel;
    }
}