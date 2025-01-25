using DVLD_Buisness;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_FullRealProject.Classes;

namespace DVLD_FullRealProject
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicenses _License;
        private clsPerson _Person;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicenses SelectedLicenseInfo
        {
            get { return _License; }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
            {
                lblGendor.Text = "Male";
                pbGendorImage.Image = Properties.Resources.man;

            }
            else
            {
                lblGendor.Text = "Female";
                pbGendorImage.Image = Properties.Resources.woman;


            }


            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                if (_Person.Gendor == 0)
                {

                    pbPersonImage.Image = Properties.Resources.man;

                }
                else
                {

                    pbPersonImage.Image = Properties.Resources.woman;
                }
            }
        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicenses.Find(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            _Person = _License.DriverInfo.PersonInfo;

            lblClass.Text = _License.LicensesClassInfo.ClassName;
            lblName.Text = _Person.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _Person.NationalNo.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes != "" ? _License.Notes :"No Notes";
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";

            _LoadPersonImage();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
