using System.Text.RegularExpressions;
using GoSell.Common.Constants;

namespace GoSell.Common.Utils
{
    public static class StringHelper
    {
        public static bool ValidatePasswordFormat(string password)
        {
            return Regex.IsMatch(password, RegexValidation.PASSWORD_VALIDATION);
        }

        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, RegexValidation.Email);
        }

        public static string Identify(string countryCode, string phoneNumber)
        {
            return $"{countryCode}:{phoneNumber}";
        }

        public static string ConvertCountryToPhoneNumber(string countryCode, string phoneNumber)
        {
            if (countryCode == "84" || countryCode == "+84")
            {
                return Regex.IsMatch(phoneNumber, @"^0") ? phoneNumber : $"0{phoneNumber}";
            }
            return phoneNumber;
        }
        
        public static string PhoneNumberWithoutZero(string countryCode, string phoneNumber)
        {
            if (countryCode == "84" || countryCode == "+84")
            {
                // Case 0xxxxxxxx (start with 0) (length < 10)
                return Regex.IsMatch(phoneNumber, @"^0") ? phoneNumber?.Substring(1, phoneNumber.Length - 1) : phoneNumber;
            }
            return phoneNumber;
        }

        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
