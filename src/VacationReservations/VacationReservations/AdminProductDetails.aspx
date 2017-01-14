<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AdminProductDetails.aspx.cs" Inherits="VacationReservations.AdminProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <span class="AdminTitle">Админ зона
 <br />
        Обратно към
 <asp:HyperLink ID="catLink" runat="server" />
    </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="server">
    <asp:Label CssClass="AdminTitle" ID="productNameLabel" runat="server" />
    <p>
        <asp:Label ID="statusLabel" CssClass="AdminError" runat="server" />
    </p>
    <p>
        Продуктът е в следните категории:
 <asp:Label ID="categoriesLabel" runat="server" />
    </p>
    <p>
        Премахни от тази категория:
 <asp:DropDownList ID="categoriesListRemove" runat="server" />
        <asp:Button ID="removeButton" runat="server" Text="Премахни" OnClick="removeButton_Click" />
        <asp:Button ID="deleteButton" runat="server" Text="Изтрий" OnClick="deleteButton_Click" />
    </p>
    <p>
        Добави продукт в тази категория:
 <asp:DropDownList ID="categoriesListAssign" runat="server" />
        <asp:Button ID="assignButton" runat="server" Text="Добави" OnClick="assignButton_Click" />
        <p>
            Премести продукт в тази категория:
 <asp:DropDownList ID="categoriesListMove" runat="server" />
            <asp:Button ID="moveButton" runat="server" Text="Премести" OnClick="moveButton_Click" />
        </p>
        <p>
            Малка снимка:
 <asp:Label ID="Image1Label" runat="server" />
            <asp:FileUpload ID="image1FileUpload" runat="server" />
            <asp:Button ID="upload1Button" runat="server" Text="Качи" /><br />
            <asp:Image ID="image1" runat="server" />
        </p>
        <p>
            Голяма снимка:
 <asp:Label ID="Image2Label" runat="server" />
            <asp:FileUpload ID="image2FileUpload" runat="server" />
            <asp:Button ID="upload2Button" runat="server" Text="Качи" /><br />
            <asp:Image ID="image2" runat="server" />
        </p>
</asp:Content>
