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

    public partial class Mostrar : Window
    {
        public Mostrar()
        {
            InitializeComponent();
            mostrar_datos();
        }

        public static string dato;
        Afiliado Afiliado = new Afiliado();
        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm; Convert Zero DateTime=True";
        Conexion.ConexionAfiliado conexionafiliado = new Conexion.ConexionAfiliado(datos);

        public void mostrar_datos()
        {

            Afiliado = conexionafiliado.search(dato);
            txtMostrar_doc.Text = Afiliado.Id.ToString();
            txtMostrar_tipodoc.Text = Afiliado.Tipo_doc;
            txtMostrar_nombre.Text = Afiliado.Nombres;
            txtMostrar_apellidos.Text = Afiliado.Apellidos;
            txtMostrar_genero.Text = Afiliado.Genero;
            txtMostrar_depto.Text = Afiliado.Depto;
            txtMostrar_municipio.Text = Afiliado.Ciudad;
            txtMostrar_barrio.Text = Afiliado.Barrio;
            txtMostrar_comuna.Text = Afiliado.Comuna;
            txtMostrar_direccion.Text = Afiliado.Direccion;
            txtMostrar_telefono.Text = Afiliado.Telefono;
            txtMostrar_email.Text = Afiliado.Email;
            txtMostrar_fechanac.Text = Afiliado.Fecha_nacimiento.ToShortDateString();
            txtMostrar_fechaafil.Text = Afiliado.Fecha_afiliacion.ToShortDateString();
            txtMostrar_eps.Text = Afiliado.Eps;
            txtMostrar_ips.Text = Afiliado.Ips;
            txtMostrar_condicion.Text = Afiliado.Condicion;
            txtMostrar_pension.Text = Afiliado.Pension;
            txtMostrar_sisben.Text = Afiliado.Sisben;
            txtMostrar_Despl.Text = Afiliado.Desplazado;
            txtMostrar_mascot.Text = Afiliado.Mascotas;
            txtMostrar_ayudas.Text = Afiliado.Ayudas;
            txtMostrar_gastos.Text = Afiliado.Gastos;
            txtmostrar_Categ.Text = Afiliado.Categoria;
            txtmostrar_user.Text = Afiliado.User;
            txtmostrar_create.Text = Afiliado.Create.ToString();
            txtmostrar_update.Text = Afiliado.Update.ToString();
            txtmostrar_limitaciones.Text = Afiliado.Limitaciones;
            txtmostrar_analfabetismo.Text = Afiliado.Analfabetismo;

        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
 
        }
    }
}
