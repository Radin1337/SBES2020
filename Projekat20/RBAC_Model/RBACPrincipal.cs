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

        public bool IsInRole(string permission)
        {
            foreach (IdentityReference group in this.identity.Groups)//prolazimo kroz sve grupe, pokusavamo da izvucemo grupu odredjenu
            {
                SecurityIdentifier sid = (SecurityIdentifier)group.Translate(typeof(SecurityIdentifier)); // za svaku grupu dolazimo do imena
                var name = sid.Translate(typeof(NTAccount));
                string groupName = Formatter.ParseName(name.ToString());// dolazimo do imena same grupe
                string[] permissions;
                if (RolesConfig.GetPermissions(groupName, out permissions))// da li neka grupa ima tu permisiju,ako postoji grupa, dobijamo permsije u nizu stringova
                {
                    foreach (string permision in permissions) //prolazimo kroz sve prermisije
                    {
                        if (permission.Equals(permission))//proveravamo da li se permisije podudaraju iz grupe  sa permisijom koja je stigla kao parametar
                            return true;
                    }
                    // return permissions.Contains(permission);                   
                }
            }
            return false;
        }
    }
}
