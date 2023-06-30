using Fundacion.Clases;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Fundacion.Conexion
{
    public class ConexionUsuario
    {
        private MySqlConnection conexionusuario = new MySqlConnection();

        public ConexionUsuario(string _datos)
        {
            conexionusuario.ConnectionString = _datos;
        }

        static List<Usuario> lista_user = new List<Usuario>();
        static Usuario user = new Usuario();
        static List<Departamento> deptos = new List<Departamento>();
       static List<Ciudad> muns = new List<Ciudad>();

        public Usuario validar(string[] usuario)
        {
            Usuario user = new Usuario();

            try
            {
                conexionusuario.Open();
                MySqlCommand cmd = new MySqlCommand("select name, lastname, User, password, rol from user where User= @User and password = @password", conexionusuario);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@User", usuario[0]);
                cmd.Parameters.AddWithValue("@password", usuario[1]);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    user.Name = info.GetString(0);
                    user.Lastname = info.GetString(1);
                    user.User = info.GetString(2);
                    user.Password = info.GetString(3);
                    user.Rol = info.GetString(4);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            conexionusuario.Close();
            return user;
        }

        public List<Usuario> read()
        {
                try
                {
                    conexionusuario.Open();
                    MySqlCommand cmd = new MySqlCommand("select  name, lastname, user, rol from user", conexionusuario);
                    cmd.Parameters.Clear();
                    MySqlDataReader info = cmd.ExecuteReader();

                    while (info.Read())
                    {

                        lista_user.Add(new Usuario {  Name = info.GetString(0), Lastname = info.GetString(1), User = info.GetString(2), Rol = info.GetString(3) });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            conexionusuario.Close();
                return lista_user;  
        }

        public Usuario search(string msg)
        {
            try
            {
                conexionusuario.Open();
                MySqlCommand cmd = new MySqlCommand("select  name, lastname, user, password, rol from user where User= @User", conexionusuario);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@User", msg);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {
                    user.Name = info.GetString(0);
                    user.Lastname = info.GetString(1);
                    user.User = info.GetString(2);
                    user.Password = info.GetString(3);
                    user.Rol = info.GetString(4);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            conexionusuario.Close();
            return user;
        }


        public string create(Usuario usuario)
        {
            string respuesta = null;
            try
            {
                conexionusuario.Open();
                string consulta = "Insert into user (name, lastname, user, password, rol) values (@name, @lastname, @user, @password, @rol)";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionusuario);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", usuario.Name);
                cmd.Parameters.AddWithValue("@lastname", usuario.Lastname);
                cmd.Parameters.AddWithValue("@user", usuario.User);
                cmd.Parameters.AddWithValue("@password", usuario.Password);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                cmd.ExecuteNonQuery();
                respuesta = "Usuario ingresado con exito :)";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionusuario.Close();
            return respuesta;
        }


        public string update(Usuario user)
        {
            string respuesta = null;
            try
            {
                conexionusuario.Open();
                string consulta = "Update user set name=@name, lastname=@lastname, password=@password, rol=@rol where user=@user";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionusuario);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                cmd.Parameters.AddWithValue("@user", user.User);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@rol", user.Rol);

                cmd.ExecuteNonQuery();
                respuesta = "Usuario actualizado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            conexionusuario.Close();
            return respuesta;
        }

        public string delete(string msg)
        {
            string respuesta = null;
            try
            {
                conexionusuario.Open();
                string consulta = "delete from user where user.user=@user";
                MySqlCommand cmd = new MySqlCommand(consulta, conexionusuario);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@user", msg);
                cmd.ExecuteNonQuery();
                respuesta = "Usuario eliminado con exito :)";

            }
            catch (Exception ex)
            {
                respuesta = "\n" + ex.Message;
            }
            conexionusuario.Close();
            return respuesta;

        }

        public List<Departamento> cargar()
        {
            try
            {
                conexionusuario.Open();
                MySqlCommand cmd = new MySqlCommand("select  departamento from departamento", conexionusuario);
                cmd.Parameters.Clear();
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {

                    deptos.Add(new Departamento { Depto = info.GetString(0) });
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conexionusuario.Close();
            return deptos;
        }

        public List<Ciudad> cargar_datos(string depto)
        {
            try
            {
                conexionusuario.Open();
                MySqlCommand cmd = new MySqlCommand("select  municipio from ciudad where departamento =@depto", conexionusuario);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@depto", depto);
                MySqlDataReader info = cmd.ExecuteReader();

                while (info.Read())
                {

                    muns.Add(new Ciudad { Municipio = info.GetString(0) });

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conexionusuario.Close();
            return muns;
        }
       

    }
}
