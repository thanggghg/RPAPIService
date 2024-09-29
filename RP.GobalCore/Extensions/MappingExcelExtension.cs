using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;
using FluentValidation;
using RP.GobalCore.Commons.Enums;
using RP.Library.Db;
using RP.Library.Extensions;
using RP.Library.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;

public static class MappingExcelExtension
{
    public static long ExtensionGetValueColToLong(this string value, long oldValue)
    {
        if (long.TryParse(value, out long result))
        {
            return result;
        }
        else
        {
            return oldValue;
        }
    }
    public static decimal ExtensionGetValueColToDecimal(this string value, decimal oldValue)
    {
        if (decimal.TryParse(value, out decimal result))
        {
            return result;
        }
        else
        {
            return oldValue;
        }
    }

    public static int ExtensionGetValueColPaymentMethod(this string value, int oldValue)
    {
        if (PaymentMethodEnum.TryParse(value, out PaymentMethodEnum result))
        {
            return (int)result;
        }
        else
        {
            return oldValue;
        }
    }
    public static DateTime ExtensionGetValueColToDateTime(this string value, DateTime oldValue)
    {
        if (DateTime.TryParseExact(value, ["dd/MM/yyyy HH:mm:ss", "d/M/yyyy HH:mm:ss", "dd-MM-yyyy HH:mm:ss", "d-M-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm", "d/M/yyyy HH:mm", "dd-MM-yyyy HH:mm", "d-M-yyyy HH:mm"], CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        else
        {
            return oldValue;
        }
    }
    public static DateOnly ExtensionGetValueColToDateOnly(this string value, DateOnly oldValue)
    {
        if (DateOnly.TryParseExact(value, ["dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy"], out DateOnly result))
        {
            return result;
        }
        else
        {
            return oldValue;
        }
    }
    public static int ExtensionGetValueColStatus(this string value, int oldValue)
    {
        if (SubmissionStatusEnum.TryParse(value, out SubmissionStatusEnum result))
        {
            return (int)result;
        }
        else
        {
            return oldValue;
        }
    }
}
