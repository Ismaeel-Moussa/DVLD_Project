using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLD_FullRealProject.Classes;

namespace DVLD_FullRealProject
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;
        private clsPerson _Person;

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        public ctrlInternationalLicenseInfo()
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

        public void LoadInfo(int InternationalLicenseID)
        {
             clsInternationalLicenses InternationalLicense = clsInternationalLicenses.Find(InternationalLicenseID);
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;

            if (InternationalLicense == null) 
            {
                MessageBox.Show("Could not find International License ID = " + _InternationalLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;

            }

            _Person = clsPerson.Find(InternationalLicense.DriverInfo.PersonID);

            lblName.Text = _Person.FullName;
            lblIntLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblIssueDate.Text = clsFormat.DateToShort(InternationalLicense.IssueDate);
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lblDriverID.Text = InternationalLicense.DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(InternationalLicense.ExpirationDate);
            _LoadPersonImage();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
               
        }
    }
}
