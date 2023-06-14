using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Input;
using System.Collections;

namespace Library_Management
{
    public partial class phieuNhapSach : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;
        public phieuNhapSach()
        {
            InitializeComponent();
        }

        private void phieuNhapSach_Load(object sender, EventArgs e)
        {
            loadPhieuNhapSach();
            DS_PNS.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            datetimePNS.Text = "";
            btn_NhapSach.Enabled = false;
            btnXoa.Enabled = false;
            btnChiTiet.Enabled = false;
            btnLuu.Enabled = false;
            txb_MaPNS.Text = generateNewMaPhieuNhapSach();
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

        private void loadPhieuNhapSach()
        {
            string truy_van = "SELECT MaPhieuNhapSach AS [Mã Phiếu Nhập Sách], NgLap AS [Ngày Lập], TongTien AS [Tổng tiền] " +
                              "FROM PHIEUNHAPSACH ";
            DS_PNS.DataSource = ket_noi_co_du_lieu(truy_van);
            connection.Close();
        }

        private string generateNewMaPhieuNhapSach()
        {
            string truy_van = "SELECT TOP 1 MaPhieuNhapSach " +
                              "FROM PHIEUNHAPSACH " +
                              "ORDER BY MaPhieuNhapSach DESC";
            ket_noi_co_du_lieu(truy_van);
            string MaPhieuNhapSachMax = Convert.ToString(command.ExecuteScalar());
            int numberMaPhieuNhapSachMax = Convert.ToInt32(MaPhieuNhapSachMax.Substring(4));
            string strNumber = (++numberMaPhieuNhapSachMax).ToString();
            MaPhieuNhapSachMax = "MTG" + strNumber.PadLeft(3, '0');
            return MaPhieuNhapSachMax;
        }

        private void themPhieuNhapSach()
        {
            try
            {
                string truy_van = "INSERT INTO PHIEUNHAPSACH(NgLap)" +
                "VALUES ('" + datetimePNS.Value.Date.ToString("MM/dd/yyyy") + "')";
                ket_noi_khong_du_lieu(truy_van);
                loadPhieuNhapSach();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Thông Báo Lỗi");
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            // hide form 1
            // this.Hide();
            // create an instace of form 2
            //chiTietPNS f2 = new chiTietPNS();
            //// show form 2
            //f2.ShowDialog(); // it fonna halt/ freeze the excution of click event.
            //// dispose form 2 instance
            //f2 = null;
            ////show form 1 again
            //this.Show();
            btn_NhapSach.Enabled = false;
            btnXoa.Enabled = false;
            btnChiTiet.Enabled = false;
            string query = "DROP TABLE IF EXISTS MAPN " +
                           "CREATE TABLE MAPN(MaPhieuNhap VARCHAR(50)) " +
                           "INSERT INTO MAPN VALUES ('" + txb_MaPNS.Text + "')";
            ket_noi_khong_du_lieu(query);
            chiTietPNS f2 = new chiTietPNS();
            f2.Show();
            f2.FormClosed += (formCTPN_FormClosed);
        }

        private void btnXemVaCapNhat_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                loadPhieuNhapSach();
            }
        }

        private void DS_PNS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaPNS.Text = DS_PNS.CurrentRow.Cells[0].Value.ToString();
            datetimePNS.Text = DS_PNS.CurrentRow.Cells[1].Value.ToString();
            txb_TongTien.Text = DS_PNS.CurrentRow.Cells[2].Value.ToString();
            btn_NhapSach.Enabled = false;
            btnXoa.Enabled = true;
            btnChiTiet.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnXoa_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu nhập này.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string truy_van = "IF EXISTS " +
                                          "(SELECT * " +
                                            "FROM CT_PHIEUNHAP " +
                                            "WHERE MaPhieuNhapSach = '" + txb_MaPNS.Text + "') " +
                                          "BEGIN SELECT 0 END ELSE BEGIN SELECT 1 END";
                        ket_noi_khong_du_lieu(truy_van);
                        int flag = Convert.ToInt32(command.ExecuteScalar());
                        if (flag == 1)
                        {
                            truy_van = "DELETE FROM PHIEUNHAPSACH WHERE MaPhieuNhapSach='" + txb_MaPNS.Text + "'";
                            ket_noi_khong_du_lieu(truy_van);
                            MessageBox.Show("Xóa phiếu nhập thành công.", "Thông Báo");
                            btn_NhapSach.Enabled = false;
                            btnXoa.Enabled = false;
                            btnTaoMoi.Enabled = true;
                            btnChiTiet.Enabled = false;
                        }
                        else
                            MessageBox.Show("Phiếu nhập này có chứa chi tiết phiếu nhập!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại.\nPhiếu nhập này có chứa chi tiết phiếu nhập!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                loadPhieuNhapSach();
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                btn_NhapSach.Enabled = false;
            }
        }

        private void btnTaoMoi_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txb_MaPNS.Text = generateNewMaPhieuNhapSach();
                txb_TongTien.Text = "0.0000";
                datetimePNS.Text = "";
                btnXoa.Enabled = false;
                btn_NhapSach.Enabled = true;
            }
        }

        private void formCTPN_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadPhieuNhapSach();
            for (int i = 0; i < DS_PNS.RowCount; i++)
            {
                if (DS_PNS.Rows[i].Cells[0].Value.ToString() == txb_MaPNS.Text)
                {
                    txb_TongTien.Text = DS_PNS.Rows[i].Cells[2].Value.ToString();
                    break;
                }
            }
        }

        private void btn_NhapSach_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DateTime a = new DateTime();
                a = datetimePNS.Value;
                string[] formattedStrings = a.GetDateTimeFormats();
                if (a > DateTime.Now)
                {
                    MessageBox.Show("Ngày không được vượt quá hôm nay", "Thông Báo Lỗi");
                    return;
                }
                themPhieuNhapSach();
                string truy_van = "SELECT TOP 1 MaPhieuNhapSach " +
                                  "FROM PHIEUNHAPSACH " +
                                  "ORDER BY MaPhieuNhapSach DESC";
                ket_noi_co_du_lieu(truy_van);
                txb_MaPNS.Text = Convert.ToString(command.ExecuteScalar());
                connection.Close();
                btn_NhapSach.Enabled = false;
                btnTaoMoi.Enabled = true;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                truy_van = "DROP TABLE IF EXISTS MAPN " +
                           "CREATE TABLE MAPN(MaPhieuNhap VARCHAR(50)) " +
                           "INSERT INTO MAPN VALUES ('" + txb_MaPNS.Text + "')";
                ket_noi_khong_du_lieu(truy_van);
                chiTietPNS ne = new chiTietPNS();
                ne.Show();
                ne.FormClosed += (formCTPN_FormClosed);
            }
        }

        private void btnLuu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                DateTime a = new DateTime();
                a = datetimePNS.Value;
                string[] formattedStrings = a.GetDateTimeFormats();
                if (a > DateTime.Now) 
                {
                    MessageBox.Show("Ngày không được vượt quá hôm nay", "Thông Báo Lỗi");
                    return;
                }
                string truy_van = "UPDATE PHIEUNHAPSACH " +
                           "SET NgLap = " + datetimePNS.Value.Date.ToString("MM/dd/yyyy") + 
                           "WHERE MaPhieuNhapSach = '" + txb_MaPNS.Text + "'";
                ket_noi_khong_du_lieu(truy_van);
                loadPhieuNhapSach();
                btnLuu.Enabled = false;
                btn_NhapSach.Enabled = false;
                btnXoa.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Thông Báo Lỗi");
            }
        }
    }
}
