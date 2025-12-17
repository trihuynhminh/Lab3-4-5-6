// Trong file MovieItemControl.Designer.cs
namespace Bai04
{
    partial class MovieItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnBookTicket = new System.Windows.Forms.Button();
            this.lblTicketInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(5, 5);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(150, 220);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPoster.TabIndex = 0;
            this.pbPoster.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 230);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Tên phim";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Enabled = false;
            this.lblUrl.Location = new System.Drawing.Point(5, 260);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(36, 20);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL";
            this.lblUrl.Visible = false;
            // 
            // btnBookTicket
            // 
            this.btnBookTicket.BackColor = System.Drawing.Color.Maroon;
            this.btnBookTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookTicket.ForeColor = System.Drawing.Color.White;
            this.btnBookTicket.Location = new System.Drawing.Point(5, 285);
            this.btnBookTicket.Name = "btnBookTicket";
            this.btnBookTicket.Size = new System.Drawing.Size(150, 35);
            this.btnBookTicket.TabIndex = 4;
            this.btnBookTicket.Text = "ĐẶT VÉ";
            this.btnBookTicket.UseVisualStyleBackColor = false;
            // 
            // lblTicketInfo
            // 
            this.lblTicketInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketInfo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTicketInfo.Location = new System.Drawing.Point(5, 260);
            this.lblTicketInfo.Name = "lblTicketInfo";
            this.lblTicketInfo.Size = new System.Drawing.Size(150, 20);
            this.lblTicketInfo.TabIndex = 3;
            this.lblTicketInfo.Text = "Đã bán: X / Y vé";
            this.lblTicketInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MovieItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnBookTicket);
            this.Controls.Add(this.lblTicketInfo);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPoster);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "MovieItemControl";
            this.Size = new System.Drawing.Size(160, 325);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnBookTicket;
        private System.Windows.Forms.Label lblTicketInfo;
    }
}
