<%@ Page Async="true" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="Web.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="project_grid" ClientIDMode="Static" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
    PageSize="10" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="< First" PagerSettings-LastPageText="Last >" PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="grid-paging" AllowPaging="true">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="OnDetailsLinkClick">Project Details</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
