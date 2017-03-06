<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Homework.WebFormsClient.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a id="ButtonBack" runat="server" href="/EmployeesList.aspx">Back</a>
    </div>
    <div>
        <asp:DetailsView ID="EmployeeDetailsView" runat="server" />
    </div>
    </form>
</body>
</html>
