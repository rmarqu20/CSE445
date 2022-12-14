using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
	[OperationContract]
	[WebGet(UriTemplate = "news/topic={topic}", ResponseFormat = WebMessageFormat.Json)]
	newsInformation NewsFocus(String topic);
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

