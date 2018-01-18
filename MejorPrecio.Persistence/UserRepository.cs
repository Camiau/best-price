using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
using System.Data;
namespace MejorPrecio.Persistence
{
    /// <summary>
    ///  Manejara las operaciones de login, registro y validación del estado del usuario
    /// </summary>
    public class UserRepository
    {
        private SimpleUserModel _logedIn = new SimpleUserModel();

        public SimpleUserModel logedIn { get { return _logedIn; } }
        private static string conectionStringLocalDB = Environment.GetEnvironmentVariable("conectionStringLocalDB");
        public bool CreateUser(ApplicationUser user)
        {
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('@userName', '@userSurname', '@userDni', '@userEmail', '@userImagePath ', '@idRol')";
                    command.Parameters.AddWithValue("@username", user.Name);
                    command.Parameters.AddWithValue("@userSurname", user.Surname);
                    command.Parameters.AddWithValue("@userDni", user.Dni);
                    command.Parameters.AddWithValue("@userEmail", user.Email);
                    command.Parameters.AddWithValue("@userImagePath", user.ImagePath);
                    command.Parameters.AddWithValue("@idRol", 0);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        public void ConfirmEmail(ApplicationUser user)
        {
            user.EmailIsConfirmed = true;
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE users SET emailIsConfirmed=1 WHERE idUser=@id";
                    command.Parameters.AddWithValue("@id", user.IdUser);
                    command.ExecuteNonQuery();
                }
            }
        }


        public ApplicationUser UserExist(string email, string dni)
        {
            ApplicationUser user = null;
            //SELECT example:
            //SELECT * FROM users WHERE users.mail='asdkddskds@adskjds.com' AND users.dni='39244338'
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT * FROM users WHERE users.mail=@email AND users.dni=@dni AND active=1";
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@dni", dni);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new ApplicationUser();
                            user.IdUser = (Guid)reader["iduser"];
                            user.Name = reader["nameUser"].ToString();
                            user.Surname = reader["lastName"].ToString();
                            user.Dni = reader["dni"].ToString();
                            user.Email = reader["mail"].ToString();
                            user.ImagePath = reader["imagePath"].ToString();
                            user.IdRol =(Guid)reader["idRole"];
                            user.EmailIsConfirmed = bool.Parse(reader["EmailIsConfirmed"].ToString());
                        }
                    }
                }
            }
            return user;
        }

        public ApplicationUser GetUserById(Guid idUser)
        {
            var user = new ApplicationUser();

            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;//Excecute scalar devele el 1er valor de la primera fila que devolveria
                    command.CommandText = @"SELECT * FROM users WHERE idUser=@idUs";
                    command.Parameters.AddWithValue("@idUs", idUser);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user.Name = reader["nameUser"].ToString();
                            user.Surname = reader["lastName"].ToString();
                            user.Dni = reader["dni"].ToString();
                            user.Email = reader["mail"].ToString();
                            user.ImagePath = reader["imagePath"].ToString();
                            user.IdRol = (Guid)reader["idRol"];
                            user.EmailIsConfirmed = bool.Parse(reader["EmailIsConfirmed"].ToString());
                        }
                        else
                        {
                            user = null;
                        }
                    }
                }
            }
            return user;
        }

    }
}
