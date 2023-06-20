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
    public partial class FormTuyChinh : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table = new DataTable();
        string str = $@"{Library_Management.Models.Database.connectionStr}";
        SqlDataAdapter adapter = new SqlDataAdapter();
        string DG = "";
        public FormTuyChinh()
        {
            InitializeComponent();
        }


        void loadQD()
        {
            //disableSortHeader();
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select ThoiHanThe,TuoiToiThieu,TuoiToiDa,ThoiGianLuuHanh,SoNgayMuonMax,SoSachMuonMax,format(MucThuTienPhat,'#.') from ThamSo ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            string s = "";
            s += table.Rows[0].ItemArray[0].ToString();

            s += " tháng";

            lbthoihan.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[3].ToString();
            s += " năm";
            lbLuuHanh.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[2].ToString();
            s += " tuổi";
            lbTuoiMax.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[1].ToString();
            s += " tuổi";
            lbTuoiMin.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[4].ToString();
            s += " ngày";
            lbNgayMax.Text = s;
            s = "";
            s += table.Rows[0].ItemArray[5].ToString();
            s += " cuốn";
            lbSachMax.Text = s;

            s = "";
            s += table.Rows[0].ItemArray[6].ToString();
            s += " đồng";
            lbTien.Text = s;
        }

        private void FormTuyChinh_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();

            loadQD();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txbSoNgayMuonMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbSoNgayMuonMax.Text) == 0)
                {
                    MessageBox.Show("Số Ngày mượn tối đa không được bằng 0", "Thông báo");
                    txbSoNgayMuonMax.Text = "";
                }
            }
            catch
            { }
        }

        private void txbThoiHanThe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbThoiHanThe.Text) == 0)
                {
                    MessageBox.Show("Giá Trị của thời gian thẻ không được bằng 0", "Thông báo");
                    txbThoiHanThe.Text = "";
                }
            }
            catch
            { }
        }

        private void txbThoiGianLuuHanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbThoiGianLuuHanh.Text) == 0)
                {
                    MessageBox.Show("Thời gian lưu hành của sách không được bằng 0", "Thông báo"); txbThoiGianLuuHanh.Text = "";
                }
            }
            catch
            { }
        }

        private void txbTuoiToiDa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbTuoiToiDa.Text) == 0)
                {
                    MessageBox.Show("Tuổi tối đa của độc giả mượn sách không được bằng 0", "Thông báo"); txbTuoiToiDa.Text = "";
                }
            }
            catch
            { }
        }

        private void txbSoSachMuonMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbSoSachMuonMax.Text) == 0)
                {
                    MessageBox.Show("Số sách mượn tối đa không được phép bằng 0", "Thông báo"); txbSoSachMuonMax.Text = "";
                }
            }
            catch
            { }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txbMucThuTienPhat.Text != "" || txbSoNgayMuonMax.Text != "" || txbSoSachMuonMax.Text != "" || txbThoiGianLuuHanh.Text != "" || txbThoiHanThe.Text != "" || txbTuoiToiDa.Text != "" || txbTuoiToiThieu.Text != "")
            {

                if (txbThoiHanThe.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set ThoiHanThe='" + txbThoiHanThe.Text + "' ";
                    command.ExecuteNonQuery();
                }
                if (txbThoiGianLuuHanh.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set ThoiGianLuuHanh='" + txbThoiGianLuuHanh.Text + "' ";
                    command.ExecuteNonQuery();
                }
                if (txbTuoiToiDa.Text != "")
                {
                    DataTable a = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select Tuoitoithieu from thamso";
                    adapter.SelectCommand = command;
                    a.Clear();
                    adapter.Fill(a);
                    if (int.Parse(a.Rows[0].ItemArray[0].ToString()) > int.Parse(txbTuoiToiDa.Text))
                    {
                        MessageBox.Show("Quy định về tuổi tối đa không được phép nhỏ hơn tuổi tối thiểu", "Thông báo");
                        i = 1;
                    }
                    else
                    {
                        command = connection.CreateCommand();
                        command.CommandText = "update Thamso set TuoiToiDa='" + txbTuoiToiDa.Text + "' ";
                        command.ExecuteNonQuery();

                    }
                }
                if (txbTuoiToiThieu.Text != "")
                {
                    DataTable b = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select TuoiToiDa from thamso";
                    adapter.SelectCommand = command;
                    b.Clear();
                    adapter.Fill(b);
                    if (int.Parse(b.Rows[0].ItemArray[0].ToString()) < int.Parse(txbTuoiToiThieu.Text))
                    {
                        MessageBox.Show("Quy định về tuổi tối đa không được phép nhỏ hơn tuổi tối thiểu", "Thông báo");
                        i = 1;
                    }
                    else if (txbTuoiToiThieu.Text == "0")
                    {
                        MessageBox.Show("Quy định về tuổi tối thiểu phải lơn hơn 0", "Thông báo");
                        i = 1;
                    }
                    else
                    {
                        command = connection.CreateCommand();
                        command.CommandText = "update Thamso set TuoiToiThieu='" + txbTuoiToiThieu.Text + "' ";
                        command.ExecuteNonQuery();
                    }
                }
                if (txbSoNgayMuonMax.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set SoNgayMuonMax='" + txbSoNgayMuonMax.Text + "' ";
                    command.ExecuteNonQuery();
                }
                if (txbSoSachMuonMax.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set SoSachMuonMax='" + txbSoSachMuonMax.Text + "' ";
                    command.ExecuteNonQuery();
                }
                if (txbMucThuTienPhat.Text != "")
                {
                    if (txbMucThuTienPhat.Text != "0")
                    {
                        command = connection.CreateCommand();
                        command.CommandText = "update Thamso set MucThuTienPhat='" + double.Parse(txbMucThuTienPhat.Text) + "' ";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Quy định số tiền phạt không được bé hơn hoặc bằng 0đ!", "Thông báo");
                        txbMucThuTienPhat.Text = "";
                        return;
                    }
                }
                txbThoiHanThe.Text = "";
                txbThoiGianLuuHanh.Text = "";
                txbTuoiToiDa.Text = "";
                txbSoNgayMuonMax.Text = "";
                txbTuoiToiThieu.Text = "";
                txbSoSachMuonMax.Text = "";
                txbMucThuTienPhat.Text = "";
                if (i == 0)
                    MessageBox.Show("Cập nhật quy định thành công", "Thông báo");
                loadQD();
            }
            else
                MessageBox.Show("Tất Cả Các ô đều đang trống, không thể cập nhật", "Thông báo");

        }

        private void txbTuoiToiThieu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbTuoiToiDa.Text) == 0)
                {
                    MessageBox.Show("Tuổi tối thiểu của độc giả mượn sách không được bằng 0", "Thông báo"); txbTuoiToiDa.Text = "";
                }
            }
            catch
            { }
        }
    }
}
