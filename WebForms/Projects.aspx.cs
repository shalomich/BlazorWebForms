using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Domain.UseCases;
using Domain.Web;
using MediatR;
using WebForms.Infrastructure;

namespace WebForms
{
    public partial class Projects : System.Web.UI.Page
    {
        private readonly IMediator mediator;
        private readonly BlazorAppUrlBuilder blazorAppUrlBuilder;
        public Projects()
        {
            var serviceProvider = LegacyServiceProvider.Create();

            mediator = serviceProvider.GetRequiredService<IMediator>();
            blazorAppUrlBuilder = serviceProvider.GetRequiredService<BlazorAppUrlBuilder>();
        }
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Redirect(WebFormsAppPaths.LoginPath);
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

            Redirect(blazorAppUrlBuilder.BuildProjectDetailsUrl(projectId));
        }

        private void Redirect(string url)
        {
            Response.Redirect(url, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}