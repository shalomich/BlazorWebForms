using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorWebForms.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebForms.UseCases.GetProjects
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
                .OrderByDescending(project => project.Id)
                .Select(project => new ProjectDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate
                })
                .ToListAsync(cancellationToken);
        }
    }
}
