using DatabaseTier.Persistence;
using DatabaseTier.Protocol;

namespace DatabaseTier
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSocket socket = new StartSocket();
            socket.Start();
            
            using (CloudContext context = new CloudContext())
            {
             
            }
        }
    }
}