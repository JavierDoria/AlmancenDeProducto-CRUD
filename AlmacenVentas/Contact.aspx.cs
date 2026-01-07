using Antlr.Runtime.Misc;
using CRUD.BusinessLayer;
using CRUD.entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmacenVentas
{
    public partial class Contact : Page
    {
        private static int Id_Producto = 0;
        CategoriaBL categoriaBL = new CategoriaBL();
        ProductoBL productoBL = new ProductoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id_Producto"] != null)
                {
                    Id_Producto = Convert.ToInt32(Request.QueryString["Id_Producto"].ToString());

                    if (Id_Producto != 0)
                    {
                        lblTitulo.Text = "Editar Producto";
                        btnSubmit.Text = "Actualizar";

                        Producto producto = productoBL.obtener(Id_Producto);
                        txtCodigo.Text = producto.Codigo;
                        TxtNombre.Text = producto.Nombre;
                        txtPrecio.Text = producto.Precio.ToString();
                        txtCantidad.Text = producto.Cantidad.ToString();
                        CargarCategoria(producto.Categoria.Id_Categoria.ToString());
                        txtImagen.Text = producto.Imagen.UrlImagen;
                        chkActivo.Checked = producto.Activo;
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Producto";
                        btnSubmit.Text = "Guardar";
                        CargarCategoria();
                    }
                }
                else Response.Redirect("~/Default.aspx");
            }
        }

        private void CargarCategoria(string Id_Categoria = "")
        {
            List<Categoria> lista = categoriaBL.Lista();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "Id_Categoria";

            ddlCategoria.DataSource = lista;
            ddlCategoria.DataBind();
            if (Id_Categoria != "")
                ddlCategoria.SelectedValue = Id_Categoria;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                ScriptManager.RegisterStartupScript(
                    this, this.GetType(), "msg",
                    "alert('El Codigo  es obligatorio');", true);
                return;
            }
            if (ddlCategoria.SelectedValue == null || ddlCategoria.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(
                    this, this.GetType(), "msg",
                    "alert('Debe seleccionar una Categoria');", true);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Any, new CultureInfo("es-PE"), out decimal precio))
            {
                ScriptManager.RegisterStartupScript(
                    this, this.GetType(), "msg",
                    "alert('Debe ingresar un precio válido');", true);
                return;
            }
            Producto entidad = new Producto()
            {
                Id_Producto = Id_Producto,
                Codigo = txtCodigo.Text,
                Nombre = TxtNombre.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text, new CultureInfo("es-PE")),
                Categoria = new Categoria() { Id_Categoria = Convert.ToInt32(ddlCategoria.SelectedValue) },
                Cantidad = int.Parse(txtCantidad.Text),
                Activo = chkActivo.Checked,
                Imagen = new Imagen() {UrlImagen = txtImagen.Text }
            };
            try
            {
                bool respuesta;

                if (Id_Producto != 0)
                    respuesta = productoBL.editar(entidad);
                else
                    respuesta = productoBL.crear(entidad);

                if (respuesta)
                {
                    //ScriptManager.RegisterStartupScript(
                    //   this,
                    //   GetType(),
                    //   "redirect",
                    //   "alert('Producto guardado correctamente');" +
                    //   "setTimeout(function(){ window.location='Default.aspx'; }, 700);",
                    //   true);
                    ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "redirect",
                    @"
                    var d=document,
                        o=d.createElement('div'),
                        b=d.createElement('div');

                    o.style='position:fixed;inset:0;background:rgba(0,0,0,.4);display:flex;align-items:center;justify-content:center;z-index:9999';
                    b.style='background:#fff;padding:25px 35px;border-radius:8px;box-shadow:0 10px 25px rgba(0,0,0,.2);text-align:center;font-family:Arial';

                    b.innerHTML='<div style=""font-size:42px;color:#28a745"">&#10004;</div><div style=""font-size:18px;color:#333"">Producto guardado correctamente</div>';

                    o.appendChild(b);
                    d.body.appendChild(o);

                    setTimeout(function(){ location.href='Default.aspx'; },2000);
                    ",
                    true
                );
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                        this, GetType(), "msg",
                        "alert('No se pudo realizar la operación');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(
                    this, GetType(), "error",
                    $"alert('{ex.Message}');", true);
            }
        }
    }
}