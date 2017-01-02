using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class SettingsService
    {
        private static SettingsService _instance;

        protected SettingsService()
        {
        }

        public static SettingsService Instance()
        {
            if (_instance == null)
            {
                _instance = new SettingsService();
            }

            return _instance;
        }
    }
}
