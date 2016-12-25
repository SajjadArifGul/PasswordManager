using PasswordManager.DAL;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BLL
{
    public class Passwords
    {
        Database db = Database.Instance();

        /// <summary>
        /// Generates a new Random Password.
        /// </summary>
        /// <param name="options">Password Options for Generation.</param>
        /// <returns></returns>
        public string New(Entities.PasswordOptions options)
        {
            //maybe we dont have any pasword options for current user.
            if (options == null) options = new Entities.PasswordOptions()
            {
                AllowLowercaseCharacters = Globals.Defaults.AllowLowercaseCharacters,
                AllowUppercaseCharacters = Globals.Defaults.AllowUppercaseCharacters,
                AllowNumberCharacters = Globals.Defaults.AllowNumberCharacters,
                AllowSpecialCharacters = Globals.Defaults.AllowSpecialCharacters,
                AllowUnderscoreCharacters = Globals.Defaults.AllowUnderscoreCharacters,
                AllowSpaceCharacters = Globals.Defaults.AllowSpaceCharacters,
                AllowOtherCharacters = Globals.Defaults.AllowOtherCharacters,
                RequireLowercaseCharacters = Globals.Defaults.RequireLowercaseCharacters,
                RequireUppercaseCharacters = Globals.Defaults.RequireUppercaseCharacters,
                RequireNumberCharacters = Globals.Defaults.RequireNumberCharacters,
                RequireSpecialCharacters = Globals.Defaults.RequireSpecialCharacters,
                RequireUnderscoreCharacters = Globals.Defaults.RequireUnderscoreCharacters,
                RequireSpaceCharacters = Globals.Defaults.RequireSpaceCharacters,
                RequireOtherCharacters = Globals.Defaults.RequireOtherCharacters,
                MinimumCharacters = Globals.Defaults.MinimumCharacters,
                MaximumCharacters = Globals.Defaults.MaximumCharacters
            }; 

            // Make a list of allowed characters.
            string allowed = "";

            if (options.AllowLowercaseCharacters) allowed += options.LowercaseCharacters;
            if (options.AllowUppercaseCharacters) allowed += options.UppercaseCharacters;
            if (options.AllowNumberCharacters) allowed += options.NumberCharacters;
            if (options.AllowSpecialCharacters) allowed += options.SpecialCharacters;
            if (options.AllowUnderscoreCharacters) allowed += options.UnderscoreCharacters;
            if (options.AllowSpaceCharacters) allowed += options.SpaceCharacters;
            if (options.AllowOtherCharacters) allowed += options.OtherCharacters;
            
            Random random = new Random();

            int RequiredLength = random.Next(options.MinimumCharacters, options.MaximumCharacters);

            // Satisfy requirements.
            string password = "";

            if (options.RequireLowercaseCharacters &&
                (password.IndexOfAny(options.LowercaseCharacters.ToCharArray()) == -1))
                password += RandomChar(options.LowercaseCharacters, random);
            if (options.RequireUppercaseCharacters &&
                (password.IndexOfAny(options.UppercaseCharacters.ToCharArray()) == -1))
                password += RandomChar(options.UppercaseCharacters, random);
            if (options.RequireNumberCharacters &&
                (password.IndexOfAny(options.NumberCharacters.ToCharArray()) == -1))
                password += RandomChar(options.NumberCharacters, random);
            if (options.RequireSpecialCharacters &&
                (password.IndexOfAny(options.SpecialCharacters.ToCharArray()) == -1))
                password += RandomChar(options.SpecialCharacters, random);
            if (options.RequireUnderscoreCharacters &&
                (password.IndexOfAny(options.UnderscoreCharacters.ToCharArray()) == -1))
                password += options.UnderscoreCharacters;
            if (options.RequireSpaceCharacters &&
                (password.IndexOfAny(options.SpaceCharacters.ToCharArray()) == -1))
                password += options.SpaceCharacters;
            if (options.RequireOtherCharacters &&
                (password.IndexOfAny(options.OtherCharacters.ToCharArray()) == -1))
                password += options.OtherCharacters;

            // Add the remaining characters randomly.
            while (password.Length < RequiredLength)
                password += allowed.Substring(
                    random.Next(0, allowed.Length - 1), 1);

            // Randomize (to mix up the required characters at the front).
            password = RandomizeString(password, random);

            return password;
        }

        public List<Password> Get(Entities.User user)
        {
            return db.Password_Select(user);
        }

        // Return a random character from a string.
        private string RandomChar(string str, Random random)
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

        /// <summary>
        /// Save Password.
        /// </summary>
        /// <param name="user">User to Save Password to.</param>
        /// <param name="password">Password to be Saved.</param>
        /// <returns>The new Password</returns>
        public Password Save(Entities.User user, Entities.Password password)
        {
            if (db.Password_Add(password, user))
            {
                return password;
            }
            else return null;
        }

        public bool Same(string oldPass, string newPass)
        {
            return string.Equals(oldPass, newPass);
        }

        public List<Password> Search(User user, string Search, string LooksFor, string Options)
        {
            List<Password> AllPasswords = Get(user);
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

        public List<Password> ReEncrypter(User user, string NewMaster)
        {
            //use the gulipso to re encrypt here & then update all passwords in db

            //for now
            return user.Passwords;
        }

        /// <summary>
        /// Save Password.
        /// </summary>
        /// <param name="user">User to Save Password to.</param>
        /// <param name="password">Password to be Saved.</param>
        /// <returns>The new Password</returns>
        public Password Update(Entities.User user, Entities.Password password)
        {
            if (db.Password_Update(password, user))
            {
                return password;
            }
            else return null;
        }

        public List<Password> Update(Entities.User user, List<Entities.Password> passwords)
        {
            List<Password> UpdatedPasswords = new List<Password>();

            //we should use transactions & try catch here
            //or may be a new function with transactions in Database layer for a List of passwords
            foreach(Password password in passwords)
            {
                if (db.Password_Update(password, user))
                {
                    UpdatedPasswords.Add(password);
                }
            }

            return UpdatedPasswords;
        }
    }
}