using Giftlare.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftlare.Infra.DbContext.Mappings
{
    public class ExchangeMapping : IEntityTypeConfiguration<ExchangeData>
    {
        public void Configure(EntityTypeBuilder<ExchangeData> builder)
        {
            builder.ToTable("Exchange");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.InviteToken)
                .IsRequired();
        }
    }
}
