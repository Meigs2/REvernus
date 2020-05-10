namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc />
    public class RamAssemblyLineTypeDetailPerGroupConfiguration : IEntityTypeConfiguration<RamAssemblyLineTypeDetailPerGroup>
    {
        ///<inheritdoc />
        public void Configure(EntityTypeBuilder<RamAssemblyLineTypeDetailPerGroup> builder)
        {
            builder.HasKey(e => new { e.AssemblyLineTypeId, e.GroupId });

            builder.ToTable("ramAssemblyLineTypeDetailPerGroup");

            builder.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

            builder.Property(e => e.GroupId).HasColumnName("groupID");

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
