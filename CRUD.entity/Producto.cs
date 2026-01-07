using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.entity
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Decimal Precio { get; set; }
        public Categoria Categoria { get; set; } = new Categoria();
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public Imagen Imagen { get; set; } = new Imagen();
    }
}
