using Giftlare.Core.Domain.Security;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Repositories;
using Giftlare.Infra.DbEntities;
using Giftlare.Main.Domain.Entities;
using Giftlare.Main.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Giftlare.Main.Infra.Data.Repositories
{
    public class GatheringRepository : AuditableRepository<GatheringDomain, GatheringData>, IGatheringRepository
    {
        public GatheringRepository(IApplicationDbContext context, 
                                   ISessionService sessionService)
            : base(context, sessionService)
        {
        }

        public override GatheringDomain? GetById(Guid domainEntityId)
        {
            var dataEntity = _dbSet.AsNoTracking()
                .Include(x => x.Members)
                .SingleOrDefault(x => x.Id.Equals(domainEntityId));
            if (dataEntity != null)
                return MapTo(dataEntity);
            return default;
        }

        public override GatheringDomain Add(GatheringDomain domainEntity)
        {
            var dataEntity = MapTo(domainEntity);

            dataEntity.OnCreate(_sessionService.User.Id);
            foreach (var member in dataEntity.Members)
            {
                member.OnCreate(_sessionService.User.Id);
            }
            
            _dbSet.Add(dataEntity);
            return domainEntity;
        }

        public override void Update(GatheringDomain domainEntity)
        {
            var dataEntity = MapTo(domainEntity);

            var existingParent = _context.Query<GatheringData>()
                .Include(x => x.Members)
                .SingleOrDefault(x => x.Id == domainEntity.Id);

            if (existingParent != null)
            {
                existingParent.OnUpdate(_sessionService.User.Id);
                var entry = _context.GetDbEntry(dataEntity);
                entry.CurrentValues.SetValues(dataEntity);
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedOn).IsModified = false;

                foreach (var existingChild in existingParent.Members.ToList())
                {
                    if (!dataEntity.Members.Any(c => c.Id == existingChild.Id))
                        _context.GetDbSet<GatheringMemberData>().Remove(existingChild);
                }

                foreach (var childModel in dataEntity.Members)
                {
                    var existingChild = existingParent.Members
                        .SingleOrDefault(c => c.Id == childModel.Id && c.Id != Guid.Empty);

                    if (existingChild != null)
                    {
                        existingChild.OnUpdate(_sessionService.User.Id);
                        var childEntry = _context.GetDbEntry(existingChild);
                        childEntry.CurrentValues.SetValues(childModel);
                        childEntry.Property(x => x.CreatedBy).IsModified = false;
                        childEntry.Property(x => x.CreatedOn).IsModified = false;
                    }
                    else
                    {
                        childModel.OnCreate(_sessionService.User.Id);
                        existingParent.Members.Add(childModel);
                        _context.GetDbEntry(childModel).State = EntityState.Added;
                    }
                }
            }
        }

        protected override GatheringDomain MapTo(GatheringData dataEntity)
        {
            var members = dataEntity.Members.Select(m => new GatheringMemberDomain(m.Id, m.GatheringId, m.MemberId, m.Role));
            return new GatheringDomain(dataEntity.Id, dataEntity.Name, dataEntity.InviteToken, members.ToList());
        }

        protected override GatheringData MapTo(GatheringDomain domainEntity)
        {
            return new GatheringData
            {
                Id = domainEntity.Id,
                Name = domainEntity.Name,
                InviteToken = domainEntity.Invitation.Token,
                Members = domainEntity.Members.Select(m =>
                    new GatheringMemberData
                    {
                        Id = m.Id,
                        GatheringId = m.GatheringId,
                        MemberId = m.MemberId,
                        Role = m.Role
                    }).ToList()
            };
        }
    }
}
