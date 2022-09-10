<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WCFWeatherServiceWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Weather Forecast TryIt Page"></asp:Label>
            <br />
            TryIt URL: <a href="http://webstrar41.fulton.asu.edu/page2/">http://webstrar41.fulton.asu.edu/page2/</a><br />
            Service URL: <a href="http://webstrar41.fulton.asu.edu/page2/Service1.svc/weather/zipcode=Tempe">http://webstrar41.fulton.asu.edu/page2/Service1.svc/weather/zipcode={zipcode</a>}<br />
            Methods:<br />
            - public weatherInformation WeatherService(string zipcode)<br />
            This method returns the hourly forecast for today&#39;s date.<br />
            - Service Extension: /weather/zipcode={zipcode}<br />
            - public astro AstroService(string zipcode)<br />
            This method returns the only the astrological data for today&#39;s date. Such as sunrise and sunset times etc.<br />
            - Service Extension: /weather/astro/zipcode={zipcode}<br />
            - public day[] DayService(int days, string zipcode)<br />
            This method returns a list of day structures that contain the daily forecast for 1-3 days ahead of time.
            <br />
            - Service Extension: /weather/days={days}/zipcode={zipcode}<br />
            - public location LocationService(string zipcode)<br />
            This method returns only the location data for the zip code provided.<br />
            - Service Extension: /location/zipcode={zipcode}<br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter Zipcode/City Name:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Output:"></asp:Label>
            <asp:Label ID="Label10" runat="server" Text="[ErrorLabel]" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Location:"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="[LocationLabel]" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Current Temperature:"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="[TemperatureLabel]" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Current Condition:"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="[ConditionLabel]" Visible="False"></asp:Label>
        </div>
    </form>
    <div id="hourlyDiv" runat="server">
    </div>
</body>
</html>
