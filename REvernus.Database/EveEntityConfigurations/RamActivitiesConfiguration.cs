namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class RamActivitiesConfiguration : IEntityTypeConfiguration<RamActivities>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<RamActivities> builder)
        {
            builder.HasKey(e => e.ActivityId);

            builder.ToTable("ramActivities");

            builder.Property(e => e.ActivityId)
                .HasColumnName("activityID")
                .ValueGeneratedNever();

            builder.Property(e => e.ActivityName)
                .HasColumnName("activityName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.IconNo)
                .HasColumnName("iconNo")
                .HasColumnType("VARCHAR(5)");

            builder.Property(e => e.Published)
                .HasColumnName("published")
                .HasColumnType("BOOLEAN");
        }
    }
}
