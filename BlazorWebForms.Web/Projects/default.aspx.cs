using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Dtos;
using Common.Entities;
using Common.UseCases;
using Common.Web;
using MediatR;
using BlazorWebForms.Web.Infrastructure;

namespace WebForms.Projects
{
    public partial class _default : System.Web.UI.Page
    {
        private readonly IMediator mediator;
        private readonly AppUrlBuilder blazorAppUrlBuilder;

        public IEnumerable<UserDto> Users { get; private set; }

        public Func<int, string> GetDetailsPath { get; private set; }

        public Func<int, string> GetUpdatePath { get; private set; }


        public _default()
        {
            var serviceProvider = LegacyServiceProvider.Create();

            mediator = serviceProvider.GetRequiredService<IMediator>();
            blazorAppUrlBuilder = serviceProvider.GetRequiredService<AppUrlBuilder>();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(LegacyAppPaths.LoginPath);
                return;
            }

            if (IsPostBack)
            {
                return;
            }

            // TODO: Fix problem with LinkButton handlers.
            GetDetailsPath = projectId => blazorAppUrlBuilder.BuildNewAppUrl(NewAppPaths.GetProjectDetails(projectId));
            GetUpdatePath = projectId => LegacyAppPaths.ProjectUpdatePath(projectId);

            Users = await mediator.Send(new GetUsersQuery());

            var projects = await mediator.Send(new GetProjectsQuery());

            if (projects.Any())
            {
                project_grid.DataSource = projects;
                project_grid.DataBind();
            }
        }

        private void Redirect(string url)
        {
            Response.Redirect(url, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}