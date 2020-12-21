using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 9990;
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            ChannelFactory<IWorkerToLB> factory = new ChannelFactory<IWorkerToLB>(binding, new
           EndpointAddress("net.tcp://localhost:9997/WorkerToLB"));
            IWorkerToLB proxy = factory.CreateChannel();

            //javi se load balanceru i trazi svoj id
            int id = proxy.IamAliveGiveMeID();

            //dobili id sad otvaramo konekciju
            NetTcpBinding binding2 = new NetTcpBinding();
            binding2.Security.Mode = SecurityMode.Transport;
            binding2.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            binding2.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            int realport = port + id;
            string address2 = "net.tcp://localhost:" + realport + "/LbToWorker";
            ServiceHost host = new ServiceHost(typeof(WorkerServer));
            host.AddServiceEndpoint(typeof(ILBtoWorker), binding2, address2);
            host.Open();
            proxy.RegisterMe(id);
            Console.WriteLine("Worker started working. Press anykey to stop.");
            Console.ReadKey();
            proxy.UnRegisterMe(id);
            host.Close();
        }
    }
}
