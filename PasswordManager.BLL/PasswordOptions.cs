using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;
using PasswordManager.DAL;

namespace PasswordManager.BLL
{
    public class PasswordOptions
    {
        Database db;

        public PasswordOptions()
        {
            db = Database.Instance();
        }

        public bool Update(Entities.Settings settings)
        {
            return db.PasswordOptions_Update(settings);
        }
    }
}
