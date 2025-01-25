using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplicationTypes
    {

        public int ApplicationTypeID { get; set; }
        public string ApplicationTitle {  get; set; }
        public float ApplicationFees {  get; set; }


       private clsApplicationTypes(int ApplicationTypeID,string ApplicationTitle,float ApplicationFees) 
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTitle = ApplicationTitle;
            this.ApplicationFees = ApplicationFees;

        }

        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string ApplicationTitle = ""; float ApplicationFees = 0;

            if(clsApplicationTypesData.GetApplicationTypeByID(ApplicationTypeID,ref ApplicationTitle,ref ApplicationFees))
            {
                return new clsApplicationTypes(ApplicationTypeID,ApplicationTitle,ApplicationFees);
            }
            else
            {
                return null;
            }
        }
        public bool Update()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTitle, this.ApplicationFees);
        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

    }
}
