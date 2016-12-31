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

        private PasswordManager.Database.Users Users;
        private PasswordManager.Database.Passwords Passwords;
        private PasswordManager.Database.Settings Settings;
        private PasswordManager.Database.PasswordOptions PasswordOptions;

        // Constructor is 'protected'
        protected Database()
        {
            Users = new PasswordManager.Database.Users();
            Passwords = new PasswordManager.Database.Passwords();
            Settings = new PasswordManager.Database.Settings();
            PasswordOptions = new PasswordManager.Database.PasswordOptions();
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

        public bool Password_Add(List<Password> passwords, User user)
        {
            return Passwords.Insert(passwords, user);
        }

        public List<Password> Password_Select(int userID)
        {
            return Passwords.Select(userID);
        }

        public List<Password> Password_Select(User user)
        {
            return Passwords.Select(user);
        }
        
        public bool Password_Update(Password password, User user)
        {
            return Passwords.Update(user, password);
        }

        public bool Settings_Add(PasswordManager.Entities.Settings settings, User user)
        {
            return Settings.Insert(settings, user);
        }

        public PasswordManager.Entities.Settings Settings_Select(User user)
        {
            return Settings.Select(user);
        }

        public PasswordManager.Entities.Settings Settings_Select(int userID)
        {
            return Settings.Select(userID);
        }
        
        public bool Settings_Update(PasswordManager.Entities.Settings settings, User user)
        {
            return Settings.Update(settings, user);
        }

        public bool PasswordOptions_Add(PasswordManager.Entities.PasswordOptions passwordOptions, PasswordManager.Entities.Settings settings)
        {
            return PasswordOptions.Insert(passwordOptions, settings);
        }

        public PasswordManager.Entities.PasswordOptions PasswordOptions_Select(PasswordManager.Entities.Settings settings)
        {
            return PasswordOptions.Select(settings);
        }

        public bool PasswordOptions_Update(PasswordManager.Entities.Settings settings)
        {
            return PasswordOptions.Update(settings);
        }

        public bool Password_Delete(Password password, User user)
        {
            return Passwords.Delete(password, user);
        }
    }
}
