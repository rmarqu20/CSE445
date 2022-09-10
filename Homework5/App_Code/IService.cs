using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public interface IService
{
    //NewsFocus
    [OperationContract]
    [WebGet(UriTemplate = "news/topic={topic}", ResponseFormat = WebMessageFormat.Json)]
    newsInformation NewsFocus(String topic);

    //WeatherService
    [OperationContract]
    [WebGet(UriTemplate = "weather/zipcode={zipcode}", ResponseFormat = WebMessageFormat.Json)]
    weatherInformation WeatherService(string zipcode);

    [OperationContract]
    [WebGet(UriTemplate = "weather/astro/zipcode={zipcode}", ResponseFormat = WebMessageFormat.Json)]
    astro AstroService(string zipcode);

    [OperationContract]
    [WebGet(UriTemplate = "weather/days={days}/zipcode={zipcode}", ResponseFormat = WebMessageFormat.Json)]
    day[] DayService(string days, string zipcode);

    [OperationContract]
    [WebGet(UriTemplate = "location/zipcode={zipcode}", ResponseFormat = WebMessageFormat.Json)]
    location LocationService(string zipcode);

    //SportsService
    [OperationContract]
    [WebGet(UriTemplate = "soccer/date={date}", ResponseFormat = WebMessageFormat.Json)]
    List<SoccerGames> SoccerService(string date);

    [OperationContract]
    [WebGet(UriTemplate = "nba/date={date}", ResponseFormat = WebMessageFormat.Json)]
    List<NBAGames> NBAService(string date);
}

//NewsFocus Structs
public class Article
{
    public string author { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string urlToImage { get; set; }
    public string publishedAt { get; set; }
}

public class newsInformation
{
    public string status { get; set; }
    public string source { get; set; }
    public string sortBy { get; set; }
    public List<Article> articles { get; set; }
}

//Weather Structs
public class weatherInformation
{
    public location location { get; set; }
    public current current { get; set; }
    public forecast forecast { get; set; }
}

public class location
{
    public string name { get; set; }
    public string region { get; set; }
    public string country { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string tz_id { get; set; }
    public int localtime_epoch { get; set; }
    public string localtime { get; set; }
}

public class current
{
    public int last_updated_epoch { get; set; }
    public string last_updated { get; set; }
    public double temp_c { get; set; }
    public double temp_f { get; set; }
    public int is_day { get; set; }
    public condition condition { get; set; }
    public double wind_mph { get; set; }
    public double wind_kph { get; set; }
    public int wind_degree { get; set; }
    public string wind_dir { get; set; }
    public double pressure_mb { get; set; }
    public double pressure_in { get; set; }
    public double precip_mm { get; set; }
    public double precip_in { get; set; }
    public int humidity { get; set; }
    public int cloud { get; set; }
    public double feelslike_c { get; set; }
    public double feelslike_f { get; set; }
    public double vis_km { get; set; }
    public double vis_miles { get; set; }
    public double uv { get; set; }
    public double gust_mph { get; set; }
    public double gust_kph { get; set; }
}

public class condition
{
    public string text { get; set; }
    public string icon { get; set; }
    public int code { get; set; }
}

public class forecast
{
    public forecastday[] forecastday { get; set; }
}

public class forecastday
{
    public string date { get; set; }
    public int date_epoch { get; set; }
    public day day { get; set; }
    public astro astro { get; set; }
    public hour[] hour { get; set; }
}
public class day
{
    public double maxtemp_c { get; set; }
    public double maxtemp_f { get; set; }
    public double mintemp_c { get; set; }
    public double mintemp_f { get; set; }
    public double avgtemp_c { get; set; }
    public double avgtemp_f { get; set; }
    public double maxwind_mph { get; set; }
    public double maxwind_kph { get; set; }
    public double totalprecip_mm { get; set; }
    public double totalprecip_in { get; set; }
    public double avgvis_km { get; set; }
    public double avgvis_miles { get; set; }
    public double avghumidity { get; set; }
    public int daily_will_it_rain { get; set; }
    public int daily_chance_of_rain { get; set; }
    public int daily_will_it_snow { get; set; }
    public int daily_chance_of_snow { get; set; }
    public condition condition { get; set; }
    public double uv { get; set; }
}

public class astro
{
    public string sunrise { get; set; }
    public string sunset { get; set; }
    public string moonrise { get; set; }
    public string moonset { get; set; }
    public string moon_phase { get; set; }
    public string moon_illumination { get; set; }
}

public class hour
{
    public int time_epoch { get; set; }
    public string time { get; set; }
    public double temp_c { get; set; }
    public double temp_f { get; set; }
    public int is_day { get; set; }
    public condition condition { get; set; }
    public double wind_mph { get; set; }
    public double wind_kph { get; set; }
    public int wind_degree { get; set; }
    public string wind_dir { get; set; }
    public double pressure_mb { get; set; }
    public double pressure_in { get; set; }
    public double precip_mm { get; set; }
    public double precip_in { get; set; }
    public int humidity { get; set; }
    public int cloud { get; set; }
    public double feelslike_c { get; set; }
    public double feelslike_f { get; set; }
    public double windchill_c { get; set; }
    public double windchill_f { get; set; }
    public double heatindex_c { get; set; }
    public double heatindex_f { get; set; }
    public double dewpoint_c { get; set; }
    public double dewpoint_f { get; set; }
    public int will_it_rain { get; set; }
    public int chance_of_rain { get; set; }
    public int will_it_snow { get; set; }
    public int chance_of_snow { get; set; }
    public double vis_km { get; set; }
    public double vis_miles { get; set; }
    public double gust_mph { get; set; }
    public double gust_kph { get; set; }
    public double uv { get; set; }
}

//Sports Structs 
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