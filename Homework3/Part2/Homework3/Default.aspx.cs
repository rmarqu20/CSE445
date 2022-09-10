using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    //protected string hostURL = "http://localhost:49857";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label3.Text = "TEST";
        //REST News Service
        string url = "http://localhost:49857/Service.svc/news/topic=" + TextBox1.Text;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();

        newsInformation userObject = JsonConvert.DeserializeObject<newsInformation>(responsereader);
        if(userObject.articles.Count != 0)
        {
            Label4.Text = "Title: " + userObject.articles[0].title + " URL: " + userObject.articles[0].url;
        }
        else
        {
            Label4.Text = "No articles found.";
        }
    }
}