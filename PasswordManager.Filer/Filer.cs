using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Filer
{
    public class Filer
    {
        public bool Save(List<User> Users)
        {
            string FilePath = Globals.Settings.DatabaseFilePath;

            foreach (User user in Users)
            {
                foreach (Password password in user.Passwords)
                {
                    //get all stuff & write xml
                }
            }

            return false;
        }

        public string Read()
        {
            //return type should be a list of users with their password details

            string FilePath = Globals.Settings.DatabaseFilePath;

            return "";
        }
    }
}
