namespace REvernus.Database.EveEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using REvernus.Database.EveDbModels;

    ///<inheritdoc/>
    public class AgtAgentTypesConfiguration : IEntityTypeConfiguration<AgtAgentTypes>
    {
        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<AgtAgentTypes> builder)
        {
            builder.HasKey(e => e.AgentTypeId);

            builder.ToTable("agtAgentTypes");

            builder.Property(e => e.AgentTypeId)
                    .HasColumnName("agentTypeID")
                    .ValueGeneratedNever();

            builder.Property(e => e.AgentType)
                    .HasColumnName("agentType")
                    .HasColumnType("VARCHAR(50)");
        }
    }
}
