using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data
{
    public class UsersData
    {
        private static UsersData _instance;

        protected UsersData()
        {
        }

        public static UsersData Instance()
        {
            if (_instance == null)
            {
                _instance = new UsersData();
            }

            return _instance;
        }

        public int Register(User user, Settings settings, PasswordOptions passwordOptions)
        {

            return 0;
        }

        public User Select(User user)
        {

            return user;
        }

        public User Update(User user)
        {

            return user;
        }
    }
}
