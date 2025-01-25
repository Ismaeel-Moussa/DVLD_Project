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
using System.IO;
using static System.Windows.Forms.LinkLabel;
using DVLD_FullRealProject.Global_Classes;

namespace DVLD_FullRealProject
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
           
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsUser User = clsUser.FindByUserName(txtUserName.Text.Trim());

            if (User == null)
            {
                MessageBox.Show("Invalid UserName","Wrong Credentials",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            if (!clsHashing.VerifyPassword(txtPassword.Text, User.Password))
            {
                MessageBox.Show("Invalid Password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }  

            if (!User.isActive)
            {
                MessageBox.Show("Your Account is deactivated please contact your admin ", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (chkRememberMe.Checked)
                clsCredentialManager.RememberUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            else
                clsCredentialManager.RememberUserNameAndPassword("", "");


            clsGlobal.CurrentUser = User;
            this.Hide();
            Form frm = new frmMain(this);
            frm.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";


            if(clsCredentialManager.GetStoredCredentials(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
