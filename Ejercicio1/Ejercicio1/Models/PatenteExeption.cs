using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class PatenteExeptio: ApplicationException
    {
        public PatenteExeptio():base ("Patente invalida") { }

        public PatenteExeptio(string message) : base(message) { }
        public PatenteExeptio(string? message, Exception innerException) : base(message, innerException) {}
    }
}
