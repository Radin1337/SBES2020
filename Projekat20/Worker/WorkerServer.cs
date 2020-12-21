using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
namespace Worker
{
    public class WorkerServer : ILBtoWorker
    {
        public List<string> DoSomeWork(List<string> input)
        {
            Console.WriteLine("Work accepted. Action: "+input[0]);
            return null;
        }
    }
}
