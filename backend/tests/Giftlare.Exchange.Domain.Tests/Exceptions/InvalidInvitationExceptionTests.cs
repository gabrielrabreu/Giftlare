using Giftlare.Exchange.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Tests.Exceptions
{
    public class InvalidInvitationExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Act
            var exception = new InvalidInvitationException();

            // Assert
            exception.Type.Should().Be("InvalidInvitation");
            exception.Error.Should().Be(GiftlareResource.InvalidInvitation);
            exception.Detail.Should().Be(GiftlareResource.InvalidInvitationMessage);
        }
    }
}
