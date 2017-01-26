using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Globals
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        
        protected DatabaseConnection()
        {
        }

        public static DatabaseConnection Instance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnection();
            }

            return _instance;
        }

        /// <summary>
        /// Holds Database Connection String Value
        /// </summary>
        private static string Value { get; set; } 

        public void SetValue(string Value)
        {
            DatabaseConnection.Value = Value;
        }

        public string GetValue()
        {
            return Value;
        }
    }
}
