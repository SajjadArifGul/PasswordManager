using PasswordManager.Entities;
using PasswordManager.Globals;
using System.Collections.Generic;

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

        public Password EncryptUserPassword(User user, Password password)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Encrypt(password.Name, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Encrypt(password.Email, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Encrypt(password.Username, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Encrypt(password.Website, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Encrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            return password;
        }
        
        public List<Password> EncryptUserPasswords(User user, List<Password> passwords)
        {
            List<Password> EncryptedPasswords = new List<Password>();

            foreach (Password password in passwords)
            {
                EncryptedPasswords.Add(EncryptUserPassword(user, password));
            }

            return EncryptedPasswords;
        }

        public Password DecryptUserPassword(User user, Password password)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Decrypt(password.Name, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Decrypt(password.Email, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Decrypt(password.Username, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Decrypt(password.Website, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Decrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            return password;
        }

        internal List<Password> DecryptUserPasswords(User user, List<Password> passwords)
        {
            List<Password> decryptedPasswords = new List<Password>();

            foreach (var password in passwords)
            {
                decryptedPasswords.Add(DecryptUserPassword(user, password));
            }
            return decryptedPasswords;
        }
    }
}
