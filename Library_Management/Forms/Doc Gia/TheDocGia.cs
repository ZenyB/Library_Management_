using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;

namespace Library_Management.Forms.DocGia
{
    public partial class TheDocGia : Form
    {
        string connectionStr = $@"{Library_Management.Models.Database.connectionStr}";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand command;
        private DataTable table;
        public bool isUpdate = false;

        public string maDG, tenDG, email, ngaySinhDG, diaChiDG, loaiDG, NgLapThe;
        public TheDocGia()
        {
            InitializeComponent();

            foreach (DataGridViewColumn col in DS_DocGia.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            DS_DocGia.EnableHeadersVisualStyles = false;
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

        private void setSizeCol()
        {
            DS_DocGia.Columns[0].Width = 80;
            DS_DocGia.Columns[1].Width = 210;
            DS_DocGia.Columns[2].Width = 110;
            DS_DocGia.Columns[3].Width = 120;
            DS_DocGia.Columns[4].Width = 130;
            DS_DocGia.Columns[5].Width = 230;
            DS_DocGia.Columns[6].Width = 120;
            DS_DocGia.Columns[7].Width = 120;
        }

        private void DS_DocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_MaDG.Text = DS_DocGia.CurrentRow.Cells[0].Value.ToString();
            txb_HoTen.Text = DS_DocGia.CurrentRow.Cells[1].Value.ToString();
            cbb_LoaiDG.Text = DS_DocGia.CurrentRow.Cells[2].Value.ToString();
            dtp_NgaySinh.Text = DS_DocGia.CurrentRow.Cells[3].Value.ToString();
            txb_DiaChi.Text = DS_DocGia.CurrentRow.Cells[4].Value.ToString();
            txb_Email.Text = DS_DocGia.CurrentRow.Cells[5].Value.ToString();
            dtp_NgayLapThe.Text = DS_DocGia.CurrentRow.Cells[6].Value.ToString();
            txtb_NgayHetHan.Text = tranferFormatTextBox(DS_DocGia.CurrentRow.Cells[7].Value.ToString());
            txb_TongNo.Text = DS_DocGia.CurrentRow.Cells[8].Value.ToString();
            btnLuu.Enabled = false;
            btnTaoMoi.Enabled = true;
            btnXoa.Enabled = true;
            btn_In.Enabled = true;
            isUpdate = false;
        }

        public bool checkIsMail(string email)
        {
            string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reg = new Regex(match);
            return reg.IsMatch(email);
        }

        void setFormatDMY()
        {
            DS_DocGia.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            DS_DocGia.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            DS_DocGia.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        void loadLoaiDG()
        {
            string cauTruyVan = "SELECT TenLoaiDocGia FROM LOAIDOCGIA";
            cbb_LoaiDG.DataSource = connect(cauTruyVan);
            cbb_LoaiDG.DisplayMember = "TenLoaiDocGia";
            cbb_LoaiDG.SelectedIndex = -1;
        }

        string tranferFormatTextBox(string s)
        {
            DateTime temp;
            temp = Convert.ToDateTime(s);
            return temp.ToString("dd/MM/yyyy");
        }

        private string getNextIdDG()
        {
            string queryGetId = "SELECT TOP 1 MaDocGia FROM DOCGIA ORDER BY MaDocGia DESC";
            connect(queryGetId);
            string fullID = Convert.ToString(command.ExecuteScalar());
            int numberID = Convert.ToInt32(fullID.Substring(2));
            string strNumber = (++numberID).ToString();
            fullID = "DG" + strNumber.PadLeft(3, '0');
            return fullID;
        }

        void loadDS_DocGia()
        {
            string cauTruyVan = "SELECT MaDocGia AS [Mã ĐG], HoTen AS [Tên ĐG], TenLoaiDocGia AS [Loại ĐG], NgSinh AS [Ngày Sinh], DChi AS [Địa Chỉ], Email AS [Email], NgLapThe AS [N.Lập Thẻ], NgHetHan AS [N.Hết Hạn], TongNo AS [Tổng Nợ] " +
               "FROM dbo.DOCGIA, dbo.LOAIDOCGIA " +
               "WHERE DOCGIA.MaLoaiDocGia = dbo.LOAIDOCGIA.MaLoaiDocGia";
            DS_DocGia.DataSource = connect(cauTruyVan);
            DS_DocGia.AutoGenerateColumns = false;
            connection.Close();
        }

        public string SaveStringSQL(string pQuery)
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();
            string thuchiencaulenh = pQuery;
            command = new SqlCommand(thuchiencaulenh, connection);
            var SavedString = (string)command.ExecuteScalar();
            return SavedString;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txb_MaDG.Text = getNextIdDG();
            txb_HoTen.Text = "";
            txb_Email.Text = "";
            txb_DiaChi.Text = "";
            dtp_NgaySinh.Text = "";
            cbb_LoaiDG.SelectedItem = null;
            dtp_NgayLapThe.Text = "";
            txtb_NgayHetHan.Text = "";
            txb_TongNo.Text = "0.0000";
            txb_HoTen.Focus();
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            isUpdate = false;
            dtp_NgayLapThe_ValueChanged(this, e);
            isUpdate = true;
        }

        private void addDocGia()
        {
            string queryMLDG = "SELECT MaLoaiDocGia FROM LOAIDOCGIA WHERE TenLoaiDocGia = N'" + cbb_LoaiDG.Text + "'";
            connect(queryMLDG);
            string maLDG = Convert.ToString(command.ExecuteScalar());

            try
            {

                string themdongsql = "INSERT INTO DOCGIA(HoTen, MaLoaiDocGia, NgSinh, DChi, Email, NgLapThe, TongNo)" +
                "VALUES (N'" + txb_HoTen.Text + "', '" + maLDG + "', '" + dtp_NgaySinh.Value.Date.ToString("MM/dd/yyyy") + "', N'" + txb_DiaChi.Text + "', '" + txb_Email.Text + "', '" + dtp_NgayLapThe.Value.Date.ToString("MM/dd/yyyy") + "', 0)";
                connectNonQuery(themdongsql);
                MessageBox.Show("Thêm thành công.", "Thông Báo");
                loadDS_DocGia();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error");
            }
        }

        private void updateDocGia()
        {
            isUpdate = true;
            {
                if (txb_HoTen.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Tên DG", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (txb_Email.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Email", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                if (!checkIsMail(txb_Email.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                if (txb_DiaChi.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

                if (cbb_LoaiDG.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Loại DG", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (txb_HoTen.Text.Length > 0 && txb_DiaChi.Text.Length > 0 && txb_Email.Text.Length > 0 && dtp_NgaySinh.Text.Length > 0 && cbb_LoaiDG.Text.Length > 0 && dtp_NgayLapThe.Text.Length > 0)
            {
                string query = "SELECT TuoiToiThieu FROM THAMSO ";
                connect(query);
                int tuoiMin = Convert.ToInt32(command.ExecuteScalar());

                query = "SELECT TuoiToiDa FROM THAMSO";
                connect(query);
                int tuoiMax = Convert.ToInt32(command.ExecuteScalar());

                string[] nam = dtp_NgaySinh.Text.Split('/');
                int NamSinh = Convert.ToInt32(nam[2]);
                int tuoi = DateTime.Now.Year - NamSinh;

                if (tuoi < tuoiMin || tuoi > tuoiMax)
                {
                    MessageBox.Show("Số tuổi không hợp lệ!");
                    return;
                }


                if (isUpdate == true)
                {
                    try
                    {
                        string queryMLDG = "SELECT MaLoaiDocGia FROM LOAIDOCGIA WHERE TenLoaiDocGia = N'" + cbb_LoaiDG.Text + "'";
                        connect(queryMLDG);
                        string maLDG = Convert.ToString(command.ExecuteScalar());
                        string capnhatdongsql;
                        capnhatdongsql = "UPDATE DOCGIA " +
                            "SET HoTen = N'" + txb_HoTen.Text + "', MaLoaiDocGia = '" + maLDG + "', NgSinh = '" + dtp_NgaySinh.Value.Date.ToString("MM/dd/yyyy") + "', DChi = N'" + txb_DiaChi.Text + "', Email = '" + txb_Email.Text + "', NgLapThe = '" + dtp_NgayLapThe.Value.Date.ToString("MM/dd/yyyy") + "', TongNo = 0 " +
                            "WHERE MaDocGia = '" + txb_MaDG.Text + "'";
                        connect(capnhatdongsql);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sửa thành công.", "Thông Báo");
                        loadDS_DocGia();
                    }
                    catch
                    {
                        MessageBox.Show("Sửa thất bại.\nVui lòng kiểm tra lại dữ liệu.", "Thông Báo");
                    }
                }

                btnLuu.Enabled = false;
                btnTaoMoi.Enabled = true;
                btnXoa.Enabled = true;
                DS_DocGia.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông Báo");
                if (txb_HoTen.Text.Length == 0)
                    txb_HoTen.Focus();
                else if (txb_DiaChi.Text.Length == 0)
                    txb_DiaChi.Focus();
                else if (txb_Email.Text.Length == 0)
                    txb_Email.Focus();

            }
        }

        private void add_DocGia()
        {
            isUpdate = false;
            {
                if (txb_HoTen.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Tên DG", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (txb_Email.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Email", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (!checkIsMail(txb_Email.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (txb_DiaChi.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                if (cbb_LoaiDG.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Loại DG", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (txb_HoTen.Text.Length > 0 && txb_DiaChi.Text.Length > 0 && dtp_NgaySinh.Text.Length > 0 && cbb_LoaiDG.Text.Length > 0 && dtp_NgayLapThe.Text.Length > 0)
            {
                string query = "SELECT TuoiToiThieu FROM THAMSO ";
                connect(query);
                int tuoiMin = Convert.ToInt32(command.ExecuteScalar());

                query = "SELECT TuoiToiDa FROM THAMSO";
                connect(query);
                int tuoiMax = Convert.ToInt32(command.ExecuteScalar());

                string[] nam = dtp_NgaySinh.Value.ToString("dd/MM/yyyy").Split('/');
                int NamSinh = Convert.ToInt32(nam[2]);
                int tuoi = DateTime.Now.Year - NamSinh;

                if (tuoi < tuoiMin || tuoi > tuoiMax)
                {
                    MessageBox.Show("Số tuổi không hợp lệ!");
                    return;
                }

                if (isUpdate == false)
                {
                    addDocGia();
                    query = "SELECT TOP 1 MaDocGia FROM DOCGIA ORDER BY MaDocGia DESC ";
                    connect(query);
                    txb_MaDG.Text = Convert.ToString(command.ExecuteScalar());
                    query = "SELECT NgHetHan FROM DOCGIA WHERE MaDocGia = '" + txb_MaDG.Text + "'"; ;
                    connect(query);
                    txtb_NgayHetHan.Text = tranferFormatTextBox(Convert.ToString(command.ExecuteScalar()));
                    txb_TongNo.Text = "0.0000";
                }

                DS_DocGia.AutoGenerateColumns = false;
                connection.Close();
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                DS_DocGia.Enabled = true;
                DS_DocGia.FirstDisplayedScrollingRowIndex = DS_DocGia.RowCount - 1;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông Báo");
                if (txb_HoTen.Text.Length == 0)
                    txb_HoTen.Focus();
                else if (txb_DiaChi.Text.Length == 0)
                    txb_DiaChi.Focus();
                else if (txb_Email.Text.Length == 0)
                    txb_Email.Focus();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            add_DocGia();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (txb_MaDG.Text == "" || txb_HoTen.Text == "" || txtb_NgayHetHan.Text == "" || dtp_NgayLapThe.Text == "" || dtp_NgaySinh.Text == "" || cbb_LoaiDG.Text == "")
            {
                MessageBox.Show("vui lòng chọn 1 bộ dữ liệu bên dưới để tiến hành in");
            }
            else
            {
                e.Graphics.DrawString("Thẻ Độc Giả", new Font("Arial", 25, FontStyle.Bold), Brushes.Blue, new Point(320, 80));
                e.Graphics.DrawString(lb_MaDocGia.Text + " " + txb_MaDG.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 190));
                e.Graphics.DrawString("....................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(332, 196));

                e.Graphics.DrawString(lb_HoTen.Text + "      " + txb_HoTen.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 260));
                e.Graphics.DrawString(".......................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(300, 272));

                e.Graphics.DrawString(lb_NgaySinh.Text + "    " + dtp_NgaySinh.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 330));
                e.Graphics.DrawString(".....................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(315, 340));

                e.Graphics.DrawString(lb_NgayLapThe.Text + "            " + dtp_NgayLapThe.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 400));
                e.Graphics.DrawString(".........................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(290, 410));

                e.Graphics.DrawString(lb_NgayHetHan.Text + "        " + txtb_NgayHetHan.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(150, 470));
                e.Graphics.DrawString(".......................................................................", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(290, 476));
                e.Graphics.DrawString("Độc giả", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(90, 700));
                e.Graphics.DrawString("(Ký ghi rõ họ tên)", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(105, 735));
                e.Graphics.DrawString("Người Lập thẻ", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(550, 700));
                e.Graphics.DrawString("(Ký ghi rõ họ tên)", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(565, 735));
            }
        }


        private void btn_In_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Height = this.Height;
            printPreviewDialog1.Width = this.Width;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void dtp_NgayLapThe_ValueChanged(object sender, EventArgs e)
        {
            string query = "SELECT ThoiHanThe FROM THAMSO ";
            connect(query);
            int ThoiHanThe = Convert.ToInt32(command.ExecuteScalar());
            DateTime ngLapThe = dtp_NgayLapThe.Value.Date;
            DateTime ngHetHan = ngLapThe.AddMonths(ThoiHanThe);
            txtb_NgayHetHan.Text = tranferFormatTextBox(ngHetHan.ToString());
        }

        private void TheDocGia_Load(object sender, EventArgs e)
        {
            loadDS_DocGia();
            DS_DocGia.Enabled = true;
            btnLuu.Enabled = true;
            btnTaoMoi.Enabled = true;
            btn_In.Enabled = true;
            btnXoa.Enabled = false;
            txb_TongNo.Text = "0.0000";
            txb_MaDG.Text = getNextIdDG();
            dtp_NgayLapThe_ValueChanged(this, e);
            setFormatDMY();
            loadLoaiDG();
            setSizeCol();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            removeDG();
        }

        private void removeDG()
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn chắc chắn muốn xóa.", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    string xoadongsql = "DELETE FROM DOCGIA WHERE MaDocGia='" + txb_MaDG.Text + "'";
                    connectNonQuery(xoadongsql);
                    MessageBox.Show("Xóa thành công.", "Thông Báo");
                    btnLuu.Enabled = true;
                    btnXoa.Enabled = false;
                    btnTaoMoi.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thất bại.\nĐộc Giả này đang mượn sách.", "Thông Báo");
                }
            }
            loadDS_DocGia();
        }
    }
}
