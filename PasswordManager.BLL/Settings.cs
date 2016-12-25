using PasswordManager.DAL;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BLL
{
    public class Settings
    {
        Database db;

        public Settings()
        {
            db = Database.Instance();
        }

        public Entities.Settings Update(Entities.User user, Entities.Settings settings)
        {
            if (db.Settings_Update(settings, user))
            {
                return settings;
            }
            else return null;
        }
    }
}
