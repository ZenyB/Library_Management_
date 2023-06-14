namespace Library_Management
{
    partial class dauSach
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
            this.label1 = new System.Windows.Forms.Label();
            this.tongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.maPNS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.thongTinPN = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listBox_TacGia = new System.Windows.Forms.ListBox();
            this.txb_TenDauSach = new System.Windows.Forms.TextBox();
            this.txb_MaDauSach = new System.Windows.Forms.TextBox();
            this.cb_MaTheLoai = new System.Windows.Forms.ComboBox();
            this.cb_TenTacGia = new System.Windows.Forms.ComboBox();
            this.cb_TenTheLoai = new System.Windows.Forms.ComboBox();
            this.btn_AddTacGia = new FontAwesome.Sharp.IconPictureBox();
            this.btn_RemoveTacGia = new FontAwesome.Sharp.IconPictureBox();
            this.btnThemTG = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.DS_DauSach = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnXemVaCapNhat = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_AddTacGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_RemoveTacGia)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_DauSach)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1244, 5);
            this.panel4.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.label1.Location = new System.Drawing.Point(450, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN ĐẦU SÁCH";
            // 
            // tongTien
            // 
            this.tongTien.HeaderText = "Tổng tiền";
            this.tongTien.MinimumWidth = 6;
            this.tongTien.Name = "tongTien";
            this.tongTien.Width = 125;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 50);
            this.panel2.TabIndex = 7;
            // 
            // maPNS
            // 
            this.maPNS.HeaderText = "Mã phiếu nhập sách";
            this.maPNS.MinimumWidth = 6;
            this.maPNS.Name = "maPNS";
            this.maPNS.Width = 125;
            // 
            // ngayNhap
            // 
            this.ngayNhap.HeaderText = "Ngày nhập";
            this.ngayNhap.MinimumWidth = 6;
            this.ngayNhap.Name = "ngayNhap";
            this.ngayNhap.Width = 125;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.thongTinPN);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(380, 57);
            this.panel5.TabIndex = 0;
            // 
            // thongTinPN
            // 
            this.thongTinPN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.thongTinPN.AutoSize = true;
            this.thongTinPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongTinPN.ForeColor = System.Drawing.Color.White;
            this.thongTinPN.Location = new System.Drawing.Point(98, 13);
            this.thongTinPN.Name = "thongTinPN";
            this.thongTinPN.Size = new System.Drawing.Size(172, 25);
            this.thongTinPN.TabIndex = 0;
            this.thongTinPN.Text = "Thông tin chi tiết";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listBox_TacGia);
            this.panel3.Controls.Add(this.txb_TenDauSach);
            this.panel3.Controls.Add(this.txb_MaDauSach);
            this.panel3.Controls.Add(this.cb_MaTheLoai);
            this.panel3.Controls.Add(this.cb_TenTacGia);
            this.panel3.Controls.Add(this.cb_TenTheLoai);
            this.panel3.Controls.Add(this.btn_AddTacGia);
            this.panel3.Controls.Add(this.btn_RemoveTacGia);
            this.panel3.Controls.Add(this.btnThemTG);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnLuu);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.btnTaoMoi);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 702);
            this.panel3.TabIndex = 9;
            // 
            // listBox_TacGia
            // 
            this.listBox_TacGia.FormattingEnabled = true;
            this.listBox_TacGia.ItemHeight = 16;
            this.listBox_TacGia.Location = new System.Drawing.Point(30, 382);
            this.listBox_TacGia.Name = "listBox_TacGia";
            this.listBox_TacGia.Size = new System.Drawing.Size(297, 84);
            this.listBox_TacGia.TabIndex = 38;
            // 
            // txb_TenDauSach
            // 
            this.txb_TenDauSach.Location = new System.Drawing.Point(30, 184);
            this.txb_TenDauSach.Name = "txb_TenDauSach";
            this.txb_TenDauSach.Size = new System.Drawing.Size(324, 22);
            this.txb_TenDauSach.TabIndex = 37;
            // 
            // txb_MaDauSach
            // 
            this.txb_MaDauSach.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txb_MaDauSach.Enabled = false;
            this.txb_MaDauSach.Location = new System.Drawing.Point(30, 122);
            this.txb_MaDauSach.Name = "txb_MaDauSach";
            this.txb_MaDauSach.Size = new System.Drawing.Size(324, 22);
            this.txb_MaDauSach.TabIndex = 36;
            // 
            // cb_MaTheLoai
            // 
            this.cb_MaTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MaTheLoai.Enabled = false;
            this.cb_MaTheLoai.FormattingEnabled = true;
            this.cb_MaTheLoai.Location = new System.Drawing.Point(30, 246);
            this.cb_MaTheLoai.Name = "cb_MaTheLoai";
            this.cb_MaTheLoai.Size = new System.Drawing.Size(324, 24);
            this.cb_MaTheLoai.TabIndex = 35;
            // 
            // cb_TenTacGia
            // 
            this.cb_TenTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TenTacGia.FormattingEnabled = true;
            this.cb_TenTacGia.Location = new System.Drawing.Point(30, 507);
            this.cb_TenTacGia.Name = "cb_TenTacGia";
            this.cb_TenTacGia.Size = new System.Drawing.Size(324, 24);
            this.cb_TenTacGia.TabIndex = 33;
            // 
            // cb_TenTheLoai
            // 
            this.cb_TenTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TenTheLoai.FormattingEnabled = true;
            this.cb_TenTheLoai.Location = new System.Drawing.Point(30, 308);
            this.cb_TenTheLoai.Name = "cb_TenTheLoai";
            this.cb_TenTheLoai.Size = new System.Drawing.Size(324, 24);
            this.cb_TenTheLoai.TabIndex = 32;
            this.cb_TenTheLoai.SelectedIndexChanged += new System.EventHandler(this.cb_TenTheLoai_SelectedIndexChanged);
            // 
            // btn_AddTacGia
            // 
            this.btn_AddTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btn_AddTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btn_AddTacGia.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btn_AddTacGia.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btn_AddTacGia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_AddTacGia.IconSize = 21;
            this.btn_AddTacGia.Location = new System.Drawing.Point(333, 382);
            this.btn_AddTacGia.Name = "btn_AddTacGia";
            this.btn_AddTacGia.Size = new System.Drawing.Size(21, 35);
            this.btn_AddTacGia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_AddTacGia.TabIndex = 30;
            this.btn_AddTacGia.TabStop = false;
            this.btn_AddTacGia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_AddTacGia_MouseDown);
            // 
            // btn_RemoveTacGia
            // 
            this.btn_RemoveTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RemoveTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btn_RemoveTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btn_RemoveTacGia.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.btn_RemoveTacGia.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btn_RemoveTacGia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_RemoveTacGia.IconSize = 21;
            this.btn_RemoveTacGia.Location = new System.Drawing.Point(333, 431);
            this.btn_RemoveTacGia.Name = "btn_RemoveTacGia";
            this.btn_RemoveTacGia.Size = new System.Drawing.Size(21, 35);
            this.btn_RemoveTacGia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_RemoveTacGia.TabIndex = 29;
            this.btn_RemoveTacGia.TabStop = false;
            this.btn_RemoveTacGia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_RemoveTacGia_MouseDown);
            // 
            // btnThemTG
            // 
            this.btnThemTG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnThemTG.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThemTG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTG.ForeColor = System.Drawing.Color.White;
            this.btnThemTG.Location = new System.Drawing.Point(218, 535);
            this.btnThemTG.Name = "btnThemTG";
            this.btnThemTG.Size = new System.Drawing.Size(136, 29);
            this.btnThemTG.TabIndex = 23;
            this.btnThemTG.Text = "Thêm tác giả";
            this.btnThemTG.UseVisualStyleBackColor = false;
            this.btnThemTG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnThemTG_MouseDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(26, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Tên tác giả:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(26, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tên thể loại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mã thể loại:";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(205)))), ((int)(((byte)(203)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(30, 621);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(324, 29);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu thông tin";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLuu_MouseDown);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(80)))), ((int)(((byte)(73)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(222, 656);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(132, 29);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXoa_MouseDown);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnTaoMoi.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTaoMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoMoi.Location = new System.Drawing.Point(30, 656);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(186, 29);
            this.btnTaoMoi.TabIndex = 12;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = false;
            this.btnTaoMoi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTaoMoi_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(26, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tên Đầu sách:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Danh sách tác giả:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Đầu sách:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(858, 57);
            this.panel7.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(263, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh sách Đầu sách trong thư viện";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(386, 56);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(858, 702);
            this.panel6.TabIndex = 10;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Controls.Add(this.DS_DauSach);
            this.panel10.Location = new System.Drawing.Point(14, 109);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(830, 576);
            this.panel10.TabIndex = 11;
            // 
            // DS_DauSach
            // 
            this.DS_DauSach.AllowUserToAddRows = false;
            this.DS_DauSach.AllowUserToDeleteRows = false;
            this.DS_DauSach.AllowUserToResizeRows = false;
            this.DS_DauSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DS_DauSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DS_DauSach.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DS_DauSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DS_DauSach.ColumnHeadersHeight = 50;
            this.DS_DauSach.EnableHeadersVisualStyles = false;
            this.DS_DauSach.Location = new System.Drawing.Point(8, 8);
            this.DS_DauSach.MultiSelect = false;
            this.DS_DauSach.Name = "DS_DauSach";
            this.DS_DauSach.ReadOnly = true;
            this.DS_DauSach.RowHeadersVisible = false;
            this.DS_DauSach.RowHeadersWidth = 51;
            this.DS_DauSach.RowTemplate.Height = 24;
            this.DS_DauSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DS_DauSach.Size = new System.Drawing.Size(830, 568);
            this.DS_DauSach.TabIndex = 12;
            this.DS_DauSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DS_DauSach_CellClick);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.btnXemVaCapNhat);
            this.panel8.Location = new System.Drawing.Point(642, 61);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(204, 42);
            this.panel8.TabIndex = 9;
            // 
            // btnXemVaCapNhat
            // 
            this.btnXemVaCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemVaCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(205)))), ((int)(((byte)(203)))));
            this.btnXemVaCapNhat.FlatAppearance.BorderSize = 0;
            this.btnXemVaCapNhat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnXemVaCapNhat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.btnXemVaCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemVaCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemVaCapNhat.Location = new System.Drawing.Point(1, 7);
            this.btnXemVaCapNhat.Name = "btnXemVaCapNhat";
            this.btnXemVaCapNhat.Size = new System.Drawing.Size(200, 29);
            this.btnXemVaCapNhat.TabIndex = 2;
            this.btnXemVaCapNhat.Text = "Xem và Cập nhật";
            this.btnXemVaCapNhat.UseVisualStyleBackColor = false;
            this.btnXemVaCapNhat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXemVaCapNhat_MouseDown);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.panel9.Location = new System.Drawing.Point(380, 50);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(5, 1000);
            this.panel9.TabIndex = 11;
            // 
            // dauSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1244, 753);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dauSach";
            this.Text = "Đầu sách";
            this.Load += new System.EventHandler(this.dauSach_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_AddTacGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_RemoveTacGia)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_DauSach)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayNhap;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label thongTinPN;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconPictureBox btn_AddTacGia;
        private FontAwesome.Sharp.IconPictureBox btn_RemoveTacGia;
        private System.Windows.Forms.Button btnThemTG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView DS_DauSach;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnXemVaCapNhat;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cb_TenTheLoai;
        private System.Windows.Forms.ComboBox cb_TenTacGia;
        private System.Windows.Forms.ComboBox cb_MaTheLoai;
        private System.Windows.Forms.TextBox txb_MaDauSach;
        private System.Windows.Forms.TextBox txb_TenDauSach;
        private System.Windows.Forms.ListBox listBox_TacGia;
    }
}