<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generator.aspx.cs" Inherits="RandomGeneratorHtmlControls.Generator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="InputMin">Min: </label>
            <input id="InputMin" runat="server" type="number" />
        </div>
        <div>
            <label for="InputMin">Max: </label>
            <input id="InputMax" runat="server" type="number"/>
        </div>
        <div>
            <button type="submit" id="ButtonGenerate" runat="server" onserverclick="ButtonGenerateClick">Generate number</button>
        </div>
        <div>
            <label for="result">Generated Number: </label>
            <strong id="result" runat="server" />
        </div>
    </form>
</body>
</html>
