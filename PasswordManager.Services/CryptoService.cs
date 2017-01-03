using PasswordManager.Entities;
using PasswordManager.Globals;
using PasswordManager.Gulipso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class CryptoService
    {
        private static CryptoService _instance;

        protected CryptoService()
        {
        }

        public static CryptoService Instance()
        {
            if (_instance == null)
            {
                _instance = new CryptoService();
            }

            return _instance;
        }

        public Password Encrypt(User user, Password password)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Encrypt(password.Name, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Encrypt(password.Email, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Encrypt(password.Username, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Encrypt(password.Website, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Encrypt(password.Text, user.Master, Globals.Defaults.initVector, 256);
            return password;
        }
        
        public List<Password> Encrypt(User user, List<Password> passwords)
        {
            List<Password> EncryptedPasswords = new List<Password>();

            foreach (Password password in passwords)
            {
                EncryptedPasswords.Add(Encrypt(user, password));
            }

            return EncryptedPasswords;
        }

        public Password Decrypt(User user, Password password)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Decrypt(password.Name, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Decrypt(password.Email, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Decrypt(password.Username, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Decrypt(password.Website, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Decrypt(password.Text, user.Master, Globals.Defaults.initVector, 256);
            return password;
        }

        internal List<Password> Decrypt(User user, List<Password> passwords)
        {
            List<Password> decryptedPasswords = new List<Password>();

            foreach (var password in passwords)
            {
                decryptedPasswords.Add(Decrypt(user, password));
            }
            return decryptedPasswords;
        }
    }
}
