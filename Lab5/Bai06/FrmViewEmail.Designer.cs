namespace Bai06
{
    partial class FrmViewEmail
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblSubject = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblFrom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            flowAttachments = new FlowLayoutPanel();
            lblAttachment = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            wvEmailContent = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnRely = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvEmailContent).BeginInit();
            SuspendLayout();
            // 
            // lblSubject
            // 
            lblSubject.BackColor = Color.Transparent;
            lblSubject.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubject.Location = new Point(12, 93);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(98, 39);
            lblSubject.TabIndex = 1;
            lblSubject.Text = "Subject";
            // 
            // lblFrom
            // 
            lblFrom.BackColor = Color.Transparent;
            lblFrom.ForeColor = Color.Black;
            lblFrom.Location = new Point(12, 4);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(37, 22);
            lblFrom.TabIndex = 2;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.BackColor = Color.Transparent;
            lblTo.Location = new Point(12, 36);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(20, 22);
            lblTo.TabIndex = 3;
            lblTo.Text = "To";
            // 
            // lblDate
            // 
            lblDate.BackColor = Color.Transparent;
            lblDate.Location = new Point(13, 66);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(65, 22);
            lblDate.TabIndex = 5;
            lblDate.Text = "Datetime";
            // 
            // flowAttachments
            // 
            flowAttachments.Location = new Point(4, 539);
            flowAttachments.Name = "flowAttachments";
            flowAttachments.Size = new Size(802, 132);
            flowAttachments.TabIndex = 6;
            // 
            // lblAttachment
            // 
            lblAttachment.BackColor = Color.Transparent;
            lblAttachment.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAttachment.Location = new Point(4, 509);
            lblAttachment.Name = "lblAttachment";
            lblAttachment.Size = new Size(103, 27);
            lblAttachment.TabIndex = 7;
            lblAttachment.Text = "Attachments";
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(wvEmailContent);
            guna2GradientPanel1.CustomizableEdges = customizableEdges1;
            guna2GradientPanel1.Location = new Point(4, 138);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientPanel1.Size = new Size(802, 375);
            guna2GradientPanel1.TabIndex = 8;
            // 
            // wvEmailContent
            // 
            wvEmailContent.AllowExternalDrop = true;
            wvEmailContent.CreationProperties = null;
            wvEmailContent.DefaultBackgroundColor = Color.White;
            wvEmailContent.Location = new Point(0, 4);
            wvEmailContent.Name = "wvEmailContent";
            wvEmailContent.Size = new Size(802, 366);
            wvEmailContent.TabIndex = 1;
            wvEmailContent.ZoomFactor = 1D;
            // 
            // btnRely
            // 
            btnRely.CustomizableEdges = customizableEdges3;
            btnRely.DisabledState.BorderColor = Color.DarkGray;
            btnRely.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRely.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRely.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnRely.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRely.Font = new Font("Segoe UI", 9F);
            btnRely.ForeColor = Color.White;
            btnRely.Location = new Point(701, 12);
            btnRely.Name = "btnRely";
            btnRely.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRely.Size = new Size(105, 37);
            btnRely.TabIndex = 9;
            btnRely.Text = "Rely";
            btnRely.Click += btnRely_Click;
            // 
            // FrmViewEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 683);
            Controls.Add(btnRely);
            Controls.Add(guna2GradientPanel1);
            Controls.Add(lblAttachment);
            Controls.Add(flowAttachments);
            Controls.Add(lblDate);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(lblSubject);
            Name = "FrmViewEmail";
            Text = "FrmViewEmail";
            Load += FrmViewEmail_Load;
            guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wvEmailContent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubject;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFrom;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private FlowLayoutPanel flowAttachments;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAttachment;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvEmailContent;
        private Guna.UI2.WinForms.Guna2GradientButton btnRely;
    }
}