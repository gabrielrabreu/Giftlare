using Giftlare.Core.Domain.Security;
using Giftlare.Core.Infra.Data.Context;
using Giftlare.Core.Infra.Data.Repositories;
using Giftlare.Exchange.Domain.Entities;
using Giftlare.Exchange.Domain.Repositories;
using Giftlare.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Giftlare.Exchange.Infra.Data.Repositories
{
    public class ExchangeRepository : AggregateRepository<ExchangeDomain, ExchangeData>, IExchangeRepository
    {
        public ExchangeRepository(IApplicationDbContext context,
                                  ISessionService sessionService) 
            : base(context, sessionService)
        {
        }

        public override ExchangeDomain? GetById(Guid domainEntityId)
        {
            var dataEntity = _dbSet.AsNoTracking()
                .Include(x => x.Members)
                .SingleOrDefault(x => x.Id.Equals(domainEntityId));
            if (dataEntity != null)
                return MapTo(dataEntity);
            return null;
        }

        public override void Add(ExchangeDomain domain)
        {
            var dataEntity = MapTo(domain);

            dataEntity.OnCreate(_sessionService.User.Id);
            foreach (var member in dataEntity.Members)
            {
                member.OnCreate(_sessionService.User.Id);
            }

            _dbSet.Add(dataEntity);
        }

        public override void Update(ExchangeDomain domain)
        {
            var dataEntity = MapTo(domain);

            var existingParent = _context.Query<ExchangeData>()
                .Include(x => x.Members)
                .SingleOrDefault(x => x.Id == domain.Id);

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
                        _context.GetDbSet<ExchangeMemberData>().Remove(existingChild);
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

        protected override ExchangeDomain MapTo(ExchangeData dataEntity)
        {
            var members = dataEntity.Members.Select(m => new ExchangeMemberDomain(m.Id, m.ExchangeId, m.MemberId, m.Role));
            return new ExchangeDomain(dataEntity.Id,
                                      dataEntity.Name,
                                      dataEntity.Image,
                                      dataEntity.InviteToken,
                                      members.ToList());
        }

        protected override ExchangeData MapTo(ExchangeDomain domainEntity)
        {
            return new ExchangeData
            {
                Id = domainEntity.Id,
                Name = domainEntity.Name,
                Image = domainEntity.Image,
                InviteToken = domainEntity.Invitation.Token,
                Members = domainEntity.Members.Select(m =>
                    new ExchangeMemberData
                    {
                        Id = m.Id,
                        ExchangeId = m.ExchangeId,
                        MemberId = m.MemberId,
                        Role = m.Role
                    }).ToList()
            };
        }
    }
}
