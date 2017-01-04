using PasswordManager.Data;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class UsersService
    {
        private static UsersService _instance;
        
        protected UsersService()
        {
        }

        public static UsersService Instance()
        {
            if (_instance == null)
            {
                _instance = new UsersService();
            }

            return _instance;
        }

        public bool UserExist(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                if (UsersData.Instance().SelectUser(user) != null)
                    return true;
                else return false;
            }
            else return false;
        }

        public User RegisterUser(User user)
        {
            if (ValidationService.Instance().User(user))
            {   
                if (UsersData.Instance().AddNewUser(user, Globals.Defaults.Settings, Globals.Defaults.PasswordOptions) > 0)
                {
                    //initilze a default empty list of passwords for this user.
                    user.Passwords = new List<Password>();
                    user.Settings = Globals.Defaults.Settings;
                    user.Settings.PasswordOptions = Globals.Defaults.PasswordOptions;

                    return user;
                }
                else return null;
            }
            else return null;
        }

        public User LoginUser(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                return UsersData.Instance().SelectUser(user);
            }
            else return null;
        }

        public User UpdateUser(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                if (UsersData.Instance().UpdateUser(user) > 0)
                {
                    return user;
                }
                else return user;
            }
            else return null;
        }

        public User PopulateUserData(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                user.Passwords = PasswordsData.Instance().GetUserPasswords(user);
                user.Settings = SettingsData.Instance().GetUserSettings(user);
                user.Settings.PasswordOptions = PasswordOptionsData.Instance().GetPasswordOptionsBySettings(user.Settings);

                return user;
            }
            else return null;
        }
    }
}
