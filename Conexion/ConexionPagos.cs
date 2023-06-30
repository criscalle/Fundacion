using Fundacion.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Fundacion.Conexion
{
    public class ConexionSubsidios
    {

        private MySqlConnection conexionpagos = new MySqlConnection();

        public ConexionSubsidios(string _datos)
        {
            conexionpagos.ConnectionString = _datos;
        }

        public string msg;
        static Pagos pag = new Pagos();
        static List<Pagos> lista = new List<Pagos>();
        public string create(Pagos pago)
        {
            try
            {
                conexionpagos.Open();
                string consulta = "Insert into pagos (id_afiliado, cuota, fecha_pago, concepto, user, create_at, update_at) values (@id_afiliado, @cuota, @fecha_pago, @concepto, @user, @create_at, @update_at)";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionpagos);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_afiliado", pago.Id_afiliado);
                cmd.Parameters.AddWithValue("@cuota", pago.Cuota);
                cmd.Parameters.AddWithValue("@fecha_pago", pago.Fecha_pago);
                cmd.Parameters.AddWithValue("@concepto", pago.Concepto);
                cmd.Parameters.AddWithValue("@user", pago.User);
                cmd.Parameters.AddWithValue("@create_at", pago.Create_at);
                cmd.Parameters.AddWithValue("@update_at", pago.Update_at);


                cmd.ExecuteNonQuery();
                msg = "Pago ingresado con exito :)";

            }
            catch(Exception ex) 
            {
                msg = ex.Message;
            }
            conexionpagos.Close();
            return msg;
        }

        public string update(Pagos pag)
        {
            string respuesta = null;
            try
            {
                conexionpagos.Open();
                string consulta = "Update pagos set id_afiliado=@id_afiliado, cuota=@cuota, fecha_pago=@fecha_pago, concepto=@concepto, user= @user, update_at=@update_at where id=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionpagos);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", pag.Id);
                cmd.Parameters.AddWithValue("@id_afiliado", pag.Id_afiliado);
                cmd.Parameters.AddWithValue("@cuota", pag.Cuota);
                cmd.Parameters.AddWithValue("@fecha_pago", pag.Fecha_pago);
                cmd.Parameters.AddWithValue("@concepto", pag.Concepto);
                cmd.Parameters.AddWithValue("@user", pag.User);
                cmd.Parameters.AddWithValue("@update_at", pag.Update_at);


                cmd.ExecuteNonQuery();
                respuesta = "Pago actualizado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionpagos.Close();
            return respuesta;
        }

        public string delete(int id)
        {
            string respuesta = null;
            try
            {
                conexionpagos.Open();
                string consulta = "delete from pagos where id=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionpagos);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                respuesta = "Pago eliminado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = "\n" + ex.Message;
            }
            conexionpagos.Close();
            return respuesta;

        }

        public List<Pagos> show(string msg)
        {
            try
            {
                conexionpagos.Open();
                MySqlCommand cmd = new MySqlCommand("select  id, id_afiliado, cuota, concepto, fecha_pago, user, create_at, update_at from pagos where id_afiliado= @id_afiliado", conexionpagos);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_afiliado", msg);
                MySqlDataReader info = cmd.ExecuteReader();


                while (info.Read())
                {
                    lista.Add(new Pagos { Id = info.GetInt32(0), Id_afiliado = info.GetInt32(1), Cuota = info.GetInt32(2), Concepto = info.GetString(3),
                        Fecha_pago = info.GetDateTime(4), User = info.GetString(5), Create_at = info.GetDateTime(6), Update_at = info.GetDateTime(7)
                     });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexionpagos.Close();
            return lista;
        }

    }
}
