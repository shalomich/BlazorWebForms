using Web.SharedComponents.Components;
using Web.SharedComponents.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

BlazorModule.Register(builder.Services);

builder.RootComponents.RegisterCustomElement<AppHeader>("app-header");
builder.RootComponents.RegisterCustomElement<AppProvider>("app-provider");

await builder.Build().RunAsync();
