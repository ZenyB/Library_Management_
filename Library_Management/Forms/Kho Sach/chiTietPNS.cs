using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Library_Management
{
    public partial class chiTietPNS : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;
        private bool isUpdate = false;
        private bool isNewSach = false;
        private string masach = "";

        public chiTietPNS()
        {
            InitializeComponent();
        }

        private void chiTietPNS_Load(object sender, EventArgs e)
        {
            loadChiTietPNS();
            loadDauSach();
            loadMaSach();
            cb_MaSach.SelectedIndex = -1;
            cb_TenSach.SelectedIndex = -1;
            txb_TacGia.Text = "";
            txb_NhaXB.Text = "";
            txb_NamXB.Text = "";
            txb_SoLuong.Text = "";
            txb_DonGia.Text = "";
            txb_ThanhTien.Text = "";
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

        private void ket_noi_khong_du_lieu(string truy_van)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(truy_van, connection);
            command.ExecuteNonQuery();
        }

        private string generateNewMaChiTietPNS()
        {
            string truy_van = "SELECT TOP 1 MaCTPN " +
                              "FROM CT_PhieuNhap " +
                              "ORDER BY MaCTPN DESC";
            ket_noi_co_du_lieu(truy_van);
            string MaChiTietPNSMax = Convert.ToString(command.ExecuteScalar());
            int numberMaChiTietPNSMax = Convert.ToInt32(MaChiTietPNSMax.Substring(5));
            string strNumber = (++numberMaChiTietPNSMax).ToString();
            MaChiTietPNSMax = "MCTPN" + strNumber.PadLeft(3, '0');
            return MaChiTietPNSMax;
        }

        private string generateNewMaSach()
        {
            string truy_van = "SELECT TOP 1 MaSach " +
                              "FROM SACH " +
                              "ORDER BY MaSach DESC";
            ket_noi_co_du_lieu(truy_van);
            string MaSachMax = Convert.ToString(command.ExecuteScalar());
            int numberMaSachMax = Convert.ToInt32(MaSachMax.Substring(2));
            string strNumber = (++numberMaSachMax).ToString();
            MaSachMax = "MS" + strNumber.PadLeft(3, '0');
            return MaSachMax;
        }


        private void loadChiTietPNS()
        {
            string truy_van = "SELECT * FROM MAPN";
            ket_noi_co_du_lieu(truy_van);
            string maPN = Convert.ToString(command.ExecuteScalar());
            txb_MaPNS.Text = maPN;
            txb_MaCTPNS.Text = generateNewMaChiTietPNS();
            truy_van = "SELECT MaCTPN AS [Mã CTPN], SACH.MaSach AS [Mã Sách], TenDauSach AS [Tên Sách], STRING_AGG(TenTacGia, ', ') AS [Tác Giả], NhaXuatBan AS [Nhà XB], NamXuatBan AS [Năm XB], CT_PHIEUNHAP.SoLuong AS [Số lượng], DonGia AS [Đơn Giá], ThanhTien AS [Thành Tiền]" +
                                "FROM CT_PHIEUNHAP, DAUSACH, SACH, CTTACGIA, TACGIA, PHIEUNHAPSACH " +
                                "WHERE CT_PHIEUNHAP.MaSach = SACH.MaSach " +
                                "AND SACH.MaDauSach = DAUSACH.MaDauSach " +
                                "AND CTTACGIA.MaDauSach = DAUSACH.MaDauSach " +
                                "AND CTTACGIA.MaTacGia = TACGIA.MaTacGia " +
                                "AND PHIEUNHAPSACH.MaPhieuNhapSach = CT_PHIEUNHAP.MaPhieuNhapSach AND PHIEUNHAPSACH.MaPhieuNhapSach = '" + txb_MaPNS.Text + "'" +
                                "GROUP BY MaCTPN, TenDauSach, SACH.MaSach, NhaXuatBan, NamXuatBan, CT_PHIEUNHAP.SoLuong, DonGia, ThanhTien";
            DS_chitietPNS.DataSource = ket_noi_co_du_lieu(truy_van);
            connection.Close();
        }

        private void loadDauSach()
        {
            string truy_van = "SELECT MaDauSach, TenDauSach FROM DAUSACH";
            cb_TenSach.DataSource = ket_noi_co_du_lieu(truy_van);
            cb_TenSach.ValueMember = "MaDauSach";
            cb_TenSach.DisplayMember = "TenDauSach";
            cb_TenSach.SelectedIndex = -1;
        }

        private void loadMaSach()
        {
            string truy_van = "SELECT MaSach FROM SACH";
            cb_MaSach.DataSource = ket_noi_co_du_lieu(truy_van);
            cb_MaSach.DisplayMember = "MaSach";
            cb_MaSach.SelectedIndex = -1;
        }

        private void themCuonSach(string maSach, string maCTPN)
        {
            string nonquery = "INSERT INTO CUONSACH(MaSach, TinhTrang, MaCTPN) VALUES ('" + maSach + "' , '0', '" + maCTPN + "')";
            ket_noi_khong_du_lieu(nonquery);
        }

        private void xoaCuonSach(string maCTPN)
        {
            string nonquery = "DELETE FROM CUONSACH WHERE MaCTPN = '" + maCTPN + "'";
            ket_noi_khong_du_lieu(nonquery);
        }

        private void themCTPN()
        {
            try
            {
                string truy_van = null;
                int soluong = 0;
                MessageBox.Show(isNewSach.ToString());
                if (!isNewSach)
                {
                    truy_van = "SELECT SoLuong " +
                              "FROM SACH " +
                              "WHERE SACH.MaSach ='" + cb_MaSach.GetItemText(cb_MaSach.SelectedItem) + "' ";
                    ket_noi_co_du_lieu(truy_van);
                    string soluongStr = Convert.ToString(command.ExecuteScalar());
                    soluong = Int32.Parse(txb_SoLuong.Text) + Int32.Parse(soluongStr);
                }
                truy_van = "INSERT INTO CT_PHIEUNHAP (MaPhieuNhapSach, MaSach, SoLuong, DonGia) " +
                    "VALUES ('" + txb_MaPNS.Text + "', '" + cb_MaSach.Text + "', " + txb_SoLuong.Text + ", " + txb_DonGia.Text + ")";
                ket_noi_khong_du_lieu(truy_van);

                truy_van = "UPDATE SACH SET SoLuong = " + soluong + " WHERE MaSach = '" + cb_MaSach.Text + "'";
                ket_noi_khong_du_lieu(truy_van);

                int ktSoLuong;
                bool isNumberSoLuong = int.TryParse(txb_SoLuong.Text, out ktSoLuong);
                for (int i = 0; i < ktSoLuong; i++)
                {
                    MessageBox.Show("Thêm nè");
                    themCuonSach(cb_MaSach.Text, txb_MaCTPNS.Text);
                }
                MessageBox.Show("Thêm chi tiết phiếu nhập thành công.", "Thông Báo");
                connection.Close();
            }
            catch
            {
            }
        }

        private void xoaCTPN()
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    xoaCuonSach(txb_MaCTPNS.Text);
                    string xoadongSql;
                    xoadongSql = "DELETE FROM CT_PHIEUNHAP WHERE MaCTPN = '" + txb_MaCTPNS.Text + "'";
                    ket_noi_khong_du_lieu(xoadongSql);
                    MessageBox.Show("Xóa thành công.", "Thông Báo");
                    btnLuu.Enabled = true;
                    btnXoa.Enabled = false;
                    btnTaoMoi.Enabled = true;
                    isUpdate = false;
                    txb_MaCTPNS.Text = generateNewMaChiTietPNS();
                    cb_MaSach.SelectedIndex = -1;
                    cb_TenSach.SelectedIndex = -1;
                    txb_TacGia.Text = "";
                    txb_NhaXB.Text = "";
                    txb_NamXB.Text = "";
                    txb_SoLuong.Text = "";
                    txb_DonGia.Text = "";
                    txb_ThanhTien.Text = "";
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại.\nTrong chi tiết nhập sách trên, đã có cuốn sách được mượn.", "Thông Báo");
                }
            }
            loadChiTietPNS();
        }

        private void suaCTPN()
        {
            try
            {
                string capnhatdong;
                xoaCuonSach(txb_MaCTPNS.Text);
                capnhatdong = "UPDATE  CT_PHIEUNHAP " +
                                "SET MaPhieuNhapSach = '" + txb_MaPNS.Text + "', MaSach = '" + cb_MaSach.Text + "', SoLuong = " + txb_SoLuong.Text + ", DonGia = " + txb_DonGia.Text + "" +
                                "WHERE MaCTPN = '" + txb_MaCTPNS.Text + "'";
                ket_noi_khong_du_lieu(capnhatdong);
                int ktSoLuong;
                bool isNumberSoLuong = int.TryParse(txb_SoLuong.Text, out ktSoLuong);
                for (int i = 0; i < ktSoLuong; i++)
                {
                    themCuonSach(cb_MaSach.Text, txb_MaCTPNS.Text);
                }
                MessageBox.Show("Cập nhật thành công chi tiết phiếu nhập sách.", "Thông Báo");
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại.\nĐã có cuốn sách trong lần nhập này được mượn.", "Thông Báo Lỗi");
            }
        }

        private void themSach()
        {
            try
            {
                string query = "INSERT INTO SACH (MaDauSach, NhaXuatBan, NamXuatBan, SoLuong, TriGia) " +
                    "VALUES ('" + cb_TenSach.SelectedValue.ToString() + "', N'" + txb_NhaXB.Text + "', " + txb_NamXB.Text + ", " + txb_SoLuong.Text + ", " + txb_DonGia.Text + ")";
                ket_noi_khong_du_lieu(query);

                int soluong = Int32.Parse(txb_SoLuong.Text);
                query = "UPDATE SACH SET SoLuong = " + soluong + " WHERE MaSach = '" + cb_MaSach.Text + "'";
                ket_noi_khong_du_lieu(query);
                connection.Close();
                loadMaSach();
                cb_MaSach.Text = masach;
            }
            catch
            {
            }
        }

        private void DS_chitietPNS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaCTPNS.Text = DS_chitietPNS.CurrentRow.Cells[0].Value.ToString();
            cb_MaSach.Text = DS_chitietPNS.CurrentRow.Cells[1].Value.ToString();
            cb_TenSach.Text = DS_chitietPNS.CurrentRow.Cells[2].Value.ToString();
            txb_TacGia.Text = DS_chitietPNS.CurrentRow.Cells[3].Value.ToString();
            txb_NamXB.Text = DS_chitietPNS.CurrentRow.Cells[5].Value.ToString();
            txb_NhaXB.Text = DS_chitietPNS.CurrentRow.Cells[4].Value.ToString();
            txb_SoLuong.Text = DS_chitietPNS.CurrentRow.Cells[6].Value.ToString();
            txb_DonGia.Text = DS_chitietPNS.CurrentRow.Cells[7].Value.ToString();
            txb_ThanhTien.Text = DS_chitietPNS.CurrentRow.Cells[8].Value.ToString();
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            isUpdate = true;
            btn_SachMoi.Enabled = false;
        }

        private void cb_TenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TenSach.SelectedIndex >= 0)
            {
                string truy_van = "SELECT STRING_AGG(TenTacGia, ', ') AS TenTG " +
                             "FROM TACGIA, CTTACGIA, DAUSACH " +
                             "WHERE DAUSACH.MaDauSach = CTTACGIA.MaDauSach  " +
                             "AND TACGIA.MaTacGia = CTTACGIA.MaTacGia " +
                             "AND DAUSACH.MaDauSach = '" + cb_TenSach.SelectedValue.ToString() + "'";
                ket_noi_co_du_lieu(truy_van);
                string tacgia = Convert.ToString(command.ExecuteScalar());
                txb_TacGia.Text = tacgia;
            }
        }

        private void btn_SachMoi_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                masach = generateNewMaSach();
                cb_MaSach.Text = masach;
                isNewSach = true;
                isUpdate = false;
                txb_DonGia.ReadOnly = false;
                txb_NamXB.ReadOnly = false;
                txb_NhaXB.ReadOnly = false;
            }  
        }

        private void cb_MaSach_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_MaSach.SelectedValue != null && cb_MaSach.Text != "" && cb_MaSach.SelectedIndex != -1)
            {
                isNewSach = false;
                string truy_van = "SELECT TenDauSach " +
                                  "FROM DAUSACH, SACH " +
                                  "WHERE SACH.MaSach ='" + cb_MaSach.GetItemText(cb_MaSach.SelectedItem) + "' " +
                                  "AND SACH.MaDauSach = DAUSACH.MaDauSach";
                ket_noi_co_du_lieu(truy_van);
                cb_TenSach.Text = Convert.ToString(command.ExecuteScalar());
                truy_van = "SELECT NhaXuatBan " +
                                  "FROM SACH " +
                                  "WHERE SACH.MaSach ='" + cb_MaSach.GetItemText(cb_MaSach.SelectedItem) + "' ";
                ket_noi_co_du_lieu(truy_van);
                txb_NhaXB.Text = Convert.ToString(command.ExecuteScalar());
                truy_van = "SELECT NamXuatBan " +
                                  "FROM SACH " +
                                  "WHERE SACH.MaSach ='" + cb_MaSach.GetItemText(cb_MaSach.SelectedItem) + "' ";
                ket_noi_co_du_lieu(truy_van);
                txb_NamXB.Text = Convert.ToString(command.ExecuteScalar());
                truy_van = "SELECT TriGia " +
                                  "FROM SACH " +
                                  "WHERE SACH.MaSach ='" + cb_MaSach.GetItemText(cb_MaSach.SelectedItem) + "' ";
                ket_noi_co_du_lieu(truy_van);
                txb_DonGia.Text = Convert.ToString(command.ExecuteScalar());
                txb_DonGia.ReadOnly = true;
                txb_NamXB.ReadOnly = true;
                txb_NhaXB.ReadOnly = true;
            }
        }

        private void txb_SoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txb_DonGia.Text != "" && txb_SoLuong.Text != "")
            {
                txb_ThanhTien.Text = (float.Parse(txb_DonGia.Text) * float.Parse(txb_SoLuong.Text)).ToString();
            }
        }

        private void txb_DonGia_TextChanged(object sender, EventArgs e)
        {
            if (txb_DonGia.Text != "" && txb_SoLuong.Text != "")
            {
                txb_ThanhTien.Text = (float.Parse(txb_DonGia.Text) * float.Parse(txb_SoLuong.Text)).ToString();
            }
        }

        private void txb_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txb_DonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!isUpdate)
                {
                    if (cb_TenSach.Text == "")
                    {
                        MessageBox.Show("Vui lòng chọn Tên Sách", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (txb_SoLuong.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập số lượng sách nhập đợt này", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (isNewSach && txb_DonGia.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đơn giá sách đợt này", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    string query = "SELECT ThoiGianLuuHanh FROM THAMSO";
                    ket_noi_co_du_lieu(query);
                    int thoiGianLuuHanh = Convert.ToInt32(command.ExecuteScalar());

                    if (txb_NamXB.Text != "" && DateTime.Now.Year - Convert.ToInt32(txb_NamXB.Text) > thoiGianLuuHanh)
                    {
                        MessageBox.Show("Sách đã quá hạn thời gian lưu hành cho phép!");
                        return;
                    }
                    float ktTriGia;
                    bool isNumberTriGia = float.TryParse(txb_DonGia.Text, out ktTriGia);
                    int ktSoLuong;
                    bool isNumberSoLuong = int.TryParse(txb_SoLuong.Text, out ktSoLuong);
                    if (isNumberSoLuong == false || ktSoLuong <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng là số nguyên dương", "Thông Báo Lỗi");
                        return;
                    }
                    if (isNumberTriGia == false || ktTriGia <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá tiền là số dương", "Thông Báo Lỗi");
                        return;
                    }
                    if (cb_MaSach.Text.Length > 0 && cb_TenSach.Text.Length > 0 
                        && txb_DonGia.Text.Length > 0 && isNumberTriGia == true 
                        && ktTriGia > 0 && txb_SoLuong.Text.Length > 0 && isNumberSoLuong == true)
                    {
                        if (!isNewSach)
                        {
                            string truy_van = "IF EXISTS" +
                                                "(SELECT * " +
                                                "FROM CT_PHIEUNHAP " +
                                                "WHERE MaSach = '" + cb_MaSach.Text + "' " +
                                                "AND MaPhieuNhapSach = '" + txb_MaPNS + "')" +
                                              "BEGIN SELECT 0 END ELSE BEGIN SELECT 1 END";
                            ket_noi_co_du_lieu(truy_van);
                            int resultNumber = Convert.ToInt32(command.ExecuteScalar());
                            if (resultNumber == 0)
                            {
                                MessageBox.Show("Thêm thất bại.\nĐã tồn tại mã sách này trong chi tiết phiếu nhập này.", "Thông Báo Lỗi");
                                return;
                            }
                        }
                        else
                        {
                            themSach();
                            isNewSach = true;
                        }

                        themCTPN();

                        loadChiTietPNS();
                        connection.Close();
                        btnLuu.Enabled = false;
                        btnTaoMoi.Enabled = true;
                        isUpdate = false;
                        btnXoa.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông Báo");
                    }
                }
                else
                {
                    suaCTPN();
                    loadChiTietPNS();
                    connection.Close();
                    btnLuu.Enabled = false;
                    btnTaoMoi.Enabled = true;
                    btnXoa.Enabled = false;
                    isUpdate = false;
                }
            }
        }

        private void btnXemVaCapNhat_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                loadChiTietPNS();
            }
        }

        private void btnTaoMoi_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txb_MaCTPNS.Text = generateNewMaChiTietPNS();
                cb_MaSach.SelectedIndex = -1;
                cb_TenSach.SelectedIndex = -1;
                txb_TacGia.Text = "";
                txb_NhaXB.Text = "";
                txb_NamXB.Text = "";
                txb_SoLuong.Text = "";
                txb_DonGia.Text = "";
                txb_ThanhTien.Text = "";
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btn_SachMoi.Enabled = true;
            }  
        }

        private void btnXoa_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xoaCTPN();
            }
        }
    }
}
