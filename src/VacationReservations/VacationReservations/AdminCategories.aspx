<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AdminCategories.aspx.cs" Inherits="VacationReservations.AdminCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <span class="AdminTitle">Админ зона
 <br />
        Категории
 <asp:HyperLink ID="deptLink" runat="server" />
    </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="server">
    <p>
        <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
    </p>
    <asp:GridView ID="grid" runat="server" DataKeyNames="CategoryID" AutoGenerateColumns="False" Width="100%" OnRowEditing="grid_RowEditing" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowUpdating="grid_RowUpdating" OnRowDeleting="grid_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="CategoryName" SortExpression="Name" />
            <asp:TemplateField HeaderText="Category Description" SortExpression="Description">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'>
                    </asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" Text='<%# Bind("Description") %>' Height="70px" Width="400px" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="link" NavigateUrl='<%# "AdminProducts.aspx?DepartmentID=" + Request.QueryString["DepartmentID"] + "&amp;CategoryID=" + Eval("CategoryID") %>' Text="View Products">
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:ButtonField CommandName="Delete" Text="Delete" />
        </Columns>
    </asp:GridView>
    <p>Създаване на категория:</p>
    <p>Име:</p>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
    <p>Описание:</p>
    <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
    <p>
        <asp:Button ID="createCategory" Text="Създай" runat="server" OnClick="createCategory_Click" />
    </p>
</asp:Content>
