using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShareBagAPI
{
    public class AuthOptions
    {
        public const string ISSUER = "ShareBagServer"; // издатель токена
        public const string AUDIENCE = "ShareBagClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 1000; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public const string Id = "id";
        public const string Password = "password";
    }
}
