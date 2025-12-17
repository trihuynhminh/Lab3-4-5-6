namespace Bai06
{
    partial class FrmSendEmail
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblFrom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTo = new Label();
            txtFrom = new Guna.UI2.WinForms.Guna2TextBox();
            txtTo = new Guna.UI2.WinForms.Guna2TextBox();
            txtBody = new Guna.UI2.WinForms.Guna2TextBox();
            flowAttachments = new FlowLayoutPanel();
            txtSubject = new Guna.UI2.WinForms.Guna2TextBox();
            lblSuject = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblBody = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnAttach = new Guna.UI2.WinForms.Guna2GradientButton();
            btnSend = new Guna.UI2.WinForms.Guna2GradientButton();
            lblAttach = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // lblFrom
            // 
            lblFrom.BackColor = Color.Transparent;
            lblFrom.Location = new Point(29, 27);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(37, 22);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(29, 72);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 20);
            lblTo.TabIndex = 1;
            lblTo.Text = "To";
            // 
            // txtFrom
            // 
            txtFrom.CustomizableEdges = customizableEdges1;
            txtFrom.DefaultText = "";
            txtFrom.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFrom.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFrom.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFrom.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFrom.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFrom.Font = new Font("Segoe UI", 9F);
            txtFrom.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFrom.Location = new Point(80, 27);
            txtFrom.Margin = new Padding(3, 4, 3, 4);
            txtFrom.Name = "txtFrom";
            txtFrom.PlaceholderText = "";
            txtFrom.SelectedText = "";
            txtFrom.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtFrom.Size = new Size(326, 26);
            txtFrom.TabIndex = 2;
            // 
            // txtTo
            // 
            txtTo.CustomizableEdges = customizableEdges3;
            txtTo.DefaultText = "";
            txtTo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTo.Font = new Font("Segoe UI", 9F);
            txtTo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTo.Location = new Point(80, 66);
            txtTo.Margin = new Padding(3, 4, 3, 4);
            txtTo.Name = "txtTo";
            txtTo.PlaceholderText = "";
            txtTo.SelectedText = "";
            txtTo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTo.Size = new Size(326, 26);
            txtTo.TabIndex = 3;
            // 
            // txtBody
            // 
            txtBody.CustomizableEdges = customizableEdges5;
            txtBody.DefaultText = "";
            txtBody.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBody.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBody.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBody.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBody.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBody.Font = new Font("Segoe UI", 9F);
            txtBody.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBody.Location = new Point(80, 157);
            txtBody.Margin = new Padding(3, 4, 3, 4);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.PlaceholderText = "";
            txtBody.SelectedText = "";
            txtBody.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtBody.Size = new Size(499, 279);
            txtBody.TabIndex = 4;
            // 
            // flowAttachments
            // 
            flowAttachments.Location = new Point(585, 66);
            flowAttachments.Name = "flowAttachments";
            flowAttachments.Size = new Size(158, 370);
            flowAttachments.TabIndex = 5;
            // 
            // txtSubject
            // 
            txtSubject.CustomizableEdges = customizableEdges7;
            txtSubject.DefaultText = "";
            txtSubject.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSubject.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSubject.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSubject.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSubject.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSubject.Font = new Font("Segoe UI", 9F);
            txtSubject.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSubject.Location = new Point(80, 114);
            txtSubject.Margin = new Padding(3, 4, 3, 4);
            txtSubject.Name = "txtSubject";
            txtSubject.PlaceholderText = "";
            txtSubject.SelectedText = "";
            txtSubject.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSubject.Size = new Size(499, 35);
            txtSubject.TabIndex = 6;
            // 
            // lblSuject
            // 
            lblSuject.BackColor = Color.Transparent;
            lblSuject.Location = new Point(22, 114);
            lblSuject.Name = "lblSuject";
            lblSuject.Size = new Size(52, 22);
            lblSuject.TabIndex = 7;
            lblSuject.Text = "Subject";
            // 
            // lblBody
            // 
            lblBody.BackColor = Color.Transparent;
            lblBody.Location = new Point(29, 172);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(37, 22);
            lblBody.TabIndex = 8;
            lblBody.Text = "Body";
            // 
            // btnAttach
            // 
            btnAttach.CustomizableEdges = customizableEdges9;
            btnAttach.DisabledState.BorderColor = Color.DarkGray;
            btnAttach.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAttach.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAttach.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnAttach.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAttach.Font = new Font("Segoe UI", 9F);
            btnAttach.ForeColor = Color.White;
            btnAttach.Location = new Point(531, 66);
            btnAttach.Name = "btnAttach";
            btnAttach.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAttach.Size = new Size(45, 41);
            btnAttach.TabIndex = 9;
            btnAttach.Text = "📎";
            btnAttach.Click += btnAttach_Click;
            // 
            // btnSend
            // 
            btnSend.CustomizableEdges = customizableEdges11;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.Font = new Font("Segoe UI", 9F);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(494, 27);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSend.Size = new Size(82, 35);
            btnSend.TabIndex = 10;
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click;
            // 
            // lblAttach
            // 
            lblAttach.BackColor = Color.Transparent;
            lblAttach.Location = new Point(585, 27);
            lblAttach.Name = "lblAttach";
            lblAttach.Size = new Size(86, 22);
            lblAttach.TabIndex = 11;
            lblAttach.Text = "Attachments";
            // 
            // FrmSendEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 452);
            Controls.Add(lblAttach);
            Controls.Add(btnSend);
            Controls.Add(btnAttach);
            Controls.Add(lblBody);
            Controls.Add(lblSuject);
            Controls.Add(txtSubject);
            Controls.Add(flowAttachments);
            Controls.Add(txtBody);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Name = "FrmSendEmail";
            Text = "Send Email";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblFrom;
        private Label lblTo;
        private Guna.UI2.WinForms.Guna2TextBox txtFrom;
        private Guna.UI2.WinForms.Guna2TextBox txtTo;
        private Guna.UI2.WinForms.Guna2TextBox txtBody;
        private FlowLayoutPanel flowAttachments;
        private Guna.UI2.WinForms.Guna2TextBox txtSubject;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSuject;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBody;
        private Guna.UI2.WinForms.Guna2GradientButton btnAttach;
        private Guna.UI2.WinForms.Guna2GradientButton btnSend;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAttach;
    }
}