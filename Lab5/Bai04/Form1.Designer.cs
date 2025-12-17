// Các using bắt buộc phải có ở đầu file Form1.Designer.cs
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Bai04
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flpMovieList = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPhimDangChieu = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.webViewDetails = new Microsoft.Web.WebView2.WinForms.WebView2();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flpMovieList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webViewDetails)).BeginInit();
     

            //
            // splitContainer1
            //
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            //
            // splitContainer1.Panel1 (Panel chứa danh sách phim)
            //
            this.splitContainer1.Panel1.Controls.Add(this.flpMovieList);
            //
            // splitContainer1.Panel2 (Panel chứa WebView2)
            //
            this.splitContainer1.Panel2.Controls.Add(this.webViewDetails);
            this.splitContainer1.Size = new System.Drawing.Size(873, 513);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 0;

            //
            // flpMovieList
            //
            this.flpMovieList.AutoScroll = true;
            this.flpMovieList.Controls.Add(this.lblPhimDangChieu);
            this.flpMovieList.Controls.Add(this.progressBar1);
            this.flpMovieList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMovieList.Location = new System.Drawing.Point(0, 0);
            this.flpMovieList.Name = "flpMovieList";
            this.flpMovieList.Size = new System.Drawing.Size(291, 513);
            this.flpMovieList.TabIndex = 0;

            //
            // lblPhimDangChieu
            //
            this.lblPhimDangChieu.AutoSize = true;
            this.lblPhimDangChieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhimDangChieu.Location = new System.Drawing.Point(3, 0);
            this.lblPhimDangChieu.Name = "lblPhimDangChieu";
            this.lblPhimDangChieu.Size = new System.Drawing.Size(204, 25);
            this.lblPhimDangChieu.TabIndex = 0;
            this.lblPhimDangChieu.Text = "PHIM ĐANG CHIẾU";

            //
            // progressBar1
            //
            this.progressBar1.Location = new System.Drawing.Point(3, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(288, 22);
            this.progressBar1.TabIndex = 1;

            //
            // webViewDetails
            //
            this.webViewDetails.AllowExternalDrop = true;
            this.webViewDetails.CreationProperties = null;
            this.webViewDetails.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewDetails.Location = new System.Drawing.Point(0, 0);
            this.webViewDetails.Name = "webViewDetails";
            this.webViewDetails.Size = new System.Drawing.Size(578, 513);
            this.webViewDetails.TabIndex = 0;
            this.webViewDetails.ZoomFactor = 1D;

            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 513);
            this.Controls.Add(this.splitContainer1); // Chỉ cần thêm splitContainer1 đã chứa mọi thứ
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false); // Quan trọng: Đảm bảo Panel1 có ResumeLayout/PerformLayout
            this.splitContainer1.Panel2.ResumeLayout(false); // Quan trọng: Đảm bảo Panel2 có ResumeLayout/PerformLayout
            this.splitContainer1.ResumeLayout(false);

            this.flpMovieList.ResumeLayout(false);
            this.flpMovieList.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.webViewDetails)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo các Controls
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flpMovieList;
        private System.Windows.Forms.Label lblPhimDangChieu;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewDetails;

        // Lưu ý: Đã loại bỏ splitContainer2 thừa, chỉ giữ lại splitContainer1
    }
}