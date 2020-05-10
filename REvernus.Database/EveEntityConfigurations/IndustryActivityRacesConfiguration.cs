namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class IndustryActivityRacesConfiguration : IEntityTypeConfiguration<IndustryActivityRaces>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<IndustryActivityRaces> builder)
        {
            builder.HasNoKey();

            builder.ToTable("industryActivityRaces");

            builder.HasIndex(e => e.ProductTypeId)
                .HasName("ix_industryActivityRaces_productTypeID");

            builder.HasIndex(e => e.TypeId)
                .HasName("ix_industryActivityRaces_typeID");

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.ProductTypeId).HasColumnName("productTypeID");

            builder.Property(e => e.RaceId).HasColumnName("raceID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
