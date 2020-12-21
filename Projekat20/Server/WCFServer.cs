using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DecryptionAES;

namespace Server
{
    public class WCFServer : ISpecialUsers
    {

        public void GetElectricityConsumption(string imeprezime, string uid)
        {
            Console.WriteLine("GetElectricityConsumption");
            Console.WriteLine("Not implemented yet");

            Console.WriteLine("Decrypted: " + DecryptionAlgorithm.DecryptMessage(imeprezime, SecretKey.sKey));

            Console.WriteLine("EncryptedMessage: " + imeprezime + uid);
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);

            List<string> retValue = ForwardToLoadBalancer(new List<string> { "GetElectricityConsumption", imeprezime, uid});
        }


        [PrincipalPermission(SecurityAction.Demand, Role = "Add")]
        public void AddEntity(string Id, string value,string name)
        {
            Console.WriteLine("Called method: ADD ENTITY");
            
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);

            List<string> retValue = ForwardToLoadBalancer(new List<string> {"AddEntity",value.ToString(),name });
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "DeleteAll")]
        public void DeleteDatabase()
        {
            Console.WriteLine("Called method: DELETE DATABASE");
            
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);

            List<string> retValue = ForwardToLoadBalancer(new List<string> {"DeleteDatabase" });
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public void DeleteEntity(string Id)
        {
            Console.WriteLine("Called method: DELETE ENTITY");
            
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);

            List<string> retValue = ForwardToLoadBalancer(new List<string> {"DeleteEntity",Id.ToString() });
        }

       

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyID(string oldId, string newId)
        {
            Console.WriteLine("Called method: MODIFY ID");
            
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);

            List<string> retValue = ForwardToLoadBalancer(new List<string> {"modifyID", oldId.ToString(),newId.ToString() });
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyValue(string id, string newValue)
        {
            Console.WriteLine("Called method: MODIFY VALUE");
            
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);

            List<string> retValue = ForwardToLoadBalancer(new List<string> {"modifyValue",id.ToString(),newValue.ToString() });
        }


        //funkcija za konektovanje na load balancer i prosledjivanje zahteva
        static List<string> ForwardToLoadBalancer(List<string> actionAndParameters)
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            ChannelFactory<ILoadBalancer> factory = new ChannelFactory<ILoadBalancer>(binding, new
           EndpointAddress("net.tcp://localhost:9998/LoadBalancer"));
            ILoadBalancer proxy = factory.CreateChannel();
            List<string> returnValue = proxy.demandWork(actionAndParameters);
            return returnValue;
        }

        public string GetSecretKey()
        {
            return SecretKey.sKey;
        }
    }
    
}
