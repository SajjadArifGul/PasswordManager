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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = txtName.Text,
                Username = txtUsername.Text,
                Email = txtEmail.Text,
                LoginPassword = txtLoginPass.Text,
                MasterPassword = txtMasterPass.Text
            };


        }
    }
}
