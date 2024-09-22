namespace GoSell.Common.Constants
{
    public class RegexValidation
    {
        public const string PHONE_NUMBER_SPECIAL = @"^\d+$";
        public const string COUNTRY_CODE_VALIDATION = @"^\+\d+$";
        public const string PASSWORD_VALIDATION = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[\W_]).{8,}$";
        public const string Email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    }
}
