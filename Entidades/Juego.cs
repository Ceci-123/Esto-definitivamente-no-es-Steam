using System;

namespace Entidades
{
    public class Juego
    {
        private int codigoJuego;
        private int codigoUsuario;
        private string nombre;
        private string genero;
        private double precio;

        public Juego(int codigoJuego, int codigoUsuario, string nombre, string genero, double precio)
            : this(codigoUsuario, nombre, genero, precio)
        {
            this.codigoJuego = codigoJuego;
            
        }

        public Juego(int codigoUsuario, string nombre, string genero, double precio)
        {
            this.codigoUsuario = codigoUsuario;
            this.nombre = nombre;
            this.genero = genero;
            this.precio = precio;
        }
        public int CodigoJuego { get => codigoJuego; }
        public int CodigoUsuario { get => codigoUsuario; }
        public string Nombre { get => nombre; }
        public string Genero { get => genero; }
        public double Precio { get => precio; }
    }
}
