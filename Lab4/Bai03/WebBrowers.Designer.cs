namespace Bai03
{
    partial class WebBrowers
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
            this.components = new System.ComponentModel.Container();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDownHTML = new System.Windows.Forms.Button();
            this.btnDownResources = new System.Windows.Forms.Button();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(130, 39);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(359, 26);
            this.txtURL.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 35);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(85, 34);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(534, 39);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(96, 30);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDownHTML
            // 
            this.btnDownHTML.Location = new System.Drawing.Point(390, 83);
            this.btnDownHTML.Name = "btnDownHTML";
            this.btnDownHTML.Size = new System.Drawing.Size(108, 32);
            this.btnDownHTML.TabIndex = 4;
            this.btnDownHTML.Text = "Down Files";
            this.btnDownHTML.UseVisualStyleBackColor = true;
            this.btnDownHTML.Click += new System.EventHandler(this.btnDownHTML_Click);
            // 
            // btnDownResources
            // 
            this.btnDownResources.Location = new System.Drawing.Point(534, 83);
            this.btnDownResources.Name = "btnDownResources";
            this.btnDownResources.Size = new System.Drawing.Size(168, 32);
            this.btnDownResources.TabIndex = 5;
            this.btnDownResources.Text = "Down Resources";
            this.btnDownResources.UseVisualStyleBackColor = true;
            this.btnDownResources.Click += new System.EventHandler(this.btnDownResources_Click);
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(12, 135);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(762, 290);
            this.webView.TabIndex = 6;
            this.webView.ZoomFactor = 1D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.btnDownResources);
            this.Controls.Add(this.btnDownHTML);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtURL);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDownHTML;
        private System.Windows.Forms.Button btnDownResources;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
    }
}

