using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using DVLD_Business;

namespace DVLD_FullRealProject.Global_Classes
{
    public class clsCredentialManager
    {
        private static string KeyPath = @"SOFTWARE\DVLD_PROJECT\Credentials";
        private static string ValueName = "UsernameAndPassword";
        private static string Delimiter = "#//#";

        private static string FullKeyPath = $"HKEY_CURRENT_USER\\{KeyPath}";
        
        public static bool IsValueDeleted()
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (RegistryKey key = baseKey.OpenSubKey(KeyPath, writable: true))
                {
                    if (key == null) return false;

                    key.DeleteValue(ValueName);
                    return true;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                clsLogger.Log(ex);
                return false;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex);
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool RememberUserNameAndPassword(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return IsValueDeleted();
            }

            string valueData = FormatCredentials(username, password);

            try
            {
                Registry.SetValue(FullKeyPath, ValueName, valueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex);
                return false;
            }
        }

        public static bool GetStoredCredentials(ref string username, ref string password)
        {
            try
            {
                string value = Registry.GetValue(FullKeyPath, ValueName, null) as string;
                if (string.IsNullOrEmpty(value)) return false;

                ParseCredentials(value, ref username, ref password);
                return true;
            }
            catch (Exception ex)
            {
                clsLogger.Log(ex);
                return false;
            }
        }

        private static string FormatCredentials(string username, string password)
        {
            return $"{username}{Delimiter}{password}";
        }

        private static void ParseCredentials(string value, ref string username, ref string password)
        {
            string[] result = value.Split(new[] { Delimiter }, StringSplitOptions.None);

            username = result[0];
            password = result[1]; 
        }

    }

}
