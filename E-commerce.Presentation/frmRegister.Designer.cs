namespace E_commerce.Presentation
{
    partial class frmRegister

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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnSignUp = new Button();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtFirstname = new TextBox();
            txtLastname = new TextBox();
            txtUsername = new TextBox();
            txtpassword = new TextBox();
            txtConfirmpassword = new TextBox();
            label8 = new Label();
            txtEmail = new TextBox();
            lblLogin = new Label();
            btnDisplayPassword = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            panel1.Size = new Size(683, 44);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.Cancel;
            pictureBox1.Location = new Point(642, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseHover += pictureBox1_MouseHover;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 31);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.FromArgb(76, 175, 80);
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.White;
            btnSignUp.Location = new Point(3, 360);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(636, 48);
            btnSignUp.TabIndex = 6;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSave_Click;
            btnSignUp.MouseHover += btnAdd_MouseHover;
            // 
            // label4
            // 
            label4.BackColor = Color.BlueViolet;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 57);
            label4.Name = "label4";
            label4.Size = new Size(171, 33);
            label4.TabIndex = 7;
            label4.Text = "First Name";
            // 
            // label2
            // 
            label2.BackColor = Color.BlueViolet;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 106);
            label2.Name = "label2";
            label2.Size = new Size(171, 33);
            label2.TabIndex = 7;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.BackColor = Color.BlueViolet;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 270);
            label3.Name = "label3";
            label3.Size = new Size(171, 33);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // label5
            // 
            label5.BackColor = Color.BlueViolet;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 218);
            label5.Name = "label5";
            label5.Size = new Size(171, 33);
            label5.TabIndex = 7;
            label5.Text = "Username";
            // 
            // label6
            // 
            label6.BackColor = Color.BlueViolet;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 323);
            label6.Name = "label6";
            label6.Size = new Size(171, 33);
            label6.TabIndex = 7;
            label6.Text = "Confirm Password";
            // 
            // txtFirstname
            // 
            txtFirstname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstname.Location = new Point(217, 56);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.PlaceholderText = "First Name";
            txtFirstname.Size = new Size(398, 34);
            txtFirstname.TabIndex = 8;
            txtFirstname.KeyPress += txtFirstname_KeyPress;
            // 
            // txtLastname
            // 
            txtLastname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastname.Location = new Point(217, 106);
            txtLastname.Name = "txtLastname";
            txtLastname.PlaceholderText = "Last Name";
            txtLastname.Size = new Size(398, 34);
            txtLastname.TabIndex = 8;
            txtLastname.KeyPress += txtLastname_KeyPress;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(217, 215);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "username";
            txtUsername.Size = new Size(398, 34);
            txtUsername.TabIndex = 8;
            txtUsername.KeyPress += txtUsername_KeyPress;
            // 
            // txtpassword
            // 
            txtpassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(217, 270);
            txtpassword.Name = "txtpassword";
            txtpassword.PlaceholderText = "Password";
            txtpassword.Size = new Size(398, 34);
            txtpassword.TabIndex = 8;
            txtpassword.UseSystemPasswordChar = true;
            txtpassword.KeyPress += txtpassword_KeyPress;
            // 
            // txtConfirmpassword
            // 
            txtConfirmpassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmpassword.Location = new Point(217, 320);
            txtConfirmpassword.Name = "txtConfirmpassword";
            txtConfirmpassword.PlaceholderText = "Confirm Password";
            txtConfirmpassword.Size = new Size(398, 34);
            txtConfirmpassword.TabIndex = 8;
            txtConfirmpassword.UseSystemPasswordChar = true;
            txtConfirmpassword.KeyPress += txtConfirmpassword_KeyPress;
            // 
            // label8
            // 
            label8.BackColor = Color.BlueViolet;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(12, 164);
            label8.Name = "label8";
            label8.Size = new Size(171, 33);
            label8.TabIndex = 7;
            label8.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(217, 164);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "name@host.org";
            txtEmail.Size = new Size(398, 34);
            txtEmail.TabIndex = 8;
            txtEmail.KeyPress += txtEmail_KeyPress;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Cursor = Cursors.Hand;
            lblLogin.FlatStyle = FlatStyle.Flat;
            lblLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.MediumBlue;
            lblLogin.Location = new Point(271, 420);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(77, 31);
            lblLogin.TabIndex = 16;
            lblLogin.Text = "Log In";
            lblLogin.Click += lblLogin_Click;
            lblLogin.MouseHover += lblLogin_MouseHover;
            // 
            // btnDisplayPassword
            // 
            btnDisplayPassword.Location = new Point(622, 295);
            btnDisplayPassword.Name = "btnDisplayPassword";
            btnDisplayPassword.Size = new Size(49, 31);
            btnDisplayPassword.TabIndex = 17;
            btnDisplayPassword.Text = "😑";
            btnDisplayPassword.UseVisualStyleBackColor = true;
            btnDisplayPassword.Click += btnDisplayPassword_Click;
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(683, 460);
            Controls.Add(btnDisplayPassword);
            Controls.Add(lblLogin);
            Controls.Add(txtConfirmpassword);
            Controls.Add(txtpassword);
            Controls.Add(txtUsername);
            Controls.Add(txtEmail);
            Controls.Add(txtLastname);
            Controls.Add(txtFirstname);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(btnSignUp);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddNewUser";
            TopMost = true;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnSignUp;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private TextBox txtFirstname;
        private TextBox txtLastname;
        private TextBox txtUsername;
        private TextBox txtpassword;
        private TextBox txtConfirmpassword;
        private Label label8;
        private TextBox txtEmail;
        private Label lblLogin;
        private Button btnDisplayPassword;
    }
}