namespace REvernus.Database.Contexts
{
    using JetBrains.Annotations;

    using Microsoft.EntityFrameworkCore;

    using REvernus.Database.EveDbModels;
    using REvernus.Utilites;

    public class EveContext : DbContext
    {
        public EveContext()
        {
        }

        public EveContext(DbContextOptions<EveContext> options)
            : base(options)
        {
        }

        public DbSet<AgtAgentTypes> AgtAgentTypes { get; set; }
        public DbSet<AgtAgents> AgtAgents { get; set; }
        public DbSet<AgtResearchAgents> AgtResearchAgents { get; set; }
        public DbSet<CertCerts> CertCerts { get; set; }
        public DbSet<CertMasteries> CertMasteries { get; set; }
        public DbSet<CertSkills> CertSkills { get; set; }
        public DbSet<ChrAncestries> ChrAncestries { get; set; }
        public DbSet<ChrAttributes> ChrAttributes { get; set; }
        public DbSet<ChrBloodlines> ChrBloodlines { get; set; }
        public DbSet<ChrFactions> ChrFactions { get; set; }
        public DbSet<ChrRaces> ChrRaces { get; set; }
        public DbSet<CrpActivities> CrpActivities { get; set; }
        public DbSet<CrpNpccorporationDivisions> CrpNpccorporationDivisions { get; set; }
        public DbSet<CrpNpccorporationResearchFields> CrpNpccorporationResearchFields { get; set; }
        public DbSet<CrpNpccorporationTrades> CrpNpccorporationTrades { get; set; }
        public DbSet<CrpNpccorporations> CrpNpccorporations { get; set; }
        public DbSet<CrpNpcdivisions> CrpNpcdivisions { get; set; }
        public DbSet<DgmAttributeCategories> DgmAttributeCategories { get; set; }
        public DbSet<DgmAttributeTypes> DgmAttributeTypes { get; set; }
        public DbSet<DgmEffects> DgmEffects { get; set; }
        public DbSet<DgmExpressions> DgmExpressions { get; set; }
        public DbSet<DgmTypeAttributes> DgmTypeAttributes { get; set; }
        public DbSet<DgmTypeEffects> DgmTypeEffects { get; set; }
        public DbSet<EveGraphics> EveGraphics { get; set; }
        public DbSet<EveIcons> EveIcons { get; set; }
        public DbSet<EveUnits> EveUnits { get; set; }
        public DbSet<IndustryActivity> IndustryActivity { get; set; }
        public DbSet<IndustryActivityMaterials> IndustryActivityMaterials { get; set; }
        public DbSet<IndustryActivityProbabilities> IndustryActivityProbabilities { get; set; }
        public DbSet<IndustryActivityProducts> IndustryActivityProducts { get; set; }
        public DbSet<IndustryActivityRaces> IndustryActivityRaces { get; set; }
        public DbSet<IndustryActivitySkills> IndustryActivitySkills { get; set; }
        public DbSet<IndustryBlueprints> IndustryBlueprints { get; set; }
        public DbSet<InvCategories> InvCategories { get; set; }
        public DbSet<InvContrabandTypes> InvContrabandTypes { get; set; }
        public DbSet<InvControlTowerResourcePurposes> InvControlTowerResourcePurposes { get; set; }
        public DbSet<InvControlTowerResources> InvControlTowerResources { get; set; }
        public DbSet<InvFlags> InvFlags { get; set; }
        public DbSet<InvGroups> InvGroups { get; set; }
        public DbSet<InvItems> InvItems { get; set; }
        public DbSet<InvMarketGroups> InvMarketGroups { get; set; }
        public DbSet<InvMetaGroups> InvMetaGroups { get; set; }
        public DbSet<InvMetaTypes> InvMetaTypes { get; set; }
        public DbSet<InvNames> InvNames { get; set; }
        public DbSet<InvPositions> InvPositions { get; set; }
        public DbSet<InvTraits> InvTraits { get; set; }
        public DbSet<InvTypeMaterials> InvTypeMaterials { get; set; }
        public DbSet<InvTypeReactions> InvTypeReactions { get; set; }
        
        [UsedImplicitly]
        public DbSet<InvTypes> InvTypes { get; set; }
        public DbSet<InvUniqueNames> InvUniqueNames { get; set; }
        public DbSet<InvVolumes> InvVolumes { get; set; }
        public DbSet<MapCelestialStatistics> MapCelestialStatistics { get; set; }
        public DbSet<MapConstellationJumps> MapConstellationJumps { get; set; }
        public DbSet<MapConstellations> MapConstellations { get; set; }
        public DbSet<MapDenormalize> MapDenormalize { get; set; }
        public DbSet<MapJumps> MapJumps { get; set; }
        public DbSet<MapLandmarks> MapLandmarks { get; set; }
        public DbSet<MapLocationScenes> MapLocationScenes { get; set; }
        public DbSet<MapLocationWormholeClasses> MapLocationWormholeClasses { get; set; }
        public DbSet<MapRegionJumps> MapRegionJumps { get; set; }
        public DbSet<MapRegions> MapRegions { get; set; }
        public DbSet<MapSolarSystemJumps> MapSolarSystemJumps { get; set; }
        
        [UsedImplicitly] 
        public DbSet<MapSolarSystems> MapSolarSystems { get; set; }
        public DbSet<MapUniverse> MapUniverse { get; set; }
        public DbSet<PlanetSchematics> PlanetSchematics { get; set; }
        public DbSet<PlanetSchematicsPinMap> PlanetSchematicsPinMap { get; set; }
        public DbSet<PlanetSchematicsTypeMap> PlanetSchematicsTypeMap { get; set; }
        public DbSet<RamActivities> RamActivities { get; set; }
        public DbSet<RamAssemblyLineStations> RamAssemblyLineStations { get; set; }
        public DbSet<RamAssemblyLineTypeDetailPerCategory> RamAssemblyLineTypeDetailPerCategory { get; set; }
        public DbSet<RamAssemblyLineTypeDetailPerGroup> RamAssemblyLineTypeDetailPerGroup { get; set; }
        public DbSet<RamAssemblyLineTypes> RamAssemblyLineTypes { get; set; }
        public DbSet<RamInstallationTypeContents> RamInstallationTypeContents { get; set; }
        public DbSet<SkinLicense> SkinLicense { get; set; }
        public DbSet<SkinMaterials> SkinMaterials { get; set; }
        public DbSet<SkinShip> SkinShip { get; set; }
        public DbSet<Skins> Skins { get; set; }
        public DbSet<StaOperationServices> StaOperationServices { get; set; }
        public DbSet<StaOperations> StaOperations { get; set; }
        public DbSet<StaServices> StaServices { get; set; }
        public DbSet<StaStationTypes> StaStationTypes { get; set; }

        [UsedImplicitly]
        public DbSet<StaStations> StaStations { get; set; }
        public DbSet<TranslationTables> TranslationTables { get; set; }
        public DbSet<TrnTranslationColumns> TrnTranslationColumns { get; set; }
        public DbSet<TrnTranslationLanguages> TrnTranslationLanguages { get; set; }
        public DbSet<TrnTranslations> TrnTranslations { get; set; }
        public DbSet<WarCombatZoneSystems> WarCombatZoneSystems { get; set; }
        public DbSet<WarCombatZones> WarCombatZones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"DataSource={Paths.SdeDataBasePath};");
            }
        }

        /// <summary>
        /// Applying entity configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EveContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
