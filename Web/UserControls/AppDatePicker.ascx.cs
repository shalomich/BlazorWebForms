using System;

public partial class AppDataPicker : System.Web.UI.UserControl
{
    public DateTime? Date
    {
        get
        {
            // Get the value from Blazor component if available
            if (Page.IsPostBack && !string.IsNullOrEmpty(Request.Form[Name]))
            {
                if (DateTime.TryParse(Request.Form[Name], out DateTime result))
                {
                    ViewState["Date"] = result;
                    return result;
                }
            }
            return (DateTime?)ViewState["Date"];
        }
        set
        {
            ViewState["Date"] = value;
        }
    }

    public string Name { get; set; }
}