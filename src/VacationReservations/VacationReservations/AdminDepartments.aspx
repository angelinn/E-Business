<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AdminDepartments.aspx.cs" Inherits="VacationReservations.AdminDepartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <span class="AdminTitle">Админ зона
 <br />
        Департаменти
    </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="server">
    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="AdminError"></asp:Label>
    <asp:GridView ID="gvMain" runat="server" DataKeyNames="DepartmentID" Width="100%" AutoGenerateColumns="False" OnRowCancelingEdit="gvMain_RowCancelingEdit" OnRowEditing="gvMain_RowEditing" OnRowDeleting="gvMain_RowDeleting" OnRowUpdating="gvMain_RowUpdating">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Департамент" SortExpression="Name" />
            <asp:TemplateField HeaderText="Описание"
                SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="400px" Height="70px" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="AdminCategories.aspx?DepartmentID={0}" HeaderText="Виж категориите" Text="Виж категориите" />
        </Columns>
    </asp:GridView>
    <p>Създаване на департамент:</p>
    <p>Име:</p>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
    <p>Описание:</p>
    <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
    <p>
        <asp:Button ID="createDepartment" Text="Създай" runat="server" />
    </p>
</asp:Content>
