using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management.Forms.DocGia
{
    public partial class PhieuThuTien : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table = new DataTable();
        private bool isUpdate = false;
        private int soTienThuCu = 0;
        public PhieuThuTien()
        {
            InitializeComponent();
        }

        void setFormatDMY()
        {
            DS_PhieuThuPhat.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
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

        void loadPhieuThuPhat()
        {
            string truy_van = "SELECT MaPhieuThu AS [Mã Phiếu Thu Phạt], MaDocGia as [Mã Độc Giả], NgThu as [Ngày Thu], format(SoTienThu,'#.') as [Số Tiền Thu], format(conlai,'0.') as [Số Tiền Còn Nợ] " +
                              "FROM PHIEUTHUTIEN";
            DS_PhieuThuPhat.DataSource = ket_noi_co_du_lieu(truy_van);
            connection.Close();
        }

        private void loadMaDocGia()
        {
            string truy_van = "SELECT MaDocGia, HoTen FROM DOCGIA";
            cb_MaDG.DataSource = ket_noi_co_du_lieu(truy_van);
            cb_MaDG.DisplayMember = "MaDocGia";
            cb_MaDG.ValueMember = "HoTen";
            cb_MaDG.SelectedIndex = -1;
        }
        private string generateNewMaPhieuThu()
        {
            string truy_van = "SELECT TOP 1 MaPhieuThu " +
                              "FROM PHIEUTHUTIEN " +
                              "ORDER BY MaPhieuThu DESC";
            ket_noi_co_du_lieu(truy_van);
            string MaPhieuThuMax = "";
            try
            {
                MaPhieuThuMax = Convert.ToString(command.ExecuteScalar());
                int numberMaPhieuThuMax = Convert.ToInt32(MaPhieuThuMax.Substring(3));
                string strNumber = (++numberMaPhieuThuMax).ToString();
                MaPhieuThuMax = "MPT" + strNumber.PadLeft(3, '0');
            }
            catch
            {
                MaPhieuThuMax = "MPT001";
            }
            return MaPhieuThuMax;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (txb_MaPhieuThu.Text == "" || cb_MaDG.Text == "" || txb_SoTienConNo.Text == "" || dtp_NgayThu.Text == "" || txb_SoTienThu.Text == "")
            {
                MessageBox.Show("vui lòng chọn 1 bộ dữ liệu bên dưới để tiến hành in");
            }
            else
            {
                e.Graphics.DrawString("Phiếu Thu Tiền", new Font("Arial", 25, FontStyle.Bold), Brushes.Blue, new Point(320, 80));
                e.Graphics.DrawString(lb_MaDocGia.Text + "             " + cb_MaDG.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 190));
                e.Graphics.DrawString("....................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(332, 196));

                e.Graphics.DrawString(lb_HoTen.Text + "      " + txb_HoTen.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 260));
                e.Graphics.DrawString("..................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(335, 272));

                e.Graphics.DrawString(lb_MaPhieuThu.Text + "    " + txb_MaPhieuThu.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 330));
                e.Graphics.DrawString(".....................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(315, 340));

                e.Graphics.DrawString(lb_NgayThu.Text + "            " + dtp_NgayThu.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 400));
                e.Graphics.DrawString(".........................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(290, 410));

                e.Graphics.DrawString(lb_TongNo.Text + "        " + txb_TongNo.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 470));
                e.Graphics.DrawString(".......................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(290, 476));

                e.Graphics.DrawString(lb_SoTienThu.Text + "        " + txb_SoTienThu.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 530));
                e.Graphics.DrawString("...................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(315, 540));
                
                e.Graphics.DrawString(lb_SoTienConNo.Text + "        " + txb_SoTienConNo.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 600));
                e.Graphics.DrawString("............................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(345, 610));

                e.Graphics.DrawString("Độc giả", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(110, 700));
                e.Graphics.DrawString("(Ký ghi rõ họ tên)", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(105, 735));
                e.Graphics.DrawString("Người lập phiếu thu", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(550, 700));
                e.Graphics.DrawString("(Ký ghi rõ họ tên)", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(565, 735));
            }
        }


        private void PhieuThuTien_Load(object sender, EventArgs e)
        {
            loadPhieuThuPhat();
            setFormatDMY();
            loadMaDocGia();
            cb_MaDG.SelectedIndex = -1;
            txb_MaPhieuThu.Text = generateNewMaPhieuThu();
            txb_HoTen.Text = "";
            btn_In.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void txb_SoTienThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnXoa_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    string truy_van = "";
                    float tienThuPhieuXoa = float.Parse(txb_SoTienThu.Text);
                    truy_van = "UPDATE DOCGIA SET TongNo += " + tienThuPhieuXoa + "WHERE MaDocGia = '" + cb_MaDG.Text + "'";
                    ket_noi_khong_du_lieu(truy_van);

                    truy_van = "DELETE PHIEUTHUTIEN WHERE MaPhieuThu = '" + txb_MaPhieuThu.Text + "'";
                    ket_noi_khong_du_lieu(truy_van);
                    loadPhieuThuPhat();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void DS_PhieuThuPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaPhieuThu.Text = DS_PhieuThuPhat.CurrentRow.Cells[0].Value.ToString();
            cb_MaDG.Text = DS_PhieuThuPhat.CurrentRow.Cells[1].Value.ToString();
            dtp_NgayThu.Text = DS_PhieuThuPhat.CurrentRow.Cells[2].Value.ToString();
            txb_SoTienThu.Text = DS_PhieuThuPhat.CurrentRow.Cells[3].Value.ToString();
            soTienThuCu = Int32.Parse(DS_PhieuThuPhat.CurrentRow.Cells[3].Value.ToString());
            txb_SoTienConNo.Text = DS_PhieuThuPhat.CurrentRow.Cells[4].Value.ToString(); ;
            txb_TongNo.Text = (float.Parse(txb_SoTienConNo.Text) + float.Parse(txb_SoTienThu.Text)).ToString();
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            btn_In.Enabled = true;
            isUpdate = true;
        }

        private void cb_MaDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MaDG.SelectedIndex >= 0)
            {
                string truy_van = "SELECT TongNo " +
                                  "FROM DOCGIA " +
                                  "WHERE MaDocGia ='" + cb_MaDG.Text + "' ";
                ket_noi_co_du_lieu(truy_van);
                string tongno = Convert.ToString(command.ExecuteScalar());

                txb_TongNo.Text = tongno;
                txb_HoTen.Text = cb_MaDG.SelectedValue.ToString();
                txb_SoTienThu.Text = "";
                dtp_NgayThu.Value = DateTime.Now;
                btn_In.Enabled = false;
            }
        }

        private void btnTaoMoi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button  == MouseButtons.Left)
            {
                txb_MaPhieuThu.Text = generateNewMaPhieuThu();
                cb_MaDG.SelectedIndex = -1;
                txb_HoTen.Text = "";
                txb_SoTienThu.Text = "";
                txb_SoTienConNo.Text = "";
                txb_TongNo.Text = "";
                dtp_NgayThu.Value = DateTime.Now;
                isUpdate = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }
        }

        private void btn_In_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show("Tính năng đang phát triển");
                printPreviewDialog1.Height = this.Height;
                printPreviewDialog1.Width = this.Width;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void btnLuu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!isUpdate)
                {
                    DateTime a = new DateTime();
                    a = dtp_NgayThu.Value;
                    string[] formattedStrings = a.GetDateTimeFormats();

                    if (cb_MaDG.Text == "" || txb_SoTienThu.Text == "" || dtp_NgayThu.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                        return;
                    }
                    else if (Int32.Parse(txb_SoTienThu.Text) <= 0)
                    {
                        MessageBox.Show("Số tiền thu phải là số dương", "Thông báo lỗi");
                        return;
                    }
                    else if (a > DateTime.Now)
                    {
                        MessageBox.Show("Ngày không được vượt quá hôm nay", "Thông báo lỗi");
                        return;
                    }
                    else
                    {
                        float k = float.Parse(txb_TongNo.Text) - float.Parse(txb_SoTienThu.Text);
                        if (k < 0)
                        {
                            MessageBox.Show("Số tiền thu không được lớn hơn số tiền nợ của độc giả", "Thông báo lỗi");
                            txb_SoTienThu.Text = "";
                            return;
                        }
                        else
                        {
                            string truy_van = "insert into PhieuThuTien (MaDocGia,NgThu,SoTienThu,ConLai) values ('" + cb_MaDG.Text + "','" + formattedStrings[6] + "','" + float.Parse(txb_SoTienThu.Text) + "','" + k + "')";
                            ket_noi_khong_du_lieu(truy_van);
                            MessageBox.Show("Hoàn tất thu phạt", "Thông báo");
                            loadPhieuThuPhat();
                            truy_van = "update docgia set TongNo-='" + float.Parse(txb_SoTienThu.Text) + "' where madocgia='" + cb_MaDG.Text + "'";
                            txb_SoTienConNo.Text = (float.Parse(txb_TongNo.Text) - float.Parse(txb_SoTienThu.Text)).ToString();
                            ket_noi_khong_du_lieu(truy_van);
                            connection.Close();
                        }
                    }
                }
                else
                {
                    DateTime a = new DateTime();
                    a = dtp_NgayThu.Value;
                    string[] formattedStrings = a.GetDateTimeFormats();

                    if (cb_MaDG.Text == "" || txb_SoTienThu.Text == "" || dtp_NgayThu.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                        return;
                    }
                    else if (Int32.Parse(txb_SoTienThu.Text) <= 0)
                    {
                        MessageBox.Show("Số tiền thu phải là số dương", "Thông báo lỗi");
                        return;
                    }
                    else if (a > DateTime.Now)
                    {
                        MessageBox.Show("Ngày không được vượt quá hôm nay", "Thông báo lỗi");
                        return;
                    }
                    else
                    {
                        float tongno = float.Parse(txb_TongNo.Text) + soTienThuCu;
                        txb_TongNo.Text = tongno.ToString();
                        string truy_van = "UPDATE DOCGIA " +
                                              "SET TongNo = " + txb_TongNo.Text +
                                              "WHERE MaDocGia = '" + cb_MaDG.Text + "'";
                        ket_noi_khong_du_lieu(truy_van);
                        float k = tongno - float.Parse(txb_SoTienThu.Text);
                        if (k < 0)
                        {
                            MessageBox.Show("Số tiền thu không được lớn hơn số tiền nợ của độc giả", "Thông báo lỗi");
                            txb_SoTienThu.Text = "";
                            tongno = float.Parse(txb_TongNo.Text) - soTienThuCu;
                            txb_TongNo.Text = tongno.ToString();
                            truy_van = "UPDATE DOCGIA " +
                                       "SET TongNo = " + txb_TongNo.Text +
                                       "WHERE MaDocGia = '" + cb_MaDG.Text + "'";
                            ket_noi_khong_du_lieu(truy_van);
                        }
                        else
                        {
                            string query = "UPDATE PHIEUTHUTIEN " +
                                              "SET SoTienThu = " + txb_SoTienThu.Text + 
                                              "WHERE MaPhieuThu = '" + txb_MaPhieuThu.Text + "'";
                            ket_noi_khong_du_lieu(query);
                            query = "update docgia set TongNo-='" + float.Parse(txb_SoTienThu.Text) + "' where madocgia='" + cb_MaDG.Text + "'";
                            ket_noi_khong_du_lieu(query);
                            txb_SoTienConNo.Text = (float.Parse(txb_TongNo.Text) - float.Parse(txb_SoTienThu.Text)).ToString();
                            query = "UPDATE PHIEUTHUTIEN " +
                                              "SET ConLai = " + txb_SoTienConNo.Text +
                                              "WHERE MaPhieuThu = '" + txb_MaPhieuThu.Text + "'";
                            ket_noi_khong_du_lieu(query);
                            query = "UPDATE PHIEUTHUTIEN " +
                                              "SET NgThu = '" + formattedStrings[6] + "'" +
                                              "WHERE MaPhieuThu = '" + txb_MaPhieuThu.Text + "'";
                            ket_noi_khong_du_lieu(query);
                            connection.Close();
                            btnLuu.Enabled = false;
                            btnXoa.Enabled = false;
                            loadPhieuThuPhat();
                            MessageBox.Show("Hoàn tất cập nhật", "Thông báo");
                        }
                    }
                }
                btnLuu.Enabled = false;
                btn_In.Enabled = true;
            }
        }

        private void txb_SoTienThu_TextChanged(object sender, EventArgs e)
        {
            if (btn_In.Enabled == true)
                btn_In.Enabled = false;
        }

        private void dtp_NgayThu_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_NgayThu.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày không được vượt quá hôm nay", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
