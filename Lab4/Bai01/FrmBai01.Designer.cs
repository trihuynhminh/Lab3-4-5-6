namespace Bai01
{
    partial class FrmBai01
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
            rtbHTLMCode = new RichTextBox();
            txtLink = new TextBox();
            btnGet = new Button();
            SuspendLayout();
            // 
            // rtbHTLMCode
            // 
            rtbHTLMCode.Location = new Point(40, 107);
            rtbHTLMCode.Name = "rtbHTLMCode";
            rtbHTLMCode.Size = new Size(545, 301);
            rtbHTLMCode.TabIndex = 0;
            rtbHTLMCode.Text = "";
            // 
            // txtLink
            // 
            txtLink.Location = new Point(40, 47);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(430, 27);
            txtLink.TabIndex = 1;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(497, 47);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(88, 27);
            btnGet.TabIndex = 2;
            btnGet.Text = "GET";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // FrmBai01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 450);
            Controls.Add(btnGet);
            Controls.Add(txtLink);
            Controls.Add(rtbHTLMCode);
            Name = "FrmBai01";
            Text = "Bài 01";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbHTLMCode;
        private TextBox txtLink;
        private Button btnGet;
    }
}