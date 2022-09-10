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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        weatherService();
        sportsService();
        HttpCookie cookie = Request.Cookies["myNewsCookie"];
        if (cookie != null && TextBox1.Text == "")
        {
            TextBox1.Text = cookie["news"];
        }
        /*HttpCookie cookie2 = Request.Cookies["myWeatherCookie"];
        if (cookie2 != null && TextBox2.Text == "")
        {
            TextBox2.Text = cookie2["weather"];
        }
        HttpCookie cookie3 = Request.Cookies["mySportsCookie"];
        if (cookie3 != null && TextBox3.Text == "")
        {
            TextBox3.Text = cookie3["sports"];
        }*/
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("myNewsCookie");
        cookie["news"] = TextBox1.Text;
        cookie.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Add(cookie);
        //REST News Service
        string host = "http://localhost:53166"; //string host = "http://webstrar41.fulton.asu.edu/page1/";
        string url = host + "/Service.svc/news/topic=" + TextBox1.Text;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();

            newsInformation userObject = JsonConvert.DeserializeObject<newsInformation>(responsereader);
            int count = userObject.articles.Count;
            if (count == 0)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                HtmlGenericControl warning = new HtmlGenericControl("p");

                warning.InnerText = "No Articles Found! Please Try Again.";

                div.Controls.Add(warning);

                articlesDiv.Controls.Add(div);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    HtmlGenericControl image = new HtmlGenericControl("img");
                    HtmlGenericControl href = new HtmlGenericControl("a");
                    HtmlGenericControl urlLink = new HtmlGenericControl("p");
                    HtmlGenericControl date = new HtmlGenericControl("p");
                    HtmlGenericControl author = new HtmlGenericControl("p");

                    image.Attributes.Add("src", userObject.articles[i].urlToImage);
                    image.Attributes.Add("style", "float:left;width:150px;height:100px;");

                    href.InnerText = userObject.articles[i].title;
                    href.Attributes.Add("href", userObject.articles[i].url);
                    urlLink.Controls.Add(href);

                    date.InnerText = "Date Published: " + userObject.articles[i].publishedAt;
                    author.InnerText = "Author: " + userObject.articles[i].author;

                    div.Controls.Add(image);
                    div.Controls.Add(urlLink);
                    div.Controls.Add(date);
                    div.Controls.Add(author);
                    div.Attributes.Add("style", "width:900px;height:100px;background:lightblue;");

                    articlesDiv.Controls.Add(div);
                }
            }
        }
        catch (Exception ex)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            HtmlGenericControl warning = new HtmlGenericControl("p");
            HtmlGenericControl error = new HtmlGenericControl("p");

            warning.InnerText = "No Articles Found! Please Try Again.";
            error.InnerText = "ERROR: " + ex.Message;

            div.Controls.Add(warning);
            div.Controls.Add(error);

            articlesDiv.Controls.Add(div);
        }
    }

    protected void weatherService()
    {
        /*HttpCookie cookie2 = new HttpCookie("myWeatherCookie");
        cookie2["weather"] = TextBox1.Text;
        cookie2.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Add(cookie2);*/

        //REST Weather Service
        string host = "http://localhost:53166"; //string host = "http://webstrar41.fulton.asu.edu/page2/";
        string url = host + "/Service.svc/weather/zipcode=" + "Tempe"; //Tempe default
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();

            weatherInformation userObject = JsonConvert.DeserializeObject<weatherInformation>(responsereader);
            if (userObject.location.region != "")
            {
                Label1.Text = userObject.location.name + ", " + userObject.location.region + ", " + userObject.location.country;
                Label1.Visible = true;
            }
            //locations without regions/states
            else
            {
                Label1.Text = userObject.location.name + ", " + userObject.location.country;
                Label1.Visible = true;
            }
            Label2.Text = userObject.current.temp_c + "℃ " + userObject.current.temp_f + "℉ ";
            Label2.Visible = true;
            Label3.Text = userObject.current.condition.text;
            Label3.Visible = true;

            //hourly forecast
            int count = userObject.forecast.forecastday[0].hour.Count();
            for (int i = 0; i < count; i++)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                HtmlGenericControl image = new HtmlGenericControl("img");
                HtmlGenericControl time = new HtmlGenericControl("p");
                HtmlGenericControl temp = new HtmlGenericControl("p");
                HtmlGenericControl condition = new HtmlGenericControl("p");

                time.InnerText = "Time:" + userObject.forecast.forecastday[0].hour[i].time;
                temp.InnerText = "Temp: " + userObject.forecast.forecastday[0].hour[i].temp_c.ToString() + "℃ " + userObject.forecast.forecastday[0].hour[i].temp_f.ToString() + "℉";
                condition.InnerText = "Condition: " + userObject.forecast.forecastday[0].hour[i].condition.text;

                image.Attributes.Add("src", userObject.forecast.forecastday[0].hour[i].condition.icon);
                image.Attributes.Add("style", "float:right;width:90px;height:90px;");

                div.Controls.Add(image);
                div.Controls.Add(time);
                div.Controls.Add(temp);
                div.Controls.Add(condition);

                div.Attributes.Add("style", "width:350px;background:lightblue;");

                hourlyDiv.Controls.Add(div);
            }
        }
        catch (Exception ex)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            HtmlGenericControl warning = new HtmlGenericControl("p");
            HtmlGenericControl error = new HtmlGenericControl("p");

            warning.InnerText = "Invalid Zip Code Or City! Please Try Again.";
            error.InnerText = "ERROR: " + ex.Message;

            div.Controls.Add(warning);
            div.Controls.Add(error);

            hourlyDiv.Controls.Add(div);

            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
        }
    }

    protected void sportsService()
    {
        /*HttpCookie cookie3 = new HttpCookie("mySportsCookie");
        cookie3["sports"] = TextBox3.Text;
        cookie3.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Add(cookie3);
        string date = TextBox3.Text;
        if (date == "")
        {
            date = DateTime.Now.ToString("yyyy-MM-dd");
        }*/

        //REST Sports Service
        String date = DateTime.Now.ToString("yyyy-MM-dd");
        string host = "http://localhost:53166"; //string host = "http://webstrar41.fulton.asu.edu/page3/";
        string url = host + "/Service.svc/soccer/date=" + date;
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
                        if (userObject[i].Week == null)
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