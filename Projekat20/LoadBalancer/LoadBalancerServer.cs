using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class LoadBalancerServer : ILoadBalancer
    {
        public List<string> demandWork(List<string> input)
        {
            List<string> retList = new List<string>();
            string logline = "Work demand came from server. Action: " + input[0];
            if (input.Count > 1)
            {
                logline = logline + ". Parameters: ";
                for (int i = 1; i < input.Count; i++)
                {
                    if (i == input.Count - 1)
                    {
                        logline = logline + input[i] + ".";
                        break;
                    }
                    logline = logline + input[i] + ", ";
                }
            }
            Console.WriteLine(logline);
            return retList;
        }
    }
}
