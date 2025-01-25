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
using System.IO;

namespace DVLD_FullRealProject
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private DataView _DataView;

        private void _RefreshPeopleList()
        {
                      
            DataTable PeopleTable = clsPerson.GetAllPeople();

            _DataView = PeopleTable.DefaultView;
            dgvAllPeople.DataSource = _DataView;
            dgvAllPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllPeople.Columns["Date of Birth"].Width = 130;
            dgvAllPeople.Columns["Email"].Width = 120;


            lblNumberOfRecords.Text = _DataView.Count.ToString();

        }

        private void _FillColumnsInCombobox()
        {
            foreach (DataColumn column in _DataView.Table.Columns)
            {
                if (column.ColumnName == "Date Of Birth")
                {
                    continue;
                }
                cbFilterBy.Items.Add(column.ColumnName);
            }
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            _FillColumnsInCombobox();

            cbFilterBy.SelectedIndex = 0;
        }

        private void cbPeopleFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cbFilterBy.SelectedIndex != 0);

            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }

        }

        private void txtFilterPeopleBy_TextChanged(object sender, EventArgs e)
        {
                
                string ColumnName = cbFilterBy.SelectedItem.ToString().Trim();
                string ToSearch = txtFilterBy.Text.Trim();

                if (!string.IsNullOrEmpty(ToSearch))
                {
                    if (ColumnName == "Person ID")
                    { 
                        _DataView.RowFilter = $"[{ColumnName}] = {ToSearch}";                       
                    }
                    else
                    {
                        _DataView.RowFilter = $"[{ColumnName}] LIKE '%{ToSearch}%'";
                    }
                }
                else
                {
                    _DataView.RowFilter = string.Empty;

                }

                dgvAllPeople.DataSource = _DataView;
                lblNumberOfRecords.Text = _DataView.Count.ToString();
        }

        private void txtFilterPeopleBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString() == "Person ID")
            {              
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);                 
            }
        }
  
        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvAllPeople.CurrentRow.Cells[0].Value + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (clsPerson.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.","Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPersonDetails((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
