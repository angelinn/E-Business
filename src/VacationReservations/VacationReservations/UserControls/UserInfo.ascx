<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="VacationReservations.UserControls.UserInfo" %>
<table cellspacing="0" border="0" width="200px">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <tr>
                <td class="UserInfoHead">Добре дошли!</td>
            </tr>
            <tr>
                <td class="UserInfoContent">Не сте влезли.
 <br />
                    <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Влизане" LogoutText="Излизане" />
                    или
                    <asp:HyperLink runat="server" ID="registerLink" NavigateUrl="~/Register.aspx" Text="Регистрация"
                        ToolTip="Go to the registration page" />
                </td>
            </tr>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrators">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server" FormatString="Здравей, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:LoginStatus ID="LoginStatus2" runat="server" />
                            <br />
                            <a href="/">&lt;-- Обратно/a>
                            <br />
                            <a href="AdminDepartments.aspx">Админ каталог</a>
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</table>
