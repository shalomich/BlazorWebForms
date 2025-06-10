using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorWebForms.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebForms.UseCases.GetProjectId
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
                    EndDate = project.EndDate,
                    StartDate = project.StartDate,
                    UserName = project.User.UserName
                })
                .FirstAsync(project => project.Id == request.Id, cancellationToken);
        }
    }
}
