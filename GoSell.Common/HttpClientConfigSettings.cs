namespace GoSell.Common
{
    public class HttpClientConfigSettings
    {
        public const double HANDLER_LIFETIME_MINUTES = 3;
        public const int TRANSIENT_HTTP_ERROR_POLICY_RETRY = 3;
        public const double TRANSIENT_HTTP_ERROR_POLICY_WAIT_SECONDS = 30;
    }
}
