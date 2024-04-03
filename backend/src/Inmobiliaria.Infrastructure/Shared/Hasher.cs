using System.Security.Cryptography;
using Inmobiliaria.Application.Shared;

namespace Inmobiliaria.Infrastructure.Shared;

public class Hasher : IHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private readonly static HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;
    private const char Delimiter = ';';

    public string Hash(string plainKey)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(plainKey, salt, Iterations, HashAlgorithmName, KeySize);

        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Verify(string hashedKey, string plainKey)
    {
        var elements = hashedKey.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(plainKey, salt, Iterations, HashAlgorithmName, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashToCompare);
    }
}
