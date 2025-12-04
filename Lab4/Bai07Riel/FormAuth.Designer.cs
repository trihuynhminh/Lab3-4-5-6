namespace Bai7Riel
{
    partial class FormAuth
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            label1 = new Label();
            label2 = new Label();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI", 11F);
            txtUser.Location = new Point(278, 164);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(280, 47);
            txtUser.TabIndex = 3;
            txtUser.Text = "phatpt";
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI", 11F);
            txtPass.Location = new Point(278, 234);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(280, 47);
            txtPass.TabIndex = 4;
            txtPass.Text = "123456";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(278, 299);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(224, 60);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.WhiteSmoke;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.Location = new Point(526, 302);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(224, 54);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Đăng Ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(85, 170);
            label1.Name = "label1";
            label1.Size = new Size(150, 41);
            label1.TabIndex = 1;
            label1.Text = "Tài khoản:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(86, 240);
            label2.Name = "label2";
            label2.Size = new Size(149, 41);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu:";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(140, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(555, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormAuth
            // 
            ClientSize = new Size(819, 476);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtUser);
            Controls.Add(txtPass);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Name = "FormAuth";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - Bai7Riel";
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.TextBox txtUser, txtPass;
        private System.Windows.Forms.Button btnLogin, btnRegister;
        private System.Windows.Forms.Label label1, label2, lblTitle;
    }
}