using Giftlare.Core.Domain.Exceptions;
using Giftlare.Exchange.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Giftlare.Exchange.Domain.Entities
{
    public class ExchangeInvitationDomain
    {
        private readonly int _expiresInHours = 2;

        private string _token;
        public string Token
        {
            get => _token;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new FieldRequiredException(nameof(Token));
                _token = value;
            }
        }

        public ExchangeInvitationDomain()
        {
            Token = Guid.NewGuid().ToString();
        }

        public ExchangeInvitationDomain(string token)
        {
            Token = token;
        }

        public string CreateToken(Guid id, string name)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token.ToString()));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                name,
                name,
                claims,
                expires: DateTime.Now.AddHours(_expiresInHours),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void ValidateToken(Guid id, string name, string invitationToken)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token.ToString()));

            var parameters = new TokenValidationParameters
            {
                ValidIssuer = name,
                ValidAudience = name,
                IssuerSigningKey = key
            };

            var handler = new JwtSecurityTokenHandler();

            try
            {
                handler.ValidateToken(invitationToken, parameters, out SecurityToken securityToken);
                var jwtToken = (JwtSecurityToken)securityToken;
                if (jwtToken.Subject != id.ToString())
                    throw new InvalidInvitationException();
            }
            catch (SecurityTokenExpiredException)
            {
                throw new ExpiredInvitationException();
            }
            catch (SecurityTokenValidationException)
            {
                throw new InvalidInvitationException();
            }
        }
    }

}
