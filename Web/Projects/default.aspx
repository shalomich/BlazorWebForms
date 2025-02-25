<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" EnableViewState="true" Inherits="WebForms.Projects._default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display:flex; justify-content:end; gap:16px; padding-bottom: 8px">
        <project-create-button id="create-project"></project-create-button>
    </div>
    <asp:GridView ID="project_grid" ClientIDMode="Static" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-striped table-bordered table-sm table-hover"
    PageSize="10" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="< First" PagerSettings-LastPageText="Last >" PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center" PagerStyle-CssClass="grid-paging" AllowPaging="true">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="StartDate" HeaderText="Start date" />
        <asp:BoundField DataField="EndDate" HeaderText="End date" />
        <asp:TemplateField>
            <ItemTemplate>
                
                <a href='<%# GetDetailsPath((int) Eval("Id")) %>'>Details</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <a href='<%# GetUpdatePath((int) Eval("Id")) %>'>Update</a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<script>
    document.addEventListener('component-rendered', function (event) {
        const projectCreateButtonId = 'create-project';
        if (event.detail.id !== projectCreateButtonId) {
            return;
        }
        const projectCreateButton = document.getElementById(projectCreateButtonId);
        projectCreateButton.users = <%= System.Text.Json.JsonSerializer.Serialize(Users) %>;
    });
</script>
</asp:Content>

