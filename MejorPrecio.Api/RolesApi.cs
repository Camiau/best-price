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
            var dbRole=new RoleRepository();
            return dbRole.InitRoles();
        }
    }
}
