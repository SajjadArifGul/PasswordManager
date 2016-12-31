using PasswordManager.Entities;
using PasswordManager.Globals;

namespace PasswordManager.BLL
{
    public static class Encrypter
    {
        public static Password Encrypt(Password password, User user)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Encrypt(password.Name, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Encrypt(password.Email, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Encrypt(password.Username, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Encrypt(password.Website, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Encrypt(password.Text, user.Master, Globals.Defaults.initVector, 256);
            return password;
        }

        public static Password Decrypt(Password password, User user)
        {
            if (Verifier.Text(password.Name)) password.Name = Gulipso.Gulipso.Decrypt(password.Name, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Email)) password.Email = Gulipso.Gulipso.Decrypt(password.Email, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Username)) password.Username = Gulipso.Gulipso.Decrypt(password.Username, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Website)) password.Website = Gulipso.Gulipso.Decrypt(password.Website, user.Master, Globals.Defaults.initVector, 256);
            if (Verifier.Text(password.Text)) password.Text = Gulipso.Gulipso.Decrypt(password.Text, user.Master, Globals.Defaults.initVector, 256);
            return password;
        }
    }
}
