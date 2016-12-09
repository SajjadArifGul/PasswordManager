using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    public class Settings
    {
        public DateTime DateTimeFormat { get; set; }
        public string Master { get; set; }

        public PasswordOptions passwordOptions { get; set; }
    }
}
