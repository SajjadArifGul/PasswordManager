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
    public partial class MasterPasswordForm : Form
    {
        public User user;

        public MasterPasswordForm(User user)
        {
            InitializeComponent();

            this.user = user;
            user.Settings = new Settings();

            lblMasterNote.Text = Globals.Information.MasterPasswordNote;
            lblMasterNote.ForeColor = Color.FromArgb(255, 214, 0);

            if (user.Settings.differentMaster)
                LoadMaster(user.Settings.differentMaster);
        }

        private void MasterPasswordForm_Load(object sender, EventArgs e)
        {
        }

        private void chkEnableMaster_CheckedChanged(object sender, EventArgs e)
        {
            user.Settings.differentMaster = chkEnableMaster.Checked;

            LoadMaster(user.Settings.differentMaster);
        }

        public void LoadMaster(bool MasterEnabled)
        {
            chkEnableMaster.Checked = MasterEnabled;

            if (MasterEnabled)
            {
                txtMaster.Enabled = true;
                txtNewMaster.Enabled = true;
                txtConfirmMaster.Enabled = true;

                chkHideMaster.Enabled = true;
                chkHideNewMaster.Enabled = true;
                chkHideConfirmMaster.Enabled = true;
            }
            else
            {
                txtMaster.Enabled = false;
                txtNewMaster.Enabled = false;
                txtConfirmMaster.Enabled = false;

                chkHideMaster.Enabled = false;
                chkHideNewMaster.Enabled = false;
                chkHideConfirmMaster.Enabled = false;
            }
        }

        private void chkShowMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtMaster.UseSystemPasswordChar = chkHideMaster.Checked;
        }

        private void chkShowNewMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtNewMaster.UseSystemPasswordChar = chkHideNewMaster.Checked;
        }

        private void chkShowConfirmMaster_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmMaster.UseSystemPasswordChar = chkHideConfirmMaster.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am here");
        }
    }
}
