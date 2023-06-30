using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Clases
{
    public class Pagos
    {
        private int id;
        private int id_afiliado;
        private int cuota;
        private DateTime fecha_pago;
        private string concepto;
        private string user;
        private DateTime update_at;
        private DateTime create_at;


        public int Cuota { get => cuota; set => cuota = value; }
        public DateTime Fecha_pago { get => fecha_pago; set => fecha_pago = value; }
        public string Concepto { get => concepto; set => concepto = value; }
        public int Id { get => id; set => id = value; }
        public int Id_afiliado { get => id_afiliado; set => id_afiliado = value; }
        public string User { get => user; set => user = value; }
        public DateTime Update_at { get => update_at; set => update_at = value; }
        public DateTime Create_at { get => create_at; set => create_at = value; }

        public Pagos() { }
    }
}
