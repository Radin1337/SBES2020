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
        public void AddEntity(long Id, double value)
        {
            Console.WriteLine("Called method: ADD ENTITY");
            Console.WriteLine("Not implemented yet");
            IIdentity identity = Thread.CurrentPrincipal.Identity;

            Console.WriteLine("Autentification type : " + identity.AuthenticationType);

            WindowsIdentity windowsIdentity = identity as WindowsIdentity;

            Console.WriteLine("Client name : " + windowsIdentity.Name);     //checking who called method
        }
    }
}
