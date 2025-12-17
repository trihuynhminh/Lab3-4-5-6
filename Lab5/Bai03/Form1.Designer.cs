namespace Bai03
{
    partial class Form1
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.rdoIMAP = new System.Windows.Forms.RadioButton();
            this.rdoPOP3 = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lvEmails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader())); // KHAI BÁO CỘT 1
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader())); // KHAI BÁO CỘT 2
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader())); // KHAI BÁO CỘT 3
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRecent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(162, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(166, 26);
            this.txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(162, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(166, 26);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true; // Thêm để ẩn mật khẩu
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(587, 50);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(103, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // rdoIMAP
            // 
            this.rdoIMAP.AutoSize = true;
            this.rdoIMAP.Checked = true;
            this.rdoIMAP.Location = new System.Drawing.Point(41, 192);
            this.rdoIMAP.Name = "rdoIMAP";
            this.rdoIMAP.Size = new System.Drawing.Size(73, 24);
            this.rdoIMAP.TabIndex = 3;
            this.rdoIMAP.TabStop = true;
            this.rdoIMAP.Text = "IMAP";
            this.rdoIMAP.UseVisualStyleBackColor = true;
            // 
            // rdoPOP3
            // 
            this.rdoPOP3.AutoSize = true;
            this.rdoPOP3.Location = new System.Drawing.Point(177, 192);
            this.rdoPOP3.Name = "rdoPOP3";
            this.rdoPOP3.Size = new System.Drawing.Size(75, 24);
            this.rdoPOP3.TabIndex = 4;
            this.rdoPOP3.Text = "POP3";
            this.rdoPOP3.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(37, 152);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 20);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total: 0";
            // 
            // lvEmails
            // 
            this.lvEmails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3}); // <--- THÊM CỘT
            this.lvEmails.FullRowSelect = true; // Thêm để dễ chọn thư
            this.lvEmails.HideSelection = false;
            this.lvEmails.Location = new System.Drawing.Point(41, 251);
            this.lvEmails.Name = "lvEmails";
            this.lvEmails.Size = new System.Drawing.Size(718, 173);
            this.lvEmails.TabIndex = 6;
            this.lvEmails.UseCompatibleStateImageBehavior = false;
            this.lvEmails.View = System.Windows.Forms.View.Details; // <--- RẤT QUAN TRỌNG
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Email (Subject)";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "From";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Thời gian";
            this.columnHeader3.Width = 150;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(37, 25);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 20);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email: ";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(37, 81);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // lblRecent
            // 
            this.lblRecent.AutoSize = true;
            this.lblRecent.Location = new System.Drawing.Point(130, 152);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(78, 20);
            this.lblRecent.TabIndex = 9;
            this.lblRecent.Text = "Recent: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRecent);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lvEmails);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.rdoPOP3);
            this.Controls.Add(this.rdoIMAP);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Name = "Form1";
            this.Text = "Email Client (IMAP/POP3)"; // Đổi tên dễ nhận biết
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.RadioButton rdoIMAP;
        private System.Windows.Forms.RadioButton rdoPOP3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ListView lvEmails;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRecent;

        // KHAI BÁO THÊM 3 COLUMN HEADER
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}