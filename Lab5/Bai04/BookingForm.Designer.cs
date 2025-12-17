// Trong file BookingForm.Designer.cs

namespace Bai04
{
    partial class BookingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMovieTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;

        // --- CÁC KHAI BÁO CŨ ĐÃ BỎ numTickets ---
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbShowtime;
        // ----------------------------------------

        // --- KHAI BÁO MỚI CHO BÀI 4 ---
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.FlowLayoutPanel flpSeats;
        private System.Windows.Forms.Label lblSelectedSeats;
        // ----------------------------------------


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
            this.lblMovieTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            // BỎ numTickets
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            // KHỞI TẠO CONTROLS CŨ
            this.label3 = new System.Windows.Forms.Label();
            this.cbShowtime = new System.Windows.Forms.ComboBox();
            // KHỞI TẠO CONTROLS MỚI
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.flpSeats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSelectedSeats = new System.Windows.Forms.Label();
            // HẾT KHỞI TẠO CONTROLS MỚI

            this.SuspendLayout();
            // 
            // lblMovieTitle
            // 
            this.lblMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblMovieTitle.Location = new System.Drawing.Point(12, 9);
            this.lblMovieTitle.Name = "lblMovieTitle";
            this.lblMovieTitle.Size = new System.Drawing.Size(564, 34); // Tăng kích thước
            this.lblMovieTitle.TabIndex = 0;
            this.lblMovieTitle.Text = "ĐẶT VÉ: [TÊN PHIM]";
            this.lblMovieTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(165, 57);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(411, 26);
            this.txtCustomerName.TabIndex = 2;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 105);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(52, 20);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email:";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Location = new System.Drawing.Point(165, 102);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(411, 26);
            this.txtCustomerEmail.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chọn Suất Chiếu:";
            // 
            // cbShowtime
            // 
            this.cbShowtime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShowtime.FormattingEnabled = true;
            this.cbShowtime.Location = new System.Drawing.Point(165, 145);
            this.cbShowtime.Name = "cbShowtime";
            this.cbShowtime.Size = new System.Drawing.Size(411, 28);
            this.cbShowtime.TabIndex = 6;
            // 
            // flpSeats
            // 
            this.flpSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSeats.Location = new System.Drawing.Point(16, 230);
            this.flpSeats.Name = "flpSeats";
            this.flpSeats.Size = new System.Drawing.Size(559, 230);
            this.flpSeats.TabIndex = 7;
            // 
            // lblSelectedSeats
            // 
            this.lblSelectedSeats.AutoSize = true;
            this.lblSelectedSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedSeats.ForeColor = System.Drawing.Color.Blue;
            this.lblSelectedSeats.Location = new System.Drawing.Point(13, 470);
            this.lblSelectedSeats.Name = "lblSelectedSeats";
            this.lblSelectedSeats.Size = new System.Drawing.Size(123, 20);
            this.lblSelectedSeats.TabIndex = 8;
            this.lblSelectedSeats.Text = "Ghế đã chọn: 0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalAmount.Location = new System.Drawing.Point(16, 188); // Vị trí mới
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(559, 25);
            this.lblTotalAmount.TabIndex = 9;
            this.lblTotalAmount.Text = "TỔNG THANH TOÁN: 0 VNĐ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.Green;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(198, 500); // Vị trí mới
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(193, 44);
            this.btnBook.TabIndex = 10;
            this.btnBook.Text = "XÁC NHẬN ĐẶT VÉ";
            this.btnBook.UseVisualStyleBackColor = false;
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 556); // Điều chỉnh kích thước Form lớn hơn
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblSelectedSeats);
            this.Controls.Add(this.flpSeats);
            this.Controls.Add(this.cbShowtime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMovieTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt vé";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // CÁC KHAI BÁO BIẾN Ở CUỐI FILE ĐÃ CÓ Ở ĐẦU FILE, KHÔNG CẦN LẶP LẠI
    }
}