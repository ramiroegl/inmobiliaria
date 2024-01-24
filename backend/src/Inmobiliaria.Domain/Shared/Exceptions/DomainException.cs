namespace Inmobiliaria.Domain.Shared.Exceptions;

public class DomainException(string message) : Exception(message)
{
    public DomainException(string message, params string[] strings) : this(string.Format(message, strings))
    {
    }
}
