namespace Inmobiliaria.Application.Shared;

public interface IHasher
{
    /// <summary>
    /// Hash a key
    /// </summary>
    /// <param name="plainKey">Key to hash</param>
    /// <returns>A hashed key</returns>
    string Hash(string plainKey);

    /// <summary>
    /// Compare two strings, a hashed key with a plain key
    /// </summary>
    /// <param name="hashed">A hashed key</param>
    /// <param name="plain">A plain key</param>
    /// <returns>If the hash of plain key is equal to hashed key</returns>
    bool Verify(string hashed, string plain);
}
