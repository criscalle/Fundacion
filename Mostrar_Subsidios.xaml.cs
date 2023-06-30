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
    /// Lógica de interacción para Mostrar_Subsidios.xaml
    /// </summary>
    public partial class Mostrar_Subsidios : Window
    {
        public Mostrar_Subsidios()
        {
            InitializeComponent();
            mostrar_sub();
        }

        public static string documento_sub;
        FundTran fund = new FundTran();
        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm; Convert Zero DateTime=True";
        Conexion.ConexionSubsidio conexionsubsidio = new Conexion.ConexionSubsidio(datos);
        static List<Subsidios> lista_sub = new List<Subsidios>();

        public void mostrar_sub()
        {
            lista_sub.Clear();
            Lista_subsidios.Items.Clear();
            lista_sub = conexionsubsidio.show(documento_sub);

            foreach (Subsidios s in lista_sub)
            {
                Lista_subsidios.Items.Add(new Subsidios { Id = s.Id, Id_afiliado = s.Id_afiliado, Valor = s.Valor, Concepto = s.Concepto, User = s.User, Fecha_entrega = s.Fecha_entrega, Create_at = s.Create_at, Update_at = s.Update_at });
            }
        }

        private void bnt_volver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
