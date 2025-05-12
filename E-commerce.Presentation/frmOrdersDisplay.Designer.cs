namespace E_commerce.Presentation
{
    partial class frmOrdersDisplay
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
            cmbOrderStatus = new ComboBox();
            dgvOrders = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Background;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(cmbOrderStatus);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 43);
            panel1.TabIndex = 5;
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.Dock = DockStyle.Left;
            cmbOrderStatus.FormattingEnabled = true;
            cmbOrderStatus.Location = new Point(0, 0);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(197, 28);
            cmbOrderStatus.TabIndex = 0;
            cmbOrderStatus.Text = "Status";
            cmbOrderStatus.SelectedIndexChanged += cmbOrderStatus_SelectedIndexChanged;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 49);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(788, 399);
            dgvOrders.TabIndex = 6;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // frmOrdersDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(dgvOrders);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmOrdersDisplay";
            Text = "frmProductManagement";
            Load += frmOrdersDisplay_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ComboBox cmbOrderStatus;
        private DataGridView dgvOrders;
    }
}