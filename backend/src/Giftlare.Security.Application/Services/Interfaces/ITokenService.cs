using Giftlare.Infra.DbEntities;

namespace Giftlare.Security.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}
