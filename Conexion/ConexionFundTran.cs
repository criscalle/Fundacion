using Fundacion.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Fundacion.Conexion
{
    public class ConexionFundTran
    {
        private MySqlConnection conexionfundacion = new MySqlConnection();

        public ConexionFundTran(string _datos)
        {
            conexionfundacion.ConnectionString = _datos;
        }

        static FundTran fund = new FundTran();
 

        public string create(FundTran fund)
        {
            string respuesta = null;
            try
            {
                conexionfundacion.Open();
                string consulta = "Insert into fundacion (nit, name, tipo_trans, tutela, hospedaje, rechazo, motivo, info_fundacion, id_persona) values (@nit, @name, @tipo_trans, @tutela, @hospedaje, @rechazo, @motivo, @info_fundacion, @id_persona)";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionfundacion);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nit", fund.Nit);
                cmd.Parameters.AddWithValue("@name", fund.Name);
                cmd.Parameters.AddWithValue("@tipo_trans", fund.Tipo_transplante);
                cmd.Parameters.AddWithValue("@tutela", fund.Tutela);
                cmd.Parameters.AddWithValue("@hospedaje", fund.Hospedaje);
                cmd.Parameters.AddWithValue("@rechazo", fund.Rechazo);
                cmd.Parameters.AddWithValue("@motivo", fund.Motivo);
                cmd.Parameters.AddWithValue("@info_fundacion", fund.Info_fundacion);
                cmd.Parameters.AddWithValue("@id_persona", fund.Id_persona);


                cmd.ExecuteNonQuery();
                respuesta = "Datos ingresados con exito :)";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionfundacion.Close();
            return respuesta;
        }

        public string update(FundTran fund)
        {
            string respuesta = null;
            try
            {
                conexionfundacion.Open();
                string consulta = "Update fundacion set tipo_trans=@tipo_trans, tutela=@tutela, hospedaje=@hospedaje, rechazo=@rechazo, motivo=@motivo, info_fundacion=@info_fundacion where id_persona=@id_persona";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionfundacion);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_persona", fund.Id_persona);
                cmd.Parameters.AddWithValue("@tipo_trans", fund.Tipo_transplante);
                cmd.Parameters.AddWithValue("@tutela", fund.Tutela);
                cmd.Parameters.AddWithValue("@hospedaje", fund.Hospedaje);
                cmd.Parameters.AddWithValue("@rechazo", fund.Rechazo);
                cmd.Parameters.AddWithValue("@motivo", fund.Motivo);
                cmd.Parameters.AddWithValue("@info_fundacion", fund.Info_fundacion);
             

                cmd.ExecuteNonQuery();
                respuesta = "Datos actualizados con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionfundacion.Close();
            return respuesta;
        }

        public FundTran search(string validar)
        {

            try
            {
                conexionfundacion.Open();
                MySqlCommand cmd = new MySqlCommand("select  nit, name, tipo_trans, tutela, hospedaje, rechazo, motivo, info_fundacion from fundacion where id_persona= @id_persona", conexionfundacion);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_persona", validar);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    fund.Nit = info.GetString(0);
                    fund.Name = info.GetString(1);
                    fund.Tipo_transplante = info.GetString(2);
                    fund.Tutela = info.GetString(3);
                    fund.Hospedaje = info.GetString(4);
                    fund.Rechazo = info.GetString(5);
                    fund.Motivo = info.GetString(6);
                    fund.Info_fundacion = info.GetString(7);
                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conexionfundacion.Close();
           return fund;
        }

        public string delete(int id)
        {
            string respuesta = null;
            try
            {
                conexionfundacion.Open();
                string consulta = "delete from fundacion where id_persona=@id_persona";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionfundacion);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_persona", id);
                cmd.ExecuteNonQuery();
                respuesta = "Datos eliminados con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = "\n" + ex.Message;
            }
            conexionfundacion.Close();
            return respuesta;

        }

    }
}



