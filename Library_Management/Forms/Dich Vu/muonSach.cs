using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class muonSach : Form
    {

        List<Book> stockBooks;
        List<Book> findBooks;
        List<Book> chosenBooks;
        List<Reader> readers;
        string connectionStr = Database.connectionStr;
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;


        string slipCode = "";
        string readerName = "";
        bool lockReaderName = true;
        public static string lendState = "";
        public static bool askBeforePrint = true;

        Thread tdGetBookSlip;
        int numborrowedBooks = -1;

        BindingSource bindingStock;
        BindingSource bindingChosen;
        enum BtnOption
        {
            ChooseBook,
            UnchooseBook
        }
        public muonSach()
        {
            InitializeComponent();
        }

        private void LendBook_Load(object sender, EventArgs e)
        {
            Parameters.LoadParam();

            dtp_NgayTra.Value = dtp_NgayMuon.Value.AddDays(Parameters.maxLendDay);
            tbx_SoSachMax.Text = $"{Parameters.maxBorrowBook}";
            LoadData();
        }

        private void LoadData()
        {
            stockBooks = new List<Book>();
            findBooks = new List<Book>();
            chosenBooks = new List<Book>();
            readers = new List<Reader>();

            bindingStock = new BindingSource();

            txb_SoLuong.Text = $"Số lượng: {chosenBooks.Count}";
            //LoadReaders();
            LoadStockBooks();
            GetSlipCode();
            //UpdateComboBoxReaders();
            loadMaDocGia();
            cb_MaDG.SelectedIndex = -1;
            txb_TenDocGia.Text = "";
            DS_SachTrongKho.Columns[0].HeaderText = "STT";
            DS_SachTrongKho.Columns[1].HeaderText = "Mã Sách";
            DS_SachTrongKho.Columns[2].HeaderText = "Tên Sách";
            DS_SachTrongKho.Columns[3].HeaderText = "Thể Loại";
            DS_SachTrongKho.Columns[4].HeaderText = "Tác giả";
            DS_SachTrongKho.Columns[0].Width = 50;
            DS_SachTrongKho.Columns[1].Width = 100;
            DS_SachTrongKho.Columns[2].Width = 120;
            DS_SachTrongKho.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DS_SachTrongKho.Columns[4].Width = 200;
            //AddControlEvent();
        }

        private void UpdateComboBoxReaders()
        {
            foreach (Reader reader in readers)
            {
                cb_MaDG.Items.Add(reader.code);
            }
        }

        private void GetSlipCode()
        {
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Database.getBookSlipCode, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    slipCode = reader.GetString(0);
                }
            }
            conn.Close();
            int stt = int.Parse(slipCode.Substring(4, 3)) + 1;
            slipCode = $"MPMS{stt:000}";
        }

        private void LoadReaders()
        {
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Database.validReadersQueryCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    readers.Add(new Reader(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3)));
                }
            }
            conn.Close();
        }

        private DataTable ket_noi_co_du_lieu(string truy_van)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(truy_van, connection);
            dataAdapter = new SqlDataAdapter(command);
            table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        private void loadMaDocGia()
        {
            string truy_van = "SELECT MaDocGia, HoTen FROM DOCGIA";
            //cb_MaDG.DataSource = ket_noi_co_du_lieu(truy_van);
            cb_MaDG.ValueMember = "HoTen";
            cb_MaDG.DisplayMember = "MaDocGia";
            cb_MaDG.SelectedIndex = -1;
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(truy_van,connection);
            dataAdapter = new SqlDataAdapter(command);
            table = new DataTable();
            dataAdapter.Fill(table);
            cb_MaDG.DataSource = table;
        }

        void LoadStockBooks()
        {
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Database.bookInStockQueryCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int stt = 1;
                while (reader.Read())
                {
                    stockBooks.Add(new Book(stt, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                    stt++;
                }
            }
            conn.Close();

            stockBooks = stockBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();
            bindingStock.DataSource = stockBooks;
            DS_SachTrongKho.DataSource = bindingStock;

            if (DS_SachTrongKho.Rows.Count != 0)
            {
                DS_SachTrongKho.Rows[0].Selected = false;
            }
        }

        private void borrowDate_ValueChanged(object sender, EventArgs e)
        {
            Parameters.LoadParam();
            dtp_NgayTra.Value = dtp_NgayMuon.Value.AddDays(Parameters.maxLendDay);
        }

        private void btnChooseBook_Click(object sender, EventArgs e)
        {
            if (cb_MaDG.SelectedIndex == -1)
            {
                MessageBox.Show($"Vui lòng nhập mã độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //try
                {
                    Parameters.LoadParam();
                    LoadNumBorrowBooks();

                    if ((chosenBooks.Count + numborrowedBooks + 1 > Parameters.maxBorrowBook) && (chb_MaxMuon.CheckState == CheckState.Checked))
                    {
                        MessageBox.Show($"Không được mượn quá {Parameters.maxBorrowBook} quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (CheckBorrowed())
                    {
                        MessageBox.Show($"Độc giả đã mượn quyển sách này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (tbx_TimSach.Text.Length == 0)
                        {
                            SelectFromNormalView();
                        }
                        else
                        {
                            SelectFromFindingView();
                        }
                    }
                }
            }
        }

        private bool CheckBorrowed()
        {
            string bookCode;
            bookCode = DS_SachTrongKho.SelectedRows[0].Cells[1].Value.ToString();

            string queryCmd = $@"SELECT *
                FROM PHIEUMUON, CTPHIEUMUON, CUONSACH
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND TinhTrangPM = 0 
		                AND MaDocGia = '{cb_MaDG.Text}' AND CUONSACH.MaSach = '{bookCode}' AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach";
            bool found = false;
            Parameters.LoadParam();
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    found = true;
                }
            }
            conn.Close();

            return found;
        }

        private void LoadNumBorrowBooks()
        {
            Parameters.LoadParam();
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Database.GetNumOfBooksBorrowed(cb_MaDG.Text), conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    numborrowedBooks = reader.GetInt32(0);
                }
            }
            conn.Close();
        }

        private void SelectFromFindingView()
        {
            try
            {
                int stt = 1;
                Book bookChosen = new Book();

                bookChosen.numerical = chosenBooks.Count + 1;
                bookChosen.code = DS_SachTrongKho.SelectedRows[0].Cells[1].Value.ToString();
                bookChosen.nameBook = DS_SachTrongKho.SelectedRows[0].Cells[2].Value.ToString();
                bookChosen.category = DS_SachTrongKho.SelectedRows[0].Cells[3].Value.ToString();
                bookChosen.author = DS_SachTrongKho.SelectedRows[0].Cells[4].Value.ToString();
                bookChosen.specCode = findBooks[DS_SachTrongKho.SelectedRows[0].Index].specCode;

                chosenBooks.Add(bookChosen);

                int index = 0;
                foreach (Book book in stockBooks)
                {
                    if (bookChosen.code == book.code)
                    {
                        break;
                    }
                    index++;
                }
                stockBooks.RemoveAt(index);
                findBooks.RemoveAt(DS_SachTrongKho.SelectedRows[0].Index);

                findBooks = findBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();
                chosenBooks = chosenBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();

                foreach (Book book in findBooks)
                {
                    book.numerical = stt;
                    stt++;
                }

                stt = 1;
                foreach (Book book in chosenBooks)
                {
                    book.numerical = stt;
                    stt++;
                }

                stt = 1;
                foreach (Book book in stockBooks)
                {
                    book.numerical = stt;
                    stt++;
                }

                bindingStock = new BindingSource();
                bindingStock.DataSource = findBooks;
                DS_SachTrongKho.DataSource = bindingStock;

                bindingChosen = new BindingSource();
                bindingChosen.DataSource = chosenBooks;
                DS_SachDaMuon.DataSource = bindingChosen;
                //dtgvBookChosen.Update();
                //dtgvBookChosen.Refresh();

                tbx_SoSachMax.Text = $"Số lượng: {chosenBooks.Count}";

                if (DS_SachTrongKho.Rows.Count != 0)
                {
                    DS_SachTrongKho.Rows[0].Selected = false;
                }

                foreach (DataGridViewRow row in DS_SachDaMuon.Rows)
                {
                    if (row != null && row.Cells[1].Value.ToString() == bookChosen.code)
                    {
                        DS_SachDaMuon.Rows[row.Index].Selected = true;
                        DS_SachDaMuon.Columns[0].HeaderText = "STT";
                        DS_SachDaMuon.Columns[1].HeaderText = "Mã Sách";
                        DS_SachDaMuon.Columns[2].HeaderText = "Tên Sách";
                        DS_SachDaMuon.Columns[3].HeaderText = "Thể Loại";
                        DS_SachDaMuon.Columns[4].HeaderText = "Tác giả";
                        DS_SachDaMuon.AutoGenerateColumns = false;
                        DS_SachDaMuon.Columns[0].Width = 50;
                        DS_SachDaMuon.Columns[1].Width = 100;
                        DS_SachDaMuon.Columns[2].Width = 120;
                        DS_SachDaMuon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        DS_SachDaMuon.Columns[4].Width = 200;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show($"Vui lòng chọn 1 quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SelectFromNormalView()
        {
            try
            {
                Book bookChosen = new Book();

                bookChosen.numerical = chosenBooks.Count + 1;
                bookChosen.code = DS_SachTrongKho.SelectedRows[0].Cells[1].Value.ToString();
                bookChosen.nameBook = DS_SachTrongKho.SelectedRows[0].Cells[2].Value.ToString();
                bookChosen.category = DS_SachTrongKho.SelectedRows[0].Cells[3].Value.ToString();
                bookChosen.author = DS_SachTrongKho.SelectedRows[0].Cells[4].Value.ToString();
                bookChosen.specCode = stockBooks[DS_SachTrongKho.SelectedRows[0].Index].specCode;

                chosenBooks.Add(bookChosen);

                UpdateData(BtnOption.ChooseBook);
                if (DS_SachTrongKho.Rows.Count != 0)
                {
                    DS_SachTrongKho.Rows[0].Selected = false;
                }

                foreach (DataGridViewRow row in DS_SachDaMuon.Rows)
                {
                    if (row != null && row.Cells[1].Value.ToString() == bookChosen.code)
                    {
                        DS_SachDaMuon.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show($"Vui lòng chọn 1 quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnUnchooseBook_Click(object sender, EventArgs e)
        {
            if (tbx_TimSach.Text == "")
            {
                DeselectFromNormalView();
            }
            else
            {
                DeselectFromFindingView();
            }
        }

        private void DeselectFromFindingView()
        {
            try
            {
                int stt = 1;
                Book bookUnchosen = new Book();

                bookUnchosen.numerical = stockBooks.Count + 1;
                bookUnchosen.code = DS_SachDaMuon.SelectedRows[0].Cells[1].Value.ToString();
                bookUnchosen.nameBook = DS_SachDaMuon.SelectedRows[0].Cells[2].Value.ToString();
                bookUnchosen.category = DS_SachDaMuon.SelectedRows[0].Cells[3].Value.ToString();
                bookUnchosen.author = DS_SachDaMuon.SelectedRows[0].Cells[4].Value.ToString();
                bookUnchosen.specCode = chosenBooks[DS_SachDaMuon.SelectedRows[0].Index].specCode;

                findBooks.Add(bookUnchosen);
                stockBooks.Add(bookUnchosen);
                chosenBooks.RemoveAt(DS_SachDaMuon.SelectedRows[0].Index);

                findBooks = findBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();
                chosenBooks = chosenBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();

                foreach (Book book in findBooks)
                {
                    book.numerical = stt;
                    stt++;
                }

                stt = 1;
                foreach (Book book in chosenBooks)
                {
                    book.numerical = stt;
                    stt++;
                }

                stt = 1;
                foreach (Book book in stockBooks)
                {
                    book.numerical = stt;
                    stt++;
                }

                bindingStock = new BindingSource();
                bindingStock.DataSource = findBooks;
                DS_SachTrongKho.DataSource = bindingStock;

                bindingChosen = new BindingSource();
                bindingChosen.DataSource = chosenBooks;
                DS_SachDaMuon.DataSource = bindingChosen;
                //dtgvBookChosen.Update();
                //dtgvBookChosen.Refresh();

                txb_SoLuong.Text = $"Số lượng: {chosenBooks.Count}";
                if (DS_SachDaMuon.Rows.Count != 0)
                {
                    DS_SachDaMuon.Rows[0].Selected = false;
                }
                foreach (DataGridViewRow row in DS_SachDaMuon.Rows)
                {
                    if (row.Cells[1].Value.ToString() == bookUnchosen.code)
                    {
                        DS_SachTrongKho.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show($"Vui lòng chọn 1 quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeselectFromNormalView()
        {
            try
            {
                Book bookUnchosen = new Book();

                bookUnchosen.numerical = stockBooks.Count + 1;
                bookUnchosen.code = DS_SachDaMuon.SelectedRows[0].Cells[1].Value.ToString();
                bookUnchosen.nameBook = DS_SachDaMuon.SelectedRows[0].Cells[2].Value.ToString();
                bookUnchosen.category = DS_SachDaMuon.SelectedRows[0].Cells[3].Value.ToString();
                bookUnchosen.author = DS_SachDaMuon.SelectedRows[0].Cells[4].Value.ToString();
                bookUnchosen.specCode = chosenBooks[DS_SachDaMuon.SelectedRows[0].Index].specCode;

                stockBooks.Add(bookUnchosen);

                UpdateData(BtnOption.UnchooseBook);
                if (DS_SachDaMuon.Rows.Count != 0)
                {
                    DS_SachDaMuon.Rows[0].Selected = false;
                }
                foreach (DataGridViewRow row in DS_SachTrongKho.Rows)
                {
                    if (row.Cells[1].Value.ToString() == bookUnchosen.code)
                    {
                        DS_SachTrongKho.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show($"Vui lòng chọn 1 quyển sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateData(BtnOption btnOption)
        {
            int stt = 1;
            if (btnOption == BtnOption.ChooseBook)
            {
                stockBooks.RemoveAt(DS_SachTrongKho.SelectedRows[0].Index);
            }
            else
            {
                chosenBooks.RemoveAt(DS_SachDaMuon.SelectedRows[0].Index);
            }

            stockBooks = stockBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();
            chosenBooks = chosenBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();

            foreach (Book book in stockBooks)
            {
                book.numerical = stt;
                stt++;
            }
            stt = 1;
            foreach (Book book in chosenBooks)
            {
                book.numerical = stt;
                stt++;
            }

            bindingStock = new BindingSource();
            bindingStock.DataSource = stockBooks;
            DS_SachTrongKho.DataSource = bindingStock;

            bindingChosen = new BindingSource();
            bindingChosen.DataSource = chosenBooks;
            DS_SachDaMuon.DataSource = bindingChosen;
            //dtgvBookChosen.Update();
            //dtgvBookChosen.Refresh();

            txb_SoLuong.Text = $"Số lượng: {chosenBooks.Count}";
        }

        private void cb_MaDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MaDG.SelectedIndex >= 0)
            {
                lockReaderName = false;
                string truy_van = "SELECT HoTen FROM DOCGIA WHERE MaDocGia = '" + cb_MaDG.Text + "'";
                ket_noi_co_du_lieu(truy_van);
                txb_TenDocGia.Text = Convert.ToString(command.ExecuteScalar());
                lockReaderName = true;
            }

        }

        private void txb_TenDocGia_MouseDown(object sender, MouseEventArgs e)
        {
            readerName = txb_TenDocGia.Text.ToString();
        }

        private void dtpNgayTra_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void txb_TenDocGia_TextChanged(object sender, EventArgs e)
        {
            if (lockReaderName)
            {
                txb_TenDocGia.Text = readerName;
            }
        }

        private void cb_MaDG_TextChanged(object sender, EventArgs e)
        {
            if (cb_MaDG.Text != "" && cb_MaDG.SelectedIndex != -1)
            {
                txb_TenDocGia.Text = cb_MaDG.SelectedValue.ToString();
                
            }
        }
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        private void tbx_TimSach_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text.Length == 0)
            {
                bindingStock = new BindingSource();
                bindingStock.DataSource = stockBooks;
                DS_SachTrongKho.DataSource = bindingStock;
            }
            else
            {
                String findText = txb.Text;
                String code, name, category, author;
                findText = RemoveUnicode(findText.ToLower());


                findBooks.Clear();
                int stt = 1;
                bool found = false;
                foreach (Book book in stockBooks)
                {
                    found = false;

                    code = RemoveUnicode(book.code.ToLower());
                    name = RemoveUnicode(book.nameBook.ToLower());
                    category = RemoveUnicode(book.category.ToLower());
                    author = RemoveUnicode(book.author.ToLower());

                    if (code.Contains(findText) || name.Contains(findText) || category.Contains(findText) || author.Contains(findText))
                    {
                        found = true;
                    }
                    else if (book.code.ToLower().Contains(findText) || book.nameBook.ToLower().Contains(findText) || book.category.ToLower().Contains(findText) || book.author.ToLower().Contains(findText))
                    {
                        found = true;
                    }
                    if (found)
                    {
                        Book findBook = new Book(book);
                        findBook.numerical = stt;
                        stt++;
                        findBooks.Add(findBook);
                        findBooks = findBooks.OrderBy(o => o.code).ThenBy(o => o.nameBook).ToList();
                    }
                }

                bindingStock = new BindingSource();
                bindingStock.DataSource = findBooks;
                DS_SachTrongKho.DataSource = bindingStock;
                if (DS_SachTrongKho.Rows.Count != 0)
                {
                    DS_SachTrongKho.Rows[0].Selected = false;
                }
            }
        }

        private void labelXoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbx_TimSach.Text = "";
            tbx_TimSach.Select();
        }

        public enum Valid
        {
            Valid,
            MissingCode,
            MissingBook,
            BorrowedMax,
            LendDayPast,
            Borrowed
        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (dtp_NgayMuon.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày mượn không vượt quá hôm nay", "Thông báo lỗi");
                return;
            }
            switch (IsValid())
            {
                case Valid.Valid:
                    {
                        ShowConfirmForm();
                        break;
                    }
                case Valid.MissingCode:
                    {
                        MessageBox.Show("Vui lòng nhập mã độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case Valid.MissingBook:
                    {
                        MessageBox.Show("Vui chọn 1 quyển sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case Valid.BorrowedMax:
                    {
                        MessageBox.Show($"Không được mượn quá {Parameters.maxBorrowBook} quyển sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case Valid.Borrowed:
                    {

                        break;
                    }
            }
        }

        private Valid IsValid()
        {
            if (cb_MaDG.SelectedIndex == -1)
            {
                return Valid.MissingCode;
            }
            else if (DS_SachDaMuon.Rows.Count == 0)
            {
                return Valid.MissingBook;
            }
            else
            {
                if (chb_MaxMuon.CheckState == CheckState.Checked)
                {
                    Parameters.LoadParam();
                    SqlConnection conn = new SqlConnection(Database.connectionStr);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Database.GetNumOfBooksBorrowed(cb_MaDG.Text), conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            numborrowedBooks = reader.GetInt32(0);
                        }
                    }
                    conn.Close();

                    if (numborrowedBooks + DS_SachDaMuon.Rows.Count > Parameters.maxBorrowBook)
                    {
                        return Valid.BorrowedMax;
                    }
                }
            }

            string msg = "";
            Parameters.LoadParam();
            SqlConnection conn1 = new SqlConnection(Database.connectionStr);
            conn1.Open();
            SqlCommand cmd1;
            string queryCmd = "";
            foreach (Book book in chosenBooks)
            {
                queryCmd = $@"SELECT *
                FROM PHIEUMUON, CTPHIEUMUON, CUONSACH
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND TinhTrangPM = 0 
		                AND MaDocGia = '{cb_MaDG.Text}' AND CUONSACH.MaSach = '{book.code}' AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach";

                cmd1 = new SqlCommand(queryCmd, conn1);
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        msg += book.code + " ";
                    }
                }
            }
            conn1.Close();
            if (msg != "")
            {
                MessageBox.Show("Độc giả này đã mượn " + msg + "rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Valid.Borrowed;
            }

            return Valid.Valid;
        }

        private void ShowConfirmForm()
        {
            //tdGetBookSlip.Join();
            string code = cb_MaDG.Text.ToString();
            string name = txb_TenDocGia.Text.ToString();
            //string email = readers[cb_MaDG.SelectedIndex].email;
            string lendDate = dtp_NgayMuon.Value.ToString("yyyy-MM-dd");
            string backDate = dtp_NgayTra.Value.ToString("yyyy-MM-dd");
            string amount = chosenBooks.Count.ToString();

            thongTinPMS.borrowSlip = new BorrowSlip(slipCode, code, name, lendDate, backDate, amount, chosenBooks);
            new thongTinPMS().ShowDialog();

            if (lendState == "Success")
            {
                MessageBox.Show("Cho mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnChoMuon.Enabled = false;

                //chosenBooks.Clear();
                //bindingChosen = new BindingSource();
                //bindingChosen.DataSource = chosenBooks;
                //dtgvBookChosen.DataSource = bindingChosen;

                lendState = "";
                tdGetBookSlip = new Thread(new ThreadStart(GetSlipCode));
                tdGetBookSlip.Start();
                muonSach f2 = new muonSach();
                // show form 2
                f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
                                 // dispose form 2 instance
                f2 = null;
                //show form 1 again
                this.Show();
            }
            //String returnDay = 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowConfirmForm();
        }

        private void chbIn_CheckedChanged(object sender, EventArgs e)
        {
            askBeforePrint = (chb_InPhieuMuon.CheckState == CheckState.Checked) ? true : false;
        }

        private void chb_MaxMuon_CheckedChanged(object sender, EventArgs e)
        {
            string temp = "Số sách được mượn tối đa: ";
            if (chb_MaxMuon.CheckState == CheckState.Checked)
            {
                txb_SoLuong.Text = $"{Parameters.maxBorrowBook}";
            }
            else
            {
                txb_SoLuong.Text = "Không";
            }
        }

        //private void btnViewBorrowSlip_Click(object sender, EventArgs e)
        //{
        //    new DSPhieuMS().ShowDialog();
        //}

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtp_NgayMuon.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày mượn không vượt quá hôm nay", "Thông báo lỗi");
                return;
            }
            DSPhieuMS f2 = new DSPhieuMS();
            // show form 2
            f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            // dispose form 2 instance
            f2 = null;
            //show form 1 again
            this.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXemPhieuMuon_Click(object sender, EventArgs e)
        {
            // hide form 1
            // this.Hide();
            // create an instace of form 2
            DSPhieuMS f2 = new DSPhieuMS();
            // show form 2
            f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            // dispose form 2 instance
            f2 = null;
            //show form 1 again
            this.Show();
        }
    }
}
