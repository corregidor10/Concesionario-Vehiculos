using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Concesionario_Vehiculos_18_11.Seguridad
{
    public class IdentityPersonalizado : IIdentity //EL IDENTITY ES LA IDENTIDAD DEL USUARIO, CON LOS DATOS QUE VAMOS A NECESITAR EN NUESTRO PROYECTO
    {
        public string Name
        {
            get { return Login; }
        }

        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        public int idUsuario { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public String Rol { get; set; }
        public IIdentity Identity { get; set; }
        public String Email { get; set; }



        public IdentityPersonalizado(IIdentity identity)
        {
            this.Identity = identity;

            var us = Membership.GetUser(identity.Name) as UsuarioMemberShip;
            Nombre = us.Nombre;
            Apellidos = us.Apellidos;
            Login = us.Login;
            idUsuario = us.idUsuario;
            Rol = us.Rol;
            Email = us.Email;
        }
    }
}
