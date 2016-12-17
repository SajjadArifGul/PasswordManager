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
    public partial class Dashboard : Form
    {
        Passwords passwords;

        User user;

        public Dashboard(User user)
        {
            InitializeComponent();

            passwords = new Passwords();
            this.user = user;

            LoadSettings(user.Settings);
        }

        public void LoadSettings(Settings settings)
        {
            if (settings != null)
            {
                if (!settings.ShowEmailColumn)
                {
                    PasswordsGridView.Columns["ColEmail"].Visible = false;
                }
                else PasswordsGridView.Columns["ColEmail"].Visible = true;

                if (!settings.ShowUsernameColumn)
                {
                    PasswordsGridView.Columns["ColUsername"].Visible = false;
                }
                else PasswordsGridView.Columns["ColUsername"].Visible = true;

                if (!settings.ShowPasswordColumn)
                {
                    PasswordsGridView.Columns["ColPassword"].Visible = false;
                }
                else PasswordsGridView.Columns["ColPassword"].Visible = true;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = user.Name + " - " + Globals.Information.AppName + " Dashboard";

            ShowPasswords(user.Passwords);
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            ShowPasswords(user.Passwords);
        }

        private void btnSearchPassword_Click(object sender, EventArgs e)
        {
            Search searchForm = new Search(user.Passwords);

            if(searchForm.ShowDialog() == DialogResult.OK)
            {
                //ShowPasswords(searchForm.txtSearchPassword.Text);
                string SearchTerm = searchForm.txtSearchPassword.Text;

                string LooksFor = string.Empty;

                if(searchForm.rdbLookEmail.Checked)
                {
                    LooksFor = "Email";
                }
                else if (searchForm.rdbLookUsername.Checked)
                {
                    LooksFor = "Username";
                }
                else LooksFor = "Name";

                string Options = string.Empty;
                if (searchForm.rdbOptionContains.Checked)
                {
                    Options = "Contains";
                }
                else Options = "Equals";

                ShowPasswords(SearchPasswords(user.Passwords, SearchTerm, LooksFor, Options));
            }
        }

        private void btnNewPassword_Click(object sender, EventArgs e)
        {
            NewPassword newPasswordForm = new NewPassword(user.Settings.passwordOptions);

            if (newPasswordForm.ShowDialog() == DialogResult.OK)
            {
                Password password = passwords.Save(user, newPasswordForm.newPassword);
                PasswordsGridView.Rows.Add(password.ID, password.DateCreated, password.Name, password.Email, password.Username, password.Text);
                
            }
        }

        private void btnMasterPassword_Click(object sender, EventArgs e)
        {
            MasterPasswordForm masterPasswordForm = new MasterPasswordForm(user);

            masterPasswordForm.ShowDialog();
        }

        private void btnImportPasswords_Click(object sender, EventArgs e)
        {
            ImportPasswords importPasswords = new ImportPasswords(user);


        }

        private void btnExportPasswords_Click(object sender, EventArgs e)
        {

        }

        private void btnGuide_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(user);

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                user = settingsForm.user;

                LoadSettings(user.Settings);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ShowPasswords(List<Password> Passwords)
        {
            PasswordsGridView.Rows.Clear();

            foreach (Password password in Passwords)
            {
                PasswordsGridView.Rows.Add(password.ID, password.DateCreated, password.Name, password.Email, password.Username, password.Text);
            }
        }

        public List<Password> SearchPasswords(List<Password> Passwords, string Search, string LooksFor, string Options)
        {
            List<Password> searchedPasswords = null;

            if (string.IsNullOrEmpty(Search))
            {
                return Passwords;
            }
            else
            {
                switch(Options)
                {
                    case "Contains":
                        if (LooksFor == "Username")
                        {
                            searchedPasswords = Passwords.Where(p => p.Username.ToLower().Contains(Search.ToLower())).ToList();
                        }
                        else if (LooksFor == "Email")
                        {
                            searchedPasswords = Passwords.Where(p => p.Email.ToLower().Contains(Search.ToLower())).ToList();
                        }
                        else
                        {
                            searchedPasswords = Passwords.Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();
                        }
                        break;
                    case "Equals":
                        if (LooksFor == "Username")
                        {
                            searchedPasswords = Passwords.Where(p => p.Username.ToLower().Equals(Search.ToLower())).ToList();
                        }
                        else if (LooksFor == "Email")
                        {
                            searchedPasswords = Passwords.Where(p => p.Email.ToLower().Equals(Search.ToLower())).ToList();
                        }
                        else
                        {
                            searchedPasswords = Passwords.Where(p => p.Name.ToLower().Equals(Search.ToLower())).ToList();
                        }
                        break;
                }
                return searchedPasswords;
            }
        }
    }
}
