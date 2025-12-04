namespace Lab4.Bai5 // Đảm bảo đúng Namespace của m
{
    partial class Form5
    {
        // Các biến cần thiết cho việc quản lý tài nguyên
        private System.ComponentModel.IContainer components = null;

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
            lblTitle = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnPOST = new Button();
            lblResult = new Label();
            rtbResult = new RichTextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(65, 49);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(864, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HTTP POST: ĐĂNG NHẬP VỚI API (BÀI 5)";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(108, 172);
            lblUsername.Margin = new Padding(6, 0, 6, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(126, 32);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(108, 258);
            lblPassword.Margin = new Padding(6, 0, 6, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(116, 32);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(260, 172);
            txtUsername.Margin = new Padding(6, 7, 6, 7);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(537, 39);
            txtUsername.TabIndex = 3;
            txtUsername.Text = "phatpt";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(260, 258);
            txtPassword.Margin = new Padding(6, 7, 6, 7);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(537, 39);
            txtPassword.TabIndex = 4;
            txtPassword.Text = "123456";
            // 
            // btnPOST
            // 
            btnPOST.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPOST.Location = new Point(815, 172);
            btnPOST.Margin = new Padding(6, 7, 6, 7);
            btnPOST.Name = "btnPOST";
            btnPOST.Size = new Size(260, 135);
            btnPOST.TabIndex = 5;
            btnPOST.Text = "ĐĂNG NHẬP (POST)";
            btnPOST.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(108, 345);
            lblResult.Margin = new Padding(6, 0, 6, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(231, 36);
            lblResult.TabIndex = 6;
            lblResult.Text = "Kết quả Phản hồi:";
            // 
            // rtbResult
            // 
            rtbResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbResult.Location = new Point(115, 406);
            rtbResult.Margin = new Padding(6, 7, 6, 7);
            rtbResult.Name = "rtbResult";
            rtbResult.ReadOnly = true;
            rtbResult.Size = new Size(955, 486);
            rtbResult.TabIndex = 7;
            rtbResult.Text = "Thông tin token sẽ hiển thị tại đây sau khi đăng nhập thành công...";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 985);
            Controls.Add(rtbResult);
            Controls.Add(lblResult);
            Controls.Add(btnPOST);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Margin = new Padding(6, 7, 6, 7);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 5: HTTP POST - Đăng nhập";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        // KHAI BÁO CÁC ĐỐI TƯỢNG CONTROL (Rất quan trọng)
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnPOST;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.RichTextBox rtbResult;
    }
}