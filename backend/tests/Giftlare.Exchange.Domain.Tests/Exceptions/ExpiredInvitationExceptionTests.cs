using Giftlare.Exchange.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Tests.Exceptions
{
    public class ExpiredInvitationExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Act
            var exception = new ExpiredInvitationException();

            // Assert
            exception.Type.Should().Be("ExpiredInvitation");
            exception.Error.Should().Be(GiftlareResource.ExpiredInvitation);
            exception.Detail.Should().Be(GiftlareResource.ExpiredInvitationMessage);
        }
    }
}
