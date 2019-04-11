using System.Runtime.Serialization;

namespace EVEStandard.Enumerations
{
    public enum ServicesEnum
    {
        [EnumMember(Value = "bounty-missions")]
        BountyMissions = 1,
        [EnumMember(Value = "assassination-missions")]
        AssasinationMissions = 2,
        [EnumMember(Value = "courier-missions")]
        CourierMissions = 3,
        Interbus = 4,
        [EnumMember(Value = "reprocessing-plant")]
        ReprocessingPlant = 5,
        Refinery = 6,
        Market = 7,
        [EnumMember(Value = "black-market")]
        BlackMarket = 8,
        [EnumMember(Value = "stock-exchange")]
        StockExchange = 9,
        Cloning = 10,
        Surgery = 11,
        [EnumMember(Value = "dna-therapy")]
        DnaTherapy = 12,
        [EnumMember(Value = "repair-facilities")]
        RepairFacilities = 13,
        Factory = 14,
        Labratory = 15,
        Gambling = 16,
        Fitting = 17,
        Paintshop = 18,
        News = 19,
        Storage = 20,
        Insurance = 21,
        Docking = 22,
        [EnumMember(Value = "office-rental")]
        OfficeRental = 23,
        [EnumMember(Value = "jump-clone-facility")]
        JumpCloneFacility = 24,
        [EnumMember(Value = "loyalty-point-store")]
        LoyaltyPointStore = 25,
        [EnumMember(Value = "navy-offices")]
        NavyOffices = 26,
        [EnumMember(Value = "security-offices")]
        SecurityOffices = 27
    }
}
