namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class IndustryActivityConfiguration : IEntityTypeConfiguration<IndustryActivity>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<IndustryActivity> builder)
        {
            builder.HasKey(e => new { e.TypeId, e.ActivityId });

            builder.ToTable("industryActivity");

            builder.HasIndex(e => e.ActivityId)
                .HasName("ix_industryActivity_activityID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.Time).HasColumnName("time");
        }
    }
}
