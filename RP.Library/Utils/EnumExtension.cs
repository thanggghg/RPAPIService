using System.ComponentModel;
using System.Text.RegularExpressions;

namespace RP.Library.Utils
{
    public static class EnumExtension
    {
        public static string GetName<TEnum>(Byte val)
        {
            return Enum.GetName(typeof(TEnum), val);
        }

        public static string GetNameToLower<TEnum>(this TEnum val)
        {
            var name = Enum.GetName(typeof(TEnum), val);
            return name.ToLower();
        }

        public static bool CheckExist<TEnum>(Byte val)
        {
            return Enum.IsDefined(typeof(TEnum), val);
        }


        public static string GetDescription<TEnum>(this TEnum val)
        {
            var type = typeof(TEnum);
            var memInfo = type.GetMember(val.ToString());
            if (memInfo.Count() == 0)
            {
                return Convert.ToString(val);
            }

            var attribute = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            var description = attribute == null ? FormatName(val.ToString()) : ((DescriptionAttribute)attribute).Description;
            return description;
        }

        public static TEnum GetValueFromDescription<TEnum>(this string description)
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (TEnum)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (TEnum)field.GetValue(null);
                }
            }

            return default;
        }

        public static List<TEnum> EnumToList<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        }

        private static string FormatName(string name)
        {
            return Regex.Replace(name, "(\\B[A-Z])", " $1");
        }
    }
}
