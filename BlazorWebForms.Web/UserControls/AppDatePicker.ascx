<%@ Control Language="C#" AutoEventWireup="true" Inherits="AppDataPicker" Codebehind="AppDatePicker.ascx.cs" 
    EnableViewState="true" %>

<app-date-picker id="<%= ID %>" name="<%= Name %>"></app-date-picker>

<script type="module">
    function setDatePickerValue (event) {
        const datePickerId = '<%= ID %>';
        if (event.detail.id !== datePickerId) {
            return;
        }
        const datePicker = document.getElementById(datePickerId);
        datePicker.value = <%= System.Text.Json.JsonSerializer.Serialize(Date) %>;

        document.removeEventListener('component-rendered', setDatePickerValue);
    };

    document.addEventListener('component-rendered', setDatePickerValue);
</script>