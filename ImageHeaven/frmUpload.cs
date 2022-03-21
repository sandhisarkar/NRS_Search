using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;


namespace ImageHeaven
{
    public partial class frmUpload : Form
    {
        OdbcConnection SqlCon;
        DataTable excel_dt = new DataTable();
        public frmUpload()
        {
            InitializeComponent();
        }
        public frmUpload(OdbcConnection conn)
        {
            InitializeComponent();
            SqlCon = conn;
        }
        public bool GetData(string carton_no, string patient_name, string patient_id)
        {
            bool retVal = false;
            DataTable dt = new DataTable();
            string query = "select * from tbl_details where cartonname = '" + carton_no + "' and patientname = '" + patient_name + "' and patientID = '" + patient_id + "'";
            OdbcDataAdapter da = new OdbcDataAdapter(query, SqlCon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                retVal = true;
            else
                retVal = false;

            return retVal;
        }


        private void deTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void deButton2_Click(object sender, EventArgs e)
        {
            try
            {
                deButton2.Enabled = false;
                //xcel_dt.Columns.Add("Serial No");
                excel_dt.Columns.Add("Carton No");
                excel_dt.Columns.Add("Patient Name");
                excel_dt.Columns.Add("ID");
                excel_dt.Columns.Add("Pages");
                excel_dt.Columns.Add("Date of Scan");
                excel_dt.Columns.Add("Date of PDF Creation");
                excel_dt.Columns.Add("Date of Data Handover");

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(deTextBox1.Text);

                Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;


                int rowCount = excelRange.Rows.Count;

                //int colCount = excelRange.Columns.Count;

                // DataRow row = new DataRow();

                for (int i = 3; i <= rowCount; i++)
                {
                    try
                    {
                        string carton_no = excelRange[i, 2].value2;
                        string Patient_name_ID = excelRange[i, 3].value2;
                        //string split with " "
                        string[] split = Patient_name_ID.Split(' ');
                        string patient_name = string.Empty;
                        //string split with '.'
                        //string[] ID = Patient_name_ID.Split('.');
                        string patient_id = string.Empty;
                        for (int j = 0; j < split.Length; j++)
                        {
                            if (split.Length > 0)
                            {
                                if (j == 0)
                                { patient_name = split[j]; }
                                else if (j != split.Length - 1 && j > 0)
                                {
                                    patient_name = patient_name + " " + split[j];
                                }
                                else
                                {
                                    string[] ID = split[j].Split('.');
                                    for (int k = 0; k < ID.Length; k++)
                                    {
                                        if (ID.Length > 0)
                                        {
                                            if (k == 0)
                                            {
                                                patient_id = ID[k];
                                            }
                                        }
                                        else
                                        { patient_id = string.Empty; }
                                    }
                                }
                            }
                            else
                            {
                                patient_name = string.Empty;
                                patient_id = string.Empty;
                            }
                        }

                        string pages = Convert.ToString(excelRange[i, 4].value2);

                        var date_of_scan = DateTime.FromOADate(double.Parse(excelRange[i, 5].value2.ToString())).ToString("dd/MM/yyyy");
                        var date_of_pdf = DateTime.FromOADate(double.Parse(excelRange[i, 6].value2.ToString())).ToString("dd/MM/yyyy");
                        var date_of_handover = DateTime.FromOADate(double.Parse(excelRange[i, 7].value2.ToString())).ToString("dd/MM/yyyy");

                        if (!GetData(carton_no.Trim(), patient_name.Trim(), patient_id.Trim()))
                        {
                            //insert
                            string insert_str = "insert into tbl_details(cartonno, patientname, patientID, pages, scan_date, pdf_date, handover_date)"
                                                + "values('" + carton_no.Trim() + "', '" + patient_name.Trim() + "', '" + patient_id.Trim() + "', '"+pages+"', '" + date_of_scan + "', '" + date_of_pdf + "', '" + date_of_handover + "')";
                            OdbcCommand cmd1 = new OdbcCommand(insert_str, SqlCon);
                            OdbcDataReader myreader = cmd1.ExecuteReader();
                            myreader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }

                }
                
                //connfirm msg
                MessageBox.Show(this, "Data Uploaded successfully", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
           
            
        }

        private void deButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmUpload_Load(object sender, EventArgs e)
        {
            deButton2.Enabled = false;
        }

        private void deButton1_Click(object sender, EventArgs e)
        {
             OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";

            DialogResult dlg = openFileDialog.ShowDialog();

            if (dlg == DialogResult.OK)
            {
                deTextBox1.Text = openFileDialog.FileName;
                deButton2.Enabled = true;
            }
            else
            {
                deTextBox1.Text = string.Empty;
                deButton2.Enabled = false;
            }
        }
    }
}
