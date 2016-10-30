<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesList.ascx.cs" Inherits="VacationReservations.UserControls.CategoriesList" %>
<%@ Import Namespace="VacationReservations.Common" %>

<asp:DataList ID="dlCategories" runat="server" Width="200px" CssClass="CategoriesList" HeaderStyle-CssClass="CategoriesListHead">

    <HeaderStyle CssClass="CategoriesListHead"></HeaderStyle>
    <HeaderTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl='<%# Link.ToCategory(Request.QueryString["DepartmentID"],
                             Eval("CategoryID").ToString()) %>'
            Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
            ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
            CssClass='<%# Eval("CategoryID").ToString() ==
             Request.QueryString["CategoryID"] ?
             "CategorySelected" : "CategoryUnselected" %>'>>
        </asp:HyperLink>
    </HeaderTemplate>

</asp:DataList>