<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NamePrinter.aspx.cs" Inherits="Homework.NamePrinterWebFormsClient.NamePrinter" %>

<%@ Register Src="~/CustomControls/NamePrinterUserControl.ascx" TagName="printer" TagPrefix="np" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="namePrinterForm" runat="server">
    <div>
        <np:printer runat="server" />
    </div>
    </form>
</body>
</html>
