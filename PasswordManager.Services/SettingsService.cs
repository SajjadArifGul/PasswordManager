using PasswordManager.Data;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    /// <summary>
    /// Provides access to User related Settings and data.
    /// </summary>
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

        /// <summary>
        /// Gets the Settings for Supplied User.
        /// </summary>
        /// <param name="user">User for which Settings are required.</param>
        /// <returns>Settings: The Settings for User</returns>
        public Settings GetUserSettings(User user)
        {
            if (ValidationService.Instance().User(user))
            {
                return SettingsData.Instance().GetUserSettings(user);
            }
            else return null;
        }

        /// <summary>
        /// Updates the supplied User Settings.
        /// </summary>
        /// <param name="user">User for which settings are to be updated.</param>
        /// <param name="settings">Settings which are to be updated.</param>
        /// <returns>User: User with the updated settings.</returns>
        public User UpdateUserSettings(User user, Settings settings)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Settings(settings))
            {
                if (SettingsData.Instance().UpdateUserSettings(user, settings) > 0)
                {
                    user.Settings = settings;

                    return user;
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Gets the PasswordOptions Settings.
        /// </summary>
        /// <param name="settings">Settings for which PasswordOptions are required.</param>
        /// <returns>PasswordOptions object to be attached to settings.</returns>
        public PasswordOptions GetUserPasswordOptions(Settings settings)
        {
            if (ValidationService.Instance().Settings(settings))
            {
                return PasswordOptionsData.Instance().GetPasswordOptionsBySettings(settings);
            }
            else return null;
        }

        /// <summary>
        /// Updates the PasswordOptions for supplied User Settings
        /// </summary>
        /// <param name="user">User for Settings Access.</param>
        /// <param name="settings">Settings to be updated with PasswordOptions.</param>
        /// <param name="passwordOptions">PasswordOptions to be updated.</param>
        /// <returns>User: User with the updated Settings and PasswordOptions.</returns>
        public User UpdateUserPasswordOptions(User user, Settings settings, PasswordOptions passwordOptions)
        {
            if (ValidationService.Instance().User(user) && ValidationService.Instance().Settings(settings) && ValidationService.Instance().PasswordOptions(passwordOptions))
            {
                if (PasswordOptionsData.Instance().UpdatePasswordOptionsBySettings(settings, passwordOptions) > 0)
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
