using Web.SharedComponents.Components;
using Web.SharedComponents.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Common.Web;
using Common.DI;
using Web.SharedComponents.Components.ProjectCreateDialog;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

ApplicationModule.Register(builder.Services, builder.Configuration);
BlazorModule.Register(builder.Services);

builder.RootComponents.RegisterCustomElement<AppHeader>("app-header");
builder.RootComponents.RegisterCustomElement<AppProvider>("app-provider");
builder.RootComponents.RegisterCustomElement<ProjectCreateButton>("project-create-button");

await builder.Build().RunAsync();
