using Common.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.New.Controllers;

public class AccountController : Controller
{
    private readonly AppUrlBuilder blazorAppUrlBuilder;

    public AccountController(
        AppUrlBuilder blazorAppUrlBuilder)
    {
        this.blazorAppUrlBuilder = blazorAppUrlBuilder;
    }

    [HttpPost(NewAppPaths.Logout)]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return Redirect(blazorAppUrlBuilder.BuildLegacyAppUrl(LegacyAppPaths.LoginPath));
    }
}
