using Giftlare.Core.Domain.Exceptions;
using Giftlare.Core.Enums;
using Giftlare.Exchange.Domain.Entities;
using Giftlare.TestHelpers.Extensions;

namespace Giftlare.Exchange.Domain.Tests.Entities
{
    public class ExchangeMemberDomainTests
    {
        [Fact]
        public void Constructor_WhenValidParameters_ShouldSetProperties()
        {
            // Arrange
            var exchangeId = Guid.NewGuid();
            var memberId = Guid.NewGuid();
            var role = ExchangeMemberRoles.Admin;

            // Act
            var exchangeMemberDomain = new ExchangeMemberDomain(exchangeId, memberId, role);

            // Assert
            exchangeMemberDomain.Id.Should().NotBe(Guid.Empty);
            exchangeMemberDomain.ExchangeId.Should().Be(exchangeId);
            exchangeMemberDomain.MemberId.Should().Be(memberId);
            exchangeMemberDomain.Role.Should().Be(role);
        }

        [Fact]
        public void Constructor_WithId_WhenValidParameters_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var exchangeId = Guid.NewGuid();
            var memberId = Guid.NewGuid();
            var role = ExchangeMemberRoles.Admin;

            // Act
            var exchangeMemberDomain = new ExchangeMemberDomain(id, exchangeId, memberId, role);

            // Assert
            exchangeMemberDomain.Id.Should().Be(id);
            exchangeMemberDomain.ExchangeId.Should().Be(exchangeId);
            exchangeMemberDomain.MemberId.Should().Be(memberId);
            exchangeMemberDomain.Role.Should().Be(role);
        }

        [Fact]
        public void Constructor_WhenIdIsEmpty_ShouldThrowFieldRequiredException()
        {
            // Act
            Action act = () => new ExchangeMemberDomain(Guid.Empty, Guid.NewGuid(), Guid.NewGuid(), ExchangeMemberRoles.Member);

            // Assert
            act.Should().Throw<FieldRequiredException>().WithErrorField("Id");
        }

        [Fact]
        public void Constructor_WhenExchangeIdIsEmpty_ShouldThrowFieldRequiredException()
        {
            // Act
            Action act = () => new ExchangeMemberDomain(Guid.Empty, Guid.NewGuid(), ExchangeMemberRoles.Member);

            // Assert
            act.Should().Throw<FieldRequiredException>().WithErrorField("ExchangeId");
        }

        [Fact]
        public void Constructor_WhenMemberIdIsEmpty_ShouldThrowFieldRequiredException()
        {
            // Act
            Action act = () => new ExchangeMemberDomain(Guid.NewGuid(), Guid.Empty, ExchangeMemberRoles.Member);

            // Assert
            act.Should().Throw<FieldRequiredException>().WithErrorField("MemberId");
        }
    }
}
