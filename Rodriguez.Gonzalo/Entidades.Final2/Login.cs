using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final2
{
    public class Login
    {
        private string email;
        private string pass;


        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public Login(string correo, string clave)
        {
            this.email = correo;
            this.pass = clave;
        }



        public bool Loguear()
        {
            List<Usuario> users = ADO.ObtenerTodos();
            foreach (Usuario usuario in users) 
            {
                if (this.email == usuario.Correo)
                {
                    if (this.pass == usuario.Clave) return true;
                    else return false;  
                }
            }
            return false;
        }


    }
}
