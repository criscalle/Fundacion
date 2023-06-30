using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Clases
{
    public class Afiliado
    {
        private int id;
        private string tipo_doc;
        private string nombres;
        private string apellidos;
        private string genero;
        private string depto;
        private string ciudad;
        private string barrio;
        private string comuna;
        private string telefono;
        private string direccion;
        private string email;
        private DateTime fecha_nacimiento;
        private DateTime fecha_afiliacion;
        private string eps;
        private string ips;
        private string condicion;
        private string pension;
        private string sisben;
        private string desplazado;
        private string gastos;
        private string ayudas;
        private string mascotas;
        private string categoria;
        private string user;
        private string limitaciones;
        private string analfabetismo;
        private DateTime create;
        private DateTime update;
       

        public int Id { get => id; set => id = value; }
        public string Tipo_doc { get => tipo_doc; set => tipo_doc = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Depto { get => depto; set => depto = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }

        public string Barrio { get => barrio; set => barrio = value; }
        public string Comuna { get => comuna; set => comuna = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public DateTime Fecha_afiliacion { get => fecha_afiliacion; set => fecha_afiliacion = value; }
        public string Eps { get => eps; set => eps = value; }
        public string Ips { get => ips; set => ips = value; }
        public string Condicion { get => condicion; set => condicion = value; }
        public string User { get => user; set => user = value; }
        public string Pension { get => pension; set => pension = value; }
        public string Sisben { get => sisben; set => sisben = value; }
        public string Gastos { get => gastos; set => gastos = value; }
        public string Ayudas { get => ayudas; set => ayudas = value; }
        public string Mascotas { get => mascotas; set => mascotas = value; }
        public string Desplazado { get => desplazado; set => desplazado = value; }
        public DateTime Update { get => update; set => update = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public DateTime Create { get => create; set => create = value; }
        public string Limitaciones { get => limitaciones; set => limitaciones = value; }
        public string Analfabetismo { get => analfabetismo; set => analfabetismo = value; }

        public Afiliado() { }
          
        
    }
}
