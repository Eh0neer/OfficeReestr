using System;
using System.Security.Cryptography;
using System.Text;

namespace OfficeReestr.Utilities;

public class PasswordHasher
{
    private const int SaltSize = 32;
    private const int HashSize = 32;
    private const int Iterations = 10000;

    // Метод для генерации соли
    public static string GenerateSalt()
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }

    // Метод для хеширования пароля с использованием соли
    public static string HashPassword(string password, string salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = Convert.FromBase64String(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, saltBytes, Iterations, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(HashSize);
            return Convert.ToBase64String(hash);
        }
    }

    // Метод для проверки соответствия хеша и пароля
    public static bool VerifyPassword(string password, string salt, string hashedPassword)
    {
        return HashPassword(password, salt) == hashedPassword;
    }
}
