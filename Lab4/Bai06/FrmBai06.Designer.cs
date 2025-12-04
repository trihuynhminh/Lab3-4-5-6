namespace Bai06
{
    partial class FrmBai06
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
            button1 = new Button();
            txtToken = new TextBox();
            rtbUserInfo = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(442, 23);
            button1.Name = "button1";
            button1.Size = new Size(115, 28);
            button1.TabIndex = 0;
            button1.Text = "GET";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(50, 23);
            txtToken.Name = "txtToken";
            txtToken.PlaceholderText = "Token";
            txtToken.Size = new Size(369, 27);
            txtToken.TabIndex = 1;
            // 
            // rtbUserInfo
            // 
            rtbUserInfo.Location = new Point(50, 72);
            rtbUserInfo.Name = "rtbUserInfo";
            rtbUserInfo.Size = new Size(507, 325);
            rtbUserInfo.TabIndex = 2;
            rtbUserInfo.Text = "";
            // 
            // FrmBai06
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 459);
            Controls.Add(rtbUserInfo);
            Controls.Add(txtToken);
            Controls.Add(button1);
            Name = "FrmBai06";
            Text = "Bài 6";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtToken;
        private RichTextBox rtbUserInfo;
    }
}