using PasswordManager.Entities;
using PasswordManager.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            //we should also check if user is authorized or exists -gul:0301171247
            if (user != null)
            {
                if (Verifier.ID(user.ID) && Verifier.Text(user.Username) && Verifier.Email(user.Email) && Verifier.Text(user.Master))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool Settings(Settings settings)
        {
            if (settings != null)
            {
                if (Verifier.ID(settings.ID) && Verifier.ID(settings.UserID))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool File(string FileName)
        {
            if (Verifier.Text(FileName))
            {
                return System.IO.File.Exists(FileName);
            }
            else return false;
        }
        
        public bool Password(Password password)
        {
            if (password != null)
            {
                if (Verifier.Email(password.Email) && Verifier.Text(password.Text))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        internal bool PasswordOptions(PasswordOptions passwordOptions)
        {
            throw new NotImplementedException();
        }

        internal bool Passwords(List<Password> passwords)
        {
            bool result = true;

            foreach (Password password in passwords)
            {
                if (password != null)
                {
                    if (!Verifier.Email(password.Email) || !Verifier.Text(password.Text))
                    {
                        result = false;
                    }
                }
                else result = false;
            }

            return result;
        }
    }
}
