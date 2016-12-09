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
    public partial class PasswordGenerateOptions : Form
    {
        public PasswordOptions passwordOptions;

        public PasswordGenerateOptions(PasswordOptions passwordOptions)
        {
            InitializeComponent();

            this.passwordOptions = passwordOptions;
        }

        private void PasswordGenerateOptions_Load(object sender, EventArgs e)
        {
            AllowLowercaseCheckBox.Checked = passwordOptions.AllowUppercaseCharacters;
            AllowUppercaseCheckBox.Checked = passwordOptions.AllowUppercaseCharacters;
            AllowNumberCheckBox.Checked = passwordOptions.AllowNumberCharacters;
            AllowSpecialCheckBox.Checked = passwordOptions.AllowSpecialCharacters;
            AllowUnderscoreCheckBox.Checked = passwordOptions.AllowUnderscoreCharacters;
            AllowSpaceCheckBox.Checked = passwordOptions.AllowSpaceCharacters;

            RequireLowercaseCheckBox.Checked = passwordOptions.RequireUppercaseCharacters;
            RequireUppercaseCheckBox.Checked = passwordOptions.RequireUppercaseCharacters;
            RequireNumberCheckBox.Checked = passwordOptions.RequireNumberCharacters;
            RequireSpecialCheckBox.Checked = passwordOptions.RequireSpecialCharacters;
            RequireUnderscoreCheckBox.Checked = passwordOptions.RequireUnderscoreCharacters;
            RequireSpaceCheckBox.Checked = passwordOptions.RequireSpaceCharacters;

            txtOtherCharacters.Text = passwordOptions.OtherCharacters;
            txtMinimumCharacters.Text = passwordOptions.MinimumCharacters.ToString();
            txtMaximumCharacters.Text = passwordOptions.MaximumCharacters.ToString();
        }

        private void AllowLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(AllowLowercaseCheckBox.Checked)
            {
                passwordOptions.AllowLowercaseCharacters = true;
            }
            else passwordOptions.AllowLowercaseCharacters = false;
        }

        private void AllowUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllowUppercaseCheckBox.Checked)
            {
                passwordOptions.AllowUppercaseCharacters = true;
            }
            else passwordOptions.AllowUppercaseCharacters = false;
        }

        private void AllowNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllowNumberCheckBox.Checked)
            {
                passwordOptions.AllowNumberCharacters = true;
            }
            else passwordOptions.AllowNumberCharacters = false;
        }

        private void AllowSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllowSpecialCheckBox.Checked)
            {
                passwordOptions.AllowSpecialCharacters = true;
            }
            else passwordOptions.AllowSpecialCharacters = false;
        }

        private void AllowUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllowUnderscoreCheckBox.Checked)
            {
                passwordOptions.AllowUnderscoreCharacters = true;
            }
            else passwordOptions.AllowUnderscoreCharacters = false;
        }

        private void AllowSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllowSpaceCheckBox.Checked)
            {
                passwordOptions.AllowSpaceCharacters = true;
            }
            else passwordOptions.AllowSpaceCharacters = false;
        }

        private void RequireLowercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RequireLowercaseCheckBox.Checked)
            {
                passwordOptions.RequireLowercaseCharacters = true;
            }
            else passwordOptions.RequireLowercaseCharacters = false;
        }

        private void RequireUppercaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RequireUppercaseCheckBox.Checked)
            {
                passwordOptions.RequireUppercaseCharacters = true;
            }
            else passwordOptions.RequireUppercaseCharacters = false;
        }

        private void RequireNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RequireNumberCheckBox.Checked)
            {
                passwordOptions.RequireNumberCharacters = true;
            }
            else passwordOptions.RequireNumberCharacters = false;
        }

        private void RequireSpecialCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RequireSpecialCheckBox.Checked)
            {
                passwordOptions.RequireSpecialCharacters = true;
            }
            else passwordOptions.RequireSpecialCharacters = false;
        }

        private void RequireUnderscoreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RequireUnderscoreCheckBox.Checked)
            {
                passwordOptions.RequireUnderscoreCharacters = true;
            }
            else passwordOptions.RequireUnderscoreCharacters = false;
        }

        private void RequireSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RequireSpaceCheckBox.Checked)
            {
                passwordOptions.RequireSpaceCharacters = true;
            }
            else passwordOptions.RequireSpaceCharacters = false;
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
            }
            else
            {
                passwordOptions.MinimumCharacters = 12;
            }
        }
    }
}
