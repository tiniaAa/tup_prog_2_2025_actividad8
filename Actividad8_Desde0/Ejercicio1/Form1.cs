using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        List <Vehiculo> vehiculos = new List<Vehiculo> ();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opDialog = new OpenFileDialog(); // ventana modal para seleccionar el archivo 

            opDialog.Filter = "Archivo CSV|*.csv|Todos los archivos|*.*"; // Filto para archivos

            if (opDialog.ShowDialog()==DialogResult.OK)// lanzar la modal 
            {
                string nombre = opDialog.FileName;//guardar el nombre

                FileStream fs = null;// conector (como conectar con la manguera el archivo con el proyecto ) todavia no creado 
                StreamReader sr = null; // Para leer el archivo , todavia no creado 

                try
                {
                    fs = new FileStream(nombre, FileMode.Open, FileAccess.Read); // creo la manguera conectora
                    sr = new StreamReader(fs);// creo el lector del archivo 
                    sr.ReadLine();//leo una linea para y no la guardo en ningun lado para saltearla 


                    while (sr.EndOfStream != true)//mientras no sea la linea final del texto se repite 
                    {
                        string cadena = sr.ReadLine().Trim();//leo la linea y la guardo, y saco los espacion 
                        Vehiculo vehiculo = new Vehiculo();//creo el vehiculo 
                        vehiculos.Sort();//ordeno la lista vehiculos 
                        vehiculo.importar(cadena); //le paso la cadena("Lo que tiene los atributos digamos, para asignarlo dentro de vehiculo ")
                        int idx = vehiculos.BinarySearch(vehiculo);//busco el vehiculo 
                        if (idx >= 0)
                        {
                            vehiculos[idx].AgregarMulta(vehiculo.Importe); //si el vehiculo existe le agrego el importe a la multa

                        }
                        else { vehiculos.Add(vehiculo); } // sino lo añado a la lista
                    }
                    textBox1.Text = " ";//no me aacuerdo que hace¿¿¿
                    foreach (Vehiculo v in vehiculos)
                    {
                        textBox1.Text += v.ToString(); //agrego la patente y el importe a pagar 
                    }
                }
                catch (PatenteExeption p)//capturar la excepcion
                { MessageBox.Show(p.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }//excepcion de la patente, muestro el mensaje, le agrego boton ok y icono de error 
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }//excepcion de la patente, muestro el mensaje, le agrego boton ok y icono de error 
                finally
                {
                    if ( sr !=null) sr.Close();//cierro el lector del archivo para que no quede colgado 
                    if (fs!=null) fs.Close();//cierro la coneccion del archivo para evitar errores 
                }
            }




        }
    }
}
