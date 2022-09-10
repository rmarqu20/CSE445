using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string url = @"http://localhost:57279/Service.svc/verify?xml=" + TextBox1.Text +"&xmls=" + TextBox2.Text;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        string validationStr = JsonConvert.DeserializeObject<string>(responsereader);
        validationLabel.Text = validationStr;
        validationLabel.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string url = @"http://localhost:57279/Service.svc/xpath?xml=" + TextBox3.Text + "&exp=" + TextBox4.Text;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader sreader = new StreamReader(dataStream);
        string responsereader = sreader.ReadToEnd();
        response.Close();
        string pathValue = JsonConvert.DeserializeObject<string>(responsereader);
        pathValueLabel.Text = pathValue;
        pathValueLabel.Visible = true;
    }
}