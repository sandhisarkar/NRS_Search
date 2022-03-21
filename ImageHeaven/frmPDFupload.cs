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
    public partial class frmPDFupload : Form
    {
        OdbcConnection Sqlcon;
        List<string> pdfList = new List<string>(); 
        public frmPDFupload()
        {
            InitializeComponent();
        }
        public frmPDFupload(OdbcConnection conn)
        {
            InitializeComponent();
            Sqlcon = conn;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void deButton2_Click(object sender, EventArgs e)
        {
            string carton_no = Path.GetFileName(deTextBox1.Text);
            string copy_path = @"D:\NRS_Images";
            if (!Directory.Exists(copy_path + "\\" + carton_no))
            {
                Directory.CreateDirectory(copy_path + "\\" + carton_no);
            }
            //for (int i = 0; i < pdfList.Count; i++)
            //{
            //    File.Copy(deTextBox1.Text + "\\" + pdfList[i].ToString(), )
            //}
            for (int i = 0; i < pdfList.Count; i++)
            {
                string[] split = Path.GetFileName(pdfList[i].ToString()).Split(' ');
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
                string dest_path = copy_path + "\\" + carton_no + "\\" + Path.GetFileName(pdfList[i].ToString());
                dest_path = dest_path.Replace("\\", "\\\\");
                string init_path = deTextBox1.Text + "\\" + Path.GetFileName(pdfList[i].ToString());
                File.Copy(init_path, dest_path, true);
                // string pdf_path = copy_path + "\\" + pdfList[i].ToString();

                string update_str = "Update tbl_details set pdf_path = '" + dest_path + "' where cartonno = '" + carton_no + "' and patientname = '" + patient_name + "' and patientid = '" + patient_id + "'";
                OdbcCommand cmd1 = new OdbcCommand(update_str, Sqlcon);
                OdbcDataReader myreader = cmd1.ExecuteReader();
                myreader.Close();
            }
            MessageBox.Show(this, "PDF Uploaded successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void deButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            DialogResult dlg = fdlg.ShowDialog();
            if (dlg == DialogResult.OK)
            {
               // var list = Directory.GetFiles(fdlg.SelectedPath, ".pdf");
               
                string[] get_files = Directory.GetFiles(fdlg.SelectedPath);
                foreach (string str in get_files)
                {
                    if (Path.GetExtension(str).ToLower() == ".pdf")
                    {
                        pdfList.Add(str);
                        
                    }

                }
                if (pdfList.Count > 0)
                {
                    deTextBox1.Text = fdlg.SelectedPath;
                    deButton2.Enabled = true;
                }
                //button enable
                else
                {
                    deButton2.Enabled = false;
                    deTextBox1.Text = string.Empty;
                    MessageBox.Show(this, "No PDF Found for this folder", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frmPDFupload_Load(object sender, EventArgs e)
        {
            deButton2.Enabled = false;
        }
    }
}
