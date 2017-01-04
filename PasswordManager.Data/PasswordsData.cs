using PasswordManager.Database;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data
{
    public class PasswordsData
    {
        private static PasswordsData _instance;

        private DB Database = DB.Instance();

        protected PasswordsData()
        {
        }

        public static PasswordsData Instance()
        {
            if (_instance == null)
            {
                _instance = new PasswordsData();
            }

            return _instance;
        }

        public PasswordOptions GetPasswordOptions(User user)
        {
            return Database.GetPasswordOptionsByID(user.ID);
        }

        public int Save(User user, Password password)
        {
            return Database.AddNewPassword(user.ID, password);
        }

        public int Save(User user, List<Password> passwords)
        {
            return Database.AddNewPasswords(user.ID, passwords);
        }

        public List<Password> GetUserPasswords(User user)
        {
            return Database.GetPasswordsByUserID(user.ID);
        }

        public int Update(User user, Password password)
        {
            return Database.UpdatePasswordByUserID(user.ID, password);
        }

        public int Update(User user, List<Password> passwords)
        {
            return Database.UpdatePasswordsByUserID(user.ID, passwords);
        }

        public int Delete(User user, Password password)
        {
            return Database.DeletePasswordByID(user.ID, password.ID);
        }
    }
}
