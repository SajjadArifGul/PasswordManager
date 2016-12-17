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
    public partial class ImportPasswords : Form
    {
        User user;

        public ImportPasswords(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void ImportPasswords_Load(object sender, EventArgs e)
        {

        }
    }
}
