﻿using Contracts;
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
            //host za glavnu serversku komponentu
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            string address = "net.tcp://localhost:9998/LoadBalancer";
            ServiceHost host = new ServiceHost(typeof(LoadBalancerServer));
            host.AddServiceEndpoint(typeof(ILoadBalancer), binding, address);
            host.Open();


            //host za worker role
            NetTcpBinding binding2 = new NetTcpBinding();
            binding2.Security.Mode = SecurityMode.Transport;
            binding2.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            binding2.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            string address2 = "net.tcp://localhost:9997/WorkerToLB";
            ServiceHost host2 = new ServiceHost(typeof(LoadBalancerWorkerServer));
            host2.AddServiceEndpoint(typeof(IWorkerToLB), binding2, address2);
            host2.Open();


            Console.WriteLine("LoadBalancer started working. Press any key to exit.");
            Console.ReadKey();
        }
    }
}