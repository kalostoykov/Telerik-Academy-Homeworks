<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeesUserControl.ascx.cs" Inherits="Homework.WebFormsClient.UserControls.EmployeesUserControl" %>

<asp:GridView ID="EmployeesGridView" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="FullName" HeaderText="Full name" />
        <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/EmployeeDetails.aspx?id={0}" />
    </Columns>
</asp:GridView>