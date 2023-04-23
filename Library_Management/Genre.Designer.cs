namespace Library_Management
{
    partial class Genre
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
            this.pnl_Content = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrv_Book = new System.Windows.Forms.DataGridView();
            this.pnl_Buttons = new System.Windows.Forms.Panel();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Genre = new System.Windows.Forms.TextBox();
            this.lb_GenreName = new System.Windows.Forms.Label();
            this.txt_BookCode = new System.Windows.Forms.TextBox();
            this.lb_GenreCode = new System.Windows.Forms.Label();
            this.lb_Genre = new System.Windows.Forms.Label();
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.mnstr_1 = new System.Windows.Forms.MenuStrip();
            this.tRANGCHỦToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sÁCHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đâuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sáchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tácGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thểLoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuNhậpSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đỘCGIẢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thẻĐộcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiĐộcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuThuTiềnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mƯỢNTRẢSÁCHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mượnSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trảSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRACỨUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tHỐNGKÊToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUYĐỊNHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_Name = new System.Windows.Forms.Panel();
            this.lb_Name = new System.Windows.Forms.Label();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.col_GenreCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_Content.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_Book)).BeginInit();
            this.pnl_Buttons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Menu.SuspendLayout();
            this.mnstr_1.SuspendLayout();
            this.pnl_Name.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Content
            // 
            this.pnl_Content.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_Content.Controls.Add(this.panel2);
            this.pnl_Content.Controls.Add(this.pnl_Buttons);
            this.pnl_Content.Controls.Add(this.panel1);
            this.pnl_Content.Controls.Add(this.lb_Genre);
            this.pnl_Content.Location = new System.Drawing.Point(0, 154);
            this.pnl_Content.Name = "pnl_Content";
            this.pnl_Content.Size = new System.Drawing.Size(1028, 442);
            this.pnl_Content.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrv_Book);
            this.panel2.Location = new System.Drawing.Point(219, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 287);
            this.panel2.TabIndex = 4;
            // 
            // dgrv_Book
            // 
            this.dgrv_Book.AllowUserToAddRows = false;
            this.dgrv_Book.AllowUserToDeleteRows = false;
            this.dgrv_Book.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgrv_Book.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrv_Book.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_GenreCode,
            this.col_Genre});
            this.dgrv_Book.Location = new System.Drawing.Point(0, 0);
            this.dgrv_Book.Name = "dgrv_Book";
            this.dgrv_Book.ReadOnly = true;
            this.dgrv_Book.RowHeadersVisible = false;
            this.dgrv_Book.RowHeadersWidth = 62;
            this.dgrv_Book.RowTemplate.Height = 28;
            this.dgrv_Book.Size = new System.Drawing.Size(536, 287);
            this.dgrv_Book.TabIndex = 0;
            // 
            // pnl_Buttons
            // 
            this.pnl_Buttons.Controls.Add(this.btn_Update);
            this.pnl_Buttons.Controls.Add(this.btn_Save);
            this.pnl_Buttons.Controls.Add(this.btn_Delete);
            this.pnl_Buttons.Controls.Add(this.btn_Add);
            this.pnl_Buttons.Location = new System.Drawing.Point(569, 52);
            this.pnl_Buttons.Name = "pnl_Buttons";
            this.pnl_Buttons.Size = new System.Drawing.Size(307, 94);
            this.pnl_Buttons.TabIndex = 3;
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Update.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(13, 50);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(119, 35);
            this.btn_Update.TabIndex = 3;
            this.btn_Update.Text = "Cập nhật";
            this.btn_Update.UseVisualStyleBackColor = false;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Save.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(164, 9);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(119, 35);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Delete.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(164, 50);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(119, 35);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "Xoá";
            this.btn_Delete.UseVisualStyleBackColor = false;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Add.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(13, 9);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(119, 35);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Genre);
            this.panel1.Controls.Add(this.lb_GenreName);
            this.panel1.Controls.Add(this.txt_BookCode);
            this.panel1.Controls.Add(this.lb_GenreCode);
            this.panel1.Location = new System.Drawing.Point(89, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 94);
            this.panel1.TabIndex = 2;
            // 
            // txt_Genre
            // 
            this.txt_Genre.Location = new System.Drawing.Point(150, 48);
            this.txt_Genre.Name = "txt_Genre";
            this.txt_Genre.Size = new System.Drawing.Size(182, 26);
            this.txt_Genre.TabIndex = 12;
            // 
            // lb_GenreName
            // 
            this.lb_GenreName.AutoSize = true;
            this.lb_GenreName.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_GenreName.Location = new System.Drawing.Point(3, 48);
            this.lb_GenreName.Name = "lb_GenreName";
            this.lb_GenreName.Size = new System.Drawing.Size(141, 26);
            this.lb_GenreName.TabIndex = 11;
            this.lb_GenreName.Text = "Tên thể loại:";
            // 
            // txt_BookCode
            // 
            this.txt_BookCode.Location = new System.Drawing.Point(150, 9);
            this.txt_BookCode.Name = "txt_BookCode";
            this.txt_BookCode.Size = new System.Drawing.Size(182, 26);
            this.txt_BookCode.TabIndex = 10;
            // 
            // lb_GenreCode
            // 
            this.lb_GenreCode.AutoSize = true;
            this.lb_GenreCode.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_GenreCode.Location = new System.Drawing.Point(3, 9);
            this.lb_GenreCode.Name = "lb_GenreCode";
            this.lb_GenreCode.Size = new System.Drawing.Size(133, 26);
            this.lb_GenreCode.TabIndex = 9;
            this.lb_GenreCode.Text = "Mã thể loại:";
            // 
            // lb_Genre
            // 
            this.lb_Genre.AutoSize = true;
            this.lb_Genre.Font = new System.Drawing.Font("MS Reference Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Genre.Location = new System.Drawing.Point(402, 3);
            this.lb_Genre.Name = "lb_Genre";
            this.lb_Genre.Size = new System.Drawing.Size(159, 35);
            this.lb_Genre.TabIndex = 1;
            this.lb_Genre.Text = "THỂ LOẠI";
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_Menu.Controls.Add(this.mnstr_1);
            this.pnl_Menu.Location = new System.Drawing.Point(0, 106);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(1028, 48);
            this.pnl_Menu.TabIndex = 8;
            // 
            // mnstr_1
            // 
            this.mnstr_1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnstr_1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnstr_1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnstr_1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tRANGCHỦToolStripMenuItem,
            this.sÁCHToolStripMenuItem,
            this.đỘCGIẢToolStripMenuItem,
            this.mƯỢNTRẢSÁCHToolStripMenuItem,
            this.tRACỨUToolStripMenuItem,
            this.tHỐNGKÊToolStripMenuItem,
            this.qUYĐỊNHToolStripMenuItem});
            this.mnstr_1.Location = new System.Drawing.Point(0, 0);
            this.mnstr_1.Name = "mnstr_1";
            this.mnstr_1.Size = new System.Drawing.Size(1028, 33);
            this.mnstr_1.TabIndex = 0;
            this.mnstr_1.Text = "menuStrip1";
            // 
            // tRANGCHỦToolStripMenuItem
            // 
            this.tRANGCHỦToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tRANGCHỦToolStripMenuItem.Image = global::Library_Management.Properties.Resources.home11;
            this.tRANGCHỦToolStripMenuItem.Name = "tRANGCHỦToolStripMenuItem";
            this.tRANGCHỦToolStripMenuItem.Size = new System.Drawing.Size(150, 29);
            this.tRANGCHỦToolStripMenuItem.Text = "TRANG CHỦ";
            // 
            // sÁCHToolStripMenuItem
            // 
            this.sÁCHToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sÁCHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đâuToolStripMenuItem,
            this.sáchToolStripMenuItem1,
            this.tácGiảToolStripMenuItem,
            this.thểLoạiToolStripMenuItem,
            this.phiếuNhậpSáchToolStripMenuItem});
            this.sÁCHToolStripMenuItem.Image = global::Library_Management.Properties.Resources.book;
            this.sÁCHToolStripMenuItem.Name = "sÁCHToolStripMenuItem";
            this.sÁCHToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.sÁCHToolStripMenuItem.Text = "SÁCH";
            // 
            // đâuToolStripMenuItem
            // 
            this.đâuToolStripMenuItem.Name = "đâuToolStripMenuItem";
            this.đâuToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.đâuToolStripMenuItem.Text = "Đầu sách";
            // 
            // sáchToolStripMenuItem1
            // 
            this.sáchToolStripMenuItem1.Name = "sáchToolStripMenuItem1";
            this.sáchToolStripMenuItem1.Size = new System.Drawing.Size(242, 34);
            this.sáchToolStripMenuItem1.Text = "Sách";
            // 
            // tácGiảToolStripMenuItem
            // 
            this.tácGiảToolStripMenuItem.Name = "tácGiảToolStripMenuItem";
            this.tácGiảToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.tácGiảToolStripMenuItem.Text = "Thể loại";
            // 
            // thểLoạiToolStripMenuItem
            // 
            this.thểLoạiToolStripMenuItem.Name = "thểLoạiToolStripMenuItem";
            this.thểLoạiToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.thểLoạiToolStripMenuItem.Text = "Tác giả";
            // 
            // phiếuNhậpSáchToolStripMenuItem
            // 
            this.phiếuNhậpSáchToolStripMenuItem.Name = "phiếuNhậpSáchToolStripMenuItem";
            this.phiếuNhậpSáchToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.phiếuNhậpSáchToolStripMenuItem.Text = "Phiếu nhập sách";
            // 
            // đỘCGIẢToolStripMenuItem
            // 
            this.đỘCGIẢToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thẻĐộcGiảToolStripMenuItem,
            this.loạiĐộcGiảToolStripMenuItem,
            this.phiếuThuTiềnToolStripMenuItem});
            this.đỘCGIẢToolStripMenuItem.Image = global::Library_Management.Properties.Resources.user;
            this.đỘCGIẢToolStripMenuItem.Name = "đỘCGIẢToolStripMenuItem";
            this.đỘCGIẢToolStripMenuItem.Size = new System.Drawing.Size(124, 29);
            this.đỘCGIẢToolStripMenuItem.Text = "ĐỘC GIẢ";
            // 
            // thẻĐộcGiảToolStripMenuItem
            // 
            this.thẻĐộcGiảToolStripMenuItem.Name = "thẻĐộcGiảToolStripMenuItem";
            this.thẻĐộcGiảToolStripMenuItem.Size = new System.Drawing.Size(222, 34);
            this.thẻĐộcGiảToolStripMenuItem.Text = "Thẻ độc giả";
            // 
            // loạiĐộcGiảToolStripMenuItem
            // 
            this.loạiĐộcGiảToolStripMenuItem.Name = "loạiĐộcGiảToolStripMenuItem";
            this.loạiĐộcGiảToolStripMenuItem.Size = new System.Drawing.Size(222, 34);
            this.loạiĐộcGiảToolStripMenuItem.Text = "Loại độc giả";
            // 
            // phiếuThuTiềnToolStripMenuItem
            // 
            this.phiếuThuTiềnToolStripMenuItem.Name = "phiếuThuTiềnToolStripMenuItem";
            this.phiếuThuTiềnToolStripMenuItem.Size = new System.Drawing.Size(222, 34);
            this.phiếuThuTiềnToolStripMenuItem.Text = "Phiếu thu tiền";
            // 
            // mƯỢNTRẢSÁCHToolStripMenuItem
            // 
            this.mƯỢNTRẢSÁCHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mượnSáchToolStripMenuItem,
            this.trảSáchToolStripMenuItem});
            this.mƯỢNTRẢSÁCHToolStripMenuItem.Image = global::Library_Management.Properties.Resources.transfer;
            this.mƯỢNTRẢSÁCHToolStripMenuItem.Name = "mƯỢNTRẢSÁCHToolStripMenuItem";
            this.mƯỢNTRẢSÁCHToolStripMenuItem.Size = new System.Drawing.Size(198, 29);
            this.mƯỢNTRẢSÁCHToolStripMenuItem.Text = "MƯỢN/TRẢ SÁCH";
            // 
            // mượnSáchToolStripMenuItem
            // 
            this.mượnSáchToolStripMenuItem.Name = "mượnSáchToolStripMenuItem";
            this.mượnSáchToolStripMenuItem.Size = new System.Drawing.Size(202, 34);
            this.mượnSáchToolStripMenuItem.Text = "Mượn sách";
            // 
            // trảSáchToolStripMenuItem
            // 
            this.trảSáchToolStripMenuItem.Name = "trảSáchToolStripMenuItem";
            this.trảSáchToolStripMenuItem.Size = new System.Drawing.Size(202, 34);
            this.trảSáchToolStripMenuItem.Text = "Trả sách";
            // 
            // tRACỨUToolStripMenuItem
            // 
            this.tRACỨUToolStripMenuItem.Image = global::Library_Management.Properties.Resources.research;
            this.tRACỨUToolStripMenuItem.Name = "tRACỨUToolStripMenuItem";
            this.tRACỨUToolStripMenuItem.Size = new System.Drawing.Size(125, 29);
            this.tRACỨUToolStripMenuItem.Text = "TRA CỨU";
            // 
            // tHỐNGKÊToolStripMenuItem
            // 
            this.tHỐNGKÊToolStripMenuItem.Image = global::Library_Management.Properties.Resources.report;
            this.tHỐNGKÊToolStripMenuItem.Name = "tHỐNGKÊToolStripMenuItem";
            this.tHỐNGKÊToolStripMenuItem.Size = new System.Drawing.Size(137, 29);
            this.tHỐNGKÊToolStripMenuItem.Text = "THỐNG KÊ";
            // 
            // qUYĐỊNHToolStripMenuItem
            // 
            this.qUYĐỊNHToolStripMenuItem.Image = global::Library_Management.Properties.Resources.regulation;
            this.qUYĐỊNHToolStripMenuItem.Name = "qUYĐỊNHToolStripMenuItem";
            this.qUYĐỊNHToolStripMenuItem.Size = new System.Drawing.Size(137, 29);
            this.qUYĐỊNHToolStripMenuItem.Text = "QUY ĐỊNH";
            // 
            // pnl_Name
            // 
            this.pnl_Name.BackColor = System.Drawing.Color.LightBlue;
            this.pnl_Name.Controls.Add(this.lb_Name);
            this.pnl_Name.Controls.Add(this.pic_Logo);
            this.pnl_Name.Location = new System.Drawing.Point(0, -1);
            this.pnl_Name.Name = "pnl_Name";
            this.pnl_Name.Size = new System.Drawing.Size(1028, 107);
            this.pnl_Name.TabIndex = 7;
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("MS Reference Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Name.Location = new System.Drawing.Point(125, 29);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(316, 55);
            this.lb_Name.TabIndex = 1;
            this.lb_Name.Text = "THƯ VIỆN ...";
            // 
            // pic_Logo
            // 
            this.pic_Logo.Image = global::Library_Management.Properties.Resources.library__1_1;
            this.pic_Logo.Location = new System.Drawing.Point(0, 0);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(119, 107);
            this.pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Logo.TabIndex = 0;
            this.pic_Logo.TabStop = false;
            // 
            // col_GenreCode
            // 
            this.col_GenreCode.HeaderText = "Mã thể loại";
            this.col_GenreCode.MinimumWidth = 8;
            this.col_GenreCode.Name = "col_GenreCode";
            this.col_GenreCode.ReadOnly = true;
            this.col_GenreCode.Width = 250;
            // 
            // col_Genre
            // 
            this.col_Genre.HeaderText = "Tên thể loại";
            this.col_Genre.MinimumWidth = 8;
            this.col_Genre.Name = "col_Genre";
            this.col_Genre.ReadOnly = true;
            this.col_Genre.Width = 283;
            // 
            // Genre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1028, 594);
            this.Controls.Add(this.pnl_Content);
            this.Controls.Add(this.pnl_Menu);
            this.Controls.Add(this.pnl_Name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Genre";
            this.Text = "THƯ VIỆN ...";
            this.pnl_Content.ResumeLayout(false);
            this.pnl_Content.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_Book)).EndInit();
            this.pnl_Buttons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Menu.ResumeLayout(false);
            this.pnl_Menu.PerformLayout();
            this.mnstr_1.ResumeLayout(false);
            this.mnstr_1.PerformLayout();
            this.pnl_Name.ResumeLayout(false);
            this.pnl_Name.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Content;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrv_Book;
        private System.Windows.Forms.Panel pnl_Buttons;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Genre;
        private System.Windows.Forms.Label lb_GenreName;
        private System.Windows.Forms.TextBox txt_BookCode;
        private System.Windows.Forms.Label lb_GenreCode;
        private System.Windows.Forms.Label lb_Genre;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.MenuStrip mnstr_1;
        private System.Windows.Forms.ToolStripMenuItem tRANGCHỦToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sÁCHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đâuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sáchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tácGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thểLoạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuNhậpSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đỘCGIẢToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thẻĐộcGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loạiĐộcGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuThuTiềnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mƯỢNTRẢSÁCHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mượnSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trảSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tRACỨUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHỐNGKÊToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUYĐỊNHToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_Name;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GenreCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Genre;
    }
}