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
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void _RefreshTestTypesList()
        {
            DataTable TestTypesTable = clsTestTypes.GetAllTestTypes();

            TestTypesTable.Columns["TestTypeID"].ColumnName = "ID";
            TestTypesTable.Columns["TestTypeTitle"].ColumnName = "Title";
            TestTypesTable.Columns["TestTypeDescription"].ColumnName = "Description";
            TestTypesTable.Columns["TestTypeFees"].ColumnName = "Fees";


            DataView TestTypesView = TestTypesTable.DefaultView;

            dgvAllTestTypes.DataSource = TestTypesView;

            dgvAllTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllTestTypes.Columns["ID"].Width = 50;
            dgvAllTestTypes.Columns["Title"].Width = 70;
            dgvAllTestTypes.Columns["Description"].Width = 200;
            dgvAllTestTypes.Columns["Fees"].Width = 90;

            lblNumberOfRecords.Text = TestTypesView.Count.ToString();
        }


        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frm = new frmEditTestType((clsTestTypes.enTestType)dgvAllTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypesList();

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();

        }
    }
}
