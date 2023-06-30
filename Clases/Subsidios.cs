using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Clases
{
    public class Subsidios
    {
        private int id;
        private int id_afiliado;
        private int valor;
        private string concepto;
        private string user;
        private DateTime fecha_entrega;
        private DateTime create_at;
        private DateTime update_at;

        public int Id { get => id; set => id = value; }
        public int Id_afiliado { get => id_afiliado; set => id_afiliado = value; }
        public int Valor { get => valor; set => valor = value; }
        public string Concepto { get => concepto; set => concepto = value; }
        public string User { get => user; set => user = value; }
        public DateTime Update_at { get => update_at; set => update_at = value; }
        public DateTime Create_at { get => create_at; set => create_at = value; }
        public DateTime Fecha_entrega { get => fecha_entrega; set => fecha_entrega = value; }

        public Subsidios() { }
    }
}
