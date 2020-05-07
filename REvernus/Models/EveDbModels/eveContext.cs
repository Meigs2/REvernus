using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace REvernus.Models.EveDbModels
{
    // ReSharper disable once InconsistentNaming
    public partial class eveContext : DbContext
    {
        public eveContext()
        {
        }

        public eveContext(DbContextOptions<eveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgtAgentTypes> AgtAgentTypes { get; set; }
        public virtual DbSet<AgtAgents> AgtAgents { get; set; }
        public virtual DbSet<AgtResearchAgents> AgtResearchAgents { get; set; }
        public virtual DbSet<CertCerts> CertCerts { get; set; }
        public virtual DbSet<CertMasteries> CertMasteries { get; set; }
        public virtual DbSet<CertSkills> CertSkills { get; set; }
        public virtual DbSet<ChrAncestries> ChrAncestries { get; set; }
        public virtual DbSet<ChrAttributes> ChrAttributes { get; set; }
        public virtual DbSet<ChrBloodlines> ChrBloodlines { get; set; }
        public virtual DbSet<ChrFactions> ChrFactions { get; set; }
        public virtual DbSet<ChrRaces> ChrRaces { get; set; }
        public virtual DbSet<CrpActivities> CrpActivities { get; set; }
        public virtual DbSet<CrpNpccorporationDivisions> CrpNpccorporationDivisions { get; set; }
        public virtual DbSet<CrpNpccorporationResearchFields> CrpNpccorporationResearchFields { get; set; }
        public virtual DbSet<CrpNpccorporationTrades> CrpNpccorporationTrades { get; set; }
        public virtual DbSet<CrpNpccorporations> CrpNpccorporations { get; set; }
        public virtual DbSet<CrpNpcdivisions> CrpNpcdivisions { get; set; }
        public virtual DbSet<DgmAttributeCategories> DgmAttributeCategories { get; set; }
        public virtual DbSet<DgmAttributeTypes> DgmAttributeTypes { get; set; }
        public virtual DbSet<DgmEffects> DgmEffects { get; set; }
        public virtual DbSet<DgmExpressions> DgmExpressions { get; set; }
        public virtual DbSet<DgmTypeAttributes> DgmTypeAttributes { get; set; }
        public virtual DbSet<DgmTypeEffects> DgmTypeEffects { get; set; }
        public virtual DbSet<EveGraphics> EveGraphics { get; set; }
        public virtual DbSet<EveIcons> EveIcons { get; set; }
        public virtual DbSet<EveUnits> EveUnits { get; set; }
        public virtual DbSet<IndustryActivity> IndustryActivity { get; set; }
        public virtual DbSet<IndustryActivityMaterials> IndustryActivityMaterials { get; set; }
        public virtual DbSet<IndustryActivityProbabilities> IndustryActivityProbabilities { get; set; }
        public virtual DbSet<IndustryActivityProducts> IndustryActivityProducts { get; set; }
        public virtual DbSet<IndustryActivityRaces> IndustryActivityRaces { get; set; }
        public virtual DbSet<IndustryActivitySkills> IndustryActivitySkills { get; set; }
        public virtual DbSet<IndustryBlueprints> IndustryBlueprints { get; set; }
        public virtual DbSet<InvCategories> InvCategories { get; set; }
        public virtual DbSet<InvContrabandTypes> InvContrabandTypes { get; set; }
        public virtual DbSet<InvControlTowerResourcePurposes> InvControlTowerResourcePurposes { get; set; }
        public virtual DbSet<InvControlTowerResources> InvControlTowerResources { get; set; }
        public virtual DbSet<InvFlags> InvFlags { get; set; }
        public virtual DbSet<InvGroups> InvGroups { get; set; }
        public virtual DbSet<InvItems> InvItems { get; set; }
        public virtual DbSet<InvMarketGroups> InvMarketGroups { get; set; }
        public virtual DbSet<InvMetaGroups> InvMetaGroups { get; set; }
        public virtual DbSet<InvMetaTypes> InvMetaTypes { get; set; }
        public virtual DbSet<InvNames> InvNames { get; set; }
        public virtual DbSet<InvPositions> InvPositions { get; set; }
        public virtual DbSet<InvTraits> InvTraits { get; set; }
        public virtual DbSet<InvTypeMaterials> InvTypeMaterials { get; set; }
        public virtual DbSet<InvTypeReactions> InvTypeReactions { get; set; }
        public virtual DbSet<InvTypes> InvTypes { get; set; }
        public virtual DbSet<InvUniqueNames> InvUniqueNames { get; set; }
        public virtual DbSet<InvVolumes> InvVolumes { get; set; }
        public virtual DbSet<MapCelestialStatistics> MapCelestialStatistics { get; set; }
        public virtual DbSet<MapConstellationJumps> MapConstellationJumps { get; set; }
        public virtual DbSet<MapConstellations> MapConstellations { get; set; }
        public virtual DbSet<MapDenormalize> MapDenormalize { get; set; }
        public virtual DbSet<MapJumps> MapJumps { get; set; }
        public virtual DbSet<MapLandmarks> MapLandmarks { get; set; }
        public virtual DbSet<MapLocationScenes> MapLocationScenes { get; set; }
        public virtual DbSet<MapLocationWormholeClasses> MapLocationWormholeClasses { get; set; }
        public virtual DbSet<MapRegionJumps> MapRegionJumps { get; set; }
        public virtual DbSet<MapRegions> MapRegions { get; set; }
        public virtual DbSet<MapSolarSystemJumps> MapSolarSystemJumps { get; set; }
        public virtual DbSet<MapSolarSystems> MapSolarSystems { get; set; }
        public virtual DbSet<MapUniverse> MapUniverse { get; set; }
        public virtual DbSet<PlanetSchematics> PlanetSchematics { get; set; }
        public virtual DbSet<PlanetSchematicsPinMap> PlanetSchematicsPinMap { get; set; }
        public virtual DbSet<PlanetSchematicsTypeMap> PlanetSchematicsTypeMap { get; set; }
        public virtual DbSet<RamActivities> RamActivities { get; set; }
        public virtual DbSet<RamAssemblyLineStations> RamAssemblyLineStations { get; set; }
        public virtual DbSet<RamAssemblyLineTypeDetailPerCategory> RamAssemblyLineTypeDetailPerCategory { get; set; }
        public virtual DbSet<RamAssemblyLineTypeDetailPerGroup> RamAssemblyLineTypeDetailPerGroup { get; set; }
        public virtual DbSet<RamAssemblyLineTypes> RamAssemblyLineTypes { get; set; }
        public virtual DbSet<RamInstallationTypeContents> RamInstallationTypeContents { get; set; }
        public virtual DbSet<SkinLicense> SkinLicense { get; set; }
        public virtual DbSet<SkinMaterials> SkinMaterials { get; set; }
        public virtual DbSet<SkinShip> SkinShip { get; set; }
        public virtual DbSet<Skins> Skins { get; set; }
        public virtual DbSet<StaOperationServices> StaOperationServices { get; set; }
        public virtual DbSet<StaOperations> StaOperations { get; set; }
        public virtual DbSet<StaServices> StaServices { get; set; }
        public virtual DbSet<StaStationTypes> StaStationTypes { get; set; }
        public virtual DbSet<StaStations> StaStations { get; set; }
        public virtual DbSet<TranslationTables> TranslationTables { get; set; }
        public virtual DbSet<TrnTranslationColumns> TrnTranslationColumns { get; set; }
        public virtual DbSet<TrnTranslationLanguages> TrnTranslationLanguages { get; set; }
        public virtual DbSet<TrnTranslations> TrnTranslations { get; set; }
        public virtual DbSet<WarCombatZoneSystems> WarCombatZoneSystems { get; set; }
        public virtual DbSet<WarCombatZones> WarCombatZones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"DataSource={Utilities.Paths.SdeDataBasePath};");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgtAgentTypes>(entity =>
            {
                entity.HasKey(e => e.AgentTypeId);

                entity.ToTable("agtAgentTypes");

                entity.Property(e => e.AgentTypeId)
                    .HasColumnName("agentTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgentType)
                    .HasColumnName("agentType")
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<AgtAgents>(entity =>
            {
                entity.HasKey(e => e.AgentId);

                entity.ToTable("agtAgents");

                entity.HasIndex(e => e.CorporationId)
                    .HasName("ix_agtAgents_corporationID");

                entity.HasIndex(e => e.LocationId)
                    .HasName("ix_agtAgents_locationID");

                entity.Property(e => e.AgentId)
                    .HasColumnName("agentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgentTypeId).HasColumnName("agentTypeID");

                entity.Property(e => e.CorporationId).HasColumnName("corporationID");

                entity.Property(e => e.DivisionId).HasColumnName("divisionID");

                entity.Property(e => e.IsLocator)
                    .HasColumnName("isLocator")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Quality).HasColumnName("quality");
            });

            modelBuilder.Entity<AgtResearchAgents>(entity =>
            {
                entity.HasKey(e => new { e.AgentId, e.TypeId });

                entity.ToTable("agtResearchAgents");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_agtResearchAgents_typeID");

                entity.Property(e => e.AgentId).HasColumnName("agentID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<CertCerts>(entity =>
            {
                entity.HasKey(e => e.CertId);

                entity.ToTable("certCerts");

                entity.Property(e => e.CertId)
                    .HasColumnName("certID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(255)");
            });

            modelBuilder.Entity<CertMasteries>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("certMasteries");

                entity.Property(e => e.CertId).HasColumnName("certID");

                entity.Property(e => e.MasteryLevel).HasColumnName("masteryLevel");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<CertSkills>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("certSkills");

                entity.HasIndex(e => e.SkillId)
                    .HasName("ix_certSkills_skillID");

                entity.Property(e => e.CertId).HasColumnName("certID");

                entity.Property(e => e.CertLevelInt).HasColumnName("certLevelInt");

                entity.Property(e => e.CertLevelText)
                    .HasColumnName("certLevelText")
                    .HasColumnType("VARCHAR(8)");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.Property(e => e.SkillLevel).HasColumnName("skillLevel");
            });

            modelBuilder.Entity<ChrAncestries>(entity =>
            {
                entity.HasKey(e => e.AncestryId);

                entity.ToTable("chrAncestries");

                entity.Property(e => e.AncestryId)
                    .HasColumnName("ancestryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AncestryName)
                    .HasColumnName("ancestryName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.BloodlineId).HasColumnName("bloodlineID");

                entity.Property(e => e.Charisma).HasColumnName("charisma");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.Intelligence).HasColumnName("intelligence");

                entity.Property(e => e.Memory).HasColumnName("memory");

                entity.Property(e => e.Perception).HasColumnName("perception");

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("shortDescription")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.Willpower).HasColumnName("willpower");
            });

            modelBuilder.Entity<ChrAttributes>(entity =>
            {
                entity.HasKey(e => e.AttributeId);

                entity.ToTable("chrAttributes");

                entity.Property(e => e.AttributeId)
                    .HasColumnName("attributeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttributeName)
                    .HasColumnName("attributeName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("shortDescription")
                    .HasColumnType("VARCHAR(500)");
            });

            modelBuilder.Entity<ChrBloodlines>(entity =>
            {
                entity.HasKey(e => e.BloodlineId);

                entity.ToTable("chrBloodlines");

                entity.Property(e => e.BloodlineId)
                    .HasColumnName("bloodlineID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BloodlineName)
                    .HasColumnName("bloodlineName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Charisma).HasColumnName("charisma");

                entity.Property(e => e.CorporationId).HasColumnName("corporationID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.FemaleDescription)
                    .HasColumnName("femaleDescription")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.Intelligence).HasColumnName("intelligence");

                entity.Property(e => e.MaleDescription)
                    .HasColumnName("maleDescription")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.Memory).HasColumnName("memory");

                entity.Property(e => e.Perception).HasColumnName("perception");

                entity.Property(e => e.RaceId).HasColumnName("raceID");

                entity.Property(e => e.ShipTypeId).HasColumnName("shipTypeID");

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("shortDescription")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.ShortFemaleDescription)
                    .HasColumnName("shortFemaleDescription")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.ShortMaleDescription)
                    .HasColumnName("shortMaleDescription")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.Willpower).HasColumnName("willpower");
            });

            modelBuilder.Entity<ChrFactions>(entity =>
            {
                entity.HasKey(e => e.FactionId);

                entity.ToTable("chrFactions");

                entity.Property(e => e.FactionId)
                    .HasColumnName("factionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CorporationId).HasColumnName("corporationID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.FactionName)
                    .HasColumnName("factionName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.MilitiaCorporationId).HasColumnName("militiaCorporationID");

                entity.Property(e => e.RaceIds).HasColumnName("raceIDs");

                entity.Property(e => e.SizeFactor)
                    .HasColumnName("sizeFactor")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

                entity.Property(e => e.StationCount).HasColumnName("stationCount");

                entity.Property(e => e.StationSystemCount).HasColumnName("stationSystemCount");
            });

            modelBuilder.Entity<ChrRaces>(entity =>
            {
                entity.HasKey(e => e.RaceId);

                entity.ToTable("chrRaces");

                entity.Property(e => e.RaceId)
                    .HasColumnName("raceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.RaceName)
                    .HasColumnName("raceName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("shortDescription")
                    .HasColumnType("VARCHAR(500)");
            });

            modelBuilder.Entity<CrpActivities>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("crpActivities");

                entity.Property(e => e.ActivityId)
                    .HasColumnName("activityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityName)
                    .HasColumnName("activityName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");
            });

            modelBuilder.Entity<CrpNpccorporationDivisions>(entity =>
            {
                entity.HasKey(e => new { e.CorporationId, e.DivisionId });

                entity.ToTable("crpNPCCorporationDivisions");

                entity.Property(e => e.CorporationId).HasColumnName("corporationID");

                entity.Property(e => e.DivisionId).HasColumnName("divisionID");

                entity.Property(e => e.Size).HasColumnName("size");
            });

            modelBuilder.Entity<CrpNpccorporationResearchFields>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.CorporationId });

                entity.ToTable("crpNPCCorporationResearchFields");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.Property(e => e.CorporationId).HasColumnName("corporationID");
            });

            modelBuilder.Entity<CrpNpccorporationTrades>(entity =>
            {
                entity.HasKey(e => new { e.CorporationId, e.TypeId });

                entity.ToTable("crpNPCCorporationTrades");

                entity.Property(e => e.CorporationId).HasColumnName("corporationID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<CrpNpccorporations>(entity =>
            {
                entity.HasKey(e => e.CorporationId);

                entity.ToTable("crpNPCCorporations");

                entity.Property(e => e.CorporationId)
                    .HasColumnName("corporationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Border).HasColumnName("border");

                entity.Property(e => e.Corridor).HasColumnName("corridor");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(4000)");

                entity.Property(e => e.EnemyId).HasColumnName("enemyID");

                entity.Property(e => e.Extent)
                    .HasColumnName("extent")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.FactionId).HasColumnName("factionID");

                entity.Property(e => e.FriendId).HasColumnName("friendID");

                entity.Property(e => e.Fringe).HasColumnName("fringe");

                entity.Property(e => e.Hub).HasColumnName("hub");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.InitialPrice).HasColumnName("initialPrice");

                entity.Property(e => e.InvestorId1).HasColumnName("investorID1");

                entity.Property(e => e.InvestorId2).HasColumnName("investorID2");

                entity.Property(e => e.InvestorId3).HasColumnName("investorID3");

                entity.Property(e => e.InvestorId4).HasColumnName("investorID4");

                entity.Property(e => e.InvestorShares1).HasColumnName("investorShares1");

                entity.Property(e => e.InvestorShares2).HasColumnName("investorShares2");

                entity.Property(e => e.InvestorShares3).HasColumnName("investorShares3");

                entity.Property(e => e.InvestorShares4).HasColumnName("investorShares4");

                entity.Property(e => e.MinSecurity)
                    .HasColumnName("minSecurity")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.PublicShares).HasColumnName("publicShares");

                entity.Property(e => e.Scattered)
                    .HasColumnName("scattered")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.SizeFactor)
                    .HasColumnName("sizeFactor")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

                entity.Property(e => e.StationCount).HasColumnName("stationCount");

                entity.Property(e => e.StationSystemCount).HasColumnName("stationSystemCount");
            });

            modelBuilder.Entity<CrpNpcdivisions>(entity =>
            {
                entity.HasKey(e => e.DivisionId);

                entity.ToTable("crpNPCDivisions");

                entity.Property(e => e.DivisionId)
                    .HasColumnName("divisionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.DivisionName)
                    .HasColumnName("divisionName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.LeaderType)
                    .HasColumnName("leaderType")
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<DgmAttributeCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("dgmAttributeCategories");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("categoryDescription")
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<DgmAttributeTypes>(entity =>
            {
                entity.HasKey(e => e.AttributeId);

                entity.ToTable("dgmAttributeTypes");

                entity.Property(e => e.AttributeId)
                    .HasColumnName("attributeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttributeName)
                    .HasColumnName("attributeName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("defaultValue")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasColumnType("VARCHAR(150)");

                entity.Property(e => e.HighIsGood)
                    .HasColumnName("highIsGood")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Stackable)
                    .HasColumnName("stackable")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.UnitId).HasColumnName("unitID");
            });

            modelBuilder.Entity<DgmEffects>(entity =>
            {
                entity.HasKey(e => e.EffectId);

                entity.ToTable("dgmEffects");

                entity.Property(e => e.EffectId)
                    .HasColumnName("effectID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.DisallowAutoRepeat)
                    .HasColumnName("disallowAutoRepeat")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.DischargeAttributeId).HasColumnName("dischargeAttributeID");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Distribution).HasColumnName("distribution");

                entity.Property(e => e.DurationAttributeId).HasColumnName("durationAttributeID");

                entity.Property(e => e.EffectCategory).HasColumnName("effectCategory");

                entity.Property(e => e.EffectName)
                    .HasColumnName("effectName")
                    .HasColumnType("VARCHAR(400)");

                entity.Property(e => e.ElectronicChance)
                    .HasColumnName("electronicChance")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.FalloffAttributeId).HasColumnName("falloffAttributeID");

                entity.Property(e => e.FittingUsageChanceAttributeId).HasColumnName("fittingUsageChanceAttributeID");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("VARCHAR(60)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.IsAssistance)
                    .HasColumnName("isAssistance")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.IsOffensive)
                    .HasColumnName("isOffensive")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.IsWarpSafe)
                    .HasColumnName("isWarpSafe")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.ModifierInfo).HasColumnName("modifierInfo");

                entity.Property(e => e.NpcActivationChanceAttributeId).HasColumnName("npcActivationChanceAttributeID");

                entity.Property(e => e.NpcUsageChanceAttributeId).HasColumnName("npcUsageChanceAttributeID");

                entity.Property(e => e.PostExpression).HasColumnName("postExpression");

                entity.Property(e => e.PreExpression).HasColumnName("preExpression");

                entity.Property(e => e.PropulsionChance)
                    .HasColumnName("propulsionChance")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.RangeAttributeId).HasColumnName("rangeAttributeID");

                entity.Property(e => e.RangeChance)
                    .HasColumnName("rangeChance")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.SfxName)
                    .HasColumnName("sfxName")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.TrackingSpeedAttributeId).HasColumnName("trackingSpeedAttributeID");
            });

            modelBuilder.Entity<DgmExpressions>(entity =>
            {
                entity.HasKey(e => e.ExpressionId);

                entity.ToTable("dgmExpressions");

                entity.Property(e => e.ExpressionId)
                    .HasColumnName("expressionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Arg1).HasColumnName("arg1");

                entity.Property(e => e.Arg2).HasColumnName("arg2");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.ExpressionAttributeId).HasColumnName("expressionAttributeID");

                entity.Property(e => e.ExpressionGroupId).HasColumnName("expressionGroupID");

                entity.Property(e => e.ExpressionName)
                    .HasColumnName("expressionName")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.ExpressionTypeId).HasColumnName("expressionTypeID");

                entity.Property(e => e.ExpressionValue)
                    .HasColumnName("expressionValue")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.OperandId).HasColumnName("operandID");
            });

            modelBuilder.Entity<DgmTypeAttributes>(entity =>
            {
                entity.HasKey(e => new { e.TypeId, e.AttributeId });

                entity.ToTable("dgmTypeAttributes");

                entity.HasIndex(e => e.AttributeId)
                    .HasName("ix_dgmTypeAttributes_attributeID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.AttributeId).HasColumnName("attributeID");

                entity.Property(e => e.ValueFloat)
                    .HasColumnName("valueFloat")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ValueInt).HasColumnName("valueInt");
            });

            modelBuilder.Entity<DgmTypeEffects>(entity =>
            {
                entity.HasKey(e => new { e.TypeId, e.EffectId });

                entity.ToTable("dgmTypeEffects");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.EffectId).HasColumnName("effectID");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("isDefault")
                    .HasColumnType("BOOLEAN");
            });

            modelBuilder.Entity<EveGraphics>(entity =>
            {
                entity.HasKey(e => e.GraphicId);

                entity.ToTable("eveGraphics");

                entity.Property(e => e.GraphicId)
                    .HasColumnName("graphicID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GraphicFile)
                    .HasColumnName("graphicFile")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.SofFactionName)
                    .HasColumnName("sofFactionName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.SofHullName)
                    .HasColumnName("sofHullName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.SofRaceName)
                    .HasColumnName("sofRaceName")
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<EveIcons>(entity =>
            {
                entity.HasKey(e => e.IconId);

                entity.ToTable("eveIcons");

                entity.Property(e => e.IconId)
                    .HasColumnName("iconID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IconFile)
                    .HasColumnName("iconFile")
                    .HasColumnType("VARCHAR(500)");
            });

            modelBuilder.Entity<EveUnits>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.ToTable("eveUnits");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<IndustryActivity>(entity =>
            {
                entity.HasKey(e => new { e.TypeId, e.ActivityId });

                entity.ToTable("industryActivity");

                entity.HasIndex(e => e.ActivityId)
                    .HasName("ix_industryActivity_activityID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<IndustryActivityMaterials>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("industryActivityMaterials");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_industryActivityMaterials_typeID");

                entity.HasIndex(e => new { e.TypeId, e.ActivityId })
                    .HasName("industryActivityMaterials_idx1");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.MaterialTypeId).HasColumnName("materialTypeID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<IndustryActivityProbabilities>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("industryActivityProbabilities");

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("ix_industryActivityProbabilities_productTypeID");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_industryActivityProbabilities_typeID");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.Probability)
                    .HasColumnName("probability")
                    .HasColumnType("DECIMAL(3, 2)");

                entity.Property(e => e.ProductTypeId).HasColumnName("productTypeID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<IndustryActivityProducts>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("industryActivityProducts");

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("ix_industryActivityProducts_productTypeID");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_industryActivityProducts_typeID");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.ProductTypeId).HasColumnName("productTypeID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<IndustryActivityRaces>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("industryActivityRaces");

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("ix_industryActivityRaces_productTypeID");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_industryActivityRaces_typeID");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.ProductTypeId).HasColumnName("productTypeID");

                entity.Property(e => e.RaceId).HasColumnName("raceID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<IndustryActivitySkills>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("industryActivitySkills");

                entity.HasIndex(e => e.SkillId)
                    .HasName("ix_industryActivitySkills_skillID");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_industryActivitySkills_typeID");

                entity.HasIndex(e => new { e.TypeId, e.ActivityId })
                    .HasName("industryActivitySkills_idx1");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<IndustryBlueprints>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("industryBlueprints");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaxProductionLimit).HasColumnName("maxProductionLimit");
            });

            modelBuilder.Entity<InvCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("invCategories");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("BOOLEAN");
            });

            modelBuilder.Entity<InvContrabandTypes>(entity =>
            {
                entity.HasKey(e => new { e.FactionId, e.TypeId });

                entity.ToTable("invContrabandTypes");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_invContrabandTypes_typeID");

                entity.Property(e => e.FactionId).HasColumnName("factionID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.AttackMinSec)
                    .HasColumnName("attackMinSec")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ConfiscateMinSec)
                    .HasColumnName("confiscateMinSec")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.FineByValue)
                    .HasColumnName("fineByValue")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.StandingLoss)
                    .HasColumnName("standingLoss")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<InvControlTowerResourcePurposes>(entity =>
            {
                entity.HasKey(e => e.Purpose);

                entity.ToTable("invControlTowerResourcePurposes");

                entity.Property(e => e.Purpose)
                    .HasColumnName("purpose")
                    .ValueGeneratedNever();

                entity.Property(e => e.PurposeText)
                    .HasColumnName("purposeText")
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<InvControlTowerResources>(entity =>
            {
                entity.HasKey(e => new { e.ControlTowerTypeId, e.ResourceTypeId });

                entity.ToTable("invControlTowerResources");

                entity.Property(e => e.ControlTowerTypeId).HasColumnName("controlTowerTypeID");

                entity.Property(e => e.ResourceTypeId).HasColumnName("resourceTypeID");

                entity.Property(e => e.FactionId).HasColumnName("factionID");

                entity.Property(e => e.MinSecurityLevel)
                    .HasColumnName("minSecurityLevel")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Purpose).HasColumnName("purpose");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<InvFlags>(entity =>
            {
                entity.HasKey(e => e.FlagId);

                entity.ToTable("invFlags");

                entity.Property(e => e.FlagId)
                    .HasColumnName("flagID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FlagName)
                    .HasColumnName("flagName")
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.FlagText)
                    .HasColumnName("flagText")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.OrderId).HasColumnName("orderID");
            });

            modelBuilder.Entity<InvGroups>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("invGroups");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("ix_invGroups_categoryID");

                entity.Property(e => e.GroupId)
                    .HasColumnName("groupID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anchorable)
                    .HasColumnName("anchorable")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Anchored)
                    .HasColumnName("anchored")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.FittableNonSingleton)
                    .HasColumnName("fittableNonSingleton")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.GroupName)
                    .HasColumnName("groupName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.UseBasePrice)
                    .HasColumnName("useBasePrice")
                    .HasColumnType("BOOLEAN");
            });

            modelBuilder.Entity<InvItems>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("invItems");

                entity.HasIndex(e => e.LocationId)
                    .HasName("ix_invItems_locationID");

                entity.HasIndex(e => new { e.OwnerId, e.LocationId })
                    .HasName("items_IX_OwnerLocation");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FlagId).HasColumnName("flagID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.OwnerId).HasColumnName("ownerID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<InvMarketGroups>(entity =>
            {
                entity.HasKey(e => e.MarketGroupId);

                entity.ToTable("invMarketGroups");

                entity.Property(e => e.MarketGroupId)
                    .HasColumnName("marketGroupID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(3000)");

                entity.Property(e => e.HasTypes)
                    .HasColumnName("hasTypes")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.MarketGroupName)
                    .HasColumnName("marketGroupName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.ParentGroupId).HasColumnName("parentGroupID");

                entity.HasOne(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentGroupId);

                entity.HasMany(e => e.InventoryChildren)
                    .WithOne(e => e.MarketGroup)
                    .HasForeignKey(e => e.MarketGroupId);
            });

            modelBuilder.Entity<InvMetaGroups>(entity =>
            {
                entity.HasKey(e => e.MetaGroupId);

                entity.ToTable("invMetaGroups");

                entity.Property(e => e.MetaGroupId)
                    .HasColumnName("metaGroupID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.MetaGroupName)
                    .HasColumnName("metaGroupName")
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<InvMetaTypes>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("invMetaTypes");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MetaGroupId).HasColumnName("metaGroupID");

                entity.Property(e => e.ParentTypeId).HasColumnName("parentTypeID");
            });

            modelBuilder.Entity<InvNames>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("invNames");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName")
                    .HasColumnType("VARCHAR(200)");
            });

            modelBuilder.Entity<InvPositions>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("invPositions");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pitch)
                    .HasColumnName("pitch")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Roll)
                    .HasColumnName("roll")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Yaw)
                    .HasColumnName("yaw")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<InvTraits>(entity =>
            {
                entity.HasKey(e => e.TraitId);

                entity.ToTable("invTraits");

                entity.Property(e => e.TraitId)
                    .HasColumnName("traitID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.BonusText).HasColumnName("bonusText");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.UnitId).HasColumnName("unitID");
            });

            modelBuilder.Entity<InvTypeMaterials>(entity =>
            {
                entity.HasKey(e => new { e.TypeId, e.MaterialTypeId });

                entity.ToTable("invTypeMaterials");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.MaterialTypeId).HasColumnName("materialTypeID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<InvTypeReactions>(entity =>
            {
                entity.HasKey(e => new { e.ReactionTypeId, e.Input, e.TypeId });

                entity.ToTable("invTypeReactions");

                entity.Property(e => e.ReactionTypeId).HasColumnName("reactionTypeID");

                entity.Property(e => e.Input)
                    .HasColumnName("input")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<InvTypes>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("invTypes");

                entity.HasIndex(e => e.GroupId)
                    .HasName("ix_invTypes_groupID");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BasePrice)
                    .HasColumnName("basePrice")
                    .HasColumnType("DECIMAL(19, 4)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GraphicId).HasColumnName("graphicID");

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.MarketGroupId).HasColumnName("marketGroupID");

                entity.Property(e => e.Mass)
                    .HasColumnName("mass")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.PortionSize).HasColumnName("portionSize");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.RaceId).HasColumnName("raceID");

                entity.Property(e => e.SoundId).HasColumnName("soundID");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Volume)
                    .HasColumnName("volume")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<InvUniqueNames>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("invUniqueNames");

                entity.HasIndex(e => e.ItemName)
                    .HasName("ix_invUniqueNames_itemName")
                    .IsUnique();

                entity.HasIndex(e => new { e.GroupId, e.ItemName })
                    .HasName("invUniqueNames_IX_GroupName");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName")
                    .HasColumnType("VARCHAR(200)");
            });

            modelBuilder.Entity<InvVolumes>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("invVolumes");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Volume).HasColumnName("volume");
            });

            modelBuilder.Entity<MapCelestialStatistics>(entity =>
            {
                entity.HasKey(e => e.CelestialId);

                entity.ToTable("mapCelestialStatistics");

                entity.Property(e => e.CelestialId)
                    .HasColumnName("celestialID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Density)
                    .HasColumnName("density")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Eccentricity)
                    .HasColumnName("eccentricity")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.EscapeVelocity)
                    .HasColumnName("escapeVelocity")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Fragmented)
                    .HasColumnName("fragmented")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Life)
                    .HasColumnName("life")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Locked)
                    .HasColumnName("locked")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Luminosity)
                    .HasColumnName("luminosity")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Mass).HasColumnName("mass");

                entity.Property(e => e.MassDust)
                    .HasColumnName("massDust")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.MassGas)
                    .HasColumnName("massGas")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.OrbitPeriod)
                    .HasColumnName("orbitPeriod")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.OrbitRadius)
                    .HasColumnName("orbitRadius")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Pressure)
                    .HasColumnName("pressure")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Radius)
                    .HasColumnName("radius")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.RotationRate)
                    .HasColumnName("rotationRate")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.SpectralClass)
                    .HasColumnName("spectralClass")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.SurfaceGravity)
                    .HasColumnName("surfaceGravity")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Temperature)
                    .HasColumnName("temperature")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<MapConstellationJumps>(entity =>
            {
                entity.HasKey(e => new { e.FromConstellationId, e.ToConstellationId });

                entity.ToTable("mapConstellationJumps");

                entity.Property(e => e.FromConstellationId).HasColumnName("fromConstellationID");

                entity.Property(e => e.ToConstellationId).HasColumnName("toConstellationID");

                entity.Property(e => e.FromRegionId).HasColumnName("fromRegionID");

                entity.Property(e => e.ToRegionId).HasColumnName("toRegionID");
            });

            modelBuilder.Entity<MapConstellations>(entity =>
            {
                entity.HasKey(e => e.ConstellationId);

                entity.ToTable("mapConstellations");

                entity.Property(e => e.ConstellationId)
                    .HasColumnName("constellationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConstellationName)
                    .HasColumnName("constellationName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.FactionId).HasColumnName("factionID");

                entity.Property(e => e.Radius)
                    .HasColumnName("radius")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.RegionId).HasColumnName("regionID");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMax)
                    .HasColumnName("xMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMin)
                    .HasColumnName("xMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMax)
                    .HasColumnName("yMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMin)
                    .HasColumnName("yMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMax)
                    .HasColumnName("zMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMin)
                    .HasColumnName("zMin")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<MapDenormalize>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("mapDenormalize");

                entity.HasIndex(e => e.ConstellationId)
                    .HasName("ix_mapDenormalize_constellationID");

                entity.HasIndex(e => e.OrbitId)
                    .HasName("ix_mapDenormalize_orbitID");

                entity.HasIndex(e => e.RegionId)
                    .HasName("ix_mapDenormalize_regionID");

                entity.HasIndex(e => e.SolarSystemId)
                    .HasName("ix_mapDenormalize_solarSystemID");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_mapDenormalize_typeID");

                entity.HasIndex(e => new { e.GroupId, e.ConstellationId })
                    .HasName("mapDenormalize_IX_groupConstellation");

                entity.HasIndex(e => new { e.GroupId, e.RegionId })
                    .HasName("mapDenormalize_IX_groupRegion");

                entity.HasIndex(e => new { e.GroupId, e.SolarSystemId })
                    .HasName("mapDenormalize_IX_groupSystem");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CelestialIndex).HasColumnName("celestialIndex");

                entity.Property(e => e.ConstellationId).HasColumnName("constellationID");

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.ItemName)
                    .HasColumnName("itemName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.OrbitId).HasColumnName("orbitID");

                entity.Property(e => e.OrbitIndex).HasColumnName("orbitIndex");

                entity.Property(e => e.Radius)
                    .HasColumnName("radius")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.RegionId).HasColumnName("regionID");

                entity.Property(e => e.Security)
                    .HasColumnName("security")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<MapJumps>(entity =>
            {
                entity.HasKey(e => e.StargateId);

                entity.ToTable("mapJumps");

                entity.Property(e => e.StargateId)
                    .HasColumnName("stargateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DestinationId).HasColumnName("destinationID");
            });

            modelBuilder.Entity<MapLandmarks>(entity =>
            {
                entity.HasKey(e => e.LandmarkId);

                entity.ToTable("mapLandmarks");

                entity.Property(e => e.LandmarkId)
                    .HasColumnName("landmarkID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IconId).HasColumnName("iconID");

                entity.Property(e => e.LandmarkName)
                    .HasColumnName("landmarkName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<MapLocationScenes>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("mapLocationScenes");

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GraphicId).HasColumnName("graphicID");
            });

            modelBuilder.Entity<MapLocationWormholeClasses>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("mapLocationWormholeClasses");

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.WormholeClassId).HasColumnName("wormholeClassID");
            });

            modelBuilder.Entity<MapRegionJumps>(entity =>
            {
                entity.HasKey(e => new { e.FromRegionId, e.ToRegionId });

                entity.ToTable("mapRegionJumps");

                entity.Property(e => e.FromRegionId).HasColumnName("fromRegionID");

                entity.Property(e => e.ToRegionId).HasColumnName("toRegionID");
            });

            modelBuilder.Entity<MapRegions>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.ToTable("mapRegions");

                entity.Property(e => e.RegionId)
                    .HasColumnName("regionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FactionId).HasColumnName("factionID");

                entity.Property(e => e.Radius)
                    .HasColumnName("radius")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.RegionName)
                    .HasColumnName("regionName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMax)
                    .HasColumnName("xMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMin)
                    .HasColumnName("xMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMax)
                    .HasColumnName("yMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMin)
                    .HasColumnName("yMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMax)
                    .HasColumnName("zMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMin)
                    .HasColumnName("zMin")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<MapSolarSystemJumps>(entity =>
            {
                entity.HasKey(e => new { e.FromSolarSystemId, e.ToSolarSystemId });

                entity.ToTable("mapSolarSystemJumps");

                entity.Property(e => e.FromSolarSystemId).HasColumnName("fromSolarSystemID");

                entity.Property(e => e.ToSolarSystemId).HasColumnName("toSolarSystemID");

                entity.Property(e => e.FromConstellationId).HasColumnName("fromConstellationID");

                entity.Property(e => e.FromRegionId).HasColumnName("fromRegionID");

                entity.Property(e => e.ToConstellationId).HasColumnName("toConstellationID");

                entity.Property(e => e.ToRegionId).HasColumnName("toRegionID");
            });

            modelBuilder.Entity<MapSolarSystems>(entity =>
            {
                entity.HasKey(e => e.SolarSystemId);

                entity.ToTable("mapSolarSystems");

                entity.HasIndex(e => e.ConstellationId)
                    .HasName("ix_mapSolarSystems_constellationID");

                entity.HasIndex(e => e.RegionId)
                    .HasName("ix_mapSolarSystems_regionID");

                entity.HasIndex(e => e.Security)
                    .HasName("ix_mapSolarSystems_security");

                entity.Property(e => e.SolarSystemId)
                    .HasColumnName("solarSystemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Border)
                    .HasColumnName("border")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Constellation)
                    .HasColumnName("constellation")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.ConstellationId).HasColumnName("constellationID");

                entity.Property(e => e.Corridor)
                    .HasColumnName("corridor")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.FactionId).HasColumnName("factionID");

                entity.Property(e => e.Fringe)
                    .HasColumnName("fringe")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Hub)
                    .HasColumnName("hub")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.International)
                    .HasColumnName("international")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Luminosity)
                    .HasColumnName("luminosity")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Radius)
                    .HasColumnName("radius")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.RegionId).HasColumnName("regionID");

                entity.Property(e => e.Regional)
                    .HasColumnName("regional")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Security)
                    .HasColumnName("security")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.SecurityClass)
                    .HasColumnName("securityClass")
                    .HasColumnType("VARCHAR(2)");

                entity.Property(e => e.SolarSystemName)
                    .HasColumnName("solarSystemName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.SunTypeId).HasColumnName("sunTypeID");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMax)
                    .HasColumnName("xMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMin)
                    .HasColumnName("xMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMax)
                    .HasColumnName("yMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMin)
                    .HasColumnName("yMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMax)
                    .HasColumnName("zMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMin)
                    .HasColumnName("zMin")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<MapUniverse>(entity =>
            {
                entity.HasKey(e => e.UniverseId);

                entity.ToTable("mapUniverse");

                entity.Property(e => e.UniverseId)
                    .HasColumnName("universeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Radius)
                    .HasColumnName("radius")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.UniverseName)
                    .HasColumnName("universeName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMax)
                    .HasColumnName("xMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.XMin)
                    .HasColumnName("xMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMax)
                    .HasColumnName("yMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.YMin)
                    .HasColumnName("yMin")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMax)
                    .HasColumnName("zMax")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ZMin)
                    .HasColumnName("zMin")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<PlanetSchematics>(entity =>
            {
                entity.HasKey(e => e.SchematicId);

                entity.ToTable("planetSchematics");

                entity.Property(e => e.SchematicId)
                    .HasColumnName("schematicID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CycleTime).HasColumnName("cycleTime");

                entity.Property(e => e.SchematicName)
                    .HasColumnName("schematicName")
                    .HasColumnType("VARCHAR(255)");
            });

            modelBuilder.Entity<PlanetSchematicsPinMap>(entity =>
            {
                entity.HasKey(e => new { e.SchematicId, e.PinTypeId });

                entity.ToTable("planetSchematicsPinMap");

                entity.Property(e => e.SchematicId).HasColumnName("schematicID");

                entity.Property(e => e.PinTypeId).HasColumnName("pinTypeID");
            });

            modelBuilder.Entity<PlanetSchematicsTypeMap>(entity =>
            {
                entity.HasKey(e => new { e.SchematicId, e.TypeId });

                entity.ToTable("planetSchematicsTypeMap");

                entity.Property(e => e.SchematicId).HasColumnName("schematicID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.IsInput)
                    .HasColumnName("isInput")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<RamActivities>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("ramActivities");

                entity.Property(e => e.ActivityId)
                    .HasColumnName("activityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityName)
                    .HasColumnName("activityName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.IconNo)
                    .HasColumnName("iconNo")
                    .HasColumnType("VARCHAR(5)");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("BOOLEAN");
            });

            modelBuilder.Entity<RamAssemblyLineStations>(entity =>
            {
                entity.HasKey(e => new { e.StationId, e.AssemblyLineTypeId });

                entity.ToTable("ramAssemblyLineStations");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("ix_ramAssemblyLineStations_ownerID");

                entity.HasIndex(e => e.RegionId)
                    .HasName("ix_ramAssemblyLineStations_regionID");

                entity.HasIndex(e => e.SolarSystemId)
                    .HasName("ix_ramAssemblyLineStations_solarSystemID");

                entity.Property(e => e.StationId).HasColumnName("stationID");

                entity.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

                entity.Property(e => e.OwnerId).HasColumnName("ownerID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RegionId).HasColumnName("regionID");

                entity.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

                entity.Property(e => e.StationTypeId).HasColumnName("stationTypeID");
            });

            modelBuilder.Entity<RamAssemblyLineTypeDetailPerCategory>(entity =>
            {
                entity.HasKey(e => new { e.AssemblyLineTypeId, e.CategoryId });

                entity.ToTable("ramAssemblyLineTypeDetailPerCategory");

                entity.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CostMultiplier)
                    .HasColumnName("costMultiplier")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.MaterialMultiplier)
                    .HasColumnName("materialMultiplier")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.TimeMultiplier)
                    .HasColumnName("timeMultiplier")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<RamAssemblyLineTypeDetailPerGroup>(entity =>
            {
                entity.HasKey(e => new { e.AssemblyLineTypeId, e.GroupId });

                entity.ToTable("ramAssemblyLineTypeDetailPerGroup");

                entity.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.CostMultiplier)
                    .HasColumnName("costMultiplier")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.MaterialMultiplier)
                    .HasColumnName("materialMultiplier")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.TimeMultiplier)
                    .HasColumnName("timeMultiplier")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<RamAssemblyLineTypes>(entity =>
            {
                entity.HasKey(e => e.AssemblyLineTypeId);

                entity.ToTable("ramAssemblyLineTypes");

                entity.Property(e => e.AssemblyLineTypeId)
                    .HasColumnName("assemblyLineTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.AssemblyLineTypeName)
                    .HasColumnName("assemblyLineTypeName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.BaseCostMultiplier)
                    .HasColumnName("baseCostMultiplier")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.BaseMaterialMultiplier)
                    .HasColumnName("baseMaterialMultiplier")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.BaseTimeMultiplier)
                    .HasColumnName("baseTimeMultiplier")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.MinCostPerHour)
                    .HasColumnName("minCostPerHour")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Volume)
                    .HasColumnName("volume")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<RamInstallationTypeContents>(entity =>
            {
                entity.HasKey(e => new { e.InstallationTypeId, e.AssemblyLineTypeId });

                entity.ToTable("ramInstallationTypeContents");

                entity.Property(e => e.InstallationTypeId).HasColumnName("installationTypeID");

                entity.Property(e => e.AssemblyLineTypeId).HasColumnName("assemblyLineTypeID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<SkinLicense>(entity =>
            {
                entity.HasKey(e => e.LicenseTypeId);

                entity.ToTable("skinLicense");

                entity.Property(e => e.LicenseTypeId)
                    .HasColumnName("licenseTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.SkinId).HasColumnName("skinID");
            });

            modelBuilder.Entity<SkinMaterials>(entity =>
            {
                entity.HasKey(e => e.SkinMaterialId);

                entity.ToTable("skinMaterials");

                entity.Property(e => e.SkinMaterialId)
                    .HasColumnName("skinMaterialID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DisplayNameId).HasColumnName("displayNameID");

                entity.Property(e => e.MaterialSetId).HasColumnName("materialSetID");
            });

            modelBuilder.Entity<SkinShip>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("skinShip");

                entity.HasIndex(e => e.SkinId)
                    .HasName("ix_skinShip_skinID");

                entity.HasIndex(e => e.TypeId)
                    .HasName("ix_skinShip_typeID");

                entity.Property(e => e.SkinId).HasColumnName("skinID");

                entity.Property(e => e.TypeId).HasColumnName("typeID");
            });

            modelBuilder.Entity<Skins>(entity =>
            {
                entity.HasKey(e => e.SkinId);

                entity.ToTable("skins");

                entity.Property(e => e.SkinId)
                    .HasColumnName("skinID")
                    .ValueGeneratedNever();

                entity.Property(e => e.InternalName)
                    .HasColumnName("internalName")
                    .HasColumnType("VARCHAR(70)");

                entity.Property(e => e.SkinMaterialId).HasColumnName("skinMaterialID");
            });

            modelBuilder.Entity<StaOperationServices>(entity =>
            {
                entity.HasKey(e => new { e.OperationId, e.ServiceId });

                entity.ToTable("staOperationServices");

                entity.Property(e => e.OperationId).HasColumnName("operationID");

                entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            });

            modelBuilder.Entity<StaOperations>(entity =>
            {
                entity.HasKey(e => e.OperationId);

                entity.ToTable("staOperations");

                entity.Property(e => e.OperationId)
                    .HasColumnName("operationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.AmarrStationTypeId).HasColumnName("amarrStationTypeID");

                entity.Property(e => e.Border).HasColumnName("border");

                entity.Property(e => e.CaldariStationTypeId).HasColumnName("caldariStationTypeID");

                entity.Property(e => e.Corridor).HasColumnName("corridor");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.Fringe).HasColumnName("fringe");

                entity.Property(e => e.GallenteStationTypeId).HasColumnName("gallenteStationTypeID");

                entity.Property(e => e.Hub).HasColumnName("hub");

                entity.Property(e => e.JoveStationTypeId).HasColumnName("joveStationTypeID");

                entity.Property(e => e.MinmatarStationTypeId).HasColumnName("minmatarStationTypeID");

                entity.Property(e => e.OperationName)
                    .HasColumnName("operationName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Ratio).HasColumnName("ratio");
            });

            modelBuilder.Entity<StaServices>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("staServices");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("serviceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(1000)");

                entity.Property(e => e.ServiceName)
                    .HasColumnName("serviceName")
                    .HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<StaStationTypes>(entity =>
            {
                entity.HasKey(e => e.StationTypeId);

                entity.ToTable("staStationTypes");

                entity.Property(e => e.StationTypeId)
                    .HasColumnName("stationTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Conquerable)
                    .HasColumnName("conquerable")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.DockEntryX)
                    .HasColumnName("dockEntryX")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.DockEntryY)
                    .HasColumnName("dockEntryY")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.DockEntryZ)
                    .HasColumnName("dockEntryZ")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.DockOrientationX)
                    .HasColumnName("dockOrientationX")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.DockOrientationY)
                    .HasColumnName("dockOrientationY")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.DockOrientationZ)
                    .HasColumnName("dockOrientationZ")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.OfficeSlots).HasColumnName("officeSlots");

                entity.Property(e => e.OperationId).HasColumnName("operationID");

                entity.Property(e => e.ReprocessingEfficiency)
                    .HasColumnName("reprocessingEfficiency")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<StaStations>(entity =>
            {
                entity.HasKey(e => e.StationId);

                entity.ToTable("staStations");

                entity.HasIndex(e => e.ConstellationId)
                    .HasName("ix_staStations_constellationID");

                entity.HasIndex(e => e.CorporationId)
                    .HasName("ix_staStations_corporationID");

                entity.HasIndex(e => e.OperationId)
                    .HasName("ix_staStations_operationID");

                entity.HasIndex(e => e.RegionId)
                    .HasName("ix_staStations_regionID");

                entity.HasIndex(e => e.SolarSystemId)
                    .HasName("ix_staStations_solarSystemID");

                entity.HasIndex(e => e.StationTypeId)
                    .HasName("ix_staStations_stationTypeID");

                entity.Property(e => e.StationId)
                    .HasColumnName("stationID")
                    .HasColumnType("BIGINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConstellationId).HasColumnName("constellationID");

                entity.Property(e => e.CorporationId).HasColumnName("corporationID");

                entity.Property(e => e.DockingCostPerVolume)
                    .HasColumnName("dockingCostPerVolume")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.MaxShipVolumeDockable)
                    .HasColumnName("maxShipVolumeDockable")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.OfficeRentalCost).HasColumnName("officeRentalCost");

                entity.Property(e => e.OperationId).HasColumnName("operationID");

                entity.Property(e => e.RegionId).HasColumnName("regionID");

                entity.Property(e => e.ReprocessingEfficiency)
                    .HasColumnName("reprocessingEfficiency")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.ReprocessingHangarFlag).HasColumnName("reprocessingHangarFlag");

                entity.Property(e => e.ReprocessingStationsTake)
                    .HasColumnName("reprocessingStationsTake")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Security)
                    .HasColumnName("security")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.SolarSystemId).HasColumnName("solarSystemID");

                entity.Property(e => e.StationName)
                    .HasColumnName("stationName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.StationTypeId).HasColumnName("stationTypeID");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<TranslationTables>(entity =>
            {
                entity.HasKey(e => new { e.SourceTable, e.TranslatedKey });

                entity.ToTable("translationTables");

                entity.Property(e => e.SourceTable)
                    .HasColumnName("sourceTable")
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.TranslatedKey)
                    .HasColumnName("translatedKey")
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.DestinationTable)
                    .HasColumnName("destinationTable")
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.TcGroupId).HasColumnName("tcGroupID");

                entity.Property(e => e.TcId).HasColumnName("tcID");
            });

            modelBuilder.Entity<TrnTranslationColumns>(entity =>
            {
                entity.HasKey(e => e.TcId);

                entity.ToTable("trnTranslationColumns");

                entity.Property(e => e.TcId)
                    .HasColumnName("tcID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasColumnName("columnName")
                    .HasColumnType("VARCHAR(128)");

                entity.Property(e => e.MasterId)
                    .HasColumnName("masterID")
                    .HasColumnType("VARCHAR(128)");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("tableName")
                    .HasColumnType("VARCHAR(256)");

                entity.Property(e => e.TcGroupId).HasColumnName("tcGroupID");
            });

            modelBuilder.Entity<TrnTranslationLanguages>(entity =>
            {
                entity.HasKey(e => e.NumericLanguageId);

                entity.ToTable("trnTranslationLanguages");

                entity.Property(e => e.NumericLanguageId)
                    .HasColumnName("numericLanguageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LanguageId)
                    .HasColumnName("languageID")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.LanguageName)
                    .HasColumnName("languageName")
                    .HasColumnType("VARCHAR(200)");
            });

            modelBuilder.Entity<TrnTranslations>(entity =>
            {
                entity.HasKey(e => new { e.TcId, e.KeyId, e.LanguageId });

                entity.ToTable("trnTranslations");

                entity.Property(e => e.TcId).HasColumnName("tcID");

                entity.Property(e => e.KeyId).HasColumnName("keyID");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("languageID")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");
            });

            modelBuilder.Entity<WarCombatZoneSystems>(entity =>
            {
                entity.HasKey(e => e.SolarSystemId);

                entity.ToTable("warCombatZoneSystems");

                entity.Property(e => e.SolarSystemId)
                    .HasColumnName("solarSystemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CombatZoneId).HasColumnName("combatZoneID");
            });

            modelBuilder.Entity<WarCombatZones>(entity =>
            {
                entity.HasKey(e => e.CombatZoneId);

                entity.ToTable("warCombatZones");

                entity.Property(e => e.CombatZoneId)
                    .HasColumnName("combatZoneID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenterSystemId).HasColumnName("centerSystemID");

                entity.Property(e => e.CombatZoneName)
                    .HasColumnName("combatZoneName")
                    .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR(500)");

                entity.Property(e => e.FactionId).HasColumnName("factionID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
