using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace WCFSportsServiceWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //REST Sports Service
            string date = TextBox1.Text;
            if (date == "")
            {
                date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            string host = "http://webstrar41.fulton.asu.edu/page3/"; //Old: http://localhost:58479
            string url = host + "/Service1.svc/soccer/date=" + date;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();

                List<SoccerGames> userObject = JsonConvert.DeserializeObject<List<SoccerGames>>(responsereader);
                int count = userObject.Count();
                for (int i = 0; i < count; i++)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    HtmlGenericControl season = new HtmlGenericControl("p");
                    HtmlGenericControl time = new HtmlGenericControl("p");
                    HtmlGenericControl updatedTime = new HtmlGenericControl("p");
                    HtmlGenericControl home = new HtmlGenericControl("p");
                    HtmlGenericControl away = new HtmlGenericControl("p");
                    HtmlGenericControl homeScore = new HtmlGenericControl("p");
                    HtmlGenericControl awayScore = new HtmlGenericControl("p");

                    int seasonType = userObject[i].SeasonType;
                    switch (seasonType)
                    {
                        case 1:
                            if(userObject[i].Week == null)
                            {
                                int week = 0;
                                season.InnerText = "Season: " + userObject[i].Season + " Week: " + week + " Regular Season";
                            }
                            else
                            {
                                season.InnerText = "Season: " + userObject[i].Season + " Week: " + userObject[i].Week + " Regular Season";
                            }                            
                            break;
                        case 2:
                            season.InnerText = "Season: " + userObject[i].Season + " Preseason";
                            break;
                        case 3:
                            season.InnerText = "Season: " + userObject[i].Season + " Postseason";
                            break;
                        case 4:
                            season.InnerText = "Season: " + userObject[i].Season + " Offseason";
                            break;
                        case 5:
                            season.InnerText = "Season: " + userObject[i].Season + " AllStar";
                            break;
                    }

                    if (userObject[i].HomeTeamScore == null && userObject[i].HomeTeamScorePeriod1 == null && userObject[i].HomeTeamScorePeriod2 == null)
                    {
                        userObject[i].HomeTeamScore = 0;
                        userObject[i].HomeTeamScorePeriod1 = 0;
                        userObject[i].HomeTeamScorePeriod2 = 0;
                    }

                    if (userObject[i].AwayTeamScore == null && userObject[i].AwayTeamScorePeriod1 == null && userObject[i].AwayTeamScorePeriod2 == null)
                    {
                        userObject[i].AwayTeamScore = 0;
                        userObject[i].AwayTeamScorePeriod1 = 0;
                        userObject[i].AwayTeamScorePeriod2 = 0;
                    }

                    DateTime eventTime = userObject[i].DateTime;
                    eventTime = eventTime.AddHours(-4);

                    time.InnerText = "Event Time:" + eventTime + " EST";
                    updatedTime.InnerText = "Last Updated:" + userObject[i].Updated.ToString() + " EST";
                    home.InnerText = "Home Team: [" + userObject[i].HomeTeamKey + "] " + userObject[i].HomeTeamName + " " + userObject[i].HomeTeamCountryCode;
                    homeScore.InnerText = "Score: " + userObject[i].HomeTeamScore + " Period 1: " + userObject[i].HomeTeamScorePeriod1 + " Period 2: " + userObject[i].HomeTeamScorePeriod2;
                    away.InnerText = "Away Team: [" + userObject[i].AwayTeamKey + "] " + userObject[i].AwayTeamName + " " + userObject[i].AwayTeamCountryCode;
                    awayScore.InnerText = "Score: " + userObject[i].AwayTeamScore + " Period 1: " + userObject[i].AwayTeamScorePeriod1 + " Period 2: " + userObject[i].AwayTeamScorePeriod2;

                    div.Controls.Add(time);
                    div.Controls.Add(updatedTime);
                    div.Controls.Add(season);
                    div.Controls.Add(home);
                    div.Controls.Add(homeScore);
                    div.Controls.Add(away);
                    div.Controls.Add(awayScore);

                    div.Attributes.Add("style", "width:350px;background:lightblue;");

                    soccerGamesDiv.Controls.Add(div);
                }
            }
            catch (Exception ex)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                HtmlGenericControl warning = new HtmlGenericControl("p");
                HtmlGenericControl error = new HtmlGenericControl("p");

                warning.InnerText = "Invalid Date Format! Or No Games Found. Please Try Again.";
                error.InnerText = "ERROR: " + ex.Message;
                
                div.Controls.Add(warning);
                div.Controls.Add(error);
                
                soccerGamesDiv.Controls.Add(div);
            }
        }
    }
}