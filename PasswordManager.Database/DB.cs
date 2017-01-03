using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;

namespace PasswordManager.Database
{
    public class DB
    {
        private static DB _instance;
        private string ConnectionString;

        protected DB()
        {
            ConnectionString = Properties.Settings.Default["PasswordManagerDBConnection"].ToString();
        }

        public static DB Instance()
        {
            if (_instance == null)
            {
                _instance = new DB();
            }

            return _instance;
        }

        public int AddNewUser(Entities.User user, Entities.Settings settings, Entities.PasswordOptions passwordOptions)
        {
            throw new NotImplementedException();
        }

        public PasswordOptions GetPasswordOptionsByID(int userID)
        {
            throw new NotImplementedException();
        }

        public int AddNewPassword(int userID, Password password)
        {
            throw new NotImplementedException();
        }

        public int AddNewPasswords(int iD, List<Password> passwords)
        {
            throw new NotImplementedException();
        }

        public List<Password> GetPasswordsByUserID(int iD)
        {
            throw new NotImplementedException();
        }

        public int UpdatePasswordByUserID(int iD, Password password)
        {
            throw new NotImplementedException();
        }

        public int UpdatePasswordsByUserID(int iD, List<Password> passwords)
        {
            throw new NotImplementedException();
        }

        public int DeletePasswordByID(int iD1, int iD2)
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(int iD)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSettings(Entities.User user, Entities.Settings settings)
        {
            throw new NotImplementedException();
        }
    }
}
