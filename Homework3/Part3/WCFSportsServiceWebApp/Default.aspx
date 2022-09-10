<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WCFSportsServiceWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Sports TryIt Page"></asp:Label>
            <br />
            TryIt URL: <a href="http://webstrar41.fulton.asu.edu/page3/">http://webstrar41.fulton.asu.edu/page3/</a><br />
            Service URL: <a href="http://webstrar41.fulton.asu.edu/page3/Service1.svc/soccer/date=2022-04-05">http://webstrar41.fulton.asu.edu/page3/Service1.svc/soccer/date={date</a>}<br />
            Methods:<br />
            - public List<SoccerGames>&lt;SoccerGames&gt; SoccerService(string date)<br />
            This method returns a list of soccer events happening a specific date or today if the textbox is left blank.<br />
            - Service Extension: /soccer/date={date}<br />
            - List<NBAGames>&lt;NBAGames&gt; NBAService(string date)<br />
            This method returns a list of NBA basketball events happening a specific date or today if the textbox is left blank.<br />
            - Service Extension: /nba/date={date}<br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Date Format (YYYY-MM-DD)"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Leave Blank for Today's Events"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Search Date: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Soccer Events Happening Today:"></asp:Label>
            <br />
        </div>
    </form>
    <div id="soccerGamesDiv" runat="server">
    </div>
</body>
</html>
