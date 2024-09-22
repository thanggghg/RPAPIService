using System.Text;

namespace GoSell.API.Extensions
{
    public interface IOauthClientDetailsService
    {
        OauthClientDetailsDTO GetFromBasicToken(string basicToken);
    }
    public class OauthClientDetailsService : IOauthClientDetailsService
    {
        private readonly string DEFAULT_BASC_AUTH;
        private readonly string DEFAULT_CLIENT_ID;
        public OauthClientDetailsService(AuthorizationConstants authorizationConstants)
        {
            DEFAULT_BASC_AUTH = authorizationConstants.DEFAULT_BASC_AUTH;
            DEFAULT_CLIENT_ID = authorizationConstants.DEFAULT_CLIENT_ID;
        }
        public OauthClientDetailsDTO GetFromBasicToken(string basicToken)
        {
            Console.WriteLine($"Request get OauthClientDetails from Base64:\n{basicToken}");

            if (DEFAULT_BASC_AUTH.Equals(basicToken))
            {
                // Testing
                Console.WriteLine("THIS BASIC TOKEN IS FOR TESTING, NEED REMOVE ASAP!");
                return new OauthClientDetailsDTO();
            }

            string base64Token = basicToken;

            if (base64Token.StartsWith("Basic "))
            {
                base64Token = base64Token.Replace("Basic ", "");
            }

            byte[] decoded = Convert.FromBase64String(base64Token);
            string decodedAuthz = Encoding.UTF8.GetString(decoded);
            string[] userParts = decodedAuthz.Split(':', 2);

            if (userParts.Length != 2)
            {
                throw new Exception("Invalid basic authenticate token");
            }

            string clientId = userParts[0];
            string clientSecret = userParts[1];

            return new OauthClientDetailsDTO();
        }
    }
    public class OauthClientDetailsDTO
    {
        // Your DTO properties
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

}
