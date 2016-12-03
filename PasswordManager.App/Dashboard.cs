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

        public Dashboard(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = user.Name + " - " + Globals.Settings.AppName + " Dashboard";

            foreach (Password password in user.Passwords)
            {
                PasswordsGridView.Rows.Add(password.ID, password.DateCreated, password.Name, password.Email, password.Username, password.Text);
            }
        }

        private void btnSearchPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnMasterPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnImportPasswords_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPasswords_Click(object sender, EventArgs e)
        {

        }

        private void btnGuide_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {

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
    }
}
