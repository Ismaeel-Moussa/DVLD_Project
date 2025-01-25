using DVLD_Business;
using DVLD_FullRealProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD_FullRealProject
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DelegateReturnPersonID(object sender, int PersonID);

        public event DelegateReturnPersonID ReturnPersonID;

        public enum enMode { AddNew =0,Update = 1};
        public enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _PersonID = -1;
        private clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _Mode = enMode.AddNew;
            
        }

        public frmAddUpdatePerson(int personID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _PersonID = personID;
            _Mode = enMode.Update;

        }

        private void _FillCountriesInComobox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _ResetDefualtValues()
        {
            _FillCountriesInComobox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblMode.Text = "Update Person";
            }

            llRemove.Visible = (pbDefaultPicture.ImageLocation != null);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblPersonID.Text = _PersonID.ToString();
            txtNationalNo.Text = _Person.NationalNo;  
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;


            if (_Person.ImagePath != "")
            {
                pbDefaultPicture.ImageLocation = _Person.ImagePath;
            }

            llRemove.Visible = (_Person.ImagePath != "");


        }

        private bool _HandlePersonImage()
        {
            //_Person.ImagePath contains the old image , we check if it changed then we copy the new image

            if(_Person.ImagePath != pbDefaultPicture.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);

                    }catch (IOException ex)
                    {
                        clsLogger.Log(ex);
                    }
                }


                if (pbDefaultPicture.ImageLocation != null)
                {
                    // then we copy the new image to the image folder after we rename it 
                    string SourceImageFile = pbDefaultPicture.ImageLocation.ToString();

                    if(clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbDefaultPicture.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            }

            return true;
        }

        private void _SaveData()
        {   

            if(!_HandlePersonImage())
            {
                return;
            }

            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;

            if(rbMale.Checked)
                _Person.Gendor = (byte)enGendor.Male;
            else
                _Person.Gendor = (byte)enGendor.Female; ;

            if (pbDefaultPicture.ImageLocation != null)
                _Person.ImagePath = pbDefaultPicture.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully.");

                _Mode = enMode.Update;
                lblMode.Text = "Update Person";
                lblPersonID.Text = _Person.PersonID.ToString();

                // Trigger the event to send PersonID to the caller form.             
                ReturnPersonID?.Invoke(this, _Person.PersonID);

            }
            else
            {
                MessageBox.Show("Error: Data is not Saved Successfully.");
            }

        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
            
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _SaveData();
            }
            else
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "This field is required.");
            }
            else
            {
                if (clsPerson.isPersonExist(txtNationalNo.Text.Trim()) && _Person.NationalNo != txtNationalNo.Text.Trim())
                {
                    errorProvider1.SetError(txtNationalNo, "This NationalNo is Exist");
                }
                else
                {
                    errorProvider1.SetError(txtNationalNo, "");

                }
            }


        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {


            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
              

                if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
                {
                    errorProvider1.SetError(txtEmail, "Invalid Email Format");
                }
                else
                {
                    errorProvider1.SetError(txtEmail, "");
                }

            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }


        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbDefaultPicture.ImageLocation == null)
                pbDefaultPicture.Image = Properties.Resources.man;

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbDefaultPicture.ImageLocation == null)
                pbDefaultPicture.Image = Properties.Resources.woman;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;

                pbDefaultPicture.Load(selectedFilePath);

                llRemove.Visible = true;


            }


        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbDefaultPicture.ImageLocation = null;

            if (rbMale.Checked)
                pbDefaultPicture.Image = Properties.Resources.man;
            else
                pbDefaultPicture.Image = Properties.Resources.woman;

            llRemove.Visible = false;
            

        }
    }
}
