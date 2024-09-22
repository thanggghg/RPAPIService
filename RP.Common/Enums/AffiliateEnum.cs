namespace RP.Common.Enums
{
    public enum LoginMethod
    {
        PHONE_NUMBER,
        EMAIL,
        USERNAME,
        GOOGLE,
        FACEBOOK,
        APPLE
    }

    public enum AffilateUserStatus
    {
        PENDING,
        ACTIVE,
        LOCK,
        DELETE
    }

    public enum AffilateVerifyType
    {
        SMS_OTP,
        EMAIL
    }
}
