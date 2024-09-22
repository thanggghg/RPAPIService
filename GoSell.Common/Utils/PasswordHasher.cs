namespace GoSell.Common.Utils
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash the password with the salt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
