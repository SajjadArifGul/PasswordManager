using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    public class PasswordOptions
    {
        public int ID { get; set; }
        public int SettingsID { get; set; }
        
        public bool AllowLowercaseCharacters =true,
            AllowUppercaseCharacters=true,
            AllowNumberCharacters=true,
            AllowSpecialCharacters=true,
            AllowUnderscoreCharacters=false,
            AllowSpaceCharacters=false,
            AllowOtherCharacters=false;
        
        public bool RequireLowercaseCharacters = true,
            RequireUppercaseCharacters = true,
            RequireNumberCharacters = true,
            RequireSpecialCharacters = true,
            RequireUnderscoreCharacters = false,
            RequireSpaceCharacters = false,
            RequireOtherCharacters = false;

        // Pick the number of characters.
        public int MinimumCharacters=10, MaximumCharacters = 12;

        public string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        public string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string NumberCharacters = "0123456789";
        public string SpecialCharacters = @"~!@#$%^&*():;[]{}<>,.?/\|";
        public string UnderscoreCharacters = "_";
        public string SpaceCharacters = " ";
        public string OtherCharacters = null;
    }
}
