using Ardalis.Specification;

namespace Inmobiliaria.Domain.Users.Specifications;

public sealed class SearchUsersSpec : Specification<User>
{
    public SearchUsersSpec(string? search, int skip, int take)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalizedSearch = search.ToLower();
            Query
                .Where(user =>
                    user.Name.ToLower().Contains(normalizedSearch) ||
                    user.LastName.ToLower().Contains(normalizedSearch) ||
                    user.Email.ToLower().Contains(normalizedSearch)
                );
        }
        Query.OrderByDescending(user => user.Name);
        Query.Skip(skip).Take(take);
    }
}
