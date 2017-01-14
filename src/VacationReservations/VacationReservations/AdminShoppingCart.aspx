<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AdminShoppingCart.aspx.cs" Inherits="VacationReservations.AdminShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <span class="AdminTitle">Админ зона
 <br />
        Колички
    </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="server">
    <p>
        <asp:Label ID="countLabel" runat="server">Hello!
        </asp:Label>
    </p>
    <p>
        <span>How many days?</span>
        <asp:DropDownList ID="daysList" runat="server">
            <asp:ListItem Value="0">All shopping carts</asp:ListItem>
            <asp:ListItem Value="1">One</asp:ListItem>
            <asp:ListItem Value="10" Selected="True">Ten</asp:ListItem>
            <asp:ListItem Value="20">Twenty</asp:ListItem>
            <asp:ListItem Value="30">Thirty</asp:ListItem>
            <asp:ListItem Value="90">Ninety</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="countButton" runat="server" Text="Count Old Shopping Carts" OnClick="countButton_Click" />
        <asp:Button ID="deleteButton" runat="server" Text="Delete Old Shopping Carts" OnClick="deleteButton_Click" />
    </p>
</asp:Content>
