using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Common.Dtos;
using Common.Entities;

namespace Common.UseCases
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
