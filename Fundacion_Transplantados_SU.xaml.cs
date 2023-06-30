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
   
    public partial class Fundacion_Transplantados_SU : Window
    {
        public Fundacion_Transplantados_SU()
        {
            InitializeComponent();
            cargardatos();
        }

        static string datos = "Server=192.168.1.23; database=afiliados; user=Admin; password=EKFvxkF9.xr.sDrm", msg, resul;
        Conexion.ConexionAfiliado conexionafiliado = new Conexion.ConexionAfiliado(datos);
        Conexion.ConexionUsuario conexionusuario = new Conexion.ConexionUsuario(datos);
        Conexion.ConexionContacto conexioncontacto = new Conexion.ConexionContacto(datos);
        Conexion.ConexionFundTran conexionfundacion = new Conexion.ConexionFundTran(datos);
        Conexion.ConexionSubsidios conexionpagos = new Conexion.ConexionSubsidios(datos);
        Conexion.ConexionSubsidio conexionsubsidio = new Conexion.ConexionSubsidio(datos);
        static List<Usuario> lista_user = new List<Usuario>();
        static Usuario user = new Usuario();
        static List<Departamento> deptos = new List<Departamento>();
        static List<Ciudad> muns = new List<Ciudad>();
        static Afiliado afil = new Afiliado();
        static FundTran fund = new FundTran();
        static Pagos pag = new Pagos();
        static Subsidios sub = new Subsidios();
        static int doc;
        static Contacto cont = new Contacto();

        public void cargardatos()
        {
            deptos = conexionusuario.cargar();
            foreach (Departamento d in deptos)
            {
                combodep.Items.Add(d.Depto);
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow Login = new MainWindow();
            Login.Show();
        }

        private void combodep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                muns.Clear();
                combomun.Items.Clear();

                if (combodep.SelectedValue.ToString() != null)
                {
                    string depto = combodep.SelectedValue.ToString();
                    muns = conexionusuario.cargar_datos(depto);

                    foreach (Ciudad m in muns)
                    {
                        combomun.Items.Add(m.Municipio);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void calendario_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            calendario01.Visibility = Visibility.Visible;

        }

        private void calendario01_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txtfecha_nac.Text = calendario01.SelectedDate.ToString();
            calendario01.Visibility = Visibility.Hidden;
        }

        private void calen_afil_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            calendario_afil.Visibility = Visibility.Visible;
        }

        private void calendario_afil_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txtfecha_afil.Text = calendario_afil.SelectedDate.ToString();
            calendario_afil.Visibility = Visibility.Hidden;
        }

        // crear afiliado //

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtid.Text == "" || txtNombre.Text == "" || txtapellidos.Text == "" || txtbarrio.Text == "" || txtdireccion.Text == "" || txtemail.Text == "" || txteps.Text == "" || txtips.Text == "" || combocondicion.SelectedIndex == 0 || combogenero.SelectedIndex == 0 || combopension.SelectedIndex == 0 || combosisben.SelectedIndex == 0 || combosisben.SelectedIndex == 0 || combodesplazado.SelectedIndex == 0 || comboayudas.SelectedIndex == 0 || combomascota.SelectedIndex == 0 || combocategoria.SelectedIndex == 0 || txtanalfabetismo.Text == "" || txtlimitaciones.Text == ""
                    )
                {
                    MessageBox.Show("Ingrese todos los campos requeridos", "Afiliado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {

                    ComboBoxItem selec_doc = (ComboBoxItem)comboid.SelectedItem;
                    TextBlock select_doc = (TextBlock)selec_doc.Content;

                    ComboBoxItem selec_gen = (ComboBoxItem)combogenero.SelectedItem;
                    TextBlock select_gen = (TextBlock)selec_gen.Content;

                    ComboBoxItem selec_comun = (ComboBoxItem)combocomuna.SelectedItem;
                    TextBlock select_comun = (TextBlock)selec_comun.Content;

                    ComboBoxItem selec_cond = (ComboBoxItem)combocondicion.SelectedItem;
                    TextBlock select_cond = (TextBlock)selec_cond.Content;

                    ComboBoxItem selec_pen = (ComboBoxItem)combopension.SelectedItem;
                    TextBlock select_pen = (TextBlock)selec_pen.Content;

                    ComboBoxItem selec_sis = (ComboBoxItem)combosisben.SelectedItem;
                    TextBlock select_sis = (TextBlock)selec_sis.Content;

                    ComboBoxItem selec_des = (ComboBoxItem)combodesplazado.SelectedItem;
                    TextBlock select_des = (TextBlock)selec_des.Content;

                    ComboBoxItem selec_ay = (ComboBoxItem)comboayudas.SelectedItem;
                    TextBlock select_ay = (TextBlock)selec_ay.Content;

                    ComboBoxItem selec_mas = (ComboBoxItem)combomascota.SelectedItem;
                    TextBlock select_mas = (TextBlock)selec_mas.Content;

                    ComboBoxItem selec_cat = (ComboBoxItem)combocategoria.SelectedItem;
                    TextBlock select_cat = (TextBlock)selec_cat.Content;


                    afil.Id = Convert.ToInt32(txtid.Text);
                    afil.Tipo_doc = select_doc.Text;
                    afil.Nombres = txtNombre.Text;
                    afil.Apellidos = txtapellidos.Text;
                    afil.Genero = select_gen.Text;
                    afil.Depto = combodep.SelectedValue.ToString();
                    afil.Ciudad = combomun.SelectedValue.ToString(); ;
                    afil.Barrio = txtbarrio.Text;
                    afil.Comuna = select_comun.Text;
                    afil.Direccion = txtdireccion.Text;
                    afil.Telefono = txttelefono.Text;
                    afil.Email = txtemail.Text;
                    afil.Fecha_nacimiento = Convert.ToDateTime(txtfecha_nac.Text);
                    afil.Fecha_afiliacion = Convert.ToDateTime(txtfecha_afil.Text);
                    afil.Eps = txteps.Text;
                    afil.Ips = txtips.Text;
                    afil.Condicion = select_cond.Text;
                    afil.Pension = select_pen.Text;
                    afil.Sisben = select_sis.Text;
                    afil.Desplazado = select_des.Text;
                    afil.Gastos = txtgastos.Text;
                    afil.Ayudas = select_ay.Text;
                    afil.Mascotas = select_mas.Text;
                    afil.Categoria = select_cat.Text;
                    afil.User = MainWindow.dato;
                    afil.Create = DateTime.Now;
                    afil.Update = DateTime.Now;
                    afil.Limitaciones = txtlimitaciones.Text;
                    afil.Analfabetismo = txtanalfabetismo.Text;

                    msg = conexionafiliado.create(afil);
                    MessageBox.Show(msg, "Afiliado", MessageBoxButton.OK, MessageBoxImage.Information);
                    clean();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clean()
        {
            txtid.Clear();
            txtNombre.Clear();
            txtapellidos.Clear();
            txtbarrio.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
            txtemail.Clear();
            txtfecha_nac.Clear();
            txtfecha_afil.Clear();
            txteps.Clear();
            txtips.Clear();
            txtgastos.Clear();
            txtlimitaciones.Clear();
            txtanalfabetismo.Clear();
            comboid.SelectedIndex = 0;
            combogenero.SelectedIndex = 0;
            combocomuna.SelectedIndex = 0;
            combocondicion.SelectedIndex = 0;
            combopension.SelectedIndex = 0;
            combosisben.SelectedIndex = 0;
            combodesplazado.SelectedIndex = 0;
            combomascota.SelectedIndex = 0;
            comboayudas.SelectedIndex = 0;
            combodep.SelectedIndex = 0;
            combomun.SelectedIndex = 0;
            combocategoria.SelectedIndex = 0;

        }

        // delete afiliado con cuadro de advertencia//

        private void btnDelete1_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtid.Text == "")
                {
                    MessageBox.Show("Por favor ingrese el Documento a eliminar", "Afiliado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    string messageBoxText = "Deseas eliminar este Afiliado?";
                    string caption = "Confirmar cambios";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult resultado = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (resultado == MessageBoxResult.Yes)
                    {
                        doc = Convert.ToInt32(txtid.Text);
                        msg = conexionafiliado.delete(doc);
                        MessageBox.Show(msg, "Afiliado", MessageBoxButton.OK, MessageBoxImage.Information);
                        clean();

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //editar afiliado //
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtid.Text == "" || txtNombre.Text == "" || txtapellidos.Text == "" || txtbarrio.Text == "" || txtdireccion.Text == "" || txtemail.Text == "" || txteps.Text == "" || txtips.Text == "" || combocondicion.SelectedIndex == 0 || combogenero.SelectedIndex == 0 || combopension.SelectedIndex == 0 || combosisben.SelectedIndex == 0 || combosisben.SelectedIndex == 0 || combodesplazado.SelectedIndex == 0 || comboayudas.SelectedIndex == 0 || combomascota.SelectedIndex == 0 || combocategoria.SelectedIndex == 0 || txtanalfabetismo.Text == "" || txtlimitaciones.Text == ""
                    )
                {
                    MessageBox.Show("Ingrese todos los campos requeridos", "Afiliado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {

                    ComboBoxItem selec_doc = (ComboBoxItem)comboid.SelectedItem;
                    TextBlock select_doc = (TextBlock)selec_doc.Content;

                    ComboBoxItem selec_gen = (ComboBoxItem)combogenero.SelectedItem;
                    TextBlock select_gen = (TextBlock)selec_gen.Content;

                    ComboBoxItem selec_comun = (ComboBoxItem)combocomuna.SelectedItem;
                    TextBlock select_comun = (TextBlock)selec_comun.Content;

                    ComboBoxItem selec_cond = (ComboBoxItem)combocondicion.SelectedItem;
                    TextBlock select_cond = (TextBlock)selec_cond.Content;

                    ComboBoxItem selec_pen = (ComboBoxItem)combopension.SelectedItem;
                    TextBlock select_pen = (TextBlock)selec_pen.Content;

                    ComboBoxItem selec_sis = (ComboBoxItem)combosisben.SelectedItem;
                    TextBlock select_sis = (TextBlock)selec_sis.Content;

                    ComboBoxItem selec_des = (ComboBoxItem)combodesplazado.SelectedItem;
                    TextBlock select_des = (TextBlock)selec_des.Content;

                    ComboBoxItem selec_ay = (ComboBoxItem)comboayudas.SelectedItem;
                    TextBlock select_ay = (TextBlock)selec_ay.Content;

                    ComboBoxItem selec_mas = (ComboBoxItem)combomascota.SelectedItem;
                    TextBlock select_mas = (TextBlock)selec_mas.Content;

                    ComboBoxItem selec_cat = (ComboBoxItem)combocategoria.SelectedItem;
                    TextBlock select_cat = (TextBlock)selec_cat.Content;


                    afil.Id = Convert.ToInt32(txtid.Text);
                    afil.Tipo_doc = select_doc.Text;
                    afil.Nombres = txtNombre.Text;
                    afil.Apellidos = txtapellidos.Text;
                    afil.Genero = select_gen.Text;
                    afil.Depto = combodep.SelectedValue.ToString();
                    afil.Ciudad = combomun.SelectedValue.ToString(); ;
                    afil.Barrio = txtbarrio.Text;
                    afil.Comuna = select_comun.Text;
                    afil.Direccion = txtdireccion.Text;
                    afil.Telefono = txttelefono.Text;
                    afil.Email = txtemail.Text;
                    afil.Eps = txteps.Text;
                    afil.Ips = txtips.Text;
                    afil.Condicion = select_cond.Text;
                    afil.Pension = select_pen.Text;
                    afil.Sisben = select_sis.Text;
                    afil.Desplazado = select_des.Text;
                    afil.Gastos = txtgastos.Text;
                    afil.Ayudas = select_ay.Text;
                    afil.Mascotas = select_mas.Text;
                    afil.Categoria = select_cat.Text;
                    afil.User = MainWindow.dato;
                    afil.Update = DateTime.Now;
                    afil.Limitaciones = txtlimitaciones.Text;
                    afil.Analfabetismo = txtanalfabetismo.Text;

                    msg = conexionafiliado.update(afil);
                    MessageBox.Show(msg, "Afiliado", MessageBoxButton.OK, MessageBoxImage.Information);
                    clean();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            clean();
        }
        // mostrar datos del afiliado //
        private void btnShow_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtid.Text == "")
                {
                    MessageBox.Show("Ingrese el Documento del afiliado a mostrar", "Afiliado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Mostrar.dato = txtid.Text;
                    Mostrar show = new Mostrar();
                    show.Show();
                    clean();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // ingresar contacto del usuario//
        private void btn_ingresar_contacto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem selec_paren = (ComboBoxItem)comboparentesco.SelectedItem;
                TextBlock select_paren = (TextBlock)selec_paren.Content;

                if (txtid_Afiliado.Text == "" || txtid_contacto.Text == "" || txtcelular_contacto.Text == "" || txtNombre_contacto.Text == "" || txtapellidos_contacto.Text == "" || txttelefono_contacto.Text == "" || txtDireccion_contacto.Text == "" || txtCiudad_contacto.Text == "" || txtemail_contacto.Text == "" || comboparentesco.SelectedIndex == 0)
                {
                    MessageBox.Show("Ingrese todos los datos requeridos", "Contacto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {

                    cont.Id = txtid_contacto.Text;
                    cont.Name = txtNombre_contacto.Text;
                    cont.Lastname = txtapellidos_contacto.Text;
                    cont.Parentesco = select_paren.Text;
                    cont.Phone = txttelefono_contacto.Text;
                    cont.Celphone = txtcelular_contacto.Text;
                    cont.Email = txtemail_contacto.Text;
                    cont.Adress = txtDireccion_contacto.Text;
                    cont.City = txtCiudad_contacto.Text;
                    cont.Id_afiliado = Convert.ToInt32(txtid_Afiliado.Text);

                    msg = conexioncontacto.create(cont);
                    MessageBox.Show(msg, "Contacto", MessageBoxButton.OK, MessageBoxImage.Information);
                    clean_cont();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clean_cont()
        {
            txtid_Afiliado.Clear();
            txtid_contacto.Clear();
            txtNombre_contacto.Clear();
            txtapellidos_contacto.Clear();
            txttelefono_contacto.Clear();
            comboparentesco.SelectedIndex = 0;
            txtcelular_contacto.Clear();
            txtemail_contacto.Clear();
            txtDireccion_contacto.Clear();
            txtCiudad_contacto.Clear();

        }



        private void btnLimpiar_contacto_Click(object sender, RoutedEventArgs e)
        {
            clean_cont();
        }
        // editar contacto de emergencia //

        private void btneditar_contacto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem selec_paren = (ComboBoxItem)comboparentesco.SelectedItem;
                TextBlock select_paren = (TextBlock)selec_paren.Content;

                if (txtid_Afiliado.Text == "" || txtid_contacto.Text == "" || txtcelular_contacto.Text == "" || txtNombre_contacto.Text == "" || txtapellidos_contacto.Text == "" || txttelefono_contacto.Text == "" || txtDireccion_contacto.Text == "" || txtCiudad_contacto.Text == "" || txtemail_contacto.Text == "" || comboparentesco.SelectedIndex == 0)
                {
                    MessageBox.Show("Ingrese todos los datos requeridos", "Contacto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {

                    cont.Id = txtid_contacto.Text;
                    cont.Name = txtNombre_contacto.Text;
                    cont.Lastname = txtapellidos_contacto.Text;
                    cont.Parentesco = select_paren.Text;
                    cont.Phone = txttelefono_contacto.Text;
                    cont.Celphone = txtcelular_contacto.Text;
                    cont.Email = txtemail_contacto.Text;
                    cont.Adress = txtDireccion_contacto.Text;
                    cont.City = txtCiudad_contacto.Text;
                    cont.Id_afiliado = Convert.ToInt32(txtid_Afiliado.Text);

                    msg = conexioncontacto.update(cont);
                    MessageBox.Show(msg, "Contacto", MessageBoxButton.OK, MessageBoxImage.Information);
                    clean_cont();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // mostrar datos del contacto del afiliado
        private void btn_mostrar_contacto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtid_Afiliado.Text == "")
                {
                    MessageBox.Show("Ingrese el Documento del afiliado", "Contacto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Mostrar_Contacto.documento = txtid_Afiliado.Text;
                    Mostrar_Contacto show = new Mostrar_Contacto();
                    show.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // eliminar contacto del afiliado
        private void btneliminar_contacto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string messageBoxText = "Deseas eliminar este Contacto?";
                string caption = "Confirmar cambios";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult resultado = MessageBox.Show(messageBoxText, caption, button, icon);

                if (resultado == MessageBoxResult.Yes)
                {
                    msg = conexioncontacto.delete(Convert.ToInt32(txtid_Afiliado.Text));
                    MessageBox.Show(msg, "Contacto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Contacto no ha sido eliminado", "Contacto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // crear datos de la fundacion // 
        private void btnCreate_fund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDocumento_afil_fund.Text == "" || txtmotivo.Text == "" || combotransplante.SelectedIndex == 0 || combotutela.SelectedIndex == 0 || comborechazo.SelectedIndex == 0 || combohospedaje.SelectedIndex == 0 || comboinfo_fund.SelectedIndex == 0)
                {
                    MessageBox.Show("Ingrese todos los datos", "Fundacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {

                    ComboBoxItem selec_nit = (ComboBoxItem)combonit.SelectedItem;
                    TextBlock select_nit = (TextBlock)selec_nit.Content;

                    ComboBoxItem selec_name = (ComboBoxItem)comborazonsoc.SelectedItem;
                    TextBlock select_name = (TextBlock)selec_name.Content;

                    ComboBoxItem selec_tran = (ComboBoxItem)combotransplante.SelectedItem;
                    TextBlock select_tran = (TextBlock)selec_tran.Content;


                    ComboBoxItem selec_tut = (ComboBoxItem)combotutela.SelectedItem;
                    TextBlock select_tut = (TextBlock)selec_tut.Content;

                    ComboBoxItem selec_rec = (ComboBoxItem)comborechazo.SelectedItem;
                    TextBlock select_rec = (TextBlock)selec_rec.Content;

                    ComboBoxItem selec_hosp = (ComboBoxItem)combohospedaje.SelectedItem;
                    TextBlock select_hosp = (TextBlock)selec_hosp.Content;

                    ComboBoxItem selec_info = (ComboBoxItem)comboinfo_fund.SelectedItem;
                    TextBlock select_info = (TextBlock)selec_info.Content;


                    fund.Nit = select_nit.Text;
                    fund.Name = select_name.Text;
                    fund.Tipo_transplante = select_tran.Text;
                    fund.Tutela = select_tut.Text;
                    fund.Rechazo = select_rec.Text;
                    fund.Motivo = txtmotivo.Text;
                    fund.Hospedaje = select_hosp.Text;
                    fund.Info_fundacion = select_info.Text;
                    fund.Id_persona = Convert.ToInt32(txtDocumento_afil_fund.Text);


                    msg = conexionfundacion.create(fund);
                    MessageBox.Show(msg, "Fundacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiar_fund();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // limpiar textos de datos fundacion //

        public void limpiar_fund()
        {
            txtDocumento_afil_fund.Clear();
            combotransplante.SelectedIndex = 0;
            combotutela.SelectedIndex = 0;
            comborechazo.SelectedIndex = 0;
            txtmotivo.Clear();
            combohospedaje.SelectedIndex = 0;
            comboinfo_fund.SelectedIndex = 0;

        }
        // editar info de la fundacion//
        private void btnEditar_infofundacion_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtDocumento_afil_fund.Text == "" || txtmotivo.Text == "" || combotransplante.SelectedIndex == 0 || combotutela.SelectedIndex == 0 || comborechazo.SelectedIndex == 0 || combohospedaje.SelectedIndex == 0 || comboinfo_fund.SelectedIndex == 0)
                {
                    MessageBox.Show("Ingrese todos los campos requeridos", "Fundacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    ComboBoxItem selec_tran = (ComboBoxItem)combotransplante.SelectedItem;
                    TextBlock select_tran = (TextBlock)selec_tran.Content;


                    ComboBoxItem selec_tut = (ComboBoxItem)combotutela.SelectedItem;
                    TextBlock select_tut = (TextBlock)selec_tut.Content;

                    ComboBoxItem selec_rec = (ComboBoxItem)comborechazo.SelectedItem;
                    TextBlock select_rec = (TextBlock)selec_rec.Content;

                    ComboBoxItem selec_hosp = (ComboBoxItem)combohospedaje.SelectedItem;
                    TextBlock select_hosp = (TextBlock)selec_hosp.Content;

                    ComboBoxItem selec_info = (ComboBoxItem)comboinfo_fund.SelectedItem;
                    TextBlock select_info = (TextBlock)selec_info.Content;

                    fund.Id_persona = Convert.ToInt32(txtDocumento_afil_fund.Text);
                    fund.Tipo_transplante = select_tran.Text;
                    fund.Tutela = select_tut.Text;
                    fund.Hospedaje = select_hosp.Text;
                    fund.Rechazo = select_rec.Text;
                    fund.Motivo = txtmotivo.Text;
                    fund.Info_fundacion = select_info.Text;

                    resul = conexionfundacion.update(fund);
                    MessageBox.Show(resul, "Fundacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiar_fund();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnDelete_fund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDocumento_afil_fund.Text == "")
                {
                    MessageBox.Show("Ingrese el documento del afiliado", "Fundacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    string messageBoxText = "Deseas eliminar los datos de este Afiliado?";
                    string caption = "Confirmar cambios";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult resultado = MessageBox.Show(messageBoxText, caption, button, icon);

                    if (resultado == MessageBoxResult.Yes)
                    {
                        doc = Convert.ToInt32(txtDocumento_afil_fund.Text);
                        msg = conexionfundacion.delete(doc);
                        MessageBox.Show(msg, "Fundacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        limpiar_fund();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // mostrar los datos de la fundacion respecto al afiliado
        private void btnmostrar_datos_fund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDocumento_afil_fund.Text == "")
                {
                    MessageBox.Show("Ingrese el Documento del afiliado", "Fundacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {

                    Mostrar_fund.documento_fun = txtDocumento_afil_fund.Text;
                    Mostrar_fund fund = new Mostrar_fund();
                    fund.Show();
                    limpiar_fund();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // limpiar datos fundacion //

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            limpiar_fund();
        }
        // calendario pagos //
        private void FP_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Calendario_pago.Visibility = Visibility.Visible;
        }

        private void Calendario_pago_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txtfecha_pago.Text = Calendario_pago.SelectedDate.ToString();
            Calendario_pago.Visibility = Visibility.Hidden;

        }

        // ingresar  crear pagos // 

        private void btnIngresar_pago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDoc_afil_pagos.Text == "" || txtcuota.Text == "" || txtconcepto_pago.Text == "" || txtfecha_pago.Text == "")
                {
                    MessageBox.Show("Ingrese todos los datos", "Pago", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    pag.Id_afiliado = Convert.ToInt32(txtDoc_afil_pagos.Text);
                    pag.Cuota = Convert.ToInt32(txtcuota.Text);
                    pag.Concepto = txtconcepto_pago.Text;
                    pag.Fecha_pago = Convert.ToDateTime(txtfecha_pago.Text);
                    pag.User = MainWindow.dato;
                    pag.Create_at = DateTime.Now;
                    pag.Update_at = DateTime.Now;

                    resul = conexionpagos.create(pag);
                    MessageBox.Show(resul, "Pagos", MessageBoxButton.OK, MessageBoxImage.Information);
                    clean_pag();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clean_pag()
        {
            txtDoc_afil_pagos.Clear();
            txtcuota.Clear();
            txtconcepto_pago.Clear();
            txtfecha_pago.Clear();
            txtid_pago.Clear();

        }
        // eliminar pago //
        private void btnEliminar_pago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtid_pago.Text == "")
                {
                    MessageBox.Show("Ingrese el id del pago a eliminar", "Pago", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    doc = Convert.ToInt32(txtid_pago.Text);
                    msg = conexionpagos.delete(doc);
                    MessageBox.Show(msg, "Pago", MessageBoxButton.OK, MessageBoxImage.Information);
                    clean_pag();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // editar pago // 
        private void btnEditar_pago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtid_pago.Text == "")
                {
                    MessageBox.Show("Ingrese el id del pago a editar", "Pago", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    pag.Id = Convert.ToInt32(txtid_pago.Text);
                    pag.Id_afiliado = Convert.ToInt32(txtDoc_afil_pagos.Text);
                    pag.Cuota = Convert.ToInt32(txtcuota.Text);
                    pag.Concepto = txtconcepto_pago.Text;
                    pag.User = MainWindow.dato;
                    pag.Update_at = DateTime.Now;
                    pag.Fecha_pago = Convert.ToDateTime(txtfecha_pago.Text);

                    msg = conexionpagos.update(pag);
                    MessageBox.Show(msg, "Pago", MessageBoxButton.OK, MessageBoxImage.Information);
                    clean_pag();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // mostrar pagos del afiliado/asociado //
        private void btnMostrar_pagos_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtDoc_afil_pagos.Text == "")
                {
                    MessageBox.Show("Ingrese el Documento del afiliado", "Pago", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    Mostrar_Pagos.documento_pag = txtDoc_afil_pagos.Text;
                    Mostrar_Pagos pag = new Mostrar_Pagos();
                    pag.Show();
                    clean_pag();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // calendario subsidios
        private void FE_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            calen_fecha_sub.Visibility = Visibility.Visible;

        }
        // calendario subsidios
        private void calen_fecha_sub_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txtfechaentrega_subs.Text = calen_fecha_sub.SelectedDate.ToString();
            calen_fecha_sub.Visibility = Visibility.Hidden;
        }

        private void btnIngresar_sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDoc_afil_subs.Text == "" || txtvalor_subsidio.Text == "" || txtconcepto_subs.Text == "" || txtfechaentrega_subs.Text == "")
                {
                    MessageBox.Show("Ingrese todos los datos", "Subsidio", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    sub.Id_afiliado = Convert.ToInt32(txtDoc_afil_subs.Text);
                    sub.Valor = Convert.ToInt32(txtvalor_subsidio.Text);
                    sub.Concepto = txtconcepto_subs.Text;
                    sub.Fecha_entrega = Convert.ToDateTime(txtfechaentrega_subs.Text);
                    sub.User = MainWindow.dato;
                    sub.Create_at = DateTime.Now;
                    sub.Update_at = DateTime.Now;

                    msg = conexionsubsidio.create(sub);
                    MessageBox.Show(msg, "Subsidio", MessageBoxButton.OK, MessageBoxImage.Information);
                    lim_sub();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void lim_sub()
        {
            txtDoc_afil_subs.Clear();
            txtvalor_subsidio.Clear();
            txtconcepto_subs.Clear();
            txtfechaentrega_subs.Clear();
        }
        // editar subsidio
        private void btnEditar_sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDoc_afil_subs.Text == "" || txtvalor_subsidio.Text == "" || txtconcepto_subs.Text == "" || txtfechaentrega_subs.Text == "")
                {
                    MessageBox.Show("Ingrese todos los datos", "Subsidio", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    sub.Id = Convert.ToInt32(txtid_subs.Text);
                    sub.Id_afiliado = Convert.ToInt32(txtDoc_afil_subs.Text);
                    sub.Valor = Convert.ToInt32(txtvalor_subsidio.Text);
                    sub.Concepto = txtconcepto_subs.Text;
                    sub.Fecha_entrega = Convert.ToDateTime(txtfechaentrega_subs.Text);
                    sub.User = MainWindow.dato;
                    sub.Update_at = DateTime.Now;

                    msg = conexionsubsidio.update(sub);
                    MessageBox.Show(msg, "Subsidio", MessageBoxButton.OK, MessageBoxImage.Information);
                    lim_sub();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // eliminar subsidio
        private void btnEliminar_sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtid_subs.Text == "")
                {

                    MessageBox.Show("Ingrese el Id del subsidio a eliminar", "Subsidio", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    doc = Convert.ToInt32(txtid_subs.Text);
                    msg = conexionsubsidio.delete(doc);
                    MessageBox.Show(msg, "Subsidio", MessageBoxButton.OK, MessageBoxImage.Information);
                    lim_sub();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_mostrar_sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDoc_afil_subs.Text == "")
                {
                    MessageBox.Show("Ingrese el documento del afiliado", "Subsidio", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Mostrar_Subsidios.documento_sub = txtDoc_afil_subs.Text;
                    Mostrar_Subsidios sub = new Mostrar_Subsidios();
                    sub.Show();
                    lim_sub();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLista_cond_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Afiliado> lista = new List<Afiliado>();
                if (combocondicion.SelectedIndex == 0)
                {
                    MessageBox.Show("Ingrese la condicion a buscar", "Condicion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {

                    ComboBoxItem selec_cond = (ComboBoxItem)combocondicion.SelectedItem;
                    TextBlock select_cond = (TextBlock)selec_cond.Content;
                    Lista_Afiliados.condicion = select_cond.Text;

                    Lista_Afiliados list = new Lista_Afiliados();
                    list.Show();
                    clean();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLista_Cat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (combocategoria.SelectedIndex == 0)
                {
                    MessageBox.Show("Ingrese la categoria a buscar", "Condicion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    ComboBoxItem selec_cat = (ComboBoxItem)combocategoria.SelectedItem;
                    TextBlock select_cat = (TextBlock)selec_cat.Content;
                    Lista__Categoria.categoria = select_cat.Text;

                    Lista__Categoria list = new Lista__Categoria();
                    list.Show();
                    clean();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnlista_ninos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lista_ninos lista = new Lista_ninos();
                lista.Show();
                clean();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnlista_adultos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lista_adultos lista = new Lista_adultos();
                lista.Show();
                clean();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
