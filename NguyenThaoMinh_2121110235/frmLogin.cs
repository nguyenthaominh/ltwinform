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
        DataTable tblLI;
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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //string sql;
            //string username = txtTenDangNhap.Text;
            //string password = txtMatKhau.Text;

            //try
            //{
            //    sql= "SELECT*FROM tblLogin WHERE username='"+ txtTenDangNhap.Text + "' AND password='" + txtMatKhau.Text + "'";
            //    tblLI = Class.Functions.GetDataToTable(sql);
            //    if (Class.Functions.CheckKey(sql))
            //    {
            //        username= txtTenDangNhap.Text;
            //        password = txtMatKhau.Text;
            //        frmMain frmMain= new frmMain();
            //        frmMain.ShowDialog();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtTenDangNhap.Clear();
            //        txtMatKhau.Clear();
            //        txtTenDangNhap.Focus();
                    
            //    }    
            //}
            //catch
            //{
                if(txtTenDangNhap.Text=="admin"&&txtMatKhau.Text == "123456")
                {
                   
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog();
                    this.Close();


            }
                else
                {
                    MessageBox.Show("Error");
                }

            //}
            //finally
            //{
            //    Application.Exit();
            //}
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
