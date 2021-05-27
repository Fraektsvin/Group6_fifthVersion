using System.Threading.Tasks;
using DatabaseTier.Protocol;
using DatabaseTier.Repository.AdminREPO;

namespace DatabaseTier
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StartSocket socket = new StartSocket();
            AdminRepository test = new AdminRepository();
            test.CheckUserAsync("Nina");
            socket.Start();
        }
    }
}