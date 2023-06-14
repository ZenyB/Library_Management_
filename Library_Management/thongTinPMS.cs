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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (muonSach.askBeforePrint)
            {
                PrintSlip();
            }
            UpdataData();
        }
        Bitmap bmp;

        private void PrintSlip()
        {
            //printDocument1.DefaultPageSettings.PaperSize = new PaperSize("MyPaper", this.Size.Width + 30, 581 - 74);
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, 581 - 74, g);
            Graphics mg = Graphics.FromImage(bmp);
            Size size = new Size(this.Size.Width, 581 - 74);
            mg.CopyFromScreen(this.Location.X, this.Location.Y + 25, 0, 0, size);
            //printPreviewDialog1.ShowDialog();
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

            //DemoDesign.LendBook.lendState = "Success";
            //SendMail();
            this.Close();
        }

        private void SendMail()
        {
            string slipTitle = "<b>THÔNG TIN PHIẾU MƯỢN</b><br/><br/>";
            string readerCode = $"<b>Mã độc giả</b>: {borrowSlip.code}<br/>";
            string readerName = $"<b>Họ tên</b>: {borrowSlip.name}<br/>";
            string borrowDate = $"<b>Ngày mượn</b>: {FormatDate(borrowSlip.borrowDate)}<br/>";
            string returnDate = $"<b>Ngày trả</b>: {FormatDate(borrowSlip.returnDate)}<br/>";
            string borrowBooksTitle = $"<br/><b>SÁCH ĐÃ MƯỢN:</b><br/>";
            string borrowBooks = "";
            foreach (Book book in borrowSlip.chosenBooks)
            {
                string bookInfo = $"<b>Mã sách:</b> {book.code}&emsp;&emsp;<b>Tên sách:</b> {book.nameBook}&emsp;&emsp;<b>Tác giả:</b> {book.author}<br/>";
                borrowBooks += bookInfo;
            }

            string msg = slipTitle + readerCode + readerName + borrowDate + returnDate + borrowBooksTitle + borrowBooks;
            MailService.SendMail(borrowSlip.email, msg, borrowSlip.name);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DemoDesign.LendBook.lendState = "Cancelled";
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
