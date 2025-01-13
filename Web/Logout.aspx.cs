using System;
using System.Web;
using System.Web.Security;
using Common.Web;

namespace Web.Fetch
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Cookies.Add(new HttpCookie(AuthenticationConstants.CookieName, string.Empty));

            Response.Redirect(LegacyAppPaths.LoginPath);
        }
    }
}