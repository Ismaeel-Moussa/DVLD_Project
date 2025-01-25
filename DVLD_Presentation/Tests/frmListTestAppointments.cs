using DVLD_Business;
using DVLD_FullRealProject.Properties;
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
    public partial class frmListTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypes.enTestType _TestTypeID;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {

                case clsTestTypes.enTestType.VisionTest:
                    {
                        this.Text = lblTitle.Text = "Vision Test Appointments";
                        pbTestTypeImage.Image = Resources.visionTest256;
                        break;
                    }

                case clsTestTypes.enTestType.WrittenTest:
                    {
                        this.Text = lblTitle.Text = "Written Test Appointments";
                        pbTestTypeImage.Image = Resources.Written256;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        this.Text = lblTitle.Text = "Street Test Appointments";
                        pbTestTypeImage.Image = Resources.Street256;
                        break;
                    }
            }
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

            dgvLicenseTestAppointments.DataSource =
                clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID( _LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (localDrivingLicenseApplication.DoesPassTestType(_TestTypeID))
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Form frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestTypeID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmetnID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            Form frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestTypeID, TestAppointmetnID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestTypeID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
