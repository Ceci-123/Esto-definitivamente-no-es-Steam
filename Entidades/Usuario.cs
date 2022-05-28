using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int codigoUsuario;
        private string username;

        public Usuario(int codigoUsuario, string username)
        {
            this.codigoUsuario = codigoUsuario;
            this.username = username;
        }

        public int CodigoUsuario { get => codigoUsuario; }

        public override string ToString()
        {
            return $"Nombre de usuario {this.username}";
        }
    }
}
