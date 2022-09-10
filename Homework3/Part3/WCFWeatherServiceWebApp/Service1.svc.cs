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

namespace WCFWeatherServiceWebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string APIKey = "f0751b33fdc54438aba230635220404";
        public weatherInformation WeatherService(string zipcode)
        {
            string url = @"http://api.weatherapi.com/v1/forecast.json?key="+ APIKey + "&q=" + zipcode + "&days=1&aqi=no&alerts=no";
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
            for(int i = 0; i < dayNum; i++)
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
    }
}
