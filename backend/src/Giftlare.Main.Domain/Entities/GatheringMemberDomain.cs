using Giftlare.Core.Domain.Exceptions;
using Giftlare.Enums;

namespace Giftlare.Main.Domain.Entities
{
    public class GatheringMemberDomain
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

        private Guid _gatheringId;
        public Guid GatheringId
        {
            get => _gatheringId;
            private set
            {
                if (value == Guid.Empty)
                {
                    throw new FieldRequiredException(nameof(GatheringId));
                }
                _gatheringId = value;
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


        private GatheringMemberRoles _role;
        public GatheringMemberRoles Role
        {
            get => _role;
            private set
            {
                _role = value;
            }
        }

        public GatheringMemberDomain(Guid gatheringId, Guid memberId, GatheringMemberRoles role)
        {
            Id = Guid.NewGuid();
            GatheringId = gatheringId;
            MemberId = memberId;
            Role = role;
        }

        public GatheringMemberDomain(Guid id, Guid gatheringId, Guid memberId, GatheringMemberRoles role)
        {
            Id = id;
            GatheringId = gatheringId;
            MemberId = memberId;
            Role = role;
        }
    }
}
