using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Common.UseCases;
using Common.Web;
using MediatR;
using Web.Infrastructure;

namespace Web
{
    public partial class Projects : System.Web.UI.Page
    {
        private readonly IMediator mediator;
        private readonly AppUrlBuilder blazorAppUrlBuilder;
        public Projects()
        {
            var serviceProvider = LegacyServiceProvider.Create();

            mediator = serviceProvider.GetRequiredService<IMediator>();
            blazorAppUrlBuilder = serviceProvider.GetRequiredService<AppUrlBuilder>();
        }
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Redirect(LegacyAppPaths.LoginPath);
                return;
            }

            var projects = await mediator.Send(new GetProjectsQuery());

            if (projects.Any())
            {
                project_grid.DataSource = projects;
                project_grid.DataBind();
            }
        }

        protected void OnDetailsLinkClick(object sender, CommandEventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int projectId = Convert.ToInt32(button.CommandArgument);

            Redirect(blazorAppUrlBuilder.BuildNewAppUrl(NewAppPaths.GetProjectDetails(projectId)));
        }

        private void Redirect(string url)
        {
            Response.Redirect(url, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}