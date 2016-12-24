using PasswordManager.DAL;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BLL
{
    public class Users
    {
        Database db;

        public Users()
        {
            db = Database.Instance();
        }

        public bool Register(User user)
        {
            return db.User_Add(user);
        }

        public User Exist(User user)
        {
            User returnedUser = db.User_Select(user);

            if (returnedUser.Master == user.Master)
                return returnedUser;
            else return null;
        }

        public User Login(User user)
        {
            if (Exist(user) != null)
            {
                //now populate the user with passwords and settings and related stuff
                Passwords passwords = new Passwords();
                user.Passwords = passwords.Get(user);

                //for now
                user.Settings = new Settings() { PasswordOptions = new PasswordOptions()};
                
            }

            return user;
        }

        public User Update(User user)
        {
            if (db.User_Update(user)) return user;
            else return null;
        }
    }
}
