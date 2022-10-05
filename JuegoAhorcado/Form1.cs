using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JuegoAhorcado
{
    public partial class Form1 : Form
    {
        Partida juego; //Se crea el objeto de la Clase Partida
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            //El programa funcionará mientras no haya victoria ni haya derrota
            if (juego.victoria() == false && juego.derrota() == false)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                juego.verificar(btn.Text);
                TxtResultado.Text = juego.imprimirPalabra();
                LblIntento.Text = juego.intento.ToString();         

                //Un switch que pondrá la imagen en el PictureBox dependiendo del intento
                switch (juego.intento)
                {
                    case 1:
                        PBintentos.Image = Properties.Resources.Intento1;
                        break;
                    case 2:
                        PBintentos.Image = Properties.Resources.Intento2;
                        break;
                    case 3:
                        PBintentos.Image = Properties.Resources.Intento3;
                        break;
                    case 4:
                        PBintentos.Image = Properties.Resources.Intento4;
                        break;
                    case 5:
                        PBintentos.Image = Properties.Resources.Intento5;
                        break;
                    case 6:
                        PBintentos.Image = Properties.Resources.Intento6;
                        break;
                    case 7:
                        PBintentos.Image = Properties.Resources.Intento7;
                        break;
                    default:
                        break;
                }

                //Si victoria es true, significa que el usuario reunió los
                //requisitos para ser el ganador
                if (juego.victoria() == true)
                {
                    DialogResult resultado = MessageBox.Show("    VICTORIA !!!!    \n\n\n¿Desea Jugar otra Partida?", "Juego del Ahorcado", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        this.Dispose();
                    }
                }

                //Si derrota es true, significa que el usuario reunió los
                //requisitos para ser el perdedor
                if (juego.derrota() == true)
                {
                    DialogResult resultado = MessageBox.Show("    GAME OVER !!    \n\nLa palabra Secreta era: " + juego.palabraSecreta + "\n\n¿Desea Jugar otra Partida?", "Juego del Ahorcado", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
            } 
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtPalabraSecreta.PasswordChar = '*'; //Para que la caja de texto se vean 
                                                    //asteriscos en lugar de letras
        }

        private void BtnIniciarJuego_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtPalabraSecreta.Text))
            {
                MessageBox.Show("No ha ingresado ninguna palabra", "Juego del Ahorcado", MessageBoxButtons.OK);
            }
            else
            {
                juego = new Partida(TxtPalabraSecreta.Text);
                TxtResultado.Text = juego.imprimirPalabra();
                BtnIniciarJuego.Enabled = false;
                TxtPalabraSecreta.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void TxtPalabraSecreta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtResultado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
