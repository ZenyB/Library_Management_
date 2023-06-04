namespace Library_Management
{
    partial class Home
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.TroGiup = new FontAwesome.Sharp.IconButton();
            this.TuyChinh = new FontAwesome.Sharp.IconButton();
            this.ThongKe = new FontAwesome.Sharp.IconButton();
            this.panelDichVuSubMenu = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.DichVu = new FontAwesome.Sharp.IconButton();
            this.panelDocGiaSubMenu = new System.Windows.Forms.Panel();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.DocGia = new FontAwesome.Sharp.IconButton();
            this.panelKhoSachSubMenu = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.KhoSach = new FontAwesome.Sharp.IconButton();
            this.TrangChu = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelDichVuSubMenu.SuspendLayout();
            this.panelDocGiaSubMenu.SuspendLayout();
            this.panelKhoSachSubMenu.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.panelMenu.Controls.Add(this.TroGiup);
            this.panelMenu.Controls.Add(this.TuyChinh);
            this.panelMenu.Controls.Add(this.ThongKe);
            this.panelMenu.Controls.Add(this.panelDichVuSubMenu);
            this.panelMenu.Controls.Add(this.DichVu);
            this.panelMenu.Controls.Add(this.panelDocGiaSubMenu);
            this.panelMenu.Controls.Add(this.DocGia);
            this.panelMenu.Controls.Add(this.panelKhoSachSubMenu);
            this.panelMenu.Controls.Add(this.KhoSach);
            this.panelMenu.Controls.Add(this.TrangChu);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 953);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // TroGiup
            // 
            this.TroGiup.Dock = System.Windows.Forms.DockStyle.Top;
            this.TroGiup.FlatAppearance.BorderSize = 0;
            this.TroGiup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TroGiup.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TroGiup.ForeColor = System.Drawing.Color.White;
            this.TroGiup.IconChar = FontAwesome.Sharp.IconChar.QuestionCircle;
            this.TroGiup.IconColor = System.Drawing.Color.White;
            this.TroGiup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.TroGiup.IconSize = 32;
            this.TroGiup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TroGiup.Location = new System.Drawing.Point(0, 910);
            this.TroGiup.Name = "TroGiup";
            this.TroGiup.Size = new System.Drawing.Size(220, 60);
            this.TroGiup.TabIndex = 12;
            this.TroGiup.Text = "Trợ giúp";
            this.TroGiup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TroGiup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TroGiup.UseVisualStyleBackColor = true;
            this.TroGiup.Click += new System.EventHandler(this.TroGiup_Click);
            // 
            // TuyChinh
            // 
            this.TuyChinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.TuyChinh.FlatAppearance.BorderSize = 0;
            this.TuyChinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TuyChinh.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TuyChinh.ForeColor = System.Drawing.Color.White;
            this.TuyChinh.IconChar = FontAwesome.Sharp.IconChar.Sliders;
            this.TuyChinh.IconColor = System.Drawing.Color.White;
            this.TuyChinh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.TuyChinh.IconSize = 32;
            this.TuyChinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TuyChinh.Location = new System.Drawing.Point(0, 850);
            this.TuyChinh.Name = "TuyChinh";
            this.TuyChinh.Size = new System.Drawing.Size(220, 60);
            this.TuyChinh.TabIndex = 11;
            this.TuyChinh.Text = "Tùy chỉnh";
            this.TuyChinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TuyChinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TuyChinh.UseVisualStyleBackColor = true;
            this.TuyChinh.Click += new System.EventHandler(this.TuyChinh_Click);
            // 
            // ThongKe
            // 
            this.ThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.ThongKe.FlatAppearance.BorderSize = 0;
            this.ThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThongKe.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThongKe.ForeColor = System.Drawing.Color.White;
            this.ThongKe.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.ThongKe.IconColor = System.Drawing.Color.White;
            this.ThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ThongKe.IconSize = 32;
            this.ThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThongKe.Location = new System.Drawing.Point(0, 790);
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.Size = new System.Drawing.Size(220, 60);
            this.ThongKe.TabIndex = 10;
            this.ThongKe.Text = "Thống kê";
            this.ThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ThongKe.UseVisualStyleBackColor = true;
            this.ThongKe.Click += new System.EventHandler(this.ThongKe_Click);
            // 
            // panelDichVuSubMenu
            // 
            this.panelDichVuSubMenu.Controls.Add(this.button4);
            this.panelDichVuSubMenu.Controls.Add(this.button5);
            this.panelDichVuSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDichVuSubMenu.Location = new System.Drawing.Point(0, 707);
            this.panelDichVuSubMenu.Name = "panelDichVuSubMenu";
            this.panelDichVuSubMenu.Size = new System.Drawing.Size(220, 83);
            this.panelDichVuSubMenu.TabIndex = 9;
            this.panelDichVuSubMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDichVuSubMenu_Paint);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 40);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(220, 40);
            this.button4.TabIndex = 1;
            this.button4.Text = "Tra cứu";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(220, 40);
            this.button5.TabIndex = 0;
            this.button5.Text = "Mượn/ Trả sách";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DichVu
            // 
            this.DichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.DichVu.FlatAppearance.BorderSize = 0;
            this.DichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DichVu.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DichVu.ForeColor = System.Drawing.Color.White;
            this.DichVu.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            this.DichVu.IconColor = System.Drawing.Color.White;
            this.DichVu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DichVu.IconSize = 32;
            this.DichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DichVu.Location = new System.Drawing.Point(0, 647);
            this.DichVu.Name = "DichVu";
            this.DichVu.Size = new System.Drawing.Size(220, 60);
            this.DichVu.TabIndex = 8;
            this.DichVu.Text = "Dịch vụ";
            this.DichVu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DichVu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DichVu.UseVisualStyleBackColor = true;
            this.DichVu.Click += new System.EventHandler(this.DichVu_Click);
            // 
            // panelDocGiaSubMenu
            // 
            this.panelDocGiaSubMenu.Controls.Add(this.button16);
            this.panelDocGiaSubMenu.Controls.Add(this.button17);
            this.panelDocGiaSubMenu.Controls.Add(this.button18);
            this.panelDocGiaSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDocGiaSubMenu.Location = new System.Drawing.Point(0, 523);
            this.panelDocGiaSubMenu.Name = "panelDocGiaSubMenu";
            this.panelDocGiaSubMenu.Size = new System.Drawing.Size(220, 124);
            this.panelDocGiaSubMenu.TabIndex = 7;
            this.panelDocGiaSubMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDocGiaSubMenu_Paint);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.White;
            this.button16.Dock = System.Windows.Forms.DockStyle.Top;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(0, 80);
            this.button16.Name = "button16";
            this.button16.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button16.Size = new System.Drawing.Size(220, 40);
            this.button16.TabIndex = 2;
            this.button16.Text = "Phiếu thu tiền";
            this.button16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.White;
            this.button17.Dock = System.Windows.Forms.DockStyle.Top;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(0, 40);
            this.button17.Name = "button17";
            this.button17.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button17.Size = new System.Drawing.Size(220, 40);
            this.button17.TabIndex = 1;
            this.button17.Text = "Loại độc giả";
            this.button17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.White;
            this.button18.Dock = System.Windows.Forms.DockStyle.Top;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(0, 0);
            this.button18.Name = "button18";
            this.button18.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button18.Size = new System.Drawing.Size(220, 40);
            this.button18.TabIndex = 0;
            this.button18.Text = "Thẻ độc giả";
            this.button18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // DocGia
            // 
            this.DocGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocGia.FlatAppearance.BorderSize = 0;
            this.DocGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DocGia.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocGia.ForeColor = System.Drawing.Color.White;
            this.DocGia.IconChar = FontAwesome.Sharp.IconChar.BookOpenReader;
            this.DocGia.IconColor = System.Drawing.Color.White;
            this.DocGia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DocGia.IconSize = 32;
            this.DocGia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DocGia.Location = new System.Drawing.Point(0, 463);
            this.DocGia.Name = "DocGia";
            this.DocGia.Size = new System.Drawing.Size(220, 60);
            this.DocGia.TabIndex = 6;
            this.DocGia.Text = "Độc giả";
            this.DocGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DocGia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DocGia.UseVisualStyleBackColor = true;
            this.DocGia.Click += new System.EventHandler(this.DocGia_Click);
            // 
            // panelKhoSachSubMenu
            // 
            this.panelKhoSachSubMenu.Controls.Add(this.button8);
            this.panelKhoSachSubMenu.Controls.Add(this.button9);
            this.panelKhoSachSubMenu.Controls.Add(this.button10);
            this.panelKhoSachSubMenu.Controls.Add(this.button11);
            this.panelKhoSachSubMenu.Controls.Add(this.button12);
            this.panelKhoSachSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKhoSachSubMenu.Location = new System.Drawing.Point(0, 260);
            this.panelKhoSachSubMenu.Name = "panelKhoSachSubMenu";
            this.panelKhoSachSubMenu.Size = new System.Drawing.Size(220, 203);
            this.panelKhoSachSubMenu.TabIndex = 5;
            this.panelKhoSachSubMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelKhoSachSubMenu_Paint);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(0, 160);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(220, 40);
            this.button8.TabIndex = 4;
            this.button8.Text = "Phiếu nhập sách";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(0, 120);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button9.Size = new System.Drawing.Size(220, 40);
            this.button9.TabIndex = 3;
            this.button9.Text = "Tác giả";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(0, 80);
            this.button10.Name = "button10";
            this.button10.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button10.Size = new System.Drawing.Size(220, 40);
            this.button10.TabIndex = 2;
            this.button10.Text = "Thể loại";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(0, 40);
            this.button11.Name = "button11";
            this.button11.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button11.Size = new System.Drawing.Size(220, 40);
            this.button11.TabIndex = 1;
            this.button11.Text = "Sách";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.White;
            this.button12.Dock = System.Windows.Forms.DockStyle.Top;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(0, 0);
            this.button12.Name = "button12";
            this.button12.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button12.Size = new System.Drawing.Size(220, 40);
            this.button12.TabIndex = 0;
            this.button12.Text = "Đầu sách";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // KhoSach
            // 
            this.KhoSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.KhoSach.FlatAppearance.BorderSize = 0;
            this.KhoSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KhoSach.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KhoSach.ForeColor = System.Drawing.Color.White;
            this.KhoSach.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.KhoSach.IconColor = System.Drawing.Color.White;
            this.KhoSach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.KhoSach.IconSize = 32;
            this.KhoSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KhoSach.Location = new System.Drawing.Point(0, 200);
            this.KhoSach.Name = "KhoSach";
            this.KhoSach.Size = new System.Drawing.Size(220, 60);
            this.KhoSach.TabIndex = 2;
            this.KhoSach.Text = "Kho sách";
            this.KhoSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KhoSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.KhoSach.UseVisualStyleBackColor = true;
            this.KhoSach.Click += new System.EventHandler(this.KhoSach_Click);
            // 
            // TrangChu
            // 
            this.TrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.TrangChu.FlatAppearance.BorderSize = 0;
            this.TrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrangChu.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangChu.ForeColor = System.Drawing.Color.White;
            this.TrangChu.IconChar = FontAwesome.Sharp.IconChar.House;
            this.TrangChu.IconColor = System.Drawing.Color.White;
            this.TrangChu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.TrangChu.IconSize = 32;
            this.TrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TrangChu.Location = new System.Drawing.Point(0, 140);
            this.TrangChu.Name = "TrangChu";
            this.TrangChu.Size = new System.Drawing.Size(220, 60);
            this.TrangChu.TabIndex = 1;
            this.TrangChu.Text = "Trang chủ";
            this.TrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TrangChu.UseVisualStyleBackColor = true;
            this.TrangChu.Click += new System.EventHandler(this.TrangChu_Click_1);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 140);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogo_Paint);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.panelTitleBar.Controls.Add(this.panel1);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1262, 75);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitleBar_Paint);
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnMaximize);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(1103, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 40);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))));
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 20;
            this.btnMinimize.Location = new System.Drawing.Point(0, 7);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(50, 30);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))));
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 20;
            this.btnMaximize.Location = new System.Drawing.Point(56, 7);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(50, 30);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnExit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))));
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(112, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("UTM Avo", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.White;
            this.lblTitleChildForm.Location = new System.Drawing.Point(58, 28);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(81, 20);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Trang chủ";
            this.lblTitleChildForm.Click += new System.EventHandler(this.label1_Click);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 33;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(20, 21);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(35, 33);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            this.iconCurrentChildForm.Click += new System.EventHandler(this.iconCurrentChildForm_Click);
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 75);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1262, 5);
            this.panelShadow.TabIndex = 2;
            this.panelShadow.Paint += new System.Windows.Forms.PaintEventHandler(this.panelShadow_Paint);
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1262, 873);
            this.panelDesktop.TabIndex = 3;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 953);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "Home";
            this.Text = "Home";
            this.panelMenu.ResumeLayout(false);
            this.panelDichVuSubMenu.ResumeLayout(false);
            this.panelDocGiaSubMenu.ResumeLayout(false);
            this.panelKhoSachSubMenu.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton TrangChu;
        private FontAwesome.Sharp.IconButton KhoSach;
        private System.Windows.Forms.Panel panelKhoSachSubMenu;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private FontAwesome.Sharp.IconButton DocGia;
        private FontAwesome.Sharp.IconButton DichVu;
        private System.Windows.Forms.Panel panelDocGiaSubMenu;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private FontAwesome.Sharp.IconButton ThongKe;
        private System.Windows.Forms.Panel panelDichVuSubMenu;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private FontAwesome.Sharp.IconButton TroGiup;
        private FontAwesome.Sharp.IconButton TuyChinh;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnMaximize;
    }
}