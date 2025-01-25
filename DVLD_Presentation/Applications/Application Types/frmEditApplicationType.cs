using DVLD_Business;
using DVLD_FullRealProject.Classes;
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
    public partial class frmEditApplicationType : Form
    {

        private int _ApplicationTypeID;

        private clsApplicationTypes _ApplicationType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid !", "Not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicationTitle = txtTitle.Text.Trim();
            _ApplicationType.ApplicationFees = Convert.ToSingle(txtFees.Text.Trim());


            if (_ApplicationType.Update())
            {
                MessageBox.Show("Updated Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Updated Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
                txtTitle.Text = _ApplicationType.ApplicationTitle;
                txtFees.Text = _ApplicationType.ApplicationFees.ToString();
            }

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");

            }
            else
            {
                {
                    errorProvider1.SetError(txtTitle, null);
                }
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");

            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }


            if (!clsValidation.IsNumber(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number");

            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

        }

    }
}
