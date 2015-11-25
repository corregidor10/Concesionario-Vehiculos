using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Concesionario_Vehiculos_18_11.Models;
using Concesionario_Vehiculos_18_11.Utilidades;

namespace Concesionario_Vehiculos_18_11.Seguridad
{
  public class ProveedorRol:RoleProvider
    {
      public override bool IsUserInRole(string username, string roleName) // nos devuelve si un usuario esta en el rol o no
      {
         
          using (var db= new Concesionario20Entities())
          {
              
              try
              {
                    var us = db.Usuario.First((o => o.Login == username));
                    return us.Rol.NombreRol == roleName;
              }
              catch (Exception)
              {
                  return false;
              }
          }
      }

      public override string[] GetRolesForUser(string username)
      {
     

            using (var db = new Concesionario20Entities())
            {
                var us = db.Usuario.First((o => o.Login == username));
                try
                {
                    return new[] {us.Rol.NombreRol};
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

      public override void CreateRole(string roleName)
      {
          throw new NotImplementedException();
      }

      public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
      {
          throw new NotImplementedException();
      }

      public override bool RoleExists(string roleName)
      {
          throw new NotImplementedException();
      }

      public override void AddUsersToRoles(string[] usernames, string[] roleNames)
      {
          throw new NotImplementedException();
      }

      public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
      {
          throw new NotImplementedException();
      }

      public override string[] GetUsersInRole(string roleName)
      {
          throw new NotImplementedException();
      }

      public override string[] GetAllRoles()
      {
          throw new NotImplementedException();
      }

      public override string[] FindUsersInRole(string roleName, string usernameToMatch)
      {
          throw new NotImplementedException();
      }

      public override string ApplicationName { get; set; }
    }
    
}
