<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VacationReservations.Default" MasterPageFile="~/VacationReservationsPage.Master" Title="Резервации за почивка" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<script runat="server">
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">
    <h1>
        <span class="CatalogTitle">Добре дошли в Екскурзии в България!</span>
    </h1>
    <h2>
        <span class="CatalogDescription">Промоциални оферти</span>
    </h2>
    <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>
