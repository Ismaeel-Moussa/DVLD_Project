using System;
using System.Data;
using DVLD_Buisness;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClassID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public int CreatedByUserID { set; get; }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public bool IsDetained
        {
            get { return clsDetainedLicenses.IsLicenseDetained(this.LicenseID); }
        }

        public clsDrivers DriverInfo;

        public clsLicenseClasses LicensesClassInfo;

        public clsDetainedLicenses DetainedInfo;




        public clsLicenses()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsLicenses(int LicensesID, int ApplicationID, int DriverID, int LicensesClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)

        {
            this.LicenseID = LicensesID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicensesClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDrivers.FindByDriverID(this.DriverID);
            this.LicensesClassInfo = clsLicenseClasses.Find(this.LicenseClassID);
            this.DetainedInfo = clsDetainedLicenses.FindByLicenseID(this.LicenseID);

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicensesData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicensesData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClassID,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static clsLicenses Find(int LicensesID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicensesClassID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;
            if (clsLicensesData.GetLicenseInfoByID(LicensesID, ref ApplicationID, ref DriverID, ref LicensesClassID,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicenses(LicensesID, ApplicationID, DriverID, LicensesClassID,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicensesClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicensesClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicensesClassID)
        {

            return clsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicensesClassID);

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicensesData.GetDriverLicenses(DriverID);
        }

        public Boolean IsLicensesExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicensesData.DeactivateLicense(this.LicenseID));
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicenses detainedLicenses = new clsDetainedLicenses();
            detainedLicenses.LicenseID = this.LicenseID;
            detainedLicenses.DetainDate = DateTime.Now;
            detainedLicenses.FineFees = Convert.ToSingle(FineFees);
            detainedLicenses.CreatedByUserID = CreatedByUserID;

            if (!detainedLicenses.Save())
            {

                return -1;
            }

            return detainedLicenses.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;


            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

        }

        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = clsApplications.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicenses = new clsLicenses();

            NewLicenses.ApplicationID = Application.ApplicationID;
            NewLicenses.DriverID = this.DriverID;
            NewLicenses.LicenseClassID = this.LicenseClassID;
            NewLicenses.IssueDate = DateTime.Now;
            NewLicenses.ExpirationDate = DateTime.Now.AddYears(this.LicensesClassInfo.DefaultValidityLength);
            NewLicenses.Notes = Notes;
            NewLicenses.PaidFees = this.LicensesClassInfo.ClassFees;
            NewLicenses.IsActive = true;
            NewLicenses.IssueReason = clsLicenses.enIssueReason.Renew;
            NewLicenses.CreatedByUserID = CreatedByUserID;


            if (!NewLicenses.Save())
            {
                return null;
            }

            //we need to deactivate the old Licenses.
            DeactivateCurrentLicense();

            return NewLicenses;
        }

        public clsLicenses Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                clsApplications.enApplicationType.ReplaceDamagedDrivingLicense :
                clsApplications.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.Find((int)Application.ApplicationTypeID).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicenses = new clsLicenses();

            NewLicenses.ApplicationID = Application.ApplicationID;
            NewLicenses.DriverID = this.DriverID;
            NewLicenses.LicenseClassID = this.LicenseClassID;
            NewLicenses.IssueDate = DateTime.Now;
            NewLicenses.ExpirationDate = this.ExpirationDate;
            NewLicenses.Notes = this.Notes;
            NewLicenses.PaidFees = 0;// no fees for the Licenses because it's a replacement.
            NewLicenses.IsActive = true;
            NewLicenses.IssueReason = IssueReason;
            NewLicenses.CreatedByUserID = CreatedByUserID;



            if (!NewLicenses.Save())
            {
                return null;
            }

            //we need to deactivate the old Licenses.
            DeactivateCurrentLicense();

            return NewLicenses;
        }
    }
}
