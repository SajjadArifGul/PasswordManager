using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;
using PasswordManager.Database;

namespace PasswordManager.Data
{
    public class PasswordOptionsData
    {
        private static PasswordOptionsData _instance;
        DB Database = DB.Instance();

        protected PasswordOptionsData()
        {
        }

        public static PasswordOptionsData Instance()
        {
            if (_instance == null)
            {
                _instance = new PasswordOptionsData();
            }

            return _instance;
        }

        public int UpdatePasswordOptionsBySettings(Settings settings, PasswordOptions passwordOptions)
        {
            return Database.UpdatePasswordOptionsBySettingsID(settings.ID, passwordOptions);
        }

        public PasswordOptions GetPasswordOptionsBySettings(Settings settings)
        {
            return Database.GetPasswordOptionsBySettingsID(settings.ID);
        }
    }
}
