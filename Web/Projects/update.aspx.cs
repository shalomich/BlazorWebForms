using System;
using System.Text.Json;
using System.Web.UI;
using Common.UseCases;
using Common.Web;
using MediatR;
using Web.Infrastructure;

namespace WebForms.Projects
{
    public partial class update : System.Web.UI.Page
    {
        private readonly IMediator mediator;
        private readonly AppUrlBuilder blazorAppUrlBuilder;

        public string UpdateProjectPath { get; private set; }
        public string ProjectEndDateString { get; private set; }

        public update()
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
            ProjectEndDateString = JsonSerializer.Serialize(project.EndDate);
            UpdateProjectPath = blazorAppUrlBuilder.BuildNewAppUrl(ApiPaths.UpdateProject(projectId));
        }
    }
}