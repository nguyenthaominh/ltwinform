using NguyenThaoMinh_2121110235.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NguyenThaoMinh_2121110235.BUS
{
    public class BUS
    {
        public static DataTable LoadListSP()
        {
            return Functions.DAL_CHATLIEU.getChatLieu();
        }
        public static void deleteChatLieu(string maCL)
        {
            Functions.DAL_CHATLIEU.deleteChatLieu(maCL);
        }
        public static void editChatLieu(string tenCL, string maCL)
        {
            Functions.DAL_CHATLIEU.editChatLieu(tenCL, maCL);
        }
        public static void sqlChatLieu(string maCL)
        {
            Functions.DAL_CHATLIEU.sqlChatLieu(maCL);
        }
        public static bool insertChatLieu(string tenCL, string maCL)
        {
            return Functions.DAL_CHATLIEU.insertChatLieu(tenCL, maCL);
        }
        public static DataTable LoadListHangHoa()
        {
            return Functions.DAL_HANGHOA.getHangHoa();
        }
        public static string LoadChatLieu()
        {
            return Functions.DAL_HANGHOA.loadChatLieu();
        }
        public static string cboMaChatLieu(string MaChatLieu)
        {

            return Functions.DAL_HANGHOA.cboMaChatLieu(MaChatLieu);
        }
        public static string loadAnh(string MaHang)
        {
            return Functions.DAL_HANGHOA.loadAnh(MaHang);

        }
        public static string loadGhiChu(string MaHang)
        {
            return Functions.DAL_HANGHOA.loadGhiChu(MaHang);

        }
        public static bool insertHangHoa(string maHang, string tenHang, string cboMaChatLieu, string soLuong, string donGiaNhap, string donGiaBan, string hinhAnh, string ghiChu)
        {
            return Functions.DAL_HANGHOA.insertHangHoa(maHang, tenHang,cboMaChatLieu,soLuong,donGiaNhap,donGiaBan,hinhAnh,ghiChu);
        }
        public static void editHangHoa(string tenHang, string cboMaChatLieu, string soLuong, string hinhAnh, string ghiChu, string maHang)
        {
            Functions.DAL_HANGHOA.editHangHoa(tenHang, cboMaChatLieu, soLuong, hinhAnh, ghiChu, maHang);
        }
        public static void deleteHangHoa(string maHangHoa)
        {
            Functions.DAL_CHATLIEU.deleteChatLieu(maHangHoa);
        }
        public static DataTable TimKiemHangHoa(string maHangHoa, string tenHangHoa, string cboMaChatLieu, string cboMaCL)
        {
            return Functions.DAL_HANGHOA.timkiemHangHoa (maHangHoa, tenHangHoa, cboMaChatLieu, cboMaCL);
        }
        public static DataTable hienthiDs()
        {
            return Functions.DAL_HANGHOA.hienthiDs();
        }
        public static DataTable LoadListKhachHang()
        {
            return Functions.DAL_KHACHHANG.getKhachHang();
        }
        public static bool insertKhachHang(string maKhach, string tenKhach, string diaChi, string dienThoai)
        {
            return Functions.DAL_KHACHHANG.insertKhachHang(maKhach, tenKhach,diaChi,dienThoai);
        }
        public static void editKhachHang(string tenKhach, string diaChi, string dienThoai, string maKhach)
        {
            Functions.DAL_KHACHHANG.editKhachHang(tenKhach, diaChi, dienThoai, maKhach);
        }
        public static void deleteKhachHang(string maKhachHang)
        {
            Functions.DAL_KHACHHANG.deleteKhachHang(maKhachHang);
        }
        public static DataTable LoadListNhanVien()
        {
            return Functions.DAL_NHANVIEN.getNhanVien();
        }
        public static bool insertNhanVien(string maNhanVien, string tenNhanVien, string gt, string diaChi, string dienThoai, string NgaySinh)
        {
            return Functions.DAL_NHANVIEN.insertNhanVien(maNhanVien, tenNhanVien, gt, diaChi, dienThoai, NgaySinh);
        }
        public static void editNhanVien(string tenNhanVien, string diaChi, string dienThoai, string gt, string NgaySinh, string maNhanVien)
        {
            Functions.DAL_NHANVIEN.editNhanVien(tenNhanVien, diaChi, dienThoai, gt, NgaySinh, maNhanVien);
        }
        public static void deleteNhanVien(string maNhanVien)
        {
            Functions.DAL_NHANVIEN.deleteNhanVien(maNhanVien);
        }
        public static DataTable LoadHoaDon(string maHoaDon)
        {
            return Functions.DAL_HOADONBAN.getHoaDonBan(maHoaDon);
        }
        public static string loadNgay(string maHDBan)
        {
            return Functions.DAL_HOADONBAN.loadNgay(maHDBan);

        }
        public static string loadMaNV(string maHDBan)
        {
            return Functions.DAL_HOADONBAN.loadMaNV(maHDBan);

        }
        public static string loadMaKhach(string maHDBan)
        {
            return Functions.DAL_HOADONBAN.loadMaKhach(maHDBan);

        }
        public static string loadTongTien(string maHDBan)
        {
            return Functions.DAL_HOADONBAN.loadTongTien(maHDBan);

        }
        public static string fillMaKhach()
        {
            return Functions.DAL_HOADONBAN.fillMaKhach();

        }
        public static string fillMaNhanVien()
        {
            return Functions.DAL_HOADONBAN.fillMaNhanVien();

        }
        public static string fillMaHang()
        {
            return Functions.DAL_HOADONBAN.fillMaHang();

        }
        public static string sqlLuu(string maHDBan)
        {
            return Functions.DAL_HOADONBAN.sqlLuu(maHDBan);

        }
        public static void insertHoaDon(string maHDBan, string NgayBan, string cboMaNhanVien, string cboMaKhach, string tongTien)
        {
            Functions.DAL_HOADONBAN.insertHoaDon(maHDBan, NgayBan, cboMaNhanVien, cboMaKhach, tongTien);
        }
        public static string sqlktMaHang(string cboMaHang, string maHDBan)
        {
            return Functions.DAL_HOADONBAN.sqlktMaHang(cboMaHang, maHDBan);

        }
        public static string sqlktSoLuong(string cboMaHang)
        {
            return Functions.DAL_HOADONBAN.sqlktSoLuong(cboMaHang);

        }
        public static void insertCTHoaDon(string maHDBan, string cboMaHang, string SoLuong, string DonGiaBan, string GiamGia, string ThanhTien)
        {
            Functions.DAL_HOADONBAN.insertCTHoaDon(maHDBan, cboMaHang, SoLuong, DonGiaBan, GiamGia, ThanhTien);
        }
        public static void editCTHoaDon(double SLcon, string cboMaHang)
        {
            Functions.DAL_HOADONBAN.editCTHoaDon(SLcon, cboMaHang);
        }
        public static string sqlTongTien(string maHoaDon)
        {
            return Functions.DAL_HOADONBAN.sqlTongTien(maHoaDon);
        }
        public static void updateTongTien(double Tongmoi, string maHDBan)
        {
            Functions.DAL_HOADONBAN.updateTongTien(Tongmoi, maHDBan);
        }
        public static void deleteCTHDBan(string maHDBan, string MaHangxoa)
        {
            Functions.DAL_HOADONBAN.deleteCTHDBan(maHDBan, MaHangxoa);
        }
        public static void edittcMatHang(double slcon, string MaHangxoa)
        {
            Functions.DAL_HOADONBAN.edittcMatHang(slcon, MaHangxoa);
        }
        public static string sqlslMatHang(string MaHangxoa)
        {
            return Functions.DAL_HOADONBAN.sqlTongTien(MaHangxoa);
        }
        public static string sqlttTongTien(string MaHDBan)
        {
            return Functions.DAL_HOADONBAN.sqlttTongTien(MaHDBan);
        }
        public static void editTongHDBan(double tongmoi, string maHDBan)
        {
            Functions.DAL_HOADONBAN.editTongHDBan(tongmoi, maHDBan);
        }
        public static string sqlxoaHDBan(string maHDBan)
        {
            return Functions.DAL_HOADONBAN.sqlxoaHDBan(maHDBan);
        }
        public static string sqlslMatHang()
        {
            return Functions.DAL_HOADONBAN.sqlslMatHang();
        }
        public static void editslMatHang(double slcon, string hang)
        {
            Functions.DAL_HOADONBAN.editslMatHang(slcon, hang);
        }
    }
}
