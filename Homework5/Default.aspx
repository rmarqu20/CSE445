<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ OutputCache Duration="20" VaryByParam="*" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #container{
            width:900px;
            margin:0 auto;
        }
        .col1{
            .width:400px;
            float:left;
            margin:25px;
        }
        .col2{
            .width:400px;
            float:right;
            margin:25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="container">
                <h2 class="heading"> Latest News </h2>
                Enter Article Topic Here:
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Articles" />
                <br />
                <div id="articlesDiv" runat="server"></div>
                <br />
                <hr />
            </div>
            <div id="container">
                <div class="col1">
                    <h2 class="heading"> Today's Weather</h2>
                    Location:
                    <asp:Label ID="Label1" runat="server" Text="[LocationLabel]" Visible="False"></asp:Label>
                    <br />
                    Current Temperature:
                    <asp:Label ID="Label2" runat="server" Text="[TemperatureLabel]" Visible="False"></asp:Label>
                    <br />
                    Current Condition:
                    <asp:Label ID="Label3" runat="server" Text="[ConditionLabel]" Visible="False"></asp:Label>
                    <br />
                    <div id="hourlyDiv" runat="server"></div>
                </div>
                <div class="col2">
                    <h2 class="heading"> Today's Soccer Games </h2>
                    <div id="soccerGamesDiv" runat="server"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
