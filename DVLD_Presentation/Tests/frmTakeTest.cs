using DVLD_Business;
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

namespace DVLD_FullRealProject
{
    public partial class frmTakeTest : Form
    {

        private int _AppointmentID;
        private clsTestTypes.enTestType _TestTypeID;


        private clsTests _Test;


        public frmTakeTest(int AppointmentID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;
        }



        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadInfo(_AppointmentID);

            if (ctrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else 
                btnSave.Enabled = true;

            if (ctrlScheduledTest1.TestID != -1)
            {
                _Test = clsTests.Find(ctrlScheduledTest1.TestID);

                rbPass.Checked = _Test.TestResult;
                rbFail.Checked = !_Test.TestResult;

                lblUserMessage.Visible = true;
                rbPass.Enabled = false;
                rbFail.Enabled = false;
            }
            else
                _Test = new clsTests();

            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;


            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
