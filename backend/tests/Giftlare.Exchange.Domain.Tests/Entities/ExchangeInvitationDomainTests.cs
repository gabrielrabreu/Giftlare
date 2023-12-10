using Giftlare.Exchange.Domain.Entities;
using Giftlare.Exchange.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Giftlare.Exchange.Domain.Tests.Entities
{
    public class ExchangeInvitationDomainTests
    {
        [Fact]
        public void Constructor_WhenDefault_ShouldGenerateToken()
        {
            // Act
            var exchangeInvitationDomain = new ExchangeInvitationDomain();

            // Assert
            exchangeInvitationDomain.Token.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void Constructor_WhenProvidedToken_ShouldSetToken()
        {
            // Arrange
            var token = "provided_token";

            // Act
            var exchangeInvitationDomain = new ExchangeInvitationDomain(token);

            // Assert
            exchangeInvitationDomain.Token.Should().Be(token);
        }

        [Fact]
        public void CreateToken_WhenValidParameters_ShouldReturnValidJwtToken()
        {
            // Arrange
            var exchangeInvitationDomain = new ExchangeInvitationDomain();
            var id = Guid.NewGuid();
            var name = "TestExchange";

            // Act
            var jwtToken = exchangeInvitationDomain.CreateToken(id, name);

            // Assert
            jwtToken.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void ValidateToken_WhenValidToken_ShouldNotThrowExceptions()
        {
            // Arrange
            var exchangeInvitationDomain = new ExchangeInvitationDomain();
            var id = Guid.NewGuid();
            var name = "TestExchange";
            var invitationToken = exchangeInvitationDomain.CreateToken(id, name);

            // Act
            Action act = () => exchangeInvitationDomain.ValidateToken(id, name, invitationToken);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ValidateToken_WhenExpiredToken_ShouldThrowExpiredInvitationException()
        {
            // Arrange
            var exchangeInvitationDomain = new ExchangeInvitationDomain();
            var id = Guid.NewGuid();
            var name = "TestExchange";
            var expiredToken = GenerateExpiredToken(id, name, exchangeInvitationDomain.Token);

            // Act
            Action act = () => exchangeInvitationDomain.ValidateToken(id, name, expiredToken);

            // Assert
            act.Should().Throw<ExpiredInvitationException>();
        }

        [Fact]
        public void ValidateToken_WhenInvalidToken_ShouldThrowInvalidInvitationException()
        {
            // Arrange
            var exchangeInvitationDomain = new ExchangeInvitationDomain();
            var id = Guid.NewGuid();
            var name = "TestExchange";
            var invalidToken = GenerateInvalidToken(id, name, exchangeInvitationDomain.Token);

            // Act
            Action act = () => exchangeInvitationDomain.ValidateToken(id, name, invalidToken);

            // Assert
            act.Should().Throw<InvalidInvitationException>();
        }

        private string GenerateExpiredToken(Guid id, string name, string inviteToken)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(inviteToken.ToString()));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var expiredToken = new JwtSecurityToken(
                name,
                name,
                claims,
                expires: DateTime.UtcNow.AddHours(-2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(expiredToken);
        }

        private string GenerateInvalidToken(Guid id, string name, string inviteToken)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(inviteToken.ToString()));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var expiredToken = new JwtSecurityToken(
                "invalid_issuer",
                name,
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(expiredToken);
        }
    }
}
