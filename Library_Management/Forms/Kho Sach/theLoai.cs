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

namespace Library_Management
{
    public partial class theLoai : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;
        private bool isUpdate = false;
        public theLoai()
        {
            InitializeComponent();
        }

        private void theLoai_Load(object sender, EventArgs e)
        {
            loadTheLoai();
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnTaoMoi.Enabled = true;
        }

        private DataTable connect(string query)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(query, connection);
            dataAdapter = new SqlDataAdapter(command);
            table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        private void connectNonQuery(string query)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        private void loadTheLoai()
        {
            string query = "SELECT MaTheLoai AS [Mã Thể Loại], TenTheLoai AS [Tên Thể Loại]" +
                              "FROM THELOAI";
            DS_TheLoai.DataSource = connect(query);
            connection.Close();
        }

        private string generateNewMaTheLoai()
        {
            string query = "SELECT TOP 1 MaTheLoai FROM THELOAI ORDER BY MaTheLoai DESC";
            connect(query);
            string MaTheLoaiMax = Convert.ToString(command.ExecuteScalar());
            int numberMaTheLoaiMax = Convert.ToInt32(MaTheLoaiMax.Substring(3));
            string strNumber = (++numberMaTheLoaiMax).ToString();
            MaTheLoaiMax = "MTL" + strNumber.PadLeft(3, '0');
            return MaTheLoaiMax;
        }
        private void themTheLoai()
        {
            try
            {
                string query = "INSERT INTO THELOAI(TenTheLoai)" +
                                     "VALUES (N'" + txb_TenTL.Text + "')";
                connectNonQuery(query);
                MessageBox.Show("Thêm thể loại thành công.", "Thông Báo");
                loadTheLoai();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Thông Báo Lỗi");
            }
        }

        private void btnXemVaCapNhat_Click(object sender, EventArgs e)
        {
            loadTheLoai();
        }

        private void DS_TheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaTL.Text = DS_TheLoai.CurrentRow.Cells[0].Value.ToString();
            txb_TenTL.Text = DS_TheLoai.CurrentRow.Cells[1].Value.ToString();
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            isUpdate = true;
        }

        private void btnTaoMoi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txb_MaTL.Text = generateNewMaTheLoai();
                txb_TenTL.Text = "";
                isUpdate = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }
        }

        private void btnXoa_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Bạn chắc chắn muốn xóa thể loại này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM THELOAI WHERE MaTheLoai='" + txb_MaTL.Text + "'";
                        connectNonQuery(query);
                        MessageBox.Show("Xóa thể loại thành công.", "Thông Báo");
                        btnLuu.Enabled = false;
                        btnXoa.Enabled = false;
                        btnTaoMoi.Enabled = true;
                        isUpdate = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thể loại thất bại.\nVẫn còn tồn tại sách của thể loại này.", "Thông Báo Lỗi");
                    }
                }
                loadTheLoai();
            }
        }

        private void btnLuu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int flag = 0;
                for (int i = 0; i < DS_TheLoai.RowCount; i++)
                {
                    if (txb_TenTL.Text.ToUpper() == DS_TheLoai.Rows[i].Cells[1].Value.ToString().ToUpper())
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    {
                        if (txb_TenTL.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập tên thể loại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (txb_TenTL.Text.Length > 0)
                    {
                        string query = null;
                        if (isUpdate)
                        {
                            try
                            {
                                query = "UPDATE THELOAI " +
                                           "SET TenTheLoai = N'" + txb_TenTL.Text + "'" +
                                           "WHERE MaTheLoai = '" + txb_MaTL.Text + "'";
                                connect(query);
                                command.ExecuteNonQuery();
                                MessageBox.Show("Cập nhật thành công.", "Thông Báo");
                                loadTheLoai();
                            }
                            catch
                            {
                                MessageBox.Show("Cập nhật thất bại.", "Thông Báo Lỗi");
                            }
                        }
                        else
                        {
                            themTheLoai();
                            query = "SELECT TOP 1 MaTheLoai " +
                                       "FROM THELOAI " +
                                       "ORDER BY MaTheLoai DESC ";
                            connect(query);
                            txb_MaTL.Text = Convert.ToString(command.ExecuteScalar());
                        }

                        connection.Close();
                        btnLuu.Enabled = true;
                        btnTaoMoi.Enabled = true;
                        btnXoa.Enabled = true;
                        DS_TheLoai.Enabled = true;
                        DS_TheLoai.FirstDisplayedScrollingRowIndex = DS_TheLoai.RowCount - 1;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập tên thể loại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txb_TenTL.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên thể loại đã tồn tại");
                }
            }
        }
    }
}
