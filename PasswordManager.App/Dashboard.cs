using PasswordManager.Entities;
using PasswordManager.Filer;
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
    public partial class Dashboard : Form
    {
        User user;

        public Dashboard(User user)
        {
            InitializeComponent();
            
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
            ShowPasswords(user);
        }

        private async void btnSearchPassword_Click(object sender, EventArgs e)
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

                ShowPasswords(await PasswordsService.Instance().SearchUserPasswordsAsync(user, SearchTerm, LooksFor, Options));
            }
        }

        private async void btnNewPassword_Click(object sender, EventArgs e)
        {
            NewPassword newPasswordForm = new NewPassword(user);

            if (newPasswordForm.ShowDialog() == DialogResult.OK)
            {
                user.Passwords = await PasswordsService.Instance().GetAllUserPasswordsAsync(user);
                ShowPasswords(user.Passwords);
            }
        }

        private void btnMasterPassword_Click(object sender, EventArgs e)
        {
            MasterPasswordForm masterPasswordForm = new MasterPasswordForm(user);

            masterPasswordForm.ShowDialog();
        }

        private void btnImportPasswords_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Import Passwords";
            ofd.DefaultExt = "bp";
            ofd.Filter = Globals.Information.AppName + " files (*.bp)|*.bp|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.CheckPathExists = true;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<Password> importedPasswords = Filer.Filer.ImportFromFile(ofd.FileName);
                if (importedPasswords != null)
                {
                    if(MessageBox.Show("The file contains "+ importedPasswords.Count + " passwords. Are you sure you want to import these passwords to your account?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        //import the passwords to current user.
                        user.Passwords.AddRange(importedPasswords);
                        ShowPasswords(user.Passwords);


                        //BearPassService.Instance().ImportPasswords(user, importedPasswords);
                        //passwords.Import(importedPasswords, user);
                    }
                }
            }
        }

        private void btnExportPasswords_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Export Passwords";
            sfd.DefaultExt = "bp";
            sfd.Filter = Globals.Information.AppName + " files (*.bp)|*.bp|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.CheckPathExists = true;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (Filer.Filer.ExportToFile(user.Passwords, sfd.FileName))
                {
                    MessageBox.Show("Passwords exported to "+sfd.FileName+" file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();

            guide.ShowDialog();
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

        public void ShowPasswords()
        {
            ShowPasswords(user);
        }
        public async void ShowPasswords(User user)
        {
            ShowPasswords(await PasswordsService.Instance().GetAllUserPasswordsAsync(user));
        }
        public void ShowPasswords(List<Password> Passwords)
        {
            PasswordsGridView.Rows.Clear();

            foreach (Password password in Passwords)
            {
                PasswordsGridView.Rows.Add(password.ID, password.DateCreated, password.Name, password.Email, password.Username, password.Text);
            }
        }

        private void PasswordsGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (sender as DataGridView);

            //Skip the Column and Row headers
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                dataGridView.Cursor = Cursors.Default;
            }
            else
            {
                if (e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
                    dataGridView.Cursor = Cursors.Hand;
                else
                    dataGridView.Cursor = Cursors.Default;
            }
        }

        private async void PasswordsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColCopy")
                {
                    Clipboard.Clear();
                    Clipboard.SetText(PasswordsGridView.Rows[e.RowIndex].Cells["ColPassword"].Value.ToString());
                    System.Media.SystemSounds.Exclamation.Play();
                    Messenger(PasswordsGridView.Rows[e.RowIndex].Cells["ColName"].Value.ToString() + " Password Copied.");
                }
                else if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColUpdate")
                {
                    int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());

                    UpdatePassword updatePasswordForm = new UpdatePassword(user, user.Passwords.Where(i=>i.ID == ID).FirstOrDefault());

                    if (updatePasswordForm.ShowDialog() == DialogResult.OK)
                    {
                        user.Passwords = await PasswordsService.Instance().GetAllUserPasswordsAsync(user);
                        Messenger("Password Updated.", Globals.Defaults.WarningColor);
                        ShowPasswords(user.Passwords);
                    }
                }
                else if (PasswordsGridView.Columns[e.ColumnIndex].Name == "ColDelete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this Password?\nTHIS TASK WILL NOT BE REVERTED.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        int ID = Convert.ToInt32(PasswordsGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());
                        Password passwordToDelete = user.Passwords.Where(p => p.ID == ID).FirstOrDefault();

                        if (await PasswordsService.Instance().RemoveUserPasswordAsync(user, passwordToDelete))
                        {
                            PasswordsGridView.Rows.RemoveAt(e.RowIndex);
                            Messenger("Password Deleted.", Globals.Defaults.WarningColor);
                            System.Media.SystemSounds.Question.Play();
                        }
                        else
                        {
                            Messenger("Password NOT Deleted.", Globals.Defaults.ErrorColor);
                            System.Media.SystemSounds.Exclamation.Play();
                        }
                    }
                }
            }
        }

        public void Messenger(string Message)
        {
            Messenger(Message, Globals.Defaults.DefaultColor);
        }

        public void Messenger(string Message, Color FontColor)
        {
            lblMassege.Text = Message;
            lblMassege.ForeColor = FontColor;
        }
    }
}
