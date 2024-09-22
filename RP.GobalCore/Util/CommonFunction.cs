using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace GoSell.Affiliate.Tracking.Utils
{
    public static class CommonFunction
    {
        public static string GenerateApiKey(int keyLength = 32)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] apiKeyBytes = new byte[keyLength];
                rng.GetBytes(apiKeyBytes);
                return Convert.ToBase64String(apiKeyBytes);
            }
        }

        public static bool IsValidUri(string uri)
        {
            try
            {
                Uri uriResult;
                bool result = Uri.TryCreate(uri,
                                            UriKind.Absolute,
                                            out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp
                                                               || uriResult.Scheme == Uri.UriSchemeHttps);
                return result;
            }
            catch
            {
                return false;
            }
        }
        public static string ConvertCountryToPhoneNumber(string countryCode, string phoneNumber)
        {
            if (countryCode == "84" || countryCode == "+84")
            {
                return Regex.IsMatch(phoneNumber, @"^0") ? phoneNumber : $"0{phoneNumber}";
            }
            return phoneNumber;
        }
        public static string EscapeSpecialCharacters(this string input)
        {
            string[] CharactersToEscape = ["%", "_"];
            string escapedInput = input;
            foreach (string character in CharactersToEscape)
            {
                escapedInput = escapedInput.Replace(character, $"\\{character}");
            }
            return escapedInput;
        }
    }
}
