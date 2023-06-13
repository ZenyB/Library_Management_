using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management.Forms.DocGia
{
    public partial class LoaiDocGia : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;
        private bool isUpdate = false;

        public LoaiDocGia()
        {
            InitializeComponent();
        }

        private void LoaiDocGia_Load(object sender, EventArgs e)
        {
            loadLoaiDocGia();
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

        private void loadLoaiDocGia()
        {
            string truy_van = "SELECT MaLoaiDocGia AS [Mã Loại Độc Giả], TenLoaiDocGia AS [Tên Loại Độc Giả]" +
                              "FROM LOAIDOCGIA";
            DS_LoaiDocGia.DataSource = ket_noi_co_du_lieu(truy_van);
            connection.Close();
        }

        private string generateNewMaLoaiDocGia()
        {
            string truy_van = "SELECT TOP 1 MaLoaiDocGia FROM LOAIDOCGIA ORDER BY MaLoaiDocGia DESC";
            ket_noi_co_du_lieu(truy_van);
            string MaLoaiDocGiaMax = Convert.ToString(command.ExecuteScalar());
            int numberMaLoaiDocGiaMax = Convert.ToInt32(MaLoaiDocGiaMax.Substring(4));
            string strNumber = (++numberMaLoaiDocGiaMax).ToString();
            MaLoaiDocGiaMax = "MLDG" + strNumber.PadLeft(3, '0');
            return MaLoaiDocGiaMax;
        }

        private void themLoaiDocGia()
        {
            try
            {
                string truy_van = "INSERT INTO LOAIDOCGIA(TenLoaiDocGia)" +
                                  "VALUES (N'" + txb_TenLoaiDG.Text + "')";
                ket_noi_khong_du_lieu(truy_van);
                MessageBox.Show("Thêm loại độc giả thành công.", "Thông Báo");
                loadLoaiDocGia();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Thông Báo Lỗi");
            }
        }

        private void DS_TacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaLoaiDG.Text = DS_LoaiDocGia.CurrentRow.Cells[0].Value.ToString();
            txb_TenLoaiDG.Text = DS_LoaiDocGia.CurrentRow.Cells[1].Value.ToString();
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            isUpdate = true;
        }

        private void btnLuu_MouseDown_1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int flag = 0;
                for (int i = 0; i < DS_LoaiDocGia.RowCount; i++)
                {
                    if (txb_TenLoaiDG.Text.ToUpper() == DS_LoaiDocGia.Rows[i].Cells[1].Value.ToString().ToUpper())
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    {
                        if (txb_TenLoaiDG.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập tên loại độc giả", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (txb_TenLoaiDG.Text.Length > 0)
                    {
                        string truy_van = null;
                        if (isUpdate)
                        {
                            try
                            {
                                truy_van = "UPDATE LOAIDOCGIA " +
                                           "SET TenLoaiDocGia = N'" + txb_TenLoaiDG.Text + "'" +
                                           "WHERE MaLoaiDocGia = '" + txb_MaLoaiDG.Text + "'";
                                ket_noi_co_du_lieu(truy_van);
                                command.ExecuteNonQuery();
                                MessageBox.Show("Cập nhật thành công.", "Thông Báo");
                                loadLoaiDocGia();
                            }
                            catch
                            {
                                MessageBox.Show("Cập nhật thất bại.", "Thông Báo Lỗi");
                            }
                        }
                        else
                        {
                            themLoaiDocGia();
                            truy_van = "SELECT TOP 1 MaLoaiDocGia " +
                                       "FROM LOAIDOCGIA " +
                                       "ORDER BY MaLoaiDocGia DESC ";
                            ket_noi_co_du_lieu(truy_van);
                            txb_MaLoaiDG.Text = Convert.ToString(command.ExecuteScalar());
                        }

                        connection.Close();
                        btnLuu.Enabled = true;
                        btnTaoMoi.Enabled = true;
                        btnXoa.Enabled = true;
                        DS_LoaiDocGia.Enabled = true;
                        DS_LoaiDocGia.FirstDisplayedScrollingRowIndex = DS_LoaiDocGia.RowCount - 1;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập tên loại độc giả", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txb_TenLoaiDG.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên loại độc giả giả đã tồn tại");
                }
            }
        }

        private void btnXoa_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Bạn chắc chắn muốn xóa loại độc giả này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string truy_van = "DELETE FROM LOAIDOCGIA WHERE MaLoaiDocGia='" + txb_MaLoaiDG.Text + "'";
                        ket_noi_khong_du_lieu(truy_van);
                        MessageBox.Show("Xóa loại độc giả thành công.", "Thông Báo");
                        btnLuu.Enabled = false;
                        btnXoa.Enabled = false;
                        btnTaoMoi.Enabled = true;
                        isUpdate = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa loại độc giả thất bại.\nVẫn còn tồn tại độc giả thuộc loại này.", "Thông Báo Lỗi");
                    }
                }
                loadLoaiDocGia();
            }
        }

        private void btnTaoMoi_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txb_MaLoaiDG.Text = generateNewMaLoaiDocGia();
                txb_TenLoaiDG.Text = "";
                isUpdate = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }
        }

        private void btnXemVaCapNhat_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                loadLoaiDocGia();
            }
        }

        private void DS_LoaiDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaLoaiDG.Text = DS_LoaiDocGia.CurrentRow.Cells[0].Value.ToString();
            txb_TenLoaiDG.Text = DS_LoaiDocGia.CurrentRow.Cells[1].Value.ToString();
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            isUpdate = true;
        }
    }
}
