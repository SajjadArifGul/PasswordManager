using PasswordManager.Entities;
using PasswordManager.Globals;
using PasswordManager.Services;
using PasswordManager.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            lblMasterNote.Text = Globals.Information.MasterPasswordNote;
            lblMasterNote.ForeColor = Color.FromArgb(255, 214, 0);

            picboxLoading.Hide();
        }

        private void MasterPasswordForm_Load(object sender, EventArgs e)
        {

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
        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //check if the newly supplied passwords are same or not
                if (!PasswordsService.Instance().IsSame(txtNewMaster.Text, txtConfirmMaster.Text) && !Verifier.Text(txtNewMaster.Text) && !Verifier.Text(txtConfirmMaster.Text))
                {
                    lblMassege.Text = "Your New Master Password and Confirm Master Password doesn't match.";
                    lblMassege.ForeColor = Color.FromArgb(244, 67, 54);

                }
                else //both new passwords are same. Dont match them again
                {
                    //match the current Master Password with the entered Master Password
                    if (Verifier.Text(txtMaster.Text) && PasswordsService.Instance().IsSame(user.Master, txtMaster.Text))
                    {
                        if (MessageBox.Show("Are you sure you want to change your Master Password?\n\nPlease write down your Master Password for safe keeping, if you forgot your Master Password, you will not be able to recover your Passwords.\n\nFor more guidelines goto Dashboard > Guidelines.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            picboxLoading.Show();
                            btnSave.Enabled = false;

                            //do some refactoring here like null etc exc -gul:1401171353
                            user = await PasswordsService.Instance().ChangeMasterEncryption(user, txtNewMaster.Text);

                            picboxLoading.Hide();
                            btnSave.Enabled = true;
                            lblMassege.Text = "Master Password Changed.";
                            lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
                        }
                    }
                    else //user entered a wrong master password
                    {
                        lblMassege.Text = "Your Master Password is incorrect.";
                        lblMassege.ForeColor = Color.FromArgb(244, 67, 54);
                    }
                }
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
                picboxLoading.Hide();
                btnSave.Enabled = true;
            }
        }

        private void CheckSaveEnable(object sender, EventArgs e)
        {
            btnSave.Enabled = IsEnable();
        }

        public bool IsEnable()
        {
            if (PasswordsService.Instance().IsSame(txtNewMaster.Text, txtConfirmMaster.Text) && Verifier.Text(txtNewMaster.Text) && Verifier.Text(txtConfirmMaster.Text))
            {
                //now check if existing master match too
                if (Verifier.Text(txtMaster.Text) && PasswordsService.Instance().IsSame(user.Master, txtMaster.Text))
                {
                    lblMassege.Text = "You can try to save now.";
                    lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
                    return true;
                }
                else
                {
                    lblMassege.Text = "Your Master Password is incorrect.";
                    lblMassege.ForeColor = Color.FromArgb(244, 67, 54);
                    return false;
                }
            }
            else
            {
                lblMassege.Text = "Your New Master Password and Confirm Master Password doesn't match.";
                lblMassege.ForeColor = Color.FromArgb(244, 67, 54);
                return false;
            }
        }
    }
}
