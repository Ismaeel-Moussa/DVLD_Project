using DVLD_Business;
using DVLD_FullRealProject.Applications.Local_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsTestTypes;

namespace DVLD_FullRealProject
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        DataView _DataView;

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void _RefreshLocalApplicationsList()
        {
            DataTable LocalApplicationTable = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            _DataView = LocalApplicationTable.DefaultView;

            dgvLocalDrivingLicenseApplications.DataSource = _DataView;
            dgvLocalDrivingLicenseApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocalDrivingLicenseApplications.Columns["L.D.LAppID"].Width = 150;
            dgvLocalDrivingLicenseApplications.Columns["Driving Class"].Width = 250;
            dgvLocalDrivingLicenseApplications.Columns["National No."].Width = 90;
            dgvLocalDrivingLicenseApplications.Columns["Full Name"].Width = 250;


            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {

            _RefreshLocalApplicationsList();
            cbFilterBy.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;

            foreach (DataColumn Column in _DataView.Table.Columns)
            {
                if (Column.ColumnName == "Driving Class" || Column.ColumnName == "Application Date")
                {
                    continue;
                }
                cbFilterBy.Items.Add(Column.ColumnName);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = cbFilterBy.Text;
            string ToSearch = txtFilterBy.Text.Trim();

            if (!string.IsNullOrWhiteSpace(ToSearch))
            {
                if (ColumnName == "L.D.LAppID")
                {
                    _DataView.RowFilter = $"[{ColumnName}] = {ToSearch}";
                }
                else
                {
                    _DataView.RowFilter = $"[{ColumnName}] like '%{ToSearch}%'";
                }
            }
            else
            {
                _DataView.RowFilter = string.Empty;
            }

            dgvLocalDrivingLicenseApplications.DataSource = _DataView;

            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void _ResetFilter()
        {
            _DataView.RowFilter = string.Empty;
            dgvLocalDrivingLicenseApplications.DataSource = _DataView;
            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ResetFilter();


            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterBy.Visible = false;
                cbStatus.Visible = false;
                return;
            }

            if (cbFilterBy.SelectedItem.ToString() == "Status")
            {
                cbStatus.Visible = true;
                txtFilterBy.Visible = false;
                return;
            }

            txtFilterBy.Visible = true;
            cbStatus.Visible = false;

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem.ToString() == "All")
            {
                _DataView.RowFilter = string.Empty;


            }

            if (cbStatus.SelectedItem.ToString() == "New")
            {
                _DataView.RowFilter = "[Status] = 'New'";

            }


            if (cbStatus.SelectedItem.ToString() == "Cancelled")
            {
                _DataView.RowFilter = "[Status] = 'Cancelled'";
            }


            if (cbStatus.SelectedItem.ToString() == "Completed")
            {
                _DataView.RowFilter = "[Status] = 'Completed'";
            }


            dgvLocalDrivingLicenseApplications.DataSource = _DataView;
            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
            _RefreshLocalApplicationsList();
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    _RefreshLocalApplicationsList();

                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicesnseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLocalApplicationsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLocalApplicationsList();

                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _ScheduleTest(clsTestTypes.enTestType TestTypeID)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            Form frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, TestTypeID);
            frm.ShowDialog();
            _RefreshLocalApplicationsList();

        }

        private void ScheduleVistionTestTSMI_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.VisionTest);
        }

        private void ScheduleWrittenTestTSMI_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.WrittenTest);
        }

        private void ScheduleStreetTestTSMI_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.StreetTest);
        }

        private void cmtIssueLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmIssueDriverLicenseForTheFirstTime((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLocalApplicationsList();
        }

        private void cmtShowLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            int LicenseID = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                Form frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmtShowLicenseHistory_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications LocalApp = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            clsApplications Application = clsApplications.FindBaseApplication(LocalApp.ApplicationID);

            Form frm = new frmShowPersonLicenseHistory(Application.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm =
            new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshLocalApplicationsList();


        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            

            EditApplicationTSMI.Enabled = !LicenseExists && LocalDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New;

            DeleteApplicationTSMI.Enabled = LocalDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New;

            CancelApplicationTSMI.Enabled = LocalDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New;

            IssueLicenseFirstTimeTSMI.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            ScheduleTestsTSMI.Enabled = !LicenseExists;

            ShowLicenseTSMI.Enabled = LicenseExists;



            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

            ScheduleTestsTSMI.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) &&
                 LocalDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New;

            if (ScheduleTestsTSMI.Enabled)
            {
                ScheduleVistionTestTSMI.Enabled = !PassedVisionTest;

                ScheduleWrittenTestTSMI.Enabled = PassedVisionTest && !PassedWrittenTest;

                ScheduleStreetTestTSMI.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }

        }


    }
}
