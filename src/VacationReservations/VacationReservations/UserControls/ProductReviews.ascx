<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductReviews.ascx.cs" Inherits="VacationReservations.UserControls.ProductReviews" %>

<p class="ReviewHead">Ревюта на клиенти</p>
<asp:DataList ID="list" runat="server" ShowFooter="true"
    CssClass="ReviewTable">
    <ItemStyle CssClass="ReviewTable" />
    <ItemTemplate>
        <p>
            Ревю от <strong>
                <%# Eval("CustomerName") %></strong> на
 <%# String.Format("{0:D}", Eval("ReviewDate")) %>:
 <br />
            <i>
                <%# Eval("ProductReview") %></i>
        </p>
    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:DataList>
<asp:Panel ID="addReviewPanel" runat="server">
    <p>
        Напишете собствено ревю!
    </p>
    <p>
        <asp:TextBox runat="server" ID="reviewTextBox" Rows="3"
            Columns="88" TextMode="MultiLine" />
    </p>
    <asp:LinkButton ID="addReviewButton" runat="server"
        OnClick="addReviewButton_Click">Добави ревю</asp:LinkButton>
</asp:Panel>
<asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <p>
            Моля влезте в акаунта си, за да напишете ревю.
        </p>
    </AnonymousTemplate>
</asp:LoginView>
