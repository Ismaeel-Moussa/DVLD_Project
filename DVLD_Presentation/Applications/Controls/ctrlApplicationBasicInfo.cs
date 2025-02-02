﻿using DVLD_Business;
using DVLD_FullRealProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_FullRealProject.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplications _Application;

        private int _ApplicationID = -1;

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }


        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;
            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }


        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplications.FindBaseApplication(ApplicationID);

            if(_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTitle;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.PersonInfo.FullName;
            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmPersonDetails(_Application.ApplicantPersonID);
            frm.ShowDialog();
            LoadApplicationInfo(_ApplicationID);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
