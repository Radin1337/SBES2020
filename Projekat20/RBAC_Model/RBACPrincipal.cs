using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RBAC_Model
{
    public class RBACPrincipal : IPrincipal
    {
        WindowsIdentity identity = null;

        public RBACPrincipal(WindowsIdentity windowsIdentity) 
        {
            identity = windowsIdentity;
        }

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
