<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarsUserControl.ascx.cs" Inherits="Homework.WebFormsClient.UserControls.CarsUserControl" %>

<div>
    <asp:DropDownList ID="DropDownListProducers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProducers_SelectedIndexChanged"/>
    <asp:DropDownList ID="DropDownListModels" runat="server" />
    <asp:CheckBoxList ID="CheckBoxListExtras" runat="server" />
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
</div>

<div>
    <asp:DetailsView ID="DetailsViewCreatedCar" runat="server" />
    <asp:GridView ID="GridViewCreatedCar" runat="server" />
</div>