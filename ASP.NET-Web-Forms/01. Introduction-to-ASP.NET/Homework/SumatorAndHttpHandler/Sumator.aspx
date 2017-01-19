<%@ Page Title="Sumator" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="SumatorAndHttpHandler.Sumator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ultimate Sumator</h1>
    <div class="input-container">
        <asp:Label runat="server" AssociatedControlID="TextBoxFirstNum" Text="First number:" />
        <asp:TextBox ID="TextBoxFirstNum" class="form-control" runat="server"></asp:TextBox>
    </div>
    <br />
    <div class="input-container">
        <asp:Label runat="server" AssociatedControlID="TextBoxSecondNum" Text="Second number:" />
        <asp:TextBox ID="TextBoxSecondNum" class="form-control" runat="server"></asp:TextBox>
    </div>
    <br />
    <div class="btn-group">
        <asp:Button ID="ButtonCalculateSum" class="btn btn-default" runat="server" Text="Calculate" OnClick="ButtonCalculateSum_Click" />
    </div>
    <br />
    <br />
    <div class="input-container">
        <asp:Label runat="server" AssociatedControlID="TextBoxSum" Text="The sum is:" />
        <asp:TextBox ID="TextBoxSum" class="form-control" runat="server"></asp:TextBox>
    </div>
</asp:Content>

