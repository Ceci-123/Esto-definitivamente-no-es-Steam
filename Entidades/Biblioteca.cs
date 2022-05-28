using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        private int codigoJuego;
        private string juego;
        private string genero;
        private string usuario;

        public Biblioteca(int codigoJuego, string juego, string genero, string usuario)
        {
            this.codigoJuego = codigoJuego;
            this.juego = juego;
            this.genero = genero;
            this.usuario = usuario;
        }

        public int CodigoJuego { get => codigoJuego;  }
        public string Juego { get => juego;  }
        public string Genero { get => genero;  }
        public string Usuario { get => usuario; }
    }
}
