using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    class Partida
    {
        public string palabraSecreta { get; set; }

        public string[] palabra { get; set; }

        public int intento { get; set; }
        public Partida (string palabraSecreta)
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
                string palabraArreglo = this.palabraSecreta;
                palabraArreglo.ToCharArray();
                for (int i = 0; i < palabraArreglo.Length; i++)
                {
                    if (palabraArreglo[i].Equals(char.Parse(letra)) == true)
                    {
                        this.palabra[i] = letra;
                    }
                }
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

        public bool victoria()
        {
            if (!imprimirPalabra().Contains("_"))
            {
                return true;
            }
            return false;
        }

        public bool derrota()
        {
            if (this.intento == 7)
            {
                return true;
            }
            return false;
        }

    }
}
