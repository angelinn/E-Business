<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentUserControl.ascx.cs" Inherits="VacationReservations.UserControls.DepartmentUserControl" %>
<%@ Import namespace="VacationReservations.Common" %>

<asp:DataList ID="dlDepartments" Width="200px" CssClass="DepartmentsList" HeaderStyle-CssClass="DepartmentsListHead" runat="server">

    <HeaderStyle CssClass="DepartmentsListHead"></HeaderStyle>
    <HeaderTemplate>
        Choose a department
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl='<%# Link.ToDepartment(Eval("DepartmentID").ToString())%>'
            Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
            ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
            CssClass='<%# Eval("DepartmentID").ToString() ==
            Request.QueryString["DepartmentID"] ? "DepartmentSelected" :"DepartmentUnselected" %>'>HyperLink

        </asp:HyperLink>
    </ItemTemplate>

</asp:DataList>
