using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
//using System.Web.Script.Serialization;
using System.Net.Http;
using Newtonsoft.Json;

internal class Program
{
    static void Main(string[] args)
    {
        string url = @"https://newsapi.org/v1/articles?source=techcrunch&apiKey=1cf43045af994c18b75a363b6d639d1c";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();

        //Console.WriteLine(responsereader);

        string json = @"{
            'articles': [
            {
                'author':'Connie Loizos',
                'title':'Lee Fixel is...', 
                'description':'Lee Fixel...',
                'url':'https://techcrunch.com...',
                'urlToImage':'https://...png',
                'publishedAt':'2019-03-15T01:10:52Z'}]
            }";

        newsInformation userObject = JsonConvert.DeserializeObject<newsInformation>(responsereader);
        for (int i = 0; i < userObject.articles.Count; i++)
        {
            Console.WriteLine("Title: " + userObject.articles[i].title);
            Console.WriteLine("Author: " + userObject.articles[i].author);
            Console.WriteLine("URL: " + userObject.articles[i].url + "\n");
        }
    }

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
}