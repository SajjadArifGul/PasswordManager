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

        public int PasswordOptionsID { get; set; }
        public PasswordOptions PasswordOptions { get; set; }

        public bool ShowEmailColumn { get; set; }
        public bool ShowUsernameColumn { get; set; }
        public bool ShowPasswordColumn { get; set; }


        public Settings()
        {
            //if (dateTimeFormat != null) this.dateTimeFormat = dateTimeFormat;
            //else this.dateTimeFormat = new DateTime();

            //if (passwordOptions != null) this.passwordOptions = passwordOptions;
            //else this.passwordOptions = new PasswordOptions();

            //if (differentMaster) this.Master = Master;

            //this.ShowEmailColumn = ShowEmailColumn;
            //this.ShowUernameColumn = ShowUernameColumn;
            //this.ShowPasswordColumn = ShowPasswordColumn;
        }
    }
}
