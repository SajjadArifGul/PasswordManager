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
    public partial class NewPassword : Form
    {
        Passwords passwords;
        User user;

        public Password newPassword;

        public NewPassword(User user)
        {
            InitializeComponent();

            passwords = new Passwords();
            this.user = user;
            
            txtName.Focus();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            PasswordGenerateOptions passwordGenerateOptionsForm = new PasswordGenerateOptions(user);

            if (passwordGenerateOptionsForm.ShowDialog() == DialogResult.OK)
            {
                txtPassword.Text = passwords.New(passwordGenerateOptionsForm.passwordOptions);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = passwords.New(user.Settings.PasswordOptions);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            newPassword = new Password()
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (Verifier.Text(txtName.Text) && Verifier.Text(txtPassword.Text))
                return true;
            return false;
        }

    }
}
