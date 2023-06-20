using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management
{
    public partial class Sach : Form
    {

        string chuoiKetNoi = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection myConnection; // kết nối tới csdl
        private SqlDataAdapter myDataAdapter;   // Vận chuyển csdl qa DataSet
        private DataTable myTable;  // Dùng để lưu bảng lấy từ c#
        SqlCommand myCommand;
        private bool isUpdate = false;
        public Sach()
        {
            InitializeComponent();
        }

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

        void loadDS_Sach()
        {
            string cauTruyVan = "SELECT MaSach AS[Mã sách], DAUSACH.MaDauSach AS [Mã đầu sách], TenDauSach AS [Tên sách], STRING_AGG(TenTacGia, ', ') AS [Tác giả], NhaXuatBan AS [Nhà xuất bản], NamXuatBan AS [Năm xuất bản], SoLuong AS [Số lượng], TriGia AS [Đơn giá]" +
                        " FROM TACGIA, CTTACGIA, DAUSACH, SACH" +
                        " WHERE TACGIA.MaTacGia = CTTACGIA.MaTacGia AND CTTACGIA.MaDauSach = DAUSACH.MaDauSach AND SACH.MaDauSach = DAUSACH.MaDauSach" +
                        " GROUP BY DAUSACH.TenDauSach, DAUSACH.MaDauSach, MaSach, NamXuatBan, NhaXuatBan, SoLuong, TriGia";
            DS_Sach.DataSource = connect(cauTruyVan);
            DS_Sach.AutoGenerateColumns = false;
            myConnection.Close();
        }

        private void Sach_Load(object sender, EventArgs e)
        {
            loadDS_Sach();
            DS_Sach.Enabled = true;
            btnLuu.Enabled = false;
            btnTaoMoi.Enabled = true;
            btnXemVaCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            txb_MaSach.Text = "";
            txb_SoLuong.Text = "0";
            loadMaDS();
            loadTenDS();
            cb_MaDS.SelectedIndex = -1;
            cb_TenSach.SelectedIndex = -1;
        }

        private void btnXemVaCapNhat_Click(object sender, EventArgs e)
        {
            loadDS_Sach();
            DS_Sach.Enabled = true;
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXemVaCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            txb_MaSach.Text = txb_NhaXB.Text = txb_NamXB.Text = "";
            txb_SoLuong.Text = txb_DonGia.Text = "0";
            loadMaDS();
            loadTenDS();
            cb_MaDS.SelectedIndex = -1;
            cb_TenSach.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txb_MaSach.Text = "";
            cb_MaDS.SelectedIndex = -1;
            cb_TenSach.SelectedIndex = -1;
            txb_TacGia.Text = "";
            txb_NhaXB.Text = "";
            txb_SoLuong.Text = "1";
            txb_DonGia.Text = "";
            txb_NamXB.Text = "";
            btnXemVaCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            phieuNhapSach phieuNhapSach = new phieuNhapSach();
            phieuNhapSach.ShowDialog();
        }

        void loadMaDS()
        {
            string cauTruyVan = "SELECT MaDauSach FROM DAUSACH";
            cb_MaDS.DataSource = connect(cauTruyVan);
            cb_MaDS.DisplayMember = "MaDauSach";
            cb_MaDS.SelectedIndex = -1;
        }
        void loadTenDS()
        {
            string cauTruyVan = "SELECT TenDauSach FROM DAUSACH";
            cb_TenSach.DataSource = connect(cauTruyVan);
            cb_TenSach.DisplayMember = "TenDauSach";
            cb_TenSach.SelectedIndex = -1;
        }

        private void DS_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaSach.Text = DS_Sach.CurrentRow.Cells[0].Value.ToString();
            cb_MaDS.Text = DS_Sach.CurrentRow.Cells[1].Value.ToString();
            cb_TenSach.Text = DS_Sach.CurrentRow.Cells[2].Value.ToString();
            txb_TacGia.Text = DS_Sach.CurrentRow.Cells[3].Value.ToString();
            txb_NamXB.Text = DS_Sach.CurrentRow.Cells[4].Value.ToString();
            txb_NhaXB.Text = DS_Sach.CurrentRow.Cells[5].Value.ToString();
            txb_SoLuong.Text = DS_Sach.CurrentRow.Cells[6].Value.ToString();
            txb_DonGia.Text = Decimal.Parse(DS_Sach.CurrentRow.Cells[7].Value.ToString()).ToString("N2");
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            btnXemVaCapNhat.Enabled = true;

        }

        private void cb_MaDS_SelectedValueChanged(object sender, EventArgs e)
        {
            string cauTruyVan = "SELECT TenDauSach FROM DAUSACH WHERE MaDauSach = '" + this.cb_MaDS.GetItemText(this.cb_MaDS.SelectedItem) + "'";
            connect(cauTruyVan);
            string tenDS = Convert.ToString(myCommand.ExecuteScalar());
            cb_TenSach.Text = tenDS;
            cauTruyVan = "SELECT STRING_AGG(TenTacGia, ', ') AS TenTG FROM TACGIA, CTTACGIA, DAUSACH WHERE DAUSACH.MaDauSach = CTTACGIA.MaDauSach  AND TACGIA.MaTacGia = CTTACGIA.MaTacGia AND DAUSACH.MaDauSach = '" + this.cb_MaDS.GetItemText(this.cb_MaDS.SelectedItem) + "'";
            connect(cauTruyVan);
            string tenTG = Convert.ToString(myCommand.ExecuteScalar());
            txb_TacGia.Text = tenTG;
        }

        private void cb_TenSach_SelectedValueChanged(object sender, EventArgs e)
        {
            string cauTruyVan = "SELECT MaDauSach FROM DAUSACH WHERE TenDauSach = N'" + this.cb_TenSach.GetItemText(this.cb_TenSach.SelectedItem) + "'";
            connect(cauTruyVan);
            string maDS = Convert.ToString(myCommand.ExecuteScalar());
            cb_MaDS.Text = maDS;
            cb_MaDS_SelectedValueChanged(this, e);
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void suaSach()
        {
            try
            {
                string capnhatdong;
                capnhatdong = "UPDATE  SACH SET MaDauSach = '" + cb_MaDS.Text + "', NhaXuatBan = N'" + txb_NhaXB.Text + "', NamXuatBan = '" + txb_NamXB.Text + "', TriGia = '" + txb_DonGia.Text +
                                "'WHERE MaSach = '" + txb_MaSach.Text + "'";
                connectNonQuery(capnhatdong);
                MessageBox.Show("Sửa thành công.", "Thông Báo");
            }
            catch
            {
                MessageBox.Show("Sửa thất bại.\nVui lòng kiểm tra lại dữ liệu.", "Thông Báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //string query = "SELECT  ThoiGianLuuHanh FROM THAMSO";
            //connect(query);
            //int tgXB = Convert.ToInt32(myCommand.ExecuteScalar());

            //if (DateTime.Now.Year - Convert.ToInt32(txb_NamXB.Text) > tgXB)
            //{
            //    MessageBox.Show("Chỉ nhận sách xuất bản trong vòng " + tgXB.ToString() + " năm!");
            //    return;
            //}
            //float ktTriGia;
            //bool isNumberTriGia = float.TryParse(txb_DonGia.Text, out ktTriGia);

            //if (isNumberTriGia == false || ktTriGia <= 0)
            //{
            //    MessageBox.Show("Vui lòng nhập số dương lớn hơn 0 trong ô:\nGiá Tiền.", "Thông Báo");
            //    return;
            //}
            if (cb_MaDS.Text.Length > 0 && cb_TenSach.Text.Length > 0 && txb_TacGia.Text.Length > 0 && txb_NhaXB.Text.Length > 0 && txb_DonGia.Text.Length > 0)
            {
                suaSach();
                loadDS_Sach();
                DS_Sach.AutoGenerateColumns = false;
                myConnection.Close();
                btnLuu.Enabled = false;
                btnTaoMoi.Enabled = true;
                btnXemVaCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                DS_Sach.Enabled = true;
                DS_Sach.FirstDisplayedScrollingRowIndex = DS_Sach.RowCount - 1;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông Báo");
                if (cb_MaDS.Text.Length == 0)
                    cb_MaDS.Focus();
                else if (cb_TenSach.Text.Length == 0)
                    cb_TenSach.Focus();
                else if (txb_NhaXB.Text.Length == 0)
                    txb_NhaXB.Focus();
                else if (txb_DonGia.Text.Length == 0)
                    txb_DonGia.Focus();

            }
        }

        private void txb_NamXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txb_DonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
