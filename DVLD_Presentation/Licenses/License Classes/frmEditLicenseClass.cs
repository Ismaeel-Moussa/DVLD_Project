using DVLD_Business;
using DVLD_FullRealProject.Classes;
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
    public partial class frmEditLicenseClass : Form
    {
        private int _LicenseClassID;

        private clsLicenseClasses _LicenseClass;
        public frmEditLicenseClass(int LicenseClassID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _LicenseClassID = LicenseClassID;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateLicenseClass_Load(object sender, EventArgs e)
        {
             _LicenseClass = clsLicenseClasses.Find(_LicenseClassID);

            if (_LicenseClass != null)
            {
                lblID.Text = _LicenseClass.LicenseClassID.ToString();
                txtName.Text = _LicenseClass.ClassName;
                txtDescription.Text = _LicenseClass.ClassDescription;
                txtMinAge.Text = _LicenseClass.MinimumAllowedAge.ToString();
                txtValidityLength.Text = _LicenseClass.DefaultValidityLength.ToString();
                txtFees.Text = _LicenseClass.ClassFees.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid !", "Not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(_LicenseClass != null) 
            {

                _LicenseClass.ClassName = txtName.Text.Trim();
                _LicenseClass.ClassDescription = txtDescription.Text.Trim();
                _LicenseClass.MinimumAllowedAge = byte.Parse(txtMinAge.Text.Trim());
                _LicenseClass.DefaultValidityLength = byte.Parse(txtValidityLength.Text.Trim());
                _LicenseClass.ClassFees = Convert.ToSingle(txtFees.Text.Trim());

                if (_LicenseClass.Update())
                {
                    MessageBox.Show("Updated Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Updated Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "Name cannot be empty!");

            }
            else
            {
                errorProvider1.SetError(txtName, null);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");

            }
            else
            {
                {
                    errorProvider1.SetError(txtDescription, null);
                }
            }
        }

        private void txtMinAge_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMinAge.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMinAge, "MinAge cannot be empty!");

            }
            else
            {
                errorProvider1.SetError(txtMinAge, null);
            }


            if (!clsValidation.ValidateInteger(txtMinAge.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMinAge, "Invalid integer");

            }
            else
            {
                errorProvider1.SetError(txtMinAge, null);
            }
        }

        private void txtValidityLength_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtValidityLength.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtValidityLength, "Validity Length cannot be empty!");

            }
            else
            {
                errorProvider1.SetError(txtValidityLength, null);
            }


            if (!clsValidation.ValidateInteger(txtValidityLength.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtValidityLength, "Invalid integer");

            }
            else
            {
                errorProvider1.SetError(txtValidityLength, null);
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


            if (!clsValidation.IsNumber(txtFees.Text.Trim()))
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
