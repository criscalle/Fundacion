using Fundacion.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fundacion
{
    /// <summary>
    /// Lógica de interacción para Lista_Afiliados.xaml
    /// </summary>
    public partial class Lista_Afiliados : Window
    {
        public Lista_Afiliados()
        {
            InitializeComponent();
            lista.Clear();
            Lista_Condicion.Items.Clear();
            cargar_afiliados();
        }

        public static string condicion;
        List <Afiliado> lista = new List<Afiliado> ();
        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm";
        Conexion.ConexionAfiliado conexionafiliado = new Conexion.ConexionAfiliado(datos);


        public void cargar_afiliados()
        {
            
            try
            {
                
                lista = conexionafiliado.listar_cond(condicion);
               
                foreach(Afiliado a in lista)
                {
                    Lista_Condicion.Items.Add(new Afiliado { Id =  a.Id, Nombres = a.Nombres, Apellidos = a.Apellidos, Ciudad = a.Ciudad, Barrio = a.Barrio, Telefono = a.Telefono, Condicion = a.Condicion, Categoria = a.Categoria});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            lista.Clear();
            Lista_Condicion.Items.Clear();
        }
    }
}
