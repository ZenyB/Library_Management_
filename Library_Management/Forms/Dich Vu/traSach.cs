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
using static Library_Management.muonSach;
using System.Windows.Documents;

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

        List<ReturnSlip> returnSlips;
        List<ReturnBook> returnBooks;
        List<ReturnBook> returnView;
        List<ReturnBook> chosenBooks;
        BindingSource bindingReturn;
        BindingSource bindingChosen;

        List<int> selectedIndex = new List<int>();

        public static string recvState = "";
        public static bool needPrint = true;

        Thread tdGetNewSlipCode;

        string newReturnSlipCode = "";
        long fineThisPeriod = 0;
        long totalFine = 0;

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
            returnSlips = new List<ReturnSlip>();
            returnBooks = new List<ReturnBook>();
            returnView = new List<ReturnBook>();
            chosenBooks = new List<ReturnBook>();
            bindingReturn = new BindingSource();
            bindingChosen = new BindingSource();
            selectedIndex = new List<int>();
            cbbReader.SelectedIndex = -1;

            returnDate.Value = DateTime.Now;

            GetNewReturnSlipCode();
            LoadBorrowSlip();
            DS_Layout();
        }

        private void DS_Layout()
        {
            DS_SlipBook.Columns[0].HeaderText = "STT";
            DS_SlipBook.Columns[1].HeaderText = "Mã Sách";
            DS_SlipBook.Columns[2].HeaderText = "Tên Sách";
            DS_SlipBook.Columns[3].HeaderText = "Ngày mượn";
            DS_SlipBook.Columns[4].HeaderText = "Số ngày trễ";
            DS_SlipBook.Columns[5].HeaderText = "Tiền phạt";

            DS_SlipBook.Columns[0].DataPropertyName = "stt";
            DS_SlipBook.Columns[1].DataPropertyName = "bookCode";
            DS_SlipBook.Columns[2].DataPropertyName = "bookName";
            DS_SlipBook.Columns[3].DataPropertyName = "borrowDate";
            DS_SlipBook.Columns[4].DataPropertyName = "borrowedDays";
            DS_SlipBook.Columns[5].DataPropertyName = "fine";

            DS_Choosen.Columns[0].HeaderText = "STT";
            DS_Choosen.Columns[1].HeaderText = "Mã Sách";
            DS_Choosen.Columns[2].HeaderText = "Tên Sách";
            DS_Choosen.Columns[3].HeaderText = "Ngày mượn";
            DS_Choosen.Columns[4].HeaderText = "Số ngày trễ";
            DS_Choosen.Columns[5].HeaderText = "Tiền phạt";

            DS_Choosen.Columns[0].DataPropertyName = "stt";
            DS_Choosen.Columns[1].DataPropertyName = "bookCode";
            DS_Choosen.Columns[2].DataPropertyName = "bookName";
            DS_Choosen.Columns[3].DataPropertyName = "borrowDate";
            DS_Choosen.Columns[4].DataPropertyName = "borrowedDays";
            DS_Choosen.Columns[5].DataPropertyName = "fine";
        }

        private void LoadBorrowSlip()
        {
            returnSlips.Clear();
            returnBooks.Clear();

            Parameters.LoadParam();
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();

            string borrowSlipQuery = @"SELECT DISTINCT PHIEUMUON.MaPhieuMuonSach, PHIEUMUON.MaDocGia, HoTen, HanTra, TongNo, Email
                FROM PHIEUMUON, CTPHIEUMUON, DOCGIA
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
                        AND TinhTrangPM = 0";
            SqlCommand cmd = new SqlCommand(borrowSlipQuery, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime dt = reader.GetDateTime(3);
                    string returnDate = dt.ToString("dd/MM/yyyy");
                    ReturnSlip slip = new ReturnSlip(reader.GetString(0), reader.GetString(1), reader.GetString(2), returnDate, ((long)reader.GetSqlMoney(4).Value).ToString());
                    slip.lateReturnDays = DateTime.Now.Subtract(dt).Days;
                    slip.fineThisPeriod = CalFineThisPeriod(slip.lateReturnDays);

                    returnSlips.Add(slip);
                }
            }

            //myCommand.CommandText = "select ThoiHanThe,TuoiToiThieu,TuoiToiDa,ThoiGianLuuHanh,SoNgayMuonMax,SoSachMuonMax,format(MucThuTienPhat,'#.') from ThamSo ";
            //myDataAdapter.SelectCommand = myCommand;
            //myTable.Clear();
            //myDataAdapter.Fill(myTable);
            //string s = myTable.Rows[0].ItemArray[4].ToString();
            //int index = Int32.Parse(s);

            string borrowedBooksQuery = @"SELECT CTPHIEUMUON.MaPhieuMuonSach, SACH.MaSach, TenDauSach, NgMuon, CTPHIEUMUON.MaCuonSach, MaChiTietPhieuMuon
            FROM SACH, CUONSACH, PHIEUMUON, CTPHIEUMUON, DAUSACH, DOCGIA
            WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
		            AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach 
						AND TinhTrangPM = 0 AND DOCGIA.MaDocGia = PHIEUMUON.MaDocGia
						AND DOCGIA.MaDocGia = '" + this.cbbReader.GetItemText(this.cbbReader.SelectedItem) + "'";
            cmd.CommandText = borrowedBooksQuery;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ReturnBook returnBook = new ReturnBook();
                    returnBook.borrowSlipCode = reader.GetString(0);
                    returnBook.bookCode = reader.GetString(1);
                    returnBook.bookName = reader.GetString(2);
                    DateTime dt = reader.GetDateTime(3);
                    returnBook.borrowDate = dt.ToString("dd/MM/yyyy");
                    returnBook.borrowedDays = Math.Abs(dt.Subtract(DateTime.Now).Days + 1).ToString();
                    returnBook.specBookCode = reader.GetString(4);
                    returnBook.detailSlipCode = reader.GetString(5);
                    if (int.Parse(returnBook.borrowedDays) > Parameters.maxLendDay)
                    {
                        int lateReturnDays = int.Parse(returnBook.borrowedDays) - Parameters.maxLendDay + 1;
                        returnBook.lateReturnDays = lateReturnDays;
                        returnBook.fine = CalFineThisPeriod(lateReturnDays);
                    }
                    returnBooks.Add(returnBook);
                }
            }

            conn.Close();
        }

        string readerCode = "";
        string readerName = "";


        private void UpdateData()
        {
            int stt = 1;
            returnView.Clear();
            foreach (ReturnBook returnBook in returnBooks)
            {
                //if (returnBook.borrowSlipCode == cbbSlipCode.Text)
                {
                    ReturnBook data = new ReturnBook(returnBook);
                    data.specBookCode = returnBook.specBookCode;
                    data.detailSlipCode = returnBook.detailSlipCode;
                    data.lateReturnDays = returnBook.lateReturnDays;
                    returnView.Add(data);
                }
            }
            returnView = returnView.OrderBy(o => o.bookCode).ThenBy(o => o.bookName).ToList();

            foreach (ReturnBook book in returnView)
            {
                book.stt = stt;
                stt++;
            }

            bindingReturn = new BindingSource();
            bindingReturn.DataSource = returnView;
            DS_SlipBook.DataSource = bindingReturn;

            bindingChosen = new BindingSource();
            bindingChosen.DataSource = chosenBooks;
            DS_Choosen.DataSource = bindingChosen;

            if (DS_SlipBook.Rows.Count != 0)
            {
                DS_SlipBook.Rows[0].Selected = false;
            }

        }

        void loadTongNo()
        {
            string cauTruyVan = "SELECT TongNo FROM DOCGIA WHERE MaDocGia = '" + cbbReader.Text + "'";
            connect(cauTruyVan);
            string tongNo = Convert.ToString(myCommand.ExecuteScalar());
            txtTongNo.Text = tongNo;
        }

        private void GetNewReturnSlipCode()
        {
            string query = @"SELECT MaDocGia
            FROM DOCGIA";

            cbbReader.DataSource = connect(query);
            cbbReader.DisplayMember = "MaDocGia";
            cbbReader.SelectedIndex = -1;

            string currCode = "";
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Database.getNewReturnSlipCode, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    currCode = reader.GetString(0);
                }
            }
            int stt = int.Parse(currCode.Substring(4, 3)) + 1;
            newReturnSlipCode = $"MPTS{stt:000}";
        }

        private long CalFineThisPeriod(int lateReturnDays)
        {
            long fine = Parameters.finePerDay * lateReturnDays;
            return fine;
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
            try
            {
                ReturnBook returnBook = new ReturnBook();
                returnBook.bookCode = DS_SlipBook.SelectedRows[0].Cells[1].Value.ToString();
                returnBook.bookName = DS_SlipBook.SelectedRows[0].Cells[2].Value.ToString();
                returnBook.borrowDate = DS_SlipBook.SelectedRows[0].Cells[3].Value.ToString();
                returnBook.borrowedDays = DS_SlipBook.SelectedRows[0].Cells[4].Value.ToString();
                returnBook.fine = long.Parse(DS_SlipBook.SelectedRows[0].Cells[5].Value.ToString());
                returnBook.specBookCode = returnView[DS_SlipBook.SelectedRows[0].Index].specBookCode;
                returnBook.detailSlipCode = returnView[DS_SlipBook.SelectedRows[0].Index].detailSlipCode;
                returnBook.lateReturnDays = returnView[DS_SlipBook.SelectedRows[0].Index].lateReturnDays;

                chosenBooks.Add(returnBook);
                returnView.RemoveAt(DS_SlipBook.SelectedRows[0].Index);

                chosenBooks = chosenBooks.OrderBy(o => o.bookCode).ThenBy(o => o.bookName).ToList();
                returnView = returnView.OrderBy(o => o.bookCode).ThenBy(o => o.bookName).ToList();

                int stt = 1;
                int totalLateReturnDays = 0;
                foreach (ReturnBook book in chosenBooks)
                {
                    totalLateReturnDays += book.lateReturnDays;
                    book.stt = stt;
                    stt++;
                }

                txb_TongTraTre.Text = totalLateReturnDays.ToString();

                stt = 1;
                foreach (ReturnBook book in returnView)
                {
                    book.stt = stt;
                    stt++;
                }

                bindingReturn = new BindingSource();
                bindingReturn.DataSource = returnView;
                DS_SlipBook.DataSource = bindingReturn;

                bindingChosen = new BindingSource();
                bindingChosen.DataSource = chosenBooks;
                DS_Choosen.DataSource = bindingChosen;

                if (DS_SlipBook.Rows.Count != 0)
                {
                    DS_SlipBook.Rows[0].Selected = false;
                }
                foreach (DataGridViewRow row in DS_Choosen.Rows)
                {
                    if (row.Cells[1].Value.ToString() == returnBook.bookCode)
                    {
                        DS_Choosen.Rows[row.Index].Selected = true;
                        break;
                    }
                }

                fineThisPeriod += returnBook.fine;
                txtTien.Text = fineThisPeriod.ToString();
                txtTongNo.Text = (totalFine + fineThisPeriod).ToString();
            }
            catch
            {
                MessageBox.Show($"Vui lòng chọn 1 quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
      //      string query = @"SELECT MaChiTietPhieuMuon, SACH.MaSach, TenDauSach, NgMuon, CTPHIEUMUON.MaCuonSach
      //          FROM SACH, CUONSACH, PHIEUMUON, CTPHIEUMUON, DAUSACH
      //          WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
		    //        AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach 
						//AND SACH.MaSach = '" + choosen + "'";

            try
            {
                ReturnBook returnBook = new ReturnBook();
                returnBook.bookCode = DS_Choosen.SelectedRows[0].Cells[1].Value.ToString();
                returnBook.bookName = DS_Choosen.SelectedRows[0].Cells[2].Value.ToString();
                returnBook.borrowDate = DS_Choosen.SelectedRows[0].Cells[3].Value.ToString();
                returnBook.borrowedDays = DS_Choosen.SelectedRows[0].Cells[4].Value.ToString();
                returnBook.fine = long.Parse(DS_Choosen.SelectedRows[0].Cells[5].Value.ToString());
                returnBook.specBookCode = chosenBooks[DS_Choosen.SelectedRows[0].Index].specBookCode;
                returnBook.detailSlipCode = chosenBooks[DS_Choosen.SelectedRows[0].Index].detailSlipCode;
                returnBook.lateReturnDays = returnView[DS_Choosen.SelectedRows[0].Index].lateReturnDays;

                returnView.Add(returnBook);
                chosenBooks.RemoveAt(DS_Choosen.SelectedRows[0].Index);

                chosenBooks = chosenBooks.OrderBy(o => o.bookCode).ThenBy(o => o.bookName).ToList();
                returnView = returnView.OrderBy(o => o.bookCode).ThenBy(o => o.bookName).ToList();

                int stt = 1;
                int totalLateReturnDays = 0;
                foreach (ReturnBook book in chosenBooks)
                {
                    book.stt = stt;
                    totalLateReturnDays += book.lateReturnDays;
                    stt++;
                }

                txb_TongTraTre.Text = totalLateReturnDays.ToString();

                stt = 1;
                foreach (ReturnBook book in returnView)
                {
                    book.stt = stt;
                    stt++;
                }

                bindingReturn = new BindingSource();
                bindingReturn.DataSource = returnView;
                DS_SlipBook.DataSource = bindingReturn;

                bindingChosen = new BindingSource();
                bindingChosen.DataSource = chosenBooks;
                DS_Choosen.DataSource = bindingChosen;

                if (DS_Choosen.Rows.Count != 0)
                {
                    DS_Choosen.Rows[0].Selected = false;
                }
                foreach (DataGridViewRow row in DS_SlipBook.Rows)
                {
                    if (row.Cells[1].Value.ToString() == returnBook.bookCode)
                    {
                        DS_SlipBook.Rows[row.Index].Selected = true;
                        break;
                    }
                }

                fineThisPeriod -= returnBook.fine;
                txtTien.Text = fineThisPeriod.ToString();
                txtTongNo.Text = (totalFine + fineThisPeriod).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
                //MessageBox.Show($"Vui lòng chọn 1 quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbReader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbReader.SelectedIndex == -1)
            {
                txtTongNo.Text = "0";
                txtTien.Text = "0";
                txb_TenDocGia.Text = "";
            }
            else
            {
                LoadBorrowSlip();
                UpdateData();

                string cauTruyVan = "SELECT TongNo FROM DOCGIA WHERE MaDocGia = '" + cbbReader.Text + "'";
                connect(cauTruyVan);
                string tongNo = Convert.ToString(myCommand.ExecuteScalar());
                txtTongNo.Text = tongNo;

                cauTruyVan = "SELECT HotEN FROM DOCGIA WHERE MaDocGia = '" + cbbReader.Text + "'";
                connect(cauTruyVan);
                string hoTen = Convert.ToString(myCommand.ExecuteScalar());
                txb_TenDocGia.Text = hoTen;
            }
        }

        public enum Valid
        {
            MissingInfo,
            MissingBook,
            Success
        }

        private Valid isValid()
        {
            if (cbbReader.SelectedIndex == -1)
            {
                return Valid.MissingInfo;
            }
            else if (DS_Choosen.Rows.Count == 0)
            {
                return Valid.MissingBook;
            }
            return Valid.Success;
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            switch (isValid())
            {
                case Valid.MissingInfo:
                    {
                        MessageBox.Show($"Vui lòng nhập mã phiếu mượn sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case Valid.MissingBook:
                    {
                        MessageBox.Show($"Vui lòng chọn 1 quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case Valid.Success:
                    {
                        ShowConfirmForm();
                        break;
                    }
            }
        }

        private void ShowConfirmForm()
        {
            ThongTinTS.returnSlip = new ReturnSlipBook(cbbReader.Text, txb_TenDocGia.Text, returnDate.Value.ToString("yyyy-MM-dd"), txtTongNo.Text, txtTien.Text, chosenBooks);
            ThongTinTS.returnSlip.recvSlipCode = newReturnSlipCode;
            ThongTinTS.returnSlip.email = "";

            new ThongTinTS().ShowDialog();
            if (recvState == "Success")
            {
                MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Library_Management.Home.SwitchForm(new traSach());
                chosenBooks.Clear();

                //btnReturn.Enabled = false;

                recvState = "";
                GetNewReturnSlipCode();

                //btnCan.Enabled = false;
                txb_TenDocGia.Text = "";
                cbbReader.Text = "";
                LoadBorrowSlip();

                bindingReturn = new BindingSource();
                bindingReturn.DataSource = returnView;
                DS_SlipBook.DataSource = bindingReturn;

                bindingChosen = new BindingSource();
                bindingChosen.DataSource = chosenBooks;
                DS_Choosen.DataSource = bindingChosen;
            }
        }

        private void CreateReturnSlip()
        {
            string createReturnSlip = $@"INSERT INTO PHIEUTRASACH(MaDocGia, NgTra, TienPhatKyNay) VALUES('{cbbReader.Text}', '{returnDate.Value.ToString("yyyy-MM-dd")}', {txtTien.Text})";
            string createReturnSlipDetail = @"";
            string setBookAndSlipDetailStatus = @"";

            foreach (ReturnBook book in chosenBooks)
            {
                string cauTruyVan = @"SELECT CTPHIEUMUON.MaPhieuMuonSach
                FROM SACH, CUONSACH, PHIEUMUON, CTPHIEUMUON, DAUSACH
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
		            AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach 
						AND TinhTrangPM = 0'";
                connect(cauTruyVan);
                string maPhieuMuon = Convert.ToString(myCommand.ExecuteScalar());

                createReturnSlipDetail += $@"INSERT INTO CTPT(MaPhieuTraSach, MaCuonSach, MaPhieuMuonSach, SoNgayMuon, TienPhat) VALUES('{newReturnSlipCode}','{book.specBookCode}','{maPhieuMuon}','{book.borrowedDays}','{book.fine}')" + "\n";
                setBookAndSlipDetailStatus += $@"UPDATE CTPHIEUMUON SET TinhTrangPM = 1  WHERE MaChiTietPhieuMuon = '{book.detailSlipCode}'" + "\n" + $@"UPDATE CUONSACH SET TinhTrang = 1 WHERE MaCuonSach = '{book.specBookCode}'";
            }

            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(createReturnSlip, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = createReturnSlipDetail;
            cmd.ExecuteNonQuery();
            cmd.CommandText = setBookAndSlipDetailStatus;
            cmd.ExecuteNonQuery();

        }

        private void returnDate_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
