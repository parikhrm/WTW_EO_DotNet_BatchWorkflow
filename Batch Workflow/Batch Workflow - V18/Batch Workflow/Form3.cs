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
    public partial class Form3 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //public string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            associatename_list();
            sourcebu_list();
            reset_overall();
        }

        public void reset_overall()
        {
            datagridview_display();
            pagenumber_from.Value = 0;
            pagenumber_to.Value = 0;
            batchid_associatename.Text = string.Empty;
            batchid_project.Text = string.Empty;
            associatename.SelectedIndex = -1;
            adminlevel.Visible = false;

            if (adminlevel.Text == "Admin")
            {
                update_associatename.Enabled = true;
            }
            else
            {
                update_associatename.Enabled = false;
            }
            sourcebu_project.SelectedIndex = -1;
        }

        public void datagridview_display()
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
                if (!string.IsNullOrEmpty(searchby_batchid.Text) && string.IsNullOrEmpty(searchby_pagenumber.Text))
                {
                    cmd.CommandText = "select RequestID,PageNumber,AssociateName_Allocation,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,InquiryStatus,ProjectNonProject from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and batchid = @batchid order by BatchID,InquiryID";
                    cmd.Parameters.AddWithValue("@batchid", Convert.ToInt32(searchby_batchid.Text));
                }
                else if(!string.IsNullOrEmpty(searchby_pagenumber.Text) && string.IsNullOrEmpty(searchby_batchid.Text))
                {
                    cmd.CommandText = "select RequestID,PageNumber,AssociateName_Allocation,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,InquiryStatus,ProjectNonProject from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and pagenumber = @pagenumber order by BatchID,InquiryID";
                    cmd.Parameters.AddWithValue("@pagenumber", Convert.ToInt32(searchby_pagenumber.Text));
                }
                else if (!string.IsNullOrEmpty(searchby_pagenumber.Text) && !string.IsNullOrEmpty(searchby_batchid.Text))
                {
                    cmd.CommandText = "select RequestID,PageNumber,AssociateName_Allocation,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,InquiryStatus,ProjectNonProject from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and pagenumber = @pagenumber and batchid = @batchid order by BatchID,InquiryID";
                    cmd.Parameters.AddWithValue("@pagenumber", Convert.ToInt32(searchby_pagenumber.Text));
                    cmd.Parameters.AddWithValue("@batchid", Convert.ToInt32(searchby_batchid.Text));
                }
                else
                {
                    cmd.CommandText = "select top 100 RequestID,PageNumber,AssociateName_Allocation,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,InquiryStatus,ProjectNonProject from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 order by BatchID,InquiryID";
                }
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

        public void associatename_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                DataTable dtaa1 = new DataTable();
                obj_empdetails.empdetails_list (dtaa);
                associatename.DataSource = dtaa;
                associatename.DisplayMember = "EmpName";
                obj_empdetails.admin_list(dtaa1, Environment.UserName.ToString());
                adminlevel.DataSource = dtaa1;
                adminlevel.DisplayMember = "BatchWorkflow_Access";
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void sourcebu_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                
                SourceBU obj_sourcebu = new SourceBU();
                DataTable dtaa = new DataTable();
                obj_sourcebu.sourcebu_list (dtaa);
                sourcebu_project.DataSource = dtaa;
                sourcebu_project.DisplayMember = "ReportingID";
                conn.Close();
                
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                conn.Open();
                cmd.Connection = conn;
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure ;
                cmd.CommandText = "usp_batchworkflow_associatename_allocation_update_dotnet";
                cmd.Parameters.AddWithValue("@pagenumber_from", Convert.ToInt32(pagenumber_from.Value));
                cmd.Parameters.AddWithValue("@pagenumber_to",Convert.ToInt32(pagenumber_to.Value));
                cmd.Parameters.AddWithValue("@batchid",batchid_associatename.Text);
                cmd.Parameters.AddWithValue("@associatename",associatename.Text);
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@AllocatedBy",Environment.UserName.ToString());
                
                //if conditions
                if (string.IsNullOrEmpty(associatename.Text))
                {
                    MessageBox.Show("Please update Associate Name");
                }
                else if (pagenumber_from.Value <= 0)
                {
                    MessageBox.Show("Please update Page Number(from)");
                }
                else if (pagenumber_to.Value <= 0)
                {
                    MessageBox.Show("Please update Page Number(to)");
                }
                else if (string.IsNullOrEmpty(batchid_associatename.Text))
                {
                    MessageBox.Show("Please update BatchID");
                }
                else
                {
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
                
        }

        
        private void reset_Click(object sender, EventArgs e)
        {
            datagridview_display();
        }

        private void searchby_pagenumber_TextChanged(object sender, EventArgs e)
        {
            datagridview_display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 obj_form4 = new Form4();
            obj_form4.Show();
        }

        private void update_project_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update dbo.tbl_batchworkflow_daily_dotnet set ProjectNonProject = 'Project', Project_LastUpdatedDateTime = @lastupdateddatetime, Project_LastUpdatedBy = @lastupdatedby where batchid = @batchid";
            cmd.Parameters.AddWithValue("@batchid", batchid_project.Text);
            cmd.Parameters.AddWithValue("@lastupdateddatetime",DateTime.Now.ToLocalTime());
            cmd.Parameters.AddWithValue("@lastupdatedby",Environment.UserName.ToString());

            //if conditions
            if (string.IsNullOrEmpty(batchid_project.Text))
            {
                MessageBox.Show("Please update BatchID");
            }
            else
            {
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Updated Successfully");
                cmd.Parameters.Clear();
                reset_overall();
                conn.Close();
            }
        }

        private void searchby_batchid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update dbo.tbl_batchworkflow_daily_dotnet set ProjectNonProject = 'Project', Project_LastUpdatedDateTime = @lastupdateddatetime, Project_LastUpdatedBy = @lastupdatedby where EntityID = @entityid";
            cmd.Parameters.AddWithValue("@entityid", entityid_project.Text);
            cmd.Parameters.AddWithValue("@lastupdateddatetime", DateTime.Now.ToLocalTime());
            cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());

            //if conditions
            if (string.IsNullOrEmpty(entityid_project.Text))
            {
                MessageBox.Show("Please update EntityID");
            }
            else
            {
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Updated Successfully");
                cmd.Parameters.Clear();
                reset_overall();
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            conn.ConnectionString = connectionstringtxt;
            conn.Open();
            cmd.Connection = conn;
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update dbo.tbl_batchworkflow_daily_dotnet set ProjectNonProject = 'Project', Project_LastUpdatedDateTime = @lastupdateddatetime, Project_LastUpdatedBy = @lastupdatedby where BatchID = @batchid and SourceBU = @sourcebu " ;
            cmd.Parameters.AddWithValue("@batchid", batchid_project.Text);
            cmd.Parameters.AddWithValue("@sourcebu",sourcebu_project.Text);
            cmd.Parameters.AddWithValue("@lastupdateddatetime", DateTime.Now.ToLocalTime());
            cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());

            //if conditions
            if (string.IsNullOrEmpty(batchid_project.Text))
            {
                MessageBox.Show("Please update BatchID");
            }
            else  if (string.IsNullOrEmpty(sourcebu_project.Text))
            {
                MessageBox.Show("Please update SourceBU");
            }
            else
            {
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records Updated Successfully");
                cmd.Parameters.Clear();
                reset_overall();
                conn.Close();
            }
        }

        private void sourcebu_project_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                sourcebu_project.SelectedIndex = -1;
            }
        }
        
    }
}
