using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class PatenteExeption:ApplicationException
    {
        public PatenteExeption():base("Patente invalida") { }
        public PatenteExeption(string message) : base(message) { }
        public PatenteExeption(string? message, Exception innerException) : base(message,innerException) { }
    }
}
