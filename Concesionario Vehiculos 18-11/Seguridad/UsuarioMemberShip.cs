using System;
using System.Configuration;
using System.Runtime.Serialization;
using System.Web.Security;
using Concesionario_Vehiculos_18_11.Models;
using Concesionario_Vehiculos_18_11.Utilidades;

namespace Concesionario_Vehiculos_18_11.Seguridad
{
    public class UsuarioMemberShip : MembershipUser //USUARIO MEMBERSHIP ES EN NEXO DE UNION ENTRE BBDD Y NUESTRO IDENTITY

    {
        public int idUsuario { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public String Rol { get; set; }
        public override String Email { get; set; }

        public UsuarioMemberShip(Usuario us)
        {
           idUsuario = us.idUsuario;
            Nombre = us.Nombre;
            Apellidos = us.Apellidos;
            Rol = us.Rol.NombreRol;
            Email = us.email;
            Login = us.Login;
        }
    }
    }
    