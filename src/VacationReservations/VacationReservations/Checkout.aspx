<%@ Page Title="" Language="C#" MasterPageFile="~/VacationReservationsPage.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="VacationReservations.Checkout" %>

<%@ Register TagPrefix="uc1" TagName="CustomerDetailsEdit" Src="UserControls/CustomerDetailsEdit.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="titleLabel" runat="server"
        CssClass="CatalogTitle" Text="Потвърждаване на поръчка" />
    <br />
    <br />
    <asp:GridView ID="grid" runat="server" Width="100%"
        AutoGenerateColumns="False" DataKeyNames="ProductID"
        BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Продукт"
                ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Price" DataFormatString="{0:c}"
                HeaderText="Цена" ReadOnly="True"
                SortExpression="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Количество"
                ReadOnly="True" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label2" runat="server" Text="Общо: "
        CssClass="ProductDescription" />
    <asp:Label ID="totalAmountLabel" runat="server" Text="Label"
        CssClass="ProductPrice" />
    <br />
    <br />
    <uc1:CustomerDetailsEdit ID="CustomerDetailsEdit1"
        runat="server" Editable="false" title="User Details" />
    <br />
    <asp:Label ID="InfoLabel" runat="server" />
    <br />
    <br />
    Изберете доставка:
 <asp:DropDownList ID="shippingSelection" runat="server" />
    <br />
    <br />
    <asp:Button ID="placeOrderButton" runat="server"
        Text="Направи поръчка" OnClick="placeOrderButton_Click" />
</asp:Content>
