using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class PermissionApi
    {
        public bool CouldI(Guid idRole, string permissionToAccessName)
        {
            var myRoleApi = new RolesApi();
            var myRole = myRoleApi.GetRoleById(idRole);
            var myPermissionRepo = new PermissionRepository();
            var permissionToAccess= myPermissionRepo.GetPermissionByName(permissionToAccessName);
            return myPermissionRepo.ThisRolehavePermissions(myRole, permissionToAccess);
        }
        public Permission GetPermissionByName(string permitionName)
        {
            var myPermissionRepo = new PermissionRepository();
            return myPermissionRepo.GetPermissionByName(permitionName);
        }
    }
}