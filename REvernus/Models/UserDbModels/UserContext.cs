using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace REvernus.Models.UserDbModels
{
    public class UserContext : DbContext
    {
        public DbSet<CharacterInformation> Characters { get; set; }
        public DbSet<AddedStructure> AddedStructures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"DataSource={Utilities.Paths.UserDataBasePath};");
            }
        }
    }
}
