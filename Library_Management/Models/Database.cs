using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    public class Database
    {
        public static string connectionStr = @"Data Source=DESKTOP-L8092DN\MSSQLSERVER1;Initial Catalog=TYPH;Integrated Security=True";
        public static string parametersQueryCmd = @"SELECT * from THAMSO";
        public static string validReadersQueryCmd = @"SELECT MaDocGia, HoTen, NgHetHan, Email
                                                    FROM DOCGIA
                                                    WHERE NgHetHan >= GETDATE()";
        public static string bookInStockQueryCmd = @"SELECT SACH.MaSach, TenDauSach, TenTheLoai, STRING_AGG(TenTacGia, ', '), CUONSACH.MaCuonSach " +
                                                    "FROM TACGIA, CTTACGIA, DAUSACH, SACH, CUONSACH, THELOAI " +
                                                    "WHERE TACGIA.MaTacGia = CTTACGIA.MaTacGia AND CTTACGIA.MaDauSach = DAUSACH.MaDauSach AND SACH.MaDauSach = DAUSACH.MaDauSach AND CUONSACH.MaSach = SACH.MaSach AND THELOAI.MaTheLoai = DAUSACH.MaTheLoai " +
                                                        "AND CUONSACH.MaCuonSach = (SELECT MAX(B.MaCuonSach) " +
                                                        "FROM CUONSACH B " +
                                                        "WHERE B.MaSach = CUONSACH.MaSach AND B.TinhTrang = 0) " +
                                                    "GROUP BY SACH.MaSach, TenDauSach, TenTheLoai, CUONSACH.MaCuonSach " +
                                                    "ORDER BY SACH.MaSach";
        public static string getBookSlipCode = @"SELECT TOP (1) MAPHIEUMUONSACH
                                                FROM phieumuon
                                                ORDER BY maphieumuonsach DESC";
        public static string GetNumOfBooksBorrowed(string readerCode)
        {
            return $@"SELECT count(*)
                        FROM PHIEUMUON, CTPHIEUMUON, CUONSACH
                        WHERE MaDocGia = '{readerCode}' 
				        AND PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach 
				        AND CUONSACH.MaCuonSach = CTPHIEUMUON.MaCuonSach
				        AND TinhTrang = 1
				        AND TinhTrangPM = 0";
        }
        public static string borrowSlipQuery = @"SELECT DISTINCT PHIEUMUON.MaPhieuMuonSach, PHIEUMUON.MaDocGia, HoTen, HanTra, TongNo, Email
                FROM PHIEUMUON, CTPHIEUMUON, DOCGIA
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
                        AND TinhTrangPM = 0";
        public static string borrowedBooksQuery = @"SELECT CTPHIEUMUON.MaPhieuMuonSach, SACH.MaSach, TenDauSach, NgMuon, CTPHIEUMUON.MaCuonSach, MaChiTietPhieuMuon
            FROM SACH, CUONSACH, PHIEUMUON, CTPHIEUMUON, DAUSACH
            WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach
		            AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach 
						AND TinhTrangPM = 0";
        public static string getNewReturnSlipCode = @"SELECT TOP (1) MAPHIEUTRASACH
            FROM PHIEUTRASACH
            ORDER BY MAPHIEUTRASACH DESC";
    }
}
