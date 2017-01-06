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
    /// <summary>
    /// Provides Validation for Different Entities and Objects in BearPass
    /// </summary>
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

        /// <summary>
        /// Determines wether the supplied User object is valid.
        /// </summary>
        /// <param name="user">User object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public bool User(User user)
        {
            //we should also check if user is authorized or exists -gul:0301171247
            //i think that would be heavy operation because i am calling this method in so many places. -gul:0401171150
            if (user != null)
            {
                if (Verifier.ID(user.ID) && Verifier.Email(user.Email) && Verifier.Text(user.Master))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied Password object is valid.
        /// </summary>
        /// <param name="password">Password object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
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

        /// <summary>
        /// Determines wether the supplied List of Password objects is valid.
        /// </summary>
        /// <param name="passwords">List of type Password object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public bool Passwords(List<Password> passwords)
        {
            if (passwords != null)
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
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied Settings object is valid.
        /// </summary>
        /// <param name="settings">Settings object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
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

        /// <summary>
        /// Determines wether the supplied PasswordOptions object is valid.
        /// </summary>
        /// <param name="passwordOptions">PasswordOptions object be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public bool PasswordOptions(PasswordOptions passwordOptions)
        {
            if (passwordOptions != null)
            {
                if (Verifier.ID(passwordOptions.ID) && Verifier.ID(passwordOptions.SettingsID))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Determines wether the supplied File path is valid.
        /// </summary>
        /// <param name="fileName">File Path be validated.</param>
        /// <returns>Boolean: True if Valid otherwise False.</returns>
        public bool File(string fileName)
        {
            if (Verifier.Text(fileName))
            {
                return System.IO.File.Exists(fileName);
            }
            else return false;
        }
    }
}
