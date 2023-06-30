using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Clases
{
    public class FundTran
    {
        private string nit;
        private string name;
        private string tipo_transplante;
        private string tutela;
        private string hospedaje;
        private string rechazo;
        private string motivo;
        private string info_fundacion;
        private int id_persona;

        public string Nit { get => nit; set => nit = value; }
        public string Name { get => name; set => name = value; }
        public string Tipo_transplante { get => tipo_transplante; set => tipo_transplante = value; }
        public string Tutela { get => tutela; set => tutela = value; }
        public string Hospedaje { get => hospedaje; set => hospedaje = value; }
        public string Rechazo { get => rechazo; set => rechazo = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public string Info_fundacion { get => info_fundacion; set => info_fundacion = value; }
        public int Id_persona { get => id_persona; set => id_persona = value; }


        public FundTran() { }


    }
}
