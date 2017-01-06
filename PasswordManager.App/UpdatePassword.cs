using PasswordManager.Entities;
using PasswordManager.Globals;
using PasswordManager.Services;
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
    public partial class UpdatePassword : Form
    {
        public Password password;
        User user;

        public UpdatePassword(User user, Password password)
        {
            InitializeComponent();

            this.password = password;
            this.user = user;
        }

        private void UpdatePassword_Load(object sender, EventArgs e)
        {
            txtName.Text = password.Name;
            txtEmail.Text = password.Email;
            txtUsername.Text = password.Username;
            txtWebsite.Text = password.Website;
            txtPassword.Text = password.Text;
            rtxtNotes.Text = password.Notes;
            
            btnSave.Enabled = IsEnable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            password.Name = txtName.Text;
            password.Email = txtEmail.Text;
            password.Username = txtUsername.Text;
            password.Website = txtWebsite.Text;
            password.Text =  txtPassword.Text;
            password.Notes = rtxtNotes.Text;
            password.DateModified = DateTime.Now;
        }

        private void ForSaveBtnEnable(object sender, EventArgs e)
        {
            btnSave.Enabled = IsEnable();
        }

        private bool IsEnable()
        {
            if (Verifier.Text(txtName.Text) && Verifier.Text(txtPassword.Text))
                return true;
            return false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = PasswordsService.Instance().GeneratePassword(user);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            PasswordGenerateOptions passwordGenerateOptionsForm = new PasswordGenerateOptions(user);

            if (passwordGenerateOptionsForm.ShowDialog() == DialogResult.OK)
            {
                user.Settings.PasswordOptions = passwordGenerateOptionsForm.passwordOptions;
                txtPassword.Text = PasswordsService.Instance().GeneratePassword(user);
            }
        }
    }
}
