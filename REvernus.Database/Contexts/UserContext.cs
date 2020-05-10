namespace REvernus.Database.Contexts
{
    using JetBrains.Annotations;

    using Microsoft.EntityFrameworkCore;

    using REvernus.Database.UserDbModels;
    using REvernus.Utilites;

    public class UserContext : DbContext
    {
        [UsedImplicitly]
        public DbSet<CharacterInformation> Characters { get; set; }
        
        [UsedImplicitly]
        public DbSet<AddedStructure> AddedStructures { get; set; }
        
        [UsedImplicitly]
        public DbSet<DeveloperApplication> DeveloperApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"DataSource={Paths.UserDataBasePath};");
            }
        }
    }
}
