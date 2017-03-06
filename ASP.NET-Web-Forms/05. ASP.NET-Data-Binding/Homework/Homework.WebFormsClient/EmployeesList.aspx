<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesList.aspx.cs" Inherits="Homework.WebFormsClient.EmployeesList" %>

<%@ Register Src="~/UserControls/EmployeesUserControl.ascx" TagPrefix="homework" TagName="employeesGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <homework:employeesGridView runat="server" />
    </form>
</body>
</html>
