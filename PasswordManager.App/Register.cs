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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                btnRegister.Enabled = false;

                if (!Verifier.Text(txtName.Text))
                {
                    lblMassege.Text = "Enter Your Name";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verifier.Text(txtUsername.Text))
                {
                    lblMassege.Text = "Enter Your Username";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verifier.Email(txtEmail.Text))
                {
                    lblMassege.Text = "Plaese Enter a Valid Email Address.";
                    lblMassege.ForeColor = Color.Red;
                }
                else if (!Verifier.Text(txtLoginPass.Text))
                {
                    lblMassege.Text = "Enter Your Password. This will be used as your Master Password by default.";
                    lblMassege.BackColor = Color.Yellow;
                    lblMassege.ForeColor = Color.Red;
                }
                else
                {
                    User user = new User()
                    {
                        ID = 1, //this shit took 1 hour for me to find out. - temporary 
                        Name = txtName.Text,
                        Username = txtUsername.Text,
                        Email = txtEmail.Text,
                        Master = txtLoginPass.Text,
                    };

                    if (!await UsersService.Instance().UserExistAsync(user))
                    {
                        user = await UsersService.Instance().RegisterUserAsync(user);

                        if (user != null)
                        {
                            lblMassege.Text = "User Registered.";

                            this.Hide();
                            Dashboard dashboard = new Dashboard(user);
                            dashboard.Show();
                        }
                        else
                        {
                            lblMassege.Text = "An unknown error occured. Please try again.";

                            this.Hide();
                            Dashboard dashboard = new Dashboard(user);
                            dashboard.Show();
                        }
                    }
                    else
                    {
                        lblMassege.Text = "A user with these credentials is already registered. Please Login or use different Email and Username.";
                        lblMassege.ForeColor = Color.Red;
                    }
                    picboxLoading.Hide();
                }
            }
            catch (Exception ex)
            {
                Messenger.Show(ex.Message + " " + ex.HResult, "Error");
                ResetControls();
            }
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        public void ResetControls()
        {
            picboxLoading.Show();
            lblMassege.BackColor = Color.Transparent;
            lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
            lblMassege.Text = string.Empty;
            btnRegister.Enabled = true;
        }
    }
}
