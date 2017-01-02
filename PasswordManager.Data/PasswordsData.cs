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
            throw new NotImplementedException();
        }

        public Password Save(User user, Password password)
        {
            throw new NotImplementedException();
        }

        public List<Password> Select(User user)
        {
            throw new NotImplementedException();
        }
    }
}
