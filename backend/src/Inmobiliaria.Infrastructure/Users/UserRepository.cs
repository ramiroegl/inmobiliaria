using Ardalis.Specification.EntityFrameworkCore;
using Inmobiliaria.Domain.Users;
using Inmobiliaria.Infrastructure.Shared;

namespace Inmobiliaria.Infrastructure.Users;

public class UserRepository(Context dbContext) : RepositoryBase<User>(dbContext), IUserRepository;
