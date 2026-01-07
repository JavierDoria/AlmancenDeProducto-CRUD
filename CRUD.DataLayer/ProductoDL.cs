using CRUD.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataLayer
{
    public class ProductoDL
    {
        public List<Producto> lista()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("ProductoListar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id_Producto = Convert.ToInt32(dr["Id_Producto"].ToString()),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                Categoria = new Categoria
                                {
                                    Id_Categoria = Convert.ToInt32(dr["Id_Categoria"].ToString()),
                                   Nombre  = dr["NombreCategoria"].ToString()
                                },
                                Imagen = new Imagen
                                {
                                    Id_Imagen = dr["Id_Imagen"] != DBNull.Value ? Convert.ToInt32(dr["Id_Imagen"]) : 0,
                                    UrlImagen = dr["UrlImagen"] != DBNull.Value ? dr["UrlImagen"].ToString() :null
                                },
                                Activo = Convert.ToBoolean(dr["Activo"])
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool crear(Producto entidad)
        {
            
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                // VALIDACIONES
                if (string.IsNullOrWhiteSpace(entidad.Codigo))
                    throw new Exception("El Codigo es obligatorio.");
                if (string.IsNullOrWhiteSpace(entidad.Nombre))
                    throw new Exception("El Nombre es obligatorio.");
                if (entidad.Precio <= 0)
                    throw new Exception("El Precio es obligatorio.");
                if (entidad.Cantidad <= 0)
                    throw new Exception("La Cantidad es obligatoria.");
                if (entidad.Categoria == null || entidad.Categoria.Id_Categoria <= 0)
                    throw new Exception("Debe seleccionar una Categoria.");
                if (string.IsNullOrWhiteSpace(entidad.Imagen.UrlImagen))
                    throw new Exception("La Imagen es obligatoria.");

                SqlCommand cmd = new SqlCommand("ProductoInsertar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", entidad.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@Precio", entidad.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", entidad.Cantidad);
                cmd.Parameters.AddWithValue("@Id_Categoria", entidad.Categoria.Id_Categoria);
                cmd.Parameters.AddWithValue("@Activo", entidad.Activo);
                cmd.Parameters.AddWithValue("@UrlImagen", entidad.Imagen.UrlImagen);

                oConexion.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
        }

        public Producto obtener(int idProducto)
        {
            Producto entidad = null;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("ProductoObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto", idProducto);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad = new Producto
                            {
                                Id_Producto = Convert.ToInt32(dr["Id_Producto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                Activo = Convert.ToBoolean(dr["Activo"]),
                                Categoria = new Categoria
                                {
                                    Id_Categoria = Convert.ToInt32(dr["Id_Categoria"])
                                },
                                Imagen = new Imagen
                                {
                                    Id_Imagen = dr["Id_Imagen"] != DBNull.Value ? Convert.ToInt32(dr["Id_Imagen"]) : 0,
                                    UrlImagen = dr["UrlImagen"] != DBNull.Value ? dr["UrlImagen"].ToString() : null
                                }
                            };
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
            return entidad;
        }

        public bool editar(Producto entidad)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("ProductoActualizar", oConexion);
                cmd.Parameters.AddWithValue("@Id_Producto", entidad.Id_Producto);
                cmd.Parameters.AddWithValue("@Codigo", entidad.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@Precio", entidad.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", entidad.Cantidad);
                cmd.Parameters.AddWithValue("@Id_Categoria", entidad.Categoria.Id_Categoria);
                cmd.Parameters.AddWithValue("@Activo", entidad.Activo);
                cmd.Parameters.AddWithValue("@UrlImagen", entidad.Imagen.UrlImagen);

                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;
                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool eliminar(int Id_Producto)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("ProductoEliminar", oConexion);
                cmd.Parameters.AddWithValue("@Id_Producto", Id_Producto);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;
                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
