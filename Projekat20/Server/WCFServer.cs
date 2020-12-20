using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class WCFServer : ISpecialUsers
    {

        public void GetElectricityConsumption(string imeprezime, int uid)
        {
            Console.WriteLine("GetElectricityConsumption");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);
        }


        [PrincipalPermission(SecurityAction.Demand, Role = "Add")]
        public void AddEntity(long Id, double value,string name)
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
        public void DeleteEntity(long Id)
        {
            Console.WriteLine("Called method: DELETE ENTITY");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);
        }

       

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyID(long oldId, long newId)
        {
            Console.WriteLine("Called method: MODIFY ID");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyValue(long id, double newValue)
        {
            Console.WriteLine("Called method: MODIFY VALUE");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Authentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name); // who called ModifyValue
            //Console.WriteLine("Jedinstveni identifikator : " + windowsIdentity.User);
        }
    }
}
