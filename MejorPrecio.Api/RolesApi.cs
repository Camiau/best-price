using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class RolesApi
    {
        public List<Role> GetAllRoles()
        {
            var dbRole = new RoleRepository();
            return dbRole.InitRoles();
        }
        public Role GetRoleById(Guid idRolToFind)
        {
            var dbRole = new RoleRepository();
            return dbRole.GetRoleByIdRole(idRolToFind);
        }
        /*public bool HavePermition(ApplicationUser currentUser, string permition)
        {
            var dbRole=new RoleRepository();
            var roleList=dbRole.InitRoles();

            if (currentUser.IdRol == roleList[0].Id)
            {

            }

            switch (currentUser.IdRol)
            {
                case dbRole[0].IdRol:
                break;
                default:
                break;
            }
            /*switch (permition)
            {
                case "ConfirmEmail":
                    if (currentUser.IdRol == idRolDefender || currentUser.IdRol == idRolAdmin)
                    {
                        return true;
                    }
                    else { return false; }
                    break;
                default:
                    return false;
            }
            return true;
            switch (currentUser.IdRol)
            {
                case (Guid)("607263FD-F917-483F-A5BC-5B022455D632"):
                System.Console.WriteLine("sadsfd");
                break;
                default:
            }
        }*/
    }
}
/*
//var currentRole=GetCurrentRole();
var roleApiInit = new RolesApi();
            bool permitionOK = roleApiInit.havePermition(ApplicationUser this, string nameFN);
            if (permitionOK)
            {

            }
            else
            { System.Console.WriteLine("Forbidden accses"); }
            if (currentRole.RoleName == "admin" || currentRole.RoleName == "defender")
                if (currentRole.Id == new Guid("607263FD-F917-483F-A5BC-5B022455D632") || currentRole.Id == new Guid("90771623-A26E-4975-9EC0-A1C81F115D4B"))
                {

                }
 */
