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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            picboxLoading.Hide();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;

            picboxLoading.Show();
            lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
            lblMassege.Text = string.Empty;

            if (!Verifier.Email(txtEmail.Text))
            {
                lblMassege.Text = "Please Enter a Valid Email Address.";
                lblMassege.ForeColor = Color.Red;

                txtEmail.Focus();
            }
            else if (!Verifier.Text(txtLoginPass.Text))
            {
                lblMassege.Text = "Enter Your Password.";
                lblMassege.ForeColor = Color.Red;

                txtLoginPass.Focus();
            }
            else
            {
                User user = new User()
                {
                    ID = 1, //temporaryID for Validation
                    Email = txtEmail.Text,
                    Master = txtLoginPass.Text
                };

                picboxLoading.Show();

                User loginUser = await UsersService.Instance().LoginUserAsync(user);
                if (loginUser != null)
                {
                    lblMassege.Text = "Login Successful.";

                    this.Hide();
                    Dashboard dashboard = new Dashboard(loginUser);
                    dashboard.Show();
                }
                else
                {
                    lblMassege.Text = "No user found with the supplied credentials.";
                    lblMassege.ForeColor = Color.Red;

                    txtEmail.Focus();
                }

                picboxLoading.Hide();
            }
            btnLogin.Enabled = true;
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
