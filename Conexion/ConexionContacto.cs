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
    public class ConexionContacto
    {
        private MySqlConnection conexioncontacto = new MySqlConnection();

        public ConexionContacto(string _datos)
        {
            conexioncontacto.ConnectionString = _datos;
        }

        static Contacto contac = new Contacto();
        
        public string create(Contacto contacto)
        {
            string respuesta = null;
            try
            {
                conexioncontacto.Open();
                string consulta = "Insert into contacto_emergencia (id, nombres, apellidos, parentesco, telefono, celular, email, direccion, ciudad, id_afiliado) values (@id, @name, @lastname, @parentesco, @telefono, @celular, @email, @direccion, @ciudad, @id_afiliado)";
                MySqlCommand cmd = new MySqlCommand(consulta, conexioncontacto);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", contacto.Id);
                cmd.Parameters.AddWithValue("@name", contacto.Name);
                cmd.Parameters.AddWithValue("@lastname", contacto.Lastname);
                cmd.Parameters.AddWithValue("@parentesco", contacto.Parentesco);
                cmd.Parameters.AddWithValue("@telefono", contacto.Phone);
                cmd.Parameters.AddWithValue("@celular", contacto.Celphone);
                cmd.Parameters.AddWithValue("@email", contacto.Email);
                cmd.Parameters.AddWithValue("@direccion", contacto.Adress);
                cmd.Parameters.AddWithValue("@ciudad", contacto.City);
                cmd.Parameters.AddWithValue("@id_afiliado", contacto.Id_afiliado);
            

                cmd.ExecuteNonQuery();
                respuesta = "Contacto ingresado con exito :)";
                
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexioncontacto.Close();
            return respuesta;
        }
      

        public Contacto search(string msg)
        {
            try
            {
                conexioncontacto.Open();
                MySqlCommand cmd = new MySqlCommand("select  id, nombres, apellidos, parentesco, telefono, celular, email, direccion, ciudad, id_afiliado from contacto_emergencia where id_afiliado= @id_contacto", conexioncontacto);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_contacto", msg);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    contac.Id = info.GetString(0);
                    contac.Name = info.GetString(1);
                    contac.Lastname = info.GetString(2);
                    contac.Parentesco = info.GetString(3);
                    contac.Phone = info.GetString(4);
                    contac.Celphone = info.GetString(5);
                    contac.Email = info.GetString(6);
                    contac.Adress = info.GetString(7);
                    contac.City = info.GetString(8);
                    contac.Id_afiliado = info.GetInt32(9);
                   

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexioncontacto.Close();
            return contac;
        }

        public string delete(int id)
        {
            string respuesta = null;
            try
            {
                conexioncontacto.Open();
                string consulta = "delete from contacto_emergencia where id_afiliado=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, conexioncontacto);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                respuesta = "Contacto eliminado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = "\n" + ex.Message;
            }
            conexioncontacto.Close();
            return respuesta;

        }

        public string update(Contacto cont)
        {
            string respuesta = null;
            try
            {
                conexioncontacto.Open();
                string consulta = "Update contacto_emergencia set id=@id, nombres=@nombre, apellidos=@apellidos, parentesco=@parentesco, telefono=@phone, celular=@celphone, email=@email, direccion=@adress, ciudad=@city  where id_afiliado=@id_afiliado";
                MySqlCommand cmd = new MySqlCommand(consulta, conexioncontacto);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", cont.Id);
                cmd.Parameters.AddWithValue("@nombre", cont.Name);
                cmd.Parameters.AddWithValue("@apellidos", cont.Lastname);
                cmd.Parameters.AddWithValue("@parentesco", cont.Parentesco);
                cmd.Parameters.AddWithValue("@phone", cont.Phone);
                cmd.Parameters.AddWithValue("@celphone", cont.Celphone);
                cmd.Parameters.AddWithValue("@email", cont.Email);
                cmd.Parameters.AddWithValue("@adress", cont.Adress);
                cmd.Parameters.AddWithValue("@city", cont.City);
                cmd.Parameters.AddWithValue("@id_afiliado", cont.Id_afiliado);
     

                cmd.ExecuteNonQuery();
                respuesta = "Contacto actualizado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexioncontacto.Close();
            return respuesta;
        }

        public string validar(string id)
        {
            string msg = "El Id ingresado no existe";
            try
            {
                conexioncontacto.Open();
                string consulta = "select id_afiliado from contacto_emergencia where id_afiliado=@id_afiliado";
                MySqlCommand cmd = new MySqlCommand(consulta, conexioncontacto);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_afiliado", id);
                cmd.ExecuteNonQuery();
                msg = "Contacto encontrado con exito :)";


            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            conexioncontacto.Close();
            return msg;
        }


    }
}
