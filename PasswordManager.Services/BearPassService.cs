using PasswordManager.Entities;
using PasswordManager.Filer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides Access to Misellanious Functions and Data.
    /// </summary>
    public class BearPassService
    {
        private static BearPassService _instance;

        protected BearPassService()
        {
        }

        public static BearPassService Instance()
        {
            if (_instance == null)
            {
                _instance = new BearPassService();
            }

            return _instance;
        }

        /// <summary>
        /// Imports Passwords from the Supplied File
        /// </summary>
        /// <param name="FileName">File from which Passwords to Imported.</param>
        /// <returns>List of Passwords: List of Passwords imported from File.</returns>
        public Task<List<Password>> ImportPasswordsAsync(string FileName)
        {
            return Task.Factory.StartNew(() =>
            {
                if (ValidationService.Instance().File(FileName))
                {
                    return Filer.Filer.ImportFromFile(FileName);
                }
                else return null;
            });
        }

        /// <summary>
        /// Exports Passwords to the Supplied File
        /// </summary>
        /// <param name="Passwords">Passwords to be exported</param>
        /// <param name="FileName">File to which Passwords are to be exported.</param>
        /// <returns>Boolean: True if Passwords are exported otherwise False.</returns>
        public Task<bool> ExportPasswordsAsync(List<Password> Passwords, string FileName)
        {
            return Task.Factory.StartNew(() =>
            {
                return Filer.Filer.ExportToFile(Passwords, FileName);
            });
        }
    }
}
