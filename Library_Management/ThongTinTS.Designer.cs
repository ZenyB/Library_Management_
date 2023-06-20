namespace Library_Management
{
    partial class ThongTinTS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongTinTS));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtgvChosenBook = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.txb_NgayTra = new System.Windows.Forms.TextBox();
            this.txb_SoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_TenDocGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_MaPMS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_MaDocGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChosenBook)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1244, 5);
            this.panel4.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 50);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.label1.Location = new System.Drawing.Point(440, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN PHIẾU TRẢ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 259);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 494);
            this.panel3.TabIndex = 13;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtgvChosenBook);
            this.panel6.Location = new System.Drawing.Point(12, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1220, 450);
            this.panel6.TabIndex = 10;
            // 
            // dtgvChosenBook
            // 
            this.dtgvChosenBook.AllowUserToAddRows = false;
            this.dtgvChosenBook.AllowUserToDeleteRows = false;
            this.dtgvChosenBook.AllowUserToResizeRows = false;
            this.dtgvChosenBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvChosenBook.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvChosenBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvChosenBook.ColumnHeadersHeight = 50;
            this.dtgvChosenBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChosenBook.Location = new System.Drawing.Point(0, 0);
            this.dtgvChosenBook.MultiSelect = false;
            this.dtgvChosenBook.Name = "dtgvChosenBook";
            this.dtgvChosenBook.ReadOnly = true;
            this.dtgvChosenBook.RowHeadersVisible = false;
            this.dtgvChosenBook.RowHeadersWidth = 51;
            this.dtgvChosenBook.RowTemplate.Height = 24;
            this.dtgvChosenBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvChosenBook.Size = new System.Drawing.Size(1220, 450);
            this.dtgvChosenBook.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(39)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.btn_XacNhan);
            this.panel1.Controls.Add(this.btn_Huy);
            this.panel1.Controls.Add(this.txb_NgayTra);
            this.panel1.Controls.Add(this.txb_SoLuong);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txb_TenDocGia);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txb_MaPMS);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txb_MaDocGia);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 204);
            this.panel1.TabIndex = 12;
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(205)))), ((int)(((byte)(203)))));
            this.btn_XacNhan.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_XacNhan.FlatAppearance.BorderSize = 0;
            this.btn_XacNhan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btn_XacNhan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_XacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XacNhan.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_XacNhan.Location = new System.Drawing.Point(962, 175);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(123, 29);
            this.btn_XacNhan.TabIndex = 66;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = false;
            this.btn_XacNhan.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(80)))), ((int)(((byte)(73)))));
            this.btn_Huy.FlatAppearance.BorderSize = 0;
            this.btn_Huy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btn_Huy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.ForeColor = System.Drawing.Color.White;
            this.btn_Huy.Location = new System.Drawing.Point(1109, 175);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(123, 29);
            this.btn_Huy.TabIndex = 27;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txb_NgayTra
            // 
            this.txb_NgayTra.HideSelection = false;
            this.txb_NgayTra.Location = new System.Drawing.Point(821, 56);
            this.txb_NgayTra.Name = "txb_NgayTra";
            this.txb_NgayTra.ReadOnly = true;
            this.txb_NgayTra.Size = new System.Drawing.Size(235, 22);
            this.txb_NgayTra.TabIndex = 65;
            this.txb_NgayTra.Tag = "";
            // 
            // txb_SoLuong
            // 
            this.txb_SoLuong.HideSelection = false;
            this.txb_SoLuong.Location = new System.Drawing.Point(256, 136);
            this.txb_SoLuong.Name = "txb_SoLuong";
            this.txb_SoLuong.ReadOnly = true;
            this.txb_SoLuong.Size = new System.Drawing.Size(67, 22);
            this.txb_SoLuong.TabIndex = 59;
            this.txb_SoLuong.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(172, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(818, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "Ngày trả:";
            // 
            // txb_TenDocGia
            // 
            this.txb_TenDocGia.HideSelection = false;
            this.txb_TenDocGia.Location = new System.Drawing.Point(499, 136);
            this.txb_TenDocGia.Name = "txb_TenDocGia";
            this.txb_TenDocGia.ReadOnly = true;
            this.txb_TenDocGia.Size = new System.Drawing.Size(235, 22);
            this.txb_TenDocGia.TabIndex = 55;
            this.txb_TenDocGia.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(495, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 57;
            this.label6.Text = "Tên độc giả:";
            // 
            // txb_MaPMS
            // 
            this.txb_MaPMS.HideSelection = false;
            this.txb_MaPMS.Location = new System.Drawing.Point(176, 56);
            this.txb_MaPMS.Name = "txb_MaPMS";
            this.txb_MaPMS.ReadOnly = true;
            this.txb_MaPMS.Size = new System.Drawing.Size(235, 22);
            this.txb_MaPMS.TabIndex = 53;
            this.txb_MaPMS.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(172, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 16);
            this.label7.TabIndex = 54;
            this.label7.Text = "Mã Phiếu trả sách:";
            // 
            // txb_MaDocGia
            // 
            this.txb_MaDocGia.HideSelection = false;
            this.txb_MaDocGia.Location = new System.Drawing.Point(499, 56);
            this.txb_MaDocGia.Name = "txb_MaDocGia";
            this.txb_MaDocGia.ReadOnly = true;
            this.txb_MaDocGia.Size = new System.Drawing.Size(235, 22);
            this.txb_MaDocGia.TabIndex = 42;
            this.txb_MaDocGia.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(495, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Mã độc giả:";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // ThongTinTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1244, 753);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "ThongTinTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Thông tin phiếu mượn";
            this.Load += new System.EventHandler(this.ConfirmLendBook_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChosenBook)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dtgvChosenBook;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txb_SoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_TenDocGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_MaPMS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_MaDocGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_NgayTra;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.Button btn_Huy;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}