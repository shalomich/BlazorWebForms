using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Common.UseCases
{

    public class GetProjectsByIdQuery : IRequest<ProjectDetailsDto>
    {
        public int Id { get; }

        public GetProjectsByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetProjectsByIdQueryHandler : IRequestHandler<GetProjectsByIdQuery, ProjectDetailsDto>
    {
        private readonly AppDbContext dbContext;

        public GetProjectsByIdQueryHandler(
            AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProjectDetailsDto> Handle(GetProjectsByIdQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Projects
                .Select(project => new ProjectDetailsDto
                {
                    Id = project.Id,
                    Name = project.Name,
                })
                .FirstOrDefaultAsync(project => project.Id == request.Id, cancellationToken);
        }
    }

    public class ProjectDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
