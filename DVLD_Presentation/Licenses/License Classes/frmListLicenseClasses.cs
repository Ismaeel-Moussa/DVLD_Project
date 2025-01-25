using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;



namespace DVLD_FullRealProject
{
    public partial class frmListLicenseClasses : Form
    {
        public frmListLicenseClasses()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void _RefreshLicenseClassesList()
        {
            DataTable LicenseClassesTable = clsLicenseClasses.GetAllLicenseClasses();

            LicenseClassesTable.Columns["LicenseClassID"].ColumnName = "ID";
            LicenseClassesTable.Columns["ClassName"].ColumnName = "Name";
            LicenseClassesTable.Columns["ClassDescription"].ColumnName = "Description";
            LicenseClassesTable.Columns["ClassFees"].ColumnName = "Fees";  
            LicenseClassesTable.Columns["MinimumAllowedAge"].ColumnName = "Min Age";  
            LicenseClassesTable.Columns["DefaultValidityLength"].ColumnName = "Validity Length";  


            DataView LicenseClassesView = LicenseClassesTable.DefaultView;

            dgvAllLicenseClasses.DataSource = LicenseClassesView;

            dgvAllLicenseClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllLicenseClasses.Columns["ID"].Width = 50;
            dgvAllLicenseClasses.Columns["Name"].Width = 105;
            dgvAllLicenseClasses.Columns["Description"].Width = 120;
            dgvAllLicenseClasses.Columns["Min Age"].Width = 50;  
            dgvAllLicenseClasses.Columns["Validity Length"].Width = 50;
            dgvAllLicenseClasses.Columns["Fees"].Width = 80;

            lblNumberOfRecords.Text = LicenseClassesView.Count.ToString();
        }

        private void frmManageLicenseClasses_Load(object sender, EventArgs e)
        {
            _RefreshLicenseClassesList();
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmEditLicenseClass((int)dgvAllLicenseClasses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLicenseClassesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
