using Ardalis.Specification;

namespace Inmobiliaria.Domain.Users.Specifications;

public class UserByEmailSpec : Specification<User>, ISingleResultSpecification<User>
{
    public UserByEmailSpec(string email)
    {
        Query.Where(user => user.Email == email);
    }
}
