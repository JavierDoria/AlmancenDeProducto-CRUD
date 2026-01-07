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
    public partial class _Default : Page
    {
        ProductoBL productoBL = new ProductoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarProducto();
        }
        private void MostrarProducto()
        {
            List<Producto> lista = productoBL.lista();
            GVProducto.DataSource = lista;
            GVProducto.DataBind();
        }
        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx?Id_Producto=0");
        }
        protected void Editar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string Id_Producto = btn.CommandArgument;
            Response.Redirect($"~/Contact.aspx?Id_Producto={Id_Producto}");
        }
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string Id_Producto = btn.CommandArgument;
            bool respuesta = productoBL.eliminar(Convert.ToInt32(Id_Producto));
            if (respuesta)
                MostrarProducto();
        }
    }
}