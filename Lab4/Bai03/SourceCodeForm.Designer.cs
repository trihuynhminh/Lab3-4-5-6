namespace Bai03
{
    partial class SourceCodeForm
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
            this.txtSourceCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourceCode.Location = new System.Drawing.Point(0, 0);
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.Size = new System.Drawing.Size(800, 450);
            this.txtSourceCode.TabIndex = 0;
            this.txtSourceCode.Text = "";

            // 
            // SourceCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSourceCode);
            this.Name = "SourceCodeForm";
            this.Text = "SourceCodeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSourceCode;
    }
}