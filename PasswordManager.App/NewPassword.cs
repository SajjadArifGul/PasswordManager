using PasswordManager.BLL;
using PasswordManager.Entities;
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

        public Password newPassword;

        PasswordOptions passwordOptions;

        public NewPassword(PasswordOptions passwordOptions)
        {
            InitializeComponent();

            passwords = new Passwords();

            if (passwordOptions != null) this.passwordOptions = passwordOptions;
            else passwordOptions = new PasswordOptions();
            
            txtName.Focus();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            PasswordGenerateOptions passwordGenerateOptionsForm = new PasswordGenerateOptions(passwordOptions);

            if (passwordGenerateOptionsForm.ShowDialog() == DialogResult.OK)
            {
                passwordOptions = passwordGenerateOptionsForm.passwordOptions;

                txtPassword.Text = passwords.New(passwordOptions);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = passwords.New(passwordOptions);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            newPassword = new Password()
            {
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
        }
    }
}
