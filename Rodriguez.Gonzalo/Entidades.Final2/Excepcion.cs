using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final2
{
    public class Excepcion1 : Exception
    {
        public Excepcion1(string mensaje) : base (mensaje) { }

        public Excepcion1(string mensaje, Exception innerException) : base (mensaje, innerException) { }

    }
}
