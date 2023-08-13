using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using NguyenThaoMinh_2121110235.DTO;

namespace NguyenThaoMinh_2121110235.Class
{
    internal class Functions
    {
        public static SqlConnection con;
        //Tạo phương thức Connect()

        public static void Connect()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=THAOMINH;Initial Catalog=Quanlybanhang;Integrated Security=True";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                MessageBox.Show("Kết nối thành công!");
            }
            else
            {
                MessageBox.Show("Kết nối không thành công!");
            }
        }
        //Tạo phương thức DisConnect
        public static void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }
        //Lấy dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Functions.con; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static bool IsDate(string date)
        {
            //string[] elements = date.Split('-');
            //if ((Convert.ToInt32(elements[0]) >= 1) && (Convert.ToInt32(elements[0]) <= 31) && (Convert.ToInt32(elements[1]) >= 1) && (Convert.ToInt32(elements[1]) <= 12) && (Convert.ToInt32(elements[2]) >= 1900))
            //    return true;
            //else return false;
            return true;
        }
        public static string ConvertDateTime(string date)
        {
            string[] elements = date.Split('-');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        static string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        private static string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private static string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private static string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        public static string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }
        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('-');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        //Chuyển đổi từ PM sang dạng 24h
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        public class DAL_CHATLIEU
        {
            public static DataTable getChatLieu()
            {
                string sql = "SELECT MaChatLieu, TenChatLieu FROM tblChatLieu";
                DataTable dt = new DataTable();
                dt = Functions.GetDataToTable(sql);
                return dt;
            }
            public static void deleteChatLieu(string maCL)
            {
                string sql = "DELETE tblChatLieu WHERE MaChatLieu=N'" + maCL + "'";
                Class.Functions.RunSqlDel(sql);
            }
            public static void editChatLieu(string tenCL, string maCL)
            {
                string sql = "UPDATE tblChatLieu SET TenChatLieu=N'" +
                tenCL.ToString() +
                "' WHERE MaChatLieu=N'" + maCL + "'";
                Class.Functions.RunSQL(sql);
            }

            public static void sqlChatLieu(string maCL)
            {
                string sql = "Select MaChatLieu From tblChatLieu where MaChatLieu=N'" + maCL.Trim() + "'";
                Class.Functions.CheckKey(sql);
            }
            public static bool insertChatLieu(string tenCL, string maCL)
            {
                bool kq = true;
                string sql = "Select MaChatLieu From tblChatLieu where MaChatLieu=N'" + maCL.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {

                    kq = false;
                    return kq;
                }
                sql = "INSERT INTO tblChatLieu VALUES(N'" +
                        maCL + "',N'" + tenCL + "')";
                Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
                return kq;
            }

        }
        public class DAL_HANGHOA
        {
            public static DataTable getHangHoa()
            {
                string sql = "SELECT * from tblHang";
                DataTable dt = new DataTable();
                dt = Functions.GetDataToTable(sql);
                return dt;
            }
            public static string loadChatLieu()
            {
                string sql = "SELECT * from tblChatLieu";
                Class.Functions.RunSqlDel(sql);
                return sql;
            }
            public static string cboMaChatLieu(string MaChatLieu)
            {
                string sql = "SELECT TenChatLieu FROM tblChatLieu WHERE MaChatLieu=N'" + MaChatLieu + "'";
                string dt = Functions.GetFieldValues(sql);
                return dt;
            }
            public static string loadAnh(string MaHang)
            {
                string sql = "SELECT Anh FROM tblHang WHERE MaHang=N'" + MaHang + "'";
                string dt = Functions.GetFieldValues(sql);
                return dt;
            }
            public static string loadGhiChu(string MaHang)
            {
                string sql = "SELECT Ghichu FROM tblHang WHERE MaHang = N'" + MaHang + "'";
                string dt = Functions.GetFieldValues(sql);
                return dt;
            }
            public static bool insertHangHoa(string maHang, string tenHang, string cboMaChatLieu, string soLuong, string donGiaNhap, string donGiaBan, string hinhAnh, string ghiChu)
            {
                bool kq = true;
                string sql = "SELECT MaHang FROM tblHang WHERE MaHang=N'" + maHang.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    kq = false;
                    return kq;
                }
                sql = "INSERT INTO tblHang(MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap, DonGiaBan,Anh,Ghichu) VALUES(N'"
                + maHang.Trim() + "',N'" + tenHang.Trim() +
                "',N'" + cboMaChatLieu +
                "'," + soLuong.Trim() + "," + donGiaNhap +
                "," + donGiaBan + ",'" + hinhAnh + "',N'" + ghiChu.Trim() + "')";
                Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
                return kq;
            }
            public static void editHangHoa(string tenHang, string cboMaChatLieu, string soLuong, string hinhAnh, string ghiChu, string maHang)
            {
                string sql = "UPDATE tblHang SET TenHang=N'" + tenHang.Trim().ToString() +
                "',MaChatLieu=N'" + cboMaChatLieu.ToString() +
                "',SoLuong=" + soLuong +
                ",Anh='" + hinhAnh + "',Ghichu=N'" + ghiChu + "' WHERE MaHang=N'" + maHang + "'";
                Class.Functions.RunSQL(sql);
            }
            public static void deleteHangHoa(string maHangHoa)
            {
                string sql = "DELETE tblHang WHERE MaHang=N'" + maHangHoa + "'";
                Class.Functions.RunSqlDel(sql);
            }
            public static DataTable timkiemHangHoa(string maHangHoa, string tenHangHoa, string cboMaChatLieu, string cboMaCL)
            {
                string sql = "SELECT * from tblHang WHERE 1=1";
                if (maHangHoa != "")
                    sql += " AND MaHang LIKE N'%" + maHangHoa + "%'";
                if (tenHangHoa != "")
                    sql += " AND TenHang LIKE N'%" + tenHangHoa + "%'";
                if (cboMaChatLieu != "")
                    sql += " AND MaChatLieu LIKE N'%" + cboMaCL + "%'";
                DataTable tblH = new DataTable();
                tblH = Functions.GetDataToTable(sql);
                return tblH;
            }
            public static DataTable hienthiDs()
            {
                string sql = "SELECT MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu FROM tblHang";
                DataTable dt = new DataTable();
                dt = Functions.GetDataToTable(sql);
                return dt;
            }
        }
        public class DAL_KHACHHANG
        {
            public static DataTable getKhachHang()
            {
                string sql = "SELECT * from tblKhach";
                DataTable dt = new DataTable();
                dt = Functions.GetDataToTable(sql);
                return dt;
            }
            public static bool insertKhachHang(string maKhach, string tenKhach, string diaChi, string dienThoai)
            {
                bool kq = true;
                string sql = "SELECT MaKhach FROM tblKhach WHERE MaKhach=N'" + maKhach.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    kq = false;
                    return kq;
                }
                sql = "INSERT INTO tblKhach VALUES (N'" + maKhach.Trim() +
                "',N'" + tenKhach.Trim() + "',N'" + diaChi.Trim() + "','" + dienThoai + "')";
                Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
                return kq;
            }
            public static void editKhachHang(string tenKhach, string diaChi, string dienThoai, string maKhach)
            {
                string sql = "UPDATE tblKhach SET TenKhach=N'" + tenKhach.Trim().ToString() + "',DiaChi=N'" +
                diaChi.Trim().ToString() + "',DienThoai='" + dienThoai.ToString() +
                "' WHERE MaKhach=N'" + maKhach + "'";
                Class.Functions.RunSQL(sql);
            }
            public static void deleteKhachHang(string maKhachHang)
            {
                string sql = "DELETE tblKhach WHERE MaKhach=N'" + maKhachHang + "'";
                Class.Functions.RunSqlDel(sql);
            }
        }
        public class DAL_NHANVIEN
        {
            public static DataTable getNhanVien()
            {
                string sql = "SELECT MaNhanVien,TenNhanVien,GioiTinh,DiaChi,DienThoai,NgaySinh FROm tblNhanVien";
                DataTable dt = new DataTable();
                dt = Functions.GetDataToTable(sql);
                return dt;
            }
            public static bool insertNhanVien(string maNhanVien, string tenNhanVien, string gt, string diaChi, string dienThoai, string NgaySinh)
            {
                bool kq = true;
                string sql = "SELECT MaNhanVien FROM tblNhanVien WHERE MaNhanVien=N'" + maNhanVien.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    kq = false;
                    return kq;
                }
                sql = "INSERT INTO tblNhanVien(MaNhanVien,TenNhanVien,GioiTinh, DiaChi,DienThoai, NgaySinh) VALUES (N'" + maNhanVien.Trim() + "',N'" + tenNhanVien.Trim() + "',N'" + gt + "',N'" + diaChi.Trim() + "','" + dienThoai + "','" + NgaySinh.ToString() + "')";
                Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
                return kq;
            }
            public static void editNhanVien(string tenNhanVien, string diaChi, string dienThoai, string gt, string ngaySinh, string maNhanVien)
            {
                string sql = "UPDATE tblNhanVien SET  TenNhanVien=N'" + tenNhanVien.Trim().ToString() +
                    "',DiaChi=N'" + diaChi.Trim().ToString() +
                    "',DienThoai='" + dienThoai.ToString() + "',GioiTinh=N'" + gt +
                    "',NgaySinh='" + Functions.ConvertDateTime(ngaySinh) +
                    "' WHERE MaNhanVien=N'" + maNhanVien + "'";
                Class.Functions.RunSQL(sql);
            }
            public static void deleteNhanVien(string maNhanVien)
            {
                string sql = "DELETE tblNhanVien WHERE MaNhanVien = N'" + maNhanVien + "'";
                Class.Functions.RunSqlDel(sql);
            }
        }
        public class DAL_HOADONBAN
        {
            public static DataTable getHoaDonBan(string maHDBan)
            {
                string sql = "SELECT a.MaHang, b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia,a.ThanhTien FROM tblChiTietHDBan AS a, tblHang AS b WHERE a.MaHDBan = N'" + maHDBan + "' AND a.MaHang=b.MaHang";
                DataTable dt = new DataTable();
                dt = Functions.GetDataToTable(sql);
                return dt;
            }
            public static string loadNgay(string maHDBan)
            {
                string sql = "SELECT NgayBan FROM tblHDBan WHERE MaHDBan = N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string loadMaNV(string maHDBan)
            {
                string sql = "SELECT MaNhanVien FROM tblHDBan WHERE MaHDBan = N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string loadMaKhach(string maHDBan)
            {
                string sql = "SELECT MaKhach FROM tblHDBan WHERE MaHDBan = N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string loadTongTien(string maHDBan)
            {
                string sql = "SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string fillMaKhach()
            {
                string sql = "SELECT MaKhach, TenKhach FROM tblKhach";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string fillMaNhanVien()
            {
                string sql = "SELECT MaNhanVien, TenNhanVien FROM tblNhanVien";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string fillMaHang()
            {
                string sql = "SELECT MaHang, TenHang FROM tblHang";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string sqlLuu(string maHDBan)
            {
                string sql = "SELECT MaHDBan FROM tblHDBan WHERE MaHDBan=N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static void insertHoaDon(string maHDBan,string NgayBan,string cboMaNhanVien, string cboMaKhach,string tongTien)
            {
                string sql = "INSERT INTO tblHDBan(MaHDBan, NgayBan, MaNhanVien, MaKhach, TongTien) VALUES (N'" + maHDBan.Trim() + "','" +
                        Functions.ConvertDateTime(NgayBan.Trim()) + "',N'" + cboMaNhanVien + "',N'" +
                        cboMaKhach + "'," + tongTien + ")";
                Class.Functions.RunSQL(sql);
            }
            public static string sqlktMaHang(string cboMaHang, string maHDBan)
            {
                string sql = "SELECT MaHang FROM tblChiTietHDBan WHERE MaHang=N'" + cboMaHang + "' AND MaHDBan = N'" + maHDBan.Trim() + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string sqlktSoLuong(string cboMaHang)
            {
                string sql = "SELECT SoLuong FROM tblHang WHERE MaHang = N'" + cboMaHang + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static void insertCTHoaDon(string maHDBan, string cboMaHang, string SoLuong, string DonGiaBan, string GiamGia, string ThanhTien)
            {
                string sql = "INSERT INTO tblChiTietHDBan(MaHDBan,MaHang,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + maHDBan.Trim() + "',N'" + cboMaHang + "'," + SoLuong + "," + DonGiaBan + "," + GiamGia + "," + ThanhTien + ")";
                Class.Functions.RunSQL(sql);
            }
            public static void editCTHoaDon(double SLcon, string cboMaHang)
            {
                string sql = "UPDATE tblHang SET SoLuong =" + SLcon + " WHERE MaHang= N'" + cboMaHang + "'";
                Class.Functions.RunSQL(sql);
            }
            public static string sqlTongTien(string maHoaDon)
            {
                string sql = "SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + maHoaDon + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static void updateTongTien(double Tongmoi, string maHDBan)
            {
                string sql = "UPDATE tblHDBan SET TongTien =" + Tongmoi + " WHERE MaHDBan = N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
            }
            public static void deleteCTHDBan(string maHDBan, string MaHangxoa)
            {
                string sql = "DELETE tblChiTietHDBan WHERE MaHDBan=N'" + maHDBan + "' AND MaHang = N'" + MaHangxoa + "'";
                Class.Functions.RunSQL(sql);
            }
            public static void edittcMatHang(double slcon, string MaHangxoa)
            {
                string sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + MaHangxoa + "'";
                Class.Functions.RunSQL(sql);
            }
            public static string sqlslMatHang(string MaHangxoa)
            {
                string sql = "SELECT SoLuong FROM tblHang WHERE MaHang = N'" + MaHangxoa + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string sqlttTongTien(string MaHDBan)
            {
                string sql = "SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + MaHDBan + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static void editTongHDBan(double tongmoi, string maHDBan)
            {
                string sql = "UPDATE tblHDBan SET TongTien =" + tongmoi + " WHERE MaHDBan = N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
            }
            public static string sqlxoaHDBan(string maHDBan)
            {
                string sql = "SELECT MaHang,SoLuong FROM tblChiTietHDBan WHERE MaHDBan = N'" + maHDBan + "'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static string sqlslMatHang()
            {
                string sql = "SELECT SoLuong FROM tblHang WHERE MaHang = N'";
                Class.Functions.RunSQL(sql);
                return sql;
            }
            public static void editslMatHang(double slcon, string hang)
            {
                string sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + hang + "'";
                Class.Functions.RunSQL(sql);
            }

        }
    }
}
