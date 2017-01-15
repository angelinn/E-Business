<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="OrderTest.aspx.cs" Inherits="VacationReservations.OrderTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <span class="AdminTitle">Тест на поръчки</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="server">
    Поръчка номер:
 <asp:TextBox runat="server" ID="orderIDBox" />
    <br />
    <asp:Button runat="server" ID="goButton" Text="Напред" OnClick="goButton_Click" />
    <br />
    <br />
    <asp:Label runat="server" ID="resultLabel" />
    <br />
    <br />
    <strong>Адрес:</strong>
    <br />
    <asp:Label runat="server" ID="addressLabel" />
    <br />
    <br />
    <strong>Дебитна карта:</strong>
    <br />
    <asp:Label runat="server" ID="creditCardLabel" />
    <br />
    <br />
    <strong>Детайли на поръчка:</strong>
    <br />
    <asp:Label runat="server" ID="orderLabel" />
</asp:Content>
