using System.Threading.Tasks;
using DatabaseTier.Protocol;

namespace DatabaseTier
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StartSocket socket = new StartSocket();
            socket.Start();
        }
    }
}