using PasswordManager.DAL;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BLL
{
    public class Users
    {
        Database db;

        public Users()
        {
            db = Database.Instance();
        }

        public User Register(User user)
        {
            if (db.User_Add(user))
            {
                //its a new user. Add default settings and password options for it.
                db.Settings_Add(new Entities.Settings()
                {
                    UserID = user.ID, //a small blunder leads to a fuckin headache
                    DateTimeFormat = Globals.Defaults.DateTimeFormat,
                    ShowEmailColumn = Globals.Defaults.ShowEmailColumn,
                    ShowUsernameColumn = Globals.Defaults.ShowUsernameColumn,
                    ShowPasswordColumn = Globals.Defaults.ShowPasswordColumn,
                    PasswordOptions = new Entities.PasswordOptions()
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
                    }
                }, user);

                //get these settings for user.
                user.Settings = db.Settings_Select(user);

                //initilze a default empty list of passwords for this user.
                user.Passwords = new List<Password>();

                return user;
            }
            else return null;
        }

        public User Exist(User user)
        {
            User returnedUser = db.User_Select(user);

            if (returnedUser.Master == user.Master)
                return returnedUser;
            else return null;
        }

        public User Login(User user)
        {
            User returnedUser = Exist(user);

            if (returnedUser != null)
            {
                //now populate the user with passwords and settings and related stuff
                Passwords passwords = new Passwords();
                returnedUser.Passwords = passwords.Get(returnedUser);
                
                returnedUser.Settings = db.Settings_Select(returnedUser);

                return returnedUser;
            }

            return null;
        }

        public User Update(User user)
        {
            if (db.User_Update(user)) return user;
            else return null;
        }
    }
}
