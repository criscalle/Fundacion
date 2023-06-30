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
using System.Xml.Linq;

namespace Fundacion
{
    /// <summary>
    /// Lógica de interacción para Mostrar_fund.xaml
    /// </summary>
    public partial class Mostrar_fund : Window
    {
        public Mostrar_fund()
        {
            InitializeComponent();
            cargarfund();
        }
        public static string documento_fun;
        FundTran fund = new FundTran();
        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm";
        Conexion.ConexionFundTran conexionfundacion = new Conexion.ConexionFundTran(datos);

        public void cargarfund()
        {
            try
            {
                fund = conexionfundacion.search(documento_fun);
                txtmostrar_afilfun.Text = fund.Id_persona.ToString();
                txtmostrartipo_tran.Text = fund.Tipo_transplante;
                txtmostrartutela_fun.Text = fund.Tutela;
                txtmostrar_rechazo.Text = fund.Rechazo;
                txtmostrarmotivo_fun.Text = fund.Motivo;
                txtmostrarhosped.Text = fund.Hospedaje;
                txtmostrarinfo_fun.Text = fund.Info_fundacion;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
