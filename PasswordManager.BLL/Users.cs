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

        public User Register(User user)
        {
            if(db.User_Add(user))
            {
                return db.Settings_Add(user);
            }
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
            User returnedUser = Exist(user);

            if (returnedUser != null)
            {
                //now populate the user with passwords and settings and related stuff
                Passwords passwords = new Passwords();
                returnedUser.Passwords = passwords.Get(returnedUser);

                //for now
                returnedUser.Settings = new Settings() { PasswordOptions = new PasswordOptions()};



                return returnedUser;
            }

            return null;
        }

        public User Update(User user)
        {
            if (db.User_Update(user)) return user;
            else return null;
        }
    }
}
