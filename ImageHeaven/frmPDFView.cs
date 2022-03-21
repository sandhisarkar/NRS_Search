using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;
using NovaNet.Utils;
using NovaNet.wfe;
using LItems;
using System.Collections;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using System.Linq;
using AcroPDFLib;
using AxAcroPDFLib;


namespace ImageHeaven
{
    public partial class frmPDFView : Form
    {
        OdbcConnection sqlCon;
        public string pdf_path = string.Empty;
       // public string pdf_name = string.Empty;
        public frmPDFView()
        {
            InitializeComponent();
        }
        public frmPDFView(OdbcConnection prmCon, string prmPath)
        {
            InitializeComponent();
            pdf_path = prmPath;
            sqlCon = prmCon;

        }

        private void frmPDFView_Load(object sender, EventArgs e)
        {
            if (pdf_path != null || pdf_path != "")
            {
                if (File.Exists(pdf_path))
                {
                    try
                    {
                        string filePdf = pdf_path;
                        string name = pdf_path;
                        axAcroPDF1.src = name;
                        axAcroPDF1.Name = name;
                        axAcroPDF1.LoadFile(pdf_path);
                    }
                    catch(Exception ex)
                    {
                        File.Open(pdf_path, FileMode.Open);
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
