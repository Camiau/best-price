
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
using System.Data;

public class RoleRepository
{
    private static string conectionStringLocalDB = Environment.GetEnvironmentVariable("conectionStringLocalDB");
    public List<Role> InitRoles()
    {
        var roleList = new List<Role>();
        using (var conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            using (var command = conn.CreateCommand())
            {
                command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                command.CommandText = @"SELECT * FROM roles";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var roleToInit = new Role();
                        roleToInit.Id = (Guid)reader["idRole"];
                        roleToInit.RoleName =(string) reader["role"];
                        roleList.Add(roleToInit);
                    }
                }
            }
        }
        return roleList;
    }
}
//sql guid newid()