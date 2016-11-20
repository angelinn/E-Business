<%@ Page Title="" Language="C#" MasterPageFile="~/VacationReservationsPage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="VacationReservations.Search" %>
<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblFirst" CssClass="CatalogTitle" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblSecond" CssClass="CatalogDescription" runat="server"></asp:Label>
    <br />
    <uc1:ProductsList ID="list" runat="server" />
</asp:Content>
