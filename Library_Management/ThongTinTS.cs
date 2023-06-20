using Library_Management.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class ThongTinTS : Form
    {
        BindingSource bindingChosen;

        internal static ReturnSlipBook returnSlip;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
        );

        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private System.Data.DataTable table;

        private System.Data.DataTable connect(string query)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(query, connection);
            dataAdapter = new SqlDataAdapter(command);
            table = new System.Data.DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public ThongTinTS()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void ConfirmLendBook_Load(object sender, EventArgs e)
        {
            txb_MaPMS.Text = returnSlip.recvSlipCode;
            txb_MaDocGia.Text = returnSlip.readerCode;
            txb_TenDocGia.Text = returnSlip.readerName;
            txb_NgayTra.Text = FormatDate(returnSlip.returnDate);
            //lbFineThisPeriod.Text = returnSlip.fineThisPeriod.ToString();
            //lbTotalFine.Text = returnSlip.totalFine.ToString();

            bindingChosen = new BindingSource();
            bindingChosen.DataSource = returnSlip.returnBooks;
            dtgvChosenBook.DataSource = bindingChosen;

            if (dtgvChosenBook.Rows.Count != 0)
            {
                dtgvChosenBook.Rows[0].Selected = false;
            }
            format();
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
            UpdataData();
        }

        private void UpdataData()
        {
            try
            {
                string createReturnSlip = $@"INSERT INTO PHIEUTRASACH(MaDocGia, NgTra, TienPhatKyNay) VALUES('{returnSlip.readerCode}', '{returnSlip.returnDate}', {returnSlip.fineThisPeriod})";
                string createReturnSlipDetail = @"";
                string setBookAndSlipDetailStatus = @"";
                string setBookDetailStatus = @"";
                string updateTotalFine = $@"UPDATE DOCGIA SET TongNo = {returnSlip.totalFine} WHERE MaDocGia = '{returnSlip.readerCode}'";

                foreach (ReturnBook book in returnSlip.returnBooks)
                {
                    string cauTruyVan = $@"SELECT CTPHIEUMUON.MaPhieuMuonSach
                    FROM CTPHIEUMUON
                    WHERE TinhTrangPM = 0 AND MaCuonSach = '{book.specBookCode}'";
                    connect(cauTruyVan);
                    string s = Convert.ToString(command.ExecuteScalar());

                    createReturnSlipDetail += $@"INSERT INTO CTPT(MaPhieuTraSach, MaCuonSach, MaPhieuMuonSach, SoNgayMuon, TienPhat) VALUES('{returnSlip.recvSlipCode}','{book.specBookCode}','{s}','{book.borrowedDays}','{book.fine}')" + "\n";
                    setBookAndSlipDetailStatus += $@"UPDATE CTPHIEUMUON SET TinhTrangPM = 1  WHERE MaChiTietPhieuMuon = '{book.detailSlipCode}'" + "\n";
                    setBookDetailStatus += $@"UPDATE CUONSACH SET TinhTrang = 0 WHERE MaCuonSach = '{book.specBookCode}'" + "\n";
                }

                SqlConnection conn = new SqlConnection(Database.connectionStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(createReturnSlip, conn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = createReturnSlipDetail;
                cmd.ExecuteNonQuery();
                cmd.CommandText = setBookAndSlipDetailStatus;
                cmd.ExecuteNonQuery();
                cmd.CommandText = setBookDetailStatus;
                cmd.ExecuteNonQuery();
                cmd.CommandText = updateTotalFine;
                cmd.ExecuteNonQuery();

                traSach.recvState = "Success";
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            traSach.recvState = "Cancelled";
            this.Close();
        }
        private void format()
        {
            dtgvChosenBook.Columns[0].HeaderText = "STT";
            dtgvChosenBook.Columns[1].HeaderText = "Mã Sách";
            dtgvChosenBook.Columns[2].HeaderText = "Tên Sách";
            dtgvChosenBook.Columns[3].HeaderText = "Ngày mượn";
            dtgvChosenBook.Columns[4].HeaderText = "Số ngày trễ";
            dtgvChosenBook.Columns[5].HeaderText = "Tiền phạt";

            dtgvChosenBook.Columns[0].DataPropertyName = "stt";
            dtgvChosenBook.Columns[1].DataPropertyName = "bookCode";
            dtgvChosenBook.Columns[2].DataPropertyName = "bookName";
            dtgvChosenBook.Columns[3].DataPropertyName = "borrowDate";
            dtgvChosenBook.Columns[4].DataPropertyName = "borrowedDays";
            dtgvChosenBook.Columns[5].DataPropertyName = "fine";
        }
    }
}
