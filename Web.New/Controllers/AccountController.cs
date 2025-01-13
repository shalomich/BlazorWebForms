using Common.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Web.New.Controllers;

[ApiController]
public class AccountController : Controller
{
    private readonly AppUrlBuilder blazorAppUrlBuilder;

    public AccountController(
        AppUrlBuilder blazorAppUrlBuilder)
    {
        this.blazorAppUrlBuilder = blazorAppUrlBuilder;
    }

    [HttpGet(NewAppPaths.Logout)]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return Redirect(blazorAppUrlBuilder.BuildLegacyAppUrl(LegacyAppPaths.LoginPath));
    }
}
