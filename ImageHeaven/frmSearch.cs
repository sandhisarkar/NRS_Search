using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;

namespace ImageHeaven
{
    public partial class frmSearch : Form
    {
        static OdbcConnection SqlCon;
        public frmSearch()
        {
            InitializeComponent();
        }
        public frmSearch(OdbcConnection conn)
        {
            InitializeComponent();
            SqlCon = conn;
            //init();
        }
        public void init()
        {
            string str = "Select * from tbl_details";
            OdbcDataAdapter adap = new OdbcDataAdapter(str, SqlCon);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                deDataGridView1.DataSource = dt;
            }
            else
                deDataGridView1.DataSource = null;
        }
        public AutoCompleteStringCollection GetSuggestions2(string patient_name)
        {
            AutoCompleteStringCollection x = new AutoCompleteStringCollection();
            string sql = "Select distinct " + patient_name + " from tbl_details";
            DataSet ds = new DataSet();
            OdbcCommand cmd = new OdbcCommand(sql, SqlCon);
            OdbcDataAdapter odap = new OdbcDataAdapter(cmd);
            odap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x.Add(ds.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
            //x.Add("Others");
            //x.Add("NA");
            return x;
        }

        public AutoCompleteStringCollection GetSuggestions(string cartonno)
        {
            AutoCompleteStringCollection x = new AutoCompleteStringCollection();
            string sql = "Select distinct " + cartonno + " from tbl_details";
            DataSet ds = new DataSet();
            OdbcCommand cmd = new OdbcCommand(sql, SqlCon);
            OdbcDataAdapter odap = new OdbcDataAdapter(cmd);
            odap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x.Add(ds.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
            //x.Add("Others");
            //x.Add("NA");
            return x;
        }

        public AutoCompleteStringCollection GetSuggestions3(string patient_id)
        {
            AutoCompleteStringCollection x = new AutoCompleteStringCollection();
            string sql = "Select distinct " + patient_id + " from tbl_details";
            DataSet ds = new DataSet();
            OdbcCommand cmd = new OdbcCommand(sql, SqlCon);
            OdbcDataAdapter odap = new OdbcDataAdapter(cmd);
            odap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x.Add(ds.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
            //x.Add("Others");
            //x.Add("NA");
            return x;
        }

        private void deTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void deLabel2_Click(object sender, EventArgs e)
        {

        }

        private void deTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void deLabel5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
        }

        private void deLabel4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "dd-MM-yyyy";
        }

        private void deButton1_Click(object sender, EventArgs e)
        {
            if (deTextBox1.Text.Trim() == "" && deTextBox2.Text.Trim() == "" && deTextBox3.Text.Trim() == "" && dateTimePicker1.ToString().Trim() == "" && dateTimePicker2.ToString().Trim() == "" && dateTimePicker3.ToString().Trim() == "")
            {
                deDataGridView1.DataSource = null;
                return;
            }
            string search_str = "Select cartonno as 'Carton Number', PatientName as 'Patient Name', PatientID as 'Patient ID', pages as 'Number of Pages', scan_date as 'Date of Scan', PDF_date as 'Date of PDF Creation', handover_date as 'Date of Handover' from tbl_details where ";
            if (!(deTextBox1.Text.Trim() == ""))
            {
                search_str = search_str + "CartonNo = '" + deTextBox1.Text + "' and ";
            }
            if (!(deTextBox2.Text.Trim() == ""))
            {
                search_str = search_str + "PatientName = '" + deTextBox2.Text + "' and ";
            }
            if (!(deTextBox3.Text.Trim() == ""))
            {
                search_str = search_str + "PatientID = '" + deTextBox3.Text + "' and ";
            }
            if (!(dateTimePicker1.CustomFormat == " "))
            {
                search_str = search_str + "Scan_Date = '" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "' and ";
            }
            if (!(dateTimePicker2.CustomFormat == " "))
            {
                search_str = search_str + "PDF_Date = '" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "' and ";
            }
            if (!(dateTimePicker3.CustomFormat == " "))
            {
                search_str = search_str + "Handover_Date = '" + dateTimePicker3.Value.ToString("dd-MM-yyyy") + "' and ";
            }

            search_str = search_str.Substring(0, search_str.Length - 4);
            OdbcCommand cmd1 = new OdbcCommand(search_str, SqlCon);
            OdbcDataAdapter sqlAdap = new OdbcDataAdapter(cmd1);
            DataTable dt = new DataTable();
             sqlAdap.Fill(dt);

            if (dt.Rows.Count > 0)
                deDataGridView1.DataSource = dt;
            else
                deDataGridView1.DataSource = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";

            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " ";

            this.dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = " ";

            this.deTextBox1.AutoCompleteCustomSource = GetSuggestions("CartonNo");
            this.deTextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.deTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.deTextBox2.AutoCompleteCustomSource = GetSuggestions2("PatientName");
            this.deTextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.deTextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.deTextBox3.AutoCompleteCustomSource = GetSuggestions3("PatientID");
            this.deTextBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.deTextBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void deDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public DataTable GetAllPdfs(string carton, string p_name, string p_id)
        {
            string sqlStr = null;
            DataSet dsImage = new DataSet();
            DataSet ds = new DataSet();
            string exception = null;
            OdbcDataAdapter sqlAdap = null;
            string indexPageName = string.Empty;

            //sqlStr = "select a.District_Code,a.RO_Code,a.Book,a.Deed_year,a.Deed_no,a.Serial_No,a.Serial_Year,a.tran_maj_code,a.tran_min_code,a.Volume_No,a.Page_From,a.Page_To,a.Date_of_Completion,a.Date_of_Delivery,replace(replace(replace(a.Deed_Remarks,'\t',''),'\n',''),'\r','') as Deed_Remarks,a.Scan_doc_type,a.hold as Exception from deed_details a,deed_details_exception b where a.district_code = '" + Do_code + "' and a.Ro_code = '" + RO_Code + "' and a.book = '" + year + "' and a.deed_year = '" + deed_year + "'  and a.deed_no = '" + deed_no + "' and a.district_code = b.district_code and a.Ro_code = b.ro_code and a.book = b.book and a.deed_year =b.deed_year and a.deed_no = b.deed_no";
            sqlStr = "select pdf_path from tbl_details where cartonno = '" + carton + "' and patientname = '" + p_name + "' and patientid = '" + p_id + "'";
            try
            {
                sqlAdap = new OdbcDataAdapter(sqlStr, SqlCon);
                sqlAdap.Fill(dsImage);


                if (dsImage.Tables[0].Rows.Count > 0)
                {

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                sqlAdap.Dispose();


            }
            //DataRow dr = dsImage.Tables[0].Rows[0];
            //dsImage.Dispose();

            return dsImage.Tables[0];
        }
        private void deDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (deDataGridView1.Rows.Count > 0)
            {
                if (deDataGridView1.SelectedRows.Count > 0)
                {
                    string carton_no = deDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string patient_name = deDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string patient_id = deDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    
                    // GetDeed(Deed_No);

                    if (GetAllPdfs(carton_no, patient_name, patient_id).Rows.Count > 0)
                    {
                        Application.DoEvents();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        string pdf_path = GetAllPdfs(carton_no, patient_name, patient_id).Rows[0][0].ToString();
                        

                        if (File.Exists(pdf_path))
                        {
                            if (pdf_path != null || pdf_path != "")
                            {
                                frmPDFView frm = new frmPDFView(SqlCon, pdf_path);
                                frm.ShowDialog(this);
                            }
                            else
                            {
                                MessageBox.Show(this, "Pdf not available...", "Not Found !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Pdf not available...", "Not Found !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Pdf not available...", "Not Found !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                }
            }
        }
    }
}
