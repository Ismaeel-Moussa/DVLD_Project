using System;
using System.Configuration;

namespace DVLD_DataAccess
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

    }
}

//"Server=.;Database=DVLD;User Id=sa;Password=sa123456;";