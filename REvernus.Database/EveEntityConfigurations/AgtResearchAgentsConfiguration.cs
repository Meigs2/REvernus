namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc/>
    public class AgtResearchAgentsConfiguration : IEntityTypeConfiguration<AgtResearchAgents>
    {
        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<AgtResearchAgents> builder)
        {
            builder.HasKey(e => new { e.AgentId, e.TypeId });

            builder.ToTable("agtResearchAgents");

            builder.HasIndex(e => e.TypeId)
                    .HasName("ix_agtResearchAgents_typeID");

            builder.Property(e => e.AgentId).HasColumnName("agentID");

            builder.Property(e => e.TypeId).HasColumnName("typeID");
        }
    }
}
