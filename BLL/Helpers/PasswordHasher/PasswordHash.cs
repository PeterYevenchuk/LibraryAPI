using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BLL.Helpers.PasswordHasher;

public class PasswordHash : IPasswordHash
{
    public string EncryptPassword(string password, byte[] salt)
    {
        byte[] byteArray = { 2,2,8};
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: byteArray,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
    }
}
