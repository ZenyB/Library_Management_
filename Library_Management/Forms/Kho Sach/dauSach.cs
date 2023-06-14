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
using System.Windows.Documents;
using System.Windows.Forms; 

namespace Library_Management
{
    public partial class dauSach : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;
        private DataTable tableTacGia = new DataTable();
        private bool isUpdate = false;
        
        public dauSach()
        {
            InitializeComponent();
        }
        private void dauSach_Load(object sender, EventArgs e)
        {
            loadDauSach();
            loadMaTheLoai();
            loadTenTacGia();
            loadTenTheLoai();
            setSizeCol();
            tableTacGia.Columns.Add("MaTacGia");
            cb_MaTheLoai.SelectedIndex = -1;
            cb_TenTheLoai.SelectedIndex = -1;
            cb_TenTacGia.SelectedIndex = -1;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnTaoMoi.Enabled = true;
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

        private void loadDauSach()
        {
            string truy_van = "SELECT MaDauSach AS [Mã Đầu Sách], TenDauSach AS [Tên Đầu Sách], DAUSACH.MaTheLoai AS [Mã Thể Loại], TenTheLoai AS [Thể Loại]" +
                                "FROM DAUSACH, THELOAI " +
                                "WHERE DAUSACH.MaTheLoai = THELOAI.MaTheLoai ";
            DS_DauSach.DataSource = ket_noi_co_du_lieu(truy_van);
            DS_DauSach.AutoGenerateColumns = false;
            connection.Close();
        }

        void loadMaTheLoai()
        {
            string cauTruyVan = "SELECT MaTheLoai FROM THELOAI";
            cb_MaTheLoai.DataSource = ket_noi_co_du_lieu(cauTruyVan);
            cb_MaTheLoai.DisplayMember = "MaTheLoai";
            cb_MaTheLoai.SelectedIndex = -1;
        }
        void loadTenTheLoai()
        {
            string cauTruyVan = "SELECT TenTheLoai FROM THELOAI";
            cb_TenTheLoai.DataSource = ket_noi_co_du_lieu(cauTruyVan);
            cb_TenTheLoai.DisplayMember = "TenTheLoai";
            cb_TenTheLoai.SelectedIndex = -1;
        }
        void loadTenTacGia()
        {
            string cauTruyVan = "SELECT MaTacGia, TenTacGia FROM TACGIA";
            cb_TenTacGia.DataSource = ket_noi_co_du_lieu(cauTruyVan);
            cb_TenTacGia.ValueMember = "MaTacGia";
            cb_TenTacGia.DisplayMember = "TenTacGia";
            cb_TenTacGia.SelectedIndex = -1;
        }
        void setSizeCol()
        {
            DS_DauSach.Columns[0].Width = 60;
            DS_DauSach.Columns[1].Width = 200;
            DS_DauSach.Columns[2].Width = 80;
            DS_DauSach.Columns[3].Width = 200;
        }

        private string generateNewMaDauSach()
        {
            string truy_van = "SELECT TOP 1 MaDauSach FROM DAUSACH ORDER BY MaDauSach DESC";
            ket_noi_co_du_lieu(truy_van);
            string MaDauSachMax = Convert.ToString(command.ExecuteScalar());
            int numberMaDauSachMax = Convert.ToInt32(MaDauSachMax.Substring(3));
            string strNumber = (++numberMaDauSachMax).ToString();
            MaDauSachMax = "MDS" + strNumber.PadLeft(3, '0');
            return MaDauSachMax;
        }

        private void themDauSach()
        {
            try
            {
                string truy_van = "INSERT INTO DAUSACH(TenDauSach, MaTheLoai)" +
                "VALUES (N'" + txb_TenDauSach.Text + "', '" + cb_MaTheLoai.Text + "')";
                ket_noi_khong_du_lieu(truy_van);
                MessageBox.Show("Thêm thành công.", "Thông Báo");
                loadDauSach();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error");
            }
        }
        private void xoaCTTacGia(string maDS)
        {
            string nonquery = "DELETE FROM CTTACGIA WHERE MaDauSach = '" + maDS + "'";
            ket_noi_khong_du_lieu(nonquery);

        }
        private void ThemCTTacGia(string maDS, string maTG)
        {
            string nonquery = "INSERT INTO CTTacGia(MaDauSach, MaTacGia) VALUES ('" + maDS + "', '" + maTG + "')";
            ket_noi_khong_du_lieu(nonquery);
        }
        public int xuly;

        private void btnThemTG_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { 
                tacGia tacgia = new tacGia();
                tacgia.ShowDialog();
            }
        }

        private void btnTaoMoi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txb_MaDauSach.Text = "";
                txb_TenDauSach .Text = "";
                listBox_TacGia.Items.Clear();
                txb_MaDauSach.Text = generateNewMaDauSach();
                cb_MaTheLoai.SelectedIndex = -1;
                cb_TenTacGia.SelectedIndex = -1;    
                cb_TenTheLoai.SelectedIndex = -1;
                txb_TenDauSach.Focus();
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                isUpdate = false;
            }
        }

        private void DS_DauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DS_DauSach.Rows[e.RowIndex];
                txb_MaDauSach.Text = row.Cells[0].Value.ToString();
                txb_TenDauSach.Text = row.Cells[1].Value.ToString();
                cb_MaTheLoai.Text = row.Cells[2].Value.ToString();
                cb_TenTheLoai.Text = row.Cells[3].Value.ToString();
                string truy_van = "SELECT TacGia.MaTacGia AS [MaTacGia], TenTacGia " +
                                "FROM DAUSACH, TACGIA, CTTACGIA " +
                                "WHERE DAUSACH.MaDauSach = CTTACGIA.MaDauSach AND " +
                                "CTTACGIA.MaTacGia = TACGIA.MaTacGia AND " +
                                "CTTACGIA.MaDauSach = '" + txb_MaDauSach.Text + "'";
                tableTacGia = ket_noi_co_du_lieu(truy_van);
                cb_TenTacGia.SelectedIndex = -1;
                listBox_TacGia.Items.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    listBox_TacGia.Items.Add(tableTacGia.Rows[i].ItemArray[1].ToString());
                }
                btnLuu.Enabled = true;
                btnTaoMoi.Enabled = true;
                btnXoa.Enabled = true;
                isUpdate = true;
            }
        }

        private void btn_RemoveTacGia_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox_TacGia.SelectedIndex >= 0)
            {
                tableTacGia.Rows.RemoveAt(listBox_TacGia.SelectedIndex);
                listBox_TacGia.Items.RemoveAt(listBox_TacGia.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tác giả muốn xóa!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_AddTacGia_MouseDown(object sender, MouseEventArgs e)
        {
            if (cb_TenTacGia.Text != "")
            {
                if (listBox_TacGia.Items.Count == 0)
                {
                    listBox_TacGia.Items.Add(cb_TenTacGia.Text);
                    tableTacGia.Rows.Add(cb_TenTacGia.SelectedValue.ToString());
                    cb_TenTacGia.SelectedIndex = -1;
                }
                else
                {
                    for (int i = 0; i < listBox_TacGia.Items.Count; i++)
                    {
                        if (listBox_TacGia.Items[i].ToString() == cb_TenTacGia.Text)
                        {
                            MessageBox.Show(string.Format("{0} đã được thêm!", cb_TenTacGia.Text), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    tableTacGia.Rows.Add(cb_TenTacGia.SelectedValue.ToString());
                    listBox_TacGia.Items.Add(cb_TenTacGia.Text);
                    cb_TenTacGia.SelectedIndex = -1;
                }
            }
            else
                MessageBox.Show("Vui lòng chọn tác giả muốn thêm.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnXoa_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa đầu sách này?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string truy_van = "IF EXISTS" +
                                            "(SELECT * " +
                                            "FROM SACH " +
                                            "WHERE MaDauSach = '" + txb_MaDauSach.Text + "' " +
                                            "AND SoLuong > 0) " +
                                          "BEGIN SELECT 0 END ELSE BEGIN SELECT 1 END";
                        ket_noi_co_du_lieu(truy_van);
                        int resultNumber = Convert.ToInt32(command.ExecuteScalar());
                        if (resultNumber == 0)
                        {
                            MessageBox.Show("Xóa đầu sách thất bại.\nTrong thư viện hiện vẫn còn sách của đầu sách này.", "Thông Báo Lỗi");
                        }
                        else
                        {
                            truy_van = "DELETE FROM CTTACGIA WHERE MaDauSach = '" + txb_MaDauSach.Text + "'";
                            ket_noi_khong_du_lieu(truy_van);
                            truy_van = "DELETE FROM DAUSACH WHERE MaDauSach = '" + txb_MaDauSach.Text + "'";
                            ket_noi_khong_du_lieu(truy_van);
                            MessageBox.Show("Xóa đầu sách thành công.", "Thông Báo");
                            btnLuu.Enabled = true;
                            btnXoa.Enabled = false;
                            btnTaoMoi.Enabled = true;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa đầu sách thất bại.\nTrong thư viện hiện vẫn còn sách của đầu sách này.", "Thông Báo");
                    }
                }
                loadDauSach();
            }
        }

        private void cb_TenTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string truy_van = "SELECT MaTheLoai " +
                              "FROM THELOAI " +
                              "WHERE TenTheLoai = N'" + cb_TenTheLoai.GetItemText(cb_TenTheLoai.SelectedItem) + "'";
            ket_noi_co_du_lieu(truy_van);
            cb_MaTheLoai.Text = Convert.ToString(command.ExecuteScalar());
        }

        private void btnXemVaCapNhat_MouseDown(object sender, MouseEventArgs e)
        {
            loadDauSach();
        }

        private void btnLuu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button  == MouseButtons.Left) 
            {
                if (!isUpdate)
                {
                    int flag = 0;
                    for (int i = 0; i < DS_DauSach.RowCount; i++)
                    {

                        if (txb_TenDauSach.Text.ToUpper() == DS_DauSach.Rows[i].Cells[1].Value.ToString().ToUpper())
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        {
                            if (txb_TenDauSach.Text == "" || cb_TenTheLoai.Text == "")
                            {
                                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đầu sách", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            if (listBox_TacGia.Items.Count == 0)
                            {
                                MessageBox.Show("Vui lòng chọn tác giả cho đầu sách", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        if (txb_TenDauSach.Text.Length > 0 && cb_MaTheLoai.Text.Length > 0 && cb_TenTheLoai.Text.Length > 0 && listBox_TacGia.Items.Count > 0)
                        {
                            string query = null;
                            if (xuly == 0)
                            {
                                themDauSach();
                                query = "SELECT TOP 1 MaDauSach FROM DAUSACH ORDER BY MaDauSach DESC ";
                                ket_noi_co_du_lieu(query);
                                txb_MaDauSach.Text = Convert.ToString(command.ExecuteScalar());
                                for (int i = 0; i < listBox_TacGia.Items.Count; i++)
                                {
                                    ThemCTTacGia(txb_MaDauSach.Text, tableTacGia.Rows[i].ItemArray[0].ToString());
                                }
                            }

                            //DS_DauSach.AutoGenerateColumns = false;
                            connection.Close();
                            btnLuu.Enabled = false;
                            btnTaoMoi.Enabled = true;
                            btnXoa.Enabled = true;
                            DS_DauSach.FirstDisplayedScrollingRowIndex = DS_DauSach.RowCount - 1;
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin đầu sách", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txb_TenDauSach.Focus();
                        }
                    }
                    else MessageBox.Show("Tên đầu sách đã tồn tại");
                }
                else
                {
                    int flag = 0;
                    for (int i = 0; i < DS_DauSach.RowCount; i++)
                    {

                        if (txb_TenDauSach.Text.ToUpper() == DS_DauSach.Rows[i].Cells[1].Value.ToString().ToUpper()
                            && txb_MaDauSach.Text.ToUpper() != DS_DauSach.Rows[i].Cells[0].Value.ToString())
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        {
                            if (txb_TenDauSach.Text == "" || cb_TenTheLoai.Text == "")
                            {
                                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đầu sách", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            if (listBox_TacGia.Items.Count == 0)
                            {
                                MessageBox.Show("Vui lòng chọn tác giả cho đầu sách", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        if (txb_TenDauSach.Text.Length > 0 && cb_MaTheLoai.Text.Length > 0 && cb_TenTheLoai.Text.Length > 0 && listBox_TacGia.Items.Count > 0)
                        {
                            string query = null;
                            if (xuly == 0)
                            {
                                xoaCTTacGia(txb_MaDauSach.Text);
                                query = "UPDATE DAUSACH " +
                                        "SET TenDauSach = N'" + txb_TenDauSach.Text + "', MaTheLoai = '" + cb_MaTheLoai.Text + "'" +
                                        "WHERE MaDauSach = '" + txb_MaDauSach.Text + "'";
                                ket_noi_co_du_lieu(query);
                                command.ExecuteNonQuery();
                                for (int i = 0; i < listBox_TacGia.Items.Count; i++)
                                {
                                    ThemCTTacGia(txb_MaDauSach.Text, tableTacGia.Rows[i].ItemArray[0].ToString());
                                }
                                MessageBox.Show("Đã cập nhật thông tin đầu sách", "Thông báo");
                            }

                            connection.Close();
                            btnLuu.Enabled = false;
                            btnTaoMoi.Enabled = true;
                            btnXoa.Enabled = false;
                            DS_DauSach.FirstDisplayedScrollingRowIndex = DS_DauSach.RowCount - 1;
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin đầu sách", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txb_TenDauSach.Focus();
                        }
                    }
                    else MessageBox.Show("Tên đầu sách này đã tồn tại.");
                }
            }
        }
    }
}
