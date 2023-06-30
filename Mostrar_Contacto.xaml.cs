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
    /// Lógica de interacción para Mostrar_Contacto.xaml
    /// </summary>
    public partial class Mostrar_Contacto : Window
    {
        public Mostrar_Contacto()
        {
            InitializeComponent();
            mostrar_datos();
        }

        public static string documento;
        Contacto contacto = new Contacto();
        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm";
        Conexion.ConexionContacto conexiocontacto = new Conexion.ConexionContacto(datos);

        public void mostrar_datos()
        {
            contacto = conexiocontacto.search(documento);
            txtmostar_id_Afil.Text = contacto.Id_afiliado.ToString(); 
            txtmostrar_doc_cont.Text = contacto.Id;
            txtmostrar_nombre_cont.Text = contacto.Name;
            txtmostrar_apell_cont.Text = contacto.Lastname;
            txtmostrar_parentesco.Text = contacto.Parentesco;
            txtmostrar_telefo_cont.Text = contacto.Phone;
            txtmostrar_cel_cont.Text = contacto.Celphone;
            txtmostrar_direc_cont.Text = contacto.Adress;
            txtmostrar_ciudad_cont.Text = contacto.City;
            txtmostrar_email_cont.Text = contacto.Email;
            
      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
