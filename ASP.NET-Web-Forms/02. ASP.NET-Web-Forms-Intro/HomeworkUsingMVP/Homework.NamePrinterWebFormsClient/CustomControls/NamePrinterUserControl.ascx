<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NamePrinterUserControl.ascx.cs" Inherits="Homework.NamePrinterWebFormsClient.CustomControls.NamePrinterUserControl" %>

<asp:Label runat="server" Text="Enter your name:" />
<asp:TextBox ID="TextBoxName" runat="server" />
<br />
<asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
<br />
<asp:Label ID="LabelName" runat="server" Text="<%#: this.Model.Message %>"/>