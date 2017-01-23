<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NamePrinter.aspx.cs" Inherits="PrintName.NamePrinter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formPrintName" runat="server">
    <div>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
    </div>
    <div>
        <asp:Label ID="LabelName" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
