<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Part1WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <strong>Encryption Service</strong><br />
        Please Enter the String to Encrypt:<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="302px">Enter String Here</asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button2_Click" Text="Encrypt Now" />
        <br />
        <br />
        Encrypted String: <asp:Label ID="hiddenEncryptedLabel" runat="server" Text="[Message]" Visible="False"></asp:Label>
        <br />
        <br />
        <strong>Decryption Service</strong><br />
        <asp:Label ID="topLabel0" runat="server" Text="String to be Decrypted:"></asp:Label>
        <br />
        <asp:Label ID="resultLabel2" runat="server" Text="Y4zUv6ZkJx1f2TSSi4eB58GdswQf/a04" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button6_Click" Text="Decrypt Now" />
        <br />
        <br />
        Decrypted String: <asp:Label ID="hiddenEncryptedLabel2" runat="server" Text="[Message]" Visible="False"></asp:Label>
        <br />
        <br />
        <strong>Image Verification Service</strong><br />
        <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="300px" />
        <br />
        Image String Length:&nbsp; <asp:TextBox ID="TextBox3" runat="server">4</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Show Me Another String Image!" />
        <br />
        <br />
        Please Enter The String Here:&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Submit" />
        <br />
        <asp:Label ID="resultLabel" runat="server" Text="[Message]" Visible="False"></asp:Label>
        <br />
    </form>
</body>
</html>
