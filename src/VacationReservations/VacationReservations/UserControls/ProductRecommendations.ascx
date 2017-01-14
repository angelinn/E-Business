<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductRecommendations.ascx.cs" Inherits="VacationReservations.UserControls.ProductRecommendations" %>
<%@ Import Namespace="VacationReservations.Common" %>

<asp:DataList ID="list" runat="server" ShowHeader="false">
    <HeaderStyle CssClass=" RecommendationsHead " />
    <HeaderTemplate>
        We also recommend:
    </HeaderTemplate>
    <ItemTemplate>
        <a class="RecommendationLabel" href='<%# Link.ToProduct(Eval("ProductID").ToString())%>'>
            <%# Eval("Name") %>
        </a>
        <%# Eval("Description") %>
    </ItemTemplate>
</asp:DataList>