using CRUD.DataLayer;
using CRUD.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BusinessLayer
{
    public class ProductoBL
    {
        ProductoDL productoDL = new ProductoDL();
        public List<Producto> lista()
        {
            try
            {
                return productoDL.lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Producto obtener(int Id_Producto)
        {
            try
            {
                return productoDL.obtener(Id_Producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool crear(Producto entidad)
        {
            try
            {
                if (entidad.Codigo == "")
                    throw new OperationCanceledException("El Codigo no puede ser vacio");
                return productoDL.crear(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool editar(Producto entidad)
        {
            try
            {
                var encontrar = productoDL.obtener(entidad.Id_Producto);
                if (encontrar.Id_Producto == 0)
                    throw new OperationCanceledException("No existe empleado");
                return productoDL.editar(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool eliminar(int Id_Producto)
        {
            try
            {
                var encontrar = productoDL.obtener(Id_Producto);
                if (encontrar.Id_Producto == 0)
                    throw new OperationCanceledException("No existe empleado");
                return productoDL.eliminar(Id_Producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
