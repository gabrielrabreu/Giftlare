namespace Giftlare.Core.Domain.Data
{
    public interface IPagedParameters
    {
        int Page { get; set; }
        int Size { get; set; }
    }
}
