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

        public bool UpdateSettings(Entities.User user, Entities.Settings settings)
        {
            return Database.UpdateSettings(user, settings);
        }
    }
}
