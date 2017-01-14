<%@ Page Title="" Language="C#" MasterPageFile="~/VacationReservationsPage.Master" AutoEventWireup="true" CodeBehind="StringEncryptorTester.aspx.cs" Inherits="VacationReservations.StringEncryptorTester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Enter data to encrypt:
 <br />
    <asp:TextBox ID="encryptBox" runat="server" />
    <br />
    Enter data to decrypt:
 <br />
    <asp:TextBox ID="decryptBox" runat="server" />
    <br />
    <asp:Button ID="processButton" runat="server" Text="Process" OnClick="processButton_Click" />
    <br />
    <asp:Label ID="result" runat="server" />
</asp:Content>
