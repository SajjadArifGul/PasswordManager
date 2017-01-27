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
    public partial class PasswordGenerateOptions : Form
    {
        public User user;

        public PasswordOptions passwordOptions;

        public PasswordGenerateOptions(User user)
        {
            InitializeComponent();

            this.user = user;
            passwordOptions = user.Settings.PasswordOptions;
        }

        private void PasswordGenerateOptions_Load(object sender, EventArgs e)
        {
            AllowLowercaseCheckBox.Checked =passwordOptions.AllowUppercaseCharacters;
            AllowUppercaseCheckBox.Checked =passwordOptions.AllowUppercaseCharacters;
            AllowNumberCheckBox.Checked =passwordOptions.AllowNumberCharacters;
            AllowSpecialCheckBox.Checked =passwordOptions.AllowSpecialCharacters;
            AllowUnderscoreCheckBox.Checked =passwordOptions.AllowUnderscoreCharacters;
            AllowSpaceCheckBox.Checked =passwordOptions.AllowSpaceCharacters;

            RequireLowercaseCheckBox.Checked =passwordOptions.RequireUppercaseCharacters;
            RequireUppercaseCheckBox.Checked =passwordOptions.RequireUppercaseCharacters;
            RequireNumberCheckBox.Checked =passwordOptions.RequireNumberCharacters;
            RequireSpecialCheckBox.Checked =passwordOptions.RequireSpecialCharacters;
            RequireUnderscoreCheckBox.Checked =passwordOptions.RequireUnderscoreCharacters;
            RequireSpaceCheckBox.Checked =passwordOptions.RequireSpaceCharacters;

            txtOtherCharacters.Text =passwordOptions.OtherCharacters;
            txtMinimumCharacters.Text =passwordOptions.MinimumCharacters.ToString();
            txtMaximumCharacters.Text =passwordOptions.MaximumCharacters.ToString();
        }

        private void AllowLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.AllowLowercaseCharacters = AllowLowercaseCheckBox.Checked;
        }

        private void AllowUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.AllowUppercaseCharacters = AllowUppercaseCheckBox.Checked;
        }

        private void AllowNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.AllowNumberCharacters = AllowNumberCheckBox.Checked;
        }

        private void AllowSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.AllowSpecialCharacters = AllowSpecialCheckBox.Checked;
        }

        private void AllowUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.AllowUnderscoreCharacters = AllowUnderscoreCheckBox.Checked;
        }

        private void AllowSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.AllowSpaceCharacters = AllowSpecialCheckBox.Checked;
        }

        private void RequireLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.RequireLowercaseCharacters = RequireLowercaseCheckBox.Checked;
        }

        private void RequireUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.RequireUppercaseCharacters = RequireUppercaseCheckBox.Checked;
        }

        private void RequireNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.RequireNumberCharacters = RequireNumberCheckBox.Checked;
        }

        private void RequireSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.RequireSpecialCharacters = RequireSpecialCheckBox.Checked;
        }

        private void RequireUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.RequireUnderscoreCharacters = RequireUnderscoreCheckBox.Checked;
        }

        private void RequireSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           passwordOptions.RequireSpaceCharacters = RequireSpaceCheckBox.Checked;
        }

        private void txtOtherCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtOtherCharacters.Text))
            {
               passwordOptions.AllowOtherCharacters = true;
               passwordOptions.RequireOtherCharacters = true;
               passwordOptions.OtherCharacters = txtOtherCharacters.Text;
            }
            else {
               passwordOptions.AllowOtherCharacters = false;
               passwordOptions.RequireOtherCharacters = false;
               passwordOptions.OtherCharacters = string.Empty;
            }
        }

        private void txtMinimumCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtMinimumCharacters.Text))
            {
               passwordOptions.MinimumCharacters = Convert.ToInt32(txtMinimumCharacters.Text);

                if (Verifier.Text(txtMaximumCharacters.Text))
                {
                    int MinChars = Convert.ToInt32(txtMinimumCharacters.Text);
                    int MaxChars = Convert.ToInt32(txtMaximumCharacters.Text);

                    if (MinChars > MaxChars)
                        txtMaximumCharacters.Text = MinChars.ToString();
                }
            }
            else
            {
               passwordOptions.MinimumCharacters = 10;
            }
        }

        private void txtMaximumCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtMaximumCharacters.Text))
            {
               passwordOptions.MaximumCharacters = Convert.ToInt32(txtMaximumCharacters.Text);

                if (Verifier.Text(txtMinimumCharacters.Text))
                {
                    int MinChars = Convert.ToInt32(txtMinimumCharacters.Text);
                    int MaxChars = Convert.ToInt32(txtMaximumCharacters.Text);

                    if (MaxChars < MinChars)
                        txtMinimumCharacters.Text = MaxChars.ToString();
                }
            }
            else
            {
               passwordOptions.MaximumCharacters = 12;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                user.Settings.PasswordOptions = passwordOptions;
                //update password options
                SettingsService.Instance().UpdateUserPasswordOptionsAsync(user, user.Settings, passwordOptions);
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
            }
        }
    }
}
