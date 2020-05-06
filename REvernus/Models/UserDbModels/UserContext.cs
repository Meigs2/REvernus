using Microsoft.EntityFrameworkCore;

namespace REvernus.Models.UserDbModels
{
    public class UserContext : DbContext
    {
        public DbSet<CharacterInformation> Characters { get; set; }
        public DbSet<AddedStructure> AddedStructures { get; set; }
        public DbSet<DeveloperApplication> DeveloperApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"DataSource={Utilities.Paths.UserDataBasePath};");
            }
        }
    }
}
