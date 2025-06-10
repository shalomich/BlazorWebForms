using System;
using System.Web.Security;
using System.Web.UI;

namespace Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // https://learn.microsoft.com/en-us/iis/extensions/url-rewrite-module/url-rewriting-for-aspnet-web-forms#setting-the-postback-url-for-the-form-element
            MainContent.Page.Form.Action = Request.RawUrl;
        }
    }
}