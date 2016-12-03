using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.App
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblAppMotto.Text = Globals.Information.AppMotto;
            lblDetails1.Text = Globals.Information.AppDetails1;
            lblDetails2.Text = Globals.Information.AppDetails2;
            lblDeveloperName.Text = Globals.Information.Developer;
            lblDesignation.Text = Globals.Information.Designation;
            lblWebsiteLink.Text = Globals.Information.WebsiteName;
        }

        private void lblPictureCopyRightsLink_Click(object sender, EventArgs e)
        {
            Process.Start("http://cdn.c.photoshelter.com/img-get/I0000IfwD_T_IDPk/s/860/860/Alaskan%20Coastal%20Brown%20Bear%208.jpg");
        }

        private void lblWebsiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Globals.Information.WebsiteLink);
        }

        private void picboxFacebook_Click(object sender, EventArgs e)
        {
            Process.Start(Globals.Information.FacebookLink);
        }

        private void picboxTwitter_Click(object sender, EventArgs e)
        {
            Process.Start(Globals.Information.TwitterLink);
        }

        private void picboxGooglePlus_Click(object sender, EventArgs e)
        {
            Process.Start(Globals.Information.GooglePlus);
        }

        private void picboxLinkedIn_Click(object sender, EventArgs e)
        {
            Process.Start(Globals.Information.LinkedInLink);
        }

        private void lblSource_Click(object sender, EventArgs e)
        {
            Process.Start(Globals.Information.GitHubSourceLink);
        }
    }
}
