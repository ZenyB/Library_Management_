namespace Library_Management.Forms.DocGia
{
    partial class LoaiDocGia
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
            this.pnl_LoaiDG = new System.Windows.Forms.Panel();
            this.lb_LoaiDG = new System.Windows.Forms.Label();
            this.pnl_TTChiTiet = new System.Windows.Forms.Panel();
            this.lb_TTChiTiet = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.lb_TenLoaiDG = new System.Windows.Forms.Label();
            this.txb_TenLoaiDG = new System.Windows.Forms.TextBox();
            this.lb_MaLoaiDG = new System.Windows.Forms.Label();
            this.txb_MaLoaiDG = new System.Windows.Forms.TextBox();
            this.pn_DSLoaiDG = new System.Windows.Forms.Panel();
            this.DS_LoaiDocGia = new System.Windows.Forms.DataGridView();
            this.btnXemVaCapNhat = new System.Windows.Forms.Button();
            this.lb_DSLoaiDG = new System.Windows.Forms.Label();
            this.pnl_LoaiDG.SuspendLayout();
            this.pnl_TTChiTiet.SuspendLayout();
            this.pn_DSLoaiDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_LoaiDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_LoaiDG
            // 
            this.pnl_LoaiDG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.pnl_LoaiDG.Controls.Add(this.lb_LoaiDG);
            this.pnl_LoaiDG.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_LoaiDG.Location = new System.Drawing.Point(0, 0);
            this.pnl_LoaiDG.Name = "pnl_LoaiDG";
            this.pnl_LoaiDG.Size = new System.Drawing.Size(1244, 50);
            this.pnl_LoaiDG.TabIndex = 9;
            // 
            // lb_LoaiDG
            // 
            this.lb_LoaiDG.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_LoaiDG.AutoSize = true;
            this.lb_LoaiDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_LoaiDG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.lb_LoaiDG.Location = new System.Drawing.Point(411, 0);
            this.lb_LoaiDG.Name = "lb_LoaiDG";
            this.lb_LoaiDG.Size = new System.Drawing.Size(383, 32);
            this.lb_LoaiDG.TabIndex = 0;
            this.lb_LoaiDG.Text = "THÔNG TIN LOẠI ĐỘC GIẢ";
            // 
            // pnl_TTChiTiet
            // 
            this.pnl_TTChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.pnl_TTChiTiet.Controls.Add(this.lb_TTChiTiet);
            this.pnl_TTChiTiet.Controls.Add(this.btnLuu);
            this.pnl_TTChiTiet.Controls.Add(this.btnXoa);
            this.pnl_TTChiTiet.Controls.Add(this.btnTaoMoi);
            this.pnl_TTChiTiet.Controls.Add(this.lb_TenLoaiDG);
            this.pnl_TTChiTiet.Controls.Add(this.txb_TenLoaiDG);
            this.pnl_TTChiTiet.Controls.Add(this.lb_MaLoaiDG);
            this.pnl_TTChiTiet.Controls.Add(this.txb_MaLoaiDG);
            this.pnl_TTChiTiet.Location = new System.Drawing.Point(0, 56);
            this.pnl_TTChiTiet.Name = "pnl_TTChiTiet";
            this.pnl_TTChiTiet.Size = new System.Drawing.Size(385, 705);
            this.pnl_TTChiTiet.TabIndex = 10;
            // 
            // lb_TTChiTiet
            // 
            this.lb_TTChiTiet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_TTChiTiet.AutoSize = true;
            this.lb_TTChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TTChiTiet.ForeColor = System.Drawing.Color.White;
            this.lb_TTChiTiet.Location = new System.Drawing.Point(101, 13);
            this.lb_TTChiTiet.Name = "lb_TTChiTiet";
            this.lb_TTChiTiet.Size = new System.Drawing.Size(172, 25);
            this.lb_TTChiTiet.TabIndex = 0;
            this.lb_TTChiTiet.Text = "Thông tin chi tiết";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(205)))), ((int)(((byte)(203)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(30, 258);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(324, 29);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu thông tin";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLuu_MouseDown_1);
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
            this.btnXoa.Location = new System.Drawing.Point(222, 293);
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
            this.btnTaoMoi.Location = new System.Drawing.Point(30, 293);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(186, 29);
            this.btnTaoMoi.TabIndex = 12;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = false;
            this.btnTaoMoi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTaoMoi_MouseDown);
            // 
            // lb_TenLoaiDG
            // 
            this.lb_TenLoaiDG.AutoSize = true;
            this.lb_TenLoaiDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenLoaiDG.ForeColor = System.Drawing.Color.White;
            this.lb_TenLoaiDG.Location = new System.Drawing.Point(26, 169);
            this.lb_TenLoaiDG.Name = "lb_TenLoaiDG";
            this.lb_TenLoaiDG.Size = new System.Drawing.Size(124, 16);
            this.lb_TenLoaiDG.TabIndex = 11;
            this.lb_TenLoaiDG.Text = "Tên loại độc giả:";
            // 
            // txb_TenLoaiDG
            // 
            this.txb_TenLoaiDG.Location = new System.Drawing.Point(30, 194);
            this.txb_TenLoaiDG.Name = "txb_TenLoaiDG";
            this.txb_TenLoaiDG.Size = new System.Drawing.Size(324, 22);
            this.txb_TenLoaiDG.TabIndex = 10;
            // 
            // lb_MaLoaiDG
            // 
            this.lb_MaLoaiDG.AutoSize = true;
            this.lb_MaLoaiDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaLoaiDG.ForeColor = System.Drawing.Color.White;
            this.lb_MaLoaiDG.Location = new System.Drawing.Point(26, 97);
            this.lb_MaLoaiDG.Name = "lb_MaLoaiDG";
            this.lb_MaLoaiDG.Size = new System.Drawing.Size(118, 16);
            this.lb_MaLoaiDG.TabIndex = 2;
            this.lb_MaLoaiDG.Text = "Mã loại độc giả:";
            // 
            // txb_MaLoaiDG
            // 
            this.txb_MaLoaiDG.BackColor = System.Drawing.Color.Silver;
            this.txb_MaLoaiDG.HideSelection = false;
            this.txb_MaLoaiDG.Location = new System.Drawing.Point(30, 122);
            this.txb_MaLoaiDG.Name = "txb_MaLoaiDG";
            this.txb_MaLoaiDG.ReadOnly = true;
            this.txb_MaLoaiDG.Size = new System.Drawing.Size(324, 22);
            this.txb_MaLoaiDG.TabIndex = 1;
            this.txb_MaLoaiDG.Tag = "";
            // 
            // pn_DSLoaiDG
            // 
            this.pn_DSLoaiDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_DSLoaiDG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.pn_DSLoaiDG.Controls.Add(this.DS_LoaiDocGia);
            this.pn_DSLoaiDG.Controls.Add(this.btnXemVaCapNhat);
            this.pn_DSLoaiDG.Controls.Add(this.lb_DSLoaiDG);
            this.pn_DSLoaiDG.Location = new System.Drawing.Point(390, 56);
            this.pn_DSLoaiDG.Name = "pn_DSLoaiDG";
            this.pn_DSLoaiDG.Size = new System.Drawing.Size(854, 699);
            this.pn_DSLoaiDG.TabIndex = 11;
            // 
            // DS_LoaiDocGia
            // 
            this.DS_LoaiDocGia.AllowUserToAddRows = false;
            this.DS_LoaiDocGia.AllowUserToDeleteRows = false;
            this.DS_LoaiDocGia.AllowUserToResizeRows = false;
            this.DS_LoaiDocGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DS_LoaiDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DS_LoaiDocGia.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DS_LoaiDocGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DS_LoaiDocGia.ColumnHeadersHeight = 50;
            this.DS_LoaiDocGia.Location = new System.Drawing.Point(14, 109);
            this.DS_LoaiDocGia.Name = "DS_LoaiDocGia";
            this.DS_LoaiDocGia.ReadOnly = true;
            this.DS_LoaiDocGia.RowHeadersVisible = false;
            this.DS_LoaiDocGia.RowHeadersWidth = 51;
            this.DS_LoaiDocGia.RowTemplate.Height = 24;
            this.DS_LoaiDocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DS_LoaiDocGia.Size = new System.Drawing.Size(829, 578);
            this.DS_LoaiDocGia.TabIndex = 13;
            this.DS_LoaiDocGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DS_LoaiDocGia_CellClick);
            // 
            // btnXemVaCapNhat
            // 
            this.btnXemVaCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemVaCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(205)))), ((int)(((byte)(203)))));
            this.btnXemVaCapNhat.FlatAppearance.BorderSize = 0;
            this.btnXemVaCapNhat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(217)))), ((int)(((byte)(170)))));
            this.btnXemVaCapNhat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(224)))), ((int)(((byte)(181)))));
            this.btnXemVaCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemVaCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemVaCapNhat.Location = new System.Drawing.Point(644, 58);
            this.btnXemVaCapNhat.Name = "btnXemVaCapNhat";
            this.btnXemVaCapNhat.Size = new System.Drawing.Size(200, 29);
            this.btnXemVaCapNhat.TabIndex = 2;
            this.btnXemVaCapNhat.Text = "Xem và Cập nhật";
            this.btnXemVaCapNhat.UseVisualStyleBackColor = false;
            this.btnXemVaCapNhat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXemVaCapNhat_MouseDown);
            // 
            // lb_DSLoaiDG
            // 
            this.lb_DSLoaiDG.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_DSLoaiDG.AutoSize = true;
            this.lb_DSLoaiDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lb_DSLoaiDG.ForeColor = System.Drawing.Color.White;
            this.lb_DSLoaiDG.Location = new System.Drawing.Point(272, 13);
            this.lb_DSLoaiDG.Name = "lb_DSLoaiDG";
            this.lb_DSLoaiDG.Size = new System.Drawing.Size(271, 25);
            this.lb_DSLoaiDG.TabIndex = 0;
            this.lb_DSLoaiDG.Text = "Danh sách các loại độc giả";
            // 
            // LoaiDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1244, 753);
            this.Controls.Add(this.pn_DSLoaiDG);
            this.Controls.Add(this.pnl_TTChiTiet);
            this.Controls.Add(this.pnl_LoaiDG);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoaiDocGia";
            this.Text = "Loại Độc giả";
            this.Load += new System.EventHandler(this.LoaiDocGia_Load);
            this.pnl_LoaiDG.ResumeLayout(false);
            this.pnl_LoaiDG.PerformLayout();
            this.pnl_TTChiTiet.ResumeLayout(false);
            this.pnl_TTChiTiet.PerformLayout();
            this.pn_DSLoaiDG.ResumeLayout(false);
            this.pn_DSLoaiDG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_LoaiDocGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_LoaiDG;
        private System.Windows.Forms.Label lb_LoaiDG;
        private System.Windows.Forms.Panel pnl_TTChiTiet;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Label lb_TenLoaiDG;
        private System.Windows.Forms.TextBox txb_TenLoaiDG;
        private System.Windows.Forms.Label lb_MaLoaiDG;
        private System.Windows.Forms.TextBox txb_MaLoaiDG;
        private System.Windows.Forms.Panel pn_DSLoaiDG;
        private System.Windows.Forms.Button btnXemVaCapNhat;
        private System.Windows.Forms.Label lb_DSLoaiDG;
        private System.Windows.Forms.Label lb_TTChiTiet;
        private System.Windows.Forms.DataGridView DS_LoaiDocGia;
    }
}