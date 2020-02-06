using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RepositoryCore.CoreState
{

    internal class DataCore
    {
        public static Dictionary<int, object> StatusCore = new Dictionary<int, object>()
        {
            { 200, new {success=true} },
            { 400, new { success= false} },
            { 201, new { success= true, created= true} },
            { 202 , new { success= true, accepted= true} },
            { 204, new { success= false, noContent= false} },
            { 401, new { success= false, unAuthorized= true} },
                   
        };
    }
    public static class RepositoryState
    {
        public static Dictionary<int, object> _dict;
        public static Dictionary<int , object> DefaultResult
        {
            get
            {
                if(_dict== null)
                {
                    _dict =  DataCore.StatusCore;
                }
                return _dict;
            }
        }
        public static string ParsePhone(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return "";
            phoneNumber = phoneNumber.Replace(" ", "");
            var resultString = Regex.Match(phoneNumber, @"\d+").Value;
            if (resultString.Length == 12)
            {
                return resultString;
            }
            if (resultString.Length == 9)
            {
                return "998" + resultString;
            }
            return null;

        }
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
        public static CultureInfo[] GetAllCulter
        {
            get => CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
        }
        public static bool IsWindows() =>
               RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMacOS() =>
               RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static bool IsLinux() =>
               RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static MemoryStream SerializeToStream(object objectType)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objectType);
            return stream;
        }

        /// <summary>
        /// deserializes as an object
        /// </summary>
        /// <param name="stream">the stream to deserialize</param>
        /// <returns>the deserialized object</returns>
        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object objectType = formatter.Deserialize(stream);
            return objectType;
        }
        #region Private
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        #endregion

    }
}
