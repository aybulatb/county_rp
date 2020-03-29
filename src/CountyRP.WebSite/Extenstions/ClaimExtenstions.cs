using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CountyRP.WebSite.Extenstions
{
    public static class ClaimExtenstions
    {
        public static int GetId(this IEnumerable<Claim> claims)
        {
            Claim claim = claims.FirstOrDefault(c => c.Type == "id");
            
            if (claim != null && int.TryParse(claim.Value, out int id))
                return id;

            return 0;
        }

        public static string GetPassword(this IEnumerable<Claim> claims)
        {
            Claim claim = claims.FirstOrDefault(c => c.Type == "password");

            if (claim != null)
                return claim.Value;

            return null;
        }
    }
}
