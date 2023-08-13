using NguyenThaoMinh_2121110235.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenThaoMinh_2121110235
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            {
                frmDMChatLieu frmChatLieu = new frmDMChatLieu(); //Khởi tạo đối tượng
                frmChatLieu.ShowDialog(); //Hiển thị
            }
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanVien frmNhanVien = new frmDMNhanVien(); //Khởi tạo đối tượng
            frmNhanVien.ShowDialog(); //Hiển thị
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frmKhachHang = new frmDMKhachHang(); //Khởi tạo đối tượng
            frmKhachHang.ShowDialog(); //Hiển thị
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHangHoa frmHangHoa = new frmDMHangHoa(); //Khởi tạo đối tượng
            frmHangHoa.ShowDialog(); //Hiển thị
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan(); //Khởi tạo đối tượng
            frmHoaDonBan.ShowDialog(); //Hiển thịthị
        }
        private void mnuTimKiemHD_Click(object sender, EventArgs e)
        {
            frmTimKiemHD frmTimKiemHD = new frmTimKiemHD(); //Khởi tạo đối tượng
            frmTimKiemHD.ShowDialog(); //Hiển thị
        }

        private void mnuNhapChatLieu_Click(object sender, EventArgs e)
        {
            frmNhapChatLieu frmNhapChatLieu=new frmNhapChatLieu();
            frmNhapChatLieu.ShowDialog();



    }
    }
}
