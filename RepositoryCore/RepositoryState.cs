using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace RepositoryCore.CoreState
{
   public static class RepositoryState
    {

        public static string GetHashString(string inputString)
        {
            //var sb = new StringBuilder();
            //foreach (var b in GetHash(inputString))
            //    sb.Append(b.ToString("X2"));

            //return sb.ToString();
            return inputString;
        }
        public static bool IsPhoneNumber(string number)
        {
            if (!number.StartsWith("998")) return false;

            return IsDigitsOnly(number);
        }
        public static bool IsDigitsOnly(string str)
        {
            foreach (var c in str)
                if (c < '0' || c > '9')
                    return false;

            return true;
        }
        public static string RandomInt(int count = 6)
        {
            var random = new Random();
            var result = "";
            for (var i = 0; i < count; i++) result += random.Next(9).ToString();
            return result;
        }
        public static string GenerateRandomString(int count)
        {
            var all = "qwertyuioplkjhgfdsazxcvbnm";
            var result = "";
            var random = new Random();
            for (var i = 0; i < count; i++) result += all[random.Next(26)];
            return result;
        }
        public static object CreateObject<T>()
        {
            return Activator.CreateInstance(typeof(T));
        }
        public static  CultureInfo[] GetAllCulter
        {
            get => CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
        }
         public static bool IsWindows() =>
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

         public static bool IsMacOS() =>
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

         public static bool IsLinux() =>
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
      
        #region Private
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        #endregion

    }
}
