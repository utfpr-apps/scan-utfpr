using System.IdentityModel.Tokens.Jwt;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Application.Handlers;

public class JwtHandler : IJwtHandler
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;

    public JwtHandler(IConfiguration configuration, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECURITY_KEY") ?? throw new ArgumentNullException());
        return new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
    }

    private async Task<List<Claim>> GetClaims(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id)
        };

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private SecurityTokenDescriptor GenerateTokenDescriptor(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(14),
            SigningCredentials = signingCredentials
        };
        return tokenDescriptor;
    }

    public async Task<string> GenerateToken(ApplicationUser user)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims(user);
        var tokenDescriptor = GenerateTokenDescriptor(signingCredentials, claims);
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var security = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(security);
    }

    public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string token)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string>()
            {
                Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID_WEB") ??
                throw new ArgumentNullException("GOOGLE_CLIENT_ID_WEB"),
                Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID_MOBILE") ??
                throw new ArgumentNullException("GOOGLE_CLIENT_ID_MOBILE")
            }
        };
        var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
        return payload;
    }
}