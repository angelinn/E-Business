<%@ Page Title="" Language="C#" MasterPageFile="~/VacationReservationsPage.Master" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="VacationReservations.CustomerDetails" %>

<%@ Register TagPrefix="uc1" TagName="CustomerDetailsEdit" Src="UserControls/CustomerDetailsEdit.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <span class="CatalogTitle">Редакция на профила</span>
    </h1>
    <uc1:CustomerDetailsEdit ID="CustomerDetailsEdit1" runat="server" />
</asp:Content>
