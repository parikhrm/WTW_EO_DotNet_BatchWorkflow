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
    public partial class PassFort_Batch_OMS : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public PassFort_Batch_OMS()
        {
            InitializeComponent();
        }

        private void PassFort_Batch_OMS_Load(object sender, EventArgs e)
        {
            matchcriteria_list();
            inquirystatus_list();
            riskcategory_list();
            queryremarks_list();
            searchby_empname_list();
            reset_overall();
        }

        public void queryremarks_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                QueryRemarks obj_queryremarks = new QueryRemarks();
                DataTable dtaa = new DataTable();
                obj_queryremarks.queryremarks_list(dtaa);
                query_remarks.DataSource = dtaa;
                query_remarks.DisplayMember = "QueryRemarks";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void searchby_empname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empname = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empname.empdetails_searchby_passfort_list(dtaa);
                searchby_associatename.DataSource = dtaa;
                searchby_associatename.DisplayMember = "EmpName";
                conn.Close();
                searchby_associatename.SelectedIndex = -1;

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void inquirystatus_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                InquiryStatus obj_inquirystatus = new InquiryStatus();
                DataTable dtaa = new DataTable();
                //DataTable dtaa1 = new DataTable();
                obj_inquirystatus.inquirystatus_list(dtaa);
                //obj_inquirystatus.inquirystatus_searchby_list(dtaa1);
                inquiry_status.DataSource = dtaa;
                inquiry_status.DisplayMember = "InquiryStatus";
                //searchby_inquirystatus_batchworkflow.DataSource = dtaa1;
                //searchby_inquirystatus_batchworkflow.DisplayMember = "InquiryStatus";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }


        public void matchcriteria_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                MatchCriteria obj_matchcriteria = new MatchCriteria();
                DataTable dtaa = new DataTable();
                obj_matchcriteria.matchcriteria_list(dtaa);
                match_criteria.DataSource = dtaa;
                match_criteria.DisplayMember = "MatchCriteria";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void riskcategory_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                RiskCategory obj_riskcategory = new RiskCategory();
                DataTable dtaa = new DataTable();
                obj_riskcategory.riskcategory_list(dtaa);
                risk_category.DataSource = dtaa;
                risk_category.DisplayMember = "RiskCategory";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void reset_overall()
        {
            insert.Enabled = true;
            update.Enabled = false;
            current_datetime.Text = DateTime.Now.ToLongDateString();
            current_datetime.Visible = false;
            requestid.Enabled = false;
            requestid.Text = string.Empty;
            clientname.Text = string.Empty;
            principal_name.Text = string.Empty;
            received_date.CustomFormat = " ";
            received_time.CustomFormat = " ";
            match_criteria.SelectedIndex = -1;
            inquiry_status.SelectedIndex = -1;
            risk_category.SelectedIndex = -1;
            query_remarks.SelectedIndex = -1;
            approval_raised_date.CustomFormat = " ";
            approval_raised_time.CustomFormat = " ";
            approval_received_date.CustomFormat = " ";
            approval_received_time.CustomFormat = " ";
            smso_raised_date.CustomFormat = " ";
            smso_raised_time.CustomFormat = " ";
            smso_justification.Text = string.Empty;
            smso_approver_name.Text = string.Empty;
            query_raised_date.CustomFormat = " ";
            query_raised_time.CustomFormat = " ";
            completion_date.CustomFormat = " ";
            completion_time.CustomFormat = " ";
            pf_risk_category.SelectedIndex = -1;
            public_private.SelectedIndex = -1;
            no_of_dno_ubo_sh_added.Text = string.Empty;
            risk_changed.SelectedIndex = -1;
            pass_final.SelectedIndex = -1;
            comments.Text = string.Empty;
            business_confirmed_client_active.Checked = false;
            confirmed_by_business_name.Text = string.Empty;
            confirmed_by_business_name.Enabled = false;
            date_of_bu_confirmation.CustomFormat = " ";
            date_of_bu_confirmation.Enabled = false;
            datagridview_display_overall();
        }

        public void datagridview_display_overall()
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

                if (string.IsNullOrEmpty(searchby_clientname.Text) && string.IsNullOrEmpty(searchby_associatename.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 RequestID,ClientName,PrinciplaName,Received_Date,Received_Time,Match_Criteria,Inquiry_Status,Risk_Catetory,QueryRemark,Approval_Raised_Date,Approval_Raised_Time,Approval_Received_Date,Approval_Received_Time,SMSO_Raised_Date,SMSO_Raised_Time,SMSO_Received_Date,SMSO_Received_Time,SMSO_Justification,SMSO_Approver_Name,Query_Raised_Date,Query_Raised_Time,Query_Received_Date,Query_Received_Time,Completion_Date,Completion_Time,PF_Risk_Category,Public_Private,No_Of_DNO_UBO_SH_Added,Risk_Changed,Pass_Fail,Comments,Business_Confirmed_Client_Inactive,Confirmed_By_Business_Name,Date_Of_BU_Confirmation,a.LastUpdatedDateTime,b.EmpName from dbo.tbl_passfort_batch_oms_daily_dotnet a with(nolock)  inner join dbo.tbl_emp_details b with(nolock) on a.lastupdatedby = substring(b.intid,5,len(b.intid)) where a.IsDeleted = 0 and a.lastupdatedby = @lastupdatedby";
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_passfort_batch_oms_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(searchby_clientname.Text))
                    {
                        cmd.Parameters.AddWithValue("@clientname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@clientname", searchby_clientname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_associatename.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename", searchby_associatename.Text);
                    }

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

        private void received_date_ValueChanged(object sender, EventArgs e)
        {
            received_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void received_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                received_date.CustomFormat = " ";
            }
        }

        private void received_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                received_time.CustomFormat = " ";
            }
        }

        private void received_time_MouseDown(object sender, MouseEventArgs e)
        {
            received_time.CustomFormat = "HH:mm:ss";
            received_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void approval_raised_date_ValueChanged(object sender, EventArgs e)
        {
            approval_raised_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void approval_raised_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approval_raised_date.CustomFormat = " ";
            }
        }

        private void approval_raised_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approval_raised_time.CustomFormat = " ";
            }
        }

        private void approval_raised_time_MouseDown(object sender, MouseEventArgs e)
        {
            approval_raised_time.CustomFormat = "HH:mm:ss";
            approval_raised_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void approval_received_date_ValueChanged(object sender, EventArgs e)
        {
            approval_received_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void approval_received_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approval_received_date.CustomFormat = " ";
            }
        }

        private void approval_received_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approval_received_time.CustomFormat = " ";
            }
        }

        private void approval_received_time_MouseDown(object sender, MouseEventArgs e)
        {
            approval_received_time.CustomFormat = "HH:mm:ss";
            approval_received_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void smso_raised_date_ValueChanged(object sender, EventArgs e)
        {
            smso_raised_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void smso_raised_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smso_raised_date.CustomFormat = " ";
            }
        }

        private void smso_raised_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smso_raised_time.CustomFormat = " ";
            }
        }

        private void smso_raised_time_MouseDown(object sender, MouseEventArgs e)
        {
            smso_raised_time.CustomFormat = "HH:mm:ss";
            smso_raised_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void query_raised_date_ValueChanged(object sender, EventArgs e)
        {
            query_raised_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void query_raised_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                query_raised_date.CustomFormat = " ";
            }
        }

        private void query_raised_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                query_raised_time.CustomFormat = " ";
            }
        }

        private void query_raised_time_MouseDown(object sender, MouseEventArgs e)
        {
            query_raised_time.CustomFormat = "HH:mm:ss";
            query_raised_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void completion_date_ValueChanged(object sender, EventArgs e)
        {
            completion_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void completion_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completion_date.CustomFormat = " ";
            }
        }

        private void completion_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completion_time.CustomFormat = " ";
            }
        }

        private void completion_time_MouseDown(object sender, MouseEventArgs e)
        {
            completion_time.CustomFormat = "HH:mm:ss";
            completion_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void date_of_bu_confirmation_ValueChanged(object sender, EventArgs e)
        {
            date_of_bu_confirmation.CustomFormat = "dd-MMMM-yyyy";
        }

        private void date_of_bu_confirmation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                date_of_bu_confirmation.CustomFormat = " ";
            }
        }

        private void query_received_date_ValueChanged(object sender, EventArgs e)
        {
            query_received_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void query_received_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                query_received_date.CustomFormat = " ";
            }
        }

        private void query_received_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                query_received_time.CustomFormat = " ";
            }
        }

        private void query_received_time_MouseDown(object sender, MouseEventArgs e)
        {
            query_received_time.CustomFormat = "HH:mm:ss";
            query_received_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_passfort_batch_oms_insert_daily_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ClientName", clientname.Text);
                cmd.Parameters.AddWithValue("@PrinciplaName",principal_name.Text);
                cmd.Parameters.AddWithValue("@Received_Date", received_date.Value.Date);
                cmd.Parameters.AddWithValue("@Received_Time", received_time.Value.ToLongTimeString());
                if (string.IsNullOrEmpty(match_criteria.Text))
                {
                    cmd.Parameters.AddWithValue("@Match_Criteria", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Match_Criteria", match_criteria.Text);
                }
                cmd.Parameters.AddWithValue("@Inquiry_Status", inquiry_status.Text);
                if (string.IsNullOrEmpty(risk_category.Text))
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", risk_category.Text);
                }
                if (string.IsNullOrEmpty(query_remarks.Text))
                {
                    cmd.Parameters.AddWithValue("@QueryRemark", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryRemark", query_remarks.Text);
                }
                if (approval_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Approval_Raised_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Approval_Raised_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Approval_Raised_Date", approval_raised_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Approval_Raised_Time", approval_raised_time.Value.ToLongTimeString());
                }
                if (approval_received_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Approval_Received_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Approval_Received_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Approval_Received_Date", approval_received_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Approval_Received_Time", approval_received_time.Value.ToLongTimeString());
                }
                if (smso_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Date", smso_raised_date.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Time", smso_raised_time.Value.ToLongTimeString());
                }
                if (smso_received_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSO_Received_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSO_Received_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Received_Date", smso_received_date.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSO_Received_Time", smso_received_time.Value.ToLongTimeString());
                }
                if (string.IsNullOrEmpty(smso_justification.Text))
                {
                    cmd.Parameters.AddWithValue("@SMSO_Justification", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Justification", smso_justification.Text);
                }
                if (string.IsNullOrEmpty(smso_approver_name.Text))
                {
                    cmd.Parameters.AddWithValue("@SMSO_Approver_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Approver_Name", smso_approver_name.Text);
                }
                if (query_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Query_Raised_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Query_Raised_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Query_Raised_Date", query_raised_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Query_Raised_Time", query_raised_time.Value.ToLongTimeString());
                }
                if (query_received_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Query_Received_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Query_Received_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Query_Received_Date", query_received_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Query_Received_Time", query_received_time.Value.ToLongTimeString());
                }
                if (completion_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Completion_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Completion_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Completion_Date", completion_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Completion_Time", completion_time.Value.ToLongTimeString());
                }
                if (string.IsNullOrEmpty(pf_risk_category.Text))
                {
                    cmd.Parameters.AddWithValue("@PF_Risk_Category", pf_risk_category.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PF_Risk_Category", pf_risk_category.Text);
                }
                if (string.IsNullOrEmpty(public_private.Text))
                {
                    cmd.Parameters.AddWithValue("@Public_Private", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Public_Private", public_private.Text);
                }
                if (string.IsNullOrEmpty(no_of_dno_ubo_sh_added.Text))
                {
                    cmd.Parameters.AddWithValue("@No_Of_DNO_UBO_SH_Added", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@No_Of_DNO_UBO_SH_Added", no_of_dno_ubo_sh_added.Text);
                }
                if (string.IsNullOrEmpty(risk_changed.Text))
                {
                    cmd.Parameters.AddWithValue("@Risk_Changed", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Risk_Changed", risk_category.Text);
                }
                if (string.IsNullOrEmpty(pass_final.Text))
                {
                    cmd.Parameters.AddWithValue("@Pass_Fail", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Pass_Fail", pass_final.Text);
                }
                if (string.IsNullOrEmpty(comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Comments", comments.Text);
                }
                if (business_confirmed_client_active.Checked == false)
                {
                    cmd.Parameters.AddWithValue("@Business_Confirmed_Client_Inactive", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Business_Confirmed_Client_Inactive", "Yes");
                }
                if (string.IsNullOrEmpty(confirmed_by_business_name.Text))
                {
                    cmd.Parameters.AddWithValue("@Confirmed_By_Business_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Confirmed_By_Business_Name", confirmed_by_business_name.Text);
                }
                if (date_of_bu_confirmation.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Date_Of_BU_Confirmation", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Date_Of_BU_Confirmation", date_of_bu_confirmation.Value.Date);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());

                
                //if conditions
                if (received_date.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Date");
                }
                else if (received_time.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Time");
                }
                else if (string.IsNullOrEmpty(clientname.Text))
                {
                    MessageBox.Show("Please update Client Name");
                }
                else if (string.IsNullOrEmpty(principal_name.Text))
                {
                    MessageBox.Show("Please update Principal Name");
                }
                else if (string.IsNullOrEmpty(inquiry_status.Text))
                {
                    MessageBox.Show("Please update Inquiry Status");
                }
                else if (received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than today's date");
                }
                else if (smso_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be more than today's date");
                }
                else if (smso_received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("SMSO Received date cannot be more than today's date");
                }
                else if (query_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Query Raised Date cannot be more than today's date");
                }
                else if (query_received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Query Received Date cannot be more than today's date");
                }
                else if (approval_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Approval Raised Date cannot be more than today's date");
                }
                else if (approval_received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Approval Received Date cannot be more than today's date");
                }
                else if (received_date.Value.Date > smso_raised_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than SMSO Raised date");
                }
                else if (received_date.Value.Date > smso_received_date.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than SMSO Received Date");
                }
                else if (received_date.Value.Date > query_raised_date.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than Query Raised Date");
                }
                else if (received_date.Value.Date > query_received_date.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than Query Received Date");
                }
                else if (received_date.Value.Date > approval_raised_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than Approval Raised Date");
                }
                else if (received_date.Value.Date > approval_received_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than Approval Received Date");
                }
                else if (received_date.Value.Date > completion_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than completion date");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void smso_received_date_ValueChanged(object sender, EventArgs e)
        {
            smso_received_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void smso_received_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smso_received_date.CustomFormat = " ";
            }
        }

        private void smso_received_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smso_received_time.CustomFormat = " ";
            }
        }

        private void smso_received_time_MouseDown(object sender, MouseEventArgs e)
        {
            smso_received_time.CustomFormat = "HH:mm:ss";
            smso_received_time.Text = DateTime.Now.ToLongTimeString();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_passfort_batch_oms_update_daily_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@RequestID",requestid.Text);
                cmd.Parameters.AddWithValue("@ClientName", clientname.Text);
                cmd.Parameters.AddWithValue("@PrinciplaName",principal_name.Text);
                cmd.Parameters.AddWithValue("@Received_Date", received_date.Value.Date);
                cmd.Parameters.AddWithValue("@Received_Time", received_time.Value.ToLongTimeString());
                if (string.IsNullOrEmpty(match_criteria.Text))
                {
                    cmd.Parameters.AddWithValue("@Match_Criteria", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Match_Criteria", match_criteria.Text);
                }
                cmd.Parameters.AddWithValue("@Inquiry_Status", inquiry_status.Text);
                if (string.IsNullOrEmpty(risk_category.Text))
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", risk_category.Text);
                }
                if (string.IsNullOrEmpty(query_remarks.Text))
                {
                    cmd.Parameters.AddWithValue("@QueryRemark", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryRemark", query_remarks.Text);
                }
                if (approval_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Approval_Raised_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Approval_Raised_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Approval_Raised_Date", approval_raised_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Approval_Raised_Time", approval_raised_time.Value.ToLongTimeString());
                }
                if (approval_received_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Approval_Received_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Approval_Received_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Approval_Received_Date", approval_received_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Approval_Received_Time", approval_received_time.Value.ToLongTimeString());
                }
                if (smso_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Date", smso_raised_date.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSO_Raised_Time", smso_raised_time.Value.ToLongTimeString());
                }
                if (smso_received_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSO_Received_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSO_Received_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Received_Date", smso_received_date.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSO_Received_Time", smso_received_time.Value.ToLongTimeString());
                }
                if (string.IsNullOrEmpty(smso_justification.Text))
                {
                    cmd.Parameters.AddWithValue("@SMSO_Justification", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Justification", smso_justification.Text);
                }
                if (string.IsNullOrEmpty(smso_approver_name.Text))
                {
                    cmd.Parameters.AddWithValue("@SMSO_Approver_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSO_Approver_Name", smso_approver_name.Text);
                }
                if (query_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Query_Raised_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Query_Raised_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Query_Raised_Date", query_raised_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Query_Raised_Time", query_raised_time.Value.ToLongTimeString());
                }
                if (query_received_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Query_Received_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Query_Received_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Query_Received_Date", query_received_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Query_Received_Time", query_received_time.Value.ToLongTimeString());
                }
                if (completion_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Completion_Date", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Completion_Time", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Completion_Date", completion_date.Value.Date);
                    cmd.Parameters.AddWithValue("@Completion_Time", completion_time.Value.ToLongTimeString());
                }
                if (string.IsNullOrEmpty(pf_risk_category.Text))
                {
                    cmd.Parameters.AddWithValue("@PF_Risk_Category", pf_risk_category.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PF_Risk_Category", pf_risk_category.Text);
                }
                if (string.IsNullOrEmpty(public_private.Text))
                {
                    cmd.Parameters.AddWithValue("@Public_Private", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Public_Private", public_private.Text);
                }
                if (string.IsNullOrEmpty(no_of_dno_ubo_sh_added.Text))
                {
                    cmd.Parameters.AddWithValue("@No_Of_DNO_UBO_SH_Added", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@No_Of_DNO_UBO_SH_Added", no_of_dno_ubo_sh_added.Text);
                }
                if (string.IsNullOrEmpty(risk_changed.Text))
                {
                    cmd.Parameters.AddWithValue("@Risk_Changed", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Risk_Changed", risk_category.Text);
                }
                if (string.IsNullOrEmpty(pass_final.Text))
                {
                    cmd.Parameters.AddWithValue("@Pass_Fail", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Pass_Fail", pass_final.Text);
                }
                if (string.IsNullOrEmpty(comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Comments", comments.Text);
                }
                if (string.IsNullOrEmpty(business_confirmed_client_active.Text))
                {
                    cmd.Parameters.AddWithValue("@Business_Confirmed_Client_Inactive", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Business_Confirmed_Client_Inactive", "Yes");
                }
                if (business_confirmed_client_active.Checked == false)
                {
                    cmd.Parameters.AddWithValue("@Confirmed_By_Business_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Confirmed_By_Business_Name", confirmed_by_business_name.Text);
                }
                if (date_of_bu_confirmation.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Date_Of_BU_Confirmation", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Date_Of_BU_Confirmation", date_of_bu_confirmation.Value.Date);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());


                //if conditions
                if (received_date.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Date");
                }
                else if (received_time.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Received Time");
                }
                else if (string.IsNullOrEmpty(clientname.Text))
                {
                    MessageBox.Show("Please update Client Name");
                }
                else if (string.IsNullOrEmpty(principal_name.Text))
                {
                    MessageBox.Show("Please update Principal Name");
                }
                else if (string.IsNullOrEmpty(inquiry_status.Text))
                {
                    MessageBox.Show("Please update Inquiry Status");
                }
                else if (received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than today's date");
                }
                else if (smso_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be more than today's date");
                }
                else if (smso_received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("SMSO Received date cannot be more than today's date");
                }
                else if (query_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Query Raised Date cannot be more than today's date");
                }
                else if (query_received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Query Received Date cannot be more than today's date");
                }
                else if (approval_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Approval Raised Date cannot be more than today's date");
                }
                else if (approval_received_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Approval Received Date cannot be more than today's date");
                }
                else if (received_date.Value.Date > smso_raised_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than SMSO Raised date");
                }
                else if (received_date.Value.Date > smso_received_date.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than SMSO Received Date");
                }
                else if (received_date.Value.Date > query_raised_date.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than Query Raised Date");
                }
                else if (received_date.Value.Date > query_received_date.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than Query Received Date");
                }
                else if (received_date.Value.Date > approval_raised_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than Approval Raised Date");
                }
                else if (received_date.Value.Date > approval_received_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than Approval Received Date");
                }
                else if (received_date.Value.Date > completion_date.Value.Date)
                {
                    MessageBox.Show("Received date cannot be more than completion date");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void searchby_clientname_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_associatename_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void business_confirmed_client_active_CheckedChanged(object sender, EventArgs e)
        {
            if (business_confirmed_client_active.Checked == true)
            {
                confirmed_by_business_name.Enabled = true;
                date_of_bu_confirmation.Enabled = true;
            }
            else
            {
                confirmed_by_business_name.Enabled = false;
                confirmed_by_business_name.Text = string.Empty;
                date_of_bu_confirmation.Enabled = false;
                date_of_bu_confirmation.CustomFormat = " ";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    requestid.Text = row.Cells["txt_RequestID"].Value.ToString();
                    clientname.Text = row.Cells["txt_ClientName"].Value.ToString();
                    principal_name.Text = row.Cells["txt_PrinciplaName"].Value.ToString();
                    received_date.Text = row.Cells["txt_Received_Date"].Value.ToString();
                    received_date.CustomFormat = "dd-MMMM-yyyy";
                    received_time.Text = row.Cells["txt_Received_Time"].Value.ToString();
                    received_time.CustomFormat = "HH:mm:ss";
                    if (string.IsNullOrEmpty(row.Cells["txt_Match_Criteria"].Value.ToString()))
                    {
                        match_criteria.SelectedIndex = -1; ;
                    }
                    else
                    {
                        match_criteria.Text = row.Cells["txt_Match_Criteria"].Value.ToString();
                    }
                    inquiry_status.Text = row.Cells["txt_Inquiry_Status"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txt_Risk_Catetory"].Value.ToString()))
                    {
                        risk_category.SelectedIndex = -1;
                    }
                    else
                    {
                        risk_category.Text = row.Cells["txt_Risk_Catetory"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_QueryRemark"].Value.ToString()))
                    {
                        query_remarks.SelectedIndex = -1;
                    }
                    else
                    {
                        query_remarks.Text = row.Cells["txt_QueryRemark"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Approval_Raised_Date"].Value.ToString()))
                    {
                        approval_raised_date.CustomFormat = " ";
                        approval_raised_time.CustomFormat = " ";
                    }
                    else
                    {
                        approval_raised_date.Text = row.Cells["txt_Approval_Raised_Date"].Value.ToString();
                        approval_raised_date.CustomFormat = "dd-MMMM-yyyy";
                        approval_raised_time.Text = row.Cells["txt_Approval_Raised_Time"].Value.ToString();
                        approval_raised_time.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Approval_Received_Date"].Value.ToString()))
                    {
                        approval_received_date.CustomFormat = " ";
                        approval_received_time.CustomFormat = " ";
                    }
                    else
                    {
                        approval_received_date.Text = row.Cells["txt_Approval_Received_Date"].Value.ToString();
                        approval_received_date.CustomFormat = "dd-MMMM-yyyy";
                        approval_received_time.Text = row.Cells["txt_Approval_Received_Time"].Value.ToString();
                        approval_received_time.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_SMSO_Raised_Date"].Value.ToString()))
                    {
                        smso_raised_date.CustomFormat = " ";
                        smso_raised_time.CustomFormat = " ";
                    }
                    else
                    {
                        smso_raised_date.Text = row.Cells["txt_SMSO_Raised_Date"].Value.ToString();
                        smso_raised_date.CustomFormat = "dd-MMMM-yyyy";
                        smso_raised_time.Text = row.Cells["txt_SMSO_Raised_Time"].Value.ToString();
                        smso_raised_time.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_SMSO_Received_Date"].Value.ToString()))
                    {
                        smso_received_date.CustomFormat = " ";
                        smso_received_time.CustomFormat = " ";
                    }
                    else
                    {
                        smso_received_date.Text = row.Cells["txt_SMSO_Received_Date"].Value.ToString();
                        smso_received_date.CustomFormat = "dd-MMMM-yyyy";
                        smso_received_time.Text = row.Cells["txt_SMSO_Received_Time"].Value.ToString();
                        smso_received_time.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_SMSO_Justification"].Value.ToString()))
                    {
                        smso_justification.Text = string.Empty;
                    }
                    else
                    {
                        smso_justification.Text = row.Cells["txt_SMSO_Justification"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_SMSO_Approver_Name"].Value.ToString()))
                    {
                        smso_approver_name.Text = string.Empty;
                    }
                    else
                    {
                        smso_approver_name.Text = row.Cells["txt_SMSO_Approver_Name"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Query_Raised_Date"].Value.ToString()))
                    {
                        query_raised_date.CustomFormat = " ";
                        query_raised_time.CustomFormat = " ";
                    }
                    else
                    {
                        query_raised_date.Text = row.Cells["txt_Query_Raised_Date"].Value.ToString();
                        query_raised_date.CustomFormat = "dd-MMMM-yyyy";
                        query_raised_time.Text = row.Cells["txt_Query_Raised_Time"].Value.ToString();
                        query_raised_time.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Query_Received_Date"].Value.ToString()))
                    {
                        query_received_date.CustomFormat = " ";
                        query_received_time.CustomFormat = " ";
                    }
                    else
                    {
                        query_received_date.Text = row.Cells["txt_Query_Received_Date"].Value.ToString();
                        query_received_date.CustomFormat = "dd-MMMM-yyyy";
                        query_received_time.Text = row.Cells["txt_Query_Received_Time"].Value.ToString();
                        query_received_time.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Completion_Date"].Value.ToString()))
                    {
                        completion_date.CustomFormat = " ";
                        completion_time.CustomFormat = " ";
                    }
                    else
                    {
                        completion_date.Text = row.Cells["txt_Completion_Date"].Value.ToString();
                        completion_date.CustomFormat = "dd-MMMM-yyyy";
                        completion_time.Text = row.Cells["txt_Completion_Time"].Value.ToString();
                        completion_time.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_PF_Risk_Category"].Value.ToString()))
                    {
                        pf_risk_category.SelectedIndex = -1;
                    }
                    else
                    {
                        pf_risk_category.Text = row.Cells["txt_PF_Risk_Category"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Public_Private"].Value.ToString()))
                    {
                        public_private.SelectedIndex = -1;
                    }
                    else
                    {
                        public_private.Text = row.Cells["txt_Public_Private"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_No_Of_DNO_UBO_SH_Added"].Value.ToString()))
                    {
                        no_of_dno_ubo_sh_added.Text = string.Empty;
                    }
                    else
                    {
                        no_of_dno_ubo_sh_added.Text = row.Cells["txt_No_Of_DNO_UBO_SH_Added"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Risk_Changed"].Value.ToString()))
                    {
                        risk_changed.SelectedIndex = -1;
                    }
                    else
                    {
                        risk_changed.Text = row.Cells["txt_Risk_Changed"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Pass_Fail"].Value.ToString()))
                    {
                        pass_final.SelectedIndex = -1;
                    }
                    else
                    {
                        pass_final.Text = row.Cells["txt_Pass_Fail"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Comments"].Value.ToString()))
                    {
                        comments.Text = string.Empty;
                    }
                    else
                    {
                        comments.Text = row.Cells["txt_Comments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Business_Confirmed_Client_Inactive"].Value.ToString()))
                    {
                        business_confirmed_client_active.Checked = false;
                        confirmed_by_business_name.Text = string.Empty;
                        date_of_bu_confirmation.CustomFormat = " ";
                    }
                    else
                    {
                        business_confirmed_client_active.Checked = true;
                        confirmed_by_business_name.Text = row.Cells["txt_Confirmed_By_Business_Name"].Value.ToString();
                        date_of_bu_confirmation.Text = row.Cells["txt_Date_Of_BU_Confirmation"].Value.ToString();
                        date_of_bu_confirmation.CustomFormat = "dd-MMMM-yyyy";
                    }
                }
                insert.Enabled = false;
                update.Enabled = true;
            }

            else
            {
                requestid.Focus();
                insert.Enabled = true;
                update.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 obj_form4 = new Form4();
            obj_form4.Show();
        }

        private void match_criteria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                match_criteria.SelectedIndex = -1;
            }
        }

        private void inquiry_status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                inquiry_status.SelectedIndex = -1;
            }
        }

        private void risk_category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                risk_category.SelectedIndex = -1;
            }
        }

        private void query_remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                query_remarks.SelectedIndex = -1;
            }
        }

        private void pf_risk_category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                pf_risk_category.SelectedIndex = -1;
            }
        }

        private void public_private_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                public_private.SelectedIndex = -1;
            }
        }

        private void risk_changed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                risk_changed.SelectedIndex = -1;
            }
        }

        private void pass_final_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                pass_final.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://app.powerbi.com/groups/81c3ab7d-0a2a-46f2-b54f-38eb239011a1/reports/930a495d-9c0b-4039-a7b8-b0a12fe94dc8/ReportSection31a41de679b2bcefa277?experience=power-bi");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void received_date_MouseHover(object sender, EventArgs e)
        {
            received_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void clientname_TextChanged(object sender, EventArgs e)
        {
            //clientname.Select(0, 0);
        }

        private void principal_name_TextChanged(object sender, EventArgs e)
        {
            //principal_name.Select(0, 0);
        }

        private void comments_Leave(object sender, EventArgs e)
        {
            //comments.Select(0, 0);
        }

        private void comments_Enter(object sender, EventArgs e)
        {
            //comments.Select(0, 0);
        }

        private void comments_MouseClick(object sender, MouseEventArgs e)
        {
            //comments.Select(0, 0);
        }

        private void PassFort_Batch_OMS_Click(object sender, EventArgs e)
        {
            //clientname.Select(0, 0);
        }

        private void completion_date_MouseHover(object sender, EventArgs e)
        {
            completion_date.CustomFormat = "dd-MMMM-yyyy";
        }
    }
}
