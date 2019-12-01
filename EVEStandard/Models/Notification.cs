using Newtonsoft.Json;
using System;

namespace EVEStandard.Models
{
    public class Notification : ModelBase<Notification>
    {
        #region Enums

        /// <summary>
        /// sender_type string
        /// </summary>
        /// <value>sender_type string</value>
        public enum SenderTypeEnum
        {
            character = 1,
            corporation = 2,
            alliance = 3,
            faction = 4,
            other = 5
        }

        /// <summary>
        /// type string
        /// </summary>
        /// <value>type string</value>
        public enum TypeEnum
        {
            AcceptedAlly,
            AcceptedSurrender,
            AllAnchoringMsg,
            AllMaintenanceBillMsg,
            AllStrucInvulnerableMsg,
            AllStructVulnerableMsg,
            AllWarCorpJoinedAllianceMsg,
            AllWarDeclaredMsg,
            AllWarInvalidatedMsg,
            AllWarRetractedMsg,
            AllWarSurrenderMsg,
            AllianceCapitalChanged,
            AllyContractCancelled,
            AllyJoinedWarAggressorMsg,
            AllyJoinedWarAllyMsg,
            AllyJoinedWarDefenderMsg,
            BattlePunishFriendlyFire,
            BillOutOfMoneyMsg,
            BillPaidCorpAllMsg,
            BountyClaimMsg,
            BountyESSShared,
            BountyESSTaken,
            BountyPlacedAlliance,
            BountyPlacedChar,
            BountyPlacedCorp,
            BountyYourBountyClaimed,
            BuddyConnectContactAdd,
            CharAppAcceptMsg,
            CharAppRejectMsg,
            CharAppWithdrawMsg,
            CharLeftCorpMsg,
            CharMedalMsg,
            CharTerminationMsg,
            CloneActivationMsg,
            CloneActivationMsg2,
            CloneMovedMsg,
            CloneRevokedMsg1,
            CloneRevokedMsg2,
            CombatOperationFinished,
            ContactAdd,
            ContactEdit,
            ContainerPasswordMsg,
            CorpAllBillMsg,
            CorpAppAcceptMsg,
            CorpAppInvitedMsg,
            CorpAppNewMsg,
            CorpAppRejectCustomMsg,
            CorpAppRejectMsg,
            CorpDividendMsg,
            CorpFriendlyFireDisableTimerCompleted,
            CorpFriendlyFireDisableTimerStarted,
            CorpFriendlyFireEnableTimerCompleted,
            CorpFriendlyFireEnableTimerStarted,
            CorpKicked,
            CorpLiquidationMsg,
            CorpNewCEOMsg,
            CorpNewsMsg,
            CorpOfficeExpirationMsg,
            CorpStructLostMsg,
            CorpTaxChangeMsg,
            CorpVoteCEORevokedMsg,
            CorpVoteMsg,
            CorpWarDeclaredMsg,
            CorpWarFightingLegalMsg,
            CorpWarInvalidatedMsg,
            CorpWarRetractedMsg,
            CorpWarSurrenderMsg,
            CustomsMsg,
            DeclareWar,
            DistrictAttacked,
            DustAppAcceptedMsg,
            EntosisCaptureStarted,
            FWAllianceKickMsg,
            FWAllianceWarningMsg,
            FWCharKickMsg,
            FWCharRankGainMsg,
            FWCharRankLossMsg,
            FWCharWarningMsg,
            FWCorpJoinMsg,
            FWCorpKickMsg,
            FWCorpLeaveMsg,
            FWCorpWarningMsg,
            FacWarCorpJoinRequestMsg,
            FacWarCorpJoinWithdrawMsg,
            FacWarCorpLeaveRequestMsg,
            FacWarCorpLeaveWithdrawMsg,
            FacWarLPDisqualifiedEvent,
            FacWarLPDisqualifiedKill,
            FacWarLPPayoutEvent,
            FacWarLPPayoutKill,
            GameTimeAdded,
            GameTimeReceived,
            GameTimeSent,
            GiftReceived,
            IHubDestroyedByBillFailure,
            IncursionCompletedMsg,
            IndustryOperationFinished,
            IndustryTeamAuctionLost,
            IndustryTeamAuctionWon,
            InfrastructureHubBillAboutToExpire,
            InsuranceExpirationMsg,
            InsuranceFirstShipMsg,
            InsuranceInvalidatedMsg,
            InsuranceIssuedMsg,
            InsurancePayoutMsg,
            JumpCloneDeletedMsg1,
            JumpCloneDeletedMsg2,
            KillReportFinalBlow,
            KillReportVictim,
            KillRightAvailable,
            KillRightAvailableOpen,
            KillRightEarned,
            KillRightUnavailable,
            KillRightUnavailableOpen,
            KillRightUsed,
            LocateCharMsg,
            MadeWarMutual,
            MercOfferedNegotiationMsg,
            MissionOfferExpirationMsg,
            MissionTimeoutMsg,
            MoonminingAutomaticFracture,
            MoonminingExtractionCancelled,
            MoonminingExtractionFinished,
            MoonminingExtractionStarted,
            MoonminingLaserFired,
            NPCStandingsGained,
            NPCStandingsLost,
            OfferedSurrender,
            OfferedToAlly,
            OldLscMessages,
            OperationFinished,
            OrbitalAttacked,
            OrbitalReinforced,
            OwnershipTransferred,
            ReimbursementMsg,
            ResearchMissionAvailableMsg,
            RetractsWar,
            SeasonalChallengeCompleted,
            SovAllClaimAquiredMsg,
            SovAllClaimLostMsg,
            SovCommandNodeEventStarted,
            SovCorpBillLateMsg,
            SovCorpClaimFailMsg,
            SovDisruptorMsg,
            SovStationEnteredFreeport,
            SovStructureDestroyed,
            SovStructureReinforced,
            SovStructureSelfDestructCancel,
            SovStructureSelfDestructFinished,
            SovStructureSelfDestructRequested,
            SovereigntyIHDamageMsg,
            SovereigntySBUDamageMsg,
            SovereigntyTCUDamageMsg,
            StationAggressionMsg1,
            StationAggressionMsg2,
            StationConquerMsg,
            StationServiceDisabled,
            StationServiceEnabled,
            StationStateChangeMsg,
            StoryLineMissionAvailableMsg,
            StructureAnchoring,
            StructureCourierContractChanged,
            StructureDestroyed,
            StructureFuelAlert,
            StructureItemsDelivered,
            StructureItemsMovedToSafety,
            StructureLostArmor,
            StructureLostShields,
            StructureOnline,
            StructureServicesOffline,
            StructureUnanchoring,
            StructureUnderAttack,
            StructureWentHighPower,
            StructureWentLowPower,
            StructuresJobsCancelled,
            StructuresJobsPaused,
            StructuresReinforcementChanged,
            TowerAlertMsg,
            TowerResourceAlertMsg,
            TransactionReversalMsg,
            TutorialMsg,
            WarAllyOfferDeclinedMsg,
            WarSurrenderDeclinedMsg,
            WarSurrenderOfferMsg
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// is_read boolean
        /// </summary>
        /// <value>is_read boolean</value>
        [JsonProperty("is_read")]
        public bool? IsRead { get; set; }

        /// <summary>
        /// notification_id integer
        /// </summary>
        /// <value>notification_id integer</value>
        [JsonProperty("notification_id")]
        public long NotificationId { get; set; }

        /// <summary>
        /// sender_id integer
        /// </summary>
        /// <value>sender_id integer</value>
        [JsonProperty("sender_id")]
        public int SenderId { get; set; }

        /// <summary>
        /// sender_type string
        /// </summary>
        /// <value>sender_type string</value>
        [JsonProperty("sender_type")]
        public SenderTypeEnum SenderType { get; set; }

        /// <summary>
        /// text string
        /// </summary>
        /// <value>text string</value>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// timestamp string
        /// </summary>
        /// <value>timestamp string</value>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// type string
        /// </summary>
        /// <value>type string</value>
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        #endregion Properties
    }
}
