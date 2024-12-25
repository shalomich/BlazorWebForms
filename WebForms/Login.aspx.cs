using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using WebForms.Infrastructure;
using Domain.Entities;

namespace WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected async void OnLoginButtonClick(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            var username = email_address.Text.Trim();
            var password = password_input.Text.Trim();

            // https://learn.microsoft.com/en-us/aspnet/identity/overview/getting-started/adding-aspnet-identity-to-an-empty-or-existing-web-forms-project#add-web-forms-for-registering-and-signing-in-users
            var userStore = new UserStore<ApplicationUser, AspNetRole, string, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>(new AppIdentityDbContext());
            var userManager = new UserManager<ApplicationUser, string>(userStore);

            var owinContext = Request.GetOwinContext();

            var user = await userManager.FindAsync(username, password);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = username
                };

                var result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    return;
                }
            }

            var authenticationManager = owinContext.Authentication;

            var userIdentity = userManager.CreateIdentity(user, "Identity.Application");
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        
            Response.Redirect("/");
        }
    }
}