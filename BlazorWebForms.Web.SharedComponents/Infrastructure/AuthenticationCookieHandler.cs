using BlazorWebForms.Web.Common.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.AspNetCore.Http;

namespace BlazorWebForms.Web.SharedComponents.Infrastructure;

class AuthenticationCookieHandler : DelegatingHandler
{
    public AuthenticationCookieHandler(HttpMessageHandler innerHandler) : base(innerHandler)
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {    
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
    
        return await base.SendAsync(request, cancellationToken);
    }
}

