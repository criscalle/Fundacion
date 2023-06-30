using Fundacion.Clases;
using Fundacion.Conexion;
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
    /// Lógica de interacción para Lista__Categoria.xaml
    /// </summary>
    public partial class Lista__Categoria : Window
    {
        public Lista__Categoria()
        {
            InitializeComponent();
            cargar_afiliados();
        }

        public static string categoria;
        List<Afiliado> lista = new List<Afiliado>();
        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm";
        Conexion.ConexionAfiliado conexionafiliado = new Conexion.ConexionAfiliado(datos);


        public void cargar_afiliados()
        {
            lista.Clear();
            lista_categoria.Items.Clear();
            try
            {
                lista = conexionafiliado.listar_cat(categoria);
                foreach (Afiliado a in lista)
                {
                    lista_categoria.Items.Add(new Afiliado { Id = a.Id, Nombres = a.Nombres, Apellidos = a.Apellidos, Ciudad = a.Ciudad, Barrio = a.Barrio, Telefono = a.Telefono, Condicion = a.Condicion, Categoria = a.Categoria });
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
            lista_categoria.Items.Clear();
        }
    }
}
