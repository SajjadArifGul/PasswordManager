using PasswordManager.Entities;
using PasswordManager.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class ValidationService
    {
        private static ValidationService _instance;

        protected ValidationService()
        {
        }

        public static ValidationService Instance()
        {
            if (_instance == null)
            {
                _instance = new ValidationService();
            }

            return _instance;
        }

        public bool User(User user)
        {
            if (user != null)
            {
                if (Verifier.Email(user.Email) && Verifier.Text(user.Master))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
