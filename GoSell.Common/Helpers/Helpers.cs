using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using GoSell.Library.Constants;

namespace GoSell.Common.Helpers
{
    public static class Helpers
    {
        public static long ToUnixTimestamp(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = date.ToUniversalTime().Subtract(epoch);
            return time.Ticks / TimeSpan.TicksPerSecond;
        }
        public static string ReadHtmlFile(string filePath, string fileName)
        {
            string htmlContent = string.Empty;
            if (string.IsNullOrEmpty(fileName))
                return htmlContent;

            bool exists = Directory.Exists(filePath);
            if (!exists)
                Directory.CreateDirectory(filePath);

            filePath = $"{filePath}/{fileName}";

            using (StreamReader reader = new StreamReader(filePath))
            {
                htmlContent = reader.ReadToEnd();
            }

            return htmlContent;
        }

        public static string GenerateOTP(int length = 0)
        {
            string randomNumbers = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                randomNumbers += random.Next(10);
            }

            return randomNumbers;
        }
        public static DateTime ConvertToUtcDate(this DateTime datetime)
        {
            return DateTime.SpecifyKind(datetime, DateTimeKind.Utc);
        }
        public static string CheckIsNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return value;
        }

        public static string BuildUrlWithQueryString(string basePath, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(basePath)
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };
            return uriBuilder.Uri.AbsoluteUri;
        }
    
        public static DateTime CustomStartDateToUtc(this DateTime d)
        {
            DateTime startDate = new DateTime(d.Year, d.Month, d.Day);
            return startDate.ToUniversalTime();
        }

        public static DateTime CustomEndDateToUtc(this DateTime d)
        {
            DateTime endDate = new DateTime(d.Year, d.Month, d.Day);
            var endDateOfDate = endDate.AddDays(1).AddMicroseconds(-1);
            return endDateOfDate.ToUniversalTime();
        }

        public static string ConvertDateTimeToString(DateTime? dateTime, string format = "dd/MM/yyyy")
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToString(format, CultureInfo.CurrentCulture);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ConvertStringToDateTimeString(string dateTimeString, string format = "dd/MM/yyyy")
        {
            DateTime parsedDateTime;
            if (DateTime.TryParseExact(dateTimeString, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out parsedDateTime))
            {
                return parsedDateTime.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                return string.Empty;
            }
        }

        public static string FormatNumber(decimal? number, string format, CultureInfo culture)
        {
            if (!number.HasValue)
            {
                return string.Empty;
            }

            string formattedNumber = string.Format(culture, format, number.Value);

            return formattedNumber;
        }

        public static string GetTemplateType(string path)
        {
            Dictionary<string, string> types = GetMimeTypes();
            string ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".zip", "application/zip" }
            };
        }

        public static long ToUnixTimestampTickMilisecond(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = date.ToUniversalTime().Subtract(epoch);
            return time.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public static string FormatCurrency(decimal currencyValue, string currencyCode, string currencySymbol)
        {
            var returnValue = string.Empty;
            var defaultValue = currencyCode != CurrencyCodes.VND ? currencySymbol + "0" : "0" + currencySymbol;
            if (currencyValue == decimal.Zero) return defaultValue;
            if (currencyCode != CurrencyCodes.VND)
            {
                var culture = new CultureInfo("en-US");
                culture.NumberFormat.NumberDecimalSeparator = ".";
                culture.NumberFormat.NumberGroupSeparator = ",";

                returnValue = currencySymbol + Math.Round(currencyValue, 2, MidpointRounding.AwayFromZero).ToString("#,##0.00", culture);
            }
            else
            {
                var culture = new CultureInfo("vi-VN");
                culture.NumberFormat.NumberGroupSeparator = ",";
                returnValue = Math.Round(currencyValue).ToString("#,###", culture.NumberFormat) + currencySymbol;
            }
            return returnValue;
        }
    }
}
