using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot.DomainModel.GameDomainModel
{
    public class Challenges
    {
        [JsonProperty("12AssistStreakCount")]
        public int _12AssistStreakCount { get; set; }
        public int abilityUses { get; set; }
        public int acesBefore15Minutes { get; set; }
        public int alliedJungleMonsterKills { get; set; }
        public int baronTakedowns { get; set; }
        public int blastConeOppositeOpponentCount { get; set; }
        public int bountyGold { get; set; }
        public int buffsStolen { get; set; }
        public int completeSupportQuestInTime { get; set; }
        public int controlWardsPlaced { get; set; }
        public double damagePerMinute { get; set; }
        public double damageTakenOnTeamPercentage { get; set; }
        public int dancedWithRiftHerald { get; set; }
        public int deathsByEnemyChamps { get; set; }
        public int dodgeSkillShotsSmallWindow { get; set; }
        public int doubleAces { get; set; }
        public int dragonTakedowns { get; set; }
        public int earlyLaningPhaseGoldExpAdvantage { get; set; }
        public double effectiveHealAndShielding { get; set; }
        public int elderDragonKillsWithOpposingSoul { get; set; }
        public int elderDragonMultikills { get; set; }
        public int enemyChampionImmobilizations { get; set; }
        public int enemyJungleMonsterKills { get; set; }
        public int epicMonsterKillsNearEnemyJungler { get; set; }
        public int epicMonsterKillsWithin30SecondsOfSpawn { get; set; }
        public int epicMonsterSteals { get; set; }
        public int epicMonsterStolenWithoutSmite { get; set; }
        public int flawlessAces { get; set; }
        public int fullTeamTakedown { get; set; }
        public double gameLength { get; set; }
        public int getTakedownsInAllLanesEarlyJungleAsLaner { get; set; }
        public double goldPerMinute { get; set; }
        public int hadOpenNexus { get; set; }
        public int immobilizeAndKillWithAlly { get; set; }
        public int initialBuffCount { get; set; }
        public int initialCrabCount { get; set; }
        public double jungleCsBefore10Minutes { get; set; }
        public int junglerTakedownsNearDamagedEpicMonster { get; set; }
        public int kTurretsDestroyedBeforePlatesFall { get; set; }
        public double kda { get; set; }
        public int killAfterHiddenWithAlly { get; set; }
        public double killParticipation { get; set; }
        public int killedChampTookFullTeamDamageSurvived { get; set; }
        public int killingSprees { get; set; }
        public int killsNearEnemyTurret { get; set; }
        public int killsOnOtherLanesEarlyJungleAsLaner { get; set; }
        public int killsOnRecentlyHealedByAramPack { get; set; }
        public int killsUnderOwnTurret { get; set; }
        public int killsWithHelpFromEpicMonster { get; set; }
        public int knockEnemyIntoTeamAndKill { get; set; }
        public int landSkillShotsEarlyGame { get; set; }
        public int laneMinionsFirst10Minutes { get; set; }
        public int laningPhaseGoldExpAdvantage { get; set; }
        public int legendaryCount { get; set; }
        public int lostAnInhibitor { get; set; }
        public double maxCsAdvantageOnLaneOpponent { get; set; }
        public int maxKillDeficit { get; set; }
        public int maxLevelLeadLaneOpponent { get; set; }
        public int mejaisFullStackInTime { get; set; }
        public double moreEnemyJungleThanOpponent { get; set; }
        public int multiKillOneSpell { get; set; }
        public int multiTurretRiftHeraldCount { get; set; }
        public int multikills { get; set; }
        public int multikillsAfterAggressiveFlash { get; set; }
        public int outerTurretExecutesBefore10Minutes { get; set; }
        public int outnumberedKills { get; set; }
        public int outnumberedNexusKill { get; set; }
        public int perfectDragonSoulsTaken { get; set; }
        public int perfectGame { get; set; }
        public int pickKillWithAlly { get; set; }
        public int playedChampSelectPosition { get; set; }
        public int poroExplosions { get; set; }
        public int quickCleanse { get; set; }
        public int quickFirstTurret { get; set; }
        public int quickSoloKills { get; set; }
        public int riftHeraldTakedowns { get; set; }
        public int saveAllyFromDeath { get; set; }
        public int scuttleCrabKills { get; set; }
        public int skillshotsDodged { get; set; }
        public int skillshotsHit { get; set; }
        public int snowballsHit { get; set; }
        public int soloBaronKills { get; set; }
        public int soloKills { get; set; }
        public int soloTurretsLategame { get; set; }
        public int stealthWardsPlaced { get; set; }
        public int survivedSingleDigitHpCount { get; set; }
        public int survivedThreeImmobilizesInFight { get; set; }
        public int takedownOnFirstTurret { get; set; }
        public int takedowns { get; set; }
        public int takedownsAfterGainingLevelAdvantage { get; set; }
        public int takedownsBeforeJungleMinionSpawn { get; set; }
        public int takedownsFirstXMinutes { get; set; }
        public int takedownsInAlcove { get; set; }
        public int takedownsInEnemyFountain { get; set; }
        public int teamBaronKills { get; set; }
        public double teamDamagePercentage { get; set; }
        public int teamElderDragonKills { get; set; }
        public int teamRiftHeraldKills { get; set; }
        public int threeWardsOneSweeperCount { get; set; }
        public int tookLargeDamageSurvived { get; set; }
        public int turretPlatesTaken { get; set; }
        public int turretTakedowns { get; set; }
        public int turretsTakenWithRiftHerald { get; set; }
        public int twentyMinionsIn3SecondsCount { get; set; }
        public int unseenRecalls { get; set; }
        public double visionScoreAdvantageLaneOpponent { get; set; }
        public double visionScorePerMinute { get; set; }
        public int wardTakedowns { get; set; }
        public int wardTakedownsBefore20M { get; set; }
        public int wardsGuarded { get; set; }
        public double? controlWardTimeCoverageInRiverOrEnemyHalf { get; set; }
        public double? earliestDragonTakedown { get; set; }
        public int? junglerKillsEarlyJungle { get; set; }
        public int? killsOnLanersEarlyJungleAsJungler { get; set; }
        public int? mythicItemUsed { get; set; }
        public int? highestCrowdControlScore { get; set; }
        public int? highestWardKills { get; set; }
        public double? firstTurretKilled { get; set; }
        public int? highestChampionDamage { get; set; }
        public double? fastestLegendary { get; set; }
        public int? fasterSupportQuestCompletion { get; set; }
    }
}
