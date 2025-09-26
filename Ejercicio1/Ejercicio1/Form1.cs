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
                        vehiculos.Sort();
                        vehiculo.importar(cadena);
                        int idx = vehiculos.BinarySearch(vehiculo);
                        if (idx>=0)
                        {
                            vehiculos[idx].AgregarMulta(vehiculo.Importe);
                        }
                        else { vehiculos.Add(vehiculo); }


                    }
                    textBox1.Text = " ";
                    foreach (Vehiculo v in vehiculos)
                    {
                        textBox1.Text += v.ToString();

                    }


                }
                catch (PatenteExeptio p)
                {
                    MessageBox.Show(p.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();
                }



            }

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV |*.csv| Todos los archivos|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string nombre = sfd.FileName;

                FileStream fs = null;
                StreamWriter sw = null;

                try
                {
                    fs = new FileStream(nombre, FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);

                    foreach (Vehiculo v in vehiculos)
                    {
                        string cadena = v.Exportar();
                        sw.WriteLine(cadena);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }


            }
        }
    }
}
