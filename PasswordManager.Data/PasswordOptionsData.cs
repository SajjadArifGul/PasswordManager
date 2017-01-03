using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Entities;

namespace PasswordManager.Data
{
    public class PasswordOptionsData
    {
        private static PasswordOptionsData _instance;

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

        public bool Update(Settings settings, PasswordOptions passwordOptions)
        {
            throw new NotImplementedException();
        }
    }
}
