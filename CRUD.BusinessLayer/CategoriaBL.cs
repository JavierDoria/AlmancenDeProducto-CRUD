using CRUD.DataLayer;
using CRUD.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BusinessLayer
{
    public class CategoriaBL
    {
        CategoriaDL categoriaDL = new CategoriaDL();

        public List<Categoria> Lista()
        {
            try
            {
                return categoriaDL.lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
