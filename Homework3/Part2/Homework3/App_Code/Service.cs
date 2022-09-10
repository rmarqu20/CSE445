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

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
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
}
