using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;

namespace MejorPrecio.Persistence
{
    /// <summary>
    ///  Manejara las operaciones de login, registro y validación del estado del usuario
    /// </summary>
    public class UserRepository
    {
        private LoginModel _logedIn = new LoginModel();

        public LoginModel logedIn { get { return _logedIn; } }

        private static string conectionStringLocalDB;
        public UserRepository()
        {
            var userLocal = Environment.UserName;
            switch (userLocal)
            {
                case "gastonh_lu":
                    conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
                    break;
                case "iskandar":
                    conectionStringLocalDB = @"Data Source=172.17.0.2,1433;Initial Catalog=mejorprecio6;User ID=sa;Password=<Clave_Segura1234>";
                    break;
                case "camilaf_lu":
                    conectionStringLocalDB =  @"Server=DESKTOP-TBLA16F\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True;";
                    break;
                default:
                    conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
                    break;
            }
        }

        public bool CreateUser(ApplicationUser user)
        {
                using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
                {
                    conn.Open();
                    //MODEL OF QUERY
                    //INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('fer','G',38324779,'fer@123.com','',1) 
                    SqlCommand myCommand = new SqlCommand("INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('" + user.Name + "','" + user.Surname + "'," + user.Dni + ",'" + user.Email + "','" + user.ImagePath + "'," + 0 + ")", conn);
                    myCommand.ExecuteNonQuery();
                }
                return true;

        }
        public bool ConfirmEmail(ApplicationUser user)
        {
                user.EmailIsConfirmed = true;
                using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
                {
                    conn.Open();
                    //MODEL OF QUERY
                    //UPDATE users SET emailIsConfirmed=1 WHERE idUser=1
                    SqlCommand myCommand = new SqlCommand("UPDATE users SET emailIsConfirmed=1 WHERE idUser=" + user.IdUser, conn);
                    myCommand.ExecuteNonQuery();
                    return true;
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
                SqlDataReader myReader = null;
                var query=@"SELECT * FROM users WHERE users.mail='" + email + "' AND users.dni='" + dni + "' AND active=1";
                SqlCommand myCommand = new SqlCommand(query, conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    user = new ApplicationUser();
                    user.IdUser = int.Parse(myReader["iduser"].ToString());
                    user.Name = myReader["nameUser"].ToString();
                    user.Surname = myReader["lastName"].ToString();
                    user.Dni = myReader["dni"].ToString();
                    user.Email = myReader["mail"].ToString();
                    user.ImagePath = myReader["imagePath"].ToString();
                    user.IdRol = int.Parse(myReader["idRol"].ToString());
                    user.EmailIsConfirmed = bool.Parse(myReader["EmailIsConfirmed"].ToString());
                }
            }
            return user;
        }

    }
}
