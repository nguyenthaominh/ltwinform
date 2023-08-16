using NguyenThaoMinh_2121110235.Class;
using NguyenThaoMinh_2121110235.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace NguyenThaoMinh_2121110235.GUI
{
    public partial class frmNhapChatLieu : Form
    {
        public frmNhapChatLieu()
        {
            InitializeComponent();
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            string file = ""; //variable for the Excel File Location
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Check if Result == "OK".
            {
                file = openFileDialog1.FileName; //get the filename with the location of the file
                try
                {
                    //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file
                    Microsoft.Office.Interop.Excel.Application excelApp =
                        new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;
                    dgvChatLieu.DataSource = ExcelFileReader.read(excelRange);

                    //close and clean excel process
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(excelRange);
                    Marshal.ReleaseComObject(excelWorksheet);
                    //quit apps
                    excelWorkbook.Close();
                    Marshal.ReleaseComObject(excelWorkbook);
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            txtDuongDan.Text=file;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;

            using (SqlConnection conn = new SqlConnection("Data Source = THAOMINH; Initial Catalog = Quanlybanhang; Integrated Security = True"))
            {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            conn.Open();
                            for (int i = 0; i < dgvChatLieu.Rows.Count - 1; i++)
                            {
                                sql= "Select MaChatLieu From tblChatLieu where MaChatLieu=N'" + dgvChatLieu.Rows[i].Cells["Mã chất liệu"].Value?.ToString() + "'";
                                if (Class.Functions.CheckKey(sql))
                                {
                                    MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                // comm.CommandText = sql;
                                ////Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
                                //comm.ExecuteNonQuery();
                            }

                            for (int i = 0; i < dgvChatLieu.Rows.Count-1; i++)
                            {
                                sql = "INSERT INTO tblChatLieu VALUES(N'" +
                                dgvChatLieu.Rows[i].Cells["Mã chất liệu"].Value?.ToString() + "',N'" + dgvChatLieu.Rows[i].Cells["Tên chất liệu"].Value?.ToString() + "')";

                                comm.CommandText = sql;
                                //Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
                                comm.ExecuteNonQuery();
                            }
                            conn.Close();
                            MessageBox.Show("Đã thêm dữ liệu");
                        }
                    }
                }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMau_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:A1"].Value = "Mã chất liệu";
            exRange.Range["B1:B1"].Value = "Tên chất liệu";
            exRange.Range["A2:A2"].Value = "CL01";
            exRange.Range["B2:B2"].Value = "Vải";
            exRange.Range["A3:A3"].Value = "CL02";
            exRange.Range["B3:B3"].Value = "Kim Loại";
            exApp.Visible = true;
        }
    }
}
