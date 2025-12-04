namespace Bai7Riel
{
    partial class FormRegister
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            txtUser = new TextBox();
            txtPass = new TextBox();
            txtEmail = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            dtpDob = new DateTimePicker();
            btnSubmit = new Button();
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.Location = new Point(184, 93);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(324, 43);
            txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.Location = new Point(184, 142);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(324, 43);
            txtPass.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(184, 191);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(324, 43);
            txtEmail.TabIndex = 6;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(378, 243);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(130, 43);
            txtFirstName.TabIndex = 10;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(181, 240);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(121, 43);
            txtLastName.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(184, 289);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(324, 43);
            txtPhone.TabIndex = 12;
            // 
            // dtpDob
            // 
            dtpDob.Font = new Font("Segoe UI", 10F);
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.Location = new Point(184, 338);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(324, 43);
            dtpDob.TabIndex = 14;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Green;
            btnSubmit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(184, 391);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(160, 45);
            btnSubmit.TabIndex = 15;
            btnSubmit.Text = "ĐĂNG KÝ NGAY";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(57, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(438, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN MỚI";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(37, 96);
            label1.Name = "label1";
            label1.Size = new Size(142, 37);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(37, 145);
            label2.Name = "label2";
            label2.Size = new Size(134, 37);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(37, 194);
            label3.Name = "label3";
            label3.Size = new Size(88, 37);
            label3.TabIndex = 5;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(37, 243);
            label4.Name = "label4";
            label4.Size = new Size(58, 37);
            label4.TabIndex = 7;
            label4.Text = "Họ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(319, 243);
            label5.Name = "label5";
            label5.Size = new Size(63, 37);
            label5.TabIndex = 9;
            label5.Text = "Tên:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(37, 292);
            label6.Name = "label6";
            label6.Size = new Size(70, 37);
            label6.TabIndex = 11;
            label6.Text = "SĐT:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(37, 341);
            label7.Name = "label7";
            label7.Size = new Size(141, 37);
            label7.TabIndex = 13;
            label7.Text = "Ngày sinh:";
            // 
            // FormRegister
            // 
            ClientSize = new Size(867, 591);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(txtUser);
            Controls.Add(label2);
            Controls.Add(txtPass);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtLastName);
            Controls.Add(label5);
            Controls.Add(txtFirstName);
            Controls.Add(label6);
            Controls.Add(txtPhone);
            Controls.Add(label7);
            Controls.Add(dtpDob);
            Controls.Add(btnSubmit);
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Ký Tài Khoản";
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.TextBox txtUser, txtPass, txtEmail, txtFirstName, txtLastName, txtPhone;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblTitle, label1, label2, label3, label4, label5, label6, label7;
    }
}