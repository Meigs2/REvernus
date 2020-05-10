namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class RamAssemblyLineTypeDetailPerCategoryConfiguration : IEntityTypeConfiguration<RamAssemblyLineTypeDetailPerCategory>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<RamAssemblyLineTypeDetailPerCategory> builder)
        {
            builder.HasKey(e => new { e.AssemblyLineTypeId, e.CategoryId });

            builder.ToTable("ramAssemblyLineTypeDetailPerCategory");

            builder.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

            builder.Property(e => e.CategoryId).HasColumnName("categoryID");

            builder.Property(e => e.CostMultiplier)
                .HasColumnName("costMultiplier")
                .HasColumnType("FLOAT");

            builder.Property(e => e.MaterialMultiplier)
                .HasColumnName("materialMultiplier")
                .HasColumnType("FLOAT");

            builder.Property(e => e.TimeMultiplier)
                .HasColumnName("timeMultiplier")
                .HasColumnType("FLOAT");
        }
    }
}
