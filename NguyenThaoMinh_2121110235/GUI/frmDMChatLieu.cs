using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using NguyenThaoMinh_2121110235.Class; //Sử dụng class Functions.cs
using NguyenThaoMinh_2121110235.GUI;

namespace NguyenThaoMinh_2121110235
{
   
    public partial class frmDMChatLieu : Form
    {
        DataTable tblCL;
        public frmDMChatLieu()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            tblCL = BUS.BUS.LoadListSP(); //Đọc dữ liệu từ bảng
            dgvChatLieu.DataSource = tblCL; //Nguồn dữ liệu            
            dgvChatLieu.Columns[0].HeaderText = "Mã chất liệu";
            dgvChatLieu.Columns[1].HeaderText = "Tên chất liệu";
            dgvChatLieu.Columns[0].Width = 100;
            dgvChatLieu.Columns[1].Width = 300;
            dgvChatLieu.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvChatLieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void frmDMChatLieu_Load(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng tblChatLieu
        }

        private void dgvChatLieu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return;
            }
            if (tblCL.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaChatLieu.Text = dgvChatLieu.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            txtTenChatLieu.Text = dgvChatLieu.CurrentRow.Cells["TenChatLieu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }       
        private void ResetValue()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }       
       
        private void txtMaChatLieu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaChatLieu.Enabled = true; //cho phép nhập mới
            txtMaChatLieu.Focus();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChatLieu.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BUS.BUS.deleteChatLieu(txtMaChatLieu.Text);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChatLieu.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BUS.BUS.editChatLieu(txtTenChatLieu.Text, txtMaChatLieu.Text);
            LoadDataGridView();
            ResetValue();
           
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenChatLieu.Focus();
                return;
            }
            bool kq = BUS.BUS.insertChatLieu(txtTenChatLieu.Text, txtMaChatLieu.Text);

            if (!kq)
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChatLieu.Focus();
                return;
            }
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }

        private void btnBoQua_Click_1(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           frmNhapChatLieu NhapChatLieu = new frmNhapChatLieu(); //Khởi tạo đối tượng
           NhapChatLieu.ShowDialog(); //Hiển thị
        }

        private void btnFileMau_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
