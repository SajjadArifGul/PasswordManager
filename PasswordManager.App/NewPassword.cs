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

        PasswordOptions passwordOptions;

        public NewPassword(PasswordOptions passwordOptions)
        {
            InitializeComponent();

            passwords = new Passwords();
            this.passwordOptions = passwordOptions;
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
            Password password = new Password()
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                Website = txtWebsite.Text,
                Text = txtPassword.Text,
                Notes = rtxtNotes.Text
            };

            passwords.Save(password);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
