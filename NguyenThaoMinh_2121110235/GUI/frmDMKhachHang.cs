﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NguyenThaoMinh_2121110235.Class;
namespace NguyenThaoMinh_2121110235
{
    public partial class frmDMKhachHang : Form
    {
        DataTable tblKH;
        public frmDMKhachHang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataGridView()
        { 
            tblKH = BUS.BUS.LoadListKhachHang();
            dgvKhachHang.DataSource = tblKH; //Hiển thị vào dataGridView
            dgvKhachHang.Columns[0].HeaderText = "Mã khách";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 150;
            dgvKhachHang.Columns[2].Width = 150;
            dgvKhachHang.Columns[3].Width = 150;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void frmDMKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKhach.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhach.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKhach.Text = dgvKhachHang.CurrentRow.Cells["MaKhach"].Value.ToString();
            txtTenKhach.Text = dgvKhachHang.CurrentRow.Cells["TenKhach"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            mskDienThoai.Text = dgvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValues()
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            mskDienThoai.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKhach.Enabled = true;
            txtMaKhach.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhach.Focus();
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhach.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDienThoai.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            bool kq = BUS.BUS.insertKhachHang(txtMaKhach.Text, txtTenKhach.Text, txtDiaChi.Text, mskDienThoai.Text);
            if (!kq)
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhach.Focus();
                return;
            }   
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKhach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhach.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDienThoai.Focus();
                return;
            }
            BUS.BUS.editKhachHang(txtTenKhach.Text, txtDiaChi.Text, mskDienThoai.Text, txtMaKhach.Text);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BUS.BUS.deleteKhachHang(txtMaKhach.Text);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKhach.Enabled = false;
        }

        private void txtMaKhach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtTenKhach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void mskDienThoai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
