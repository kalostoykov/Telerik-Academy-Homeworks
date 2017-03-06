<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="Homework.WebFormsClient.Cars" %>

<%@ Register Src="~/UserControls/CarsUserControl.ascx" TagPrefix="homework" TagName="carsForm" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <homework:carsForm runat="server"/>
    </div>
    </form>
</body>
</html>
