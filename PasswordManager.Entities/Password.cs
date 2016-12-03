using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    public class Password
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
