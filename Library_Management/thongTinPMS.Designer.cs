namespace Library_Management
{
    partial class thongTinPMS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DS_chitietPNS = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_MaDocGia = new System.Windows.Forms.TextBox();
            this.txb_MaPMS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_SoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_TenDocGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.dateTimeNgayTra = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_chitietPNS)).BeginInit();
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
            this.label1.Font = new System.Drawing.Font("UTM Avo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.label1.Location = new System.Drawing.Point(440, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN PHIẾU MƯỢN";
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
            this.panel6.Controls.Add(this.DS_chitietPNS);
            this.panel6.Location = new System.Drawing.Point(12, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1220, 450);
            this.panel6.TabIndex = 10;
            // 
            // DS_chitietPNS
            // 
            this.DS_chitietPNS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DS_chitietPNS.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DS_chitietPNS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DS_chitietPNS.ColumnHeadersHeight = 50;
            this.DS_chitietPNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.maSach,
            this.tenSach,
            this.theLoai,
            this.tacGia});
            this.DS_chitietPNS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DS_chitietPNS.Location = new System.Drawing.Point(0, 0);
            this.DS_chitietPNS.Name = "DS_chitietPNS";
            this.DS_chitietPNS.RowHeadersVisible = false;
            this.DS_chitietPNS.RowHeadersWidth = 51;
            this.DS_chitietPNS.RowTemplate.Height = 24;
            this.DS_chitietPNS.Size = new System.Drawing.Size(1220, 450);
            this.DS_chitietPNS.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(39)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.dateTimeNgayTra);
            this.panel1.Controls.Add(this.dateTimeNgayMuon);
            this.panel1.Controls.Add(this.txb_SoLuong);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txb_TenDocGia);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txb_MaPMS);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txb_MaDocGia);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 204);
            this.panel1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(818, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 45;
            this.label5.Text = "Ngày mượn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(495, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 44;
            this.label4.Text = "Mã độc giả:";
            // 
            // txb_MaDocGia
            // 
            this.txb_MaDocGia.HideSelection = false;
            this.txb_MaDocGia.Location = new System.Drawing.Point(499, 56);
            this.txb_MaDocGia.Name = "txb_MaDocGia";
            this.txb_MaDocGia.Size = new System.Drawing.Size(235, 22);
            this.txb_MaDocGia.TabIndex = 42;
            this.txb_MaDocGia.Tag = "";
            // 
            // txb_MaPMS
            // 
            this.txb_MaPMS.HideSelection = false;
            this.txb_MaPMS.Location = new System.Drawing.Point(176, 56);
            this.txb_MaPMS.Name = "txb_MaPMS";
            this.txb_MaPMS.Size = new System.Drawing.Size(235, 22);
            this.txb_MaPMS.TabIndex = 53;
            this.txb_MaPMS.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(172, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 19);
            this.label7.TabIndex = 54;
            this.label7.Text = "Mã Phiếu mượn sách:";
            // 
            // txb_SoLuong
            // 
            this.txb_SoLuong.HideSelection = false;
            this.txb_SoLuong.Location = new System.Drawing.Point(256, 136);
            this.txb_SoLuong.Name = "txb_SoLuong";
            this.txb_SoLuong.Size = new System.Drawing.Size(67, 22);
            this.txb_SoLuong.TabIndex = 59;
            this.txb_SoLuong.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(172, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 60;
            this.label2.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(818, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 58;
            this.label3.Text = "Ngày trả:";
            // 
            // txb_TenDocGia
            // 
            this.txb_TenDocGia.HideSelection = false;
            this.txb_TenDocGia.Location = new System.Drawing.Point(499, 136);
            this.txb_TenDocGia.Name = "txb_TenDocGia";
            this.txb_TenDocGia.Size = new System.Drawing.Size(235, 22);
            this.txb_TenDocGia.TabIndex = 55;
            this.txb_TenDocGia.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(495, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 57;
            this.label6.Text = "Tên độc giả:";
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            // 
            // maSach
            // 
            this.maSach.HeaderText = "Mã sách";
            this.maSach.MinimumWidth = 6;
            this.maSach.Name = "maSach";
            // 
            // tenSach
            // 
            this.tenSach.HeaderText = "Tên sách";
            this.tenSach.MinimumWidth = 6;
            this.tenSach.Name = "tenSach";
            // 
            // theLoai
            // 
            this.theLoai.HeaderText = "Thể loại";
            this.theLoai.MinimumWidth = 6;
            this.theLoai.Name = "theLoai";
            // 
            // tacGia
            // 
            this.tacGia.HeaderText = "Tác giả";
            this.tacGia.MinimumWidth = 6;
            this.tacGia.Name = "tacGia";
            // 
            // dateTimeNgayMuon
            // 
            this.dateTimeNgayMuon.Location = new System.Drawing.Point(822, 56);
            this.dateTimeNgayMuon.Name = "dateTimeNgayMuon";
            this.dateTimeNgayMuon.Size = new System.Drawing.Size(235, 22);
            this.dateTimeNgayMuon.TabIndex = 62;
            // 
            // dateTimeNgayTra
            // 
            this.dateTimeNgayTra.Location = new System.Drawing.Point(822, 136);
            this.dateTimeNgayTra.Name = "dateTimeNgayTra";
            this.dateTimeNgayTra.Size = new System.Drawing.Size(235, 22);
            this.dateTimeNgayTra.TabIndex = 63;
            // 
            // thongTinPMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1244, 753);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "thongTinPMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Thông tin phiếu mượn";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_chitietPNS)).EndInit();
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
        private System.Windows.Forms.DataGridView DS_chitietPNS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txb_SoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_TenDocGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_MaPMS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_MaDocGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn theLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn tacGia;
        private System.Windows.Forms.DateTimePicker dateTimeNgayTra;
        private System.Windows.Forms.DateTimePicker dateTimeNgayMuon;
    }
}