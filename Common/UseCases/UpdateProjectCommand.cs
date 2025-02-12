using Common.Dtos;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System;

namespace Common.UseCases
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public UpdateProjectCommand(int id, ProjectUpdateDto project)
        {
            Id = id;
            Project = project;
        }

        public int Id { get; }
        public ProjectUpdateDto Project { get; }
    }

    internal class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly AppDbContext dbContext;

        public UpdateProjectCommandHandler(
            AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (project == null)
            {
                throw new InvalidOperationException("Project not found");
            }

            project.Name = request.Project.Name;
            project.EndDate = request.Project.EndDate;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
