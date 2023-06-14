using Library_Management.Models;
using Library_Management.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Interop;
using System.Globalization;

namespace Library_Management
{
    public partial class traSach : Form
    {
        string chuoiKetNoi = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection myConnection; // kết nối tới csdl
        private SqlDataAdapter myDataAdapter;   // Vận chuyển csdl qa DataSet
        private DataTable myTable;  // Dùng để lưu bảng lấy từ c#
        SqlCommand myCommand;

        private string choosen;
        private int i;

        private DataTable connect(string query)
        {
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(query, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            return myTable;
        }
        private void connectNonQuery(string nonquery)
        {
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            myCommand = new SqlCommand(nonquery, myConnection);
            myCommand.ExecuteNonQuery();

        }
        public traSach()
        {
            InitializeComponent();
        }

        private void btnXemPhieuTra_Click(object sender, EventArgs e)
        {
            // hide form 1
            // this.Hide();
            // create an instace of form 2
            DSPhieuTS f2 = new DSPhieuTS();
            // show form 2
            f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            // dispose form 2 instance
            f2 = null;
            //show form 1 again
            this.Show();
        }

        private void traSach_Load(object sender, EventArgs e)
        {
            datetimeNgayTra.Value = DateTime.Now;

            //tdGetNewSlipCode = new Thread(new ThreadStart(GetNewReturnSlipCode));
            btn_Add.Enabled = false;
            btn_Remove.Enabled = false;

            GetNewReturnSlipCode();
        }
        void loadTongNo()
        {
            string cauTruyVan = "SELECT TongNo FROM DOCGIA WHERE MaDocGia = '" + txb_MaDocGia.Text + "'";
            connect(cauTruyVan);
            string tongNo = Convert.ToString(myCommand.ExecuteScalar());
            txtTongNo.Text = tongNo;
        }

        private void GetNewReturnSlipCode()
        {
            string query = @"SELECT MaPhieuMuonSach
            FROM CTPHIEUMUON"; 

            cbbSlipCode.DataSource = connect(query);
            cbbSlipCode.DisplayMember = "MaPhieuMuonSach";
            cbbSlipCode.SelectedIndex = -1;
        }

        private void LoadBorrowSlip(string s)
        {
            string query = @"SELECT MaChiTietPhieuMuon, SACH.MaSach, TenDauSach, NgMuon, CTPHIEUMUON.MaCuonSach
                FROM SACH, CUONSACH, PHIEUMUON, CTPHIEUMUON, DAUSACH
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
		            AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach 
						AND PHIEUMUON.MaPhieuMuonSach = '" + this.cbbSlipCode.GetItemText(this.cbbSlipCode.SelectedItem) + "'";

            DS_SlipBook.DataSource = connect(query);
            DS_SlipBook.AutoGenerateColumns = false;
            myConnection.Close();
        }

        private long CalFineThisPeriod(int lateReturnDays)
        {
            long fine = Parameters.finePerDay * lateReturnDays;
            return fine;
        }

        private void loadReader()
        {

        }


        private void cbbSlipCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cbbSlipCode.Text;
            LoadBorrowSlip(s);

            string query = @"SELECT PHIEUMUON.MaDocGia
                FROM PHIEUMUON, CTPHIEUMUON, DOCGIA
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
                        AND PHIEUMUON.MaPhieuMuonSach = '" + this.cbbSlipCode.GetItemText(this.cbbSlipCode.SelectedItem) + "'";

            connect(query);
            string maDG = Convert.ToString(myCommand.ExecuteScalar());
            txb_MaDocGia.Text = maDG;

            query = @"SELECT DOCGIA.HoTen
                FROM PHIEUMUON, CTPHIEUMUON, DOCGIA
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
                        AND PHIEUMUON.MaPhieuMuonSach = '" + this.cbbSlipCode.GetItemText(this.cbbSlipCode.SelectedItem) + "'";

            connect(query);
            string TenDG = Convert.ToString(myCommand.ExecuteScalar());
            txb_TenDocGia.Text = TenDG;
            loadTongNo();
        }

        private void DS_SlipBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Add.Enabled = true;
            btn_Remove.Enabled = false;

            choosen = DS_SlipBook.CurrentRow.Cells[1].Value.ToString();
            i = DS_SlipBook.CurrentRow.Index;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Add.Enabled = false;
            btn_Remove.Enabled = true;

            choosen = DS_Choosen.CurrentRow.Cells[0].Value.ToString();
            i = DS_Choosen.CurrentRow.Index;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string query = @"SELECT SACH.MaSach AS [Mã sách], TenDauSach AS [Tên sách], NgMuon AS [Ngày mượn]
                    FROM SACH, DAUSACH, CUONSACH, CTPHIEUMUON, PHIEUMUON
                    WHERE DAUSACH.MaDauSach = SACH.MaDauSach AND SACH.MaSach = CUONSACH.MaSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach 
                        AND CTPHIEUMUON.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
                        AND SACH.MaSach = '" + choosen + "'";

            DS_Choosen.DataSource = connect(query);
            DS_Choosen.AutoGenerateColumns = false;
            myConnection.Close();

            countDay();
            DS_SlipBook.Rows.RemoveAt(i);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            string query = @"SELECT MaChiTietPhieuMuon, SACH.MaSach, TenDauSach, NgMuon, CTPHIEUMUON.MaCuonSach
                FROM SACH, CUONSACH, PHIEUMUON, CTPHIEUMUON, DAUSACH
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
		            AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach 
						AND SACH.MaSach = '" + choosen + "'";

            DS_SlipBook.DataSource = connect(query);
            DS_SlipBook.AutoGenerateColumns = false;
            myConnection.Close();

            DS_Choosen.Rows.RemoveAt(i);
        }

        private void countDay()
        {
            string a = DS_SlipBook.CurrentRow.Cells[3].Value.ToString();
            string dateString2 = datetimeNgayTra.Value.Date.ToString("MM/dd/yyyy");
            string format = "dd/MM/yyyy";
            DateTime date1 = DateTime.ParseExact(a, format, CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
            TimeSpan diff = date2.Subtract(date1);
            int days = diff.Days;
            txtTien.Text = days.ToString();
        }
    }
}
