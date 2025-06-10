using System;
using BlazorWebForms.Web.Common.Web;
using MediatR;
using BlazorWebForms.Web.Infrastructure;
using BlazorWebForms.UseCases.GetProjectId;
using BlazorWebForms.UseCases.UpdateProject;

public partial class projects_update : System.Web.UI.Page
{
    private readonly IMediator mediator;
    private readonly AppUrlBuilder blazorAppUrlBuilder;

    public string UpdateProjectPath { get; private set; }
    
    public projects_update()
    {
        var serviceProvider = LegacyServiceProvider.Create();

        mediator = serviceProvider.GetRequiredService<IMediator>();
        blazorAppUrlBuilder = serviceProvider.GetRequiredService<AppUrlBuilder>();
    }

    protected async void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            return;
        }

        var projectIdString = Request.QueryString["id"];

        if (!int.TryParse(projectIdString, out int projectId)) 
        {
            Response.Redirect(LegacyAppPaths.ProjectsPath, false);
            return;
        }

        ProjectDetailsDto project;
        try
        {
            project = await mediator.Send(new GetProjectsByIdQuery(projectId));
        }
        catch (Exception) 
        {
            Response.Redirect(LegacyAppPaths.ProjectsPath, false);
            return;
        }

        name.Text = project.Name;
        startDate.Date = project.StartDate;
        endDate.Date = project.EndDate;

        UpdateProjectPath = blazorAppUrlBuilder.BuildNewAppUrl(ApiPaths.UpdateProject(projectId));
    }

    protected async void button_Click(object sender, EventArgs e)
    {
        var projectIdString = Request.QueryString["id"];

        if (!int.TryParse(projectIdString, out int projectId)) 
        {
            Response.Redirect(LegacyAppPaths.ProjectsPath, false);
            return;
        }

        if (endDate.Date is null)
        {
            return;
        }

        var projectDto = new ProjectUpdateDto()
        {
            Name = name.Text,
            StartDate = startDate.Date.Value,
            EndDate = endDate.Date.Value
        };

        await mediator.Send(new UpdateProjectCommand(projectId, projectDto));
        Response.Redirect(LegacyAppPaths.ProjectsPath, false);
    }
}