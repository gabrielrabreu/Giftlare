using Giftlare.Core.Domain.Entities;
using Giftlare.Core.Domain.Exceptions;
using Giftlare.Enums;
using Giftlare.Main.Domain.Exceptions;

namespace Giftlare.Main.Domain.Entities
{
    public class GatheringDomain : IAggregateRoot
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set
            {
                if (value == Guid.Empty)
                    throw new FieldRequiredException(nameof(Id));
                _id = value;
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new FieldRequiredException(nameof(Name));
                _name = value;
            }
        }

        private InvitationDomain _invitation;
        public InvitationDomain Invitation
        {
            get => _invitation;
            private set
            {
                if (value == null)
                    throw new FieldRequiredException(nameof(Invitation));
                _invitation = value;
            }
        }

        private readonly List<GatheringMemberDomain> _members;
        public IReadOnlyCollection<GatheringMemberDomain> Members => _members.AsReadOnly();

        public GatheringDomain(string name)
        {
            Id = Guid.NewGuid();
            Invitation = new InvitationDomain();

            Name = name;

            _members = new();
        }

        public GatheringDomain(Guid id, string name, Guid invitationToken, List<GatheringMemberDomain> members)
        {
            Id = id;
            Name = name;
            Invitation = new InvitationDomain(invitationToken);
            _members = members;
        }

        public void AddMember(Guid memberId, GatheringMemberRoles role)
        {
            _members.Add(new GatheringMemberDomain(Id, memberId, role));
        }

        public string CreateInvitationToken(Guid userId)
        {
            if (!IsAnAdmin(userId)) throw new AdminRequiredException();
            return Invitation.CreateToken(Id, Name);
        }

        public void AcceptInvitation(Guid userId, string invitationToken)
        {
            if (AlreadyAMember(userId)) throw new AlreadyMemberException();
            Invitation.ValidateToken(Id, Name, invitationToken);
            AddMember(userId, GatheringMemberRoles.Member);
        }

        private bool IsAnAdmin(Guid userId)
        {
            var admin = _members.Single(x => x.Role == GatheringMemberRoles.Admin);
            return admin.MemberId == userId;
        }

        private bool AlreadyAMember(Guid userId)
        {
            return _members.Any(m => m.MemberId == userId);
        }
    }
}
