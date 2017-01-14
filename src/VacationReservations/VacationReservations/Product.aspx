<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="VacationReservations.Product" MasterPageFile="~/VacationReservationsPage.Master" Title="Резервации за почивка: Продукти" %>

<%@ Register Src="UserControls/ProductRecommendations.ascx" TagName="ProductRecommendations" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server"
            Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Image ID="productImage" runat="server" />
    </p>
    <p>
        <asp:Label ID="descriptionLabel" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <b>Price:</b>
        <asp:Label CssClass="ProductPrice" ID="priceLabel" runat="server"
            Text="Label"></asp:Label>
    </p>
    <p>
        <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
    </p>
    <p>
        <asp:LinkButton ID="AddToCartButton" runat="server"
            OnClick="AddToCartButton_Click">Добави в количка</asp:LinkButton>
    </p>
    <p>
        <uc1:ProductRecommendations ID="recommendations" runat="server" />
    </p>
</asp:Content>
