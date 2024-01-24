using Ardalis.Specification.EntityFrameworkCore;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Infrastructure.Shared;

namespace Inmobiliaria.Infrastructure.Properties;

public class PropertyRepository(Context context) : RepositoryBase<Property>(context), IPropertyRepository;
