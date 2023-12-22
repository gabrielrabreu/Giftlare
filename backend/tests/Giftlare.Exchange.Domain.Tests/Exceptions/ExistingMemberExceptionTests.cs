using Giftlare.Exchange.Domain.Exceptions;
using Giftlare.Infra.Resources;

namespace Giftlare.Exchange.Domain.Tests.Exceptions
{
    public class ExistingMemberExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Act
            var exception = new ExistingMemberException();

            // Assert
            exception.Type.Should().Be("ExistingMember");
            exception.Error.Should().Be(GiftlareResource.ExistingMember);
            exception.Detail.Should().Be(GiftlareResource.ExistingMemberMessage);
        }
    }
}
