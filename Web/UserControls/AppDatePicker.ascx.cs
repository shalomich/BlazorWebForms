using System;

public partial class AppDataPicker : System.Web.UI.UserControl
{
    public DateTime? Date
    {
        get
        {
            var dateValue = Request.Form[Name];
            if (DateTime.TryParse(dateValue, out var parsedDate))
            {
                return parsedDate;
            }
            return null;
        }
        set
        {
            ViewState["Date"] = value;
        }
    }

    public string Name { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}