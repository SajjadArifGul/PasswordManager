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

        public User Update(User user, Settings settings)
        {
            if (ValidationService.Instance().User(user))
            {
                if (ValidationService.Instance().Settings(settings))
                {
                    settings = Globals.Defaults.Settings;
                }

                if (SettingsData.Instance().Update(user, settings))
                {
                    user.Settings = settings;
                }

                return user;
            }
            else return null;
        }

        public User Update(User user, Settings settings, PasswordOptions passwordOptions)
        {
            if (ValidationService.Instance().User(user))
            {
                if (ValidationService.Instance().Settings(settings))
                {
                    settings = Globals.Defaults.Settings;
                }

                if (ValidationService.Instance().PasswordOptions(passwordOptions))
                {
                    passwordOptions = Globals.Defaults.PasswordOptions;
                }
                
                if (PasswordOptionsData.Instance().Update(settings, passwordOptions))
                {
                    settings.PasswordOptions = passwordOptions;
                }

                if (SettingsData.Instance().Update(user, settings))
                {
                    user.Settings = settings;
                }

                return user;
            }
            else return null;
        }
    }
}
