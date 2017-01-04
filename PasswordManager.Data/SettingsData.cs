using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;
using PasswordManager.Database;

namespace PasswordManager.Data
{
    public class SettingsData
    {
        private static SettingsData _instance;

        private DB Database = DB.Instance();

        protected SettingsData()
        {
        }

        public static SettingsData Instance()
        {
            if (_instance == null)
            {
                _instance = new SettingsData();
            }

            return _instance;
        }

        public int UpdateUserSettings(User user, Settings settings)
        {
            return Database.UpdateSettingsByUserID(user.ID, settings);
        }

        public Settings GetUserSettings(User user)
        {
            return Database.GetSettingsByUserID(user.ID);
        }
    }
}
