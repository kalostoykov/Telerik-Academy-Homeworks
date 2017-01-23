<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generator.aspx.cs" Inherits="RandomGeneratorWebControls.Generator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="TextBoxMax">Min: </label>
            <asp:TextBox ID="TextBoxMin" runat="server" type="number" />
        </div>
        <div>
            <label for="TextBoxMax">Max: </label>
            <asp:TextBox ID="TextBoxMax" runat="server" type="number" />
        </div>
        <div>
            <asp:Button type="submit" ID="ButtonGenerate" runat="server" Text="Generate Number" OnClick="ButtonGenerate_Click" />
        </div>
        <div>
            <label for="LabelResult">Generated Number: </label>
            <asp:Label id="LabelResult" runat="server" />
        </div>
    </form>
</body>
</html>
