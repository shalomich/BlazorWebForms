using System;
using System.Text.Json;
using Common.UseCases;
using Common.Web;
using MediatR;
using Web.Infrastructure;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Common.Dtos;

public partial class projects_update : System.Web.UI.Page
{
    private readonly IMediator mediator;
    private readonly AppUrlBuilder blazorAppUrlBuilder;

    public string UpdateProjectPath { get; private set; }
    public string ProjectEndDateString { get; private set; }

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

        // HACK: Assign raw URL to form instead of auto-generated one since it's incorrect.
        Form.Action = Request.RawUrl;

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
        ProjectEndDateString = JsonSerializer.Serialize(project.EndDate);
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
            EndDate = endDate.Date.Value,
            Name = name.Text
        };

        await mediator.Send(new UpdateProjectCommand(projectId, projectDto));
        Response.Redirect(Request.RawUrl, false);
        return;
    }
}