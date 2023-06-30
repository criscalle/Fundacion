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
    /// Lógica de interacción para Mostrar_Pagos.xaml
    /// </summary>
    public partial class Mostrar_Pagos : Window
    {
        public Mostrar_Pagos()
        {
            InitializeComponent();
            mostrar_pagos();
        }

        public static string documento_pag;
        FundTran fund = new FundTran();
        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm; Convert Zero DateTime=True";
        Conexion.ConexionSubsidios conexionpagos = new Conexion.ConexionSubsidios(datos);
        static List<Pagos> lista = new List<Pagos>();

        public void mostrar_pagos()
        {
            try
            {
                lista.Clear();
                Lista_Pagos.Items.Clear();
                lista = conexionpagos.show(documento_pag);
                foreach (Pagos p in lista)
                {
                    Lista_Pagos.Items.Add(new Pagos { Id = p.Id, Id_afiliado = p.Id_afiliado, Cuota =p.Cuota, Concepto = p.Concepto, Fecha_pago = p.Fecha_pago, User = p.User, Create_at = p.Create_at, Update_at =p.Update_at});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bntVolver_pag_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
