<%@ Page Title="" Language="C#" MasterPageFile="~/VacationReservationsPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="VacationReservations.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="titleLabel" runat="server" Text="Your Shopping Cart" CssClass="CatalogTitle" />
    </p>
    <p>
        <asp:Label ID="statusLabel" runat="server" />
    </p>
    <asp:GridView ID="grid" runat="server" OnRowDeleting="grid_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Product Name" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" />
            <asp:BoundField DataField="Attributes" HeaderText="Attributes" ReadOnly="True" SortExpression="Attributes" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow" Width="24px"
                        MaxLength="2" Text='<%#Eval("Quantity")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" ShowHeader="True" Text="Delete" />
        </Columns>
    </asp:GridView>
    <p align="right">
        <span>Total amount: </span>
        <asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
    </p>
    <p align="right">
        <asp:Button ID="updateButton" runat="server" Text="Update Quantities" />
    </p>
    <p align="right">
        <asp:Button ID="Button1" runat="server" Text="Update Quantities"
            OnClick="updateButton_Click" />
        <asp:Button ID="checkoutButton" runat="server"
            Text="Proceed to Checkout" />
    </p>
</asp:Content>
