using System;
using System.Web;
using System.Web.UI;
using Domain.Web;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(WebFormsAppPaths.ProjectsPath);
            }
        }
    }
}