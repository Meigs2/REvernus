namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    /// <inheritdoc />
    public class AgtAgentsConfiguration : IEntityTypeConfiguration<AgtAgents>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<AgtAgents> builder)
        {
            builder.HasKey(e => e.AgentId);

            builder.ToTable("agtAgents");

            builder.HasIndex(e => e.CorporationId)
                .HasName("ix_agtAgents_corporationID");

            builder.HasIndex(e => e.LocationId)
                .HasName("ix_agtAgents_locationID");

            builder.Property(e => e.AgentId)
                .HasColumnName("agentID")
                .ValueGeneratedNever();

            builder.Property(e => e.AgentTypeId).HasColumnName("agentTypeID");

            builder.Property(e => e.CorporationId).HasColumnName("corporationID");

            builder.Property(e => e.DivisionId).HasColumnName("divisionID");

            builder.Property(e => e.IsLocator)
                .HasColumnName("isLocator")
                .HasColumnType("BOOLEAN");

            builder.Property(e => e.Level).HasColumnName("level");

            builder.Property(e => e.LocationId).HasColumnName("locationID");

            builder.Property(e => e.Quality).HasColumnName("quality");
        }
    }
}
