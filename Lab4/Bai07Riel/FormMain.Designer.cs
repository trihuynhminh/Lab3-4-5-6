namespace Bai7Riel
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            dgvDishes = new DataGridView();
            cbMode = new ComboBox();
            btnAdd = new Button();
            btnRandom = new Button();
            numPage = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDishes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPage).BeginInit();
            SuspendLayout();
            // 
            // dgvDishes
            // 
            dgvDishes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDishes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDishes.BackgroundColor = Color.WhiteSmoke;
            dgvDishes.ColumnHeadersHeight = 46;
            dgvDishes.Location = new Point(25, 221);
            dgvDishes.Name = "dgvDishes";
            dgvDishes.ReadOnly = true;
            dgvDishes.RowHeadersWidth = 82;
            dgvDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDishes.Size = new Size(1221, 492);
            dgvDishes.TabIndex = 7;
            // 
            // cbMode
            // 
            cbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMode.Font = new Font("Segoe UI", 10F);
            cbMode.Items.AddRange(new object[] { "Tất cả (Cộng đồng)", "Món của tôi" });
            cbMode.Location = new Point(25, 145);
            cbMode.Name = "cbMode";
            cbMode.Size = new Size(200, 45);
            cbMode.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(1116, 135);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(133, 63);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "+ THÊM MÓN";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRandom
            // 
            btnRandom.BackColor = Color.Orange;
            btnRandom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRandom.ForeColor = Color.White;
            btnRandom.Location = new Point(500, 135);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(590, 63);
            btnRandom.TabIndex = 6;
            btnRandom.Text = "🎲 HÔM NAY ĂN GÌ?";
            btnRandom.UseVisualStyleBackColor = false;
            btnRandom.Click += btnRandom_Click;
            // 
            // numPage
            // 
            numPage.Font = new Font("Segoe UI", 10F);
            numPage.Location = new Point(344, 146);
            numPage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPage.Name = "numPage";
            numPage.Size = new Size(103, 43);
            numPage.TabIndex = 4;
            numPage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(249, 148);
            label1.Name = "label1";
            label1.Size = new Size(89, 37);
            label1.TabIndex = 1;
            label1.Text = "Trang:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(25, 716);
            label2.Name = "label2";
            label2.Size = new Size(757, 32);
            label2.TabIndex = 2;
            label2.Text = "* Gợi ý: Click đúp chuột vào dòng bất kỳ để Xem chi tiết hoặc Xóa món.";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(475, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DANH SÁCH MÓN ĂN";
            // 
            // FormMain
            // 
            ClientSize = new Size(1275, 756);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(cbMode);
            Controls.Add(numPage);
            Controls.Add(btnAdd);
            Controls.Add(btnRandom);
            Controls.Add(dgvDishes);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hôm nay ăn gì? (Version Xịn)";
            ((System.ComponentModel.ISupportInitialize)dgvDishes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.DataGridView dgvDishes;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Button btnAdd, btnRandom;
        private System.Windows.Forms.NumericUpDown numPage;
        private System.Windows.Forms.Label label1, label2, lblTitle;
    }
}