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
    public partial class frmScheduleTest : Form
    {

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();

            ctrlScheduleTest1.TestTypeID = TestTypeID;
            ctrlScheduleTest1.LoadInfo(LocalDrivingLicenseApplicationID, AppointmentID);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}
