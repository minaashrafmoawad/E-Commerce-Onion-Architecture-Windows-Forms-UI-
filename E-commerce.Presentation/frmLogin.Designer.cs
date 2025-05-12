namespace E_commerce.Presentation
{
    partial class frmLogin
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
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label5 = new Label();
            label3 = new Label();
            btnLogIn = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lblCreateNewAccount = new Label();
            btnDisplayPassword = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(119, 132);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "password";
            txtPassword.Size = new Size(302, 34);
            txtPassword.TabIndex = 13;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(119, 84);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "username";
            txtUserName.Size = new Size(302, 34);
            txtUserName.TabIndex = 14;
            txtUserName.KeyPress += txtUserName_KeyPress;
            // 
            // label5
            // 
            label5.BackColor = Color.BlueViolet;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 84);
            label5.Name = "label5";
            label5.Size = new Size(110, 33);
            label5.TabIndex = 11;
            label5.Text = "Username";
            // 
            // label3
            // 
            label3.BackColor = Color.BlueViolet;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 132);
            label3.Name = "label3";
            label3.Size = new Size(110, 33);
            label3.TabIndex = 12;
            label3.Text = "Password";
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.FromArgb(76, 175, 80);
            btnLogIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(0, 182);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(452, 48);
            btnLogIn.TabIndex = 10;
            btnLogIn.Text = "Log in";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            btnLogIn.MouseHover += btnLogIn_MouseHover;
            // 
            // panel1
            // 
            panel1.BackColor = Color.BlueViolet;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(484, 44);
            panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.Cancel;
            pictureBox1.Location = new Point(443, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(77, 31);
            label1.TabIndex = 0;
            label1.Text = "Log In";
            // 
            // lblCreateNewAccount
            // 
            lblCreateNewAccount.AutoSize = true;
            lblCreateNewAccount.Cursor = Cursors.Hand;
            lblCreateNewAccount.FlatStyle = FlatStyle.Flat;
            lblCreateNewAccount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreateNewAccount.ForeColor = Color.MediumBlue;
            lblCreateNewAccount.Location = new Point(103, 234);
            lblCreateNewAccount.Name = "lblCreateNewAccount";
            lblCreateNewAccount.Size = new Size(222, 31);
            lblCreateNewAccount.TabIndex = 15;
            lblCreateNewAccount.Text = "Create New Account";
            lblCreateNewAccount.Click += lblCreateNewAccount_Click;
            lblCreateNewAccount.MouseHover += lblCreateNewAccount_MouseHover;
            // 
            // btnDisplayPassword
            // 
            btnDisplayPassword.Location = new Point(427, 136);
            btnDisplayPassword.Name = "btnDisplayPassword";
            btnDisplayPassword.Size = new Size(49, 29);
            btnDisplayPassword.TabIndex = 16;
            btnDisplayPassword.Text = "😑";
            btnDisplayPassword.UseVisualStyleBackColor = true;
            btnDisplayPassword.Click += button1_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(484, 274);
            Controls.Add(btnDisplayPassword);
            Controls.Add(lblCreateNewAccount);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(btnLogIn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            MouseHover += frmLogin_MouseHover;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label5;
        private Label label3;
        private Button btnLogIn;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label lblCreateNewAccount;
        private Button btnDisplayPassword;
    }
}