using Giftlare.Exchange.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Tests.Exceptions
{
    public class AdminRequiredExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Act
            var exception = new AdminRequiredException();

            // Assert
            exception.Type.Should().Be("AdminRequired");
            exception.Error.Should().Be(GiftlareResource.AdminRequired);
            exception.Detail.Should().Be(GiftlareResource.AdminRequiredMessage);
        }
    }
}
