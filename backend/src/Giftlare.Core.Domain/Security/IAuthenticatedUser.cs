namespace Giftlare.Core.Domain.Security
{
    public interface IAuthenticatedUser
    {
        Guid Id { get; }
        string Name { get; }
        string Email { get; }
        string Language { get; }
    }
}
