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
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _UserID = UserID;
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void _SaveData()
        {
            _User.Password = txtNewPassword.Text;
            if(_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                _SaveData();
            }
            else
            {
                MessageBox.Show("Please correct the highlighted errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(txtCurrentPassword, "Current Password is required!");
            }
            else
            {
                if (txtCurrentPassword.Text != _User.Password)
                {
                    errorProvider1.SetError(txtCurrentPassword, "Does not match the current password!");
                }
                else
                {
                    errorProvider1.SetError(txtCurrentPassword, "");

                }
            }

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "New Password is required!");
            }
            else
            {
                if (txtNewPassword.Text == txtCurrentPassword.Text)
                {
                    errorProvider1.SetError(txtNewPassword, "It is match the Current Password Try another Password!");
                }
                else
                {
                    errorProvider1.SetError(txtNewPassword, "");

                }
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is required!");
            }
            else
            {
                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    errorProvider1.SetError(txtConfirmPassword, "Confirmation does not match the New Password!");
                }
                else
                {
                    errorProvider1.SetError(txtConfirmPassword, "");

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
