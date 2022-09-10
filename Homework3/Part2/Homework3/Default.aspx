<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 96px;
            width: 368px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="News Articles TryIt Page"></asp:Label>
            <br />
            <br />
            Methods:<br />
            - public newsInformation NewsFocus(string topic)<br />
            This method gets the news based on the topic passed through the argument.<br />
            - Service Extension: /news/topic={topic}<br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter Article Topic Here:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Output:"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="[OutputText]"></asp:Label>
        </div>
    </form>
</body>
</html>
