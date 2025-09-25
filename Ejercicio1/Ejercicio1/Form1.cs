using Ejercicio1.Models;
using System.Reflection;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            

            //string path = "unArchivo.csv";
            //string[] lines = File.ReadAllLines(path);

            //foreach (string linea in lines)
            //{
            //    string[] s = linea.Split(';');
            //    textBox1.Text += s[0] + " " + s[1] + "\r\n";
            //}


                OpenFileDialog dialog = new OpenFileDialog();
                
                dialog.Filter = "Archivo CSV|*.csv|Todos los archivos|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string name = dialog.FileName;
                    FileStream fs = null;
                    StreamReader sr = null; 

                    try
                    {
                        fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                        sr = new StreamReader(fs);
                        sr.ReadLine();

                        while (sr.EndOfStream != true)
                        {
                            string cadena = sr.ReadLine().Trim();
                         

                            Vehiculo vehiculo = new Vehiculo();
                            vehiculo.importar(cadena);
                            vehiculos.Add(vehiculo);


                        }
                        foreach (Vehiculo v in vehiculos)
                        {
                            textBox1.Text += v.ToString();

                        }


                    }
                    catch (PatenteExeptio p)
                    {
                    MessageBox.Show(p.Message,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                    catch (Exception ex ) 
                    {
                        MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sr != null) sr.Close();
                        if (fs != null) fs.Close();
                    }

                   

                }
            
        }
    }
}
