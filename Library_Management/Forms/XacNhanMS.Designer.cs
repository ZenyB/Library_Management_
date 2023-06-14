namespace Library_Management.Forms.Dich_Vu
{
    partial class XacNhanMS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_TTPhieuMuon = new System.Windows.Forms.Panel();
            this.lb_TTPhieuMuon = new System.Windows.Forms.Label();
            this.pnl_XNPM = new System.Windows.Forms.Panel();
            this.lb_SoLuong = new System.Windows.Forms.Label();
            this.lb_NgayTra = new System.Windows.Forms.Label();
            this.lb_MaPhieuMuon = new System.Windows.Forms.Label();
            this.lb_HoTen = new System.Windows.Forms.Label();
            this.lb_MaDocGia = new System.Windows.Forms.Label();
            this.lb_NgayMuon = new System.Windows.Forms.Label();
            this.lb_TTChiTiet = new System.Windows.Forms.Label();
            this.pnl_dulieu = new System.Windows.Forms.Panel();
            this.DS_chitietPNS = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_MPM = new System.Windows.Forms.Label();
            this.lb_CTNgayMuon = new System.Windows.Forms.Label();
            this.lb_CTHoTen = new System.Windows.Forms.Label();
            this.lb_MaDG = new System.Windows.Forms.Label();
            this.lb_CTSoLuong = new System.Windows.Forms.Label();
            this.lb_CTNgayTra = new System.Windows.Forms.Label();
            this.pnl_TTPhieuMuon.SuspendLayout();
            this.pnl_XNPM.SuspendLayout();
            this.pnl_dulieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_chitietPNS)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_TTPhieuMuon
            // 
            this.pnl_TTPhieuMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.pnl_TTPhieuMuon.Controls.Add(this.lb_TTPhieuMuon);
            this.pnl_TTPhieuMuon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TTPhieuMuon.Location = new System.Drawing.Point(0, 0);
            this.pnl_TTPhieuMuon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_TTPhieuMuon.Name = "pnl_TTPhieuMuon";
            this.pnl_TTPhieuMuon.Size = new System.Drawing.Size(1400, 62);
            this.pnl_TTPhieuMuon.TabIndex = 9;
            // 
            // lb_TTPhieuMuon
            // 
            this.lb_TTPhieuMuon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_TTPhieuMuon.AutoSize = true;
            this.lb_TTPhieuMuon.Font = new System.Drawing.Font("UTM Avo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TTPhieuMuon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_TTPhieuMuon.Location = new System.Drawing.Point(518, 0);
            this.lb_TTPhieuMuon.Name = "lb_TTPhieuMuon";
            this.lb_TTPhieuMuon.Size = new System.Drawing.Size(429, 49);
            this.lb_TTPhieuMuon.TabIndex = 0;
            this.lb_TTPhieuMuon.Text = "THÔNG TIN PHIẾU MƯỢN";
            // 
            // pnl_XNPM
            // 
            this.pnl_XNPM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.pnl_XNPM.Controls.Add(this.lb_CTNgayTra);
            this.pnl_XNPM.Controls.Add(this.lb_CTSoLuong);
            this.pnl_XNPM.Controls.Add(this.lb_MaDG);
            this.pnl_XNPM.Controls.Add(this.lb_CTHoTen);
            this.pnl_XNPM.Controls.Add(this.lb_CTNgayMuon);
            this.pnl_XNPM.Controls.Add(this.lb_MPM);
            this.pnl_XNPM.Controls.Add(this.lb_SoLuong);
            this.pnl_XNPM.Controls.Add(this.lb_NgayTra);
            this.pnl_XNPM.Controls.Add(this.lb_MaPhieuMuon);
            this.pnl_XNPM.Controls.Add(this.lb_HoTen);
            this.pnl_XNPM.Controls.Add(this.lb_MaDocGia);
            this.pnl_XNPM.Controls.Add(this.lb_NgayMuon);
            this.pnl_XNPM.Controls.Add(this.lb_TTChiTiet);
            this.pnl_XNPM.Location = new System.Drawing.Point(0, 68);
            this.pnl_XNPM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_XNPM.Name = "pnl_XNPM";
            this.pnl_XNPM.Size = new System.Drawing.Size(1425, 269);
            this.pnl_XNPM.TabIndex = 10;
            // 
            // lb_SoLuong
            // 
            this.lb_SoLuong.AutoSize = true;
            this.lb_SoLuong.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SoLuong.ForeColor = System.Drawing.Color.White;
            this.lb_SoLuong.Location = new System.Drawing.Point(833, 171);
            this.lb_SoLuong.Name = "lb_SoLuong";
            this.lb_SoLuong.Size = new System.Drawing.Size(87, 23);
            this.lb_SoLuong.TabIndex = 15;
            this.lb_SoLuong.Text = "Số lượng:";
            // 
            // lb_NgayTra
            // 
            this.lb_NgayTra.AutoSize = true;
            this.lb_NgayTra.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgayTra.ForeColor = System.Drawing.Color.White;
            this.lb_NgayTra.Location = new System.Drawing.Point(834, 120);
            this.lb_NgayTra.Name = "lb_NgayTra";
            this.lb_NgayTra.Size = new System.Drawing.Size(86, 23);
            this.lb_NgayTra.TabIndex = 14;
            this.lb_NgayTra.Text = "Ngày trả:";
            // 
            // lb_MaPhieuMuon
            // 
            this.lb_MaPhieuMuon.AutoSize = true;
            this.lb_MaPhieuMuon.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaPhieuMuon.ForeColor = System.Drawing.Color.White;
            this.lb_MaPhieuMuon.Location = new System.Drawing.Point(217, 65);
            this.lb_MaPhieuMuon.Name = "lb_MaPhieuMuon";
            this.lb_MaPhieuMuon.Size = new System.Drawing.Size(144, 23);
            this.lb_MaPhieuMuon.TabIndex = 7;
            this.lb_MaPhieuMuon.Text = "Mã phiếu mượn:";
            // 
            // lb_HoTen
            // 
            this.lb_HoTen.AutoSize = true;
            this.lb_HoTen.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_HoTen.ForeColor = System.Drawing.Color.White;
            this.lb_HoTen.Location = new System.Drawing.Point(217, 119);
            this.lb_HoTen.Name = "lb_HoTen";
            this.lb_HoTen.Size = new System.Drawing.Size(138, 23);
            this.lb_HoTen.TabIndex = 6;
            this.lb_HoTen.Text = "Họ tên độc giả:";
            // 
            // lb_MaDocGia
            // 
            this.lb_MaDocGia.AutoSize = true;
            this.lb_MaDocGia.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaDocGia.ForeColor = System.Drawing.Color.White;
            this.lb_MaDocGia.Location = new System.Drawing.Point(217, 171);
            this.lb_MaDocGia.Name = "lb_MaDocGia";
            this.lb_MaDocGia.Size = new System.Drawing.Size(110, 23);
            this.lb_MaDocGia.TabIndex = 5;
            this.lb_MaDocGia.Text = "Mã độc giả:";
            // 
            // lb_NgayMuon
            // 
            this.lb_NgayMuon.AutoSize = true;
            this.lb_NgayMuon.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgayMuon.ForeColor = System.Drawing.Color.White;
            this.lb_NgayMuon.Location = new System.Drawing.Point(833, 65);
            this.lb_NgayMuon.Name = "lb_NgayMuon";
            this.lb_NgayMuon.Size = new System.Drawing.Size(110, 23);
            this.lb_NgayMuon.TabIndex = 4;
            this.lb_NgayMuon.Text = "Ngày mượn:";
            // 
            // lb_TTChiTiet
            // 
            this.lb_TTChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_TTChiTiet.AutoSize = true;
            this.lb_TTChiTiet.Font = new System.Drawing.Font("UTM Avo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TTChiTiet.ForeColor = System.Drawing.Color.White;
            this.lb_TTChiTiet.Location = new System.Drawing.Point(21, 11);
            this.lb_TTChiTiet.Name = "lb_TTChiTiet";
            this.lb_TTChiTiet.Size = new System.Drawing.Size(218, 35);
            this.lb_TTChiTiet.TabIndex = 1;
            this.lb_TTChiTiet.Text = "Thông tin chi tiết";
            // 
            // pnl_dulieu
            // 
            this.pnl_dulieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.pnl_dulieu.Controls.Add(this.DS_chitietPNS);
            this.pnl_dulieu.Location = new System.Drawing.Point(0, 341);
            this.pnl_dulieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_dulieu.Name = "pnl_dulieu";
            this.pnl_dulieu.Size = new System.Drawing.Size(1426, 602);
            this.pnl_dulieu.TabIndex = 11;
            // 
            // DS_chitietPNS
            // 
            this.DS_chitietPNS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DS_chitietPNS.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DS_chitietPNS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DS_chitietPNS.ColumnHeadersHeight = 50;
            this.DS_chitietPNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.MaSach,
            this.TenSach,
            this.TheLoai,
            this.TacGia});
            this.DS_chitietPNS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DS_chitietPNS.Location = new System.Drawing.Point(0, 0);
            this.DS_chitietPNS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DS_chitietPNS.Name = "DS_chitietPNS";
            this.DS_chitietPNS.RowHeadersVisible = false;
            this.DS_chitietPNS.RowHeadersWidth = 51;
            this.DS_chitietPNS.RowTemplate.Height = 24;
            this.DS_chitietPNS.Size = new System.Drawing.Size(1426, 602);
            this.DS_chitietPNS.TabIndex = 14;
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            // 
            // MaSach
            // 
            this.MaSach.HeaderText = "Mã sách";
            this.MaSach.MinimumWidth = 6;
            this.MaSach.Name = "MaSach";
            // 
            // TenSach
            // 
            this.TenSach.HeaderText = "Tên sách";
            this.TenSach.MinimumWidth = 6;
            this.TenSach.Name = "TenSach";
            // 
            // TheLoai
            // 
            this.TheLoai.HeaderText = "Thể loại";
            this.TheLoai.MinimumWidth = 6;
            this.TheLoai.Name = "TheLoai";
            // 
            // TacGia
            // 
            this.TacGia.HeaderText = "Tác Giả";
            this.TacGia.MinimumWidth = 6;
            this.TacGia.Name = "TacGia";
            // 
            // lb_MPM
            // 
            this.lb_MPM.AutoSize = true;
            this.lb_MPM.Font = new System.Drawing.Font("UTM Avo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_MPM.Location = new System.Drawing.Point(367, 61);
            this.lb_MPM.Name = "lb_MPM";
            this.lb_MPM.Size = new System.Drawing.Size(75, 27);
            this.lb_MPM.TabIndex = 27;
            this.lb_MPM.Text = "PM001";
            // 
            // lb_CTNgayMuon
            // 
            this.lb_CTNgayMuon.AutoSize = true;
            this.lb_CTNgayMuon.Font = new System.Drawing.Font("UTM Avo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CTNgayMuon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_CTNgayMuon.Location = new System.Drawing.Point(963, 61);
            this.lb_CTNgayMuon.Name = "lb_CTNgayMuon";
            this.lb_CTNgayMuon.Size = new System.Drawing.Size(118, 27);
            this.lb_CTNgayMuon.TabIndex = 28;
            this.lb_CTNgayMuon.Text = "10/06/2023";
            // 
            // lb_CTHoTen
            // 
            this.lb_CTHoTen.AutoSize = true;
            this.lb_CTHoTen.Font = new System.Drawing.Font("UTM Avo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CTHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_CTHoTen.Location = new System.Drawing.Point(367, 115);
            this.lb_CTHoTen.Name = "lb_CTHoTen";
            this.lb_CTHoTen.Size = new System.Drawing.Size(155, 27);
            this.lb_CTHoTen.TabIndex = 29;
            this.lb_CTHoTen.Text = "Nguyễn Văn A";
            // 
            // lb_MaDG
            // 
            this.lb_MaDG.AutoSize = true;
            this.lb_MaDG.Font = new System.Drawing.Font("UTM Avo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaDG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_MaDG.Location = new System.Drawing.Point(367, 167);
            this.lb_MaDG.Name = "lb_MaDG";
            this.lb_MaDG.Size = new System.Drawing.Size(77, 27);
            this.lb_MaDG.TabIndex = 30;
            this.lb_MaDG.Text = "DG020";
            // 
            // lb_CTSoLuong
            // 
            this.lb_CTSoLuong.AutoSize = true;
            this.lb_CTSoLuong.Font = new System.Drawing.Font("UTM Avo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CTSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_CTSoLuong.Location = new System.Drawing.Point(963, 167);
            this.lb_CTSoLuong.Name = "lb_CTSoLuong";
            this.lb_CTSoLuong.Size = new System.Drawing.Size(23, 27);
            this.lb_CTSoLuong.TabIndex = 31;
            this.lb_CTSoLuong.Text = "3";
            // 
            // lb_CTNgayTra
            // 
            this.lb_CTNgayTra.AutoSize = true;
            this.lb_CTNgayTra.Font = new System.Drawing.Font("UTM Avo", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CTNgayTra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_CTNgayTra.Location = new System.Drawing.Point(963, 116);
            this.lb_CTNgayTra.Name = "lb_CTNgayTra";
            this.lb_CTNgayTra.Size = new System.Drawing.Size(118, 27);
            this.lb_CTNgayTra.TabIndex = 32;
            this.lb_CTNgayTra.Text = "13/06/2023";
            // 
            // XacNhanMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1400, 941);
            this.Controls.Add(this.pnl_dulieu);
            this.Controls.Add(this.pnl_XNPM);
            this.Controls.Add(this.pnl_TTPhieuMuon);
            this.Name = "XacNhanMS";
            this.Text = "Xác nhận mượn sách";
            this.pnl_TTPhieuMuon.ResumeLayout(false);
            this.pnl_TTPhieuMuon.PerformLayout();
            this.pnl_XNPM.ResumeLayout(false);
            this.pnl_XNPM.PerformLayout();
            this.pnl_dulieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_chitietPNS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_TTPhieuMuon;
        private System.Windows.Forms.Label lb_TTPhieuMuon;
        private System.Windows.Forms.Panel pnl_XNPM;
        private System.Windows.Forms.Label lb_SoLuong;
        private System.Windows.Forms.Label lb_NgayTra;
        private System.Windows.Forms.Label lb_MaPhieuMuon;
        private System.Windows.Forms.Label lb_HoTen;
        private System.Windows.Forms.Label lb_MaDocGia;
        private System.Windows.Forms.Label lb_NgayMuon;
        private System.Windows.Forms.Label lb_TTChiTiet;
        private System.Windows.Forms.Panel pnl_dulieu;
        private System.Windows.Forms.Label lb_CTNgayTra;
        private System.Windows.Forms.Label lb_CTSoLuong;
        private System.Windows.Forms.Label lb_MaDG;
        private System.Windows.Forms.Label lb_CTHoTen;
        private System.Windows.Forms.Label lb_CTNgayMuon;
        private System.Windows.Forms.Label lb_MPM;
        private System.Windows.Forms.DataGridView DS_chitietPNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TacGia;
    }
}