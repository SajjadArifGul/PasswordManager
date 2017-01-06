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
            AllowLowercaseCheckBox.Checked =user.Settings.PasswordOptions.AllowUppercaseCharacters;
            AllowUppercaseCheckBox.Checked =user.Settings.PasswordOptions.AllowUppercaseCharacters;
            AllowNumberCheckBox.Checked =user.Settings.PasswordOptions.AllowNumberCharacters;
            AllowSpecialCheckBox.Checked =user.Settings.PasswordOptions.AllowSpecialCharacters;
            AllowUnderscoreCheckBox.Checked =user.Settings.PasswordOptions.AllowUnderscoreCharacters;
            AllowSpaceCheckBox.Checked =user.Settings.PasswordOptions.AllowSpaceCharacters;

            RequireLowercaseCheckBox.Checked =user.Settings.PasswordOptions.RequireUppercaseCharacters;
            RequireUppercaseCheckBox.Checked =user.Settings.PasswordOptions.RequireUppercaseCharacters;
            RequireNumberCheckBox.Checked =user.Settings.PasswordOptions.RequireNumberCharacters;
            RequireSpecialCheckBox.Checked =user.Settings.PasswordOptions.RequireSpecialCharacters;
            RequireUnderscoreCheckBox.Checked =user.Settings.PasswordOptions.RequireUnderscoreCharacters;
            RequireSpaceCheckBox.Checked =user.Settings.PasswordOptions.RequireSpaceCharacters;

            txtOtherCharacters.Text =user.Settings.PasswordOptions.OtherCharacters;
            txtMinimumCharacters.Text =user.Settings.PasswordOptions.MinimumCharacters.ToString();
            txtMaximumCharacters.Text =user.Settings.PasswordOptions.MaximumCharacters.ToString();
        }

        private void AllowLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.AllowLowercaseCharacters = AllowLowercaseCheckBox.Checked;
        }

        private void AllowUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.AllowUppercaseCharacters = AllowUppercaseCheckBox.Checked;
        }

        private void AllowNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.AllowNumberCharacters = AllowNumberCheckBox.Checked;
        }

        private void AllowSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.AllowSpecialCharacters = AllowSpecialCheckBox.Checked;
        }

        private void AllowUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.AllowUnderscoreCharacters = AllowUnderscoreCheckBox.Checked;
        }

        private void AllowSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.AllowSpaceCharacters = AllowSpecialCheckBox.Checked;
        }

        private void RequireLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.RequireLowercaseCharacters = RequireLowercaseCheckBox.Checked;
        }

        private void RequireUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.RequireUppercaseCharacters = RequireUppercaseCheckBox.Checked;
        }

        private void RequireNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.RequireNumberCharacters = RequireNumberCheckBox.Checked;
        }

        private void RequireSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.RequireSpecialCharacters = RequireSpecialCheckBox.Checked;
        }

        private void RequireUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.RequireUnderscoreCharacters = RequireUnderscoreCheckBox.Checked;
        }

        private void RequireSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           user.Settings.PasswordOptions.RequireSpaceCharacters = RequireSpaceCheckBox.Checked;
        }

        private void txtOtherCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtOtherCharacters.Text))
            {
               user.Settings.PasswordOptions.AllowOtherCharacters = true;
               user.Settings.PasswordOptions.RequireOtherCharacters = true;
               user.Settings.PasswordOptions.OtherCharacters = txtOtherCharacters.Text;
            }
            else {
               user.Settings.PasswordOptions.AllowOtherCharacters = false;
               user.Settings.PasswordOptions.RequireOtherCharacters = false;
               user.Settings.PasswordOptions.OtherCharacters = string.Empty;
            }
        }

        private void txtMinimumCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtMinimumCharacters.Text))
            {
               user.Settings.PasswordOptions.MinimumCharacters = Convert.ToInt32(txtMinimumCharacters.Text);

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
               user.Settings.PasswordOptions.MinimumCharacters = 10;
            }
        }

        private void txtMaximumCharacters_TextChanged(object sender, EventArgs e)
        {
            if (Verifier.Text(txtMaximumCharacters.Text))
            {
               user.Settings.PasswordOptions.MaximumCharacters = Convert.ToInt32(txtMaximumCharacters.Text);

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
               user.Settings.PasswordOptions.MaximumCharacters = 12;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            passwordOptions = user.Settings.PasswordOptions;
            
            //update password options
            SettingsService.Instance().UpdateUserSettings(user, user.Settings);
        }
    }
}
