using System.Security.Cryptography;
using System.Text;

namespace DigiDish.BusinessModels.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPasswordSHA512(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha512.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
