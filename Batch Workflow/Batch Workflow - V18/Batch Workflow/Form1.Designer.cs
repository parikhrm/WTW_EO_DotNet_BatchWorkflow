namespace Batch_Workflow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.excelsheetname = new System.Windows.Forms.TextBox();
            this.excelfilepath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFirmNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBatchType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBatchSubmittedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBatchCompletedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBatchStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTrackingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReportingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryAddressLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryProvince = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryPostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInquiryNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReasonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDecisioningNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEntityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtListEntryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEventList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMatchScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCVIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUploadDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUploadedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(194, 33);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 32);
            this.button4.TabIndex = 0;
            this.button4.Text = "Select File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(856, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Excel Sheet Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Excel File Path";
            // 
            // excelsheetname
            // 
            this.excelsheetname.Location = new System.Drawing.Point(1029, 33);
            this.excelsheetname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelsheetname.Name = "excelsheetname";
            this.excelsheetname.Size = new System.Drawing.Size(224, 26);
            this.excelsheetname.TabIndex = 3;
            // 
            // excelfilepath
            // 
            this.excelfilepath.Location = new System.Drawing.Point(374, 33);
            this.excelfilepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelfilepath.Name = "excelfilepath";
            this.excelfilepath.Size = new System.Drawing.Size(414, 26);
            this.excelfilepath.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtFirmNo,
            this.txtID,
            this.txtBatchID,
            this.txtBatchType,
            this.txtBatchSubmittedDate,
            this.txtBatchCompletedDate,
            this.txtBatchStatus,
            this.txtInquiryID,
            this.txtTrackingID,
            this.txtReportingID,
            this.txtInquiryName,
            this.txtInquiryDateOfBirth,
            this.txtInquiryAddressLine1,
            this.txtInquiryCity,
            this.txtInquiryProvince,
            this.txtInquiryPostalCode,
            this.txtInquiryCountry,
            this.txtInquiryNotes,
            this.txtDecision,
            this.txtReasonCode,
            this.txtUserName,
            this.txtDecisioningNotes,
            this.txtEntityID,
            this.txtListEntryID,
            this.txtName,
            this.txtType,
            this.txtDateOfBirth,
            this.txtDate,
            this.txtAddress,
            this.txtEventList,
            this.txtMatchScore,
            this.txtCVIP,
            this.txtUploadDateTime,
            this.txtUploadedBy,
            this.txtMachineName});
            this.dataGridView1.Location = new System.Drawing.Point(14, 226);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1873, 760);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(7, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 58);
            this.button2.TabIndex = 0;
            this.button2.Text = "Load the records below";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(199, 25);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 58);
            this.button3.TabIndex = 1;
            this.button3.Text = "Upload Final";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(416, 25);
            this.reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(195, 58);
            this.reset.TabIndex = 2;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(486, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(664, 108);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(14, 71);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(243, 66);
            this.button8.TabIndex = 130;
            this.button8.Text = "Click here to download RDC upload template.";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(453, 62);
            this.label3.TabIndex = 131;
            this.label3.Text = "Update dates in \'dd/mm/yyyy hh:mm\' format in the template file.\r\nRemove single qu" +
    "otes (\') from the data (all the columns).\r\nRemove commas (,) from the data (all " +
    "the columns).";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(14, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 34);
            this.button1.TabIndex = 132;
            this.button1.Text = "Home Page";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFirmNo
            // 
            this.txtFirmNo.DataPropertyName = "FirmNo";
            this.txtFirmNo.HeaderText = "FirmNo";
            this.txtFirmNo.Name = "txtFirmNo";
            this.txtFirmNo.ReadOnly = true;
            // 
            // txtID
            // 
            this.txtID.DataPropertyName = "ID";
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Visible = false;
            // 
            // txtBatchID
            // 
            this.txtBatchID.DataPropertyName = "BatchID";
            this.txtBatchID.HeaderText = "BatchID";
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.ReadOnly = true;
            // 
            // txtBatchType
            // 
            this.txtBatchType.DataPropertyName = "BatchType";
            this.txtBatchType.HeaderText = "BatchType";
            this.txtBatchType.Name = "txtBatchType";
            this.txtBatchType.ReadOnly = true;
            // 
            // txtBatchSubmittedDate
            // 
            this.txtBatchSubmittedDate.DataPropertyName = "BatchSubmittedDate";
            this.txtBatchSubmittedDate.HeaderText = "BatchSubmittedDate";
            this.txtBatchSubmittedDate.Name = "txtBatchSubmittedDate";
            this.txtBatchSubmittedDate.ReadOnly = true;
            // 
            // txtBatchCompletedDate
            // 
            this.txtBatchCompletedDate.DataPropertyName = "BatchCompletedDate";
            this.txtBatchCompletedDate.HeaderText = "BatchCompletedDate";
            this.txtBatchCompletedDate.Name = "txtBatchCompletedDate";
            this.txtBatchCompletedDate.ReadOnly = true;
            // 
            // txtBatchStatus
            // 
            this.txtBatchStatus.DataPropertyName = "BatchStatus";
            this.txtBatchStatus.HeaderText = "BatchStatus";
            this.txtBatchStatus.Name = "txtBatchStatus";
            this.txtBatchStatus.ReadOnly = true;
            // 
            // txtInquiryID
            // 
            this.txtInquiryID.DataPropertyName = "InquiryID";
            this.txtInquiryID.HeaderText = "InquiryID";
            this.txtInquiryID.Name = "txtInquiryID";
            this.txtInquiryID.ReadOnly = true;
            // 
            // txtTrackingID
            // 
            this.txtTrackingID.DataPropertyName = "TrackingID";
            this.txtTrackingID.HeaderText = "TrackingID";
            this.txtTrackingID.Name = "txtTrackingID";
            this.txtTrackingID.ReadOnly = true;
            // 
            // txtReportingID
            // 
            this.txtReportingID.DataPropertyName = "ReportingID";
            this.txtReportingID.HeaderText = "ReportingID";
            this.txtReportingID.Name = "txtReportingID";
            this.txtReportingID.ReadOnly = true;
            // 
            // txtInquiryName
            // 
            this.txtInquiryName.DataPropertyName = "InquiryName";
            this.txtInquiryName.HeaderText = "InquiryName";
            this.txtInquiryName.Name = "txtInquiryName";
            this.txtInquiryName.ReadOnly = true;
            this.txtInquiryName.Width = 123;
            // 
            // txtInquiryDateOfBirth
            // 
            this.txtInquiryDateOfBirth.DataPropertyName = "InquiryDateOfBirth";
            this.txtInquiryDateOfBirth.HeaderText = "InquiryDateOfBirth";
            this.txtInquiryDateOfBirth.Name = "txtInquiryDateOfBirth";
            this.txtInquiryDateOfBirth.ReadOnly = true;
            // 
            // txtInquiryAddressLine1
            // 
            this.txtInquiryAddressLine1.DataPropertyName = "InquiryAddressLine1";
            this.txtInquiryAddressLine1.HeaderText = "InquiryAddressLine1";
            this.txtInquiryAddressLine1.Name = "txtInquiryAddressLine1";
            this.txtInquiryAddressLine1.ReadOnly = true;
            // 
            // txtInquiryCity
            // 
            this.txtInquiryCity.DataPropertyName = "InquiryCity";
            this.txtInquiryCity.HeaderText = "InquiryCity";
            this.txtInquiryCity.Name = "txtInquiryCity";
            this.txtInquiryCity.ReadOnly = true;
            // 
            // txtInquiryProvince
            // 
            this.txtInquiryProvince.DataPropertyName = "InquiryProvince";
            this.txtInquiryProvince.HeaderText = "InquiryProvince";
            this.txtInquiryProvince.Name = "txtInquiryProvince";
            this.txtInquiryProvince.ReadOnly = true;
            // 
            // txtInquiryPostalCode
            // 
            this.txtInquiryPostalCode.DataPropertyName = "InquiryPostalCode";
            this.txtInquiryPostalCode.HeaderText = "InquiryPostalCode";
            this.txtInquiryPostalCode.Name = "txtInquiryPostalCode";
            this.txtInquiryPostalCode.ReadOnly = true;
            // 
            // txtInquiryCountry
            // 
            this.txtInquiryCountry.DataPropertyName = "InquiryCountry";
            this.txtInquiryCountry.HeaderText = "InquiryCountry";
            this.txtInquiryCountry.Name = "txtInquiryCountry";
            this.txtInquiryCountry.ReadOnly = true;
            // 
            // txtInquiryNotes
            // 
            this.txtInquiryNotes.DataPropertyName = "InquiryNotes";
            this.txtInquiryNotes.HeaderText = "InquiryNotes";
            this.txtInquiryNotes.Name = "txtInquiryNotes";
            this.txtInquiryNotes.ReadOnly = true;
            // 
            // txtDecision
            // 
            this.txtDecision.DataPropertyName = "Decision";
            this.txtDecision.HeaderText = "Decision";
            this.txtDecision.Name = "txtDecision";
            this.txtDecision.ReadOnly = true;
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.DataPropertyName = "ReasonCode";
            this.txtReasonCode.HeaderText = "ReasonCode";
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.ReadOnly = true;
            // 
            // txtUserName
            // 
            this.txtUserName.DataPropertyName = "UserName";
            this.txtUserName.HeaderText = "UserName";
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            // 
            // txtDecisioningNotes
            // 
            this.txtDecisioningNotes.DataPropertyName = "DecisioningNotes";
            this.txtDecisioningNotes.HeaderText = "DecisioningNotes";
            this.txtDecisioningNotes.Name = "txtDecisioningNotes";
            this.txtDecisioningNotes.ReadOnly = true;
            // 
            // txtEntityID
            // 
            this.txtEntityID.DataPropertyName = "EntityID";
            this.txtEntityID.HeaderText = "EntityID";
            this.txtEntityID.Name = "txtEntityID";
            this.txtEntityID.ReadOnly = true;
            // 
            // txtListEntryID
            // 
            this.txtListEntryID.DataPropertyName = "ListEntryID";
            this.txtListEntryID.HeaderText = "ListEntryID";
            this.txtListEntryID.Name = "txtListEntryID";
            this.txtListEntryID.ReadOnly = true;
            // 
            // txtName
            // 
            this.txtName.DataPropertyName = "Name";
            this.txtName.HeaderText = "Name";
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            // 
            // txtType
            // 
            this.txtType.DataPropertyName = "Type";
            this.txtType.HeaderText = "Type";
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            // 
            // txtDateOfBirth
            // 
            this.txtDateOfBirth.DataPropertyName = "DateOfBirth";
            this.txtDateOfBirth.HeaderText = "DateOfBirth";
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.ReadOnly = true;
            // 
            // txtDate
            // 
            this.txtDate.DataPropertyName = "Date";
            this.txtDate.HeaderText = "Date";
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            // 
            // txtAddress
            // 
            this.txtAddress.DataPropertyName = "Address";
            this.txtAddress.HeaderText = "Address";
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            // 
            // txtEventList
            // 
            this.txtEventList.DataPropertyName = "EventList";
            this.txtEventList.HeaderText = "EventList";
            this.txtEventList.Name = "txtEventList";
            this.txtEventList.ReadOnly = true;
            // 
            // txtMatchScore
            // 
            this.txtMatchScore.DataPropertyName = "MatchScore";
            this.txtMatchScore.HeaderText = "MatchScore";
            this.txtMatchScore.Name = "txtMatchScore";
            this.txtMatchScore.ReadOnly = true;
            // 
            // txtCVIP
            // 
            this.txtCVIP.DataPropertyName = "CVIP";
            this.txtCVIP.HeaderText = "CVIP";
            this.txtCVIP.Name = "txtCVIP";
            this.txtCVIP.ReadOnly = true;
            // 
            // txtUploadDateTime
            // 
            this.txtUploadDateTime.DataPropertyName = "UploadDateTime";
            this.txtUploadDateTime.HeaderText = "UploadDateTime";
            this.txtUploadDateTime.Name = "txtUploadDateTime";
            this.txtUploadDateTime.ReadOnly = true;
            this.txtUploadDateTime.Visible = false;
            // 
            // txtUploadedBy
            // 
            this.txtUploadedBy.DataPropertyName = "UploadedBy";
            this.txtUploadedBy.HeaderText = "UploadedBy";
            this.txtUploadedBy.Name = "txtUploadedBy";
            this.txtUploadedBy.ReadOnly = true;
            this.txtUploadedBy.Visible = false;
            // 
            // txtMachineName
            // 
            this.txtMachineName.DataPropertyName = "MachineName";
            this.txtMachineName.HeaderText = "MachineName";
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.ReadOnly = true;
            this.txtMachineName.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excelsheetname);
            this.Controls.Add(this.excelfilepath);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "RDC File Upload";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox excelsheetname;
        private System.Windows.Forms.TextBox excelfilepath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFirmNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBatchType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBatchSubmittedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBatchCompletedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBatchStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTrackingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReportingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryAddressLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryProvince;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryPostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInquiryNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDecision;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtReasonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDecisioningNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEntityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtListEntryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEventList;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMatchScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCVIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUploadDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUploadedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMachineName;
    }
}

