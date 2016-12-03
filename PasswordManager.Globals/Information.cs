using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Globals
{
    public static class Information
    {
        public static string AppName { get
            {
                return "BearPass";
            }
        }

        public static string AppMotto
        {
            get
            {
                return "Personal Password Manager";
            }
        }

        public static string AppDetails1
        {
            get
            {
                return AppName + @" is a password manager that helps you secure and organize your passwords"
                               + @" by using the most advanced and secure encryption alogorithms (Rijndael/AES) to encryp your passwords informartion."
                               + @" So no need to remember all those zillions of passwords for each and every website. "
                        + AppName + @" is an OFFLINE password manager so you can have complete control of your passwords. It also comes with a random password generator to generate unique and strong passwords.";
            }
        }

        public static string AppDetails2
        {
            get
            {
                return @"My Name is Sajjad Arif Gul and I am the developer of " + AppName 
                        + @". Why did I develop this software when I could just used other brilliant password managers available on the internet?"
                        + @" Sure, the reason is I wanted to know and control the process that goes behind the app interface."
                        + AppName + @" keeps all passwords in encrypted format in a file stored on the user computer unlike"
                        + @" most other password managers on the cloud. "
                        + AppName + @" is free to use software and provided as is without any warranty.";
            }
        }

        public static string Developer
        {
            get
            {
                return "Sajjad Arif Gul";
            }
        }

        public static string Designation
        {
            get
            {
                return "Software Engineer";
            }
        }

        public static string WebsiteName
        {
            get
            {
                return "www.sajjadgul.com";
            }
        }

        public static string WebsiteLink
        {
            get
            {
                return "http://www.sajjadgul.com/";
            }
        }

        public static string FacebookLink
        {
            get
            {
                return "https://www.facebook.com/imSajjadArifGul";
            }
        }
        public static string TwitterLink
        {
            get
            {
                return "https://twitter.com/SajjadArifGul";
            }
        }

        public static string GooglePlus
        {
            get
            {
                return "https://plus.google.com/u/0/104274199588729902880";
            }
        }
        
        public static string LinkedInLink
        {
            get
            {
                return "https://www.linkedin.com/in/sajjadarifgul";
            }
        }

        public static string GitHubSourceLink
        {
            get
            {
                return "https://github.com/SajjadArifGul/PasswordManager";
            }
        }
    }
}
