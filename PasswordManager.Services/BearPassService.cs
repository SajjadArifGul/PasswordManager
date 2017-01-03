using PasswordManager.Entities;
using PasswordManager.Filer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
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

        public List<Password> ImportPasswords(string FileName)
        {
            if (ValidationService.Instance().File(FileName))
            {
                return Filer.Filer.Import(FileName);
            }
            else return null;
        }

        public bool ExportPasswords(List<Password> Passwords, string FileName)
        {
            if (ValidationService.Instance().File(FileName))
            {
                return Filer.Filer.Export(Passwords, FileName);
            }
            else return false;
        }
    }
}
