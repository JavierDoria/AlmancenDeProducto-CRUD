using CRUD.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataLayer
{
    public class LoginDL
    {
        public Usuario Autenticar(string email, string password)
        {
            Usuario entidad = null;
            string passwordHash;
            
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                passwordHash = Convert.ToBase64String(hash);
            }
            System.Diagnostics.Debug.WriteLine("Hash generado: " + passwordHash);
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("LoginUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new Usuario
                        {
                            Id_Login = Convert.ToInt32(dr["Id_Login"]),
                            Email = dr["Email"].ToString()
                        };
                    }
                }
            }
            return entidad;
        }

    }
}
