<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Escaping.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBoxInput" runat="server" PlaceHolder="Enter text" />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        <br />
        <br />
        <asp:TextBox ID="TextBoxResult" runat="server" PlaceHolder="Your text goes here" />
        <asp:Label ID="LabelResult" runat="server"  Text="" />
    </div>
    </form>
</body>
</html>
