using Giftlare.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftlare.Infra.DbContext.Mappings
{
    public class GatheringMemberMapping : IEntityTypeConfiguration<GatheringMemberData>
    {
        public void Configure(EntityTypeBuilder<GatheringMemberData> builder)
        {
            builder.ToTable("GatheringMember");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.GatheringId)
                .IsRequired();

            builder.Property(x => x.MemberId)
                .IsRequired();

            builder.Property(x => x.Role)
                .IsRequired();

            builder.HasOne(x => x.Gathering)
                .WithMany(y => y.Members)
                .HasForeignKey(x => x.GatheringId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Member)
                .WithMany(y => y.Gatherings)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.GatheringId, x.MemberId })
                .IsUnique();
        }
    }
}
