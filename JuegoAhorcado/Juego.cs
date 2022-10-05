using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    class Juego
    {
        public string palabraSecreta { get; set; }

        public string[] palabra { get; set; }

        public int intento { get; set; }
        public Juego (string palabraSecreta)
        {
            this.palabraSecreta = palabraSecreta.ToUpper();
            palabra = new string[palabraSecreta.Length];
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                this.palabra[i] = "_";
            }
            this.intento = 0;
        }


        public void verificar(string letra)
        {
            if (this.palabraSecreta.Contains(letra))
            {
                this.palabra[this.palabraSecreta.IndexOf(letra)] = letra;
            }
            else
            {
                intento++;
            }
        }

        public string imprimirPalabra()
        {
            string cadena = "";
            for (int i = 0; i < this.palabra.Length; i++)
            {
                cadena = cadena + " " + this.palabra[i];
            }
            return cadena;
        }

    }
}
