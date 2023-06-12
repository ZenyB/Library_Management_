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
    public partial class tacGia : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;
        private bool isUpdate = false;
        public tacGia()
        {
            InitializeComponent();
        }

        private void tacGia_Load(object sender, EventArgs e)
        {
            loadTacGia();
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

        private void loadTacGia()
        {
            string truy_van = "SELECT MaTacGia AS [Mã Tác Giả], TenTacGia AS [Tên Tác Giả]" +
                              "FROM TACGIA";
            DS_TacGia.DataSource = ket_noi_co_du_lieu(truy_van);
            connection.Close();
        }

        private string generateNewMaTacGia()
        {
            string truy_van = "SELECT TOP 1 MaTacGia FROM TACGIA ORDER BY MaTacGia DESC";
            ket_noi_co_du_lieu(truy_van);
            string MaTacGiaMax = Convert.ToString(command.ExecuteScalar());
            int numberMaTacGiaMax = Convert.ToInt32(MaTacGiaMax.Substring(3));
            string strNumber = (++numberMaTacGiaMax).ToString();
            MaTacGiaMax = "MTG" + strNumber.PadLeft(3, '0');
            return MaTacGiaMax;
        }

        private void themTacGia()
        {
            try
            {
                string truy_van = "INSERT INTO TACGIA(TenTacGia)" +
                                     "VALUES (N'" + txb_TenTG.Text + "')";
                ket_noi_khong_du_lieu(truy_van);
                MessageBox.Show("Thêm tác giả thành công.", "Thông Báo");
                loadTacGia();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Thông Báo Lỗi");
            }
        }

        private void DS_TacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaTG.Text = DS_TacGia.CurrentRow.Cells[0].Value.ToString();
            txb_TenTG.Text = DS_TacGia.CurrentRow.Cells[1].Value.ToString();
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            isUpdate = true;
        }

        private void thongTinPN_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_MouseDown_1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int flag = 0;
                for (int i = 0; i < DS_TacGia.RowCount; i++)
                {
                    if (txb_TenTG.Text.ToUpper() == DS_TacGia.Rows[i].Cells[1].Value.ToString().ToUpper())
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    {
                        if (txb_TenTG.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập tên tác giả", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (txb_TenTG.Text.Length > 0)
                    {
                        string truy_van = null;
                        if (isUpdate)
                        {
                            try
                            {
                                truy_van = "UPDATE TACGIA " +
                                           "SET TenTacGia = N'" + txb_TenTG.Text + "'" +
                                           "WHERE MaTacGia = '" + txb_MaTG.Text + "'";
                                ket_noi_co_du_lieu(truy_van);
                                command.ExecuteNonQuery();
                                MessageBox.Show("Cập nhật thành công.", "Thông Báo");
                                loadTacGia();
                            }
                            catch
                            {
                                MessageBox.Show("Cập nhật thất bại.", "Thông Báo Lỗi");
                            }
                        }
                        else
                        {
                            themTacGia();
                            truy_van = "SELECT TOP 1 MaTacGia " +
                                       "FROM TACGIA " +
                                       "ORDER BY MaTacGia DESC ";
                            ket_noi_co_du_lieu(truy_van);
                            txb_MaTG.Text = Convert.ToString(command.ExecuteScalar());
                        }

                        connection.Close();
                        btnLuu.Enabled = true;
                        btnTaoMoi.Enabled = true;
                        btnXoa.Enabled = true;
                        DS_TacGia.Enabled = true;
                        DS_TacGia.FirstDisplayedScrollingRowIndex = DS_TacGia.RowCount - 1;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập tên tác giả", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txb_TenTG.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên tác giả đã tồn tại");
                }
            }
        }

        private void btnXoa_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Bạn chắc chắn muốn xóa tác giả này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string truy_van = "DELETE FROM TACGIA WHERE MaTacGia='" + txb_MaTG.Text + "'";
                        ket_noi_khong_du_lieu(truy_van);
                        MessageBox.Show("Xóa tác giả thành công.", "Thông Báo");
                        btnLuu.Enabled = false;
                        btnXoa.Enabled = false;
                        btnTaoMoi.Enabled = true;
                        isUpdate = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa tác giả thất bại.\nVẫn còn tồn tại sách của tác giả này.", "Thông Báo Lỗi");
                    }
                }
                loadTacGia();
            }
        }

        private void btnTaoMoi_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txb_MaTG.Text = generateNewMaTacGia();
                txb_TenTG.Text = "";
                isUpdate = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }
        }

        private void btnXemVaCapNhat_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                loadTacGia();
            }
        }
    }
}
