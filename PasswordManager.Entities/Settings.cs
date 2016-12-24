using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    public class Settings
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string DateTimeFormat { get; set; }
        public bool ShowEmailColumn { get; set; }
        public bool ShowUsernameColumn { get; set; }
        public bool ShowPasswordColumn { get; set; }

        public PasswordOptions PasswordOptions { get; set; }

        public Settings()
        {
        }
    }
}
