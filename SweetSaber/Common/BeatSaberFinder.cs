using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace SweetSaber.Common
{
    internal class BeatSaberFinder
    {
        public static string? TryFind()
        {
            string? location;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                location = CheckRegistry();
                if (location != null)
                    return location;

                location = CheckProgramFilesDir();
                if (location != null)
                    return location;
            }


            return null;
        }

        private static string? CheckRegistry()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new PlatformNotSupportedException();

            try
            {
                RegistryKey? rKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 620980");
                if (rKey != null)
                {
                    object? installLocation = rKey.GetValue("InstallLocation");
                    if (installLocation != null && installLocation is string locationStr)
                        return locationStr;
                }

                return null;
            }
            catch (SecurityException) { return null; }
        }
    
        private static string? CheckProgramFilesDir()
        {
            string location = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}/Steam/steamapps/common/Beat Saber";
            if (Directory.Exists(location))
                return location;
            return null;
        }
    }
}
