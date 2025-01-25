using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestTypes
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2 , StreetTest  = 3 };
        
        public enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }


        private clsTestTypes(enTestType TestTypeID, string TestTypeTitle,string TestTypeDescription, float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

        }

        public static clsTestTypes Find(enTestType TestTypeID)
        {
            string TestTypeTitle = "" , TestTypeDescription = ""; float TestTypeFees = 0;

            if (clsTestTypesData.GetTestTypeByID((int)TestTypeID, ref TestTypeTitle,ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }
        }

        public bool Update()
        {
            return clsTestTypesData.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle,this.TestTypeDescription, this.TestTypeFees);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }
    }
}
