using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Clases
{
    public class Fundacion
    {
        private int id;
        private string name;
        private string tipo_transplante;
        private string subsidio;
        private string tutela;
        private string hospedaje;
        private string rechazo;
        private string motivo;
        private string info_fundacion;
        private string pago_cuota;
        private DateTime fecha_pago;
        private string mes_pago;
        private int id_persona;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Tipo_transplante { get => tipo_transplante; set => tipo_transplante = value; }
        public string Subsidio { get => subsidio; set => subsidio = value; }
        public string Tutela { get => tutela; set => tutela = value; }
        public string Hospedaje { get => hospedaje; set => hospedaje = value; }
        public string Rechazo { get => rechazo; set => rechazo = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public string Info_fundacion { get => info_fundacion; set => info_fundacion = value; }
        public string Pago_cuota { get => pago_cuota; set => pago_cuota = value; }
        public DateTime Fecha_pago { get => fecha_pago; set => fecha_pago = value; }
        public string Mes_pago { get => mes_pago; set => mes_pago = value; }
        public int Id_persona { get => id_persona; set => id_persona = value; }


        public Fundacion()
        {
            
        }

    }
}
