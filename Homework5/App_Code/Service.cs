using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public class Service : IService
{
	//public string apiKey = "1cf43045af994c18b75a363b6d639d1c";
	public newsInformation NewsFocus(string topic)
	{
		string url = @"https://newsapi.org/v2/everything?q=" + topic + "&apiKey=1cf43045af994c18b75a363b6d639d1c";
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();
		response.Close();
		newsInformation userObject = JsonConvert.DeserializeObject<newsInformation>(responsereader);
		return userObject;
	}

    //Weather
    public string APIKey = "f0751b33fdc54438aba230635220404";
    public weatherInformation WeatherService(string zipcode)
    {
        string url = @"http://api.weatherapi.com/v1/forecast.json?key=" + APIKey + "&q=" + zipcode + "&days=1&aqi=no&alerts=no";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        weatherInformation userObject = JsonConvert.DeserializeObject<weatherInformation>(responsereader);
        return userObject;
    }

    public astro AstroService(string zipcode)
    {
        string url = @"http://api.weatherapi.com/v1/forecast.json?key=" + APIKey + "&q=" + zipcode + "&days=1&aqi=no&alerts=no";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        weatherInformation userObject = JsonConvert.DeserializeObject<weatherInformation>(responsereader);
        astro weatherAstro = userObject.forecast.forecastday[0].astro;
        return weatherAstro;
    }

    public day[] DayService(string days, string zipcode)
    {
        string url = @"http://api.weatherapi.com/v1/forecast.json?key=" + APIKey + "&q=" + zipcode + "&days=" + days + "&aqi=no&alerts=no";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        weatherInformation userObject = JsonConvert.DeserializeObject<weatherInformation>(responsereader);
        int dayNum = Int32.Parse(days);
        day[] dayList = new day[dayNum];
        for (int i = 0; i < dayNum; i++)
        {
            dayList[i] = userObject.forecast.forecastday[i].day;

        }
        return dayList;
    }

    public location LocationService(string zipcode)
    {
        string url = @"http://api.weatherapi.com/v1/forecast.json?key=" + APIKey + "&q=" + zipcode + "&days=1&aqi=no&alerts=no";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        weatherInformation userObject = JsonConvert.DeserializeObject<weatherInformation>(responsereader);
        location zipLocation = userObject.location;
        return zipLocation;
    }

    //Sports
    public string APIKeySoccer = "8530a922b17247e3be23532d5344dc59";
    public string APIKeyNBA = "48e645fba10947dc8240d280b19c3955";
    public List<SoccerGames> SoccerService(string date)
    {
        string sport = "soccer";

        if (date == "")
        {
            date = DateTime.Now.ToString("yyyy-MM-dd");
        }

        string url = @"https://api.sportsdata.io/v3/" + sport + "/scores/json/GamesByDate/" + date + "?key=" + APIKeySoccer;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        List<SoccerGames> userObject = JsonConvert.DeserializeObject<List<SoccerGames>>(responsereader);
        return userObject;
    }

    public List<NBAGames> NBAService(string date)
    {
        string sport = "nba";

        if (date == "")
        {
            date = DateTime.Now.ToString("yyyy-MMM-dd");
        }

        string url = @"https://api.sportsdata.io/v3/" + sport + "/scores/json/GamesByDate/" + date + "?key=" + APIKeyNBA;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        List<NBAGames> userObject = JsonConvert.DeserializeObject<List<NBAGames>>(responsereader);
        return userObject;
    }
}
