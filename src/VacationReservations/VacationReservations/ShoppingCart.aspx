<%@ Page Title="" Language="C#" MasterPageFile="~/VacationReservationsPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="VacationReservations.ShoppingCart" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="titleLabel" runat="server" Text="Вашата количка" CssClass="CatalogTitle" />
    </p>
    <p>
        <asp:Label ID="statusLabel" runat="server" />
    </p>
    <asp:GridView ID="grid" runat="server" OnRowDeleting="grid_RowDeleting" DataKeyNames="ProductID" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Продукт" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="Цена" ReadOnly="True" SortExpression="Price" DataFormatString="{0:c}" />
            <asp:BoundField DataField="Attributes" HeaderText="Атрибути" ReadOnly="True" SortExpression="Attributes" />
            <asp:TemplateField HeaderText="Количество">
                <ItemTemplate>
                    <asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow" Width="24px"
                        MaxLength="2" Text='<%#Eval("Quantity")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" ShowHeader="True" Text="Изтрий" />
        </Columns>
    </asp:GridView>
    <p align="right">
        <span>Общо: </span>
        <asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
    </p>
    <p align="right">
        <asp:Button ID="updateButton" runat="server" Text="Обнови количествата"
            OnClick="updateButton_Click" />
        <asp:Button ID="checkoutButton" runat="server"
            Text="Потвърди покупката" />
    </p>
    <uc1:ProductRecommendations ID="recommendations" runat="server" />
</asp:Content>
