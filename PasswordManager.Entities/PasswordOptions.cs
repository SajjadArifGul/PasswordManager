using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    public class PasswordOptions
    {
        bool AllowLowercaseCharacters =true,
            AllowUppercaseCharacters=true,
            AllowNumberCharacters=true,
            AllowSpecialCharacters=true,
            AllowUnderscoreCharacters=false,
            AllowSpaceCharacters=false,
            AllowOtherCharacters=false;
        
        // Pick the number of characters.
        int min_chars=8, max_chars=10;

        const string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NumberCharacters = "0123456789";
        const string SpecialCharacters = @"~!@#$%^&*():;[]{}<>,.?/\|";
        string OtherCharacters;
    }
}
