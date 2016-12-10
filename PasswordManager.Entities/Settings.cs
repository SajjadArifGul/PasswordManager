using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    public class Settings
    {
        public DateTime dateTimeFormat { get; set; }
        public PasswordOptions passwordOptions { get; set; }
        public bool differentMaster { get; set; }
        public string Master { get; set; }

        public Settings(DateTime dateTimeFormat, PasswordOptions passwordOptions, bool DifferentMaster, string Master)
        {
            if (dateTimeFormat != null) this.dateTimeFormat = dateTimeFormat;
            else this.dateTimeFormat = new DateTime();

            if (passwordOptions != null) this.passwordOptions = passwordOptions;
            else this.passwordOptions = new PasswordOptions();

            if (differentMaster) this.Master = Master;
        }
    }
}
