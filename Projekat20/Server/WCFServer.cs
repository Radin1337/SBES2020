using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
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
        }


        [PrincipalPermission(SecurityAction.Demand, Role = "Add")]
        public void AddEntity(string Id, string value,string name)
        {
            Console.WriteLine("Called method: ADD ENTITY");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);     //checking who called method
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "DeleteAll")]
        public void DeleteDatabase()
        {
            Console.WriteLine("Called method: DELETE DATABASE");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);     //checking who called method
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public void DeleteEntity(string Id)
        {
            Console.WriteLine("Called method: DELETE ENTITY");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);
        }

       

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyID(string oldId, string newId)
        {
            Console.WriteLine("Called method: MODIFY ID");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyValue(string id, string newValue)
        {
            Console.WriteLine("Called method: MODIFY VALUE");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name); // who called ModifyValue
            //Console.WriteLine("Jedinstveni identifikator : " + windowsIdentity.User);
        }

        public string GetSecretKey()
        {
            return SecretKey.sKey;
        }
    }
}
