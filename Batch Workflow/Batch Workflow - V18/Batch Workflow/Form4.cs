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
using System.Data.OleDb;
using System.Configuration;

namespace Batch_Workflow
{
    public partial class Form4 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            reset_overall();
        }

        public void reset_overall()
        {
            adminlevel.Visible = false;
            adminlevel_2.Visible = false;
            adminlevelcheck_list();
            if (adminlevel.Text == "Admin")
            {
                rdcupload.Enabled = true;
                allocation.Enabled = true;
                batchworkflow.Enabled = true;
                reports.Enabled = true;
                //l2_form.Enabled = true;
            }
            else
            {
                rdcupload.Enabled = false;
                allocation.Enabled = false;
                batchworkflow.Enabled = true;
                reports.Enabled = true;
                //l2_form.Enabled = false;
            }

            if (adminlevel_2.Text == "Admin")
            {
                l2_form.Enabled = true;
            }
            else
            {
                l2_form.Enabled = false;
            }

        }

        public void adminlevelcheck_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.admin_list(dtaa, Environment.UserName.ToString());

                adminlevel.DataSource = dtaa;
                adminlevel.DisplayMember = "BatchWorkflow_Access";
                adminlevel_2.DataSource = dtaa;
                adminlevel_2.DisplayMember = "BatchWorkflow_L2_Form_Access";

                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void rdcupload_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj_form1 = new Form1();
            obj_form1.Show();
        }

        private void allocation_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 obj_form3 = new Form3();
            obj_form3.Show();
        }

        private void batchworkflow_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj_form2 = new Form2();
            obj_form2.Show();
        }

        private void reports_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_BatchWorkflow_Reports_HomePage_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start("inmum-i-fs5\\group$:\\Global Corporate & Data Strategy\\Data Reference\\Workflow\\2018\\MFC - 2018 Workflow");
                System.Diagnostics.Process.Start("https://wtwonlineap.sharepoint.com/:w:/r/sites/tctnonclient_edskycoms/_layouts/15/Doc.aspx?sourcedoc=%7B3BB6F5BD-3FDF-47D8-84A7-F1CCC6D064EC%7D&file=Batch%20workflow%20-%20%20User%20Guide.docx&action=default&mobileredirect=true");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start("inmum-i-fs5\\group$:\\Global Corporate & Data Strategy\\Data Reference\\Workflow\\2018\\MFC - 2018 Workflow");
                System.Diagnostics.Process.Start("https://wtwonlineap.sharepoint.com/:x:/r/sites/tctnonclient_edskycoms/_layouts/15/Doc.aspx?sourcedoc=%7B1A88C97C-5952-421E-9BF7-16AC20D73552%7D&file=Links.xlsx&action=default&mobileredirect=true");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void l2_form_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 obj_form5 = new Form5();
            obj_form5.Show();
        }
    }
}
