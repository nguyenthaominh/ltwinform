using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenThaoMinh_2121110235.GUI
{
    public partial class frmQuenMatKhau : Form
    {
        string randomCode;
        public static string to;
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnSendcode_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand=new Random();
            randomCode=(rand.Next(999999)).ToString();
            MailMessage message=new MailMessage();
            to =(txtEmail.Text).ToString();
            from = "bigsea.tm@gmail.com";
            pass = "keaesnbxsvezewzv";
            messageBody = "Mã code cập nhập mật khẩu của bạn là " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "PETSHOP-MÃ CODE XÁC NHẬN";
            SmtpClient smtp=new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Đã gửi mã code qua email");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnVeryCode_Click(object sender, EventArgs e)
        {
            if(randomCode==(txtcode.Text).ToString())
            {
                to = txtEmail.Text;
                frmResetPassword rp= new frmResetPassword();
                this.Hide();
                MessageBox.Show("Mã code chính xác");
                rp.Show();
            }
            else
            {
                MessageBox.Show("Mã code không đúng, mời nhập lại");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
