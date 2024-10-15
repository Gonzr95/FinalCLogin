using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final
{
    public class ADO
    {
        private string conexion;

        static ADO() { }

        public bool Agregar(Usuario usuario)
        {
            return true;
        }
        public bool Eliminar(Usuario usuario)
        {
            return true;
        }
        public bool Modificar(Usuario usuario)
        {
            return true;
        }
        public List<Usuario> ObtenerTodos()
        {
            return new List<Usuario>();
        }
        public List<Usuario> ObtenerTodos(string apellidoUsuario)
        {
            return new List<Usuario>();
        }

    }
}
