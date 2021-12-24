using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LostHarbor.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the string is a number; integer, floating point, or scientific notation.
        /// </summary>
        /// <param name="source">The string to check.</param>
        /// <returns></returns>
        public static Boolean IsNumeric(this String source)
        {
            var regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$");
            return regex.IsMatch(source);
        }

        public static Boolean IsValidEmailAddress(this String source)
        {
            var regex = new Regex(@"^\A[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\z$");
            return regex.IsMatch(source);
        }

        public static Boolean IsValidUrl(this String source)
        {
            var regex = new Regex(@"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
            return regex.IsMatch(source);
        }

        public static Boolean IsValidIPAddress(this String source)
        {
            var regex = new Regex(@"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            return regex.IsMatch(source);
        }

        public static Boolean IsNullOrEmpty(this String source)
        {
            return String.IsNullOrEmpty(source);
        }

        public static Boolean IsNullOrEmptyOrWhiteSpace(this String source)
        {
            return String.IsNullOrEmpty(source) || source.Trim() == String.Empty;
        }

        public static String RemoveLastCharacter(this String value)
        {
            return value[0..^1];
        }

        public static String RemoveLast(this String value, Int32 number)
        {
            return value.Substring(0, value.Length - number);
        }
        public static String RemoveFirstCharacter(this String value)
        {
            return value[1..];
        }
        public static String RemoveFirst(this String value, Int32 number)
        {
            return value[number..];
        }

        public static Int64 FileSize(this String filePath)
        {
            Int64 bytes = 0;

            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
                bytes = fileInfo.Length;
            }
            catch { }
            return bytes;
        }



        public static String ComputeHash(this String value, HashType hashType)
        {
            try
            {
                Byte[] inputBytes = Encoding.ASCII.GetBytes(value);
                var hash = hashType switch
                {
                    HashType.HMAC => HMAC.Create().ComputeHash(inputBytes),
                    HashType.HMACMD5 => HMACMD5.Create().ComputeHash(inputBytes),
                    HashType.HMACSHA1 => HMACSHA1.Create().ComputeHash(inputBytes),
                    HashType.HMACSHA256 => HMACSHA256.Create().ComputeHash(inputBytes),
                    HashType.HMACSHA384 => HMACSHA384.Create().ComputeHash(inputBytes),
                    HashType.HMACSHA512 => HMACSHA512.Create().ComputeHash(inputBytes),
                    HashType.MD5 => MD5.Create().ComputeHash(inputBytes),
                    HashType.SHA1 => SHA1.Create().ComputeHash(inputBytes),
                    HashType.SHA256 => SHA256.Create().ComputeHash(inputBytes),
                    HashType.SHA384 => SHA384.Create().ComputeHash(inputBytes),
                    HashType.SHA512 => SHA512.Create().ComputeHash(inputBytes),
                    _ => inputBytes,
                };
                StringBuilder hashString = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    hashString.Append(hash[i].ToString("x2"));
                }

                return hashString.ToString();
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Sets the color of the text according to the parameter value.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="color">Color.</param>
        //public static string Colored(this string message, Color color)
        //{
        //    return string.Format("<color={0}>{1}</color>", color.ToString(), message);
        //}

        /// <summary>
        /// Sets the color of the text according to the traditional HTML format parameter value.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="color">Color</param>
        public static string Colored(this string message, string colorCode)
        {
            return string.Format("<color={0}>{1}</color>", colorCode, message);
        }

        /// <summary>
        /// Sets the size of the text according to the parameter value, given in pixels.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="size">Size.</param>
        public static string Sized(this string message, int size)
        {
            return string.Format("<size={0}>{1}</size>", size, message);
        }

        /// <summary>
        /// Renders the text in boldface.
        /// </summary>
        /// <param name="message">Message.</param>
        public static string Bold(this string message)
        {
            return string.Format("<b>{0}</b>", message);
        }

        /// <summary>
        /// Renders the text in italics.
        /// </summary>
        /// <param name="message">Message.</param>
        public static string Italics(this string message)
        {
            return string.Format("<i>{0}</i>", message);
        }

    }

    public enum HashType
    {
        HMAC,
        HMACMD5,
        HMACSHA1,
        HMACSHA256,
        HMACSHA384,
        HMACSHA512,
        MACTripleDES,
        MD5,
        RIPEMD160,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }
}
