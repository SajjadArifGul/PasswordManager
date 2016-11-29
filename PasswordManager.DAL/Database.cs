using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL
{
    public class Database
    {
        public List<User> Users { get; set; }

        public bool AddUser(User user)
        {
            foreach (User u in Users)
            {
                if ((u.Username == user.Username) || (u.Email == user.Email))
                {
                    //the user with same credentials exists. Cant add user.
                    return false;
                }
            }

            Users.Add(user);
            return true;
        }
    }
}
