using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Clases
{
    public class Contacto
    {
        private string id;
        private string name;
        private string lastname;
        private string parentesco;
        private string phone;
        private string celphone;
        private string email;
        private string adress;
        private string city;
        private int id_afiliado;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Parentesco { get => parentesco; set => parentesco = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Celphone { get => celphone; set => celphone = value; }
        public string Email { get => email; set => email = value; }
        public string Adress { get => adress; set => adress = value; }
        public string City { get => city; set => city = value; }
        public int Id_afiliado { get => id_afiliado; set => id_afiliado = value; }

        public Contacto() { }
    }
}
