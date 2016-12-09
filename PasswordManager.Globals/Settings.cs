using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Globals
{
    public static class Settings
    {
        public static string AppName {
            get {
                return "Bear Pass";
            }
        }

        public static string DatabaseFilePath = @"SampleData.xml";
        public static DateTime DateTimeFormat { get; set; }
        public static string Master { get; set; }
    }
}
