<%@ Page Async="true" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="update.aspx.cs" Inherits="projects_update" 
        EnableViewState="true" %>
<%@ Register TagPrefix="uc" Src="~/UserControls/AppDatePicker.ascx" TagName="AppDatePicker" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; flex-direction: column; gap: 10px; justify-content:center; align-items: center">
        <div class="form-group">
            <label for="name">Name:</label>
            <asp:TextBox ID="name" name="name" runat="server" CssClass="form-control"/>
        </div>
        <div class="form-group">
            <label for="start-date">Start date:</label>
            <uc:AppDatePicker ID="startDate" runat="server" Name="startDate"/>
        </div>
        <div class="form-group">
            <label for="end-date">End date:</label>
            <uc:AppDatePicker ID="endDate" runat="server" Name="endDate" />
        </div>
        <asp:Button ID="saveButton" runat="server" OnClick="button_Click" Text="Save" CssClass="btn btn-primary" />
    </div>
</asp:Content>

