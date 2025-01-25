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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_FullRealProject
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private DataView _DataView; 
        
        private void _RefreshUsersList()
        {
            DataTable UsersTable = clsUser.GetAllUsers();

            _DataView = UsersTable.DefaultView;

            dgvAllUsers.DataSource = _DataView;
            dgvAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllUsers.Columns["Full Name"].Width = 210;
            dgvAllUsers.Columns["UserName"].Width = 110;
            lblNumberOfRecords.Text = _DataView.Count.ToString();

        }

        private void _LoadData()
        {
            _RefreshUsersList();

            foreach (DataColumn column in _DataView.Table.Columns)
            {
                cbFilterBy.Items.Add(column.ColumnName);
            }

            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
            
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cbUsersFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = false;
                return;
            }

            if (cbFilterBy.SelectedItem.ToString() == "Is Active")
            {
                cbIsActive.Visible = true;
                txtFilterBy.Visible = false;
                cbIsActive.SelectedIndex = 0;
                return;
            }

            txtFilterBy.Visible = true;
            txtFilterBy.Focus();
            cbIsActive.Visible = false;



        }

        private void txtFilterUsersBy_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = cbFilterBy.Text;
            string ToSearch = txtFilterBy.Text.Trim();

            if(!string.IsNullOrWhiteSpace(ToSearch))
            {
                if (ColumnName == "User ID" || ColumnName == "Person ID")
                {
                    _DataView.RowFilter = $"[{ColumnName}] = {ToSearch}";
                }
                else
                {
                    _DataView.RowFilter = $"[{ColumnName}] like '%{ToSearch}%'";
                }
            }else
            {
                _DataView.RowFilter = string.Empty;
            }

            dgvAllUsers.DataSource = _DataView;

            lblNumberOfRecords.Text = _DataView.Count.ToString();



        }

        private void txtFilterUsersBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Person ID")
            {       
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);             
            }

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbIsActive.SelectedItem.ToString() == "All")
            {
                _DataView.RowFilter = string.Empty;


            }

            if (cbIsActive.SelectedItem.ToString() == "Yes") 
            {
                _DataView.RowFilter = "[Is Active] = 1";

            }
            

            if (cbIsActive.SelectedItem.ToString() == "No")
            {
                _DataView.RowFilter = "[Is Active] = 0";
            }



            dgvAllUsers.DataSource=_DataView;
            lblNumberOfRecords.Text= _DataView.Count.ToString();

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserDetails((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvAllUsers.CurrentRow.Cells[0].Value + "]",
                                "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {


                    MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
