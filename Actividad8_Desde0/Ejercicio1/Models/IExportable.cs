using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public interface IExportable //Interfaz para aplicar a la hora de exportar
    {
        void Importar(string cadena);// para importar 

        string Exportar(); // para exxportar 
    }
}
