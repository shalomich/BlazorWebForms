<%@ Page Title="Home Page" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForms.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="form-group">
            <label for="email_address">Email address:</label>
            <asp:TextBox ID="email_address" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="req_email" runat="server" ControlToValidate="email_address" Text="Email address is required" CssClass="invalid-feedback" />
        </div>
        <div class="form-group">
            <label for="password_input">Password:</label>
            <asp:TextBox ID="password_input" runat="server" TextMode="Password" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="req_password" runat="server" ControlToValidate="password_input" Text="Password is required" CssClass="invalid-feedback" />
        </div>
        <asp:Literal ID="login_error" runat="server" />
        <asp:Literal ID="lockout_error" runat="server" />
        <div class="text-right">
            <asp:Button ID="login_button" OnClick="OnLoginButtonClick" runat="server" CssClass="btn btn-primary" Text="Login" />
        </div>
    </main>

</asp:Content>
