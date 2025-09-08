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
    public partial class Form1 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset_overall();
        }

        public void reset_overall()
        {
            button3.Enabled = false;
            excelfilepath.Text = string.Empty;
            excelsheetname.Text = string.Empty;
            datagridview1_display_overall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.excelfilepath.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(excelsheetname.Text))
            {
                MessageBox.Show("Please enter excel sheet name");
            }
            else
            {
                string messsage = "Do you want to upload these records?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    try
                    {
                        button3.Enabled = true;
                        string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                        OleDbConnection conne = new OleDbConnection(pathconn);
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows Uploaded Unsuccessfully");
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to upload these records in the final table?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                try
                {
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "truncate table dbo.tbl_batchworkflow_rdcupload_daily_dotnet";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;
                    conn.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        //cmd.CommandText = "insert into tbl_batchworkflow_rdcupload_daily_dotnet (BatchID,BatchType,BatchSubmittedDate,BatchCompletedDate,BatchStatus,InquiryID,TrackingID,ReportingID,InquiryName,InquiryDateOfBirth,InquiryAddressLine1,InquiryCity,InquiryProvince,InquiryPostalCode,InquiryCountry,InquiryNotes,Decision,ReasonCode,UserName,DecisioningNotes,EntityID,ListEntryID,Name,Type,DateOfBirth,Date,Address,EvenList,MatchScore,CVIP,UploadedBy,MachineName,AssociateName) values('" + row.Cells["txtBatchID"].Value + "','" + row.Cells["txtBatchType"].Value + "','" + row.Cells["txtBatchSubmittedDate"].Value + "','" + row.Cells["txtBatchCompletedDate"].Value + "','" + row.Cells["txtBatchStatus"].Value + "','" + row.Cells["txtInquiryID"].Value + "','" + row.Cells["txtTrackingID"].Value + "','" + row.Cells["txtReportingID"].Value + "','" + row.Cells["txtInquiryName"].Value + "','" + row.Cells["txtInquiryDateOfBirth"].Value + "','" + row.Cells["txtInquiryAddressLine1"].Value + "','" + row.Cells["txtInquiryCity"].Value + "','" + row.Cells["txtInquiryProvince"].Value + "','" + row.Cells["txtInquiryPostalCode"].Value + "','" + row.Cells["txtInquiryCountry"].Value + "','" + row.Cells["txtInquiryNotes"].Value + "','" + row.Cells["txtDecision"].Value + "','" + row.Cells["txtReasonCode"].Value + "','" + row.Cells["txtUserName"].Value + "','" + row.Cells["txtDecisioningNotes"].Value + "','" + row.Cells["txtEntityID"].Value + "','" + row.Cells["txtListEntryID"].Value + "','" + row.Cells["txtName"].Value + "','" + row.Cells["txtType"].Value + "','" + row.Cells["txtDateOfBirth"].Value + "','" + row.Cells["txtDate"].Value + "','" + row.Cells["txtAddress"].Value + "','" + row.Cells["txtEvenList"].Value + "','" + row.Cells["txtMatchScore"].Value + "','" + row.Cells["txtCVIP"].Value + "','" + Environment.UserName.ToString() + "','" + Environment.MachineName.ToString() + "','" + row.Cells["txtAssociateName"].Value + "')";
                        cmd.CommandText = "insert into dbo.tbl_batchworkflow_rdcupload_daily_dotnet (BatchID,BatchType,BatchSubmittedDate,BatchCompletedDate,BatchStatus,InquiryID,TrackingID,ReportingID,InquiryName,InquiryDateOfBirth,InquiryAddressLine1,InquiryCity,InquiryProvince,InquiryPostalCode,InquiryCountry,InquiryNotes,Decision,ReasonCode,UserName,DecisioningNotes,EntityID,ListEntryID,Name,Type,DateOfBirth,Date,Address,EventList,MatchScore,CVIP,UploadedBy,MachineName,FirmNo) values('" + row.Cells["txtBatchID"].Value + "','" + row.Cells["txtBatchType"].Value + "','" + row.Cells["txtBatchSubmittedDate"].Value + "','" + row.Cells["txtBatchCompletedDate"].Value + "','" + row.Cells["txtBatchStatus"].Value + "','" + row.Cells["txtInquiryID"].Value + "','" + row.Cells["txtTrackingID"].Value + "','" + row.Cells["txtReportingID"].Value + "','" + row.Cells["txtInquiryName"].Value + "','" + row.Cells["txtInquiryDateOfBirth"].Value + "','" + row.Cells["txtInquiryAddressLine1"].Value + "','" + row.Cells["txtInquiryCity"].Value + "','" + row.Cells["txtInquiryProvince"].Value + "','" + row.Cells["txtInquiryPostalCode"].Value + "','" + row.Cells["txtInquiryCountry"].Value + "','" + row.Cells["txtInquiryNotes"].Value + "','" + row.Cells["txtDecision"].Value + "','" + row.Cells["txtReasonCode"].Value + "','" + row.Cells["txtUserName"].Value + "','" + row.Cells["txtDecisioningNotes"].Value + "','" + row.Cells["txtEntityID"].Value + "','" + row.Cells["txtListEntryID"].Value + "','" + row.Cells["txtName"].Value + "','" + row.Cells["txtType"].Value + "','" + row.Cells["txtDateOfBirth"].Value + "','" + row.Cells["txtDate"].Value + "','" + row.Cells["txtAddress"].Value + "','" + row.Cells["txtEventList"].Value + "','" + row.Cells["txtMatchScore"].Value + "','" + row.Cells["txtCVIP"].Value + "','" + Environment.UserName.ToString() + "','" + Environment.MachineName.ToString() + "','" + row.Cells["txtFirmNo"].Value + "')";
                        cmd.ExecuteNonQuery();
                    }
                        
                    conn.Close();
                    
                    //inserting records into final parties and inquiries table
                    int numrows = dataGridView1.Rows.Count - 1;
                    cmd.Parameters.Clear();
                    conn.ConnectionString = connectionstringtxt;
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_batchworkflow_rdcupload_archive_dotnet";
                    cmd.Parameters.AddWithValue("@UploadedBy", Environment.UserName.ToString());
                    cmd.Parameters.Add("@UploadErrorMessage", SqlDbType.NVarChar, 2000);
                    cmd.Parameters["@UploadErrorMessage"].Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    string uploadmessage = cmd.Parameters["@UploadErrorMessage"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();

                    //MessageBox.Show("Rows uploaded successfully");
                     
                    
                }
                catch (Exception ab)
                {
                    MessageBox.Show("Rows uploaded unsuccessfully into final table");
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    datagridview1_display_overall();
                    MessageBox.Show("Error Generated Details :" + ab.ToString());
                }
            }
            else
            {
                excelfilepath.Focus();
            }
        }

        public void datagridview1_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select FirmNo,ID,BatchID,BatchType,BatchSubmittedDate,BatchCompletedDate,BatchStatus,InquiryID,TrackingID,ReportingID,InquiryName,InquiryDateOfBirth,InquiryAddressLine1,InquiryCity,InquiryProvince,InquiryPostalCode,InquiryCountry,InquiryNotes,Decision,ReasonCode,UserName,DecisioningNotes,EntityID,ListEntryID,Name,Type,DateOfBirth,Date,Address,EventList,MatchScore,CVIP,UploadDateTime,UploadedBy,MachineName from dbo.tbl_batchworkflow_rdcupload_daily_dotnet with(nolock) order by ID";
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start("inmum-i-fs5\\group$:\\Global Corporate & Data Strategy\\Data Reference\\Workflow\\2018\\MFC - 2018 Workflow");
                System.Diagnostics.Process.Start("https://wtwonlineap.sharepoint.com/sites/tctnonclient_edskycoms/_layouts/15/Doc.aspx?sourcedoc=%7B542BDC1B-1F04-4E72-A222-CA87E58326DD%7D&file=RDCUpload.xls&action=default&mobileredirect=true&CT=1748874780415&OR=ItemsView");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 obj_form4 = new Form4();
            obj_form4.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
