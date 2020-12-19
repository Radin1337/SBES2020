using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class WCFServer : ISpecialUsers
    {
        public void AddEntity(long Id, double value,string name)
        {
            Console.WriteLine("Called method: ADD ENTITY");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Autentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);     //checking who called method
        }

        public void DeleteDatabase()
        {
            Console.WriteLine("Called method: DELETE DATABASE");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Autentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);     //checking who called method
        }

        public void DeleteEntity(long Id)
        {
            Console.WriteLine("Called method: DELETE ENTITY");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Autentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);
        }

        public void ModifyID(long oldId, long newId)
        {
            Console.WriteLine("Called method: MODIFY ID");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Autentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);
        }

        public void ModifyValue(long id, double newValue)
        {
            Console.WriteLine("Called method: MODIFY VALUE");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Autentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name); // who called ModifyValue
            //Console.WriteLine("Jedinstveni identifikator : " + windowsIdentity.User);
        }
    }
}
