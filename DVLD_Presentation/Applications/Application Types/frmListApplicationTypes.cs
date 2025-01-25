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

namespace DVLD_FullRealProject
{
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void _RefreshApplicationTypesList()
        {
            DataTable ApplicationTypesTable = clsApplicationTypes.GetAllApplicationTypes();

            ApplicationTypesTable.Columns["ApplicationTypeID"].ColumnName = "ID";
            ApplicationTypesTable.Columns["ApplicationTypeTitle"].ColumnName = "Title";
            ApplicationTypesTable.Columns["ApplicationFees"].ColumnName = "Fees";

            dgvAllApplicationTypes.DataSource = ApplicationTypesTable;

            dgvAllApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllApplicationTypes.Columns["ID"].Width = 70;
            dgvAllApplicationTypes.Columns["Title"].Width = 250;
            dgvAllApplicationTypes.Columns["Fees"].Width = 100;

            lblNumberOfRecords.Text = ApplicationTypesTable.Rows.Count.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmEditApplicationType((int)dgvAllApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
