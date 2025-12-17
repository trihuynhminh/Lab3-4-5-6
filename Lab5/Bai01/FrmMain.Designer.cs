namespace Bai01
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTo = new Label();
            lblSubject = new Label();
            lblBody = new Label();
            btnSend = new Button();
            txtTo = new TextBox();
            rtbBody = new RichTextBox();
            txtSubject = new TextBox();
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(25, 111);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 20);
            lblTo.TabIndex = 1;
            lblTo.Text = "To";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(25, 159);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(58, 20);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Subject";
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Location = new Point(25, 198);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(43, 20);
            lblBody.TabIndex = 3;
            lblBody.Text = "Body";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(486, 12);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(118, 41);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(100, 108);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(366, 27);
            txtTo.TabIndex = 6;
            // 
            // rtbBody
            // 
            rtbBody.Location = new Point(100, 198);
            rtbBody.Name = "rtbBody";
            rtbBody.Size = new Size(504, 288);
            rtbBody.TabIndex = 7;
            rtbBody.Text = "";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(100, 156);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(504, 27);
            txtSubject.TabIndex = 8;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(25, 15);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(25, 63);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 12);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(366, 27);
            txtEmail.TabIndex = 11;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(100, 60);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(366, 27);
            txtPassword.TabIndex = 12;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 506);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(txtSubject);
            Controls.Add(rtbBody);
            Controls.Add(txtTo);
            Controls.Add(btnSend);
            Controls.Add(lblBody);
            Controls.Add(lblSubject);
            Controls.Add(lblTo);
            Name = "FrmMain";
            Text = "Bài 1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTo;
        private Label lblSubject;
        private Label lblBody;
        private Button btnSend;
        private TextBox txtTo;
        private RichTextBox rtbBody;
        private TextBox txtSubject;
        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
    }
}
