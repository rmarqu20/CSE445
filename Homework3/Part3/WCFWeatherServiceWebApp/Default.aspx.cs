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

namespace WCFWeatherServiceWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //REST Weather Service
            string host = "http://webstrar41.fulton.asu.edu/page2/"; //Old: http://localhost:50121
            string url = host + "/Service1.svc/weather/zipcode=" + TextBox1.Text;
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
                    Label5.Text = userObject.location.name + ", " + userObject.location.region + ", " + userObject.location.country;
                    Label5.Visible = true;
                }
                //locations without regions/states
                else
                {
                    Label5.Text = userObject.location.name + ", " + userObject.location.country;
                    Label5.Visible = true;
                }
                Label7.Text = userObject.current.temp_c + "℃ " + userObject.current.temp_f + "℉ ";
                Label7.Visible = true;
                Label9.Text = userObject.current.condition.text;
                Label9.Visible = true;

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

                Label5.Text = "";
                Label7.Text = "";
                Label9.Text = "";
            }
        }
    }
}