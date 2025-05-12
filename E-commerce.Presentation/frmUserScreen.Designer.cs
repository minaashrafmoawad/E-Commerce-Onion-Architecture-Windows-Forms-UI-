namespace E_commerce.Presentation
{
    partial class frmUserScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserScreen));
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlHeader = new Panel();
            picCart = new PictureBox();
            txtSearch = new TextBox();
            lblTitle = new Label();
            picCancel = new PictureBox();
            flowPanel = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCancel).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(pnlHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(flowPanel, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.3333359F));
            tableLayoutPanel1.Size = new Size(1331, 720);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.BlueViolet;
            pnlHeader.Controls.Add(picCart);
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(picCancel);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1325, 42);
            pnlHeader.TabIndex = 3;
            // 
            // picCart
            // 
            picCart.Image = (Image)resources.GetObject("picCart.Image");
            picCart.Location = new Point(1173, 5);
            picCart.Name = "picCart";
            picCart.Size = new Size(63, 34);
            picCart.SizeMode = PictureBoxSizeMode.StretchImage;
            picCart.TabIndex = 8;
            picCart.TabStop = false;
            picCart.Click += picCart_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(235, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "What are you looking for?";
            txtSearch.Size = new Size(672, 34);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.BlueViolet;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(183, 38);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "E-Commerce";
            // 
            // picCancel
            // 
            picCancel.Image = Properties.Resources.Cancel;
            picCancel.Location = new Point(1274, 7);
            picCancel.Name = "picCancel";
            picCancel.Size = new Size(42, 31);
            picCancel.SizeMode = PictureBoxSizeMode.StretchImage;
            picCancel.TabIndex = 4;
            picCancel.TabStop = false;
            picCancel.Click += picCancel_Click;
            // 
            // flowPanel
            // 
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.Location = new Point(3, 51);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(1325, 666);
            flowPanel.TabIndex = 4;
            // 
            // UserScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1331, 720);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserScreen";
            Text = "UserScreen";
            tableLayoutPanel1.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlHeader;
        private PictureBox picCancel;
        private Label lblTitle;
        private TextBox txtSearch;
        private PictureBox picCart;
        private FlowLayoutPanel flowPanel;
    }
}