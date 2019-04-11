using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class ColonyLayout : ModelBase<ColonyLayout>
    {
        /// <summary>
        /// links array
        /// </summary>
        /// <value>links array</value>
        [JsonProperty("links")]
        public List<ColonyLink> Links { get; set; }

        /// <summary>
        /// pins array
        /// </summary>
        /// <value>pins array</value>
        [JsonProperty("pins")]
        public List<ColonyPin> Pins { get; set; }

        /// <summary>
        /// routes array
        /// </summary>
        /// <value>routes array</value>
        [JsonProperty("routes")]
        public List<ColonyRoute> Routes { get; set; }
    }

    public class ColonyLink : ModelBase<ColonyLink>
    {
        /// <summary>
        /// source_pin_id integer
        /// </summary>
        /// <value>source_pin_id integer</value>
        [JsonProperty("source_pin_id")]
        public long SourcePinId { get; set; }

        /// <summary>
        /// destination_pin_id integer
        /// </summary>
        /// <value>destination_pin_id integer</value>
        [JsonProperty("destination_pin_id")]
        public long DestinationPinId { get; set; }

        /// <summary>
        /// link_level integer
        /// </summary>
        /// <value>link_level integer</value>
        [JsonProperty("link_level")]
        public int LinkLevel { get; set; }
    }

    public class ColonyPin : ModelBase<ColonyPin>
    {
        /// <summary>
        /// latitude number
        /// </summary>
        /// <value>latitude number</value>
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// longitude number
        /// </summary>
        /// <value>longitude number</value>
        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// pin_id integer
        /// </summary>
        /// <value>pin_id integer</value>
        [JsonProperty("pin_id")]
        public long PinId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// schematic_id integer
        /// </summary>
        /// <value>schematic_id integer</value>
        [JsonProperty("schematic_id")]
        public int? SchematicId { get; set; }

        /// <summary>
        /// Gets or Sets ExtractorDetails
        /// </summary>
        [JsonProperty("extractor_details")]
        public ColonyExtractorDetails ExtractorDetails { get; set; }

        /// <summary>
        /// Gets or Sets FactoryDetails
        /// </summary>
        [JsonProperty("factory_details")]
        public ColonyFactoryDetails FactoryDetails { get; set; }

        /// <summary>
        /// contents array
        /// </summary>
        /// <value>contents array</value>
        [JsonProperty("contents")]
        public List<ColonyContent> Contents { get; set; }

        /// <summary>
        /// install_time string
        /// </summary>
        /// <value>install_time string</value>
        [JsonProperty("install_time")]
        public DateTime? InstallTime { get; set; }

        /// <summary>
        /// expiry_time string
        /// </summary>
        /// <value>expiry_time string</value>
        [JsonProperty("expiry_time")]
        public DateTime? ExpiryTime { get; set; }

        /// <summary>
        /// last_cycle_start string
        /// </summary>
        /// <value>last_cycle_start string</value>
        [JsonProperty("last_cycle_start")]
        public DateTime? LastCycleStart { get; set; }
    }

    public class ColonyRoute : ModelBase<ColonyRoute>
    {
        /// <summary>
        /// route_id integer
        /// </summary>
        /// <value>route_id integer</value>
        [JsonProperty("route_id")]
        public long RouteId { get; set; }

        /// <summary>
        /// source_pin_id integer
        /// </summary>
        /// <value>source_pin_id integer</value>
        [JsonProperty("source_pin_id")]
        public long SourcePinId { get; set; }

        /// <summary>
        /// destination_pin_id integer
        /// </summary>
        /// <value>destination_pin_id integer</value>
        [JsonProperty("destination_pin_id")]
        public long DestinationPinId { get; set; }

        /// <summary>
        /// content_type_id integer
        /// </summary>
        /// <value>content_type_id integer</value>
        [JsonProperty("content_type_id")]
        public int ContentTypeId { get; set; }

        /// <summary>
        /// quantity number
        /// </summary>
        /// <value>quantity number</value>
        [JsonProperty("quantity")]
        public float Quantity { get; set; }

        /// <summary>
        /// list of pin ID waypoints
        /// </summary>
        /// <value>list of pin ID waypoints</value>
        [JsonProperty("waypoints")]
        public List<long> Waypoints { get; set; }
    }

    public class ColonyExtractorDetails : ModelBase<ColonyExtractorDetails>
    {
        /// <summary>
        /// heads array
        /// </summary>
        /// <value>heads array</value>
        [JsonProperty("heads")]
        public List<ColonyHead> Heads { get; set; }

        /// <summary>
        /// product_type_id integer
        /// </summary>
        /// <value>product_type_id integer</value>
        [JsonProperty("product_type_id")]
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// in seconds
        /// </summary>
        /// <value>in seconds</value>
        [JsonProperty("cycle_time")]
        public int? CycleTime { get; set; }

        /// <summary>
        /// head_radius number
        /// </summary>
        /// <value>head_radius number</value>
        [JsonProperty("head_radius")]
        public float? HeadRadius { get; set; }

        /// <summary>
        /// qty_per_cycle integer
        /// </summary>
        /// <value>qty_per_cycle integer</value>
        [JsonProperty("qty_per_cycle")]
        public int? QtyPerCycle { get; set; }
    }

    public class ColonyFactoryDetails : ModelBase<ColonyFactoryDetails>
    {
        /// <summary>
        /// schematic_id integer
        /// </summary>
        /// <value>schematic_id integer</value>
        [JsonProperty("schematic_id")]
        public int SchematicId { get; set; }
    }

    public class ColonyContent : ModelBase<ColonyContent>
    {
        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// amount integer
        /// </summary>
        /// <value>amount integer</value>
        [JsonProperty("amount")]
        public long Amount { get; set; }
    }

    public class ColonyHead : ModelBase<ColonyHead>
    {
        /// <summary>
        /// head_id integer
        /// </summary>
        /// <value>head_id integer</value>
        [JsonProperty("head_id")]
        public int HeadId { get; set; }

        /// <summary>
        /// latitude number
        /// </summary>
        /// <value>latitude number</value>
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// longitude number
        /// </summary>
        /// <value>longitude number</value>
        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }
}
