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

        public bool Exist(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                if (UsersData.Instance().Select(user) != null)
                    return true;
            }

            return false;
        }

        public User Register(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                //initilze a default empty list of passwords for this user.
                user.Passwords = new List<Password>();
                
                if (UsersData.Instance().Register(user, Globals.Defaults.Settings, Globals.Defaults.PasswordOptions) > 0)
                    return user;
            }

            return null;
        }

        public User Login(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                user = UsersData.Instance().Select(user);

                return user;
            }

            return user;
        }

        public User Update(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                user = UsersData.Instance().Update(user);

                return user;
            }

            else return null;
        }
    }
}
