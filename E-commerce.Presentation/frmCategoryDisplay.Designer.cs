namespace E_commerce.Presentation
{
    partial class frmCategoryDisplay
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
            panel1 = new Panel();
            panel7 = new Panel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel6 = new Panel();
            panel10 = new Panel();
            txtDescription = new TextBox();
            panel9 = new Panel();
            label1 = new Label();
            panel8 = new Panel();
            panel5 = new Panel();
            txtCateName = new TextBox();
            panel4 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            lblID = new Label();
            panel2 = new Panel();
            dgvCategories = new DataGridView();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(428, 534);
            panel1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnAdd);
            panel7.Controls.Add(btnUpdate);
            panel7.Controls.Add(btnDelete);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 379);
            panel7.Name = "panel7";
            panel7.Size = new Size(428, 155);
            panel7.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.Dock = DockStyle.Bottom;
            btnAdd.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(0, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(428, 40);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DarkGreen;
            btnUpdate.Dock = DockStyle.Bottom;
            btnUpdate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(0, 62);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(428, 43);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Dock = DockStyle.Bottom;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 105);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(428, 50);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 120);
            panel6.Name = "panel6";
            panel6.Size = new Size(428, 414);
            panel6.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(txtDescription);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 55);
            panel10.Name = "panel10";
            panel10.Size = new Size(428, 359);
            panel10.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Top;
            txtDescription.Location = new Point(0, 0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(428, 181);
            txtDescription.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Controls.Add(label1);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 14);
            panel9.Name = "panel9";
            panel9.Size = new Size(428, 41);
            panel9.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = Color.MediumPurple;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(121, 41);
            label1.TabIndex = 3;
            label1.Text = "Description";
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(428, 14);
            panel8.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtCateName);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 80);
            panel5.Name = "panel5";
            panel5.Size = new Size(428, 40);
            panel5.TabIndex = 0;
            // 
            // txtCateName
            // 
            txtCateName.Dock = DockStyle.Fill;
            txtCateName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCateName.Location = new Point(0, 0);
            txtCateName.Name = "txtCateName";
            txtCateName.PlaceholderText = "Name";
            txtCateName.Size = new Size(428, 34);
            txtCateName.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 41);
            panel4.Name = "panel4";
            panel4.Size = new Size(428, 39);
            panel4.TabIndex = 0;
            // 
            // label3
            // 
            label3.BackColor = Color.MediumPurple;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(121, 39);
            label3.TabIndex = 2;
            label3.Text = "Name";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblID);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(428, 41);
            panel3.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(372, 9);
            lblID.Name = "lblID";
            lblID.Size = new Size(50, 20);
            lblID.TabIndex = 0;
            lblID.Text = "label2";
            lblID.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dgvCategories);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(428, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(717, 534);
            panel2.TabIndex = 0;
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.BlueViolet;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Location = new Point(0, 0);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersWidth = 51;
            dgvCategories.Size = new Size(717, 534);
            dgvCategories.TabIndex = 0;
            dgvCategories.CellClick += dgvCategories_CellClick;
            dgvCategories.CellContentClick += dgvCategories_CellContentClick;
            // 
            // frmCategoryDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1145, 534);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCategoryDisplay";
            Text = "CategoryDisplay";
            Load += frmCategoryDisplay_Load;
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Label label3;
        private Panel panel10;
        private TextBox txtDescription;
        private Panel panel9;
        private Label label1;
        private Panel panel8;
        private TextBox txtCateName;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dgvCategories;
        private Label lblID;
    }
}