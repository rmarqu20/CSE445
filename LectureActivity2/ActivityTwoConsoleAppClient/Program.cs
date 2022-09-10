using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ActivityTwoConsoleAppClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ServiceReference1.Service1Client myClient = new ServiceReference1.Service1Client();
            Console.WriteLine("Welcome To Web Service Demo\nSelect the method you need to invoke\n1. Sum of Digits\n2. Vowel Count\n3. Exit\nEnter Your Option: ");
            string option = Console.ReadLine();
            if(option == "1")
            {
                Console.WriteLine("Please enter any number: ");
                string num = Console.ReadLine();
                Console.WriteLine("Digit Sum: " + myClient.getSum(Int32.Parse(num)));
            }
            else if (option == "2")
            {
                Console.WriteLine("Please enter any word: ");
                string word = Console.ReadLine();
                Console.WriteLine("Vowel Count: " + myClient.getVowels(word));
            }
            else
            {
                Console.WriteLine("Not an option. Goodbye!");
            }
            */
            string APIKeySoccer = "8530a922b17247e3be23532d5344dc59";
            string sport = "soccer"; //hardcoded 
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine(date);
            //string url = @"https://newsapi.org/v2/everything?q=" + zipcode + "&apiKey=1cf43045af994c18b75a363b6d639d1c";
            //string url = @"http://api.weatherapi.com/v1/forecast.json?key=" + APIKey + "&q=" + zipcode + "&days=1&aqi=no&alerts=no";
            string url = @"https://api.sportsdata.io/v3/" + sport + "/scores/json/GamesByDate/" + date + "?key=" + APIKeySoccer;
            Console.WriteLine(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            Console.WriteLine(responsereader);
            response.Close();
        }
    }
}
