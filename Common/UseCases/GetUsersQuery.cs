using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Common.UseCases
{

    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {

    }

    internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly AppDbContext dbContext;

        public GetUsersQueryHandler(
            AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.AspNetUsers
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.UserName,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
