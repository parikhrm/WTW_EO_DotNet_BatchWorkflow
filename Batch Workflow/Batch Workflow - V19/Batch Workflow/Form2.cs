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
    public partial class Form2 : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            riskcategory_list();
            admin_list();
            matchcriteria_list();
            typeofapproval_list();
            queryremarks_list();
            entitytype_list();
            approvedby_list();
            eventcode_list();
            sourcebu_list();
            inquirystatus_list();
            smsoapprovedby_list();
            associatename_searchby_list();
            reset_overall();
        }

        public void reset_overall()
        {
            adminlist.Visible = false;
            inquirystatus_associatename.Visible = false;
            approvalrejectioncomment.Enabled = false;
            batchid.Text = string.Empty;
            batchid.Enabled = false;
            inquiryid.Text = string.Empty;
            inquiryid.Enabled = false;
            riskid.Text = string.Empty;
            trackingid.Text = string.Empty;
            trackingid.Enabled = false;
            receiveddate.CustomFormat = " ";
            receiveddate.Enabled = false;
            receivedtime.CustomFormat = " ";
            receivedtime.Enabled = false;
            entitytype.SelectedIndex = -1;
            entitytype.Enabled = false;
            partyname.Text = string.Empty;
            partyname.Enabled = false;
            sourcebu.SelectedIndex = -1;
            sourcebu.Enabled = false;
            noofhits.Value = 0;
            approvedby.SelectedIndex = -1;
            //noofhits.Enabled = false;
            riskcategory.SelectedIndex = -1;
            eventcodes.SelectedIndex = -1;
            //eventcodes.Enabled = false;
            matchcriteria.SelectedIndex = -1;
            queryraiseddate.CustomFormat = " ";
            queryraisedtime.CustomFormat = " ";
            queryresolveddate.CustomFormat = " ";
            queryresolvedtime.CustomFormat = " ";
            queryremarks.SelectedIndex = -1;
            approvalraiseddate.CustomFormat = " ";
            approvalraisedtime.CustomFormat = " ";
            approvalreceiveddate.CustomFormat = " ";
            approvalreceivedtime.CustomFormat = " ";
            typeofapproval.SelectedIndex = -1;
            completiondate.CustomFormat = " ";
            completiontime.CustomFormat = " ";
            smsoraiseddate.CustomFormat = " ";
            smsoraisedtime.CustomFormat = " ";
            smsoreceiveddate.CustomFormat = " ";
            smsoreceivedtime.CustomFormat = " ";
            smsoapprovedby.SelectedIndex = -1;
            approvalrejectioncomment.Text = string.Empty;
            chaser1_checkbox.Checked = false;
            chaser2_checkbox.Checked = false;
            chaser3_checkbox.Checked = false;
            chasers_checkbox.Checked = false;
            chasers_checkbox.Checked = false;
            chaser1.Visible = false;
            chaser1_checkbox.Visible = false;
            chaser2.Visible = false;
            chaser2_checkbox.Visible = false;
            chaser3.Visible = false;
            chaser3_checkbox.Visible = false;
            requestoremailaddress.Text = string.Empty;
            //label28.Visible = false;
            requestid.Text = string.Empty;
            requestid.Enabled = false;
            concat_batchid_riskid.SelectedIndex = -1;
            concat_batchid_riskid.Visible = false;
            inquirystatus.SelectedIndex = -1;
            searchby_inquirystatus_batchworkflow.SelectedIndex = -1;
            associateloginid_allocation.Text = string.Empty;
            associateloginid_allocation.Visible = false;
            pagenumber.Value = 0;
            pagenumber.Visible = false;
            current_datetime.Text = DateTime.Now.ToLongDateString();
            current_datetime.Visible = false;
            //searchby_associatename_batchworkflow.SelectedIndex = -1;
            datagridview_batchworkflow_display_overall();
            associatename_allocation.Visible = false;
            associateloginid_allocation1.Visible = false;
            allocationdate.Visible = false;
            allocationtime.Visible = false;
            allocatedby.Visible = false;
            projectnonproject.Visible = false;
            project_lastupdatedby.Visible = false;
            project_lastupdateddate.Visible = false;
            project_lastupdatedtime.Visible = false;
            uploadedby.Visible = false;
            uploaddate.Visible = false;
            uploadtime.Visible = false;
            entityid.Text = string.Empty;
            label27.Visible = false;
            requestoremailaddress.Visible = false;
            entityid.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox2.Enabled = false;
            if (adminlist.Text == "Admin")
            {
                approvalrejectioncomment.Enabled = true;
            }
            else
            {
                approvalrejectioncomment.Enabled = false;
            }
            
        }

        public void insert_records()
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
                cmd.CommandText = "usp_batchworkflow_insert_daily_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@BatchID", batchid.Text);
                cmd.Parameters.AddWithValue("@InquiryID", inquiryid.Text);
                if (string.IsNullOrEmpty(riskid.Text))
                {
                    cmd.Parameters.AddWithValue("@RiskID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RiskID", riskid.Text);
                }
                if (string.IsNullOrEmpty(entityid.Text))
                {
                    cmd.Parameters.AddWithValue("@EntityID",DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EntityID",entityid.Text);
                }
                if (string.IsNullOrEmpty(approvedby.Text))
                {
                    cmd.Parameters.AddWithValue("@ApprovedBy",DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovedBy", approvedby.Text);
                }
                cmd.Parameters.AddWithValue("@TrackingID", trackingid.Text);
                cmd.Parameters.AddWithValue("@ReceivedDate", receiveddate.Value.Date);
                cmd.Parameters.AddWithValue("@ReceivedTime", receivedtime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@EntityType", entitytype.Text);
                cmd.Parameters.AddWithValue("@PartyName", partyname.Text);
                cmd.Parameters.AddWithValue("@SourceBU", sourcebu.Text);
                cmd.Parameters.AddWithValue("@NoOfHits", Convert.ToInt32(noofhits.Value));
                if (string.IsNullOrEmpty(riskcategory.Text))
                {
                    cmd.Parameters.AddWithValue("@RiskCategory", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RiskCategory", riskcategory.Text);
                }
                if (string.IsNullOrEmpty(eventcodes.Text))
                {
                    cmd.Parameters.AddWithValue("@EventCodes", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EventCodes", eventcodes.Text);
                }
                cmd.Parameters.AddWithValue("@MatchCriteria", matchcriteria.Text);
                if (queryraiseddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryRaisedTime", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryRemarks", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDate", queryraiseddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryRaisedTime", queryraisedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@QueryRemarks", queryremarks.Text);
                }
                if (queryresolveddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryResolvedTime", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDate", queryresolveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryResolvedTime", queryresolvedtime.Value.ToLongTimeString());
                }
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
                if (smsoraiseddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSORaisedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSORaisedTime", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSORaisedDate", smsoraiseddate.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSORaisedTime", smsoraisedtime.Value.ToLongTimeString());
                }
                if (smsoreceiveddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSOReceivedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSOReceivedTime", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSOApprovedBy", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSOReceivedDate", smsoreceiveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSOReceivedTime", smsoreceivedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@SMSOApprovedBy", smsoapprovedby.Text);
                }
                if (string.IsNullOrEmpty(approvalrejectioncomment.Text))
                {
                    cmd.Parameters.AddWithValue("@ApprovalRejectionComment", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovalRejectionComment", approvalrejectioncomment.Text);
                }
                if (chaser1.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser1Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser1Date", chaser1.Value.Date);
                }
                if (chaser2.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser2Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser2Date", chaser2.Value.Date);
                }
                if (chaser3.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser3Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser3Date", chaser3.Value.Date);
                }
                if (string.IsNullOrEmpty(requestoremailaddress.Text))
                {
                    cmd.Parameters.AddWithValue("@RequestorEmailAddress", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RequestorEmailAddress", requestoremailaddress.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                //cmd.Parameters.AddWithValue("@AssociateLoginID_Allocation", associateloginid_allocation.Text);
                cmd.Parameters.AddWithValue("@PageNumber", pagenumber.Value);
                cmd.Parameters.AddWithValue("@InquiryStatus",inquirystatus.Text);
                cmd.Parameters.AddWithValue("@AssociateName_Allocation",associatename_allocation.Text);
                cmd.Parameters.AddWithValue("@AssociateLoginID_Allocation",associateloginid_allocation1.Text);
                cmd.Parameters.AddWithValue("@AllocationDate", allocationdate.Value.Date);
                cmd.Parameters.AddWithValue("@AllocationTime", allocationtime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@AllocatedBy", allocatedby.Text);
                cmd.Parameters.AddWithValue("@ProjectNonProject", projectnonproject.Text);
                if (string.IsNullOrEmpty(project_lastupdatedby.Text))
                {
                    cmd.Parameters.AddWithValue("@Project_LastUpdatedBy", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Project_LastUpdatedBy", project_lastupdatedby.Text);
                }
                if (string.IsNullOrEmpty(project_lastupdateddate.Text))
                {
                    cmd.Parameters.AddWithValue("@Project_LastUpdatedDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Project_LastUpdatedDate", project_lastupdateddate.Value.Date);
                }
                if (string.IsNullOrEmpty(project_lastupdatedtime.Text))
                {
                    cmd.Parameters.AddWithValue("@Project_LastUpdatedTime", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Project_LastUpdatedTime", project_lastupdatedtime.Value.ToLongTimeString());
                }
                cmd.Parameters.AddWithValue("@UploadDate", uploaddate.Value.Date);
                cmd.Parameters.AddWithValue("@UploadTime", uploadtime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@UploadedBy", uploadedby.Text);


                //if conditions
                if (queryraiseddate.Text.Trim() != string.Empty && queryraiseddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Query Raised Date cannot be less than Received Date");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(approvedby.Text))
                {
                    MessageBox.Show("Please update Approved By");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryresolveddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Query Resolved Date cannot be less than Received Date");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() != string.Empty && queryresolveddate.Value.Date < queryraiseddate.Value.Date)
                {
                    MessageBox.Show("Query Resolved Date cannot be less than Query Raised Date");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(queryremarks.Text))
                {
                    MessageBox.Show("Please update Query Remarks");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryraisedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Time");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryresolvedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Time");
                }
                else if (queryraiseddate.Text.Trim() == string.Empty && queryraisedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (queryresolveddate.Text.Trim() == string.Empty && queryresolvedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && queryraiseddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Query Raised Date cannot be more than Completion Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && queryresolveddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Query Resolved Date cannot be more than Completion Date");
                }
                else if (!string.IsNullOrEmpty(queryremarks.Text) && queryraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(typeofapproval.Text))
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
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be less than Received Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && smsoreceiveddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("SMSO Received Date cannot be less than Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoreceiveddate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date > smsoreceiveddate.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be more than SMSO Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoraisedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update SMSO Raised Time");
                }
                else if (smsoraiseddate.Text.Trim() == string.Empty && smsoraisedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update SMSO Raised Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && smsoreceivedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update SMSO Received Time");
                }
                else if (smsoreceiveddate.Text.Trim() == string.Empty && smsoreceivedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update SMSO Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be more than Completion Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && smsoreceiveddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("SMSO Received Date cannot be more than Completion Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(smsoapprovedby.Text))
                {
                    MessageBox.Show("Please update SMSO Approved By");
                }
                else if ((matchcriteria.Text == "Exact" || matchcriteria.Text == "Potential") && string.IsNullOrEmpty(riskcategory.Text) && inquirystatus.Text != "Informed to BU")
                {
                    MessageBox.Show("Please update Risk Category");
                }
                else if ((matchcriteria.Text == "Exact" || matchcriteria.Text == "Potential") && string.IsNullOrEmpty(eventcodes.Text) && inquirystatus.Text != "Informed to BU")
                {
                    MessageBox.Show("Please update Event Codes");
                }
                else if (chaser1.Text.Trim() != string.Empty && chaser2.Text.Trim() != string.Empty && chaser1.Value.Date > chaser2.Value.Date)
                {
                    MessageBox.Show("Chaser1 Date cannot be more than Chaser2 date");
                }
                else if (chaser1.Text.Trim() != string.Empty && chaser3.Text.Trim() != string.Empty && chaser1.Value.Date > chaser3.Value.Date)
                {
                    MessageBox.Show("Chaser1 Date cannot be more than Chaser3 date");
                }
                else if (chaser2.Text.Trim() != string.Empty && chaser3.Text.Trim() != string.Empty && chaser2.Value.Date > chaser3.Value.Date)
                {
                    MessageBox.Show("Chaser2 Date cannot be more than Chaser3 date");
                }
                else if (chaser1.Text.Trim() != string.Empty && chaser1.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Chaser1 date cannot be less than Received Date");
                }
                else if (chaser1.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && chaser1.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Chaser1 date cannot be more than Completion Date");
                }
                else if (chaser2.Text.Trim() != string.Empty && chaser2.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Chaser2 date cannot be less than Received Date");
                }
                else if (chaser2.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && chaser2.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Chaser2 date cannot be more than Completion Date");
                }
                else if (chaser3.Text.Trim() != string.Empty && chaser3.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Chaser3 date cannot be less than Received Date");
                }
                else if (chaser3.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && chaser3.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Chaser3 date cannot be more than Completion Date");
                }
                else if (((matchcriteria.Text == "Exact" || matchcriteria.Text == "Potential") && (smsoraiseddate.Text.Trim() != string.Empty || approvalraiseddate.Text.Trim() != string.Empty)) && string.IsNullOrEmpty(riskid.Text))
                {
                    MessageBox.Show("Please update Risk ID");
                }
                else if (!string.IsNullOrEmpty(riskid.Text) && string.IsNullOrEmpty(riskcategory.Text))
                {
                    MessageBox.Show("Please update Risk Category");
                }
                else if (!string.IsNullOrEmpty(riskid.Text) && string.IsNullOrEmpty(eventcodes.Text))
                {
                    MessageBox.Show("Please update Event Codes");
                }
                else if (string.IsNullOrEmpty(matchcriteria.Text))
                {
                    MessageBox.Show("Please update Match Criteria");
                }
                else if (noofhits.Value < 1)
                {
                    MessageBox.Show("No of Hits cannot be less than 1");
                }
                //else if (queryraiseddate.Text.Trim() != string.Empty && queryraiseddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Query Raised Date cannot be more than Today's date");
                //}
                //else if (queryresolveddate.Text.Trim() != string.Empty && queryresolveddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Query Resolved Date cannot be more than Today's date");
                //}
                //else if (approvalraiseddate.Text.Trim() != string.Empty && approvalraiseddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Approval Raised Date cannot be more than Today's date");
                //}
                //else if (approvalreceiveddate.Text.Trim() != string.Empty && approvalreceiveddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Approval Received Date cannot be more than Today's date");
                //}
                //else if (completiondate.Text.Trim() != string.Empty && completiondate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Completion Date cannot be more than Today's date");
                //}
                //else if (chaser1.Text.Trim() != string.Empty && chaser1.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Chaser1 Date cannot be more than Today's date");
                //}
                //else if (chaser2.Text.Trim() != string.Empty && chaser2.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Chaser2 Date cannot be more than Today's date");
                //}
                //else if (chaser3.Text.Trim() != string.Empty && chaser3.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Chaser3 Date cannot be more than Today's date");
                //}
                //else if (smsoraiseddate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("SMSO Raised Date cannot be more than Today's date");
                //}
                //else if (smsoreceiveddate.Text.Trim() != string.Empty && smsoreceiveddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("SMSO Received Date cannot be more than Today's date");
                //}
                else if (approvalraiseddate.Text.Trim() != string.Empty && noofhits.Value > 1)
                {
                    MessageBox.Show("No. of Hits cannot be more than 1");
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
                else if ((matchcriteria.Text == "PEP" || matchcriteria.Text == "Potential") && noofhits.Value > 1)
                {
                    MessageBox.Show("No of hits cannot be more than 1");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && noofhits.Value > 1)
                {
                    MessageBox.Show("No of hits cannot be more than 1");
                }
                else if ((inquirystatus.Text == "Raised for Senior Review" || inquirystatus.Text == "Already raised for Senior Review") && approvalraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Approval Raised Date");
                }
                else if (inquirystatus.Text == "Query" && queryraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (inquirystatus.Text == "Raised for SMSO" && smsoraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update SMSO Raised Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(riskid.Text) && matchcriteria.Text == "Exact" && matchcriteria.Text == "Potential")
                {
                    MessageBox.Show("Please update Risk ID");
                }
                else if (inquirystatus.Text == "Raised for SMSO" && matchcriteria.Text != "Exact" && matchcriteria.Text != "Potential")
                {
                    MessageBox.Show("Match Criteria should be Exact / Potential");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() == string.Empty && completiondate.Text.Trim() != string.Empty && checkBox1.Checked == false)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && approvalreceiveddate.Text.Trim() == string.Empty && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Approval Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoreceiveddate.Text.Trim() == string.Empty && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update SMSO Received Date");
                }
                else if (string.IsNullOrEmpty(inquirystatus.Text))
                {
                    MessageBox.Show("Please update Inquiry Status");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && matchcriteria.Text != "Exact" && matchcriteria.Text != "Potential")
                {
                    MessageBox.Show("For SMSO's Match Criteria should be Exact or Potential");
                }
                else if (matchcriteria.Text == "Mis Match" && riskid.Text != string.Empty)
                {
                    MessageBox.Show("Risk ID should be blank when Match Criteria is Mis Match");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Exact" && string.IsNullOrEmpty(entityid.Text))
                {
                    MessageBox.Show("Please update Entity ID");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Potential" && string.IsNullOrEmpty(entityid.Text))
                {
                    MessageBox.Show("Please update Entity ID");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Low Risk" && string.IsNullOrEmpty(entityid.Text))
                {
                    MessageBox.Show("Please update Entity ID");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Potential" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("You cannot update Completion Date as Match Criteria is Potential");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Query" && completiondate.Text.Trim() != string.Empty && checkBox1.Checked == false)
                {
                    MessageBox.Show("You cannot update Completion Date as Match Criteria is Query");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Already raised for Senior Review" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Already raised for Senior Review");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Query" && completiondate.Text.Trim() != string.Empty && checkBox1.Checked == false)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Query");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Raised for SMSO" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Raised for SMSO");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(approvedby.Text))
                {
                    MessageBox.Show("Please updated Approved By column");
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

        public void update_records()
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
                cmd.CommandText = "usp_batchworkflow_update_daily_dotnet";
                cmd.Parameters.AddWithValue("@RequestID", requestid.Text);
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@BatchID", batchid.Text);
                cmd.Parameters.AddWithValue("@InquiryID", inquiryid.Text);
                if (string.IsNullOrEmpty(riskid.Text))
                {
                    cmd.Parameters.AddWithValue("@RiskID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RiskID", riskid.Text);
                }
                if (string.IsNullOrEmpty(approvedby.Text))
                {
                    cmd.Parameters.AddWithValue("@ApprovedBy", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovedBy", approvedby.Text);
                }
                if (string.IsNullOrEmpty(entityid.Text))
                {
                    cmd.Parameters.AddWithValue("@EntityID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EntityID", entityid.Text);
                }
                cmd.Parameters.AddWithValue("@TrackingID", trackingid.Text);
                cmd.Parameters.AddWithValue("@ReceivedDate", receiveddate.Value.Date);
                cmd.Parameters.AddWithValue("@ReceivedTime", receivedtime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@EntityType", entitytype.Text);
                cmd.Parameters.AddWithValue("@PartyName", partyname.Text);
                cmd.Parameters.AddWithValue("@SourceBU", sourcebu.Text);
                cmd.Parameters.AddWithValue("@NoOfHits", Convert.ToInt32(noofhits.Value));
                if (string.IsNullOrEmpty(riskcategory.Text))
                {
                    cmd.Parameters.AddWithValue("@RiskCategory", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RiskCategory", riskcategory.Text);
                }
                if (string.IsNullOrEmpty(eventcodes.Text))
                {
                    cmd.Parameters.AddWithValue("@EventCodes", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EventCodes", eventcodes.Text);
                }
                cmd.Parameters.AddWithValue("@MatchCriteria", matchcriteria.Text);
                if (queryraiseddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryRaisedTime", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryRemarks", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryRaisedDate", queryraiseddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryRaisedTime", queryraisedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@QueryRemarks", queryremarks.Text);
                }
                if (queryresolveddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryResolvedTime", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@QueryResolvedDate", queryresolveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@QueryResolvedTime", queryresolvedtime.Value.ToLongTimeString());
                }
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
                if (smsoraiseddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSORaisedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSORaisedTime", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSORaisedDate", smsoraiseddate.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSORaisedTime", smsoraisedtime.Value.ToLongTimeString());
                }
                if (smsoreceiveddate.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@SMSOReceivedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSOReceivedTime", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMSOApprovedBy", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SMSOReceivedDate", smsoreceiveddate.Value.Date);
                    cmd.Parameters.AddWithValue("@SMSOReceivedTime", smsoreceivedtime.Value.ToLongTimeString());
                    cmd.Parameters.AddWithValue("@SMSOApprovedBy", smsoapprovedby.Text);
                }
                if (string.IsNullOrEmpty(approvalrejectioncomment.Text))
                {
                    cmd.Parameters.AddWithValue("@ApprovalRejectionComment", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ApprovalRejectionComment", approvalrejectioncomment.Text);
                }
                if (chaser1.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser1Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser1Date", chaser1.Value.Date);
                }
                if (chaser2.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser2Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser2Date", chaser2.Value.Date);
                }
                if (chaser3.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser3Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser3Date", chaser3.Value.Date);
                }
                if (string.IsNullOrEmpty(requestoremailaddress.Text))
                {
                    cmd.Parameters.AddWithValue("@RequestorEmailAddress", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RequestorEmailAddress", requestoremailaddress.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now.ToLocalTime());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());
                cmd.Parameters.AddWithValue("@InquiryStatus", inquirystatus.Text);

                //if conditions
                if (queryraiseddate.Text.Trim() != string.Empty && queryraiseddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Query Raised Date cannot be less than Received Date");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(approvedby.Text))
                {
                    MessageBox.Show("Please update Approved By");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryresolveddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Query Resolved Date cannot be less than Received Date");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() != string.Empty && queryresolveddate.Value.Date < queryraiseddate.Value.Date)
                {
                    MessageBox.Show("Query Resolved Date cannot be less than Query Raised Date");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(queryremarks.Text))
                {
                    MessageBox.Show("Please update Query Remarks");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryraisedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Time");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && queryresolvedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Time");
                }
                else if (queryraiseddate.Text.Trim() == string.Empty && queryraisedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (queryresolveddate.Text.Trim() == string.Empty && queryresolvedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && queryraiseddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Query Raised Date cannot be more than Completion Date");
                }
                else if (queryresolveddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && queryresolveddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Query Resolved Date cannot be more than Completion Date");
                }
                else if (!string.IsNullOrEmpty(queryremarks.Text) && queryraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(typeofapproval.Text))
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
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be less than Received Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && smsoreceiveddate.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("SMSO Received Date cannot be less than Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoreceiveddate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date > smsoreceiveddate.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be more than SMSO Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoraisedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update SMSO Raised Time");
                }
                else if (smsoraiseddate.Text.Trim() == string.Empty && smsoraisedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update SMSO Raised Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && smsoreceivedtime.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update SMSO Received Time");
                }
                else if (smsoreceiveddate.Text.Trim() == string.Empty && smsoreceivedtime.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update SMSO Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("SMSO Raised Date cannot be more than Completion Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && smsoreceiveddate.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("SMSO Received Date cannot be more than Completion Date");
                }
                else if (smsoreceiveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(smsoapprovedby.Text))
                {
                    MessageBox.Show("Please update SMSO Approved By");
                }
                else if ((matchcriteria.Text == "Exact" || matchcriteria.Text == "Potential") && string.IsNullOrEmpty(riskcategory.Text) && inquirystatus.Text != "Informed to BU")
                {
                    MessageBox.Show("Please update Risk Category");
                }
                else if ((matchcriteria.Text == "Exact" || matchcriteria.Text == "Potential") && string.IsNullOrEmpty(eventcodes.Text) && inquirystatus.Text != "Informed to BU")
                {
                    MessageBox.Show("Please update Event Codes");
                }
                else if (chaser1.Text.Trim() != string.Empty && chaser2.Text.Trim() != string.Empty && chaser1.Value.Date > chaser2.Value.Date)
                {
                    MessageBox.Show("Chaser1 Date cannot be more than Chaser2 date");
                }
                else if (chaser1.Text.Trim() != string.Empty && chaser3.Text.Trim() != string.Empty && chaser1.Value.Date > chaser3.Value.Date)
                {
                    MessageBox.Show("Chaser1 Date cannot be more than Chaser3 date");
                }
                else if (chaser2.Text.Trim() != string.Empty && chaser3.Text.Trim() != string.Empty && chaser2.Value.Date > chaser3.Value.Date)
                {
                    MessageBox.Show("Chaser2 Date cannot be more than Chaser3 date");
                }
                else if (chaser1.Text.Trim() != string.Empty && chaser1.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Chaser1 date cannot be less than Received Date");
                }
                else if (chaser1.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && chaser1.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Chaser1 date cannot be more than Completion Date");
                }
                else if (chaser2.Text.Trim() != string.Empty && chaser2.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Chaser2 date cannot be less than Received Date");
                }
                else if (chaser2.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && chaser2.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Chaser2 date cannot be more than Completion Date");
                }
                else if (chaser3.Text.Trim() != string.Empty && chaser3.Value.Date < receiveddate.Value.Date)
                {
                    MessageBox.Show("Chaser3 date cannot be less than Received Date");
                }
                else if (chaser3.Text.Trim() != string.Empty && completiondate.Text.Trim() != string.Empty && chaser3.Value.Date > completiondate.Value.Date)
                {
                    MessageBox.Show("Chaser3 date cannot be more than Completion Date");
                }
                else if (((matchcriteria.Text == "Exact" || matchcriteria.Text == "Potential") && (smsoraiseddate.Text.Trim() != string.Empty || approvalraiseddate.Text.Trim() != string.Empty)) && string.IsNullOrEmpty(riskid.Text))
                {
                    MessageBox.Show("Please update Risk ID");
                }
                else if (!string.IsNullOrEmpty(riskid.Text) && string.IsNullOrEmpty(riskcategory.Text))
                {
                    MessageBox.Show("Please update Risk Category");
                }
                else if (!string.IsNullOrEmpty(riskid.Text) && string.IsNullOrEmpty(eventcodes.Text))
                {
                    MessageBox.Show("Please update Event Codes");
                }
                else if (string.IsNullOrEmpty(matchcriteria.Text))
                {
                    MessageBox.Show("Please update Match Criteria");
                }
                else if (noofhits.Value < 1)
                {
                    MessageBox.Show("No of Hits cannot be less than 1");
                }
                //else if (queryraiseddate.Text.Trim() != string.Empty && queryraiseddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Query Raised Date cannot be more than Today's date");
                //}
                //else if (queryresolveddate.Text.Trim() != string.Empty && queryresolveddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Query Resolved Date cannot be more than Today's date");
                //}
                //else if (approvalraiseddate.Text.Trim() != string.Empty && approvalraiseddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Approval Raised Date cannot be more than Today's date");
                //}
                //else if (approvalreceiveddate.Text.Trim() != string.Empty && approvalreceiveddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Approval Received Date cannot be more than Today's date");
                //}
                //else if (completiondate.Text.Trim() != string.Empty && completiondate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Completion Date cannot be more than Today's date");
                //}
                //else if (chaser1.Text.Trim() != string.Empty && chaser1.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Chaser1 Date cannot be more than Today's date");
                //}
                //else if (chaser2.Text.Trim() != string.Empty && chaser2.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Chaser2 Date cannot be more than Today's date");
                //}
                //else if (chaser3.Text.Trim() != string.Empty && chaser3.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("Chaser3 Date cannot be more than Today's date");
                //}
                //else if (smsoraiseddate.Text.Trim() != string.Empty && smsoraiseddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("SMSO Raised Date cannot be more than Today's date");
                //}
                //else if (smsoreceiveddate.Text.Trim() != string.Empty && smsoreceiveddate.Value.Date > current_datetime.Value.Date)
                //{
                //    MessageBox.Show("SMSO Received Date cannot be more than Today's date");
                //}
                else if (approvalraiseddate.Text.Trim() != string.Empty && noofhits.Value > 1)
                {
                    MessageBox.Show("No. of Hits cannot be more than 1");
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
                else if ((matchcriteria.Text == "PEP" || matchcriteria.Text == "Potential") && noofhits.Value > 1)
                {
                    MessageBox.Show("No of hits cannot be more than 1");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && noofhits.Value > 1)
                {
                    MessageBox.Show("No of hits cannot be more than 1");
                }
                else if ((inquirystatus.Text == "Raised for Senior Review" || inquirystatus.Text == "Already raised for Senior Review") && approvalraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Approval Raised Date");
                }
                else if (inquirystatus.Text == "Query" && queryraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Query Raised Date");
                }
                else if (inquirystatus.Text == "Raised for SMSO" && smsoraiseddate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update SMSO Raised Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(riskid.Text) && matchcriteria.Text == "Exact" && matchcriteria.Text == "Potential")
                {
                    MessageBox.Show("Please update Risk ID");
                }
                else if (inquirystatus.Text == "Raised for SMSO" && matchcriteria.Text != "Exact" && matchcriteria.Text != "Potential")
                {
                    MessageBox.Show("Match Criteria should be Exact / Potential");
                }
                else if (queryraiseddate.Text.Trim() != string.Empty && queryresolveddate.Text.Trim() == string.Empty && completiondate.Text.Trim() != string.Empty && checkBox1.Checked == false)
                {
                    MessageBox.Show("Please update Query Resolved Date");
                }
                else if (approvalraiseddate.Text.Trim() != string.Empty && approvalreceiveddate.Text.Trim() == string.Empty && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update Approval Received Date");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && smsoreceiveddate.Text.Trim() == string.Empty && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Please update SMSO Received Date");
                }
                else if (string.IsNullOrEmpty(inquirystatus.Text))
                {
                    MessageBox.Show("Please update Inquiry Status");
                }
                else if (smsoraiseddate.Text.Trim() != string.Empty && matchcriteria.Text != "Exact" && matchcriteria.Text != "Potential")
                {
                    MessageBox.Show("For SMSO's Match Criteria should be Exact or Potential");
                }
                else if (matchcriteria.Text == "Mis Match" && riskid.Text != string.Empty)
                {
                    MessageBox.Show("Risk ID should be blank when Match Criteria is Mis Match");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Exact" && string.IsNullOrEmpty(entityid.Text))
                {
                    MessageBox.Show("Please update Entity ID");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Potential" && string.IsNullOrEmpty(entityid.Text))
                {
                    MessageBox.Show("Please update Entity ID");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Low Risk" && string.IsNullOrEmpty(entityid.Text))
                {
                    MessageBox.Show("Please update Entity ID");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Potential" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("You cannot update Completion Date as Match Criteria is Potential");
                }
                else if (!string.IsNullOrEmpty(matchcriteria.Text) && matchcriteria.Text == "Query" && completiondate.Text.Trim() != string.Empty && checkBox1.Checked == false)
                {
                    MessageBox.Show("You cannot update Completion Date as Match Criteria is Query");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Already raised for Senior Review" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Already raised for Senior Review");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Query" && completiondate.Text.Trim() != string.Empty && checkBox1.Checked == false)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Query");
                }
                else if (!string.IsNullOrEmpty(inquirystatus.Text) && inquirystatus.Text == "Raised for SMSO" && completiondate.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("Completion date cannot be updated when Inquiry status is Raised for SMSO");
                }
                else if (approvalreceiveddate.Text.Trim() != string.Empty && string.IsNullOrEmpty(approvedby.Text))
                {
                    MessageBox.Show("Please updated Approved By column");
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            queryraiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryraiseddate.CustomFormat = " ";
            }
        }

        private void queryresolveddate_ValueChanged(object sender, EventArgs e)
        {
            queryresolveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void queryresolveddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryresolveddate.CustomFormat = " ";
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

        private void smsoraiseddate_ValueChanged(object sender, EventArgs e)
        {
            smsoraiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void smsoraiseddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smsoraiseddate.CustomFormat = " ";
            }
        }

        private void smsoreceiveddate_ValueChanged(object sender, EventArgs e)
        {
            smsoreceiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void smsoreceiveddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smsoreceiveddate.CustomFormat = " ";
            }
        }

        private void chaser1_ValueChanged(object sender, EventArgs e)
        {
            chaser1.CustomFormat = "dd-MMMM-yyyy";
        }

        private void chaser1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                chaser1.CustomFormat = " ";
            }
        }

        private void chaser2_ValueChanged(object sender, EventArgs e)
        {
            chaser2.CustomFormat = "dd-MMMM-yyyy";
        }

        private void chaser2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                chaser2.CustomFormat = " ";
            }
        }

        private void chaser3_ValueChanged(object sender, EventArgs e)
        {
            chaser3.CustomFormat = "dd-MMMM-yyyy";
        }

        private void chaser3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                chaser3.CustomFormat = " ";
            }
        }

        private void chasers_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chasers_checkbox.Checked == true)
            {
                chaser1_checkbox.Visible = true;
                chaser1.Visible = true;
                chaser1.CustomFormat = " ";
            }
            else
            {
                chaser1_checkbox.Checked = false;
                chaser1_checkbox.Visible = false;
                chaser1.Visible = false;
                chaser1.CustomFormat = " ";

                chaser2_checkbox.Checked = false;
                chaser2_checkbox.Visible = false;
                chaser2.Visible = false;
                chaser2.CustomFormat = " ";

                chaser3_checkbox.Checked = false;
                chaser3_checkbox.Visible = false;
                chaser3.Visible = false;
                chaser3.CustomFormat = " ";
            }
        }

        private void chaser1_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chaser1_checkbox.Checked == true)
            {
                chaser2_checkbox.Visible = true;
                chaser2.Visible = true;
                chaser2.CustomFormat = " ";
            }
            else
            {
                chaser2_checkbox.Visible = false;
                chaser2_checkbox.Checked = false;
                chaser2.Visible = false;
                chaser2.CustomFormat = " ";

                chaser3_checkbox.Visible = false;
                chaser3_checkbox.Checked = false;
                chaser3.Visible = false;
                chaser3.CustomFormat = " ";
            }
        }

        private void chaser2_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chaser2_checkbox.Checked == true)
            {
                chaser3_checkbox.Visible = true;
                chaser3.Visible = true;
                chaser3.CustomFormat = " ";
            }
            else
            {
                chaser3_checkbox.Visible = false; ;
                chaser3_checkbox.Checked = false;
                chaser3.Visible = false; ;
                chaser3.CustomFormat = " ";
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
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

        private void smsoraisedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smsoraisedtime.CustomFormat = " ";
            }
        }

        private void smsoraisedtime_MouseDown(object sender, MouseEventArgs e)
        {
            smsoraisedtime.CustomFormat = "HH:mm:ss";
            smsoraisedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void smsoreceivedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                smsoreceivedtime.CustomFormat = " ";
            }
        }

        private void smsoreceivedtime_MouseDown(object sender, MouseEventArgs e)
        {
            smsoreceivedtime.CustomFormat = "HH:mm:ss";
            smsoreceivedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void queryraisedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryraisedtime.CustomFormat = " ";
            }
        }

        private void queryraisedtime_MouseDown(object sender, MouseEventArgs e)
        {
            queryraisedtime.CustomFormat = "HH:mm:ss";
            queryraisedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void queryresolvedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryresolvedtime.CustomFormat = " ";
            }
        }

        private void queryresolvedtime_MouseDown(object sender, MouseEventArgs e)
        {
            queryresolvedtime.CustomFormat = "HH:mm:ss";
            queryresolvedtime.Text = DateTime.Now.ToLongTimeString();
        }

        public void entitytype_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EntityType obj_entitytype = new EntityType();
                DataTable dtaa = new DataTable();
                obj_entitytype.entitytype_list(dtaa);
                entitytype.DataSource = dtaa;
                entitytype.DisplayMember = "EntityType";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void smsoapprovedby_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                SMSOApprovedBy obj_smsoapprovedby = new SMSOApprovedBy();
                DataTable dtaa = new DataTable();
                obj_smsoapprovedby.smsoapprovedby_list (dtaa);
                smsoapprovedby.DataSource = dtaa;
                smsoapprovedby.DisplayMember = "EmailAddress";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void approvedby_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.approvedby_list(dtaa);
                approvedby.DataSource = dtaa;
                approvedby.DisplayMember = "EmpName";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void associatename_searchby_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                DataTable dtaa_inquirystatuscheck = new DataTable();

                obj_empdetails.empdetails_searchby_list(dtaa);
                obj_empdetails.admin_list(dtaa_inquirystatuscheck,Environment.UserName.ToString());

                searchby_associatename_batchworkflow.DataSource = dtaa;
                searchby_associatename_batchworkflow.DisplayMember = "EmpName";

                inquirystatus_associatename.DataSource = dtaa_inquirystatuscheck;
                inquirystatus_associatename.DisplayMember = "INTID_New";

                conn.Close();
                searchby_associatename_batchworkflow.SelectedIndex = -1;

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
                obj_inquirystatus.inquirystatus_list(dtaa);
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
                riskcategory.DataSource = dtaa;
                riskcategory.DisplayMember = "RiskCategory";
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
                matchcriteria.DataSource = dtaa;
                matchcriteria.DisplayMember = "MatchCriteria";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void admin_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EmpDetails obj_empdetails = new EmpDetails();
                DataTable dtaa = new DataTable();
                obj_empdetails.admin_list(dtaa,Environment.UserName.ToString());
                adminlist.DataSource = dtaa;
                adminlist.DisplayMember = "BatchWorkflow_Access";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
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
                queryremarks.DataSource = dtaa;
                queryremarks.DisplayMember = "QueryRemarks";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void typeofapproval_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                TypeOfApproval obj_typeofapproval = new TypeOfApproval();
                DataTable dtaa = new DataTable();
                obj_typeofapproval.typeofapproval_list(dtaa);
                typeofapproval.DataSource = dtaa;
                typeofapproval.DisplayMember = "TypeOfApproval";
                conn.Close();

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void eventcode_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                EventCodes obj_eventcode = new EventCodes();
                DataTable dtaa = new DataTable();
                obj_eventcode.eventcode_list(dtaa);
                eventcodes.DataSource = dtaa;
                eventcodes.DisplayMember = "EventCodeDescription";
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
                DataTable dtaa1 = new DataTable();

                obj_sourcebu.sourcebu_list(dtaa);
                obj_sourcebu.sourcebu_searchby_list(dtaa1);

                sourcebu.DataSource = dtaa;
                sourcebu.DisplayMember = "ReportingID";

                searchby_sourcebu_batchworkflow.DataSource = dtaa1;
                searchby_sourcebu_batchworkflow.DisplayMember = "ReportingID";
                conn.Close();

                searchby_sourcebu_batchworkflow.SelectedIndex = -1;

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        

        private void completiondate_MouseHover(object sender, EventArgs e)
        {
            completiondate.CustomFormat = "dd-MMMM-yyyy";
            //completiondate.Text = DateTime.Now.ToLongDateString();
        }

        private void completiontime_MouseHover(object sender, EventArgs e)
        {
            completiontime.CustomFormat = "HH:mm:ss";
            completiontime.Text = DateTime.Now.ToLongTimeString();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (approvalraiseddate.Text.Trim() != string.Empty && !string.IsNullOrEmpty(riskid.Text) && !string.IsNullOrEmpty(batchid.Text))
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
                cmd.CommandText = "select distinct CONCAT(BatchID,RiskID) as Concat_BatchID_RiskID from dbo.vw_batchworkflow_daily_dotnet where ApprovalRaisedDate is not null and ApprovalReceivedDate is null and RiskID = @RiskID and BatchID  = @BatchID and RiskID is not NULL and BatchID is not null";
                cmd.Parameters.AddWithValue("@RiskID", riskid.Text);
                cmd.Parameters.AddWithValue("@BatchID", batchid.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                concat_batchid_riskid.DataSource = dt;
                concat_batchid_riskid.DisplayMember = "Concat_BatchID_RiskID";
                conn.Close();
                if (!string.IsNullOrEmpty(concat_batchid_riskid.Text))
                {
                    //MessageBox.Show("Approval has already been raised for the select RiskID and Batch ID. Hence approval cannot be raised again");
                    string messsage = "Approval has already been raised for the select RiskID and BatchID. Do you want to continue raising for approval?";
                    string title = "Message Box";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(messsage, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        insert_records();
                    }
                }
                else
                {
                    insert_records();
                }
                
            }
            else
            {
                    insert_records();
            }
        }
        

        public void datagridview_batchworkflow_display_overall()
        {
            
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //try
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    conn.ConnectionString = connectionstringtxt;
            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.Parameters.Clear();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and AssociateLoginID_Allocation = @loginidparam order by BatchID,InquiryID";
            //    cmd.Parameters.AddWithValue("@loginidparam",Environment.UserName.ToString());
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);
            //    batchworkflow_datagridview.DataSource = dt;
            //    conn.Close();
            //}
            //catch (Exception ab)
            //{
            //    MessageBox.Show("Error Generated Details : " + ab.ToString());
            //}

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
                    cmd.CommandText = "select top 100 RequestID,BatchID,InquiryID,RiskID,EntityID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,AssociateLoginID_Allocation,convert(date,AllocationDate) as AllocationDate,convert(time,AllocationDate) as AllocationTime,AllocatedBy,ProjectNonProject,Project_LastUpdatedBy,convert(date,Project_LastUpdatedDateTime) as Project_LastUpdatedDate,convert(time,Project_LastUpdatedDateTime) as Project_LastUpdatedTime,convert(date,UploadDateTime) as UploadDate,convert(time,UploadDateTime) as UploadTime,UploadedBy,EventList,LastUpdatedBy,ApprovedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and AssociateLoginID_Allocation = @loginidparam order by RequestID desc,BatchID,InquiryID";
                    cmd.Parameters.AddWithValue("@loginidparam", Environment.UserName.ToString());
                }
                //else if (!string.IsNullOrEmpty(searchby_batchid_batchworkflow.Text) || !string.IsNullOrEmpty(searchby_inquiryid_batchworkflow.Text) || !string.IsNullOrEmpty(searchby_riskid_batchworkflow.Text) || !string.IsNullOrEmpty(searchby_partyname_batchworkflow.Text) || searchby_pagenumber_batchworkflow.Value > 0 || !string.IsNullOrEmpty(searchby_inquirystatus_batchworkflow.Text))
                else
                {
                    //cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and batchid = coalesce(@batchid,batchid) and inquiryid = coalesce(@inquiryid,inquiryid) and riskid = coalesce(@riskid,riskid) and partyname = coalesce(@partyname,partyname) and pagenumber = coalesce(@pagenumber,pagenumber) and inquirystatus = coalesce(@inquirystatus,inquirystatus) order by BatchID,InquiryID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_batchworkflow_datagridview_search_dotnet";
                    if(string.IsNullOrEmpty(searchby_batchid_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@batchid",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@batchid",searchby_batchid_batchworkflow.Text);
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
                        cmd.Parameters.AddWithValue("@riskid",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@riskid", searchby_riskid_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_partyname_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@partyname",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@partyname", searchby_partyname_batchworkflow.Text);
                    }
                    if (searchby_pagenumber_batchworkflow.Value == 0)
                    {
                        cmd.Parameters.AddWithValue("@pagenumber",0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pagenumber", searchby_pagenumber_batchworkflow.Value);
                    }
                    if (string.IsNullOrEmpty(searchby_inquirystatus_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@inquirystatus",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@inquirystatus", searchby_inquirystatus_batchworkflow.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_associatename_batchworkflow.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename",searchby_associatename_batchworkflow.Text);
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
                        cmd.Parameters.AddWithValue("@eventlist",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@eventlist",searchby_eventlist_batchworkflow.Text);
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

        private void searchby_batchid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //try
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    conn.ConnectionString = connectionstringtxt;
            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.Parameters.Clear();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and BatchID like @BatchID order by BatchID,InquiryID";
            //    cmd.Parameters.AddWithValue("@BatchID", "%" + searchby_batchid_batchworkflow.Text + "%");
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);
            //    batchworkflow_datagridview.DataSource = dt;
            //    conn.Close();
            //}
            //catch (Exception ab)
            //{
            //    MessageBox.Show("Error Generated Details : " + ab.ToString());
            //}
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_inquiryid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //try
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    conn.ConnectionString = connectionstringtxt;
            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.Parameters.Clear();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and InquiryID like @InquiryID order by BatchID,InquiryID";
            //    cmd.Parameters.AddWithValue("@InquiryID", "%" + searchby_inquiryid_batchworkflow.Text + "%");
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);
            //    batchworkflow_datagridview.DataSource = dt;
            //    conn.Close();
            //}
            //catch (Exception ab)
            //{
            //    MessageBox.Show("Error Generated Details : " + ab.ToString());
            //}
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_partyname_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //try
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    conn.ConnectionString = connectionstringtxt;
            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.Parameters.Clear();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and PartyName like @PartyName order by BatchID,InquiryID";
            //    cmd.Parameters.AddWithValue("@PartyName", "%" + searchby_partyname_batchworkflow.Text + "%");
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);
            //    batchworkflow_datagridview.DataSource = dt;
            //    conn.Close();
            //}
            //catch (Exception ab)
            //{
            //    MessageBox.Show("Error Generated Details : " + ab.ToString());
            //}
            datagridview_batchworkflow_display_overall();
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
                    batchid.Text = row.Cells["txtBatchIDbatch"].Value.ToString();
                    inquiryid.Text = row.Cells["txtInquiryIDbatch"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txtRiskIDbatch"].Value.ToString()))
                    {
                        riskid.Text = string.Empty;
                    }
                    else
                    {
                        riskid.Text = row.Cells["txtRiskIDbatch"].Value.ToString();
                    }
                    trackingid.Text = row.Cells["txtTrackingIDbatch"].Value.ToString();
                    receiveddate.Text = row.Cells["txtReceivedDatebatch"].Value.ToString();
                    receiveddate.CustomFormat = "dd-MMMM-yyyy";
                    receivedtime.Text = row.Cells["txtReceivedTimebatch"].Value.ToString();
                    receivedtime.CustomFormat = "HH:mm:ss";
                    entitytype.Text = row.Cells["txtEntityTypebatch"].Value.ToString();
                    partyname.Text = row.Cells["txtPartyNamebatch"].Value.ToString();
                    sourcebu.Text = row.Cells["txtSourceBUbatch"].Value.ToString();
                    noofhits.Value = Convert.ToInt32(row.Cells["txtNoOfHitsbatch"].Value);
                    if (string.IsNullOrEmpty(row.Cells["txtRiskCategorybatch"].Value.ToString()))
                    {
                        riskcategory.SelectedIndex = -1;
                    }
                    else
                    {
                        riskcategory.Text = row.Cells["txtRiskCategorybatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtEventCodesbatch"].Value.ToString()))
                    {
                        eventcodes.SelectedIndex = -1;
                    }
                    else
                    {
                        eventcodes.Text = row.Cells["txtEventCodesbatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtApprovedBy"].Value.ToString()))
                    {
                        approvedby.SelectedIndex = -1;
                    }
                    else
                    {
                        approvedby.Text = row.Cells["txtApprovedBy"].Value.ToString();
                    }
                    matchcriteria.Text = row.Cells["txtMatchCriteriabatch"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txtQueryRaisedDatebatch"].Value.ToString()))
                    {
                        queryraiseddate.CustomFormat = " ";
                        queryraisedtime.CustomFormat = " ";
                        queryremarks.SelectedIndex = -1;
                    }
                    else
                    {
                        queryraiseddate.Text = row.Cells["txtQueryRaisedDatebatch"].Value.ToString();
                        queryraiseddate.CustomFormat = "dd-MMMM-yyyy";
                        queryraisedtime.Text = row.Cells["txtQueryRaisedTimebatch"].Value.ToString();
                        queryraisedtime.CustomFormat = "HH:mm:ss";
                        queryremarks.Text = row.Cells["txtQueryRemarksbatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtQueryResolvedDatebatch"].Value.ToString()))
                    {
                        queryresolveddate.CustomFormat = " ";
                        queryresolvedtime.CustomFormat = " ";
                    }
                    else
                    {
                        queryresolveddate.Text = row.Cells["txtQueryResolvedDatebatch"].Value.ToString();
                        queryresolveddate.CustomFormat = "dd-MMMM-yyyy";
                        queryresolvedtime.Text = row.Cells["txtQueryResolvedTimebatch"].Value.ToString();
                        queryresolvedtime.CustomFormat = "HH:mm:ss";
                    }
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
                    if (string.IsNullOrEmpty(row.Cells["txtSMSORaisedDatebatch"].Value.ToString()))
                    {
                        smsoraiseddate.CustomFormat = " ";
                        smsoraisedtime.CustomFormat = " ";
                    }
                    else
                    {
                        smsoraiseddate.Text = row.Cells["txtSMSORaisedDatebatch"].Value.ToString();
                        smsoraiseddate.CustomFormat = "dd-MMMM-yyyy";
                        smsoraisedtime.Text = row.Cells["txtSMSORaisedTimebatch"].Value.ToString();
                        smsoraisedtime.CustomFormat = "HH:mm:ss";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtSMSOReceivedDatebatch"].Value.ToString()))
                    {
                        smsoreceiveddate.CustomFormat = " ";
                        smsoreceivedtime.CustomFormat = " ";
                        smsoapprovedby.Text = string.Empty;
                    }
                    else
                    {
                        smsoreceiveddate.Text = row.Cells["txtSMSOReceivedDatebatch"].Value.ToString();
                        smsoreceiveddate.CustomFormat = "dd-MMMM-yyyy";
                        smsoreceivedtime.Text = row.Cells["txtSMSOReceivedTimebatch"].Value.ToString();
                        smsoreceivedtime.CustomFormat = "HH:mm:ss";
                        smsoapprovedby.Text = row.Cells["txtSMSOApprovedBybatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtApprovalRejectionCommentbatch"].Value.ToString()))
                    {
                        approvalrejectioncomment.Text = string.Empty;
                    }
                    else
                    {
                        approvalrejectioncomment.Text = row.Cells["txtApprovalRejectionCommentbatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtChaser1Datebatch"].Value.ToString()))
                    {
                        chaser1.CustomFormat = " ";
                    }
                    else
                    {
                        chasers_checkbox.Checked = true;
                        chaser1_checkbox.Checked = true;
                        chaser1_checkbox.Visible = true;
                        chaser1.Text = row.Cells["txtChaser1Datebatch"].Value.ToString();
                        chaser1.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtChaser2Datebatch"].Value.ToString()))
                    {
                        chaser2.CustomFormat = " ";
                    }
                    else
                    {

                        chaser2_checkbox.Checked = true;
                        chaser2_checkbox.Visible = true;
                        chaser2.Text = row.Cells["txtChaser2Datebatch"].Value.ToString();
                        chaser2.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtChaser3Datebatch"].Value.ToString()))
                    {
                        chaser3.CustomFormat = " ";
                    }
                    else
                    {
                        chaser3_checkbox.Checked = true;
                        chaser3_checkbox.Visible = true;
                        chaser3.Text = row.Cells["txtChaser3Datebatch"].Value.ToString();
                        chaser3.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtRequestorEmailAddressbatch"].Value.ToString()))
                    {
                        requestoremailaddress.Text = string.Empty;
                    }
                    else
                    {
                        requestoremailaddress.Text = row.Cells["txtRequestorEmailAddressbatch"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtInquiryStatus"].Value.ToString()))
                    {
                        inquirystatus.SelectedIndex = -1;
                    }
                    else
                    {
                        inquirystatus.Text = row.Cells["txtInquiryStatus"].Value.ToString();
                    }
                    //associateloginid_allocation.Text = row.Cells["txtAssociateLoginID_Allocation"].Value.ToString();
                    pagenumber.Value = Convert.ToInt32(row.Cells["txtPageNumber"].Value);
                    associatename_allocation.Text = row.Cells["txtAssociateName_Allocation"].Value.ToString();
                    associateloginid_allocation1.Text = row.Cells["txtAssociateLoginID_Allocation"].Value.ToString();
                    allocationdate.Text = row.Cells["txtAllocationDate"].Value.ToString();
                    allocationdate.CustomFormat = "dd-MMMM-yyyy";
                    allocationtime.Text = row.Cells["txtAllocationTime"].Value.ToString();
                    allocationtime.CustomFormat = "HH:mm:ss";
                    allocatedby.Text = row.Cells["txtAllocatedBy"].Value.ToString();
                    projectnonproject.Text = row.Cells["txtProjectNonProject"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txtProject_LastUpdatedBy"].Value.ToString()))
                    {
                        project_lastupdatedby.Text = string.Empty;
                    }
                    else
                    {
                        project_lastupdatedby.Text = row.Cells["txtProject_LastUpdatedBy"].Value.ToString();

                    }
                    if (string.IsNullOrEmpty(row.Cells["txtProject_LastUpdatedDate"].Value.ToString()))
                    {
                        project_lastupdateddate.CustomFormat = " ";
                    }
                    else
                    {
                        project_lastupdateddate.Text = row.Cells["txtProject_LastUpdatedDate"].Value.ToString();
                        project_lastupdateddate.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txtProject_LastUpdatedTime"].Value.ToString()))
                    {
                        project_lastupdatedtime.CustomFormat = " ";
                    }
                    else
                    {
                        project_lastupdatedtime.Text = row.Cells["txtProject_LastUpdatedTime"].Value.ToString();
                        project_lastupdatedtime.CustomFormat = "HH:mm:ss";

                    }
                    if (string.IsNullOrEmpty(row.Cells["txtentityidbatch"].Value.ToString()))
                    {
                        entityid.Text = string.Empty;
                    }
                    else
                    {
                        entityid.Text = row.Cells["txtentityidbatch"].Value.ToString();
                    }
                    uploaddate.Text = row.Cells["txtUploadDate"].Value.ToString();
                    uploaddate.CustomFormat = "dd-MMMM-yyyy";
                    uploadtime.Text = row.Cells["txtUploadTime"].Value.ToString();
                    uploadtime.CustomFormat = "HH:mm:ss";
                    uploadedby.Text = row.Cells["txtUploadedBy"].Value.ToString();
                }
                //checkBox2.Enabled = true;
                if (update.Enabled == true && (inquirystatus_associatename.Text == "naika" || inquirystatus_associatename.Text == "kamathgg" || inquirystatus_associatename.Text == "BhosaleSh" || inquirystatus_associatename.Text == "parikhrm" || inquirystatus_associatename.Text == "ShethCh" || inquirystatus_associatename.Text == "BhallaMa" || inquirystatus_associatename.Text == "DsouzaDiX" || inquirystatus_associatename.Text == "SwamySh" || inquirystatus_associatename.Text == "RaoSR" || inquirystatus_associatename.Text == "BOMBLEHA" || inquirystatus_associatename.Text == "NairRaR"))
                {
                    checkBox2.Enabled = true;
                }
                else
                {
                    checkBox2.Enabled = false;
                }
            }
            else
            {
                batchid.Focus();
            }
        }

        private void queryraiseddate_MouseHover(object sender, EventArgs e)
        {
            queryraiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void queryraisedtime_MouseHover(object sender, EventArgs e)
        {
            queryraisedtime.CustomFormat = "HH:mm:ss";
            queryraisedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void queryresolveddate_MouseHover(object sender, EventArgs e)
        {
            queryresolveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 obj_form4 = new Form4();
            obj_form4.Show();
        }

        private void riskcategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                riskcategory.SelectedIndex = -1;
            }
        }

        private void eventcodes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                eventcodes.SelectedIndex = -1;
            }
        }

        private void matchcriteria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                matchcriteria.SelectedIndex = -1;
            }
        }

        private void queryremarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                queryremarks.SelectedIndex = -1;
            }
        }

        private void typeofapproval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                typeofapproval.SelectedIndex = -1;
            }
        }

        private void batchworkflow_datagridview_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow myrow in batchworkflow_datagridview.Rows)
            {
                if (myrow.Cells["txtFinalStatusbatch"].Value.ToString() == "Completed")
                {
                    myrow.DefaultCellStyle.BackColor = Color.Green;
                    myrow.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    myrow.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void searchby_pagenumber_batchworkflow_ValueChanged(object sender, EventArgs e)
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //try
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    conn.ConnectionString = connectionstringtxt;
            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.Parameters.Clear();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and PageNumber = @PageNumber order by requestid";
            //    cmd.Parameters.AddWithValue("@PageNumber", Convert.ToInt32(searchby_pagenumber_batchworkflow.Value));
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);
            //    batchworkflow_datagridview.DataSource = dt;
            //    conn.Close();
            //}
            //catch (Exception ab)
            //{
            //    MessageBox.Show("Error Generated Details : " + ab.ToString());
            //}
            datagridview_batchworkflow_display_overall();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true && !string.IsNullOrEmpty(entityid.Text))
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_batchworkflow_update_inquirystatus_bulk_dotnet";
                cmd.Parameters.AddWithValue("@entityid", entityid.Text);
                cmd.Parameters.AddWithValue("@inquirystatus", inquirystatus.Text);
                cmd.Parameters.AddWithValue("@comments", approvalrejectioncomment.Text);
                cmd.Parameters.AddWithValue("@completiondate", completiondate.Value.Date);
                cmd.Parameters.AddWithValue("@completiontime", completiontime.Value.ToLongTimeString());
                cmd.Parameters.AddWithValue("@matchcriteria",matchcriteria.Text);
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                string uploadmessage1 = cmd.Parameters["@Message"].Value.ToString();
                MessageBox.Show("" + uploadmessage1.ToString());
                cmd.Parameters.Clear();
                conn.Close();
            }
            
            if (approvalraiseddate.Text.Trim() != string.Empty && !string.IsNullOrEmpty(riskid.Text) && !string.IsNullOrEmpty(batchid.Text))
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
                cmd.CommandText = "select distinct CONCAT(BatchID,RiskID) as Concat_BatchID_RiskID from dbo.vw_batchworkflow_daily_dotnet where ApprovalRaisedDate is not null and ApprovalReceivedDate is null and RiskID = @RiskID and BatchID  = @BatchID and RiskID is not NULL and BatchID is not null";
                cmd.Parameters.AddWithValue("@RiskID", riskid.Text);
                cmd.Parameters.AddWithValue("@BatchID", batchid.Text);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                concat_batchid_riskid.DataSource = dt;
                concat_batchid_riskid.DisplayMember = "Concat_BatchID_RiskID";
                conn.Close();
                if (!string.IsNullOrEmpty(concat_batchid_riskid.Text))
                {
                    //MessageBox.Show("Approval has already been raised for the select RiskID and Batch ID. Hence approval cannot be raised again");
                    string messsage = "Approval has already been raised for the select RiskID and BatchID. Do you want to continue raising for approval?";
                    string title = "Message Box";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(messsage, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        update_records();
                    }
                }
                else
                {
                    update_records();
                }
            }
            else
            {
                update_records();
            }
        }

        private void searchby_inquirystatus_batchworkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}
            //try
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    conn.ConnectionString = connectionstringtxt;
            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.Parameters.Clear();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select RequestID,BatchID,InquiryID,RiskID,TrackingID,ReceivedDate,ReceivedTime,EntityType,PartyName,SourceBU,NoOfHits,RiskCategory,EventCodes,MatchCriteria,QueryRaisedDate,QueryRaisedTime,QueryResolvedDate,QueryResolvedTime,QueryRemarks,ApprovalRaisedDate,ApprovalRaisedTime,ApprovalReceivedDate,ApprovalReceivedTime,TypeOfApproval,CompletionDate,CompletionTime,SMSORaisedDate,SMSORaisedTime,SMSOReceivedDate,SMSOReceivedTime,SMSOApprovedBy,ApprovalRejectionComment,Chaser1Date,Chaser2Date,Chaser3Date,RequestorEmailAddress,FinalStatus,PageNumber,InquiryStatus,AssociateName_Allocation,ProjectNonProject,AllocationDate,AllocatedBy from dbo.tbl_batchworkflow_daily_dotnet with(nolock) where IsDeleted = 0 and InquiryStatus = @InquiryStatus order by BatchID,InquiryID";
            //    cmd.Parameters.AddWithValue("@InquiryStatus", searchby_inquirystatus_batchworkflow.Text);
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);
            //    batchworkflow_datagridview.DataSource = dt;
            //    conn.Close();
            //}
            //catch (Exception ab)
            //{
            //    MessageBox.Show("Error Generated Details : " + ab.ToString());
            //}
            datagridview_batchworkflow_display_overall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://A20-CB-DBSE01P/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_BatchWorkflow_Rawdata_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        

        private void searchby_riskid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_inquirystatus_batchworkflow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_inquirystatus_batchworkflow.SelectedIndex = -1;
            }
        }

        private void queryresolvedtime_MouseHover(object sender, EventArgs e)
        {
            queryresolvedtime.CustomFormat = "HH:mm:ss";
            queryresolvedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void approvalraiseddate_MouseHover(object sender, EventArgs e)
        {
            approvalraiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void approvalraisedtime_MouseHover(object sender, EventArgs e)
        {
            approvalraisedtime.CustomFormat = "HH:mm:ss";
            approvalraisedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void approvalreceiveddate_MouseHover(object sender, EventArgs e)
        {
            approvalreceiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void approvalreceivedtime_MouseHover(object sender, EventArgs e)
        {
            approvalreceivedtime.CustomFormat = "HH:mm:ss";
            approvalreceivedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void smsoraiseddate_MouseHover(object sender, EventArgs e)
        {
            smsoraiseddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void smsoraisedtime_MouseHover(object sender, EventArgs e)
        {
            smsoraisedtime.CustomFormat = "HH:mm:ss";
            smsoraisedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void smsoreceiveddate_MouseHover(object sender, EventArgs e)
        {
            smsoreceiveddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void smsoreceivedtime_MouseHover(object sender, EventArgs e)
        {
            smsoreceivedtime.CustomFormat = "HH:mm:ss";
            smsoreceivedtime.Text = DateTime.Now.ToLongTimeString();
        }

        

        private void searchby_associatename_batchworkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void matchcriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (matchcriteria.Text == "Mis Match")
            {
                inquirystatus.Text = "Mismatch";
            }
            else if (matchcriteria.Text == "Low Risk")
            {
                inquirystatus.Text = "Low Risk";
            }

            if (string.IsNullOrEmpty(entityid.Text))
            {
                entityid.Enabled = true;
            }
            else
            {
                entityid.Enabled = false;
            }
            
        }

        private void searchby_associatename_batchworkflow_TextUpdate(object sender, EventArgs e)
        {
            //datagridview_batchworkflow_display_overall();
        }

        private void searchby_associatename_batchworkflow_SelectionChangeCommitted(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_associatename_batchworkflow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_associatename_batchworkflow.SelectedIndex = -1;
            }
        }

        private void allocationdate_ValueChanged(object sender, EventArgs e)
        {
            allocationdate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void allocationdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                allocationdate.CustomFormat = " ";
            }
        }

        private void allocationtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                allocationtime.CustomFormat = " ";
            }
        }

        private void allocationtime_MouseDown(object sender, MouseEventArgs e)
        {
            allocationtime.CustomFormat = "HH:mm:ss";
            allocationtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void project_lastupdateddate_ValueChanged(object sender, EventArgs e)
        {
            project_lastupdateddate.CustomFormat = "dd-MMMM-yyyy";
            //project_lastupdateddate.Text = DateTime.Now.ToLongDateString();
        }

        private void project_lastupdateddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                project_lastupdateddate.CustomFormat = " ";
            }
        }

        private void project_lastupdatedtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                project_lastupdatedtime.CustomFormat = " ";
            }
        }

        private void project_lastupdatedtime_MouseDown(object sender, MouseEventArgs e)
        {
            project_lastupdatedtime.CustomFormat = "HH:mm:ss";
            project_lastupdatedtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void uploaddate_ValueChanged(object sender, EventArgs e)
        {
            uploaddate.CustomFormat = "dd-MMMM-yyyy";
        }

        private void uploaddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                uploaddate.CustomFormat = " ";
            }
        }

        private void uploadtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                uploadtime.CustomFormat = " ";
            }
        }

        private void uploadtime_MouseDown(object sender, MouseEventArgs e)
        {
            uploadtime.CustomFormat = "HH:mm:ss";
            uploadtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void searchby_requestid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_entityid_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void searchby_eventlist_batchworkflow_TextChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void searchby_sourcebu_batchworkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_batchworkflow_display_overall();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void approvalraisedtime_ValueChanged(object sender, EventArgs e)
        {

        }

       

        

    }
}
