using Newtonsoft.Json;

namespace EVEStandard.Models
{ 
    /// <summary>
    /// Aggregate stats for a year
    /// </summary>
    
    public class AggregateStats : ModelBase<AggregateStats>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets Character
        /// </summary>
        [JsonProperty("character")]
        public CharacterStats Character { get; set; }

        /// <summary>
        /// Gets or Sets Combat
        /// </summary>
        [JsonProperty("combat")]
        public CombatStats Combat { get; set; }

        /// <summary>
        /// Gets or Sets Industry
        /// </summary>
        [JsonProperty("industry")]
        public IndustryStats Industry { get; set; }

        /// <summary>
        /// Gets or Sets Inventory
        /// </summary>
        [JsonProperty("inventory")]
        public InventoryStats Inventory { get; set; }

        /// <summary>
        /// Gets or Sets Isk
        /// </summary>
        [JsonProperty("isk")]
        public IskStats Isk { get; set; }

        /// <summary>
        /// Gets or Sets Market
        /// </summary>
        [JsonProperty("market")]
        public MarketStats Market { get; set; }

        /// <summary>
        /// Gets or Sets Mining
        /// </summary>
        [JsonProperty("mining")]
        public MiningStats Mining { get; set; }

        /// <summary>
        /// Gets or Sets Module
        /// </summary>
        [JsonProperty("module")]
        public ModuleStats Module { get; set; }

        /// <summary>
        /// Gets or Sets Orbital
        /// </summary>
        [JsonProperty("orbital")]
        public OrbitalStats Orbital { get; set; }

        /// <summary>
        /// Gets or Sets Pve
        /// </summary>
        [JsonProperty("pve")]
        public PveStats Pve { get; set; }

        /// <summary>
        /// Gets or Sets Social
        /// </summary>
        [JsonProperty("social")]
        public SocialStats Social { get; set; }

        /// <summary>
        /// Gets or Sets Travel
        /// </summary>
        [JsonProperty("travel")]
        public TravelStats Travel { get; set; }

        /// <summary>
        /// Gregorian year for this set of aggregates
        /// </summary>
        /// <value>Gregorian year for this set of aggregates</value>
        [JsonProperty("year")]
        public int Year { get; set; }

        #endregion Properties
    }
    public class CharacterStats : ModelBase<CharacterStats>
    {
        #region Properties

        /// <summary>
        /// days_of_activity integer
        /// </summary>
        /// <value>days_of_activity integer</value>
        [JsonProperty("days_of_activity")]
        public long? DaysOfActivity { get; set; }

        /// <summary>
        /// minutes integer
        /// </summary>
        /// <value>minutes integer</value>
        [JsonProperty("minutes")]
        public long? Minutes { get; set; }

        /// <summary>
        /// sessions_started integer
        /// </summary>
        /// <value>sessions_started integer</value>
        [JsonProperty("sessions_started")]
        public long? SessionsStarted { get; set; }

        #endregion Properties
    }
    public class CombatStats : ModelBase<CombatStats>
    {
        #region Properties

        /// <summary>
        /// cap_drainedby_npc integer
        /// </summary>
        /// <value>cap_drainedby_npc integer</value>
        [JsonProperty("cap_drainedby_npc")]
        public long? CapDrainedbyNpc { get; set; }

        /// <summary>
        /// cap_drainedby_pc integer
        /// </summary>
        /// <value>cap_drainedby_pc integer</value>
        [JsonProperty("cap_drainedby_pc")]
        public long? CapDrainedbyPc { get; set; }

        /// <summary>
        /// cap_draining_pc integer
        /// </summary>
        /// <value>cap_draining_pc integer</value>
        [JsonProperty("cap_draining_pc")]
        public long? CapDrainingPc { get; set; }

        /// <summary>
        /// criminal_flag_set integer
        /// </summary>
        /// <value>criminal_flag_set integer</value>
        [JsonProperty("criminal_flag_set")]
        public long? CriminalFlagSet { get; set; }

        /// <summary>
        /// damage_from_np_cs_amount integer
        /// </summary>
        /// <value>damage_from_np_cs_amount integer</value>
        [JsonProperty("damage_from_np_cs_amount")]
        public long? DamageFromNpCsAmount { get; set; }

        /// <summary>
        /// damage_from_np_cs_num_shots integer
        /// </summary>
        /// <value>damage_from_np_cs_num_shots integer</value>
        [JsonProperty("damage_from_np_cs_num_shots")]
        public long? DamageFromNpCsNumShots { get; set; }

        /// <summary>
        /// damage_from_players_bomb_amount integer
        /// </summary>
        /// <value>damage_from_players_bomb_amount integer</value>
        [JsonProperty("damage_from_players_bomb_amount")]
        public long? DamageFromPlayersBombAmount { get; set; }

        /// <summary>
        /// damage_from_players_bomb_num_shots integer
        /// </summary>
        /// <value>damage_from_players_bomb_num_shots integer</value>
        [JsonProperty("damage_from_players_bomb_num_shots")]
        public long? DamageFromPlayersBombNumShots { get; set; }

        /// <summary>
        /// damage_from_players_combat_drone_amount integer
        /// </summary>
        /// <value>damage_from_players_combat_drone_amount integer</value>
        [JsonProperty("damage_from_players_combat_drone_amount")]
        public long? DamageFromPlayersCombatDroneAmount { get; set; }

        /// <summary>
        /// damage_from_players_combat_drone_num_shots integer
        /// </summary>
        /// <value>damage_from_players_combat_drone_num_shots integer</value>
        [JsonProperty("damage_from_players_combat_drone_num_shots")]
        public long? DamageFromPlayersCombatDroneNumShots { get; set; }

        /// <summary>
        /// damage_from_players_energy_amount integer
        /// </summary>
        /// <value>damage_from_players_energy_amount integer</value>
        [JsonProperty("damage_from_players_energy_amount")]
        public long? DamageFromPlayersEnergyAmount { get; set; }

        /// <summary>
        /// damage_from_players_energy_num_shots integer
        /// </summary>
        /// <value>damage_from_players_energy_num_shots integer</value>
        [JsonProperty("damage_from_players_energy_num_shots")]
        public long? DamageFromPlayersEnergyNumShots { get; set; }

        /// <summary>
        /// damage_from_players_fighter_bomber_amount integer
        /// </summary>
        /// <value>damage_from_players_fighter_bomber_amount integer</value>
        [JsonProperty("damage_from_players_fighter_bomber_amount")]
        public long? DamageFromPlayersFighterBomberAmount { get; set; }

        /// <summary>
        /// damage_from_players_fighter_bomber_num_shots integer
        /// </summary>
        /// <value>damage_from_players_fighter_bomber_num_shots integer</value>
        [JsonProperty("damage_from_players_fighter_bomber_num_shots")]
        public long? DamageFromPlayersFighterBomberNumShots { get; set; }

        /// <summary>
        /// damage_from_players_fighter_drone_amount integer
        /// </summary>
        /// <value>damage_from_players_fighter_drone_amount integer</value>
        [JsonProperty("damage_from_players_fighter_drone_amount")]
        public long? DamageFromPlayersFighterDroneAmount { get; set; }

        /// <summary>
        /// damage_from_players_fighter_drone_num_shots integer
        /// </summary>
        /// <value>damage_from_players_fighter_drone_num_shots integer</value>
        [JsonProperty("damage_from_players_fighter_drone_num_shots")]
        public long? DamageFromPlayersFighterDroneNumShots { get; set; }

        /// <summary>
        /// damage_from_players_hybrid_amount integer
        /// </summary>
        /// <value>damage_from_players_hybrid_amount integer</value>
        [JsonProperty("damage_from_players_hybrid_amount")]
        public long? DamageFromPlayersHybridAmount { get; set; }

        /// <summary>
        /// damage_from_players_hybrid_num_shots integer
        /// </summary>
        /// <value>damage_from_players_hybrid_num_shots integer</value>
        [JsonProperty("damage_from_players_hybrid_num_shots")]
        public long? DamageFromPlayersHybridNumShots { get; set; }

        /// <summary>
        /// damage_from_players_missile_amount integer
        /// </summary>
        /// <value>damage_from_players_missile_amount integer</value>
        [JsonProperty("damage_from_players_missile_amount")]
        public long? DamageFromPlayersMissileAmount { get; set; }

        /// <summary>
        /// damage_from_players_missile_num_shots integer
        /// </summary>
        /// <value>damage_from_players_missile_num_shots integer</value>
        [JsonProperty("damage_from_players_missile_num_shots")]
        public long? DamageFromPlayersMissileNumShots { get; set; }

        /// <summary>
        /// damage_from_players_projectile_amount integer
        /// </summary>
        /// <value>damage_from_players_projectile_amount integer</value>
        [JsonProperty("damage_from_players_projectile_amount")]
        public long? DamageFromPlayersProjectileAmount { get; set; }

        /// <summary>
        /// damage_from_players_projectile_num_shots integer
        /// </summary>
        /// <value>damage_from_players_projectile_num_shots integer</value>
        [JsonProperty("damage_from_players_projectile_num_shots")]
        public long? DamageFromPlayersProjectileNumShots { get; set; }

        /// <summary>
        /// damage_from_players_smart_bomb_amount integer
        /// </summary>
        /// <value>damage_from_players_smart_bomb_amount integer</value>
        [JsonProperty("damage_from_players_smart_bomb_amount")]
        public long? DamageFromPlayersSmartBombAmount { get; set; }

        /// <summary>
        /// damage_from_players_smart_bomb_num_shots integer
        /// </summary>
        /// <value>damage_from_players_smart_bomb_num_shots integer</value>
        [JsonProperty("damage_from_players_smart_bomb_num_shots")]
        public long? DamageFromPlayersSmartBombNumShots { get; set; }

        /// <summary>
        /// damage_from_players_super_amount integer
        /// </summary>
        /// <value>damage_from_players_super_amount integer</value>
        [JsonProperty("damage_from_players_super_amount")]
        public long? DamageFromPlayersSuperAmount { get; set; }

        /// <summary>
        /// damage_from_players_super_num_shots integer
        /// </summary>
        /// <value>damage_from_players_super_num_shots integer</value>
        [JsonProperty("damage_from_players_super_num_shots")]
        public long? DamageFromPlayersSuperNumShots { get; set; }

        /// <summary>
        /// damage_from_structures_total_amount integer
        /// </summary>
        /// <value>damage_from_structures_total_amount integer</value>
        [JsonProperty("damage_from_structures_total_amount")]
        public long? DamageFromStructuresTotalAmount { get; set; }

        /// <summary>
        /// damage_from_structures_total_num_shots integer
        /// </summary>
        /// <value>damage_from_structures_total_num_shots integer</value>
        [JsonProperty("damage_from_structures_total_num_shots")]
        public long? DamageFromStructuresTotalNumShots { get; set; }

        /// <summary>
        /// damage_to_players_bomb_amount integer
        /// </summary>
        /// <value>damage_to_players_bomb_amount integer</value>
        [JsonProperty("damage_to_players_bomb_amount")]
        public long? DamageToPlayersBombAmount { get; set; }

        /// <summary>
        /// damage_to_players_bomb_num_shots integer
        /// </summary>
        /// <value>damage_to_players_bomb_num_shots integer</value>
        [JsonProperty("damage_to_players_bomb_num_shots")]
        public long? DamageToPlayersBombNumShots { get; set; }

        /// <summary>
        /// damage_to_players_combat_drone_amount integer
        /// </summary>
        /// <value>damage_to_players_combat_drone_amount integer</value>
        [JsonProperty("damage_to_players_combat_drone_amount")]
        public long? DamageToPlayersCombatDroneAmount { get; set; }

        /// <summary>
        /// damage_to_players_combat_drone_num_shots integer
        /// </summary>
        /// <value>damage_to_players_combat_drone_num_shots integer</value>
        [JsonProperty("damage_to_players_combat_drone_num_shots")]
        public long? DamageToPlayersCombatDroneNumShots { get; set; }

        /// <summary>
        /// damage_to_players_energy_amount integer
        /// </summary>
        /// <value>damage_to_players_energy_amount integer</value>
        [JsonProperty("damage_to_players_energy_amount")]
        public long? DamageToPlayersEnergyAmount { get; set; }

        /// <summary>
        /// damage_to_players_energy_num_shots integer
        /// </summary>
        /// <value>damage_to_players_energy_num_shots integer</value>
        [JsonProperty("damage_to_players_energy_num_shots")]
        public long? DamageToPlayersEnergyNumShots { get; set; }

        /// <summary>
        /// damage_to_players_fighter_bomber_amount integer
        /// </summary>
        /// <value>damage_to_players_fighter_bomber_amount integer</value>
        [JsonProperty("damage_to_players_fighter_bomber_amount")]
        public long? DamageToPlayersFighterBomberAmount { get; set; }

        /// <summary>
        /// damage_to_players_fighter_bomber_num_shots integer
        /// </summary>
        /// <value>damage_to_players_fighter_bomber_num_shots integer</value>
        [JsonProperty("damage_to_players_fighter_bomber_num_shots")]
        public long? DamageToPlayersFighterBomberNumShots { get; set; }

        /// <summary>
        /// damage_to_players_fighter_drone_amount integer
        /// </summary>
        /// <value>damage_to_players_fighter_drone_amount integer</value>
        [JsonProperty("damage_to_players_fighter_drone_amount")]
        public long? DamageToPlayersFighterDroneAmount { get; set; }

        /// <summary>
        /// damage_to_players_fighter_drone_num_shots integer
        /// </summary>
        /// <value>damage_to_players_fighter_drone_num_shots integer</value>
        [JsonProperty("damage_to_players_fighter_drone_num_shots")]
        public long? DamageToPlayersFighterDroneNumShots { get; set; }

        /// <summary>
        /// damage_to_players_hybrid_amount integer
        /// </summary>
        /// <value>damage_to_players_hybrid_amount integer</value>
        [JsonProperty("damage_to_players_hybrid_amount")]
        public long? DamageToPlayersHybridAmount { get; set; }

        /// <summary>
        /// damage_to_players_hybrid_num_shots integer
        /// </summary>
        /// <value>damage_to_players_hybrid_num_shots integer</value>
        [JsonProperty("damage_to_players_hybrid_num_shots")]
        public long? DamageToPlayersHybridNumShots { get; set; }

        /// <summary>
        /// damage_to_players_missile_amount integer
        /// </summary>
        /// <value>damage_to_players_missile_amount integer</value>
        [JsonProperty("damage_to_players_missile_amount")]
        public long? DamageToPlayersMissileAmount { get; set; }

        /// <summary>
        /// damage_to_players_missile_num_shots integer
        /// </summary>
        /// <value>damage_to_players_missile_num_shots integer</value>
        [JsonProperty("damage_to_players_missile_num_shots")]
        public long? DamageToPlayersMissileNumShots { get; set; }

        /// <summary>
        /// damage_to_players_projectile_amount integer
        /// </summary>
        /// <value>damage_to_players_projectile_amount integer</value>
        [JsonProperty("damage_to_players_projectile_amount")]
        public long? DamageToPlayersProjectileAmount { get; set; }

        /// <summary>
        /// damage_to_players_projectile_num_shots integer
        /// </summary>
        /// <value>damage_to_players_projectile_num_shots integer</value>
        [JsonProperty("damage_to_players_projectile_num_shots")]
        public long? DamageToPlayersProjectileNumShots { get; set; }

        /// <summary>
        /// damage_to_players_smart_bomb_amount integer
        /// </summary>
        /// <value>damage_to_players_smart_bomb_amount integer</value>
        [JsonProperty("damage_to_players_smart_bomb_amount")]
        public long? DamageToPlayersSmartBombAmount { get; set; }

        /// <summary>
        /// damage_to_players_smart_bomb_num_shots integer
        /// </summary>
        /// <value>damage_to_players_smart_bomb_num_shots integer</value>
        [JsonProperty("damage_to_players_smart_bomb_num_shots")]
        public long? DamageToPlayersSmartBombNumShots { get; set; }

        /// <summary>
        /// damage_to_players_super_amount integer
        /// </summary>
        /// <value>damage_to_players_super_amount integer</value>
        [JsonProperty("damage_to_players_super_amount")]
        public long? DamageToPlayersSuperAmount { get; set; }

        /// <summary>
        /// damage_to_players_super_num_shots integer
        /// </summary>
        /// <value>damage_to_players_super_num_shots integer</value>
        [JsonProperty("damage_to_players_super_num_shots")]
        public long? DamageToPlayersSuperNumShots { get; set; }

        /// <summary>
        /// damage_to_structures_total_amount integer
        /// </summary>
        /// <value>damage_to_structures_total_amount integer</value>
        [JsonProperty("damage_to_structures_total_amount")]
        public long? DamageToStructuresTotalAmount { get; set; }

        /// <summary>
        /// damage_to_structures_total_num_shots integer
        /// </summary>
        /// <value>damage_to_structures_total_num_shots integer</value>
        [JsonProperty("damage_to_structures_total_num_shots")]
        public long? DamageToStructuresTotalNumShots { get; set; }

        /// <summary>
        /// deaths_high_sec integer
        /// </summary>
        /// <value>deaths_high_sec integer</value>
        [JsonProperty("deaths_high_sec")]
        public long? DeathsHighSec { get; set; }

        /// <summary>
        /// deaths_low_sec integer
        /// </summary>
        /// <value>deaths_low_sec integer</value>
        [JsonProperty("deaths_low_sec")]
        public long? DeathsLowSec { get; set; }

        /// <summary>
        /// deaths_null_sec integer
        /// </summary>
        /// <value>deaths_null_sec integer</value>
        [JsonProperty("deaths_null_sec")]
        public long? DeathsNullSec { get; set; }

        /// <summary>
        /// deaths_pod_high_sec integer
        /// </summary>
        /// <value>deaths_pod_high_sec integer</value>
        [JsonProperty("deaths_pod_high_sec")]
        public long? DeathsPodHighSec { get; set; }

        /// <summary>
        /// deaths_pod_low_sec integer
        /// </summary>
        /// <value>deaths_pod_low_sec integer</value>
        [JsonProperty("deaths_pod_low_sec")]
        public long? DeathsPodLowSec { get; set; }

        /// <summary>
        /// deaths_pod_null_sec integer
        /// </summary>
        /// <value>deaths_pod_null_sec integer</value>
        [JsonProperty("deaths_pod_null_sec")]
        public long? DeathsPodNullSec { get; set; }

        /// <summary>
        /// deaths_pod_wormhole integer
        /// </summary>
        /// <value>deaths_pod_wormhole integer</value>
        [JsonProperty("deaths_pod_wormhole")]
        public long? DeathsPodWormhole { get; set; }

        /// <summary>
        /// deaths_wormhole integer
        /// </summary>
        /// <value>deaths_wormhole integer</value>
        [JsonProperty("deaths_wormhole")]
        public long? DeathsWormhole { get; set; }

        /// <summary>
        /// drone_engage integer
        /// </summary>
        /// <value>drone_engage integer</value>
        [JsonProperty("drone_engage")]
        public long? DroneEngage { get; set; }

        /// <summary>
        /// dscans integer
        /// </summary>
        /// <value>dscans integer</value>
        [JsonProperty("dscans")]
        public long? Dscans { get; set; }

        /// <summary>
        /// duel_requested integer
        /// </summary>
        /// <value>duel_requested integer</value>
        [JsonProperty("duel_requested")]
        public long? DuelRequested { get; set; }

        /// <summary>
        /// engagement_register integer
        /// </summary>
        /// <value>engagement_register integer</value>
        [JsonProperty("engagement_register")]
        public long? EngagementRegister { get; set; }

        /// <summary>
        /// kills_assists integer
        /// </summary>
        /// <value>kills_assists integer</value>
        [JsonProperty("kills_assists")]
        public long? KillsAssists { get; set; }

        /// <summary>
        /// kills_high_sec integer
        /// </summary>
        /// <value>kills_high_sec integer</value>
        [JsonProperty("kills_high_sec")]
        public long? KillsHighSec { get; set; }

        /// <summary>
        /// kills_low_sec integer
        /// </summary>
        /// <value>kills_low_sec integer</value>
        [JsonProperty("kills_low_sec")]
        public long? KillsLowSec { get; set; }

        /// <summary>
        /// kills_null_sec integer
        /// </summary>
        /// <value>kills_null_sec integer</value>
        [JsonProperty("kills_null_sec")]
        public long? KillsNullSec { get; set; }

        /// <summary>
        /// kills_pod_high_sec integer
        /// </summary>
        /// <value>kills_pod_high_sec integer</value>
        [JsonProperty("kills_pod_high_sec")]
        public long? KillsPodHighSec { get; set; }

        /// <summary>
        /// kills_pod_low_sec integer
        /// </summary>
        /// <value>kills_pod_low_sec integer</value>
        [JsonProperty("kills_pod_low_sec")]
        public long? KillsPodLowSec { get; set; }

        /// <summary>
        /// kills_pod_null_sec integer
        /// </summary>
        /// <value>kills_pod_null_sec integer</value>
        [JsonProperty("kills_pod_null_sec")]
        public long? KillsPodNullSec { get; set; }

        /// <summary>
        /// kills_pod_wormhole integer
        /// </summary>
        /// <value>kills_pod_wormhole integer</value>
        [JsonProperty("kills_pod_wormhole")]
        public long? KillsPodWormhole { get; set; }

        /// <summary>
        /// kills_wormhole integer
        /// </summary>
        /// <value>kills_wormhole integer</value>
        [JsonProperty("kills_wormhole")]
        public long? KillsWormhole { get; set; }

        /// <summary>
        /// npc_flag_set integer
        /// </summary>
        /// <value>npc_flag_set integer</value>
        [JsonProperty("npc_flag_set")]
        public long? NpcFlagSet { get; set; }

        /// <summary>
        /// probe_scans integer
        /// </summary>
        /// <value>probe_scans integer</value>
        [JsonProperty("probe_scans")]
        public long? ProbeScans { get; set; }

        /// <summary>
        /// pvp_flag_set integer
        /// </summary>
        /// <value>pvp_flag_set integer</value>
        [JsonProperty("pvp_flag_set")]
        public long? PvpFlagSet { get; set; }

        /// <summary>
        /// repair_armor_by_remote_amount integer
        /// </summary>
        /// <value>repair_armor_by_remote_amount integer</value>
        [JsonProperty("repair_armor_by_remote_amount")]
        public long? RepairArmorByRemoteAmount { get; set; }

        /// <summary>
        /// repair_armor_remote_amount integer
        /// </summary>
        /// <value>repair_armor_remote_amount integer</value>
        [JsonProperty("repair_armor_remote_amount")]
        public long? RepairArmorRemoteAmount { get; set; }

        /// <summary>
        /// repair_armor_self_amount integer
        /// </summary>
        /// <value>repair_armor_self_amount integer</value>
        [JsonProperty("repair_armor_self_amount")]
        public long? RepairArmorSelfAmount { get; set; }

        /// <summary>
        /// repair_capacitor_by_remote_amount integer
        /// </summary>
        /// <value>repair_capacitor_by_remote_amount integer</value>
        [JsonProperty("repair_capacitor_by_remote_amount")]
        public long? RepairCapacitorByRemoteAmount { get; set; }

        /// <summary>
        /// repair_capacitor_remote_amount integer
        /// </summary>
        /// <value>repair_capacitor_remote_amount integer</value>
        [JsonProperty("repair_capacitor_remote_amount")]
        public long? RepairCapacitorRemoteAmount { get; set; }

        /// <summary>
        /// repair_capacitor_self_amount integer
        /// </summary>
        /// <value>repair_capacitor_self_amount integer</value>
        [JsonProperty("repair_capacitor_self_amount")]
        public long? RepairCapacitorSelfAmount { get; set; }

        /// <summary>
        /// repair_hull_by_remote_amount integer
        /// </summary>
        /// <value>repair_hull_by_remote_amount integer</value>
        [JsonProperty("repair_hull_by_remote_amount")]
        public long? RepairHullByRemoteAmount { get; set; }

        /// <summary>
        /// repair_hull_remote_amount integer
        /// </summary>
        /// <value>repair_hull_remote_amount integer</value>
        [JsonProperty("repair_hull_remote_amount")]
        public long? RepairHullRemoteAmount { get; set; }

        /// <summary>
        /// repair_hull_self_amount integer
        /// </summary>
        /// <value>repair_hull_self_amount integer</value>
        [JsonProperty("repair_hull_self_amount")]
        public long? RepairHullSelfAmount { get; set; }

        /// <summary>
        /// repair_shield_by_remote_amount integer
        /// </summary>
        /// <value>repair_shield_by_remote_amount integer</value>
        [JsonProperty("repair_shield_by_remote_amount")]
        public long? RepairShieldByRemoteAmount { get; set; }

        /// <summary>
        /// repair_shield_remote_amount integer
        /// </summary>
        /// <value>repair_shield_remote_amount integer</value>
        [JsonProperty("repair_shield_remote_amount")]
        public long? RepairShieldRemoteAmount { get; set; }

        /// <summary>
        /// repair_shield_self_amount integer
        /// </summary>
        /// <value>repair_shield_self_amount integer</value>
        [JsonProperty("repair_shield_self_amount")]
        public long? RepairShieldSelfAmount { get; set; }

        /// <summary>
        /// self_destructs integer
        /// </summary>
        /// <value>self_destructs integer</value>
        [JsonProperty("self_destructs")]
        public long? SelfDestructs { get; set; }

        /// <summary>
        /// warp_scrambledby_npc integer
        /// </summary>
        /// <value>warp_scrambledby_npc integer</value>
        [JsonProperty("warp_scrambledby_npc")]
        public long? WarpScrambledbyNpc { get; set; }

        /// <summary>
        /// warp_scrambledby_pc integer
        /// </summary>
        /// <value>warp_scrambledby_pc integer</value>
        [JsonProperty("warp_scrambledby_pc")]
        public long? WarpScrambledbyPc { get; set; }

        /// <summary>
        /// warp_scramble_pc integer
        /// </summary>
        /// <value>warp_scramble_pc integer</value>
        [JsonProperty("warp_scramble_pc")]
        public long? WarpScramblePc { get; set; }
        /// <summary>
        /// weapon_flag_set integer
        /// </summary>
        /// <value>weapon_flag_set integer</value>
        [JsonProperty("weapon_flag_set")]
        public long? WeaponFlagSet { get; set; }

        /// <summary>
        /// webifiedby_npc integer
        /// </summary>
        /// <value>webifiedby_npc integer</value>
        [JsonProperty("webifiedby_npc")]
        public long? WebifiedbyNpc { get; set; }

        /// <summary>
        /// webifiedby_pc integer
        /// </summary>
        /// <value>webifiedby_pc integer</value>
        [JsonProperty("webifiedby_pc")]
        public long? WebifiedbyPc { get; set; }

        /// <summary>
        /// webifying_pc integer
        /// </summary>
        /// <value>webifying_pc integer</value>
        [JsonProperty("webifying_pc")]
        public long? WebifyingPc { get; set; }

        #endregion Properties
    }
    public class IndustryStats : ModelBase<IndustryStats>
    {
        #region Properties

        /// <summary>
        /// hacking_successes integer
        /// </summary>
        /// <value>hacking_successes integer</value>
        [JsonProperty("hacking_successes")]
        public long? HackingSuccesses { get; set; }

        /// <summary>
        /// jobs_cancelled integer
        /// </summary>
        /// <value>jobs_cancelled integer</value>
        [JsonProperty("jobs_cancelled")]
        public long? JobsCancelled { get; set; }

        /// <summary>
        /// jobs_completed_copy_blueprint integer
        /// </summary>
        /// <value>jobs_completed_copy_blueprint integer</value>
        [JsonProperty("jobs_completed_copy_blueprint")]
        public long? JobsCompletedCopyBlueprint { get; set; }

        /// <summary>
        /// jobs_completed_invention integer
        /// </summary>
        /// <value>jobs_completed_invention integer</value>
        [JsonProperty("jobs_completed_invention")]
        public long? JobsCompletedInvention { get; set; }

        /// <summary>
        /// jobs_completed_manufacture integer
        /// </summary>
        /// <value>jobs_completed_manufacture integer</value>
        [JsonProperty("jobs_completed_manufacture")]
        public long? JobsCompletedManufacture { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_asteroid integer
        /// </summary>
        /// <value>jobs_completed_manufacture_asteroid integer</value>
        [JsonProperty("jobs_completed_manufacture_asteroid")]
        public long? JobsCompletedManufactureAsteroid { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_asteroid_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_asteroid_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_asteroid_quantity")]
        public long? JobsCompletedManufactureAsteroidQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_charge integer
        /// </summary>
        /// <value>jobs_completed_manufacture_charge integer</value>
        [JsonProperty("jobs_completed_manufacture_charge")]
        public long? JobsCompletedManufactureCharge { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_charge_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_charge_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_charge_quantity")]
        public long? JobsCompletedManufactureChargeQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_commodity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_commodity integer</value>
        [JsonProperty("jobs_completed_manufacture_commodity")]
        public long? JobsCompletedManufactureCommodity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_commodity_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_commodity_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_commodity_quantity")]
        public long? JobsCompletedManufactureCommodityQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_deployable integer
        /// </summary>
        /// <value>jobs_completed_manufacture_deployable integer</value>
        [JsonProperty("jobs_completed_manufacture_deployable")]
        public long? JobsCompletedManufactureDeployable { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_deployable_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_deployable_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_deployable_quantity")]
        public long? JobsCompletedManufactureDeployableQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_drone integer
        /// </summary>
        /// <value>jobs_completed_manufacture_drone integer</value>
        [JsonProperty("jobs_completed_manufacture_drone")]
        public long? JobsCompletedManufactureDrone { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_drone_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_drone_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_drone_quantity")]
        public long? JobsCompletedManufactureDroneQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_implant integer
        /// </summary>
        /// <value>jobs_completed_manufacture_implant integer</value>
        [JsonProperty("jobs_completed_manufacture_implant")]
        public long? JobsCompletedManufactureImplant { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_implant_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_implant_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_implant_quantity")]
        public long? JobsCompletedManufactureImplantQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_module integer
        /// </summary>
        /// <value>jobs_completed_manufacture_module integer</value>
        [JsonProperty("jobs_completed_manufacture_module")]
        public long? JobsCompletedManufactureModule { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_module_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_module_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_module_quantity")]
        public long? JobsCompletedManufactureModuleQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_other integer
        /// </summary>
        /// <value>jobs_completed_manufacture_other integer</value>
        [JsonProperty("jobs_completed_manufacture_other")]
        public long? JobsCompletedManufactureOther { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_other_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_other_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_other_quantity")]
        public long? JobsCompletedManufactureOtherQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_ship integer
        /// </summary>
        /// <value>jobs_completed_manufacture_ship integer</value>
        [JsonProperty("jobs_completed_manufacture_ship")]
        public long? JobsCompletedManufactureShip { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_ship_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_ship_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_ship_quantity")]
        public long? JobsCompletedManufactureShipQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_structure integer
        /// </summary>
        /// <value>jobs_completed_manufacture_structure integer</value>
        [JsonProperty("jobs_completed_manufacture_structure")]
        public long? JobsCompletedManufactureStructure { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_structure_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_structure_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_structure_quantity")]
        public long? JobsCompletedManufactureStructureQuantity { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_subsystem integer
        /// </summary>
        /// <value>jobs_completed_manufacture_subsystem integer</value>
        [JsonProperty("jobs_completed_manufacture_subsystem")]
        public long? JobsCompletedManufactureSubsystem { get; set; }

        /// <summary>
        /// jobs_completed_manufacture_subsystem_quantity integer
        /// </summary>
        /// <value>jobs_completed_manufacture_subsystem_quantity integer</value>
        [JsonProperty("jobs_completed_manufacture_subsystem_quantity")]
        public long? JobsCompletedManufactureSubsystemQuantity { get; set; }

        /// <summary>
        /// jobs_completed_material_productivity integer
        /// </summary>
        /// <value>jobs_completed_material_productivity integer</value>
        [JsonProperty("jobs_completed_material_productivity")]
        public long? JobsCompletedMaterialProductivity { get; set; }

        /// <summary>
        /// jobs_completed_time_productivity integer
        /// </summary>
        /// <value>jobs_completed_time_productivity integer</value>
        [JsonProperty("jobs_completed_time_productivity")]
        public long? JobsCompletedTimeProductivity { get; set; }

        /// <summary>
        /// jobs_started_copy_blueprint integer
        /// </summary>
        /// <value>jobs_started_copy_blueprint integer</value>
        [JsonProperty("jobs_started_copy_blueprint")]
        public long? JobsStartedCopyBlueprint { get; set; }

        /// <summary>
        /// jobs_started_invention integer
        /// </summary>
        /// <value>jobs_started_invention integer</value>
        [JsonProperty("jobs_started_invention")]
        public long? JobsStartedInvention { get; set; }

        /// <summary>
        /// jobs_started_manufacture integer
        /// </summary>
        /// <value>jobs_started_manufacture integer</value>
        [JsonProperty("jobs_started_manufacture")]
        public long? JobsStartedManufacture { get; set; }

        /// <summary>
        /// jobs_started_material_productivity integer
        /// </summary>
        /// <value>jobs_started_material_productivity integer</value>
        [JsonProperty("jobs_started_material_productivity")]
        public long? JobsStartedMaterialProductivity { get; set; }

        /// <summary>
        /// jobs_started_time_productivity integer
        /// </summary>
        /// <value>jobs_started_time_productivity integer</value>
        [JsonProperty("jobs_started_time_productivity")]
        public long? JobsStartedTimeProductivity { get; set; }

        /// <summary>
        /// reprocess_item integer
        /// </summary>
        /// <value>reprocess_item integer</value>
        [JsonProperty("reprocess_item")]
        public long? ReprocessItem { get; set; }

        /// <summary>
        /// reprocess_item_quantity integer
        /// </summary>
        /// <value>reprocess_item_quantity integer</value>
        [JsonProperty("reprocess_item_quantity")]
        public long? ReprocessItemQuantity { get; set; }

        #endregion Properties
    }
    public class InventoryStats : ModelBase<InventoryStats>
    {
        #region Properties

        /// <summary>
        /// abandon_loot_quantity integer
        /// </summary>
        /// <value>abandon_loot_quantity integer</value>
        [JsonProperty("abandon_loot_quantity")]
        public long? AbandonLootQuantity { get; set; }

        /// <summary>
        /// trash_item_quantity integer
        /// </summary>
        /// <value>trash_item_quantity integer</value>
        [JsonProperty("trash_item_quantity")]
        public long? TrashItemQuantity { get; set; }

        #endregion Properties
    }
    public class IskStats : ModelBase<IskStats>
    {
        #region Properties

        /// <summary>
        /// in integer
        /// </summary>
        /// <value>in integer</value>
        [JsonProperty("in")]
        public long? In { get; set; }

        /// <summary>
        /// out integer
        /// </summary>
        /// <value>out integer</value>
        [JsonProperty("out")]
        public long? Out { get; set; }

        #endregion Properties
    }
    public class MarketStats : ModelBase<MarketStats>
    {
        #region Properties

        /// <summary>
        /// accept_contracts_courier integer
        /// </summary>
        /// <value>accept_contracts_courier integer</value>
        [JsonProperty("accept_contracts_courier")]
        public long? AcceptContractsCourier { get; set; }

        /// <summary>
        /// accept_contracts_item_exchange integer
        /// </summary>
        /// <value>accept_contracts_item_exchange integer</value>
        [JsonProperty("accept_contracts_item_exchange")]
        public long? AcceptContractsItemExchange { get; set; }

        /// <summary>
        /// buy_orders_placed integer
        /// </summary>
        /// <value>buy_orders_placed integer</value>
        [JsonProperty("buy_orders_placed")]
        public long? BuyOrdersPlaced { get; set; }

        /// <summary>
        /// cancel_market_order integer
        /// </summary>
        /// <value>cancel_market_order integer</value>
        [JsonProperty("cancel_market_order")]
        public long? CancelMarketOrder { get; set; }

        /// <summary>
        /// create_contracts_auction integer
        /// </summary>
        /// <value>create_contracts_auction integer</value>
        [JsonProperty("create_contracts_auction")]
        public long? CreateContractsAuction { get; set; }

        /// <summary>
        /// create_contracts_courier integer
        /// </summary>
        /// <value>create_contracts_courier integer</value>
        [JsonProperty("create_contracts_courier")]
        public long? CreateContractsCourier { get; set; }

        /// <summary>
        /// create_contracts_item_exchange integer
        /// </summary>
        /// <value>create_contracts_item_exchange integer</value>
        [JsonProperty("create_contracts_item_exchange")]
        public long? CreateContractsItemExchange { get; set; }

        /// <summary>
        /// deliver_courier_contract integer
        /// </summary>
        /// <value>deliver_courier_contract integer</value>
        [JsonProperty("deliver_courier_contract")]
        public long? DeliverCourierContract { get; set; }

        /// <summary>
        /// isk_gained integer
        /// </summary>
        /// <value>isk_gained integer</value>
        [JsonProperty("isk_gained")]
        public long? IskGained { get; set; }

        /// <summary>
        /// isk_spent integer
        /// </summary>
        /// <value>isk_spent integer</value>
        [JsonProperty("isk_spent")]
        public long? IskSpent { get; set; }

        /// <summary>
        /// modify_market_order integer
        /// </summary>
        /// <value>modify_market_order integer</value>
        [JsonProperty("modify_market_order")]
        public long? ModifyMarketOrder { get; set; }

        /// <summary>
        /// search_contracts integer
        /// </summary>
        /// <value>search_contracts integer</value>
        [JsonProperty("search_contracts")]
        public long? SearchContracts { get; set; }

        /// <summary>
        /// sell_orders_placed integer
        /// </summary>
        /// <value>sell_orders_placed integer</value>
        [JsonProperty("sell_orders_placed")]
        public long? SellOrdersPlaced { get; set; }

        #endregion Properties
    }
    public class MiningStats : ModelBase<MiningStats>
    {
        #region Properties

        /// <summary>
        /// drone_mine integer
        /// </summary>
        /// <value>drone_mine integer</value>
        [JsonProperty("drone_mine")]
        public long? DroneMine { get; set; }

        /// <summary>
        /// ore_arkonor integer
        /// </summary>
        /// <value>ore_arkonor integer</value>
        [JsonProperty("ore_arkonor")]
        public long? OreArkonor { get; set; }

        /// <summary>
        /// ore_bistot integer
        /// </summary>
        /// <value>ore_bistot integer</value>
        [JsonProperty("ore_bistot")]
        public long? OreBistot { get; set; }

        /// <summary>
        /// ore_crokite integer
        /// </summary>
        /// <value>ore_crokite integer</value>
        [JsonProperty("ore_crokite")]
        public long? OreCrokite { get; set; }

        /// <summary>
        /// ore_dark_ochre integer
        /// </summary>
        /// <value>ore_dark_ochre integer</value>
        [JsonProperty("ore_dark_ochre")]
        public long? OreDarkOchre { get; set; }

        /// <summary>
        /// ore_gneiss integer
        /// </summary>
        /// <value>ore_gneiss integer</value>
        [JsonProperty("ore_gneiss")]
        public long? OreGneiss { get; set; }

        /// <summary>
        /// ore_harvestable_cloud integer
        /// </summary>
        /// <value>ore_harvestable_cloud integer</value>
        [JsonProperty("ore_harvestable_cloud")]
        public long? OreHarvestableCloud { get; set; }

        /// <summary>
        /// ore_hedbergite integer
        /// </summary>
        /// <value>ore_hedbergite integer</value>
        [JsonProperty("ore_hedbergite")]
        public long? OreHedbergite { get; set; }

        /// <summary>
        /// ore_hemorphite integer
        /// </summary>
        /// <value>ore_hemorphite integer</value>
        [JsonProperty("ore_hemorphite")]
        public long? OreHemorphite { get; set; }

        /// <summary>
        /// ore_ice integer
        /// </summary>
        /// <value>ore_ice integer</value>
        [JsonProperty("ore_ice")]
        public long? OreIce { get; set; }

        /// <summary>
        /// ore_jaspet integer
        /// </summary>
        /// <value>ore_jaspet integer</value>
        [JsonProperty("ore_jaspet")]
        public long? OreJaspet { get; set; }

        /// <summary>
        /// ore_kernite integer
        /// </summary>
        /// <value>ore_kernite integer</value>
        [JsonProperty("ore_kernite")]
        public long? OreKernite { get; set; }

        /// <summary>
        /// ore_mercoxit integer
        /// </summary>
        /// <value>ore_mercoxit integer</value>
        [JsonProperty("ore_mercoxit")]
        public long? OreMercoxit { get; set; }

        /// <summary>
        /// ore_omber integer
        /// </summary>
        /// <value>ore_omber integer</value>
        [JsonProperty("ore_omber")]
        public long? OreOmber { get; set; }

        /// <summary>
        /// ore_plagioclase integer
        /// </summary>
        /// <value>ore_plagioclase integer</value>
        [JsonProperty("ore_plagioclase")]
        public long? OrePlagioclase { get; set; }

        /// <summary>
        /// ore_pyroxeres integer
        /// </summary>
        /// <value>ore_pyroxeres integer</value>
        [JsonProperty("ore_pyroxeres")]
        public long? OrePyroxeres { get; set; }

        /// <summary>
        /// ore_scordite integer
        /// </summary>
        /// <value>ore_scordite integer</value>
        [JsonProperty("ore_scordite")]
        public long? OreScordite { get; set; }

        /// <summary>
        /// ore_spodumain integer
        /// </summary>
        /// <value>ore_spodumain integer</value>
        [JsonProperty("ore_spodumain")]
        public long? OreSpodumain { get; set; }

        /// <summary>
        /// ore_veldspar integer
        /// </summary>
        /// <value>ore_veldspar integer</value>
        [JsonProperty("ore_veldspar")]
        public long? OreVeldspar { get; set; }

        #endregion Properties
    }
    public class ModuleStats : ModelBase<ModuleStats>
    {
        #region Properties

        /// <summary>
        /// activations_armor_hardener integer
        /// </summary>
        /// <value>activations_armor_hardener integer</value>
        [JsonProperty("activations_armor_hardener")]
        public long? ActivationsArmorHardener { get; set; }

        /// <summary>
        /// activations_armor_repair_unit integer
        /// </summary>
        /// <value>activations_armor_repair_unit integer</value>
        [JsonProperty("activations_armor_repair_unit")]
        public long? ActivationsArmorRepairUnit { get; set; }

        /// <summary>
        /// activations_armor_resistance_shift_hardener integer
        /// </summary>
        /// <value>activations_armor_resistance_shift_hardener integer</value>
        [JsonProperty("activations_armor_resistance_shift_hardener")]
        public long? ActivationsArmorResistanceShiftHardener { get; set; }

        /// <summary>
        /// activations_automated_targeting_system integer
        /// </summary>
        /// <value>activations_automated_targeting_system integer</value>
        [JsonProperty("activations_automated_targeting_system")]
        public long? ActivationsAutomatedTargetingSystem { get; set; }

        /// <summary>
        /// activations_bastion integer
        /// </summary>
        /// <value>activations_bastion integer</value>
        [JsonProperty("activations_bastion")]
        public long? ActivationsBastion { get; set; }

        /// <summary>
        /// activations_bomb_launcher integer
        /// </summary>
        /// <value>activations_bomb_launcher integer</value>
        [JsonProperty("activations_bomb_launcher")]
        public long? ActivationsBombLauncher { get; set; }

        /// <summary>
        /// activations_capacitor_booster integer
        /// </summary>
        /// <value>activations_capacitor_booster integer</value>
        [JsonProperty("activations_capacitor_booster")]
        public long? ActivationsCapacitorBooster { get; set; }

        /// <summary>
        /// activations_cargo_scanner integer
        /// </summary>
        /// <value>activations_cargo_scanner integer</value>
        [JsonProperty("activations_cargo_scanner")]
        public long? ActivationsCargoScanner { get; set; }

        /// <summary>
        /// activations_cloaking_device integer
        /// </summary>
        /// <value>activations_cloaking_device integer</value>
        [JsonProperty("activations_cloaking_device")]
        public long? ActivationsCloakingDevice { get; set; }

        /// <summary>
        /// activations_clone_vat_bay integer
        /// </summary>
        /// <value>activations_clone_vat_bay integer</value>
        [JsonProperty("activations_clone_vat_bay")]
        public long? ActivationsCloneVatBay { get; set; }

        /// <summary>
        /// activations_cynosural_field integer
        /// </summary>
        /// <value>activations_cynosural_field integer</value>
        [JsonProperty("activations_cynosural_field")]
        public long? ActivationsCynosuralField { get; set; }

        /// <summary>
        /// activations_damage_control integer
        /// </summary>
        /// <value>activations_damage_control integer</value>
        [JsonProperty("activations_damage_control")]
        public long? ActivationsDamageControl { get; set; }

        /// <summary>
        /// activations_data_miners integer
        /// </summary>
        /// <value>activations_data_miners integer</value>
        [JsonProperty("activations_data_miners")]
        public long? ActivationsDataMiners { get; set; }

        /// <summary>
        /// activations_drone_control_unit integer
        /// </summary>
        /// <value>activations_drone_control_unit integer</value>
        [JsonProperty("activations_drone_control_unit")]
        public long? ActivationsDroneControlUnit { get; set; }

        /// <summary>
        /// activations_drone_tracking_modules integer
        /// </summary>
        /// <value>activations_drone_tracking_modules integer</value>
        [JsonProperty("activations_drone_tracking_modules")]
        public long? ActivationsDroneTrackingModules { get; set; }

        /// <summary>
        /// activations_eccm integer
        /// </summary>
        /// <value>activations_eccm integer</value>
        [JsonProperty("activations_eccm")]
        public long? ActivationsEccm { get; set; }

        /// <summary>
        /// activations_ecm integer
        /// </summary>
        /// <value>activations_ecm integer</value>
        [JsonProperty("activations_ecm")]
        public long? ActivationsEcm { get; set; }

        /// <summary>
        /// activations_ecm_burst integer
        /// </summary>
        /// <value>activations_ecm_burst integer</value>
        [JsonProperty("activations_ecm_burst")]
        public long? ActivationsEcmBurst { get; set; }

        /// <summary>
        /// activations_energy_destabilizer integer
        /// </summary>
        /// <value>activations_energy_destabilizer integer</value>
        [JsonProperty("activations_energy_destabilizer")]
        public long? ActivationsEnergyDestabilizer { get; set; }

        /// <summary>
        /// activations_energy_vampire integer
        /// </summary>
        /// <value>activations_energy_vampire integer</value>
        [JsonProperty("activations_energy_vampire")]
        public long? ActivationsEnergyVampire { get; set; }

        /// <summary>
        /// activations_energy_weapon integer
        /// </summary>
        /// <value>activations_energy_weapon integer</value>
        [JsonProperty("activations_energy_weapon")]
        public long? ActivationsEnergyWeapon { get; set; }

        /// <summary>
        /// activations_festival_launcher integer
        /// </summary>
        /// <value>activations_festival_launcher integer</value>
        [JsonProperty("activations_festival_launcher")]
        public long? ActivationsFestivalLauncher { get; set; }

        /// <summary>
        /// activations_frequency_mining_laser integer
        /// </summary>
        /// <value>activations_frequency_mining_laser integer</value>
        [JsonProperty("activations_frequency_mining_laser")]
        public long? ActivationsFrequencyMiningLaser { get; set; }

        /// <summary>
        /// activations_fueled_armor_repairer integer
        /// </summary>
        /// <value>activations_fueled_armor_repairer integer</value>
        [JsonProperty("activations_fueled_armor_repairer")]
        public long? ActivationsFueledArmorRepairer { get; set; }

        /// <summary>
        /// activations_fueled_shield_booster integer
        /// </summary>
        /// <value>activations_fueled_shield_booster integer</value>
        [JsonProperty("activations_fueled_shield_booster")]
        public long? ActivationsFueledShieldBooster { get; set; }

        /// <summary>
        /// activations_gang_coordinator integer
        /// </summary>
        /// <value>activations_gang_coordinator integer</value>
        [JsonProperty("activations_gang_coordinator")]
        public long? ActivationsGangCoordinator { get; set; }

        /// <summary>
        /// activations_gas_cloud_harvester integer
        /// </summary>
        /// <value>activations_gas_cloud_harvester integer</value>
        [JsonProperty("activations_gas_cloud_harvester")]
        public long? ActivationsGasCloudHarvester { get; set; }

        /// <summary>
        /// activations_hull_repair_unit integer
        /// </summary>
        /// <value>activations_hull_repair_unit integer</value>
        [JsonProperty("activations_hull_repair_unit")]
        public long? ActivationsHullRepairUnit { get; set; }

        /// <summary>
        /// activations_hybrid_weapon integer
        /// </summary>
        /// <value>activations_hybrid_weapon integer</value>
        [JsonProperty("activations_hybrid_weapon")]
        public long? ActivationsHybridWeapon { get; set; }

        /// <summary>
        /// activations_industrial_core integer
        /// </summary>
        /// <value>activations_industrial_core integer</value>
        [JsonProperty("activations_industrial_core")]
        public long? ActivationsIndustrialCore { get; set; }

        /// <summary>
        /// activations_interdiction_sphere_launcher integer
        /// </summary>
        /// <value>activations_interdiction_sphere_launcher integer</value>
        [JsonProperty("activations_interdiction_sphere_launcher")]
        public long? ActivationsInterdictionSphereLauncher { get; set; }

        /// <summary>
        /// activations_micro_jump_drive integer
        /// </summary>
        /// <value>activations_micro_jump_drive integer</value>
        [JsonProperty("activations_micro_jump_drive")]
        public long? ActivationsMicroJumpDrive { get; set; }

        /// <summary>
        /// activations_mining_laser integer
        /// </summary>
        /// <value>activations_mining_laser integer</value>
        [JsonProperty("activations_mining_laser")]
        public long? ActivationsMiningLaser { get; set; }

        /// <summary>
        /// activations_missile_launcher integer
        /// </summary>
        /// <value>activations_missile_launcher integer</value>
        [JsonProperty("activations_missile_launcher")]
        public long? ActivationsMissileLauncher { get; set; }

        /// <summary>
        /// activations_passive_targeting_system integer
        /// </summary>
        /// <value>activations_passive_targeting_system integer</value>
        [JsonProperty("activations_passive_targeting_system")]
        public long? ActivationsPassiveTargetingSystem { get; set; }

        /// <summary>
        /// activations_probe_launcher integer
        /// </summary>
        /// <value>activations_probe_launcher integer</value>
        [JsonProperty("activations_probe_launcher")]
        public long? ActivationsProbeLauncher { get; set; }

        /// <summary>
        /// activations_projected_eccm integer
        /// </summary>
        /// <value>activations_projected_eccm integer</value>
        [JsonProperty("activations_projected_eccm")]
        public long? ActivationsProjectedEccm { get; set; }

        /// <summary>
        /// activations_projectile_weapon integer
        /// </summary>
        /// <value>activations_projectile_weapon integer</value>
        [JsonProperty("activations_projectile_weapon")]
        public long? ActivationsProjectileWeapon { get; set; }

        /// <summary>
        /// activations_propulsion_module integer
        /// </summary>
        /// <value>activations_propulsion_module integer</value>
        [JsonProperty("activations_propulsion_module")]
        public long? ActivationsPropulsionModule { get; set; }

        /// <summary>
        /// activations_remote_armor_repairer integer
        /// </summary>
        /// <value>activations_remote_armor_repairer integer</value>
        [JsonProperty("activations_remote_armor_repairer")]
        public long? ActivationsRemoteArmorRepairer { get; set; }

        /// <summary>
        /// activations_remote_capacitor_transmitter integer
        /// </summary>
        /// <value>activations_remote_capacitor_transmitter integer</value>
        [JsonProperty("activations_remote_capacitor_transmitter")]
        public long? ActivationsRemoteCapacitorTransmitter { get; set; }

        /// <summary>
        /// activations_remote_ecm_burst integer
        /// </summary>
        /// <value>activations_remote_ecm_burst integer</value>
        [JsonProperty("activations_remote_ecm_burst")]
        public long? ActivationsRemoteEcmBurst { get; set; }

        /// <summary>
        /// activations_remote_hull_repairer integer
        /// </summary>
        /// <value>activations_remote_hull_repairer integer</value>
        [JsonProperty("activations_remote_hull_repairer")]
        public long? ActivationsRemoteHullRepairer { get; set; }

        /// <summary>
        /// activations_remote_sensor_booster integer
        /// </summary>
        /// <value>activations_remote_sensor_booster integer</value>
        [JsonProperty("activations_remote_sensor_booster")]
        public long? ActivationsRemoteSensorBooster { get; set; }

        /// <summary>
        /// activations_remote_sensor_damper integer
        /// </summary>
        /// <value>activations_remote_sensor_damper integer</value>
        [JsonProperty("activations_remote_sensor_damper")]
        public long? ActivationsRemoteSensorDamper { get; set; }

        /// <summary>
        /// activations_remote_shield_booster integer
        /// </summary>
        /// <value>activations_remote_shield_booster integer</value>
        [JsonProperty("activations_remote_shield_booster")]
        public long? ActivationsRemoteShieldBooster { get; set; }

        /// <summary>
        /// activations_remote_tracking_computer integer
        /// </summary>
        /// <value>activations_remote_tracking_computer integer</value>
        [JsonProperty("activations_remote_tracking_computer")]
        public long? ActivationsRemoteTrackingComputer { get; set; }

        /// <summary>
        /// activations_salvager integer
        /// </summary>
        /// <value>activations_salvager integer</value>
        [JsonProperty("activations_salvager")]
        public long? ActivationsSalvager { get; set; }

        /// <summary>
        /// activations_sensor_booster integer
        /// </summary>
        /// <value>activations_sensor_booster integer</value>
        [JsonProperty("activations_sensor_booster")]
        public long? ActivationsSensorBooster { get; set; }

        /// <summary>
        /// activations_shield_booster integer
        /// </summary>
        /// <value>activations_shield_booster integer</value>
        [JsonProperty("activations_shield_booster")]
        public long? ActivationsShieldBooster { get; set; }

        /// <summary>
        /// activations_shield_hardener integer
        /// </summary>
        /// <value>activations_shield_hardener integer</value>
        [JsonProperty("activations_shield_hardener")]
        public long? ActivationsShieldHardener { get; set; }

        /// <summary>
        /// activations_ship_scanner integer
        /// </summary>
        /// <value>activations_ship_scanner integer</value>
        [JsonProperty("activations_ship_scanner")]
        public long? ActivationsShipScanner { get; set; }

        /// <summary>
        /// activations_siege integer
        /// </summary>
        /// <value>activations_siege integer</value>
        [JsonProperty("activations_siege")]
        public long? ActivationsSiege { get; set; }

        /// <summary>
        /// activations_smart_bomb integer
        /// </summary>
        /// <value>activations_smart_bomb integer</value>
        [JsonProperty("activations_smart_bomb")]
        public long? ActivationsSmartBomb { get; set; }

        /// <summary>
        /// activations_stasis_web integer
        /// </summary>
        /// <value>activations_stasis_web integer</value>
        [JsonProperty("activations_stasis_web")]
        public long? ActivationsStasisWeb { get; set; }

        /// <summary>
        /// activations_strip_miner integer
        /// </summary>
        /// <value>activations_strip_miner integer</value>
        [JsonProperty("activations_strip_miner")]
        public long? ActivationsStripMiner { get; set; }

        /// <summary>
        /// activations_super_weapon integer
        /// </summary>
        /// <value>activations_super_weapon integer</value>
        [JsonProperty("activations_super_weapon")]
        public long? ActivationsSuperWeapon { get; set; }

        /// <summary>
        /// activations_survey_scanner integer
        /// </summary>
        /// <value>activations_survey_scanner integer</value>
        [JsonProperty("activations_survey_scanner")]
        public long? ActivationsSurveyScanner { get; set; }

        /// <summary>
        /// activations_target_breaker integer
        /// </summary>
        /// <value>activations_target_breaker integer</value>
        [JsonProperty("activations_target_breaker")]
        public long? ActivationsTargetBreaker { get; set; }

        /// <summary>
        /// activations_target_painter integer
        /// </summary>
        /// <value>activations_target_painter integer</value>
        [JsonProperty("activations_target_painter")]
        public long? ActivationsTargetPainter { get; set; }

        /// <summary>
        /// activations_tracking_computer integer
        /// </summary>
        /// <value>activations_tracking_computer integer</value>
        [JsonProperty("activations_tracking_computer")]
        public long? ActivationsTrackingComputer { get; set; }

        /// <summary>
        /// activations_tracking_disruptor integer
        /// </summary>
        /// <value>activations_tracking_disruptor integer</value>
        [JsonProperty("activations_tracking_disruptor")]
        public long? ActivationsTrackingDisruptor { get; set; }

        /// <summary>
        /// activations_tractor_beam integer
        /// </summary>
        /// <value>activations_tractor_beam integer</value>
        [JsonProperty("activations_tractor_beam")]
        public long? ActivationsTractorBeam { get; set; }

        /// <summary>
        /// activations_triage integer
        /// </summary>
        /// <value>activations_triage integer</value>
        [JsonProperty("activations_triage")]
        public long? ActivationsTriage { get; set; }

        /// <summary>
        /// activations_warp_disrupt_field_generator integer
        /// </summary>
        /// <value>activations_warp_disrupt_field_generator integer</value>
        [JsonProperty("activations_warp_disrupt_field_generator")]
        public long? ActivationsWarpDisruptFieldGenerator { get; set; }

        /// <summary>
        /// activations_warp_scrambler integer
        /// </summary>
        /// <value>activations_warp_scrambler integer</value>
        [JsonProperty("activations_warp_scrambler")]
        public long? ActivationsWarpScrambler { get; set; }

        /// <summary>
        /// link_weapons integer
        /// </summary>
        /// <value>link_weapons integer</value>
        [JsonProperty("link_weapons")]
        public long? LinkWeapons { get; set; }

        /// <summary>
        /// overload integer
        /// </summary>
        /// <value>overload integer</value>
        [JsonProperty("overload")]
        public long? Overload { get; set; }

        /// <summary>
        /// repairs integer
        /// </summary>
        /// <value>repairs integer</value>
        [JsonProperty("repairs")]
        public long? Repairs { get; set; }

        #endregion Properties
    }
    public class OrbitalStats : ModelBase<OrbitalStats>
    {
        #region Properties

        /// <summary>
        /// strike_characters_killed integer
        /// </summary>
        /// <value>strike_characters_killed integer</value>
        [JsonProperty("strike_characters_killed")]
        public long? StrikeCharactersKilled { get; set; }

        /// <summary>
        /// strike_damage_to_players_armor_amount integer
        /// </summary>
        /// <value>strike_damage_to_players_armor_amount integer</value>
        [JsonProperty("strike_damage_to_players_armor_amount")]
        public long? StrikeDamageToPlayersArmorAmount { get; set; }

        /// <summary>
        /// strike_damage_to_players_shield_amount integer
        /// </summary>
        /// <value>strike_damage_to_players_shield_amount integer</value>
        [JsonProperty("strike_damage_to_players_shield_amount")]
        public long? StrikeDamageToPlayersShieldAmount { get; set; }

        #endregion Properties
    }
    public class PveStats : ModelBase<PveStats>
    {
        #region Properties

        /// <summary>
        /// dungeons_completed_agent integer
        /// </summary>
        /// <value>dungeons_completed_agent integer</value>
        [JsonProperty("dungeons_completed_agent")]
        public long? DungeonsCompletedAgent { get; set; }

        /// <summary>
        /// dungeons_completed_distribution integer
        /// </summary>
        /// <value>dungeons_completed_distribution integer</value>
        [JsonProperty("dungeons_completed_distribution")]
        public long? DungeonsCompletedDistribution { get; set; }

        /// <summary>
        /// missions_succeeded integer
        /// </summary>
        /// <value>missions_succeeded integer</value>
        [JsonProperty("missions_succeeded")]
        public long? MissionsSucceeded { get; set; }

        /// <summary>
        /// missions_succeeded_epic_arc integer
        /// </summary>
        /// <value>missions_succeeded_epic_arc integer</value>
        [JsonProperty("missions_succeeded_epic_arc")]
        public long? MissionsSucceededEpicArc { get; set; }

        #endregion Properties
    }
    public class SocialStats : ModelBase<SocialStats>
    {
        #region Properties

        /// <summary>
        /// add_contact_bad integer
        /// </summary>
        /// <value>add_contact_bad integer</value>
        [JsonProperty("add_contact_bad")]
        public long? AddContactBad { get; set; }

        /// <summary>
        /// add_contact_good integer
        /// </summary>
        /// <value>add_contact_good integer</value>
        [JsonProperty("add_contact_good")]
        public long? AddContactGood { get; set; }

        /// <summary>
        /// add_contact_high integer
        /// </summary>
        /// <value>add_contact_high integer</value>
        [JsonProperty("add_contact_high")]
        public long? AddContactHigh { get; set; }

        /// <summary>
        /// add_contact_horrible integer
        /// </summary>
        /// <value>add_contact_horrible integer</value>
        [JsonProperty("add_contact_horrible")]
        public long? AddContactHorrible { get; set; }

        /// <summary>
        /// add_contact_neutral integer
        /// </summary>
        /// <value>add_contact_neutral integer</value>
        [JsonProperty("add_contact_neutral")]
        public long? AddContactNeutral { get; set; }

        /// <summary>
        /// added_as_contact_bad integer
        /// </summary>
        /// <value>added_as_contact_bad integer</value>
        [JsonProperty("added_as_contact_bad")]
        public long? AddedAsContactBad { get; set; }

        /// <summary>
        /// added_as_contact_good integer
        /// </summary>
        /// <value>added_as_contact_good integer</value>
        [JsonProperty("added_as_contact_good")]
        public long? AddedAsContactGood { get; set; }

        /// <summary>
        /// added_as_contact_high integer
        /// </summary>
        /// <value>added_as_contact_high integer</value>
        [JsonProperty("added_as_contact_high")]
        public long? AddedAsContactHigh { get; set; }

        /// <summary>
        /// added_as_contact_horrible integer
        /// </summary>
        /// <value>added_as_contact_horrible integer</value>
        [JsonProperty("added_as_contact_horrible")]
        public long? AddedAsContactHorrible { get; set; }

        /// <summary>
        /// added_as_contact_neutral integer
        /// </summary>
        /// <value>added_as_contact_neutral integer</value>
        [JsonProperty("added_as_contact_neutral")]
        public long? AddedAsContactNeutral { get; set; }

        /// <summary>
        /// add_note integer
        /// </summary>
        /// <value>add_note integer</value>
        [JsonProperty("add_note")]
        public long? AddNote { get; set; }
        /// <summary>
        /// calendar_event_created integer
        /// </summary>
        /// <value>calendar_event_created integer</value>
        [JsonProperty("calendar_event_created")]
        public long? CalendarEventCreated { get; set; }

        /// <summary>
        /// chat_messages_alliance integer
        /// </summary>
        /// <value>chat_messages_alliance integer</value>
        [JsonProperty("chat_messages_alliance")]
        public long? ChatMessagesAlliance { get; set; }

        /// <summary>
        /// chat_messages_constellation integer
        /// </summary>
        /// <value>chat_messages_constellation integer</value>
        [JsonProperty("chat_messages_constellation")]
        public long? ChatMessagesConstellation { get; set; }

        /// <summary>
        /// chat_messages_corporation integer
        /// </summary>
        /// <value>chat_messages_corporation integer</value>
        [JsonProperty("chat_messages_corporation")]
        public long? ChatMessagesCorporation { get; set; }

        /// <summary>
        /// chat_messages_fleet integer
        /// </summary>
        /// <value>chat_messages_fleet integer</value>
        [JsonProperty("chat_messages_fleet")]
        public long? ChatMessagesFleet { get; set; }

        /// <summary>
        /// chat_messages_region integer
        /// </summary>
        /// <value>chat_messages_region integer</value>
        [JsonProperty("chat_messages_region")]
        public long? ChatMessagesRegion { get; set; }

        /// <summary>
        /// chat_messages_solarsystem integer
        /// </summary>
        /// <value>chat_messages_solarsystem integer</value>
        [JsonProperty("chat_messages_solarsystem")]
        public long? ChatMessagesSolarsystem { get; set; }

        /// <summary>
        /// chat_messages_warfaction integer
        /// </summary>
        /// <value>chat_messages_warfaction integer</value>
        [JsonProperty("chat_messages_warfaction")]
        public long? ChatMessagesWarfaction { get; set; }

        /// <summary>
        /// chat_total_message_length integer
        /// </summary>
        /// <value>chat_total_message_length integer</value>
        [JsonProperty("chat_total_message_length")]
        public long? ChatTotalMessageLength { get; set; }

        /// <summary>
        /// direct_trades integer
        /// </summary>
        /// <value>direct_trades integer</value>
        [JsonProperty("direct_trades")]
        public long? DirectTrades { get; set; }

        /// <summary>
        /// fleet_broadcasts integer
        /// </summary>
        /// <value>fleet_broadcasts integer</value>
        [JsonProperty("fleet_broadcasts")]
        public long? FleetBroadcasts { get; set; }

        /// <summary>
        /// fleet_joins integer
        /// </summary>
        /// <value>fleet_joins integer</value>
        [JsonProperty("fleet_joins")]
        public long? FleetJoins { get; set; }

        /// <summary>
        /// mails_received integer
        /// </summary>
        /// <value>mails_received integer</value>
        [JsonProperty("mails_received")]
        public long? MailsReceived { get; set; }

        /// <summary>
        /// mails_sent integer
        /// </summary>
        /// <value>mails_sent integer</value>
        [JsonProperty("mails_sent")]
        public long? MailsSent { get; set; }

        #endregion Properties
    }
    public class TravelStats : ModelBase<TravelStats>
    {
        #region Properties

        /// <summary>
        /// acceleration_gate_activations integer
        /// </summary>
        /// <value>acceleration_gate_activations integer</value>
        [JsonProperty("acceleration_gate_activations")]
        public long? AccelerationGateActivations { get; set; }

        /// <summary>
        /// align_to integer
        /// </summary>
        /// <value>align_to integer</value>
        [JsonProperty("align_to")]
        public long? AlignTo { get; set; }

        /// <summary>
        /// distance_warped_high_sec integer
        /// </summary>
        /// <value>distance_warped_high_sec integer</value>
        [JsonProperty("distance_warped_high_sec")]
        public long? DistanceWarpedHighSec { get; set; }

        /// <summary>
        /// distance_warped_low_sec integer
        /// </summary>
        /// <value>distance_warped_low_sec integer</value>
        [JsonProperty("distance_warped_low_sec")]
        public long? DistanceWarpedLowSec { get; set; }

        /// <summary>
        /// distance_warped_null_sec integer
        /// </summary>
        /// <value>distance_warped_null_sec integer</value>
        [JsonProperty("distance_warped_null_sec")]
        public long? DistanceWarpedNullSec { get; set; }

        /// <summary>
        /// distance_warped_wormhole integer
        /// </summary>
        /// <value>distance_warped_wormhole integer</value>
        [JsonProperty("distance_warped_wormhole")]
        public long? DistanceWarpedWormhole { get; set; }

        /// <summary>
        /// docks_high_sec integer
        /// </summary>
        /// <value>docks_high_sec integer</value>
        [JsonProperty("docks_high_sec")]
        public long? DocksHighSec { get; set; }

        /// <summary>
        /// docks_low_sec integer
        /// </summary>
        /// <value>docks_low_sec integer</value>
        [JsonProperty("docks_low_sec")]
        public long? DocksLowSec { get; set; }

        /// <summary>
        /// docks_null_sec integer
        /// </summary>
        /// <value>docks_null_sec integer</value>
        [JsonProperty("docks_null_sec")]
        public long? DocksNullSec { get; set; }

        /// <summary>
        /// jumps_stargate_high_sec integer
        /// </summary>
        /// <value>jumps_stargate_high_sec integer</value>
        [JsonProperty("jumps_stargate_high_sec")]
        public long? JumpsStargateHighSec { get; set; }

        /// <summary>
        /// jumps_stargate_low_sec integer
        /// </summary>
        /// <value>jumps_stargate_low_sec integer</value>
        [JsonProperty("jumps_stargate_low_sec")]
        public long? JumpsStargateLowSec { get; set; }

        /// <summary>
        /// jumps_stargate_null_sec integer
        /// </summary>
        /// <value>jumps_stargate_null_sec integer</value>
        [JsonProperty("jumps_stargate_null_sec")]
        public long? JumpsStargateNullSec { get; set; }

        /// <summary>
        /// jumps_wormhole integer
        /// </summary>
        /// <value>jumps_wormhole integer</value>
        [JsonProperty("jumps_wormhole")]
        public long? JumpsWormhole { get; set; }

        /// <summary>
        /// warps_high_sec integer
        /// </summary>
        /// <value>warps_high_sec integer</value>
        [JsonProperty("warps_high_sec")]
        public long? WarpsHighSec { get; set; }

        /// <summary>
        /// warps_low_sec integer
        /// </summary>
        /// <value>warps_low_sec integer</value>
        [JsonProperty("warps_low_sec")]
        public long? WarpsLowSec { get; set; }

        /// <summary>
        /// warps_null_sec integer
        /// </summary>
        /// <value>warps_null_sec integer</value>
        [JsonProperty("warps_null_sec")]
        public long? WarpsNullSec { get; set; }

        /// <summary>
        /// warps_to_bookmark integer
        /// </summary>
        /// <value>warps_to_bookmark integer</value>
        [JsonProperty("warps_to_bookmark")]
        public long? WarpsToBookmark { get; set; }

        /// <summary>
        /// warps_to_celestial integer
        /// </summary>
        /// <value>warps_to_celestial integer</value>
        [JsonProperty("warps_to_celestial")]
        public long? WarpsToCelestial { get; set; }

        /// <summary>
        /// warps_to_fleet_member integer
        /// </summary>
        /// <value>warps_to_fleet_member integer</value>
        [JsonProperty("warps_to_fleet_member")]
        public long? WarpsToFleetMember { get; set; }

        /// <summary>
        /// warps_to_scan_result integer
        /// </summary>
        /// <value>warps_to_scan_result integer</value>
        [JsonProperty("warps_to_scan_result")]
        public long? WarpsToScanResult { get; set; }

        /// <summary>
        /// warps_wormhole integer
        /// </summary>
        /// <value>warps_wormhole integer</value>
        [JsonProperty("warps_wormhole")]
        public long? WarpsWormhole { get; set; }

        #endregion Properties
    }
}
