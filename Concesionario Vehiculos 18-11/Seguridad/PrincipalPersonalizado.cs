using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario_Vehiculos_18_11.Seguridad
{
 public class PrincipalPersonalizado:IPrincipal // EL PRINCIPAL ACTUA COMO EL CONTENEDOR DEL IDENTITY Y EL COMPROBADOR DE ROLES
    {
     public bool IsInRole(string role)
     {

         return MiIdentidadPersonal.Rol == role;

            //if (MiIdentidadPersonal.Rol==role)
            //{
            //    return true;            EXACTAMENTE IGUAL
            //}
            //return false; 
        }

        public IIdentity Identity { get; private set; }

     public IdentityPersonalizado MiIdentidadPersonal
     {
         get { return (IdentityPersonalizado) Identity; }
            set { Identity = value; }
     }

     public PrincipalPersonalizado(IdentityPersonalizado identity)
     {
         Identity = identity;
     }

    }
}
