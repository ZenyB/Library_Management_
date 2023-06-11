namespace Library_Management
{
    partial class FormThongKe
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.DS_TacGia = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuotMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_TacGia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Avo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(480, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(4)))), ((int)(((byte)(32)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1244, 5);
            this.panel4.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 50);
            this.panel2.TabIndex = 22;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(146, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(411, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Loại báo cáo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(115)))), ((int)(((byte)(213)))));
            this.panel1.Controls.Add(this.btnXuatBaoCao);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 61);
            this.panel1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(575, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Thời gian:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(655, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(174)))));
            this.btnXuatBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXuatBaoCao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnXuatBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXuatBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatBaoCao.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(1011, 14);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(186, 29);
            this.btnXuatBaoCao.TabIndex = 27;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 50);
            this.panel3.TabIndex = 26;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.Controls.Add(this.DS_TacGia);
            this.panel12.Location = new System.Drawing.Point(42, 191);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1158, 550);
            this.panel12.TabIndex = 27;
            // 
            // DS_TacGia
            // 
            this.DS_TacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DS_TacGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DS_TacGia.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DS_TacGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DS_TacGia.ColumnHeadersHeight = 50;
            this.DS_TacGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.tenTheLoai,
            this.soLuotMuon,
            this.tiLe});
            this.DS_TacGia.Location = new System.Drawing.Point(3, 3);
            this.DS_TacGia.Name = "DS_TacGia";
            this.DS_TacGia.RowHeadersVisible = false;
            this.DS_TacGia.RowHeadersWidth = 51;
            this.DS_TacGia.RowTemplate.Height = 24;
            this.DS_TacGia.Size = new System.Drawing.Size(1152, 547);
            this.DS_TacGia.TabIndex = 17;
            // 
            // stt
            // 
            this.stt.FillWeight = 96.25668F;
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
            // 
            // tenTheLoai
            // 
            this.tenTheLoai.HeaderText = "Tên thể loại";
            this.tenTheLoai.MinimumWidth = 6;
            this.tenTheLoai.Name = "tenTheLoai";
            // 
            // soLuotMuon
            // 
            this.soLuotMuon.HeaderText = "Số lượt mượn";
            this.soLuotMuon.MinimumWidth = 6;
            this.soLuotMuon.Name = "soLuotMuon";
            // 
            // tiLe
            // 
            this.tiLe.HeaderText = "Tỉ lệ";
            this.tiLe.MinimumWidth = 6;
            this.tiLe.Name = "tiLe";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(39)))), ((int)(((byte)(102)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("UTM Avo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(1091, 166);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(106, 24);
            this.textBox3.TabIndex = 29;
            this.textBox3.Text = "(e.g)";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("UTM Avo", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(949, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 19);
            this.label14.TabIndex = 28;
            this.label14.Text = "Tổng số lượt mượn:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("UTM Avo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(455, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(358, 29);
            this.label5.TabIndex = 25;
            this.label5.Text = "Nội dung bảng báo cáo thống kê";
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(39)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(1244, 753);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "FormThongKe";
            this.Text = "Thống kê";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_TacGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXuatBaoCao;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView DS_TacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuotMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiLe;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
    }
}