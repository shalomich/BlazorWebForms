using System;
using System.Web;
using System.Web.UI;
using Common.Web;

namespace Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(LegacyAppPaths.ProjectsPath);
            }
            else
            {
                Response.Redirect(LegacyAppPaths.LoginPath);
            }
        }
    }
}