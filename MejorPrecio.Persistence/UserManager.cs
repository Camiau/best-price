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
    public class UserManager
    {
        private LoginModel _logedIn = new LoginModel();

        public LoginModel logedIn { get { return _logedIn; } }

        private static string conectionStringLocalDB;
        public UserManager()
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
        /// <summary>
        ///  Servira de auxilio para devolver los estados del login del usuario
        /// </summary>
        public enum SignInStatus
        {
            Success,
            Failure,
            RequiresVerification
        }

        /// <summary>
        ///  Servira de auxilio para devolver los estados del registro de usuario
        /// </summary>
        public enum SignUpStatus
        {
            Success,
            Failure

        }



        public SignUpStatus CreateUser(RegisterModel user)
        {
            var userExist = UserExist(user.Email, user.Dni);
            if (userExist == null)
            {
                ApplicationUser saveuser = new ApplicationUser()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Dni = user.Dni,
                    Email = user.Email,
                    EmailIsConfirmed = false
                };
                using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
                {
                    conn.Open();
                    //MODEL OF QUERY
                    //INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('fer','G',38324779,'fer@123.com','',1) 
                    SqlCommand myCommand = new SqlCommand("INSERT INTO users (nameUser,lastName,dni,mail,imagePath,idRol) VALUES('" + user.Name + "','" + user.Surname + "'," + user.Dni + ",'" + user.Email + "','" + user.ImagePath + "'," + 0 + ")", conn);
                    myCommand.ExecuteNonQuery();
                }

                return SignUpStatus.Success;

            }

            else
            {
                return SignUpStatus.Failure;
            }

        }

        public bool? ConfirmEmail(string email, long dni)

        {
            var result = UserExist(email, dni);


            if (result != null && !result.EmailIsConfirmed)
            {
                result.EmailIsConfirmed = true;
                using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
                {
                    conn.Open();
                    //MODEL OF QUERY
                    //UPDATE users SET emailIsConfirmed=1 WHERE idUser=1
                    SqlCommand myCommand = new SqlCommand("UPDATE users SET emailIsConfirmed=1 WHERE idUser=" + result.IdUser, conn);
                    myCommand.ExecuteNonQuery();
                    return true;
                }
            }
            else if (result.EmailIsConfirmed)
            {
                return false;
            }
            else return null;

        }

        public SignInStatus Login(LoginModel userLogin)
        {

            var user = UserExist(userLogin.Email, userLogin.Dni);

            if (user == null)
            {
                return SignInStatus.Failure;
            }
            if (!user.EmailIsConfirmed)
            {
                return SignInStatus.RequiresVerification;
            }

            else
            {
                this._logedIn.Dni = user.Dni;
                this._logedIn.Email = user.Email;
                return SignInStatus.Success;
            }
        }

        private ApplicationUser UserExist(string email, long dni)
        {
            ApplicationUser user = null;
            //SELECT example:
            //SELECT * FROM users WHERE users.mail='asdkddskds@adskjds.com' AND users.dni=39244338
            using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(@"SELECT * FROM users WHERE users.mail='" + email + "' AND users.dni=" + dni + "AND active=1", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    user = new ApplicationUser();
                    user.IdUser = int.Parse(myReader["iduser"].ToString());
                    user.Name = myReader["nameUser"].ToString();
                    user.Surname = myReader["lastName"].ToString();
                    user.Dni = int.Parse(myReader["dni"].ToString());
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
