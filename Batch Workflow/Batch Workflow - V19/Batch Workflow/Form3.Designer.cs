namespace Batch_Workflow
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sourcebu_project = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.entityid_project = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.update_project = new System.Windows.Forms.Button();
            this.batchid_project = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.searchby_batchid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchby_pagenumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.batchid_associatename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pagenumber_to = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.update_associatename = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.associatename = new System.Windows.Forms.ComboBox();
            this.pagenumber_from = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.adminlevel = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagenumber_to)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagenumber_from)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Home Page";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Controls.Add(this.searchby_batchid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.searchby_pagenumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1873, 891);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Workflow";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sourcebu_project);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(1475, 33);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(379, 155);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Update Project";
            // 
            // sourcebu_project
            // 
            this.sourcebu_project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourcebu_project.FormattingEnabled = true;
            this.sourcebu_project.Location = new System.Drawing.Point(97, 40);
            this.sourcebu_project.Name = "sourcebu_project";
            this.sourcebu_project.Size = new System.Drawing.Size(265, 28);
            this.sourcebu_project.TabIndex = 7;
            this.sourcebu_project.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sourcebu_project_KeyDown);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(58, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 43);
            this.button3.TabIndex = 6;
            this.button3.Text = "Update as Project";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "SourceBU";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.entityid_project);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(1216, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 155);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Update Project";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(25, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 43);
            this.button2.TabIndex = 6;
            this.button2.Text = "Update as Project";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // entityid_project
            // 
            this.entityid_project.Location = new System.Drawing.Point(85, 40);
            this.entityid_project.Name = "entityid_project";
            this.entityid_project.Size = new System.Drawing.Size(131, 26);
            this.entityid_project.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "EntityID";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.update_project);
            this.groupBox3.Controls.Add(this.batchid_project);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(941, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 155);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update Project";
            // 
            // update_project
            // 
            this.update_project.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_project.Location = new System.Drawing.Point(40, 82);
            this.update_project.Name = "update_project";
            this.update_project.Size = new System.Drawing.Size(185, 43);
            this.update_project.TabIndex = 6;
            this.update_project.Text = "Update as Project";
            this.update_project.UseVisualStyleBackColor = true;
            this.update_project.Click += new System.EventHandler(this.update_project_Click);
            // 
            // batchid_project
            // 
            this.batchid_project.Location = new System.Drawing.Point(85, 40);
            this.batchid_project.Name = "batchid_project";
            this.batchid_project.Size = new System.Drawing.Size(131, 26);
            this.batchid_project.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "BatchID";
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(131, 25);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(143, 38);
            this.reset.TabIndex = 6;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // searchby_batchid
            // 
            this.searchby_batchid.Location = new System.Drawing.Point(198, 87);
            this.searchby_batchid.Name = "searchby_batchid";
            this.searchby_batchid.Size = new System.Drawing.Size(240, 26);
            this.searchby_batchid.TabIndex = 11;
            this.searchby_batchid.TextChanged += new System.EventHandler(this.searchby_batchid_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search by Batch ID";
            // 
            // searchby_pagenumber
            // 
            this.searchby_pagenumber.Location = new System.Drawing.Point(46, 87);
            this.searchby_pagenumber.Name = "searchby_pagenumber";
            this.searchby_pagenumber.Size = new System.Drawing.Size(104, 26);
            this.searchby_pagenumber.TabIndex = 9;
            this.searchby_pagenumber.TextChanged += new System.EventHandler(this.searchby_pagenumber_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Search by Page number";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.batchid_associatename);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pagenumber_to);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.update_associatename);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.associatename);
            this.groupBox2.Controls.Add(this.pagenumber_from);
            this.groupBox2.Location = new System.Drawing.Point(451, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 163);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update Associate Names";
            // 
            // batchid_associatename
            // 
            this.batchid_associatename.Location = new System.Drawing.Point(168, 88);
            this.batchid_associatename.Name = "batchid_associatename";
            this.batchid_associatename.Size = new System.Drawing.Size(180, 26);
            this.batchid_associatename.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Batch ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "to";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "from";
            // 
            // pagenumber_to
            // 
            this.pagenumber_to.Location = new System.Drawing.Point(246, 49);
            this.pagenumber_to.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.pagenumber_to.Name = "pagenumber_to";
            this.pagenumber_to.Size = new System.Drawing.Size(73, 26);
            this.pagenumber_to.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Page Number";
            // 
            // update_associatename
            // 
            this.update_associatename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_associatename.Location = new System.Drawing.Point(364, 49);
            this.update_associatename.Name = "update_associatename";
            this.update_associatename.Size = new System.Drawing.Size(96, 43);
            this.update_associatename.TabIndex = 5;
            this.update_associatename.Text = "Update";
            this.update_associatename.UseVisualStyleBackColor = true;
            this.update_associatename.Click += new System.EventHandler(this.update_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Associate Name";
            // 
            // associatename
            // 
            this.associatename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.associatename.FormattingEnabled = true;
            this.associatename.Location = new System.Drawing.Point(168, 123);
            this.associatename.Name = "associatename";
            this.associatename.Size = new System.Drawing.Size(198, 28);
            this.associatename.TabIndex = 4;
            // 
            // pagenumber_from
            // 
            this.pagenumber_from.Location = new System.Drawing.Point(168, 49);
            this.pagenumber_from.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.pagenumber_from.Name = "pagenumber_from";
            this.pagenumber_from.Size = new System.Drawing.Size(72, 26);
            this.pagenumber_from.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 204);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1833, 659);
            this.dataGridView1.TabIndex = 0;
            // 
            // adminlevel
            // 
            this.adminlevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adminlevel.FormattingEnabled = true;
            this.adminlevel.Location = new System.Drawing.Point(423, 12);
            this.adminlevel.Name = "adminlevel";
            this.adminlevel.Size = new System.Drawing.Size(156, 28);
            this.adminlevel.TabIndex = 2;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 963);
            this.Controls.Add(this.adminlevel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.Text = "Allocation Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagenumber_to)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagenumber_from)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox associatename;
        private System.Windows.Forms.NumericUpDown pagenumber_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button update_associatename;
        private System.Windows.Forms.ComboBox adminlevel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.TextBox searchby_pagenumber;
        private System.Windows.Forms.TextBox searchby_batchid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown pagenumber_to;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox batchid_associatename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button update_project;
        private System.Windows.Forms.TextBox batchid_project;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox entityid_project;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox sourcebu_project;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
    }
}