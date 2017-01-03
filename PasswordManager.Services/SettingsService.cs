using PasswordManager.Data;
using PasswordManager.Entities;
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

        public User UpdateSettings(User user, Settings settings)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Settings(settings) && ValidationService.Instance().PasswordOptions(passwordOptions))
            {
                if (SettingsData.Instance().UpdateSettings(user, settings) > 0)
                {
                    user.Settings = settings;

                    return user;
                }
                else return null; ;
            }
            else return null;
        }

        public User UpdatePasswordOptions(User user, Settings settings, PasswordOptions passwordOptions)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Settings(settings) && ValidationService.Instance().PasswordOptions(passwordOptions))
            {
                if (PasswordOptionsData.Instance().UpdatePasswordOptions(settings, passwordOptions) > 0)
                {
                    settings.PasswordOptions = passwordOptions;
                    user.Settings = settings;

                    return user;
                }
                else return null;
            }
            else return null;
        }
    }
}
