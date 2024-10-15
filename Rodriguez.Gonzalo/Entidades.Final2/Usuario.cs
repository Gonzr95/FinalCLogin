using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final2
{
    public class Usuario
    {
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }

        }
        private int dni;

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public Usuario() { }
        public Usuario(string nombre, string apellido, int dni, string correo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.correo = correo;
        }
        public Usuario(string nombre, string apellido, int dni, string correo, string clave)
            : this(nombre, apellido, dni, correo)
        {
            this.clave = clave;
        }

        public override string ToString()
        {
            return this.nombre + " " + this.apellido + " " + this.correo + " " + this.dni;
        }
    }
}
