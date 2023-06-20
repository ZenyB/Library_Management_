using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class DSPhieuTS : Form
    {
        string chuoiKetNoi = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection myConnection; // kết nối tới csdl
        private SqlDataAdapter myDataAdapter;   // Vận chuyển csdl qa DataSet
        private DataTable myTable;  // Dùng để lưu bảng lấy từ c#
        SqlCommand myCommand;

        List<ReturnSlip> returnSlips;
        BindingSource binding;
        bool isLocked = true;
        public static string slipCode = "";


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
        public DSPhieuTS()
        {
            InitializeComponent();
        }

        private void Load_DS()
        {
            //string query = @"SELECT PHIEUTRASACH.MAPHIEUTRASACH AS [Mã Phiếu Trả Sách], DOCGIA.MADOCGIA AS [Mã Độc Giả], HOTEN AS [Tên Độc Giả], NGMUON AS [Ngày Mượn], SONGAYMUON AS [Số Ngày Mượn], TIENPHAT AS [Tiền Phạt]
            //        FROM PHIEUTRASACH, CTPT, DOCGIA, PHIEUMUON
            //        WHERE PHIEUTRASACH.MAPHIEUTRASACH = CTPT.MAPHIEUTRASACH AND CTPT.MAPHIEUMUONSACH = PHIEUMUON.MAPHIEUMUONSACH AND DOCGIA.MADOCGIA = PHIEUTRASACH.MADOCGIA";

            //DS_chitietPNS.DataSource = connect(query);
            //DS_chitietPNS.AutoGenerateColumns = false;
            //myConnection.Close();

            returnSlips.Clear();
            string queryCmd = @"SELECT MaPhieuTraSach, PHIEUTRASACH.MaDocGia, HoTen, NgTra, TienPhatKyNay
                FROM PHIEUTRASACH, DOCGIA
                WHERE PHIEUTRASACH.MaDocGia = DOCGIA.MaDocGia";
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ReturnSlip slip = new ReturnSlip();
                    slip.recvSlipCode = reader.GetString(0);
                    slip.readerCode = reader.GetString(1);
                    slip.readerName = reader.GetString(2);
                    slip.returnDate = reader.GetDateTime(3).ToString("dd/MM/yyyy");

                    returnSlips.Add(slip);
                }
            }
            conn.Close();

            returnSlips.OrderBy(o => o.recvSlipCode).ThenBy(o => o.readerCode).ThenBy(o => o.readerName).ToList();
            int stt = 1;
            foreach (ReturnSlip slip in returnSlips)
            {
                slip.stt = stt;
                stt++;
            }

            binding = new BindingSource();
            binding.DataSource = returnSlips;
            DS_chitietPNS.DataSource = binding;

            if (DS_chitietPNS.Rows.Count != 0)
            {
                DS_chitietPNS.Rows[0].Selected = false;
            }
        }

        private void DSPhieuTS_Load(object sender, EventArgs e)
        {
            returnSlips = new List<ReturnSlip>();
            binding = new BindingSource();
            Load_DS();
            formmat();
        }

        private void DS_chitietPNS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txb_MaPTS.Text = DS_chitietPNS.CurrentRow.Cells[0].Value.ToString();
            //txb_MaDocGia.Text = DS_chitietPNS.CurrentRow.Cells[1].Value.ToString();
            //txb_TenDocGia.Text = DS_chitietPNS.CurrentRow.Cells[2].Value.ToString();
            //txb_tienPhat.Text = DS_chitietPNS.CurrentRow.Cells[5].Value.ToString();
            //string dateString = DS_chitietPNS.CurrentRow.Cells[3].ToString();
            //string format = "MM/dd/yyyy";
            //DateTime dateTime;
            //if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            //{
            //    dateTimeNgayTra.Value = dateTime;
            //}


            if (e.RowIndex != -1)
            {
                txb_MaPTS.Text = DS_chitietPNS.Rows[e.RowIndex].Cells[1].Value.ToString();
                slipCode = txb_MaPTS.Text;
                txb_MaDocGia.Text = DS_chitietPNS.Rows[e.RowIndex].Cells[2].Value.ToString();
                txb_TenDocGia.Text = DS_chitietPNS.Rows[e.RowIndex].Cells[3].Value.ToString();
                txb_tienPhat.Text = DS_chitietPNS.Rows[e.RowIndex].Cells[5].Value.ToString();

                string date = DS_chitietPNS.Rows[e.RowIndex].Cells[4].Value.ToString();
                DateTime returnDay = new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2)));
                dateTimeNgayTra.Value = returnDay;

                isLocked = false;
            }
        }

        private void btn_xemChiTiet_Click(object sender, EventArgs e)
        {
            new chiTietPTS().ShowDialog();
        }

        private void formmat()
        {
            DS_chitietPNS.Columns[0].HeaderText = "STT";
            DS_chitietPNS.Columns[1].HeaderText = "Mã phiếu trả";
            DS_chitietPNS.Columns[2].HeaderText = "Mã người đọc";
            DS_chitietPNS.Columns[3].HeaderText = "Tên người đọc";
            DS_chitietPNS.Columns[4].HeaderText = "Ngày trả";
            DS_chitietPNS.Columns[5].HeaderText = "Tiền phạt kỳ này";

            DS_chitietPNS.Columns[0].DataPropertyName = "stt";
            DS_chitietPNS.Columns[1].DataPropertyName = "recvSlipCode";
            DS_chitietPNS.Columns[2].DataPropertyName = "readerCode";
            DS_chitietPNS.Columns[3].DataPropertyName = "readerName";
            DS_chitietPNS.Columns[4].DataPropertyName = "returnDate";
            DS_chitietPNS.Columns[5].DataPropertyName = "fineThisPeriod";
        }

        private void dateTimeNgayTra_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
