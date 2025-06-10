using BlazorWebForms.Web.Common.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebForms.Web.New.Controllers;

public class AccountController : Controller
{
    [HttpPost(ApiPaths.Logout)]
    [Authorize]
    public async Task Logout()
    {
        await HttpContext.SignOutAsync();
    }
}
