using Giftlare.Core.Domain.Data;

namespace Giftlare.Core.Infra.Data.Queries
{
    public abstract class BaseParameters : IParameters
    {
        public const int PageDefault = 0;

        private int _page = PageDefault;
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value < 0 ? PageDefault : value;
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
