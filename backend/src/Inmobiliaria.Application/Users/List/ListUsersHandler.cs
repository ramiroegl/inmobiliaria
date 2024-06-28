using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Users;
using Inmobiliaria.Domain.Users.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Users.List;

public class ListUsersHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<ListUsersQuery, ListedUsersResult>
{
    public async Task<ListedUsersResult> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var specification = new SearchUsersSpec(request.Search, request.Skip, request.Take);
        List<User> users = await userRepository.ListAsync(specification, cancellationToken);
        var totalOfUsers = await userRepository.CountAsync(specification, cancellationToken);

        return new ListedUsersResult
        {
            Data = mapper.ToListedUsers(users),
            PageSize = request.Take,
            TotalRecords = totalOfUsers
        };
    }
}
