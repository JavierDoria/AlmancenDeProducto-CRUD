using CRUD.BusinessLayer;
using CRUD.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmacenVentas
{
    public partial class Login : System.Web.UI.Page
    {
        LoginBL loginBL = new LoginBL();


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtener email y contraseña ingresados
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validar usuario mediante la capa de negocio
            // loginBL.Login debe retornar un objeto Usuario si los datos son correctos
            Usuario usuario = loginBL.Login(email, password);

            if (usuario != null)
            {
                // Guardar datos en sesión
                Session["Id_Login"] = usuario.Id_Login;
                Session["Usuario"] = usuario.Email;

                // Redirigir a la página principal
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // Mostrar mensaje de error
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "msg",
                    "alert('Correo o contraseña incorrectos');",
                    true
                );

                // Limpiar campo de contraseña
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
            }
        }
    }
}