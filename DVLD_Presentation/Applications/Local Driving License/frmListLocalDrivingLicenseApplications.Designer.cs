namespace DVLD_FullRealProject
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowApplicationDetailsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.EditApplicationTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplicationTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelApplicationTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ScheduleTestsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleVistionTestTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleWrittenTestTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleStreetTestTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.IssueLicenseFirstTimeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLicenseTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLicenseHistoryTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(406, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(413, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Local Driving License Applications";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblNumberOfRecords.Location = new System.Drawing.Point(124, 644);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(0, 17);
            this.lblNumberOfRecords.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(31, 644);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "# Records:";
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(293, 280);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(174, 20);
            this.txtFilterBy.TabIndex = 18;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // cmsApplications
            // 
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowApplicationDetailsTSMI,
            this.toolStripSeparator1,
            this.EditApplicationTSMI,
            this.DeleteApplicationTSMI,
            this.toolStripSeparator2,
            this.CancelApplicationTSMI,
            this.toolStripSeparator4,
            this.ScheduleTestsTSMI,
            this.toolStripSeparator3,
            this.IssueLicenseFirstTimeTSMI,
            this.toolStripSeparator5,
            this.ShowLicenseTSMI,
            this.toolStripSeparator6,
            this.ShowLicenseHistoryTSMI});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(262, 344);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // ShowApplicationDetailsTSMI
            // 
            this.ShowApplicationDetailsTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.list;
            this.ShowApplicationDetailsTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowApplicationDetailsTSMI.Name = "ShowApplicationDetailsTSMI";
            this.ShowApplicationDetailsTSMI.Size = new System.Drawing.Size(261, 38);
            this.ShowApplicationDetailsTSMI.Text = "Show Application Details";
            this.ShowApplicationDetailsTSMI.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // EditApplicationTSMI
            // 
            this.EditApplicationTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.EditApplication;
            this.EditApplicationTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditApplicationTSMI.Name = "EditApplicationTSMI";
            this.EditApplicationTSMI.Size = new System.Drawing.Size(261, 38);
            this.EditApplicationTSMI.Text = "Edit Application";
            this.EditApplicationTSMI.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // DeleteApplicationTSMI
            // 
            this.DeleteApplicationTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.DeleteApplication;
            this.DeleteApplicationTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteApplicationTSMI.Name = "DeleteApplicationTSMI";
            this.DeleteApplicationTSMI.Size = new System.Drawing.Size(261, 38);
            this.DeleteApplicationTSMI.Text = "Delete Application";
            this.DeleteApplicationTSMI.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // CancelApplicationTSMI
            // 
            this.CancelApplicationTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.CancelApplication;
            this.CancelApplicationTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelApplicationTSMI.Name = "CancelApplicationTSMI";
            this.CancelApplicationTSMI.Size = new System.Drawing.Size(261, 38);
            this.CancelApplicationTSMI.Text = "Cancel Application";
            this.CancelApplicationTSMI.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(258, 6);
            // 
            // ScheduleTestsTSMI
            // 
            this.ScheduleTestsTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScheduleVistionTestTSMI,
            this.ScheduleWrittenTestTSMI,
            this.ScheduleStreetTestTSMI});
            this.ScheduleTestsTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.SechduleTests;
            this.ScheduleTestsTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleTestsTSMI.Name = "ScheduleTestsTSMI";
            this.ScheduleTestsTSMI.Size = new System.Drawing.Size(261, 38);
            this.ScheduleTestsTSMI.Text = "Schedule Tests";
            // 
            // ScheduleVistionTestTSMI
            // 
            this.ScheduleVistionTestTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.VisionTest;
            this.ScheduleVistionTestTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleVistionTestTSMI.Name = "ScheduleVistionTestTSMI";
            this.ScheduleVistionTestTSMI.Size = new System.Drawing.Size(203, 38);
            this.ScheduleVistionTestTSMI.Text = "Schedule Vision Test";
            this.ScheduleVistionTestTSMI.Click += new System.EventHandler(this.ScheduleVistionTestTSMI_Click);
            // 
            // ScheduleWrittenTestTSMI
            // 
            this.ScheduleWrittenTestTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.WrittenTest;
            this.ScheduleWrittenTestTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleWrittenTestTSMI.Name = "ScheduleWrittenTestTSMI";
            this.ScheduleWrittenTestTSMI.Size = new System.Drawing.Size(203, 38);
            this.ScheduleWrittenTestTSMI.Text = "Schedule Written Test";
            this.ScheduleWrittenTestTSMI.Click += new System.EventHandler(this.ScheduleWrittenTestTSMI_Click);
            // 
            // ScheduleStreetTestTSMI
            // 
            this.ScheduleStreetTestTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.driving_test;
            this.ScheduleStreetTestTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleStreetTestTSMI.Name = "ScheduleStreetTestTSMI";
            this.ScheduleStreetTestTSMI.Size = new System.Drawing.Size(203, 38);
            this.ScheduleStreetTestTSMI.Text = "Schedule Street Test";
            this.ScheduleStreetTestTSMI.Click += new System.EventHandler(this.ScheduleStreetTestTSMI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(258, 6);
            // 
            // IssueLicenseFirstTimeTSMI
            // 
            this.IssueLicenseFirstTimeTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.IssueDrivingLicense;
            this.IssueLicenseFirstTimeTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IssueLicenseFirstTimeTSMI.Name = "IssueLicenseFirstTimeTSMI";
            this.IssueLicenseFirstTimeTSMI.Size = new System.Drawing.Size(261, 38);
            this.IssueLicenseFirstTimeTSMI.Text = "Issue Driving License (First Time)";
            this.IssueLicenseFirstTimeTSMI.Click += new System.EventHandler(this.cmtIssueLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(258, 6);
            // 
            // ShowLicenseTSMI
            // 
            this.ShowLicenseTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.ShowLicense;
            this.ShowLicenseTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLicenseTSMI.Name = "ShowLicenseTSMI";
            this.ShowLicenseTSMI.Size = new System.Drawing.Size(261, 38);
            this.ShowLicenseTSMI.Text = "Show License";
            this.ShowLicenseTSMI.Click += new System.EventHandler(this.cmtShowLicense_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(258, 6);
            // 
            // ShowLicenseHistoryTSMI
            // 
            this.ShowLicenseHistoryTSMI.Image = global::DVLD_FullRealProject.Properties.Resources.history;
            this.ShowLicenseHistoryTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLicenseHistoryTSMI.Name = "ShowLicenseHistoryTSMI";
            this.ShowLicenseHistoryTSMI.Size = new System.Drawing.Size(261, 38);
            this.ShowLicenseHistoryTSMI.Text = "Show Person License History";
            this.ShowLicenseHistoryTSMI.Click += new System.EventHandler(this.cmtShowLicenseHistory_Click);
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsApplications;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(12, 306);
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1210, 317);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 17;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None"});
            this.cbFilterBy.Location = new System.Drawing.Point(114, 279);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(174, 21);
            this.cbFilterBy.TabIndex = 16;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(31, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Filter By:";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(294, 280);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(111, 21);
            this.cbStatus.TabIndex = 25;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnClose.Image = global::DVLD_FullRealProject.Properties.Resources.IconClose;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.Location = new System.Drawing.Point(1175, 629);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 40);
            this.btnClose.TabIndex = 24;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_FullRealProject.Properties.Resources.LocalDrivingLicenseApplications;
            this.pictureBox1.Location = new System.Drawing.Point(522, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnAddNewApplication.Image = global::DVLD_FullRealProject.Properties.Resources.add_file;
            this.btnAddNewApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1151, 226);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(71, 75);
            this.btnAddNewApplication.TabIndex = 22;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 677);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label1);
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.Text = "List Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplications_Load);
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicationTSMI;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem EditApplicationTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ShowApplicationDetailsTSMI;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplicationTSMI;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ToolStripMenuItem ScheduleTestsTSMI;
        private System.Windows.Forms.ToolStripMenuItem ScheduleVistionTestTSMI;
        private System.Windows.Forms.ToolStripMenuItem ScheduleWrittenTestTSMI;
        private System.Windows.Forms.ToolStripMenuItem ScheduleStreetTestTSMI;
        private System.Windows.Forms.ToolStripMenuItem IssueLicenseFirstTimeTSMI;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseTSMI;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseHistoryTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}