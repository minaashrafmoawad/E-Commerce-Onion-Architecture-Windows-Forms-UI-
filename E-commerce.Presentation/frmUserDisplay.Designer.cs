namespace E_commerce.Presentation
{
    partial class frmUserDisplay
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
            dgvUsers = new DataGridView();
            panel1 = new Panel();
            lblNewAdmin = new Label();
            panel2 = new Panel();
            label1 = new Label();
            cmbRole = new ComboBox();
            picNewAdmin = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNewAdmin).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.BlueViolet;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvUsers.Location = new Point(0, 43);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(1134, 407);
            dgvUsers.TabIndex = 6;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Background;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(lblNewAdmin);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(picNewAdmin);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1134, 43);
            panel1.TabIndex = 7;
            // 
            // lblNewAdmin
            // 
            lblNewAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNewAdmin.AutoSize = true;
            lblNewAdmin.BackColor = Color.Transparent;
            lblNewAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewAdmin.ForeColor = Color.White;
            lblNewAdmin.Location = new Point(1015, 6);
            lblNewAdmin.Name = "lblNewAdmin";
            lblNewAdmin.Size = new Size(114, 28);
            lblNewAdmin.TabIndex = 1;
            lblNewAdmin.Text = "New Admin";
            lblNewAdmin.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbRole);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(473, 43);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 43);
            label1.TabIndex = 2;
            label1.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(103, 3);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(310, 36);
            cmbRole.TabIndex = 1;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // picNewAdmin
            // 
            picNewAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picNewAdmin.BackColor = Color.Transparent;
            picNewAdmin.Image = Properties.Resources.Add;
            picNewAdmin.Location = new Point(975, 0);
            picNewAdmin.Name = "picNewAdmin";
            picNewAdmin.Size = new Size(34, 43);
            picNewAdmin.SizeMode = PictureBoxSizeMode.StretchImage;
            picNewAdmin.TabIndex = 0;
            picNewAdmin.TabStop = false;
            picNewAdmin.Click += picNewAdmin_Click;
            // 
            // frmUserDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 450);
            Controls.Add(dgvUsers);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmUserDisplay";
            Text = "frmUserDisplay";
            Load += frmUserDisplay_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picNewAdmin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private Panel panel1;
        private ComboBox cmbRole;
        private Panel panel2;
        private Label label1;
        private PictureBox picNewAdmin;
        private Label lblNewAdmin;
    }
}