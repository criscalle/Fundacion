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
    public class ConexionAfiliado
    {

        private MySqlConnection conexionafiliado = new MySqlConnection();

        public ConexionAfiliado(string _datos)
        {
            conexionafiliado.ConnectionString = _datos;
        }

        static Afiliado afil = new Afiliado();
        static List <Afiliado> lista = new List <Afiliado>();


        public string create(Afiliado afiliado)
        {
            string respuesta = null;
            try
            {
                conexionafiliado.Open();
                string consulta = "Insert into afiliado (id, tipo_doc, nombres, apellidos, genero, depto, municipio, barrio, comuna, direccion, telefono, email, fecha_nacimiento, fecha_afiliacion, eps, ips, condicion, pension, nivel_sisben, desplazado, promedio_gastos, ayudas_gobierno, mascotas, categoria, create_at, update_at, user, limitaciones, analfabetismo) values (@id, @tipo_doc, @nombres, @apellidos, @genero, @depto, @municipio,@barrio, @comuna, @direccion, @telefono, @email, @fecha_nac, @fecha_afil, @eps, @ips, @condicion, @pension, @nivel_sis, @deplaz, @gastos, @ayudas, @mascotas, @categoria, @create, @update, @user, @limitaciones, @analfabetismo )";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionafiliado);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", afiliado.Id);
                cmd.Parameters.AddWithValue("@tipo_doc", afiliado.Tipo_doc);
                cmd.Parameters.AddWithValue("@nombres", afiliado.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", afiliado.Apellidos);
                cmd.Parameters.AddWithValue("@genero", afiliado.Genero);
                cmd.Parameters.AddWithValue("@depto", afiliado.Depto);
                cmd.Parameters.AddWithValue("@municipio", afiliado.Ciudad);
                cmd.Parameters.AddWithValue("@barrio", afiliado.Barrio);
                cmd.Parameters.AddWithValue("@comuna", afiliado.Comuna);
                cmd.Parameters.AddWithValue("@direccion", afiliado.Direccion);
                cmd.Parameters.AddWithValue("@telefono", afiliado.Telefono);
                cmd.Parameters.AddWithValue("@email", afiliado.Email);
                cmd.Parameters.AddWithValue("@fecha_nac", afiliado.Fecha_nacimiento);
                cmd.Parameters.AddWithValue("@fecha_afil", afiliado.Fecha_afiliacion);
                cmd.Parameters.AddWithValue("@eps", afiliado.Eps);
                cmd.Parameters.AddWithValue("@ips", afiliado.Ips);
                cmd.Parameters.AddWithValue("@condicion", afiliado.Condicion);
                cmd.Parameters.AddWithValue("@pension", afiliado.Pension);
                cmd.Parameters.AddWithValue("@nivel_sis", afiliado.Sisben);
                cmd.Parameters.AddWithValue("@deplaz", afiliado.Desplazado);
                cmd.Parameters.AddWithValue("@gastos", afiliado.Gastos);
                cmd.Parameters.AddWithValue("@ayudas", afiliado.Ayudas);
                cmd.Parameters.AddWithValue("@mascotas", afiliado.Mascotas);
                cmd.Parameters.AddWithValue("@categoria", afiliado.Categoria);
                cmd.Parameters.AddWithValue("@user", afiliado.User);
                cmd.Parameters.AddWithValue("@create", afiliado.Create);
                cmd.Parameters.AddWithValue("@update", afiliado.Update);
                cmd.Parameters.AddWithValue("@limitaciones", afiliado.Limitaciones);
                cmd.Parameters.AddWithValue("@analfabetismo", afiliado.Analfabetismo);


                cmd.ExecuteNonQuery();
                respuesta = "Afiliado ingresado con exito :)";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionafiliado.Close();
            return respuesta;
        }

        public Afiliado search(string msg)
        {
            try
            {
                conexionafiliado.Open();
                MySqlCommand cmd = new MySqlCommand("select  id, tipo_doc, nombres, apellidos, genero, depto, municipio, barrio, comuna, direccion, telefono, email, fecha_nacimiento, eps, fecha_afiliacion, ips, condicion, pension, nivel_sisben, desplazado, promedio_gastos, ayudas_gobierno, mascotas, categoria, user, create_at, update_at, limitaciones, analfabetismo from afiliado where id= @id", conexionafiliado);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", msg);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    afil.Id = info.GetInt32(0);
                    afil.Tipo_doc = info.GetString(1);
                    afil.Nombres = info.GetString(2);
                    afil.Apellidos = info.GetString(3);
                    afil.Genero = info.GetString(4);
                    afil.Depto = info.GetString(5);
                    afil.Ciudad = info.GetString(6);
                    afil.Barrio = info.GetString(7);
                    afil.Comuna = info.GetString(8);
                    afil.Direccion = info.GetString(9);
                    afil.Telefono = info.GetString(10);
                    afil.Email = info.GetString(11);
                    afil.Fecha_nacimiento = info.GetDateTime(12);
                    afil.Eps = info.GetString(13);
                    afil.Fecha_afiliacion = info.GetDateTime(14);
                    afil.Ips = info.GetString(15);
                    afil.Condicion = info.GetString(16);
                    afil.Pension = info.GetString(17);
                    afil.Sisben = info.GetString(18);
                    afil.Desplazado = info.GetString(19);
                    afil.Gastos = info.GetString(20);
                    afil.Ayudas = info.GetString(21);
                    afil.Mascotas = info.GetString(22);
                    afil.Categoria = info.GetString(23);
                    afil.User = info.GetString(24);
                    afil.Create = info.GetDateTime(25);
                    afil.Update = info.GetDateTime(26);
                    afil.Limitaciones = info.GetString(27);
                    afil.Analfabetismo = info.GetString(28);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexionafiliado.Close();
            return afil;
        }

        public string delete(int id)
        {
            string respuesta = null;
            try
            {
                conexionafiliado.Open();
                string consulta = "delete from afiliado where afiliado.id=@id";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionafiliado);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                respuesta = "Afiliado eliminado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = "\n" + ex.Message;
            }
            conexionafiliado.Close();
            return respuesta;

        }

        public string update(Afiliado afil)
        {
            string respuesta = null;
            try
            {
                conexionafiliado.Open();
                string consulta = "Update afiliado set tipo_doc=@tipo_doc, nombres=@nombre, apellidos=@apellidos, genero=@genero, depto=@depto, municipio=@municipio, barrio=@barrio, comuna=@comuna, direccion=@direccion, telefono=@telefono, email=@email, eps=@eps, ips=@ips, condicion=@condicion, pension=@pension, nivel_sisben=@sisben, desplazado=@desplazado, promedio_gastos=@gastos, ayudas_gobierno=@ayudas, mascotas=@mascotas, categoria=@categoria, user=@user, update_at=@update, limitaciones=@limitaciones, analfabetismo=@limitaciones where id=@id";

                MySqlCommand cmd = new MySqlCommand(consulta, conexionafiliado);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", afil.Id);
                cmd.Parameters.AddWithValue("@tipo_doc", afil.Tipo_doc);
                cmd.Parameters.AddWithValue("@nombre", afil.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", afil.Apellidos);
                cmd.Parameters.AddWithValue("@genero", afil.Genero);
                cmd.Parameters.AddWithValue("@depto", afil.Depto);
                cmd.Parameters.AddWithValue("@municipio", afil.Ciudad);
                cmd.Parameters.AddWithValue("@barrio", afil.Barrio);
                cmd.Parameters.AddWithValue("@comuna", afil.Comuna);
                cmd.Parameters.AddWithValue("@direccion", afil.Direccion);
                cmd.Parameters.AddWithValue("@telefono", afil.Telefono);
                cmd.Parameters.AddWithValue("@email", afil.Email);
                cmd.Parameters.AddWithValue("@eps", afil.Eps);
                cmd.Parameters.AddWithValue("@ips", afil.Ips);
                cmd.Parameters.AddWithValue("@condicion", afil.Condicion);
                cmd.Parameters.AddWithValue("@pension", afil.Pension);
                cmd.Parameters.AddWithValue("@sisben", afil.Sisben);
                cmd.Parameters.AddWithValue("@desplazado", afil.Desplazado);
                cmd.Parameters.AddWithValue("@gastos", afil.Gastos);
                cmd.Parameters.AddWithValue("@ayudas", afil.Ayudas);
                cmd.Parameters.AddWithValue("@mascotas", afil.Mascotas);
                cmd.Parameters.AddWithValue("@categoria", afil.Categoria);
                cmd.Parameters.AddWithValue("@user", afil.User);
                cmd.Parameters.AddWithValue("@update", afil.Update);
                cmd.Parameters.AddWithValue("@user", afil.Limitaciones);
                cmd.Parameters.AddWithValue("@update", afil.Analfabetismo);

                cmd.ExecuteNonQuery();
                respuesta = "Afiliado actualizado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionafiliado.Close();
            return respuesta;
        }

        public List<Afiliado> listar_cond(string msg)
        {
            try
            {
                conexionafiliado.Open();
                MySqlCommand cmd = new MySqlCommand("select  id, nombres, apellidos, municipio, barrio, telefono, condicion, categoria from afiliado where condicion=@condicion", conexionafiliado);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@condicion", msg);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    lista.Add(new Afiliado { Id = info.GetInt32(0), Nombres = info.GetString(1), Apellidos = info.GetString(2), Ciudad = info.GetString(3), Barrio = info.GetString(4), Telefono = info.GetString(5), Condicion = info.GetString(6), Categoria =info.GetString(7) });

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexionafiliado.Close();
            return lista;
        }


        public List<Afiliado> listar_cat(string msg)
        {
            try
            {
                conexionafiliado.Open();
                MySqlCommand cmd = new MySqlCommand("select  id, nombres, apellidos, municipio, barrio, telefono, condicion, categoria from afiliado where categoria=@categoria", conexionafiliado);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categoria", msg);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    lista.Add(new Afiliado { Id = info.GetInt32(0), Nombres = info.GetString(1), Apellidos = info.GetString(2), Ciudad = info.GetString(3), Barrio = info.GetString(4), Telefono = info.GetString(5), Condicion = info.GetString(6), Categoria = info.GetString(7) });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexionafiliado.Close();
            return lista;
        }

        public List<Afiliado> listar_edad()
        {
            try
            {
                conexionafiliado.Open();
                MySqlCommand cmd = new MySqlCommand("select  id, nombres, apellidos, municipio, barrio, telefono, condicion, categoria, fecha_nacimiento from afiliado", conexionafiliado);
                cmd.Parameters.Clear();
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    lista.Add(new Afiliado { Id = info.GetInt32(0), Nombres = info.GetString(1), Apellidos = info.GetString(2), Ciudad = info.GetString(3), Barrio = info.GetString(4), Telefono = info.GetString(5), Condicion = info.GetString(6), Categoria = info.GetString(7), Fecha_nacimiento= info.GetDateTime(8) });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexionafiliado.Close();
            return lista;
        }



    }
}
