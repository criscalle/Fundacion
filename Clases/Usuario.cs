using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Clases
{
    public class Usuario
    {
        private string name;
        private string lastname;
        private string user;
        private string password;
        private string rol;

        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }

        public Usuario() { }
    }
}
