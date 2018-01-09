using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
using System.Data;

public class PermissionRepository
{
    private static string conectionStringLocalDB = Environment.GetEnvironmentVariable("conectionStringLocalDB");
    public List<Permission> GetPermissionsByRole(Role myRole)
    {
        var ret = new List<Permission>();
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"SELECT permission.* FROM permission 
INNER JOIN permissionRole ON permissionRole.idPermission = permission.idPermission
INNER JOIN roles ON roles.idRole=permissionRole.idRole
WHERE permissionRole.idRole=@idRole
AND permissionRole.active=1";
                command.Parameters.AddWithValue("@idRole", myRole.Id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var myPermision = new Permission();
                        myPermision.IdPermission = (Guid)reader["idPermission"];
                        myPermision.PermissionName = reader["permission"].ToString();
                        ret.Add(myPermision);
                    }
                }
            }
        }
        return ret;
    }
    public bool ThisRolehavePermissions(Role myRole, Permission myPermision)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"SELECT permission.* FROM permission 
                INNER JOIN permissionRole ON permissionRole.idPermission = permission.idPermission
                INNER JOIN roles ON roles.idRole=permissionRole.idRole
                WHERE permissionRole.idRole=@idRole
                AND permissionRole.idPermission=@idPermission
                AND permissionRole.active=1";
                command.Parameters.AddWithValue("@idRole", myRole.Id);
                command.Parameters.AddWithValue("@idPermission", myPermision.IdPermission);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public Permission GetPermissionByName(string name)
    {
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"SELECT * FROM permission WHERE permission=@name AND active=1";
                command.Parameters.AddWithValue("@name", name);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var newPermission=new Permission();
                        newPermission.IdPermission=(Guid)reader["idPermission"];
                        newPermission.PermissionName=reader["permission"].ToString();
                        return newPermission;
                    }
                }
            }
        }
        return null;
    }
}