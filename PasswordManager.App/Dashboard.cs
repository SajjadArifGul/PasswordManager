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
    public partial class Dashboard : Form
    {
        User user;

        public Dashboard(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //PasswordsGridView.Rows.Add("1", "12-12-2016", "Google", "sajjadarifgul@gmail.com", "SajjadArifGul", "123456");
            //PasswordsGridView.Rows.Add("2", "01-11-2016", "Facebook", "sajjadarifgul@gmail.com", "SajjadArifGul", "123456");
            //PasswordsGridView.Rows.Add("3", "23-10-2016", "Yahoo", "sajjadarifgul@gmail.com", "SajjadArifGul", "123456");
            //PasswordsGridView.Rows.Add("4", "13-09-2016", "Twitter", "sajjadarifgul@gmail.com", "SajjadArifGul", "123456");
            //PasswordsGridView.Rows.Add("5", "18-08-2016", "Microsoft", "sajjadarifgul@gmail.com", "SajjadArifGul", "123456");
            //PasswordsGridView.Rows.Add("6", "20-07-2016", "LinkedIn", "sajjadarifgul@gmail.com", "SajjadArifGul", "123456");

            foreach (Password password in user.Passwords)
            {
                PasswordsGridView.Rows.Add(password.ID, password.DateCreated, password.Name, password.Email, password.Username, password.Text);
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
