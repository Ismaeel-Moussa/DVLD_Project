using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_FullRealProject.International_License_Applications
{
    public partial class frmListInternationalLicenseApplications : Form
    {
        DataView _DataView;
        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void _RefreshListInternationalLicenses()
        {
            DataTable InternationalLicensesTable = clsInternationalLicenses.GetAllInternationalLicenses();
            _DataView = InternationalLicensesTable.DefaultView;
            dgvAllInternationalDLA.DataSource = _DataView;
            dgvAllInternationalDLA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblNumberOfRecords.Text = _DataView.Count.ToString();

        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            
            _RefreshListInternationalLicenses();
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = cbFilterBy.Text;
            string ToSearch = txtFilterBy.Text.Trim();

            if (!string.IsNullOrWhiteSpace(ToSearch))
            {               
                _DataView.RowFilter = $"[{ColumnName}] = {ToSearch}";                
            }
            else
            {
                _DataView.RowFilter = string.Empty;
            }

            dgvAllInternationalDLA.DataSource = _DataView;

            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void _ResetFilter()
        {
            _DataView.RowFilter = string.Empty;
            dgvAllInternationalDLA.DataSource = _DataView;
            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ResetFilter();

            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = false;
                return;
            }

            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
                return;
            }

            txtFilterBy.Text = "";
            txtFilterBy.Visible = true;
            txtFilterBy.Focus();
            cbIsActive.Visible = false;
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.Text)
            {
                case "Yes":
                    _DataView.RowFilter = "[Is Active] = 1";
                    break;

                case "No":
                    _DataView.RowFilter = "[Is Active] = 0";
                    break;

                default:
                    _DataView.RowFilter = string.Empty;
                    break;

            }

            dgvAllInternationalDLA.DataSource = _DataView;
            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            _RefreshListInternationalLicenses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPersonDetails(clsDrivers.FindByDriverID((int)dgvAllInternationalDLA.CurrentRow.Cells["Driver ID"].Value).PersonID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmInternationalLicenseInfo((int)dgvAllInternationalDLA.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cmtShowLicenseHistory_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(clsDrivers.FindByDriverID((int)dgvAllInternationalDLA.CurrentRow.Cells["Driver ID"].Value).PersonID);
            frm.ShowDialog();
        }


    }
}
