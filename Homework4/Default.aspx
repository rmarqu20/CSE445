<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            XML Verification Service<br />
            XML URL:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            XMLS/XSD URL:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Verify" />
            <br />
            Validation:
            <asp:Label ID="validationLabel" runat="server" Text="[validationLabel]" Visible="False"></asp:Label>
            <br />
            <br />
            XPath Search Service<br />
            XML URL:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            XPath Expression:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <br />
            Path Value:
            <asp:Label ID="pathValueLabel" runat="server" Text="[pathValueLabel]" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
