using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using System.Data.SqlClient;
public class UserManager
{
    private static string conectionStringLocalDB = @"Server=DESKTOP-3MV52PP\SQLEXPRESS;Database=mejorprecio6;Trusted_Connection=True";
    public enum SignInStatus
    {
        Success,
        Failure,
        RequiresVerification
    }

    public enum SignUpStatus
    {
        Success,
        Failure,

    }
    public static bool ConfirmEmail(string email, long dni)

    {
        var result = UserExist(email, dni);

        if (result != null)
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
        else return false;

    }

    public static Task<SignUpStatus> CreateUserAsync(RegisterModel user)
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
            return Task.FromResult<SignUpStatus>(SignUpStatus.Success);

        }

        else
        {
            return Task.FromResult<SignUpStatus>(SignUpStatus.Failure);
        }

    }


    public static SignInStatus Login(LoginModel userLogin)
    {

        var user = UserExist(userLogin.Email, userLogin.Dni);
        if (user == null)
        {
            //return Task.FromResult<SignInStatus>(SignInStatus.Failure);
            return SignInStatus.Failure;
        }
        if (!user.EmailIsConfirmed)
        {
            //return Task.FromResult<SignInStatus>(SignInStatus.RequiresVerification);
            return SignInStatus.RequiresVerification;
        }

        else
            //return Task.FromResult<SignInStatus>(SignInStatus.Success);
            return SignInStatus.Success;
    }

    private static ApplicationUser UserExist(string email, long dni)
    {
        ApplicationUser userexist = null;
        //SELECT example:
        //SELECT * FROM users WHERE users.mail='asdkddskds@adskjds.com' AND users.dni=39244338
        using (SqlConnection conn = new SqlConnection(conectionStringLocalDB))
        {
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(@"SELECT * FROM users WHERE users.mail='" + email + "' AND users.dni=" + dni, conn);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                userexist = new ApplicationUser();
                userexist.IdUser = int.Parse(myReader["iduser"].ToString());
                userexist.Name = myReader["nameUser"].ToString();
                userexist.Surname = myReader["lastName"].ToString();
                userexist.Dni = int.Parse(myReader["dni"].ToString());
                userexist.Email = myReader["mail"].ToString();
                userexist.ImagePath = myReader["imagePath"].ToString();
                userexist.IdRol = int.Parse(myReader["idRol"].ToString());
            }
        }
        return userexist;
    }

}

/// <summary>
///  Servira de auxilio para devolver los estados del login del usuario
/// </summary>


/// <summary>
///  Servira de auxilio para devolver los estados del registro de usuario
/// </summary>