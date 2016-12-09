using PasswordManager.Entities;
using PasswordManager.Filer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL
{
    //we have to make this class a Singleton so only one object can be created 
    //during the entire lifecycle.
    public class Database
    {
        private static Database _instance;

        public List<User> Users;

        // Constructor is 'protected'
        protected Database()
        {
            //Get Users from Filer
            Users = Filer.Filer.Read();
        }

        public static Database Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Database();
            }

            return _instance;
        }

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


        public User FindUser(User user)
        {
            User UserToBeReturned = null;

            foreach (User ExistingUser in Users)
            {
                if (ExistingUser.Email == user.Email)
                {
                    if (ExistingUser.LoginPassword == user.LoginPassword)
                    {
                        UserToBeReturned = ExistingUser;
                    }
                }
            }

            return UserToBeReturned;
        }

        public Password AddPassword(User user, Password password)
        {
            Users.Where(u=>u.Email == user.Email).FirstOrDefault().Passwords.Add(password);
            return password;
        }
    }
}
