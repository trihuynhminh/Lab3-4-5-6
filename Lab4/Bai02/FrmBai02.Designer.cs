using System.Windows.Forms;
using System.Drawing;

namespace Bai02
{
    partial class FrmBai02
    {
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

        private void InitializeComponent()
        {
            txtUrl = new TextBox();
            txtFilePath = new TextBox();
            btnDownload = new Button();
            webViewMain = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webViewMain).BeginInit();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(48, 33);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "Url";
            txtUrl.Size = new Size(561, 27);
            txtUrl.TabIndex = 0;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(48, 80);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "File path";
            txtFilePath.Size = new Size(561, 27);
            txtFilePath.TabIndex = 1;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(636, 33);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(115, 39);
            btnDownload.TabIndex = 3;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // webViewMain
            // 
            webViewMain.AllowExternalDrop = true;
            webViewMain.CreationProperties = null;
            webViewMain.DefaultBackgroundColor = Color.White;
            webViewMain.Location = new Point(47, 129);
            webViewMain.Name = "webViewMain";
            webViewMain.Size = new Size(704, 323);
            webViewMain.TabIndex = 4;
            webViewMain.ZoomFactor = 1D;
            // 
            // FrmBai02
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 493);
            Controls.Add(webViewMain);
            Controls.Add(btnDownload);
            Controls.Add(txtFilePath);
            Controls.Add(txtUrl);
            Name = "FrmBai02";
            Text = "Bài 02";
            ((System.ComponentModel.ISupportInitialize)webViewMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private TextBox txtFilePath;
        private Button btnDownload;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewMain;
    }
}
