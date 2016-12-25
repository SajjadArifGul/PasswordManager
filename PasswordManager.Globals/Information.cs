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
                        + @" Sure, the reason is I wanted to know and control the process that goes behind the app interface. "
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

        public static string MasterPasswordNote
        {
            get
            {
                return AppName + @" uses Master Password to encrypt all your passwords. By default your login password is set as Master Password but if you enable Master Password, your login password will only be used for login purposes and the new Master Password will be used for encryption. "
                       + AppName + " does not save your Master Password. If you forgot your Master Password, you will NOT be able to recover your Passwords.";

            }
        }

        public static string MasterPasswordEnabled
        {
            get
            {
                return AppName + @" uses Master Password to encrypt all your passwords. By default your login password is set as Master Password but if you enable Master Password, your login password will only be used for login purposes and the new Master Password will be used for encryption. "
                       + AppName + " does not save your Master Password. If you forgot your Master Password, you will NOT be able to Recover your Passwords.";

            }
        }

        public static string MasterPasswordDisabled
        {
            get
            {
                return AppName + @" uses Master Password to encrypt all your passwords. If you disable your Master Password, "
                       + AppName + "will use your Login Password for Encryption. If you forgot your Login Password, you will NOT be able to Login or Recover your Passwords.";
            }
        }

        public static string Guidelines
        {
            get
            {
                return @"To prevent your passwords from being hacked by social engineering and keeping your online accounts safe, you should follow these guidelines:

1. Do not use the same password, security question and answer for multiple important accounts.
2. Use a password that has at least 16 characters, use at least one number, one uppercase letter, one lowercase letter and one special symbol.
3. Do not use the names of your families, friends or pets in your passwords.
4. Do not use postcodes, house numbers, phone numbers, birthdates, ID card numbers, social security numbers, and so on in your passwords.
5. Do not use any dictionary word in your passwords.
6. Do not use two or more similar passwords which most of their characters are same, for example, ilovefreshflowersMac, ilovefreshflowersDropBox, since if one of these passwords is stolen, then it means that all of these passwords are stolen.
7. Do not use something that can be cloned(but you can't change ) as your passwords, such as your fingerprints.
8. Do not let your Web browsers(FireFox, Chrome, Safari, Opera, IE) store your passwords, since all passwords saved in Web browsers can be revealed easily.
9. Do not log in to important accounts on the computers of others, or when connected to a public Wi-Fi hotspot, Tor, free VPN or web proxy.
10. Turn on 2-step authentication whenever possible.
11. Encrypt and backup your passwords to different locations.
12. Do not tell your passwords to anybody in the email.";
            }
        }
    }
}
