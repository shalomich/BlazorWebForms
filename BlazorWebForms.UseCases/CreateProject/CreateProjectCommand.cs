using MediatR;
using System.Threading.Tasks;
using System.Threading;
using BlazorWebForms.Domain.Entities;
using BlazorWebForms.Infrastructure;

namespace BlazorWebForms.UseCases.CreateProject
{
    public class CreateProjectCommand : IRequest<Unit>
    {
        public CreateProjectCommand(ProjectCreateDto project)
        {
            Project = project;
        }

        public ProjectCreateDto Project { get; }
    }

    internal class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly AppDbContext dbContext;

        public CreateProjectCommandHandler(
            AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Project.Name,
                UserId = request.Project.UserId,
            };

            dbContext.Projects.Add(project);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
