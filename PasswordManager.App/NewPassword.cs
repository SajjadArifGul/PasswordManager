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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.App
{
    public partial class NewPassword : Form
    {
        User user;
        
        public NewPassword(User user)
        {
            InitializeComponent();

            this.user = user;
            
            txtName.Focus();
        }
        
        private void NewPassword_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = IsEnable();
        }

        private void ForSaveBtnEnable(object sender, EventArgs e)
        {
            btnSave.Enabled = IsEnable();
        }

        private bool IsEnable()
        {
            if (Verifier.Text(txtName.Text) && Verifier.Text(txtPassword.Text) && Verifier.Email(txtEmail.Text))
                return true;
            return false;
        }

        private async void btnOptions_Click(object sender, EventArgs e)
        {
            PasswordGenerateOptions passwordGenerateOptionsForm = new PasswordGenerateOptions(user);

            if (passwordGenerateOptionsForm.ShowDialog() == DialogResult.OK)
            {
                user.Settings.PasswordOptions = passwordGenerateOptionsForm.passwordOptions;
                txtPassword.Text = await PasswordsService.Instance().GeneratePasswordAsync(user);
            }
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = await PasswordsService.Instance().GeneratePasswordAsync(user);
        }
        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            Password newPassword = new Password()
            {
                UserID = user.ID,
                Name = txtName.Text,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                Website = txtWebsite.Text,
                Text = txtPassword.Text,
                Notes = rtxtNotes.Text,

                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            try
            {
                await PasswordsService.Instance().SaveNewUserPasswordAsync(user, newPassword);
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
