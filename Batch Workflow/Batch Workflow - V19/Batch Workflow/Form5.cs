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
    public partial class Form5 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            requestid.Enabled = false;
            receiveddate.Enabled = false;
            receivedtime.Enabled = false;
            matchcriteria_list();
            inquirystatus_list();
        }

        public void reset_overall()
        {
            matchcriteria.SelectedIndex = -1;
            inquirystatus.SelectedIndex = -1;
            approvalraiseddate.CustomFormat = " ";
            approvalraisedtime.CustomFormat = " ";
            approvalreceiveddate.CustomFormat = " ";
            approvalreceivedtime.CustomFormat = " ";
            completiondate.CustomFormat = " ";
            completiontime.CustomFormat = " ";
            approvalrejectioncomment.Text = string.Empty;
            datagridview_batchworkflow_display_overall();
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
                obj_matchcriteria.matchcriteria_L2_form_list(dtaa);
                matchcriteria.DataSource = dtaa;
                matchcriteria.DisplayMember = "MatchCriteria";
                conn.Close();

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
                DataTable dtaa1 = new DataTable();
                obj_inquirystatus.inquirystatus_L2_form_list (dtaa);
                obj_inquirystatus.inquirystatus_searchby_list(dtaa1);
                inquirystatus.DataSource = dtaa;
                inquirystatus.DisplayMember = "InquiryStatus";
                searchby_inquirystatus_batchworkflow.DataSource = dtaa1;
                searchby_inquirystatus_batchworkflow.DisplayMember = "InquiryStatus";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }


        private void approvalraiseddate_ValueChanged(object sender, EventArgs e)
        {
            approvalraiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void approvalraiseddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approvalraiseddate.CustomFormat = " ";
            }
        }

        private void approvalraisedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approvalraisedtime.CustomFormat = " ";
            }
        }

        private void approvalraisedtime_MouseDown(object sender, MouseEventArgs e)
        {
            approvalraisedtime.CustomFormat = "HH:mm:ss";
            approvalraisedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void approvalreceiveddate_ValueChanged(object sender, EventArgs e)
        {
            approvalreceiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void approvalreceiveddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approvalreceiveddate.CustomFormat = " ";
            }
        }

        private void approvalreceivedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                approvalreceivedtime.CustomFormat = " ";
            }
        }

        private void approvalreceivedtime_MouseDown(object sender, MouseEventArgs e)
        {
            approvalreceivedtime.CustomFormat = "HH:mm:ss";
            approvalreceivedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void completiondate_ValueChanged(object sender, EventArgs e)
        {
            completiondate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void completiondate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completiondate.CustomFormat = " ";
            }
        }

        private void completiontime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completiontime.CustomFormat = " ";
            }
        }

        private void completiontime_MouseDown(object sender, MouseEventArgs e)
        {
            completiontime.CustomFormat = "HH:mm:ss";
            completiontime.Text = DateTime.Now.ToLongTimeString();
        }

        public void datagridview_batchworkflow_display_overall()
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

                if (string.IsNullOrEmpty(searchby_batchid_batchworkflow.Text) && string.IsNullOrEmpty(searchby_trackingid_batchworkflow.Text) && string.IsNullOrEmpty(searchby_riskid_batchworkflow.Text) && string.IsNullOrEmpty(searchby_partyname_batchworkflow.Text) && searchby_pagenumber_batchworkflow.Value <= 0 && string.IsNullOrEmpty(searchby_inquirystatus_batchworkflow.Text) && string.IsNullOrEmpty(searchby_associatename_batchworkflow.Text) && string.IsNullOrEmpty(searchby_sourcebu_batchworkflow.Text) && string.IsNullOrEmpty(searchby_entityid_batchworkflow.Text) && string.IsNullOrEmpty(searchby_eventlist_batchworkflow.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 RequestID,BatchID,InquiryID,RiskID,EntityID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,AssociateLoginID_Allocation,convert(date,AllocationDate) as AllocationDate,convert(time,AllocationDate) as AllocationTime,AllocatedBy,ProjectNonProject,Project_LastUpdatedBy,convert(date,Project_LastUpdatedDateTime) as Project_LastUpdatedDate,convert(time,Project_LastUpdatedDateTime) as Project_LastUpdatedTime,convert(date,UploadDateTime) as UploadDate,convert(time,UploadDateTime) as UploadTime,UploadedBy,EventList,LastUpdatedBy,ApprovedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and ApprovalRaisedDate is not null and InquiryStatus in ('Raised for Senior Review') and AssociateLoginID_Allocation = @loginidparam order by RequestID desc,BatchID,InquiryID";
                    cmd.Parameters.AddWithValue("@loginidparam", Environment.UserName.ToString());
                }
                //else if (!string.IsNullOrEmpty(searchby_batchid_batchworkflow.Text) || !string.IsNullOrEmpty(searchby_inquiryid_batchworkflow.Text) || !string.IsNullOrEmpty(searchby_riskid_batchworkflow.Text) || !string.IsNullOrEmpty(searchby_partyname_batchworkflow.Text) || searchby_pagenumber_batchworkflow.Value > 0 || !string.IsNullOrEmpty(searchby_inquirystatus_batchworkflow.Text))
                else
                {
                    //cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and batchid = coalesce(@batchid,batchid) and inquiryid = coalesce(@inquiryid,inquiryid) and riskid = coalesce(@riskid,riskid) and partyname = coalesce(@partyname,partyname) and pagenumber = coalesce(@pagenumber,pagenumber) and inquirystatus = coalesce(@inquirystatus,inquirystatus) order by BatchID,InquiryID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_batchworkflow_L2_form_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(searchby_batchid_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@batchid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@batchid", searchby_batchid_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_trackingid_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@trackingid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@trackingid", searchby_trackingid_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_riskid_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@riskid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@riskid", searchby_riskid_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_partyname_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@partyname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@partyname", searchby_partyname_batchworkflow.Text);
                    }
                    if (searchby_pagenumber_batchworkflow.Value == 0)
                    {
                        cmd.Parameters.AddWithValue("@pagenumber", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pagenumber", searchby_pagenumber_batchworkflow.Value);
                    }
                    if (string.IsNullOrEmpty(searchby_inquirystatus_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@inquirystatus", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@inquirystatus", searchby_inquirystatus_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_associatename_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename", searchby_associatename_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_sourcebu_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@sourcebu", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@sourcebu", searchby_sourcebu_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_entityid_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@entityid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@entityid", searchby_entityid_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_eventlist_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@eventlist", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@eventlist", searchby_eventlist_batchworkflow.Text);
                    }
                }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                batchworkflow_datagridview.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void batchworkflow_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.batchworkflow_datagridview.Rows[e.RowIndex];
                    requestid.Text = row.Cells["txtRequestIDbatch"].Value.ToString();
                    receiveddate.Text = row.Cells["txtReceivedDatebatch"].Value.ToString();
                    receiveddate.CustomFormat = "dd-MMMM-yyyy";
                    receivedtime.Text = row.Cells["txtReceivedTimebatch"].Value.ToString();
                    receivedtime.CustomFormat = "HH:mm:ss";
                    if (string.IsNullOrEmpty(row.Cells["txtApprovedBy"].Value.ToString()))
                    {
                        approvedby.SelectedIndex = -1;
                    }
                    else
                    {
                        approvedby.Text = row.Cells["txtApprovedBy"].Value.ToString();
                    }
                    matchcriteria.Text = row.Cells["txtMatchCriteriabatch"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txtApprovalRaisedDatebatch"].Value.ToString()))
                    {
                        approvalraiseddate.CustomFormat = " ";
                        approvalraisedtime.CustomFormat = " ";
                        typeofapproval.SelectedIndex = -1;
                    }
                    else
                    {
                        approvalraiseddate.Text = row.Cells["txtApprovalRaisedDatebatch"].Value.ToString();
                        approvalraiseddate.CustomFormat = "dd-MMMM-yyyy";
                        approvalraisedtime.Text = row.Cells["txtApprovalRaisedTimebatch"].Value.ToString();
                        approvalraisedtime.CustomFormat = "HH:mm:ss";
                        typeofapproval.Text = row.Cells["txtTypeOfApprovalbatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtApprovalReceivedDatebatch"].Value.ToString()))
                    {
                        approvalreceiveddate.CustomFormat = " ";
                        approvalreceivedtime.CustomFormat = " ";
                    }
                    else
                    {
                        approvalreceiveddate.Text = row.Cells["txtApprovalReceivedDatebatch"].Value.ToString();
                        approvalreceiveddate.CustomFormat = "dd-MMMM-yyyy";
                        approvalreceivedtime.Text = row.Cells["txtApprovalReceivedTimebatch"].Value.ToString();
                        approvalreceivedtime.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtCompletionDatebatch"].Value.ToString()))
                    {
                        completiondate.CustomFormat = " ";
                        completiontime.CustomFormat = " ";
                    }
                    else
                    {
                        completiondate.Text = row.Cells["txtCompletionDatebatch"].Value.ToString();
                        completiondate.CustomFormat = "dd-MMMM-yyyy";
                        completiontime.Text = row.Cells["txtCompletionTimebatch"].Value.ToString();
                        completiontime.CustomFormat = "HH:mm:ss";
                    }
                    
                    if (string.IsNullOrEmpty(row.Cells["txtApprovalRejectionCommentbatch"].Value.ToString()))
                    {
                        approvalrejectioncomment.Text = string.Empty;
                    }
                    else
                    {
                        approvalrejectioncomment.Text = row.Cells["txtApprovalRejectionCommentbatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtInquiryStatus"].Value.ToString()))
                    {
                        inquirystatus.SelectedIndex = -1;
                    }
                    else
                    {
                        inquirystatus.Text = row.Cells["txtInquiryStatus"].Value.ToString();
                    }
                    
                }
                
            }
            else
            {
                requestid.Focus();
            }
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
                cmd.CommandText = "usp_batchworkflow_L2_form_update_daily_dotnet";
                cmd.Parameters.AddWithValue("@RequestID", requestid.Text);
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                
                if (string.IsNullOrEmpty(approvedby.Text))
                {
                    cmd.Parameters.AddWithValue("@ApprovedBy", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovedBy", approvedby.Text);
                }
                
                cmd.Parameters.AddWithValue("@MatchCriteria", matchcriteria.Text);
                if (approvalraiseddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@ApprovalRaisedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ApprovalRaisedTime", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TypeOfApproval", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovalRaisedDate", approvalraiseddate.Value.Date);
                    cmd.Parameters.AddWithValue("@ApprovalRaisedTime", approvalraisedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@TypeOfApproval", typeofapproval.Text);
                }
                if (approvalreceiveddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@ApprovalReceivedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ApprovalReceivedTime", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovalReceivedDate", approvalreceiveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@ApprovalReceivedTime", approvalreceivedtime.Value.ToLongTimeString());
                }
                if (completiondate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CompletionDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompletionTime", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CompletionDate", completiondate.Value.Date);
                    cmd.Parameters.AddWithValue("@CompletionTime", completiontime.Value.ToLongTimeString());
                }
                
                if (string.IsNullOrEmpty(approvalrejectioncomment.Text))
                {
                    cmd.Parameters.AddWithValue("@ApprovalRejectionComment", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovalRejectionComment", approvalrejectioncomment.Text);
                }
                //cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                //cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                //cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                cmd.Parameters.AddWithValue("@InquiryStatus", inquirystatus.Text);

                //if conditions

                if (approvalraiseddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(typeofapproval.Text))
                {
                    MessageBox.Show("Please update Type Of Approval");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && approvalraiseddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Approval Raised Date cannot be less than Received Date");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && approvalreceiveddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Approval Received Date cannot be less than Received Date");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && approvalreceiveddate.Text.Trim() != string.Empty && approvalraiseddate.Value.Date > approvalreceiveddate.Value.Date)
                {
                    MessageBox.Show("Approval Raised Date cannot be more than Approval Received Date");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && approvalraisedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Approval Raised time");
                }
                else if (approvalraiseddate.Text.Trim() == string.Empty && approvalraisedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Approval Raised Date");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && approvalreceivedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Approval Received time");
                }
                else if (approvalreceiveddate.Text.Trim() == string.Empty && approvalreceivedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Approval Received Date");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && approvalraiseddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Approval Raised Date cannot be more than Completion Date");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && approvalreceiveddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Approval Received Date cannot be more than Completion Date");
                }
                else if (completiondate.Text.Trim() != string.Empty && completiontime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Completion Time");
                }
                else if (completiondate.Text.Trim() == string.Empty && completiontime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Completion Date");
                }
                else if (completiondate.Text.Trim() != string.Empty && receiveddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Received Date cannot be more than Completion Date");
                }
                else if (inquirystatus.Text == "Mismatch" && completiondate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Completion Date");
                }
                else if (inquirystatus.Text == "Low Risk" && completiondate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Completion Date");
                }
                else if (matchcriteria.Text == "Mis Match" && inquirystatus.Text != "Mismatch")
                {
                    MessageBox.Show("Inquiry Status needs to be Mis Match");
                }
                else if (matchcriteria.Text != "Mis Match" && inquirystatus.Text == "Mismatch")
                {
                    MessageBox.Show("Match Criteria should be mismatch");
                }
                else if (matchcriteria.Text == "Low Risk" && inquirystatus.Text != "Low Risk")
                {
                    MessageBox.Show("Inquiry Status needs to be Low Risk");
                }
                else if (matchcriteria.Text != "Low Risk" && inquirystatus.Text == "Low Risk")
                {
                    MessageBox.Show("Match Criteria needs to be Low Risk");
                }
                else if ((matchcriteria.Text == "PEP" || matchcriteria.Text == "Potential") && inquirystatus.Text == "Mismatch")
                {
                    MessageBox.Show("Inquiry Status cannot be Mismatch");
                }
                else if ((inquirystatus.Text == "Raised for Senior Review" || inquirystatus.Text == "Already raised for Senior Review") && approvalraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Approval Raised Date");
                }
                else if (inquirystatus.Text == "Raised for SMSO" && matchcriteria.Text != "Exact" && matchcriteria.Text != "Potential")
                {
                    MessageBox.Show("Match Criteria should be Exact / Potential");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && approvalreceiveddate.Text.Trim() == string.Empty && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Approval Received Date");
                }
                else if (string.IsNullOrEmpty(inquirystatus.Text))
                {
                    MessageBox.Show("Please update Inquiry Status");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Potential" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("You cannot update Completion Date as Match Criteria is Potential");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Already raised for Senior Review" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Already raised for Senior Review");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Raised for SMSO" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Raised for SMSO");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(approvedby.Text))
                {
                    MessageBox.Show("Please updated Approved By column");
                }
                // new rules added by Gautami
                else if (matchcriteria.Text == "Mis Match" && inquirystatus.Text == "Mismatch" && approvalreceiveddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Approval Received Date");
                }
                else if (matchcriteria.Text == "Mis Match" && inquirystatus.Text == "Mismatch" && completiondate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Completion Date");
                }
                else if (matchcriteria.Text == "Mis Match" && inquirystatus.Text != "Mismatch")
                {
                    MessageBox.Show("Inquiry status should be MisMatch");
                }
                else if (matchcriteria.Text == "Exact" && inquirystatus.Text == "Raised for SMSO" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("You can update only approval received date");
                }
                else if (matchcriteria.Text == "Exact" && inquirystatus.Text == "Raised for sanctions" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("You can update only approval received date");
                }
                else if (matchcriteria.Text == "Potential" && (inquirystatus.Text != "Raised for SMSO" || inquirystatus.Text != "Raised for sanctions"))
                {
                    MessageBox.Show("Inquiry Status can only be Raised for SMSO or Raised for Sanctions");
                }
                else if (matchcriteria.Text == "Exact" && (inquirystatus.Text != "Raised for SMSO" || inquirystatus.Text != "Raised for sanctions"))
                {
                    MessageBox.Show("Inquiry Status can only be Raised for SMSO or Raised for Sanctions");
                }
                else if (matchcriteria.Text == "Query" && inquirystatus.Text != "Query")
                {
                    MessageBox.Show("Inquiry Status should be Query");
                }
                else if (matchcriteria.Text == "Query" && inquirystatus.Text == "Raised for sanctions" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("You cannot update Completion Date");
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

        private void receiveddate_ValueChanged(object sender, EventArgs e)
        {
            receiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void receiveddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                receiveddate.CustomFormat = " ";
            }
        }

        private void receivedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                receivedtime.CustomFormat = " ";
            }
        }

        private void receivedtime_MouseDown(object sender, MouseEventArgs e)
        {
            receivedtime.CustomFormat = "HH:mm:ss";
            receivedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 obj_form4 = new Form4();
            obj_form4.Show();
        }

        private void searchby_sourcebu_batchworkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_batchid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_trackingid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_riskid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_partyname_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_pagenumber_batchworkflow_ValueChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_entityid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_inquirystatus_batchworkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_associatename_batchworkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_eventlist_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }
    }
}
