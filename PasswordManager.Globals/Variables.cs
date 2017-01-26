using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Globals
{
    public static class Variables
    {
        public static string DatabaseConnectionString { get; set; }

        public static List<DateFormat> DateFormats = new List<DateFormat>()
        {
            new DateFormat() {Format=  "d", ID =1, Value ="2/27/2000"},
            new DateFormat() {Format=  "D", ID =2, Value ="Friday, February 27, 2000"},
            new DateFormat() {Format=  "f", ID =3, Value ="Friday, February 27, 2000 12:11 PM"},
            new DateFormat() {Format=  "F", ID =4, Value ="Friday, February 27, 2000 12:12:22 PM"},
            new DateFormat() {Format=  "g", ID =5, Value ="2/27/2000 12:12 PM"},
            new DateFormat() {Format=  "G", ID =6, Value ="2/27/2000 12:12:22 PM"},
            new DateFormat() {Format=  "s", ID =7, Value ="2000-02-27T12:12:22"},
            new DateFormat() {Format=  "u", ID =8, Value ="2000-02-27 12:12:22Z"}
        };
    }

    public class DateFormat
    {
        public string Format { get; set; }
        public int ID { get; set; }
        public string Value { get; set; }
    }
}
