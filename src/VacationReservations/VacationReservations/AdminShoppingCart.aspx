<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AdminShoppingCart.aspx.cs" Inherits="VacationReservations.AdminShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <span class="AdminTitle">Админ зона
 <br />
        Колички
    </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="server">
    <p>
        <asp:Label ID="countLabel" runat="server">
        </asp:Label>
    </p>
    <p>
        <span>Колко дни?</span>
        <asp:DropDownList ID="daysList" runat="server">
            <asp:ListItem Value="0">Всички колички</asp:ListItem>
            <asp:ListItem Value="1">Една</asp:ListItem>
            <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
            <asp:ListItem Value="20">20</asp:ListItem>
            <asp:ListItem Value="30">30</asp:ListItem>
            <asp:ListItem Value="90">100</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="countButton" runat="server" Text="Преброй старите колички" OnClick="countButton_Click" />
        <asp:Button ID="deleteButton" runat="server" Text="Изтрий старите колички" OnClick="deleteButton_Click" />
    </p>
</asp:Content>
