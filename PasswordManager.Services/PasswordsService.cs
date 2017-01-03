using PasswordManager.Data;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class PasswordsService
    {
        private static PasswordsService _instance;

        protected PasswordsService()
        {
        }

        public static PasswordsService Instance()
        {
            if (_instance == null)
            {
                _instance = new PasswordsService();
            }

            return _instance;
        }

        public List<Password> GetAllPasswords(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                List<Password> passwords = CryptoService.Instance().Decrypt(user, PasswordsData.Instance().Select(user));

                if (ValidationService.Instance().Passwords(passwords))
                {
                    return passwords;
                }
                else return null;
            }
            else return null;
        }

        public Password SaveNewPassword(User user, Password password)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Password(password))
            {
                if (PasswordsData.Instance().Save(user, CryptoService.Instance().Encrypt(user, password)) > 0)
                {
                    return password;
                }
                else return null;
            }
            else return null;
        }

        public List<Password> SaveNewPasswords(User user, List<Password> passwords)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Passwords(passwords))
            {
                if (PasswordsData.Instance().Save(user, CryptoService.Instance().Encrypt(user, passwords)) > 0)
                {
                    return passwords;
                }
                else return null;
            }
            else return null;
        }

        public Password UpdatePassword(User user, Password password)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Password(password))
            {
                if (PasswordsData.Instance().Update(user, CryptoService.Instance().Encrypt(user, password)) > 0)
                {
                    return password;
                }
                else return null;
            }
            else return null;
        }

        public List<Password> UpdatePasswords(User user, List<Password> passwords)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Passwords(passwords))
            {
                if (PasswordsData.Instance().Update(user, CryptoService.Instance().Encrypt(user, passwords)) > 0)
                {
                    return passwords;
                }
                else return null;
            }
            else return null;
        }

        public bool RemovePassword(User user, Password password)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Password(password))
            {
                /* No need for decrypting password. We only need ID in the Delete method for work */
                if (PasswordsData.Instance().Delete(user, password) > 0)
                    return true;
                else return false;
            }
            else return false;            
        }

        public List<Password> Search(User user, string Search, string LooksFor, string Options)
        {
            //we can send the search query to database -gul:0301171513

            List<Password> AllPasswords = GetAllPasswords(user);
            List<Password> searchedPasswords = null;

            if (string.IsNullOrEmpty(Search))
            {
                return AllPasswords;
            }
            else
            {
                switch (Options)
                {
                    case "Contains":
                        if (LooksFor == "Username")
                        {
                            searchedPasswords = AllPasswords.Where(p => p.Username.ToLower().Contains(Search.ToLower())).ToList();
                        }
                        else if (LooksFor == "Email")
                        {
                            searchedPasswords = AllPasswords.Where(p => p.Email.ToLower().Contains(Search.ToLower())).ToList();
                        }
                        else
                        {
                            searchedPasswords = AllPasswords.Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();
                        }
                        break;
                    case "Equals":
                        if (LooksFor == "Username")
                        {
                            searchedPasswords = AllPasswords.Where(p => p.Username.ToLower().Equals(Search.ToLower())).ToList();
                        }
                        else if (LooksFor == "Email")
                        {
                            searchedPasswords = AllPasswords.Where(p => p.Email.ToLower().Equals(Search.ToLower())).ToList();
                        }
                        else
                        {
                            searchedPasswords = AllPasswords.Where(p => p.Name.ToLower().Equals(Search.ToLower())).ToList();
                        }
                        break;
                }
                return searchedPasswords;
            }
        }

        public string GeneratePassword(User user)
        {
            PasswordOptions passwordOptions = null;

            if (ValidationService.Instance().User(user))
            {
                passwordOptions = PasswordsData.Instance().GetPasswordOptions(user);
            }
            else passwordOptions = Globals.Defaults.PasswordOptions;

            // Make a list of allowed characters.
            string allowed = "";

            if (passwordOptions.AllowLowercaseCharacters) allowed += passwordOptions.LowercaseCharacters;
            if (passwordOptions.AllowUppercaseCharacters) allowed += passwordOptions.UppercaseCharacters;
            if (passwordOptions.AllowNumberCharacters) allowed += passwordOptions.NumberCharacters;
            if (passwordOptions.AllowSpecialCharacters) allowed += passwordOptions.SpecialCharacters;
            if (passwordOptions.AllowUnderscoreCharacters) allowed += passwordOptions.UnderscoreCharacters;
            if (passwordOptions.AllowSpaceCharacters) allowed += passwordOptions.SpaceCharacters;
            if (passwordOptions.AllowOtherCharacters) allowed += passwordOptions.OtherCharacters;

            Random random = new Random();

            int RequiredLength = random.Next(passwordOptions.MinimumCharacters, passwordOptions.MaximumCharacters);

            // Satisfy requirements.
            string password = "";

            if (passwordOptions.RequireLowercaseCharacters &&
                (password.IndexOfAny(passwordOptions.LowercaseCharacters.ToCharArray()) == -1))
                password += RandomCharacter(passwordOptions.LowercaseCharacters, random);
            if (passwordOptions.RequireUppercaseCharacters &&
                (password.IndexOfAny(passwordOptions.UppercaseCharacters.ToCharArray()) == -1))
                password += RandomCharacter(passwordOptions.UppercaseCharacters, random);
            if (passwordOptions.RequireNumberCharacters &&
                (password.IndexOfAny(passwordOptions.NumberCharacters.ToCharArray()) == -1))
                password += RandomCharacter(passwordOptions.NumberCharacters, random);
            if (passwordOptions.RequireSpecialCharacters &&
                (password.IndexOfAny(passwordOptions.SpecialCharacters.ToCharArray()) == -1))
                password += RandomCharacter(passwordOptions.SpecialCharacters, random);
            if (passwordOptions.RequireUnderscoreCharacters &&
                (password.IndexOfAny(passwordOptions.UnderscoreCharacters.ToCharArray()) == -1))
                password += passwordOptions.UnderscoreCharacters;
            if (passwordOptions.RequireSpaceCharacters &&
                (password.IndexOfAny(passwordOptions.SpaceCharacters.ToCharArray()) == -1))
                password += passwordOptions.SpaceCharacters;
            if (passwordOptions.RequireOtherCharacters &&
                (password.IndexOfAny(passwordOptions.OtherCharacters.ToCharArray()) == -1))
                password += passwordOptions.OtherCharacters;

            // Add the remaining characters randomly.
            while (password.Length < RequiredLength)
                password += allowed.Substring(
                    random.Next(0, allowed.Length - 1), 1);

            // Randomize (to mix up the required characters at the front).
            password = RandomizeString(password, random);

            return password;
        }

        // Return a random character from a string.
        private string RandomCharacter(string str, Random random)
        {
            return str.Substring(random.Next(0, str.Length - 1), 1);
        }

        // Return a random permutation of a string.
        private string RandomizeString(string str, Random random)
        {
            string result = "";
            while (str.Length > 0)
            {
                // Pick a random character.
                int i = random.Next(0, str.Length - 1);
                result += str.Substring(i, 1);
                str = str.Remove(i, 1);
            }
            return result;
        }

        public bool IsSame(string oldPass, string newPass)
        {
            //this need a little refactoring in a more better way i think. -gul:0301171513
            return string.Equals(oldPass, newPass);
        }
    }
}
