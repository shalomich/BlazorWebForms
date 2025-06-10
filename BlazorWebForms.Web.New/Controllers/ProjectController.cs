using Common.Dtos;
using Common.UseCases;
using Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebForms.Web.New.Controllers
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

        [HttpPost(ApiPaths.CreateProject)]
        public async Task CreateProject([FromBody] ProjectCreateDto project, CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateProjectCommand(project), cancellationToken);
        }

        [HttpPost(ApiPaths.UpdateProjectTemplate)]
        public async Task<IActionResult> UpdateProject(int id, ProjectUpdateDto project, CancellationToken cancellationToken)
        {
            await mediator.Send(new UpdateProjectCommand(id, project), cancellationToken);

            return Redirect(appUrlBuilder.BuildLegacyAppUrl(LegacyAppPaths.ProjectsPath));
        }
    }
}
