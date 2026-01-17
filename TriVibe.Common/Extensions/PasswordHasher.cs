using System.Security.Cryptography;
using System.Text;

namespace TriVibe.Common.Extensions;

public static class PasswordHasher
{
    public static string ComputeStringToSha256Hash(string plainText)
    {
        // Create a SHA256   
        using SHA256 sha256Hash = SHA256.Create();
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
