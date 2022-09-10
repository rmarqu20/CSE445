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

namespace WCFSportsServiceWebApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string APIKeySoccer = "8530a922b17247e3be23532d5344dc59";
        public string APIKeyNBA = "48e645fba10947dc8240d280b19c3955";
        public List<SoccerGames> SoccerService(string date)
        {
            string sport = "soccer";

            if(date == "")
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
}
