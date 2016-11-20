<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsList.ascx.cs" Inherits="VacationReservations.UserControls.ProductsList" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Import namespace="VacationReservations.Common" %>

<uc1:Pager ID="pgTop" runat="server" />
<asp:DataList ID="list" runat="server" RepeatColumns="2"
    CssClass="ProductList">
    <ItemTemplate>
        <h3 class="ProductTitle">
            <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
                <%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>
            </a>
        </h3>
        <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
            <img width="100" border="0"
                src="<%# Link.ToProductImage(Eval("Thumbnail").ToString()) %>"
                alt='<%# HttpUtility.HtmlEncode(Eval("Name").ToString())%>' />
        </a>
        <%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>
        <p>
            Price:
 <%# Eval("Price", "{0:c}") %>
        </p>
    </ItemTemplate>
</asp:DataList><uc1:Pager ID="pgBottom" runat="server" />
