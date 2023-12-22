using Giftlare.Core.Domain.Data;

namespace Giftlare.Core.Infra.Data.Queries
{
    public class PagedParameters : IPagedParameters
    {
        public const int PageDefault = 1;

        private int _page = PageDefault;
        public int Page
        {
            get
            {
                return _page - 1;
            }
            set
            {
                _page = value <= 0 ? PageDefault : value;
            }
        }

        public const int MaxSize = 30;
        public const int SizeDefault = 10;

        private int _size = SizeDefault;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value < 1)
                {
                    _size = SizeDefault;
                }
                else
                {
                    _size = value > MaxSize ? MaxSize : value;
                }
            }
        }
    }
}
