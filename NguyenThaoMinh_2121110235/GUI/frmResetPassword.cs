using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace NguyenThaoMinh_2121110235.GUI
{
    public partial class frmResetPassword : Form
    {
        string email = frmQuenMatKhau.to;
        public frmResetPassword()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtnewpass.Text==txtrepass.Text)
            {
                SqlConnection con = new SqlConnection("Data Source = THAOMINH; Initial Catalog = Quanlybanhang; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("UPDATE tblUsers SET password=N'" +
                txtnewpass.Text.ToString() +
                "' WHERE email=N'" + email + "'",con);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Đã thay đổi mật khẩu mới thành công");
                this.Hide();
                frmLogin dn = new frmLogin();
                dn.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa thay đổi được mật khẩu");
            }

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
