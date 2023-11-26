using Giftlare.Core.Domain.Data;

namespace Giftlare.Core.Infra.Data.Queries
{
    public class PagedList<T> : IPagedList<T>
    {
        public IList<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PagedList(IList<T> items, int totalItems, int currentPage, int pageSize)
        {
            Data = items;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
