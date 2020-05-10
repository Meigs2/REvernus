namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class RamAssemblyLineTypesConfiguration : IEntityTypeConfiguration<RamAssemblyLineTypes>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<RamAssemblyLineTypes> builder)
        {
            builder.HasKey(e => e.AssemblyLineTypeId);

            builder.ToTable("ramAssemblyLineTypes");

            builder.Property(e => e.AssemblyLineTypeId)
                .HasColumnName("assemblyLineTypeID")
                .ValueGeneratedNever();

            builder.Property(e => e.ActivityId).HasColumnName("activityID");

            builder.Property(e => e.AssemblyLineTypeName)
                .HasColumnName("assemblyLineTypeName")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.BaseCostMultiplier)
                .HasColumnName("baseCostMultiplier")
                .HasColumnType("FLOAT");

            builder.Property(e => e.BaseMaterialMultiplier)
                .HasColumnName("baseMaterialMultiplier")
                .HasColumnType("FLOAT");

            builder.Property(e => e.BaseTimeMultiplier)
                .HasColumnName("baseTimeMultiplier")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(1000)");

            builder.Property(e => e.MinCostPerHour)
                .HasColumnName("minCostPerHour")
                .HasColumnType("FLOAT");

            builder.Property(e => e.Volume)
                .HasColumnName("volume")
                .HasColumnType("FLOAT");
        }
    }
}
