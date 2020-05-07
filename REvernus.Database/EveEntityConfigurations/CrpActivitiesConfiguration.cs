namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class CrpActivitiesConfiguration : IEntityTypeConfiguration<CrpActivities>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<CrpActivities> builder)
        {
            builder.HasKey(e => e.ActivityId);

            builder.ToTable("crpActivities");

            builder.Property(e => e.ActivityId)
                .HasColumnName("activityID")
                .ValueGeneratedNever();

            builder.Property(e => e.ActivityName)
                .HasColumnName("activityName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");
        }
    }
}
