using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.Theme
{
    /// <summary>
    /// Centralized MessageBox display settings related class.
    /// </summary>
    public static class Messenger
    {
        /// <summary>
        /// Displays the message with the specified Message Type.
        /// </summary>
        /// <param name="Message">Message to be displayed.</param>
        /// <param name="Type">Message Type e.g. Error, Warning, Info.</param>
        public static void Show(string Message, string Type)
        {
            switch (Type)
            {
                case "Error":
                    ShowErrorMessage(Message);
                    break;
                case "Warning":
                    ShowWarningMessage(Message);
                    break;
                default: //info
                    ShowInfoMessage(Message);
                    break;
            }
        }
        private static void ShowInfoMessage(string Message)
        {
            MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static void ShowErrorMessage(string Message)
        {
            MessageBox.Show("An error ocured during the process. Please report to Developer at sajjadarifgul@gmail.com with this screenshot.\n\nError Message: " + Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private static void ShowWarningMessage(string Message)
        {
            MessageBox.Show(Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Displays confirmation message with the specified Message Type.
        /// </summary>
        /// <param name="Message">Message to be displayed.</param>
        /// <returns>Boolean: True if confirmed otherwise False.</returns>
        public static bool Confirm(string Message)
        {
            if (MessageBox.Show(Message, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                return true;
            }
            else return false;
        }
    }
}
