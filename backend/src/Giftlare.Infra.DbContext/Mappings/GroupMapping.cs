using Giftlare.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftlare.Infra.DbContext.Mappings
{
    public class GroupMapping : IEntityTypeConfiguration<GroupData>
    {
        public void Configure(EntityTypeBuilder<GroupData> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.InviteToken)
                .IsRequired();
        }
    }

    public class GroupUserMapping : IEntityTypeConfiguration<GroupUserData>
    {
        public void Configure(EntityTypeBuilder<GroupUserData> builder)
        {
            builder.ToTable("GroupUser");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.GroupId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Role)
                .IsRequired();

            builder.HasOne<GroupData>()
                .WithMany()
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ug => new { ug.UserId, ug.GroupId })
                .IsUnique();
        }
    }
}
