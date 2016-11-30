using PasswordManager.BLL;
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
    public partial class Login : Form
    {
        Users users = new Users();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblMassege.ForeColor = Color.FromArgb(67, 140, 235);
            lblMassege.Text = string.Empty;

            if (!Verifier.Text(txtEmail.Text))
            {
                lblMassege.Text = "Please Enter a Valid Email Address.";
                lblMassege.ForeColor = Color.Red;
            }
            else if (!Verifier.Text(txtLoginPass.Text))
            {
                lblMassege.Text = "Enter Your Password.";
                lblMassege.ForeColor = Color.Red;
            }
            else
            {
                User user = new User()
                {
                    Email = txtEmail.Text,
                    LoginPassword = txtLoginPass.Text
                };

                User loginUser = users.Exist(user);

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
                }
            }
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
