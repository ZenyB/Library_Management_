using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class thongTinPMS : Form
    {
        BindingSource bindingChosen;

        internal static BorrowSlip borrowSlip;
        public thongTinPMS()
        {
            InitializeComponent();
        }

        private void ConfirmLendBook_Load(object sender, EventArgs e)
        {
            txb_MaPMS.Text = borrowSlip.slipCode;
            txb_MaDocGia.Text = borrowSlip.code;
            txb_TenDocGia.Text = borrowSlip.name;
            txb_NgayMuon.Text = FormatDate(borrowSlip.borrowDate);
            txb_NgayTra.Text = FormatDate(borrowSlip.returnDate);
            txb_SoLuong.Text = borrowSlip.amount;

            bindingChosen = new BindingSource();
            bindingChosen.DataSource = borrowSlip.chosenBooks;
            DS_PhieuMuon.DataSource = bindingChosen;

            if (DS_PhieuMuon.Rows.Count != 0)
            {
                DS_PhieuMuon.Rows[0].Selected = false;
            }
            DS_PhieuMuon.Columns[0].HeaderText = "STT";
            DS_PhieuMuon.Columns[1].HeaderText = "Mã Sách";
            DS_PhieuMuon.Columns[2].HeaderText = "Tên Sách";
            DS_PhieuMuon.Columns[3].HeaderText = "Thể Loại";
            DS_PhieuMuon.Columns[4].HeaderText = "Tác Giả";
        }
        private string FormatDate(string date)
        {
            string day = date.Substring(8, 2);
            string month = date.Substring(5, 2);
            string year = date.Substring(0, 4);
            return $"{day}/{month}/{year}";
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            UpdataData();
        }

        private void UpdataData()
        {
            string createBorrowSlipCmd = $@"INSERT INTO PHIEUMUON (MaDocGia, NgMuon, HanTra) VALUES('{borrowSlip.code}','{borrowSlip.borrowDate}','{borrowSlip.returnDate}')";
            string insertSlipDetail = "";
            string updateBookState = "";

            foreach (Book book in borrowSlip.chosenBooks)
            {
                insertSlipDetail = insertSlipDetail + $@"INSERT INTO CTPHIEUMUON(MaPhieuMuonSach, MaCuonSach, TinhTrangPM) VALUES('{borrowSlip.slipCode}','{book.specCode}', 0)" + "\n";
                updateBookState = updateBookState + $@"UPDATE CUONSACH SET TinhTrang = 1 WHERE MaCuonSach = '{book.specCode}'" + "\n";
            }

            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(createBorrowSlipCmd, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = insertSlipDetail;
            cmd.ExecuteNonQuery();
            cmd.CommandText = updateBookState;
            cmd.ExecuteNonQuery();
            conn.Close();

            muonSach.lendState = "Success";
            this.Close();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            muonSach.lendState = "Cancelled";
            this.Close();
        }
    }
}
