namespace Bai7Riel
{
    partial class FormDetail
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtAddress = new TextBox();
            txtDesc = new TextBox();
            txtImage = new TextBox();
            pbImage = new PictureBox();
            btnSave = new Button();
            btnDelete = new Button();
            lbl1 = new Label();
            lbl2 = new Label();
            lbl3 = new Label();
            lbl4 = new Label();
            lbl5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(176, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 43);
            txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 10F);
            txtPrice.Location = new Point(176, 95);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(300, 43);
            txtPrice.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(176, 160);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(300, 43);
            txtAddress.TabIndex = 5;
            // 
            // txtDesc
            // 
            txtDesc.Font = new Font("Segoe UI", 10F);
            txtDesc.Location = new Point(176, 298);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Vertical;
            txtDesc.Size = new Size(300, 100);
            txtDesc.TabIndex = 9;
            // 
            // txtImage
            // 
            txtImage.Font = new Font("Segoe UI", 10F);
            txtImage.Location = new Point(176, 229);
            txtImage.Name = "txtImage";
            txtImage.Size = new Size(300, 43);
            txtImage.TabIndex = 7;
            // 
            // pbImage
            // 
            pbImage.BackColor = Color.WhiteSmoke;
            pbImage.BorderStyle = BorderStyle.FixedSingle;
            pbImage.Location = new Point(550, 30);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(260, 260);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 10;
            pbImage.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.MediumSeaGreen;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(176, 418);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 45);
            btnSave.TabIndex = 11;
            btnSave.Text = "LƯU MÓN";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(356, 418);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 45);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "XÓA MÓN";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI", 10F);
            lbl1.Location = new Point(30, 33);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(124, 37);
            lbl1.TabIndex = 0;
            lbl1.Text = "Tên món:";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI", 10F);
            lbl2.Location = new Point(30, 98);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(142, 37);
            lbl2.TabIndex = 2;
            lbl2.Text = "Giá (VNĐ):";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Segoe UI", 10F);
            lbl3.Location = new Point(30, 163);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(104, 37);
            lbl3.TabIndex = 4;
            lbl3.Text = "Địa chỉ:";
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Font = new Font("Segoe UI", 10F);
            lbl4.Location = new Point(30, 232);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(125, 37);
            lbl4.TabIndex = 6;
            lbl4.Text = "Link Ảnh:";
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Font = new Font("Segoe UI", 10F);
            lbl5.Location = new Point(30, 301);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(93, 37);
            lbl5.TabIndex = 8;
            lbl5.Text = "Mô tả:";
            // 
            // FormDetail
            // 
            ClientSize = new Size(904, 536);
            Controls.Add(lbl1);
            Controls.Add(txtName);
            Controls.Add(lbl2);
            Controls.Add(txtPrice);
            Controls.Add(lbl3);
            Controls.Add(txtAddress);
            Controls.Add(lbl4);
            Controls.Add(txtImage);
            Controls.Add(lbl5);
            Controls.Add(txtDesc);
            Controls.Add(pbImage);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Name = "FormDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết món ăn";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.TextBox txtName, txtPrice, txtAddress, txtDesc, txtImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnSave, btnDelete;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5;
    }
}