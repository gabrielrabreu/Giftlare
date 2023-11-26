using Giftlare.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftlare.Infra.DbContext.Mappings
{
    public class GatheringMapping : IEntityTypeConfiguration<GatheringData>
    {
        public void Configure(EntityTypeBuilder<GatheringData> builder)
        {
            builder.ToTable("Gathering");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.InviteToken)
                .IsRequired();
        }
    }
}
