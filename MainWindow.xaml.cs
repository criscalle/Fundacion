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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fundacion
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm";
        Conexion.ConexionUsuario conexionusuario = new Conexion.ConexionUsuario(datos);
        Usuario user = new Usuario();

        public static string dato;
       

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string[] usuario = new string[2];
                usuario[0] = txtUser.Text;
                usuario[1] = txtPassword.Password.ToString();

                user = conexionusuario.validar(usuario);

                if (user.Rol == "Admon")
                {
                    MessageBox.Show("Ingreso exitoso", "Afiliados", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    Fundacion_Transplantados fund = new Fundacion_Transplantados();
                    fund.Show();
                    dato = user.User;


                }
                else if (user.Rol == "User")
                {
                    MessageBox.Show("Ingreso exitoso", "Afiliados", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    Fundacion_Transplantados_SU funds = new Fundacion_Transplantados_SU();
                    funds.Show();
                    dato = user.User;
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña invalidos", "Afiliados", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtUser.Clear();
                    txtPassword.Clear();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
