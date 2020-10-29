using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CountyRP.WebSite
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        const string KEY = "ege4y4eaEGGEw33tyh2rqAff3";
        public const int LIFETIME = 30;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
