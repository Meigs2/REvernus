using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class War : ModelBase<War>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets Aggressor
        /// </summary>
        [JsonProperty("aggressor")]
        public WarAggressor Aggressor { get; set; }

        /// <summary>
        /// allied corporations or alliances, each object contains either corporation_id or alliance_id
        /// </summary>
        /// <value>allied corporations or alliances, each object contains either corporation_id or alliance_id</value>
        [JsonProperty("allies")]
        public List<WarAlly> Allies { get; set; }

        /// <summary>
        /// Time that the war was declared
        /// </summary>
        /// <value>Time that the war was declared</value>
        [JsonProperty("declared")]
        public DateTime Declared { get; set; }

        /// <summary>
        /// Gets or Sets Defender
        /// </summary>
        [JsonProperty("defender")]
        public WarDefender Defender { get; set; }

        /// <summary>
        /// Time the war ended and shooting was no longer allowed
        /// </summary>
        /// <value>Time the war ended and shooting was no longer allowed</value>
        [JsonProperty("finished")]
        public DateTime? Finished { get; set; }

        /// <summary>
        /// ID of the specified war
        /// </summary>
        /// <value>ID of the specified war</value>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Was the war declared mutual by both parties
        /// </summary>
        /// <value>Was the war declared mutual by both parties</value>
        [JsonProperty("mutual")]
        public bool Mutual { get; set; }

        /// <summary>
        /// Is the war currently open for allies or not
        /// </summary>
        /// <value>Is the war currently open for allies or not</value>
        [JsonProperty("open_for_allies")]
        public bool OpenForAllies { get; set; }

        /// <summary>
        /// Time the war was retracted but both sides could still shoot each other
        /// </summary>
        /// <value>Time the war was retracted but both sides could still shoot each other</value>
        [JsonProperty("retracted")]
        public DateTime? Retracted { get; set; }

        /// <summary>
        /// Time when the war started and both sides could shoot each other
        /// </summary>
        /// <value>Time when the war started and both sides could shoot each other</value>
        [JsonProperty("started")]
        public DateTime? Started { get; set; }

        #endregion Properties
    }

    public class WarAggressor : ModelBase<WarAggressor>
    {
        #region Properties

        /// <summary>
        /// Alliance ID if and only if the aggressor is an alliance
        /// </summary>
        /// <value>Alliance ID if and only if the aggressor is an alliance</value>
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// Corporation ID if and only if the aggressor is a corporation
        /// </summary>
        /// <value>Corporation ID if and only if the aggressor is a corporation</value>
        [JsonProperty("corporation_id")]
        public int? CorporationId { get; set; }
        /// <summary>
        /// ISK value of ships the aggressor has destroyed
        /// </summary>
        /// <value>ISK value of ships the aggressor has destroyed</value>
        [JsonProperty("isk_destroyed")]
        public float IskDestroyed { get; set; }

        /// <summary>
        /// The number of ships the aggressor has killed
        /// </summary>
        /// <value>The number of ships the aggressor has killed</value>
        [JsonProperty("ships_killed")]
        public int ShipsKilled { get; set; }

        #endregion Properties
    }

    public class WarAlly : ModelBase<WarAlly>
    {
        #region Properties

        /// <summary>
        /// Alliance ID if and only if this ally is an alliance
        /// </summary>
        /// <value>Alliance ID if and only if this ally is an alliance</value>
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// Corporation ID if and only if this ally is a corporation
        /// </summary>
        /// <value>Corporation ID if and only if this ally is a corporation</value>
        [JsonProperty("corporation_id")]
        public int? CorporationId { get; set; }

        #endregion Properties
    }

    public class WarDefender : ModelBase<WarDefender>
    {
        #region Properties

        /// <summary>
        /// Alliance ID if and only if the defender is an alliance
        /// </summary>
        /// <value>Alliance ID if and only if the defender is an alliance</value>
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// Corporation ID if and only if the defender is a corporation
        /// </summary>
        /// <value>Corporation ID if and only if the defender is a corporation</value>
        [JsonProperty("corporation_id")]
        public int? CorporationId { get; set; }
        /// <summary>
        /// ISK value of ships the defender has killed
        /// </summary>
        /// <value>ISK value of ships the defender has killed</value>
        [JsonProperty("isk_destroyed")]
        public float IskDestroyed { get; set; }

        /// <summary>
        /// The number of ships the defender has killed
        /// </summary>
        /// <value>The number of ships the defender has killed</value>
        [JsonProperty("ships_killed")]
        public int ShipsKilled { get; set; }

        #endregion Properties
    }
}
