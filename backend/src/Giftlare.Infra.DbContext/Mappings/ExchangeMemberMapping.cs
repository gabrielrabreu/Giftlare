using Giftlare.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftlare.Infra.DbContext.Mappings
{
    public class ExchangeMemberMapping : IEntityTypeConfiguration<ExchangeMemberData>
    {
        public void Configure(EntityTypeBuilder<ExchangeMemberData> builder)
        {
            builder.ToTable("ExchangeMember");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ExchangeId)
                .IsRequired();

            builder.Property(x => x.MemberId)
                .IsRequired();

            builder.Property(x => x.Role)
                .IsRequired();

            builder.HasOne(x => x.Exchange)
                .WithMany(y => y.Members)
                .HasForeignKey(x => x.ExchangeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Member)
                .WithMany(y => y.Exchanges)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.ExchangeId, x.MemberId })
                .IsUnique();
        }
    }
}
