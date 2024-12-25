using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.UseCases
{

    public class GetProjectsQuery : IRequest<IEnumerable<ProjectDto>>
    {

    }

    internal class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly AppDbContext dbContext;

        public GetProjectsQueryHandler(
            AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Projects
                .Select(project => new ProjectDto
                {
                    Id = project.Id,
                    Name = project.Name,
                })
                .ToListAsync(cancellationToken);
        }
    }

    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
