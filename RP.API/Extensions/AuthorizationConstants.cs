namespace GoSell.API.Extensions
{
    public record class AuthorizationConstants(
     string BASIC_PREFIX,
     string BEARER_PREFIX,
     string BEARER_TOKEN_FORMAT,
     string LOGIN_NAME_GUEST_PREFIX,
     string LOGIN_PATTERN_FORMAT,
     string LOGIN_USERNAME_FORMAT,
     string LOGIN_STORE_FORMAT,
     string DEFAULT_CLIENT_ID,
     string DEFAULT_BASC_AUTH,
     string CLIENT_DETAIL
    );
}
