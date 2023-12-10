using Giftlare.Core.Domain.Exceptions;
using Giftlare.Core.Enums;
using Giftlare.Exchange.Domain.Entities;
using Giftlare.Exchange.Domain.Exceptions;
using Giftlare.TestHelpers.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Giftlare.Exchange.Domain.Tests.Entities
{
    public class ExchangeDomainTests
    {
        [Fact]
        public void Constructor_WhenValidParameters_ShouldSetProperties()
        {
            // Arrange
            var name = "Test Exchange";
            var image = "test_image.jpg";
            var adminId = Guid.NewGuid();

            // Act
            var exchangeDomain = new ExchangeDomain(name, image, adminId);

            // Assert
            exchangeDomain.Id.Should().NotBe(Guid.Empty);
            exchangeDomain.Name.Should().Be(name);
            exchangeDomain.Image.Should().Be(image);
            exchangeDomain.Invitation.Should().NotBeNull();
            exchangeDomain.Members.Should().HaveCount(1);
            exchangeDomain.Members.ElementAt(0).Role.Should().Be(ExchangeMemberRoles.Admin);
            exchangeDomain.Members.ElementAt(0).MemberId.Should().Be(adminId);
        }

        [Fact]
        public void Constructor_WithId_WhenValidParameters_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Test Exchange";
            var image = "test_image.jpg";
            var inviteToken = "invite_token";
            var members = new List<ExchangeMemberDomain>();

            // Act
            var exchangeDomain = new ExchangeDomain(id, name, image, inviteToken, members);

            // Assert
            exchangeDomain.Id.Should().Be(id);
            exchangeDomain.Name.Should().Be(name);
            exchangeDomain.Image.Should().Be(image);
            exchangeDomain.Invitation.Should().NotBeNull();
            exchangeDomain.Invitation.Token.Should().Be(inviteToken);
            exchangeDomain.Members.Should().BeEquivalentTo(members);
        }

        [Fact]
        public void Constructor_WhenEmptyId_ShouldThrowFieldRequiredException()
        {
            // Act
            Action act = () => new ExchangeDomain(Guid.Empty, "Test Exchange", "test_image.jpg", "invite_token", new());

            // Assert
            act.Should().Throw<FieldRequiredException>().WithErrorField("Id");
        }

        [Fact]
        public void Constructor_WhenEmptyName_ShouldThrowFieldRequiredException()
        {
            // Act
            Action act = () => new ExchangeDomain(string.Empty, "test_image.jpg", Guid.NewGuid());

            // Assert
            act.Should().Throw<FieldRequiredException>().WithErrorField("Name");
        }

        [Fact]
        public void AddMember_WhenValidParameters_ShouldAddMember()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());
            var memberId = Guid.NewGuid();
            var role = ExchangeMemberRoles.Member;

            // Act
            exchangeDomain.AddMember(memberId, role);

            // Assert
            exchangeDomain.Members.Should().HaveCount(2);
            exchangeDomain.Members.ElementAt(1).Role.Should().Be(role);
            exchangeDomain.Members.ElementAt(1).MemberId.Should().Be(memberId);
        }

        [Fact]
        public void CreateInvitationToken_WhenValidAdmin_ShouldReturnToken()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());

            // Act
            var token = exchangeDomain.CreateInvitationToken(exchangeDomain.Members.ElementAt(0).MemberId);

            // Assert
            token.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void CreateInvitationToken_WhenNonAdmin_ShouldThrowAdminRequiredException()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());
            var nonAdminId = Guid.NewGuid();

            // Act
            Action act = () => exchangeDomain.CreateInvitationToken(nonAdminId);

            // Assert
            act.Should().Throw<AdminRequiredException>();
        }

        [Fact]
        public void AcceptInvite_WhenValidInvitation_ShouldAddMember()
        {
            // Arrange
            var adminId = Guid.NewGuid();
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", adminId);
            var memberId = Guid.NewGuid();
            var invitationToken = exchangeDomain.CreateInvitationToken(adminId);

            // Act
            exchangeDomain.AcceptInvite(memberId, invitationToken);

            // Assert
            exchangeDomain.Members.Should().HaveCount(2);
            exchangeDomain.Members.ElementAt(1).Role.Should().Be(ExchangeMemberRoles.Member);
            exchangeDomain.Members.ElementAt(1).MemberId.Should().Be(memberId);
        }

        [Fact]
        public void AcceptInvite_WhenInvalidInvitation_ShouldThrowInvalidInvitationException()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());
            var memberId = Guid.NewGuid();
            var invalidToken = GenerateInvalidToken(exchangeDomain.Id, exchangeDomain.Name, exchangeDomain.Invitation.Token);

            // Act
            Action act = () => exchangeDomain.AcceptInvite(memberId, invalidToken);

            // Assert
            act.Should().Throw<InvalidInvitationException>();
        }

        [Fact]
        public void AcceptInvite_WhenMemberAlreadyExists_ShouldThrowExistingMemberException()
        {
            // Arrange
            var memberId = Guid.NewGuid();
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", memberId);
            var invitationToken = exchangeDomain.CreateInvitationToken(memberId);

            // Act
            Action act = () => exchangeDomain.AcceptInvite(memberId, invitationToken);

            // Assert
            act.Should().Throw<ExistingMemberException>();
        }

        [Fact]
        public void IsAnAdmin_WhenAdminExists_ShouldReturnTrue()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());
            var adminId = exchangeDomain.Members.ElementAt(0).MemberId;

            // Act
            var result = exchangeDomain.IsAnAdmin(adminId);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsAnAdmin_WhenAdminDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());
            var nonAdminId = Guid.NewGuid();

            // Act
            var result = exchangeDomain.IsAnAdmin(nonAdminId);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void MemberExists_WhenMemberExists_ShouldReturnTrue()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());
            var memberId = exchangeDomain.Members.ElementAt(0).MemberId;

            // Act
            var result = exchangeDomain.MemberExists(memberId);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void MemberExists_WhenMemberDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var exchangeDomain = new ExchangeDomain("Test Exchange", "test_image.jpg", Guid.NewGuid());
            var nonExistentMemberId = Guid.NewGuid();

            // Act
            var result = exchangeDomain.MemberExists(nonExistentMemberId);

            // Assert
            result.Should().BeFalse();
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
