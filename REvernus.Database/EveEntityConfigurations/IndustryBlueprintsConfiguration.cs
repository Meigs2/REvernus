namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class IndustryBlueprintsConfiguration : IEntityTypeConfiguration<IndustryBlueprints>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<IndustryBlueprints> builder)
        {
            builder.HasKey(e => e.TypeId);

            builder.ToTable("industryBlueprints");

            builder.Property(e => e.TypeId)
                .HasColumnName("typeID")
                .ValueGeneratedNever();

            builder.Property(e => e.MaxProductionLimit).HasColumnName("maxProductionLimit");
        }
    }
}
