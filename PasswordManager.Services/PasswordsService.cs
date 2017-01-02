using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class PasswordsService
    {
        private static PasswordsService _instance;

        protected PasswordsService()
        {
        }

        public static PasswordsService Instance()
        {
            if (_instance == null)
            {
                _instance = new PasswordsService();
            }

            return _instance;
        }
    }
}
