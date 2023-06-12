using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    public class Database
    {
        public static string connectionStr = @"Data Source=LAPTOP-A6JDT5M7\KAIL;Initial Catalog=TYPH;Integrated Security=True";
        public static string parametersQueryCmd = @"SELECT * from THAMSO";
        public static string validReadersQueryCmd = @"SELECT MaDocGia, HoTen, NgHetHan, Email
                                                    FROM DOCGIA
                                                    WHERE NgHetHan >= GETDATE()";
        public static string bookInStockQueryCmd = @"SELECT DISTINCT CUONSACH.MaSach, TenDauSach, TenTheLoai, TenTacGia, CUONSACH.MaCuonSach
                                                    FROM SACH, DAUSACH, THELOAI, CUONSACH, TACGIA, CTTACGIA
                                                    WHERE SACH.MaDauSach = DAUSACH.MaDauSach AND DAUSACH.MaTheLoai = THELOAI.MaTheLoai
                                                    AND SACH.MaSach = CUONSACH.MaSach AND DAUSACH.MaDauSach = CTTACGIA.MaDauSach
                                                    AND CTTACGIA.MaTacGia = TACGIA.MaTacGia AND TinhTrang = 0
			                                        AND CUONSACH.MaCuonSach = (SELECT MAX(B.MaCuonSach)
				                                                                FROM CUONSACH B
				                                                                WHERE B.MaSach = CUONSACH.MaSach AND B.TinhTrang = 0)
			                                        ORDER BY CUONSACH.MaSach";
    }
}
