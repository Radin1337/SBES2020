using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            string address = "net.tcp://localhost:9998/LoadBalancer";
            ServiceHost host = new ServiceHost(typeof(LoadBalancerServer));
            host.AddServiceEndpoint(typeof(ILoadBalancer), binding, address);
            host.Open();
            Console.WriteLine("LoadBalancer started working. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
