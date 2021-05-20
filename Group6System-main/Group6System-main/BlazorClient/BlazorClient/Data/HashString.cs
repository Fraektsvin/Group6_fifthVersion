using System.Security.Cryptography;
using System.Text;

namespace BlazorClient.Data
{
    public class HashString
    {
        private string HashInput(string input)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            var hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var hashedInputAsString = Encoding.ASCII.GetString(hashBytes);
            return hashedInputAsString;
        }
    }
}