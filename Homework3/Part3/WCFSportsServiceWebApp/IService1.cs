using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFSportsServiceWebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "soccer/date={date}", ResponseFormat = WebMessageFormat.Json)]
        List<SoccerGames> SoccerService(string date);

        [OperationContract]
        [WebGet(UriTemplate = "nba/date={date}", ResponseFormat = WebMessageFormat.Json)]
        List<NBAGames> NBAService(string date);
    }

    public class SoccerGames
    {
        //public int GameId { get; set; }
        //public int RoundId { get; set; }
        public int Season { get; set; }
        public int SeasonType { get; set; }
        //public string Group { get; set; }
        //public int AwayTeamId { get; set; }
        //public int HomeTeamId { get; set; }
        //public int VenueId { get; set; }
        //public DateTime Day { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public int? Week { get; set; }
        //public string Period { get; set; }
        //public int Clock { get; set; }
        //public string Winner { get; set; }
        //public string VenueType { get; set; }
        public string AwayTeamKey { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamCountryCode { get; set; }
        public int? AwayTeamScore { get; set; }
        public int? AwayTeamScorePeriod1 { get; set; }
        public int? AwayTeamScorePeriod2 { get; set; }
        //public int AwayTeamScoreExtraTime { get; set; }
        //public int AwayTeamScorePenalty { get; set; }
        public string HomeTeamKey { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamCountryCode { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? HomeTeamScorePeriod1 { get; set; }
        public int? HomeTeamScorePeriod2 { get; set; }
        //public int HomeTeamScoreExtraTime { get; set; }
        //public int HomeTeamScorePenalty { get; set; }
        //public int HomeTeamMoneyLine { get; set; }
        //public int AwayTeamMoneyLine { get; set; }
        //public int DrawMoneyLine { get; set; }
        //public double PointSpread { get; set; }
        //public int HomeTeamPointSpreadPayout { get; set; }
        //public int AwayTeamPointSpreadPayout { get; set; }
        //public double OverUnder { get; set; }
        //public int OverPayout { get; set; }
        //public int UnderPayout { get; set; }
        //public int Attendance { get; set; }
        public DateTime Updated { get; set; }
        //public DateTime UpdatedUtc { get; set; }
        //public int GlobalGameId { get; set; }
        //public int GlobalAwayTeamId { get; set; }
        //public int GlobalHomeTeamId { get; set; }
        //public int ClockExtra { get; set; }
        //public string ClockDisplay { get; set; }
        //public bool IsClosed { get; set; }
        //public string HomeTeamFormation { get; set; }
        //public string AwayTeamFormation { get; set; }
        //public PlayoffAggregateScore PlayoffAggregateScore { get; set; }
    }

    public class PlayoffAggregateScore
    {
        public int TeamA_Id { get; set; }
        public int TeamA_AggregateScore { get; set; }
        public int TeamB_Id { get; set; }
        public int TeamB_AggregateScore { get; set; }
        public int WinningTeamId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public class NBAGames
    {
        public int GameID { get; set; }
        public int Season { get; set; }
        public int SeasonType { get; set; }
        public string Status { get; set; }
        public DateTime Day { get; set; }
        public DateTime DateTime { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeam { get; set; }
        public int AwayTeamID { get; set; }
        public int HomeTeamID { get; set; }
        public int StadiumID { get; set; }
        public string Channel { get; set; }
        public object Attendance { get; set; }
        public int? AwayTeamScore { get; set; }
        public int? HomeTeamScore { get; set; }
        public DateTime Updated { get; set; }
        public string Quarter { get; set; }
        public int? TimeRemainingMinutes { get; set; }
        public int? TimeRemainingSeconds { get; set; }
        public double PointSpread { get; set; }
        public double OverUnder { get; set; }
        public int AwayTeamMoneyLine { get; set; }
        public int HomeTeamMoneyLine { get; set; }
        public int GlobalGameID { get; set; }
        public int GlobalAwayTeamID { get; set; }
        public int GlobalHomeTeamID { get; set; }
        public int PointSpreadAwayTeamMoneyLine { get; set; }
        public int PointSpreadHomeTeamMoneyLine { get; set; }
        public string LastPlay { get; set; }
        public bool IsClosed { get; set; }
        public DateTime? GameEndDateTime { get; set; }
        public int HomeRotationNumber { get; set; }
        public int AwayRotationNumber { get; set; }
        public bool NeutralVenue { get; set; }
        public int OverPayout { get; set; }
        public int UnderPayout { get; set; }
        public int CrewChiefID { get; set; }
        public int UmpireID { get; set; }
        public int RefereeID { get; set; }
        public object AlternateID { get; set; }
        public DateTime DateTimeUTC { get; set; }
        public object SeriesInfo { get; set; }
        public List<Quarter> Quarters { get; set; }
    }

    public class Quarter
    {
        public int QuarterID { get; set; }
        public int GameID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int AwayScore { get; set; }
        public int HomeScore { get; set; }
    }
}
