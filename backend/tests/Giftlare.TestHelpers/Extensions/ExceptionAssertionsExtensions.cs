using FluentAssertions.Specialized;
using Giftlare.Core.Domain.Exceptions;

namespace Giftlare.TestHelpers.Extensions
{
    public static class ExceptionAssertionsExtensions
    {
        public static ExceptionAssertions<TException> WithErrorField<TException>(
            this ExceptionAssertions<TException> assertions, string fieldName)
            where TException : FieldRequiredException
        {
            assertions.And.Should().BeOfType<TException>();
            assertions.And.FieldName.Should().Be(fieldName);
            return assertions;
        }
    }
}
