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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.BackColor = Color.White;
            txtEmail.BackColor = SystemColors.Control;
            msk.BackColor = SystemColors.Control;
            txtMatKhau.BackColor = SystemColors.Control;
            txtNhapLaiMatKhau.BackColor = SystemColors.Control;
            panel2.BackColor = Color.White;
            panel9.BackColor = SystemColors.Control;
            panel10.BackColor = SystemColors.Control;
            panel11.BackColor = SystemColors.Control;
            panel12.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
            txtTenTaiKhoan.BackColor = SystemColors.Control;
            msk.BackColor = SystemColors.Control;
            txtMatKhau.BackColor = SystemColors.Control;
            txtNhapLaiMatKhau.BackColor = SystemColors.Control;
            panel9.BackColor = Color.White;
            panel2.BackColor = SystemColors.Control;
            panel10.BackColor = SystemColors.Control;
            panel11.BackColor = SystemColors.Control;
            panel12.BackColor = SystemColors.Control;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
           
            msk.BackColor = Color.White;
            txtTenTaiKhoan.BackColor = SystemColors.Control;
            txtEmail.BackColor = SystemColors.Control;
            txtMatKhau.BackColor = SystemColors.Control;
            txtNhapLaiMatKhau.BackColor = SystemColors.Control;
            panel10.BackColor = Color.White;
            panel2.BackColor = SystemColors.Control;
            panel9.BackColor = SystemColors.Control;
            panel11.BackColor = SystemColors.Control;
            panel12.BackColor = SystemColors.Control;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            txtMatKhau.BackColor = Color.White;
            txtTenTaiKhoan.BackColor = SystemColors.Control;
            txtEmail.BackColor = SystemColors.Control;
            msk.BackColor = SystemColors.Control;
            txtNhapLaiMatKhau.BackColor = SystemColors.Control;
            panel11.BackColor = Color.White;
            panel2.BackColor = SystemColors.Control;
            panel9.BackColor = SystemColors.Control;
            panel10.BackColor = SystemColors.Control;
            panel12.BackColor = SystemColors.Control;
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            txtNhapLaiMatKhau.BackColor = Color.White;
            txtTenTaiKhoan.BackColor = SystemColors.Control;
            txtEmail.BackColor = SystemColors.Control;
            msk.BackColor = SystemColors.Control;
            txtMatKhau.BackColor = SystemColors.Control;
            panel12.BackColor = Color.White;
            panel2.BackColor = SystemColors.Control;
            panel9.BackColor = SystemColors.Control;
            panel10.BackColor = SystemColors.Control;
            panel11.BackColor = SystemColors.Control;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void panel12_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtNhapLaiMatKhau.UseSystemPasswordChar = false;
        }
    }
}
