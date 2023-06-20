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
using System.Windows.Forms;

namespace Library_Management
{
    public partial class chiTietPTS : Form
    {
        List<DetailBorrowSlip> detailSlips;
        BindingSource binding;
        public chiTietPTS()
        {
            InitializeComponent();
        }

        private void ConfirmLendBook_Load(object sender, EventArgs e)
        {
            detailSlips = new List<DetailBorrowSlip>();
            binding = new BindingSource();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                detailSlips.Clear();
                //string queryCmd = $@"SELECT MaChiTietPhieuTra, MaCuonSach
                //    FROM CTPT, PHIEUTRASACH
                //    WHERE PHIEUTRASACH.MaPhieuTraSach = '{DSPhieuTS.slipCode}' 
                //    AND PHIEUTRASACH.MaPhieuTraSach = CTPT.MaPhieuTraSach";
                string queryCmd = $@"SELECT MaChiTietPhieuMuon, CTPHIEUMUON.MaCuonSach, TinhTrangPM
                    FROM CTPHIEUMUON, PHIEUMUON, CTPT
                    WHERE CTPT.MaPhieuTraSach = '{DSPhieuTS.slipCode}' 
                    AND CTPT.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
                    AND PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach";
                SqlConnection conn = new SqlConnection(Database.connectionStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(queryCmd, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetailBorrowSlip slip = new DetailBorrowSlip();
                        slip.specSlipCode = reader.GetString(0);
                        slip.bookCode = reader.GetString(1);
                        slip.status = (reader.GetSqlBoolean(2)) ? "Đã trả" : "Chưa trả";

                        detailSlips.Add(slip);
                    }
                }
                conn.Close();

                detailSlips.OrderBy(o => o.specSlipCode).ThenBy(o => o.bookCode).ThenBy(o => o.status).ToList();
                int stt = 1;
                foreach (DetailBorrowSlip borrowSlip in detailSlips)
                {
                    borrowSlip.stt = stt;
                    stt++;
                }

                binding = new BindingSource();
                binding.DataSource = detailSlips;
                DS_chitietPTS.DataSource = binding;

                if (DS_chitietPTS.Rows.Count != 0)
                {
                    DS_chitietPTS.Rows[0].Selected = false;
                }
                btnDelete.Enabled = false;
                DS_chitietPTS.Columns[0].HeaderText = "STT";
                DS_chitietPTS.Columns[1].HeaderText = "Mã Chi Tiết Phiếu Mượn Sách";
                DS_chitietPTS.Columns[2].HeaderText = "Mã Cuốn Sách";
                DS_chitietPTS.Columns[3].HeaderText = "Tình trạng sách";
                DS_chitietPTS.Columns[0].Width = 150;
                DS_chitietPTS.Columns[1].Width = 300;
                DS_chitietPTS.Columns[2].Width = 250;
                DS_chitietPTS.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string FormatDate(string date)
        {
            string day = date.Substring(8, 2);
            string month = date.Substring(5, 2);
            string year = date.Substring(0, 4);
            return $"{day}/{month}/{year}";
        }

        private void dtgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                txb_MaPTS.Text = DSPhieuTS.slipCode;
                txb_MaCTPMS.Text = DS_chitietPTS.Rows[e.RowIndex].Cells[1].Value.ToString();
                txb_MaCuonSach.Text = DS_chitietPTS.Rows[e.RowIndex].Cells[2].Value.ToString();
                txb_TinhTrang.Text = DS_chitietPTS.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (txb_TinhTrang.Text == "Chưa trả")
                {
                    btnDelete.Enabled = true;
                }
            }
        }
        private void UpdataData()
        {
            string queryUpdateCmd = $@"DELETE FROM CTPHIEUMUON
                WHERE MaChiTietPhieuMuon = '{txb_MaCTPMS.Text}'

                UPDATE CUONSACH
                SET TinhTrang = 1
                WHERE MaCuonSach = '{txb_MaCuonSach.Text}'";

            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryUpdateCmd, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdataData();
            DSPhieuMS.dataChanged = true;
            MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDelete.Enabled = false;

            txb_MaPTS.Text = "";
            txb_MaCTPMS.Text = "";
            txb_MaCuonSach.Text = "";
            txb_TinhTrang.Text = "";
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
