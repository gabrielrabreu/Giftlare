using Giftlare.Core.Domain.Entities;
using Giftlare.Core.Domain.Exceptions;
using Giftlare.Core.Enums;
using Giftlare.Exchange.Domain.Exceptions;

namespace Giftlare.Exchange.Domain.Entities
{
    public class ExchangeDomain : IAggregateRoot
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

        private ExchangeInvitationDomain _invitation;
        public ExchangeInvitationDomain Invitation
        {
            get => _invitation;
            private set
            {
                if (value == null)
                    throw new FieldRequiredException(nameof(Invitation));
                _invitation = value;
            }
        }

        private readonly List<ExchangeMemberDomain> _members;
        public IReadOnlyCollection<ExchangeMemberDomain> Members => _members.AsReadOnly();

        public ExchangeDomain(string name, Guid adminId)
        {
            Id = Guid.NewGuid();
            Invitation = new ExchangeInvitationDomain();
            _members = new();

            Name = name;
            AddMember(adminId, ExchangeMemberRoles.Admin);
        }

        public ExchangeDomain(Guid id, string name, string invitationToken, List<ExchangeMemberDomain> members)
        {
            Id = id;
            Name = name;
            Invitation = new ExchangeInvitationDomain(invitationToken);
            _members = members;
        }

        public void AddMember(Guid memberId, ExchangeMemberRoles role)
        {
            _members.Add(new ExchangeMemberDomain(Id, memberId, role));
        }

        public string CreateInvitationToken(Guid memberId)
        {
            if (!IsAnAdmin(memberId)) throw new AdminRequiredException();
            return Invitation.CreateToken(Id, Name);
        }

        public void AcceptInvite(Guid memberId, string invitationToken)
        {
            if (MemberExists(memberId)) throw new ExistingMemberException();
            Invitation.ValidateToken(Id, Name, invitationToken);
            AddMember(memberId, ExchangeMemberRoles.Member);
        }

        private bool IsAnAdmin(Guid memberId)
        {
            var admin = _members.Single(x => x.Role == ExchangeMemberRoles.Admin);
            return admin.MemberId == memberId;
        }

        private bool MemberExists(Guid memberId)
        {
            return _members.Any(m => m.MemberId == memberId);
        }
    }
}
