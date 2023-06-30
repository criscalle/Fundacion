using Fundacion.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fundacion.Conexion
{
    public class ConexionSubsidio
    {
        private MySqlConnection conexionsubsidio = new MySqlConnection();

        public ConexionSubsidio(string _datos)
        {
            conexionsubsidio.ConnectionString = _datos;
        }

        public string msg;
        static Subsidios sub = new Subsidios();
        static List<Subsidios> lista = new List<Subsidios>();
        public string create(Subsidios sub)
        {
            try
            {
                conexionsubsidio.Open();
                string consulta = "Insert into subsidios (id_afiliado, valor, concepto, user, fecha_entrega, create_at, update_at) values (@id_afiliado, @valor, @concepto, @user, @fecha_entrega, @create_at, @update_at)";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionsubsidio);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_afiliado", sub.Id_afiliado);
                cmd.Parameters.AddWithValue("@valor", sub.Valor);
                cmd.Parameters.AddWithValue("@fecha_entrega", sub.Fecha_entrega);
                cmd.Parameters.AddWithValue("@concepto", sub.Concepto);
                cmd.Parameters.AddWithValue("@user", sub.User);
                cmd.Parameters.AddWithValue("@create_at", sub.Create_at);
                cmd.Parameters.AddWithValue("@update_at", sub.Update_at);


                cmd.ExecuteNonQuery();
                msg = "Subsidio ingresado con exito :)";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            conexionsubsidio.Close();
            return msg;
        }

        public string update(Subsidios sub)
        {
            string respuesta = null;
            try
            {
                conexionsubsidio.Open();
                string consulta = "Update subsidios set id_afiliado=@id_afiliado, valor=@valor, fecha_entrega=@fecha_entrega, concepto=@concepto, user= @user, update_at=@update_at where id=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionsubsidio);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", sub.Id);
                cmd.Parameters.AddWithValue("@id_afiliado", sub.Id_afiliado);
                cmd.Parameters.AddWithValue("@valor", sub.Valor);
                cmd.Parameters.AddWithValue("@fecha_entrega", sub.Fecha_entrega);
                cmd.Parameters.AddWithValue("@concepto", sub.Concepto);
                cmd.Parameters.AddWithValue("@user", sub.User);
                cmd.Parameters.AddWithValue("@update_at", sub.Update_at);


                cmd.ExecuteNonQuery();
                respuesta = "Subsidio actualizado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionsubsidio.Close();
            return respuesta;
        }

        public string delete(int id)
        {
            string respuesta = null;
            try
            {
                conexionsubsidio.Open();
                string consulta = "delete from subsidios where id=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionsubsidio);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                respuesta = "Subsidio eliminado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = "\n" + ex.Message;
            }
            conexionsubsidio.Close();
            return respuesta;

        }

        public List<Subsidios> show(string msg)
        {
            try
            {
                conexionsubsidio.Open();
                MySqlCommand cmd = new MySqlCommand("select  id, id_afiliado, valor, concepto, user, fecha_entrega, create_at, update_at from subsidios where id_afiliado= @id_afiliado", conexionsubsidio);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_afiliado", msg);
                MySqlDataReader info = cmd.ExecuteReader();


                while (info.Read())
                {
                    lista.Add(new Subsidios
                    {
                        Id = info.GetInt32(0),
                        Id_afiliado = info.GetInt32(1),
                        Valor = info.GetInt32(2),
                        Concepto = info.GetString(3),
                        User = info.GetString(4),
                        Fecha_entrega = info.GetDateTime(5),
                        Create_at = info.GetDateTime(6),
                        Update_at = info.GetDateTime(7)
                    });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexionsubsidio.Close();
            return lista;
        }



    }
}
