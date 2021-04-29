using System.Collections.Generic;
using System.Security.Claims;

namespace ProjetoSocialAPI.Services
{
    public interface  ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpireToken(string token);
    }
}
