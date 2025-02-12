<%@ Page Async="true" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="update.aspx.cs" Inherits="WebForms.Projects.update" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display: flex; flex-direction: column; gap: 10px; justify-content:center; align-items: center">
        <div class="form-group">
            <label for="name">Name:</label>
            <asp:TextBox ID="name" name="name" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="end-date">End date:</label>
            <app-date-picker name="EndDate" id="end-date"></app-date-picker>
        </div>
        <button method="post" formaction='<%= UpdateProjectPath %>' class="btn btn-primary">Save</button>
        <script>
            // TODO: Find a way to change a property without a timeout.
            setTimeout(() => {
                document.getElementById('end-date').value = <%= ProjectEndDateString %>;
            }, 1000);
        </script>
    </div>
</asp:Content>

