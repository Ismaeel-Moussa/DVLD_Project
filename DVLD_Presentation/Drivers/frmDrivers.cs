using DVLD_Business;
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

namespace DVLD_FullRealProject
{
    public partial class frmDrivers : Form
    {

        DataView _DataView;
        public frmDrivers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void _RefreshDriversList()
        {
            DataTable DriversTable = clsDrivers.GetAllDrivers();

            _DataView = DriversTable.DefaultView;
            dgvAllDrivers.DataSource = _DataView;
            dgvAllDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllDrivers.Columns["Driver ID"].Width = 100;
            dgvAllDrivers.Columns["Person ID"].Width = 100;
            dgvAllDrivers.Columns["National No."].Width = 100;
            dgvAllDrivers.Columns["Full Name"].Width = 220;
            dgvAllDrivers.Columns["Date"].Width = 150;

            dgvAllDrivers.Columns["Active Licenses"].Width = 130;

            lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _RefreshDriversList();

            foreach(DataColumn Column in _DataView.Table.Columns) 
            {
                if(Column.ColumnName == "Date" || Column.ColumnName == "Active Licenses") { continue; }

                cbFilterBy.Items.Add(Column.ColumnName);
            }

        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = cbFilterBy.Text;
            string ToSearch = txtFilterBy.Text.Trim();

            if (!string.IsNullOrWhiteSpace(ToSearch))
            {
                if (ColumnName == "Driver ID" || ColumnName == "Person ID")
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

            dgvAllDrivers.DataSource = _DataView;

            lblNumberOfRecords.Text = _DataView.Count.ToString();

           


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 0) 
            { 
                txtFilterBy.Visible = false;
                return;
            }

            txtFilterBy.Visible = true;

        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);      
            }
        }

        private void ShowApplicationDetailsTSMI_Click(object sender, EventArgs e)
        {
            Form frm = new frmPersonDetails((int)dgvAllDrivers.CurrentRow.Cells["Person ID"].Value);
            frm.ShowDialog();
        }

        private void ShowLicenseHistoryTSMI_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory((int)dgvAllDrivers.CurrentRow.Cells["Person ID"].Value);
            frm.ShowDialog();

        }
    }
}
