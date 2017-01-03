using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManager.Globals
{
    public static class Verifier
    {
        public static bool Email(string Email)
        {
            if (Text(Email))
            {
                var EmailRegex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                return EmailRegex.IsMatch(Email);
            }
            else return false;
        }

        public static bool Text(string Text)
        {
            if (string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text) || Text == string.Empty || Text == " ")
            {
                return false;
            }
            else return true;
        }

        public static bool ID(int ID)
        {
            //this need a better implementation. -gul:0301171550
            try
            {
                ID = Convert.ToInt32(ID);

                if (ID > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
