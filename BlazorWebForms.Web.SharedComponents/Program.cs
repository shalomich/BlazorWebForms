using BlazorWebForms.Web.Common.DI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWebForms.Web.SharedComponents.Components;
using BlazorWebForms.Web.SharedComponents.Components.ProjectCreateDialog;
using BlazorWebForms.Web.SharedComponents.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");

ApplicationModule.Register(builder.Services, builder.Configuration);
BlazorModule.Register(builder.Services);
WebComponentsModule.Register(builder.Services, builder.Configuration);

builder.RootComponents.RegisterCustomElement<AppHeader>("app-header");
builder.RootComponents.RegisterCustomElement<AppProvider>("app-provider");
builder.RootComponents.RegisterCustomElement<ProjectCreateButton>("project-create-button");
builder.RootComponents.RegisterCustomElement<AppDatePicker>("app-date-picker");

await builder.Build().RunAsync();
