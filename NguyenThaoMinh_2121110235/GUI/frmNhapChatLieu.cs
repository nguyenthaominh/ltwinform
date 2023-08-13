﻿using NguyenThaoMinh_2121110235.DAL;
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
                            for (int i = 0; i < dgvChatLieu.Rows.Count; i++)
                            {
                                sql = "INSERT INTO tblChatLieu VALUES(N'" +
                        dgvChatLieu.Rows[i].Cells["Mã chất liệu"].Value.ToString() + "',N'" + dgvChatLieu.Rows[i].Cells["Tên chất liệu"].Value.ToString() + "')";

                                comm.CommandText = sql;
                                Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
                                comm.ExecuteNonQuery();
                            }
                        }
                    }
                }



            }
        }
