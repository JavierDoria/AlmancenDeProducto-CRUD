using CRUD.DataLayer;
using CRUD.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BusinessLayer
{
    public class LoginBL
    {
        LoginDL dao = new LoginDL();

        public Usuario Login(string email, string password)
        {
            return dao.Autenticar(email, password);
        }
    }
}
