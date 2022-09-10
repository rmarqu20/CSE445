<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework3Part4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" GridLines="Both" Width="1500px">
                <asp:TableRow BackColor="#daeef3"><asp:TableCell ColumnSpan="4" Font-Bold="true" HorizontalAlign="Center">Services Directory</asp:TableCell></asp:TableRow>
                <asp:TableRow BackColor="#daeef3"><asp:TableCell ColumnSpan="4">This project is developed by: Richard Marquez Cortes</asp:TableCell></asp:TableRow>
                <asp:TableRow BackColor="#daeef3">
                    <asp:TableCell>Service name</asp:TableCell>
                    <asp:TableCell>TryIt link</asp:TableCell>
                    <asp:TableCell>Service description</asp:TableCell>
                    <asp:TableCell>APIs/Web Service Methods</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>NewsFocus <br/>Input: string <br/>Output: JSON</asp:TableCell>
                    <asp:TableCell><a href="http://webstrar41.fulton.asu.edu/page1/">Try It</a></asp:TableCell>
                    <asp:TableCell>This service searches for news articles based on a topic entered by the user. The user can also check the status of the API using the NewsStatus method.</asp:TableCell>
                    <asp:TableCell>public newsInformation NewsFocus(string topic), public string NewsStatus()</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>WeatherService <br/>Input: string <br/>Output: JSON</asp:TableCell>
                    <asp:TableCell><a href="http://webstrar41.fulton.asu.edu/page2/">Try It</a></asp:TableCell>
                    <asp:TableCell>This service returns the hourly forecast for today's date at the zipcode or city entered by the user. The user can also recieve the astrological data using the AstroService method. 
                        There is also an option to get the daily forecast for the next 1-3 days using the DayService method. As a bonus, the user can recieve location data for the zip code provided using the LocationService method.</asp:TableCell>
                    <asp:TableCell>public weatherInformation WeatherService(string zipcode), public astro AstroService(string zipcode), public day[] DayService(int days, string zipcode), public location LocationService(string zipcode)</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>SportsService <br/>Input: string <br/>Output: JSON</asp:TableCell>
                    <asp:TableCell><a href="http://webstrar41.fulton.asu.edu/page3/">Try It</a></asp:TableCell>
                    <asp:TableCell>This service returns a list of soccer games happening at a specific date or today if the textbox is left blank as a default option. The user can also recieve NBA basketball games happening at a specific date or today using the NBAService method.</asp:TableCell>
                    <asp:TableCell>public List<SoccerGames> SoccerService(string date), public List<NBAGames> NBAService(string date)</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
