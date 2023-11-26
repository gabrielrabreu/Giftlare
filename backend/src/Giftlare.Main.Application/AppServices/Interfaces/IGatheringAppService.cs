using Giftlare.Main.Contracts;

namespace Giftlare.Main.Application.AppServices.Interfaces
{
    public interface IGatheringAppService
    {
        void Create(GatheringForCreationDto forCreationDto);
    }
}
