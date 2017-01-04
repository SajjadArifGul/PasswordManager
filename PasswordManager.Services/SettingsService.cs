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

        public Settings GetUserSettings(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                return SettingsData.Instance().GetUserSettings(user);
            }
            else return null;
        }

        public User UpdateUserSettings(User user, Settings settings)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Settings(settings))
            {
                if (SettingsData.Instance().UpdateSettings(user, settings) > 0)
                {
                    user.Settings = settings;

                    return user;
                }
                else return null;
            }
            else return null;
        }

        public PasswordOptions GetUserPasswordOptions(Settings settings)
        {
            if (ValidationService.Instance().Settings(settings))
            {
                return PasswordOptionsData.Instance().GetPasswordOptions(settings);
            }
            else return null;
        }

        public User UpdateUserPasswordOptions(User user, Settings settings, PasswordOptions passwordOptions)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Settings(settings) && ValidationService.Instance().PasswordOptions(passwordOptions))
            {
                if (PasswordOptionsData.Instance().UpdatePasswordOptions(settings, passwordOptions) > 0)
                {
                    user.Settings.PasswordOptions = passwordOptions;
                    return user;
                }
                else return null;
            }
            else return null;
        }
    }
}
