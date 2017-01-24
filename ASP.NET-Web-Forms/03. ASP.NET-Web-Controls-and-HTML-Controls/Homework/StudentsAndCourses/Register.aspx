<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudentsAndCourses.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="registerForm" runat="server">
    <div id="register">
        <asp:TextBox ID="TextBoxFirstName" runat="server" PlaceHolder="First name" />
        <asp:TextBox ID="TextBoxLastName" runat="server" PlaceHolder="Last name" />
        <asp:TextBox ID="TextBoxFacultyNumber" runat="server" PlaceHolder="Faculty number"/>
        <asp:DropDownList ID="DropDownListUniversity" runat="server">
            <asp:ListItem Text="SU" />
            <asp:ListItem Text="TU" />
            <asp:ListItem Text="UNIBIT" />
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListSpecialty" runat="server">
            <asp:ListItem Text="CS" />
            <asp:ListItem Text="IT" />
        </asp:DropDownList>
        <asp:ListBox ID="ListBoxCourses" runat="server" SelectionMode="Multiple">
            <asp:ListItem Text="Math" />
            <asp:ListItem Text="CSharp" />
            <asp:ListItem Text="DSA" />
        </asp:ListBox>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click"/>
    </div>
    <hr />
    <div id="registerInfo" runat="server"></div>
    </form>
</body>
</html>
