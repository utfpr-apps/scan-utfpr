using System.IdentityModel.Tokens.Jwt;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Application.Handlers
{
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
			var key = Encoding.UTF8.GetBytes(_configuration.GetSection("Google:").Value);
			var secret = new SymmetricSecurityKey(key);

			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

		private async Task<List<Claim>> GetClaims(ApplicationUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Email)
			};

			var roles = await _userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			return claims;
		}

		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddHours(6),
				signingCredentials: signingCredentials);

			return tokenOptions;
		}

		public async Task<string> GenerateToken(ApplicationUser user)
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims(user);
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
			var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return token;
		}

		public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(CadastrarUsuarioCommand externalAuth)
		{
			var settings = new GoogleJsonWebSignature.ValidationSettings()
			{
				Audience = new List<string>() { _configuration.GetValue<string>("Google:ClientId") }
			};
			var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
			return payload;
		}
	}
}