using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class WalletTransaction : ModelBase<WalletTransaction>
    {
        #region Properties

        /// <summary>
        /// client_id integer
        /// </summary>
        /// <value>client_id integer</value>
        [JsonProperty("client_id")]
        public int ClientId { get; set; }

        /// <summary>
        /// Date and time of transaction
        /// </summary>
        /// <value>Date and time of transaction</value>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// is_buy boolean
        /// </summary>
        /// <value>is_buy boolean</value>
        [JsonProperty("is_buy")]
        public bool IsBuy { get; set; }

        /// <summary>
        /// is_personal boolean
        /// </summary>
        /// <value>is_personal boolean</value>
        [JsonProperty("is_personal")]
        public bool IsPersonal { get; set; }

        /// <summary>
        /// journal_ref_id integer
        /// </summary>
        /// <value>journal_ref_id integer</value>
        [JsonProperty("journal_ref_id")]
        public long JournalRefId { get; set; }

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Unique transaction ID
        /// </summary>
        /// <value>Unique transaction ID</value>
        [JsonProperty("transaction_id")]
        public long TransactionId { get; set; }
        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }
        /// <summary>
        /// Amount paid per unit
        /// </summary>
        /// <value>Amount paid per unit</value>
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }

        #endregion Properties
    }
}
