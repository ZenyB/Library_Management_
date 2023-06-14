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
            string query = @"SELECT PHIEUTRASACH.MAPHIEUTRASACH AS [Mã Phiếu Trả Sách], DOCGIA.MADOCGIA AS [Mã Độc Giả], HOTEN AS [Tên Độc Giả], NGMUON AS [Ngày Mượn], SONGAYMUON AS [Số Ngày Mượn], TIENPHAT AS [Tiền Phạt]
                    FROM PHIEUTRASACH, CTPT, DOCGIA, PHIEUMUON
                    WHERE PHIEUTRASACH.MAPHIEUTRASACH = CTPT.MAPHIEUTRASACH AND CTPT.MAPHIEUMUONSACH = PHIEUMUON.MAPHIEUMUONSACH AND DOCGIA.MADOCGIA = PHIEUTRASACH.MADOCGIA";

            DS_chitietPNS.DataSource = connect(query);
            DS_chitietPNS.AutoGenerateColumns = false;
            myConnection.Close();
        }

        private void DSPhieuTS_Load(object sender, EventArgs e)
        {
            Load_DS();
        }

        private void DS_chitietPNS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaPTS.Text = DS_chitietPNS.CurrentRow.Cells[0].Value.ToString();
            txb_MaDocGia.Text = DS_chitietPNS.CurrentRow.Cells[1].Value.ToString();
            txb_TenDocGia.Text = DS_chitietPNS.CurrentRow.Cells[2].Value.ToString();
            txb_tienPhat.Text = DS_chitietPNS.CurrentRow.Cells[5].Value.ToString();
            string dateString = DS_chitietPNS.CurrentRow.Cells[3].ToString();
            string format = "MM/dd/yyyy";
            DateTime dateTime;
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                dateTimeNgayTra.Value = dateTime;
            }
        }
    }
}
