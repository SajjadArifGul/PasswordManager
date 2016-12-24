using PasswordManager.BLL;
using PasswordManager.Entities;
using PasswordManager.Globals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.App
{
    public partial class MasterPasswordForm : Form
    {
        public User user;

        public MasterPasswordForm(User user)
        {
            InitializeComponent();

            this.user = user;
            user.Settings = new Settings();

            lblMasterNote.Text = Globals.Information.MasterPasswordNote;
            lblMasterNote.ForeColor = Color.FromArgb(255, 214, 0);

            //if (user.Settings.DifferentMaster)
                //LoadMaster(user.Settings.DifferentMaster);
        }

        private void MasterPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void chkEnableMaster_CheckedChanged(object sender, EventArgs e)
        {
            //if (user.Settings.DifferentMaster)
            //{
            //    MessageBox.Show(Globals.Information.MasterPasswordDisabled,
            //        "Warning",
            //         MessageBoxButtons.OK,
            //         MessageBoxIcon.Warning);
            //}

            //user.Settings.DifferentMaster = chkEnableMaster.Checked;
            //LoadMaster(user.Settings.DifferentMaster);
        }

        public void LoadMaster(bool MasterEnabled)
        {
            chkEnableMaster.Checked = MasterEnabled;

            if (MasterEnabled)
            {
                txtMaster.Enabled = true;
                txtNewMaster.Enabled = true;
                txtConfirmMaster.Enabled = true;

                chkHideMaster.Enabled = true;
                chkHideNewMaster.Enabled = true;
                chkHideConfirmMaster.Enabled = true;
            }
            else
            {
                txtMaster.Enabled = false;
                txtNewMaster.Enabled = false;
                txtConfirmMaster.Enabled = false;

                chkHideMaster.Enabled = false;
                chkHideNewMaster.Enabled = false;
                chkHideConfirmMaster.Enabled = false;
            }
        }

        private void chkShowMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtMaster.UseSystemPasswordChar = chkHideMaster.Checked;
        }

        private void chkShowNewMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtNewMaster.UseSystemPasswordChar = chkHideNewMaster.Checked;
        }

        private void chkShowConfirmMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmMaster.UseSystemPasswordChar = chkHideConfirmMaster.Checked;
        }

        Passwords passwords;

        private void btnSave_Click(object sender, EventArgs e)
        {
            ////We have a situation

            ////Condition1
            ////1.1- User has changed his Master Password
            ////1.2- User just enabled the Master Password

            ////Condition2
            ////2.1- User has disabled his Master Pasword

            ////For Condition 1
            //if (user.Settings.DifferentMaster)
            //{
            //    //check if the newly supplied passwords are same or not
            //    if (!passwords.Same(txtNewMaster.Text, txtConfirmMaster.Text) && !Verifier.Text(txtNewMaster.Text) && !Verifier.Text(txtConfirmMaster.Text))
            //    {
            //        lblMassege.Text = "Your New Master Password and Confirm Master Password doesn't match.";
            //        lblMassege.ForeColor = Color.Yellow;
            //    }
            //    else //both new passwords are same. Dont match them again
            //    {
            //        //Condition 1.1
            //        //Check if we already have a Master Password
            //        if (Verifier.Text(user.Settings.Master))
            //        {
            //            //match the current Master Password with the entered Master Password
            //            if (passwords.Same(user.Settings.Master, txtMaster.Text))
            //            {
            //                //change the Master Password
            //                user.Settings.Master = txtNewMaster.Text;
            //                //Proceed with re-encrypting all passwords with new master

            //                //we'll do it here 
            //            }
            //            else //user entered a wrong master password
            //            {
            //                lblMassege.Text = "Your Master Password is incorrect.";
            //                lblMassege.ForeColor = Color.FromArgb(244, 67, 54);
            //            }
            //        }
            //        else //Condition 1.2
            //        //user just enabled the master password
            //        {
            //            //change the Master Password
            //            user.Settings.Master = txtNewMaster.Text;
            //            //Proceed with encrypting all passwords with new master

            //            //we'll do it here 
            //        }
            //    }
            //}
            //else //Condition 2.1
            //{
            //    if (Verifier.Text(txtMaster.Text))
            //    {
            //        //check if the newly supplied passwords are same or not
            //        if (!passwords.Same(user.Settings.Master, txtMaster.Text))
            //        {
            //            lblMassege.Text = "Your New Master Password and Confirm Master Password doesn't match.";
            //            lblMassege.ForeColor = Color.Yellow;
            //        }
            //        else
            //        {
            //            //1-unencrypt all passwords with current Master
            //            //2-change master password to null
            //            //3-encrypt all passwords with login password

            //            //1
            //            //do it here

            //            //2
            //            user.Settings.Master = txtNewMaster.Text;

            //            //3
            //            //we'll do it here 
            //        }
            //    }
            //    else
            //    {
            //        lblMassege.Text = "Please enter a valid Master Password in Existing Master Password field.";
            //        lblMassege.ForeColor = Color.Yellow;
            //    }
            //}
        }
    }
}
