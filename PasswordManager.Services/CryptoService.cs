using PasswordManager.Entities;
using PasswordManager.Globals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to Encryption and Decryption functions.
    /// </summary>
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

        /// <summary>
        /// Encrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="password">Password to be encrypted.</param>
        /// <returns>Password: The Password in encrypted format.</returns>
        public Task<Password> EncryptUserPasswordAsync(User user, Password password)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Encrypt(password.Name, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Encrypt(password.Email, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Encrypt(password.Username, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Encrypt(password.Website, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Encrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                return password;
            });
        }


        /// <summary>
        /// Encrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="password">Password to be encrypted.</param>
        /// <returns>Password: The Password in encrypted format.</returns>
        public Password EncryptUserPassword(User user, Password password)
        {
            if (Verifier.Text(password.Name))
            {
                password.Name = Gulipso.Gulipso.Encrypt(password.Name, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            }
            if (Verifier.Text(password.Email))
            {
                password.Email = Gulipso.Gulipso.Encrypt(password.Email, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            }
            if (Verifier.Text(password.Username))
            {
                password.Username = Gulipso.Gulipso.Encrypt(password.Username, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            }
            if (Verifier.Text(password.Website))
            {
                password.Website = Gulipso.Gulipso.Encrypt(password.Website, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            }
            if (Verifier.Text(password.Text))
            {
                password.Text = Gulipso.Gulipso.Encrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            }
            return password;
        }

        /// <summary>
        /// Encrypts the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="passwords">List of Passwords to be encrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in encrypted format.</returns>
        public Task<List<Password>> EncryptUserPasswordsAsync(User user, List<Password> passwords)
        {
            return Task.Factory.StartNew(() =>
            {
                List<Password> EncryptedPasswords = new List<Password>();

                foreach (Password password in passwords)
                {
                    EncryptedPasswords.Add(EncryptUserPassword(user, password));
                }

                return EncryptedPasswords;
            });
        }

        /// <summary>
        /// Encrypts the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Encrypted.</param>
        /// <param name="passwords">List of Passwords to be encrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in encrypted format.</returns>
        public List<Password> EncryptUserPasswords(User user, List<Password> passwords)
        {
            List<Password> EncryptedPasswords = new List<Password>();

                foreach (Password password in passwords)
                {
                    EncryptedPasswords.Add(EncryptUserPassword(user, password));
                }

                return EncryptedPasswords;
        }

        /// <summary>
        /// Decrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="password">Password to be Decrypted.</param>
        /// <returns>Password: The Password in Decrypted format.</returns>
        public Task<Password> DecryptUserPasswordAsync(User user, Password password)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Decrypt(password.Name, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Decrypt(password.Email, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Decrypt(password.Username, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Decrypt(password.Website, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Decrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
                return password;
            });
        }

        /// <summary>
        /// Decrypts the Password for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="password">Password to be Decrypted.</param>
        /// <returns>Password: The Password in Decrypted format.</returns>
        public Password DecryptUserPassword(User user, Password password)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Decrypt(password.Name, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Decrypt(password.Email, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Decrypt(password.Username, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Decrypt(password.Website, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Decrypt(password.Text, user.Master, Globals.Defaults.InitVector, Globals.Defaults.KeySize);
            return password;
        }

        /// <summary>
        /// Decrypted the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="passwords">List of Passwords to be Decrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in Decrypted format.</returns>
        public Task<List<Password>> DecryptUserPasswordsAsync(User user, List<Password> passwords)
        {
            return Task.Factory.StartNew(() =>
            {
                List<Password> decryptedPasswords = new List<Password>();

                foreach (var password in passwords)
                {
                    decryptedPasswords.Add(DecryptUserPassword(user, password));
                }
                return decryptedPasswords;
            });
        }

        /// <summary>
        /// Decrypted the List of Passwords for supplied User.
        /// </summary>
        /// <param name="user">User for whom the Password is to be Decrypted.</param>
        /// <param name="passwords">List of Passwords to be Decrypted.</param>
        /// <returns>List of Passwords: The List of Passwords in Decrypted format.</returns>
        public List<Password> DecryptUserPasswords(User user, List<Password> passwords)
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
