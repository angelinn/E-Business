<%@ Page Title="" Language="C#" MasterPageFile="~/VacationReservationsPage.Master" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="VacationReservations.NotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Looking for balloons?</h1>
    <p>
        Unfortunately, the page that you asked for doesn't exist in our web site!
    </p>
    <p>
        Please visit our
 <asp:hyperlink runat="server" target="~/" text="catalog" />
        ,
 or contact us at friendly_support@example.com!
    </p>
    <p>The <b>BalloonShop</b> team</p>
</asp:Content>
