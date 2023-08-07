using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using NguyenThaoMinh_2121110235.Class;

namespace NguyenThaoMinh_2121110235
{
    public partial class frmLogin : Form
    {
        
        SqlConnection con=new SqlConnection("Data Source = THAOMINH; Initial Catalog = Quanlybanhang; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader dr;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.BackColor = Color.White;
            txtMatKhau.BackColor = SystemColors.Control;
            panel3.BackColor = Color.White;
            panel5.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtMatKhau.BackColor = Color.White;
            txtTenDangNhap.BackColor = SystemColors.Control;
            panel5.BackColor = Color.White; 
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }


        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        public void btnDangNhap_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT *FROM tblUsers WHERE username=@username and password=@password", con);
            cmd.Parameters.AddWithValue("@username", txtTenDangNhap.Text);
            cmd.Parameters.AddWithValue("@password", txtMatKhau.Text);
            con.Open();

            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                frmMain frmMain = new frmMain();
                frmMain.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại, thử lại");
            }
            con.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTenDangNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
