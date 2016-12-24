using PasswordManager.Database;
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

        private Users Users;
        private Passwords Passwords;
        
        // Constructor is 'protected'
        protected Database()
        {
            Users = new Users();
            Passwords = new Passwords();
        }

        public static Database Instance()
        {
            if (_instance == null)
            {
                _instance = new Database();
            }

            return _instance;
        }

        public bool User_Add(User user)
        {
            return Users.Insert(user);
        }

        public User User_Select(int userID)
        {
            return Users.Select(userID);
        }

        public User User_Select(User user)
        {
            return Users.Select(user);
        }

        public bool User_Update(User user)
        {
            return Users.Update(user);
        }

        public bool Password_Add(Password password, User user)
        {
            return Passwords.Insert(password, user);
        }

        public List<Password> Password_Select(int userID)
        {
            return Passwords.Select(userID);
        }

        public List<Password> Password_Select(User user)
        {
            return Passwords.Select(user);
        }
        
        public bool Password_Update(Password password)
        {
            return Passwords.Update(password);
        }


        //public bool AddUser(User user)
        //{
        //    foreach (User u in Users)
        //    {
        //        if ((u.Username == user.Username) || (u.Email == user.Email))
        //        {
        //            //the user with same credentials exists. Cant add user.
        //            return false;
        //        }
        //    }

        //    Users.Add(user);
        //    return true;
        //}


        //public User FindUser(User user)
        //{
        //    User UserToBeReturned = null;

        //    foreach (User ExistingUser in Users)
        //    {
        //        if (ExistingUser.Email == user.Email)
        //        {
        //            if (ExistingUser.Master == user.Master)
        //            {
        //                UserToBeReturned = ExistingUser;
        //            }
        //        }
        //    }

        //    return UserToBeReturned;
        //}

        //public Password AddPassword(User user, Password password)
        //{
        //    Users.Where(u=>u.Email == user.Email).FirstOrDefault().Passwords.Add(password);
        //    return password;
        //}
    }
}
