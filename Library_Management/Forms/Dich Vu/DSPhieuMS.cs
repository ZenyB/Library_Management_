using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class DSPhieuMS : Form
    {
        List<BorrowSlip> borrowSlips;
        BindingSource binding;
        bool isLocked = true;
        public static bool dataChanged = false;
        public static string slipCode = "";

        int opt = -1;

        public DSPhieuMS()
        {
            InitializeComponent();
        }

        private void ConfirmLendBook_Load(object sender, EventArgs e)
        {
            borrowSlips = new List<BorrowSlip>();
            binding = new BindingSource();
            dataChanged = false;
            LoadData();
            DS_chitietPMS.Columns[0].HeaderText = "STT";
            DS_chitietPMS.Columns[1].HeaderText = "Mã Phiếu Mượn";
            DS_chitietPMS.Columns[2].HeaderText = "Mã Độc Giả";
            DS_chitietPMS.Columns[3].HeaderText = "Tên Độc Giả";
            DS_chitietPMS.Columns[4].HeaderText = "Ngày Mượn";
            DS_chitietPMS.Columns[5].HeaderText = "Ngày Trả";
            DS_chitietPMS.AutoGenerateColumns = false;
            DS_chitietPMS.Columns[0].Width = 70;
            DS_chitietPMS.Columns[1].Width = 150;
            DS_chitietPMS.Columns[2].Width = 150;
            DS_chitietPMS.Columns[3].Width = 300;
            DS_chitietPMS.Columns[4].Width = 150;
            DS_chitietPMS.Columns[4].Width = 150;
        }

        private void LoadData()
        {
            borrowSlips.Clear();
            string queryCmd = @"SELECT MaPhieuMuonSach, PHIEUMUON.MaDocGia, HoTen, NgMuon, HanTra
                FROM PHIEUMUON, DOCGIA
                WHERE PHIEUMUON.MaDocGia = DOCGIA.MaDocGia";
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BorrowSlip slip = new BorrowSlip();
                    slip.slipCode = reader.GetString(0);
                    slip.code = reader.GetString(1);
                    slip.name = reader.GetString(2);
                    slip.borrowDate = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    slip.returnDate = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                    borrowSlips.Add(slip);
                }
            }
            conn.Close();

            borrowSlips.OrderBy(o => o.slipCode).ThenBy(o => o.code).ThenBy(o => o.name).ToList();
            int stt = 1;
            foreach (BorrowSlip borrowSlip in borrowSlips)
            {
                borrowSlip.stt = stt;
                stt++;
            }

            binding = new BindingSource();
            binding.DataSource = borrowSlips;
            DS_chitietPMS.DataSource = binding;

            if (DS_chitietPMS.Rows.Count != 0)
            {
                DS_chitietPMS.Rows[0].Selected = false;
            }
        }

        private string FormatDate(string date)
        {
            string day = date.Substring(8, 2);
            string month = date.Substring(5, 2);
            string year = date.Substring(0, 4);
            return $"{day}/{month}/{year}";
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            if (dataChanged)
            {
                this.Hide();
                muonSach muonSach = new muonSach();
                muonSach.ShowDialog();
                MessageBox.Show("Dữ liệu vừa được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void DS_chitietPMS_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                isLocked = true;
                btnLuu.Enabled = false;
                btnCapNhat.Enabled = false;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;

                txb_MaPMS.Text = DS_chitietPMS.Rows[e.RowIndex].Cells[1].Value.ToString();
                slipCode = txb_MaPMS.Text;
                txb_MaDocGia.Text = DS_chitietPMS.Rows[e.RowIndex].Cells[2].Value.ToString();
                txb_TenDocGia.Text = DS_chitietPMS.Rows[e.RowIndex].Cells[3].Value.ToString();
                string date = DS_chitietPMS.Rows[e.RowIndex].Cells[4].Value.ToString();
                DateTime borrowDate = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
                date = DS_chitietPMS.Rows[e.RowIndex].Cells[5].Value.ToString();
                DateTime returnDay = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
                dtpNgayMuon.Value = borrowDate;
                dtpNgayTra.Value = returnDay;

                isLocked = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtpNgayMuon.Value > DateTime.Now || dtpNgayTra.Value < dtpNgayMuon.Value)
            {
                MessageBox.Show("Ngày mượn và trả sách không hợp lệ", "Thông báo lỗi");
                return;
            }
            opt = 1;
            btnCapNhat.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void UpdataData()
        {
            string queryUpdateCmd = "";
            if (opt == 1)
            {
                queryUpdateCmd = $@"UPDATE PHIEUMUON
                SET NgMuon = '{dtpNgayMuon.Value.Date.ToString("MM/dd/yyyy")}', HanTra = '{dtpNgayTra.Value.Date.ToString("MM/dd/yyyy")}'
                WHERE MaPhieuMuonSach = '{txb_MaPMS.Text}'";
            }
            else if (opt == 2)
            {
                queryUpdateCmd = $@"
                    UPDATE CUONSACH
                    SET TinhTrang = 0
                    WHERE CUONSACH.MaCuonSach IN (SELECT CTPHIEUMUON.MaCuonSach
		                    FROM CTPHIEUMUON
		                    WHERE CTPHIEUMUON.MaPhieuMuonSach = '{txb_MaPMS.Text}')

                    DELETE FROM CTPHIEUMUON
                    WHERE MaPhieuMuonSach = '{txb_MaPMS.Text}'

                    DELETE FROM CTPT
                    WHERE MaPhieuMuonSach = '{txb_MaPMS.Text}'
                    
                    DELETE FROM PHIEUMUON
                    WHERE MaPhieuMuonSach = '{txb_MaPMS.Text}'";
            }

            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryUpdateCmd, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void dtpNgayMuon_ValueChanged(object sender, EventArgs e)
        {
            if (!isLocked)
            {
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            if (!isLocked)
            {
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdataData();
            dataChanged = true;
            MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLuu.Enabled = false;
            btnCapNhat.Enabled = false;
            opt = -1;

            txb_MaPMS.Text = "";
            txb_MaDocGia.Text = "";
            txb_TenDocGia.Text = "";
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            opt = 2;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnCapNhat.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnCapNhat.Enabled = false;

            string date = DS_chitietPMS.SelectedRows[0].Cells[4].Value.ToString();
            DateTime borrowDate = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
            date = DS_chitietPMS.SelectedRows[0].Cells[5].Value.ToString();
            DateTime returnDay = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
            dtpNgayMuon.Value = borrowDate;
            dtpNgayTra.Value = returnDay;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            new chITietPMS().ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
