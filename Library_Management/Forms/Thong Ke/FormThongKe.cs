using Library_Management.Models;
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
using static System.Net.WebRequestMethods;

namespace Library_Management
{
    public partial class FormThongKe : Form
    {
        List <ReportByCategory> reportByCategory;
        List <ReportLate> reportLate;

        BindingSource binding;
        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            reportByCategory = new List<ReportByCategory>();
            reportLate = new List<ReportLate>();

            binding = new BindingSource();

            cbbReportType.SelectedIndex = 0;
            dtpTime.Value = DateTime.Now.AddMonths(-13);
            CategoryReport();
            //lbTitle.Location = new Point((this.Width - lbTitle.Width) / 2, lbTitle.Location.Y);
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            //lbInform.Visible = false;
            if (cbbReportType.SelectedIndex == 0)
            {
                CategoryReport();
            }
            else
            {
                LateReport();
            }
        }

        private void CategoryReport()
        {
            //ChangeDS_ThongKeLayout(1);

            reportByCategory.Clear();

            string categoryReportCmd = $@"SELECT TenTheLoai AS [Tên Thể Loại], COUNT(THELOAI.MaTheLoai) AS [So Luot Muon]
                FROM THELOAI, CUONSACH, SACH, DAUSACH, PHIEUMUON, CTPHIEUMUON
                WHERE CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach AND CUONSACH.MaSach = SACH.MaSach
		                AND SACH.MaDauSach = DAUSACH.MaDauSach AND DAUSACH.MaTheLoai = THELOAI.MaTheLoai
			                AND CTPHIEUMUON.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
				                AND MONTH(NgMuon) = {dtpTime.Value.Month.ToString()}
                GROUP BY TenTheLoai, THELOAI.MaTheLoai
                ORDER BY [So Luot Muon] DESC";

            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(categoryReportCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    reportByCategory.Add(new ReportByCategory(reader.GetString(0), reader.GetInt32(1)));
                }
            }
            conn.Close();
            int stt = 1;
            float totalNumOfBorrowings = 0;
            foreach (ReportByCategory report in reportByCategory)
            {
                report.stt = stt;
                totalNumOfBorrowings += report.numsOfBorrowings;
                stt++;
            }

            lbTotalBorrow.Text = totalNumOfBorrowings.ToString();

            foreach (ReportByCategory report in reportByCategory)
            {
                report.rate = $"{(Math.Round(((float)report.numsOfBorrowings / totalNumOfBorrowings), 2)) * 100}%";
            }

            binding = new BindingSource();
            binding.DataSource = reportByCategory;
            DS_ThongKe.DataSource = binding;

            if (DS_ThongKe.Rows.Count != 0)
            {
                DS_ThongKe.SelectedRows[0].Selected = false;
            }
            else
            {
                //lbInform.Visible = true;
                //lbInform.Text = $"Không có quyển sách nào được mượn trong tháng {dtp.Value.Month}";
                //lbInform.Location = new Point((this.Width - lbInform.Width) / 2, lbInform.Location.Y);
            }
        }

        private void LateReport()
        {
            //ChangeDS_ThongKeLayout(2);

            reportLate.Clear();

            string lateReportCmd = $@"SELECT CTPHIEUMUON.MaCuonSach AS 'Mã Đầu Sách', TenDauSach AS 'Tên Đầu Sách', NgMuon AS 'Người Mượn'
                FROM CTPHIEUMUON, PHIEUMUON, CUONSACH, SACH, DAUSACH
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CUONSACH.MaCuonSach = CTPHIEUMUON.MaCuonSach
			                AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach
				                AND TinhTrangPM = 0 AND HanTra < '{dtpTime.Value.ToString("yyyy-MM-dd")}'";
            SqlConnection conn = new SqlConnection(Database.connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(lateReportCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    reportLate.Add(new ReportLate(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2).ToString("dd/MM/yyyy")));
                    reportLate[i].lateReturnDays = dtpTime.Value.Subtract(reader.GetDateTime(2)).Days;
                    i++;
                }
            }
            conn.Close();
            reportLate.OrderByDescending(o => o.lateReturnDays).ThenBy(o => o.bookCode).ThenBy(o => o.borrowDate).ToList();

            binding = new BindingSource();
            binding.DataSource = reportLate;
            DS_ThongKe.DataSource = binding;

            if (DS_ThongKe.Rows.Count != 0)
            {
                DS_ThongKe.SelectedRows[0].Selected = false;
            }
            else
            {
                //lbInform.Visible = true;
                //lbInform.Text = "Không có sách nào trả trễ";
                //lbInform.Location = new Point((this.Width - lbInform.Width) / 2, lbInform.Location.Y);
            }
        }

        private void ChangeDS_ThongKeLayout(int i)
        {
            if (i == 1)
            {
                if (DS_ThongKe.Columns.Count == 5)
                {
                    DS_ThongKe.Columns.RemoveAt(4);
                }
                DS_ThongKe.Columns[1].HeaderText = "Tên thể loại";
                DS_ThongKe.Columns[2].HeaderText = "Số lượt mượn";
                DS_ThongKe.Columns[3].HeaderText = "Tỉ lệ";

                DS_ThongKe.Columns[1].Width = 650;
                DS_ThongKe.Columns[2].Width = 224;
                DS_ThongKe.Columns[3].Width = 230;

                DS_ThongKe.Columns[1].DataPropertyName = "categoryName";
                DS_ThongKe.Columns[2].DataPropertyName = "numsOfBorrowings";
                DS_ThongKe.Columns[3].DataPropertyName = "rate";

                //lbTotalBorrowTitle.Visible = true;
                lbTotalBorrow.Visible = true;

                dtpTime.CustomFormat = "MM/yyyy";

                //lbTitleName.Text = $"Tình Hình Mượn Sách Theo Thể Loại Tháng {dtp.Value.Month.ToString()}";
            }
            else
            {

                DS_ThongKe.Columns[1].HeaderText = "Mã sách";
                DS_ThongKe.Columns[2].HeaderText = "Tên sách";
                DS_ThongKe.Columns[3].HeaderText = "Ngày mượn";
                if (DS_ThongKe.Columns.Count != 5)
                {
                    DS_ThongKe.Columns.Add("newCol", "Số ngày trả trễ");
                }

                DS_ThongKe.Columns[1].Width = 140;
                DS_ThongKe.Columns[2].Width = 560;
                DS_ThongKe.Columns[3].Width = 180;
                DS_ThongKe.Columns[4].Width = 224;

                DS_ThongKe.Columns[1].DataPropertyName = "bookCode";
                DS_ThongKe.Columns[2].DataPropertyName = "bookName";
                DS_ThongKe.Columns[3].DataPropertyName = "borrowDate";
                DS_ThongKe.Columns[4].DataPropertyName = "lateReturnDays";

                //lbTotalBorrowTitle.Visible = false;
                lbTotalBorrow.Visible = false;

                dtpTime.CustomFormat = "dd/MM/yyyy";

                //lbTitleName.Text = $"Sách Trả Trễ {dtp.Value.ToString("dd/MM/yyyy")}";
            }
            //lbTitleName.Location = new Point((this.Width - lbTitleName.Width) / 2, lbTitleName.Location.Y);
        }

        private void cbbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbInform.Visible = false;
            if (cbbReportType.SelectedIndex == 0)
            {
                CategoryReport();
            }
            else
            {
                //dtpTime.Value = DateTime.Now;
                LateReport();
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (DS_ThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = $@"BaoCaoTinhHinhMuonSachTheoTheLoaiThang{dtpTime.Value.Month}";
                saveFile.Filter = "Excel File|*.xlsx";
                DialogResult dgResult = saveFile.ShowDialog();
                if (dgResult == DialogResult.OK)
                {
                    //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                    ToExcel(DS_ThongKe, saveFile.FileName);
                }
            }
        }

        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            string sheetName = "";
            if (cbbReportType.SelectedIndex == 0)
            {
                sheetName = "Báo cáo theo thể loại";
            }
            else
            {
                sheetName = "Báo cáo sách trả trễ";
            }
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = sheetName;

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch
            {
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
    }
}
