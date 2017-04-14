using System.Data.Entity.ModelConfiguration;
using EasyLOB.Activity.Data;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityRoleConfiguration : EntityTypeConfiguration<ActivityRole>
    {
        public ActivityRoleConfiguration()
        {
            #region Class

            this.ToTable("ActivityRole");

            this.HasKey(x => new { x.ActivityId, x.RoleName });

            #endregion Class

            #region Properties

            this.Property(x => x.ActivityId)
                .HasColumnName("ActivityId")
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .IsRequired();

            this.Property(x => x.RoleName)
                .HasColumnName("RoleName")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(x => x.Operations)
                .HasColumnName("Operations")
                .HasColumnType("varchar")
                .HasMaxLength(256);

            #endregion Properties

            #region Associations (FK)

            this.HasRequired(x => x.Activity)
                .WithMany(x => x.ActivityRoles)
                .HasForeignKey(x => x.ActivityId);

            #endregion Associations (FK)
        }
    }
}