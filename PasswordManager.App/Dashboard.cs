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
        User user;

        Passwords passwords;

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
                PasswordsGridView.Columns["ColEmail"].Visible = settings.ShowEmailColumn;
                PasswordsGridView.Columns["ColUsername"].Visible = settings.ShowUsernameColumn;
                PasswordsGridView.Columns["ColPassword"].Visible = settings.ShowPasswordColumn;
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
            Search searchForm = new Search();

            if(searchForm.ShowDialog() == DialogResult.OK)
            {
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

                ShowPasswords(passwords.Search(user, SearchTerm, LooksFor, Options));
            }
        }

        private void btnNewPassword_Click(object sender, EventArgs e)
        {
            NewPassword newPasswordForm = new NewPassword(user);

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
    }
}
