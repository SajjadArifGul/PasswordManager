using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string LoginPassword { get; set; }
        public string MasterPassword { get; set; }

        public List<Password> Passwords { get; set; }

        public Settings Settings { get; set; }
    }
}
