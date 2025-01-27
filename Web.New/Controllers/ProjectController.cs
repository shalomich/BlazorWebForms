using Common.Dtos;
using Common.UseCases;
using Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.New.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IMediator mediator;
        private readonly AppUrlBuilder appUrlBuilder;

        public ProjectController(
            IMediator mediator,
            AppUrlBuilder appUrlBuilder) 
        {
            this.mediator = mediator;
            this.appUrlBuilder = appUrlBuilder;
        }

        [HttpPost(NewAppPaths.Projects)]
        public async Task<IActionResult> CreateProject(ProjectCreateDto project, CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateProjectCommand(project), cancellationToken);

            return Redirect(appUrlBuilder.BuildLegacyAppUrl(LegacyAppPaths.ProjectsPath));
        }
    }
}
