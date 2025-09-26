using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Vehiculo: IExportable, IComparable
    {
        public string Patente { get; private set; }
        public double Importe { get; private set; }

        public Vehiculo(){}

        public void importar(string cadena)
        {
            cadena = cadena.Trim();
            string[] separator = cadena.Split(';');
            string patente = separator[0];
            double importe = Convert.ToDouble(separator[1]);

            if (patente.Length == 6 || patente.Length == 7)
            {
                Patente = patente;
            }
            else
            {
                throw new PatenteExeptio();
            }
            this.Importe = importe;
        }

        public string Exportar()
        {
            return $"{Patente} {Importe}";
        }

        public string ToString()
        {
            return $"{Patente}  ${Importe}\r\n";
        }
        public void AgregarMulta(double importe)
        {
            this.Importe += importe;
        }

        public int CompareTo(object? obj)
        {
            Vehiculo vehiculo = obj as Vehiculo;
            if (vehiculo != null)
            {
                return Patente.CompareTo(vehiculo.Patente);
            }

            return -1;
        }
    }
}
