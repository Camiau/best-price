using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class PermissionApi
    {
        public bool CouldI(Guid idRole, Permission permissionToAccess)
        {
            var myRoleApi = new RolesApi();
            var myRole = myRoleApi.GetRoleById(idRole);
            var myPermissionRepo = new PermissionRepository();
            return myPermissionRepo.ThisRolehavePermissions(myRole, permissionToAccess);
        }
    }
}