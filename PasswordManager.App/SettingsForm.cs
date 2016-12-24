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
    public partial class SettingsForm : Form
    {
        public User user;

        public SettingsForm(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //txtName.Text = user.Name;
            //txtEmail.Text = user.Email;
            //txtUsername.Text = user.Username;

            //txtPassword.Text = user.LoginPassword;

            //if (user.Settings.DifferentMaster)
            //{
            //    chkEnableMaster.Checked = true;
            //    txtMaster.Enabled = true;
            //    txtMaster.Text = user.Settings.Master;
            //}

            //cmbDateFormat.Items.Clear();
            //foreach(DateFormat dateFormat in Globals.Variables.DateFormats)
            //{
            //    cmbDateFormat.Items.Add(dateFormat.Value);
            //}

            //if (user.Settings.DateTimeFormat != null)
            //    cmbDateFormat.SelectedItem = Globals.Variables.DateFormats.Where(f => f.Format == user.Settings.DateTimeFormat).FirstOrDefault().Value;

            //chkDisplayEmail.Checked = user.Settings.ShowEmailColumn;
            //chkDisplayUsername.Checked = user.Settings.ShowUsernameColumn;
            //chkDisplayPassword.Checked = user.Settings.ShowPasswordColumn;
            
        }

        private void btnPasswordOptions_Click(object sender, EventArgs e)
        {
            PasswordGenerateOptions passwordGenerateOptionsForm = new PasswordGenerateOptions(user);

            if (passwordGenerateOptionsForm.ShowDialog() == DialogResult.OK)
            {
                user.Settings.PasswordOptions = passwordGenerateOptionsForm.passwordOptions;
            }
        }

        private void chkEnableMaster_CheckedChanged(object sender, EventArgs e)
        {
            //user.Settings.DifferentMaster = chkEnableMaster.Checked;

            //if (user.Settings.DifferentMaster)
            //{
            //    txtMaster.Enabled = true;
            //}
            //else
            //{
            //    txtMaster.Enabled = false;
            //}
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtName.Text.ToString()))
            user.Name = txtName.Text.ToString();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtEmail.Text.ToString()))
                user.Email = txtEmail.Text.ToString();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtUsername.Text.ToString()))
                user.Username = txtUsername.Text.ToString();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaster_TextChanged(object sender, EventArgs e)
        {
            //if (user.Settings.DifferentMaster)
            //{
            //    if (Verifier.Text(txtMaster.Text.ToString()))
            //        user.Settings.Master = txtMaster.Text.ToString();
            //}
        }

        private void cmbDateFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cmbDateFormat.SelectedItem.ToString();

            DateFormat SelectedFormat = Globals.Variables.DateFormats.Where(f => f.Value == selectedItem).FirstOrDefault();

            user.Settings.DateTimeFormat = SelectedFormat.Format;

            //if (Verifier.Text(txtUsername.Text.ToString()))
            //    user.Username = txtUsername.Text.ToString();
        }

        private void chkDisplayEmail_CheckedChanged(object sender, EventArgs e)
        {
            user.Settings.ShowEmailColumn = chkDisplayEmail.Checked;
        }

        private void chkDisplayUsername_CheckedChanged(object sender, EventArgs e)
        {
            user.Settings.ShowUsernameColumn = chkDisplayUsername.Checked;
        }

        private void chkDisplayPassword_CheckedChanged(object sender, EventArgs e)
        {
            user.Settings.ShowPasswordColumn = chkDisplayPassword.Checked;
        }
    }
}
