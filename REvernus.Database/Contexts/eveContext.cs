namespace REvernus.Database.Contexts
{
    using Microsoft.EntityFrameworkCore;

    using REvernus.Database.EveDbModels;

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
                optionsBuilder.UseSqlite($"DataSource={Utilities.Paths.SdeDataBasePath};");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EveContext).Assembly);

  

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
