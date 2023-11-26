using Giftlare.Core.Domain.Exceptions;
using Giftlare.Core.Enums;

namespace Giftlare.Exchange.Domain.Entities
{
    public class ExchangeMemberDomain
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set
            {
                if (value == Guid.Empty)
                {
                    throw new FieldRequiredException(nameof(Id));
                }
                _id = value;
            }
        }

        private Guid _exchangeId;
        public Guid ExchangeId
        {
            get => _exchangeId;
            private set
            {
                if (value == Guid.Empty)
                {
                    throw new FieldRequiredException(nameof(ExchangeId));
                }
                _exchangeId = value;
            }
        }

        private Guid _memberId;
        public Guid MemberId
        {
            get => _memberId;
            private set
            {
                if (value == Guid.Empty)
                {
                    throw new FieldRequiredException(nameof(MemberId));
                }
                _memberId = value;
            }
        }


        private ExchangeMemberRoles _role;
        public ExchangeMemberRoles Role
        {
            get => _role;
            private set
            {
                _role = value;
            }
        }

        public ExchangeMemberDomain(Guid exchangeId, Guid memberId, ExchangeMemberRoles role)
        {
            Id = Guid.NewGuid();
            ExchangeId = exchangeId;
            MemberId = memberId;
            Role = role;
        }

        public ExchangeMemberDomain(Guid id, Guid exchangeId, Guid memberId, ExchangeMemberRoles role)
        {
            Id = id;
            ExchangeId = exchangeId;
            MemberId = memberId;
            Role = role;
        }
    }

}
