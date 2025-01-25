using DVLD_Buisness;
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

namespace DVLD_FullRealProject.Detained_Licenses
{
    public partial class frmListDetainedLicenses : Form
    {
        DataView _DataView;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void _RefreshListDetainedLicenses()
        {
            DataTable DetainedTable = clsDetainedLicenses.GetAllDetainedLicenses();
            _DataView = DetainedTable.DefaultView;

            dgvAllDetainedLicenses.DataSource = _DataView;

            dgvAllDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllDetainedLicenses.Columns["Full Name"].Width = 220;
            dgvAllDetainedLicenses.Columns["Release App.ID"].Width = 110;

            lblNumberOfRecords.Text = _DataView.Count.ToString();   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshListDetainedLicenses();

            foreach(DataColumn column in _DataView.Table.Columns) 
            {
                if(column.ColumnName == "Detain Date" || column.ColumnName == "Fine Fees" || column.ColumnName == "Release Date") { continue; }
                cbFilterBy.Items.Add(column.ColumnName);
            }

            cbFilterBy.SelectedIndex = 0;
            cbIsReleased.SelectedIndex = 0;
            txtFilterBy.Visible = false;
            cbIsReleased.Visible = false;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ResetFilter();

            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = false;
                cbIsReleased.Visible = false;
                return;
            }

            if(cbFilterBy.Text == "Is Released")
            {
                txtFilterBy.Visible = false;
                cbIsReleased.Visible = true;
                return;
            }

            txtFilterBy.Text = "";
            txtFilterBy.Visible = true;
            txtFilterBy.Focus();
            cbIsReleased.Visible = false;
        }

        private void _ResetFilter()
        {
            _DataView.RowFilter = string.Empty;
            dgvAllDetainedLicenses.DataSource = _DataView;
            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = cbFilterBy.Text;
            string ToSearch = txtFilterBy.Text.Trim();

            if (!string.IsNullOrEmpty(ToSearch))
            {
                if(ColumnName == "Detain ID" || ColumnName == "License ID" || ColumnName == "Release App.ID")
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

            dgvAllDetainedLicenses.DataSource = _DataView;

            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (cbIsReleased.Text)
            {
                case "Yes":
                    _DataView.RowFilter = "[Is Released] = 1";
                    break;

                case "No":
                    _DataView.RowFilter = "[Is Released] = 0";
                    break;

                default:
                    _DataView.RowFilter = string.Empty;
                    break;

            }

            dgvAllDetainedLicenses.DataSource = _DataView;
            lblNumberOfRecords.Text = _DataView.Count.ToString();

        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ColumnName = cbFilterBy.Text;

            if (ColumnName == "Detain ID" || ColumnName == "License ID" || ColumnName == "Release App.ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);               
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshListDetainedLicenses();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            _RefreshListDetainedLicenses();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = dgvAllDetainedLicenses.CurrentRow.Cells["N.No."].Value.ToString();
            Form frm = new frmPersonDetails(clsPerson.Find(NationalNo).PersonID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLicenseInfo((int)dgvAllDetainedLicenses.CurrentRow.Cells["License ID"].Value);
            frm.ShowDialog();

        }

        private void cmtShowLicenseHistory_Click(object sender, EventArgs e)
        {
            string NationalNo = dgvAllDetainedLicenses.CurrentRow.Cells["N.No."].Value.ToString();
            Form frm = new frmShowPersonLicenseHistory(clsPerson.Find(NationalNo).PersonID);
            frm.ShowDialog();
        }

        private void releaseDetainedLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicenseApplication((int)dgvAllDetainedLicenses.CurrentRow.Cells["License ID"].Value);
            frm.ShowDialog();
            _RefreshListDetainedLicenses();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            ReleaseDetainedLicenseTSMT.Enabled = !(bool)dgvAllDetainedLicenses.CurrentRow.Cells["Is Released"].Value;
        }
    }
}
