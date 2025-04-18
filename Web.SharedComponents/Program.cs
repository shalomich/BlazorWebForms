using Common.DI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web.SharedComponents.Components;
using Web.SharedComponents.Components.ProjectCreateDialog;
using Web.SharedComponents.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");

ApplicationModule.Register(builder.Services, builder.Configuration);
BlazorModule.Register(builder.Services);
WebComponentsModule.Register(builder.Services, builder.Configuration);

builder.RootComponents.RegisterCustomElement<AppHeader>("app-header");
builder.RootComponents.RegisterCustomElement<AppProvider>("app-provider");
builder.RootComponents.RegisterCustomElement<ProjectCreateButton>("project-create-button");
builder.RootComponents.RegisterCustomElement<AppDatePicker>("app-date-picker");
builder.RootComponents.RegisterCustomElement<BlazorReadyNotifier>("blazor-ready");

await builder.Build().RunAsync();
