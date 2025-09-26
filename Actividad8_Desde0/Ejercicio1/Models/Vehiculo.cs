using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Vehiculo:IExportable,IComparable
    {
        public string Patente { get; private set; }//accesible pero no se pude escribir 
        public double Importe { get; private set; }// accesible pero no se pude escribir 

        public Vehiculo() { }//Constructor vacio 

        public string ToString()
        {
            return $"{Patente} ${Importe}\r\n";//para agregarlo al text box y bajarle una linea 
        }
        public void AgregarMulta(double importe)
        {
            this.Importe = importe;
        }
        public int CompareTo(Object? obj)//para comparar por al patente 
        {
            Vehiculo vehiculo = obj as Vehiculo;    
            if (vehiculo!=null)
            {
                return Patente.CompareTo(vehiculo.Patente);
            }

            return -1;
        }

        public void Importar(string cadena)//procesar la cadena y asignar atributos 
        {
            cadena = cadena.Trim();
            string[] separador = cadena.Split(';');//separador por el ;
            string patente = separador[0];// asignados el lugar a travez del vector 
            double importe = Convert.ToDouble(separador[1]);

            if (patente.Length == 6 || patente.Length == 7)//si tiene el largo de la patente 
            {
                Patente = patente;//le asigno 
            }
            else
            {
                throw new PatenteExeption();
            }//sino lanzo la excepcion 
            this.Importe = Importe;//le asigno 


        }

        public string Exportar()
        {
            return $"{Patente} ${Importe}";
        }
    }
}
