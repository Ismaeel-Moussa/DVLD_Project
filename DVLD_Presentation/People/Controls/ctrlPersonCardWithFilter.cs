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
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action <int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler (PersonID);
            }
        }

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; } 
            set 
            {
                _ShowAddPerson= value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
   
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFindBy.SelectedIndex = 1;
            txtFindBy.Text =  PersonID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFindBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFindBy.Text)); 
                    break;

                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtFindBy.Text);
                    break;

                default:
                    break;
            }


            if (OnPersonSelected != null && FilterEnabled)
            {
                OnPersonSelected(ctrlPersonCard1.PersonID);
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ReturnPersonID += LoadPersonInfoFromDelegation;
            frm.ShowDialog();
        }

        private void LoadPersonInfoFromDelegation(object sender, int PersonID)
        {
            cbFindBy.SelectedIndex = 1;
            txtFindBy.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);        
        }

        private void txtFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            if (cbFindBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                     
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindBy.Text = "";
            txtFindBy.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                FindNow();
            }
            else
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0;
            txtFindBy.Focus();

        }

        private void txtFindBy_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFindBy.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFindBy, "This field is required!");

            }
            else
            {
                errorProvider1.SetError(txtFindBy, null);
            }
        }

        public void FilterFocus()
        {
            txtFindBy.Focus();

        }
    }
}
