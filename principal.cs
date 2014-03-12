using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ahorcaito
{
    public partial class principal : Form
    {
        char[] termino = new char[0];
        char[] palabra = new char[0];
        int numOportunidades;
        bool gano;
        bool perdio;
        bool encontrada;
        int oportuRestantes;
        bool yaesta;
        String refran;
        StreamReader archivo;
        int numActual = 0;

        public principal()
        {
            InitializeComponent();
            numOportunidades = 6;
            oportuRestantes = 0;
            gano = false;
            perdio = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            yaesta = false;
            if (palabra.Length == 0)
            {
                DesabilitarBotones();
            }
        }

        public void Limpiar()
        {                 
            this.txtJuego.Text = "";            
            this.lblFallidos.Visible = false;
            this.lblOportunidades.Visible = false;
            numOportunidades = 5;
            oportuRestantes = 0;
            gano = false;
            perdio = false;
            termino = new char[0];
            palabra = new char[0];
            yaesta = false;
            this.image1.Visible = false;
            this.image2.Visible = false;
            this.image3.Visible = false;
            this.image4.Visible = false;
            this.pictureBox1.Visible = false;
            habilitarBotones();
            this.btonPrincipiante.Enabled = true;
            this.btonAvanzado.Enabled = false;
            if (palabra.Length == 0)
            {
                DesabilitarBotones();
            }

        }

        private void habilitarBotones()
        {
            this.a.Enabled = true;
            this.b.Enabled = true;
            this.c.Enabled = true;
            this.d.Enabled = true;
            this.e.Enabled = true;
            this.f.Enabled = true;
            this.g.Enabled = true;
            this.h.Enabled = true;
            this.i.Enabled = true;
            this.j.Enabled = true;
            this.k.Enabled = true;
            this.l.Enabled = true;
            this.m.Enabled = true;
            this.n.Enabled = true;
            this.o.Enabled = true;
            this.p.Enabled = true;
            this.q.Enabled = true;
            this.r.Enabled = true;
            this.s.Enabled = true;
            this.t.Enabled = true;
            this.u.Enabled = true;
            this.v.Enabled = true;
            this.w.Enabled = true;
            this.x.Enabled = true;
            this.y.Enabled = true;
            this.z.Enabled = true;
        }

        private void DesabilitarBotones()
        {
            this.a.Enabled = false;
            this.b.Enabled = false;
            this.c.Enabled = false;
            this.d.Enabled = false;
            this.e.Enabled = false;
            this.f.Enabled = false;
            this.g.Enabled = false;
            this.h.Enabled = false;
            this.i.Enabled = false;
            this.j.Enabled = false;
            this.k.Enabled = false;
            this.l.Enabled = false;
            this.m.Enabled = false;
            this.n.Enabled = false;
            this.o.Enabled = false;
            this.p.Enabled = false;
            this.q.Enabled = false;
            this.r.Enabled = false;
            this.s.Enabled = false;
            this.t.Enabled = false;
            this.u.Enabled = false;
            this.v.Enabled = false;
            this.w.Enabled = false;
            this.x.Enabled = false;
            this.y.Enabled = false;
            this.z.Enabled = false;
        }

        private void mostrarControles()
        {            
            this.lblFallidos.Visible = true;
            this.lblOportunidades.Visible = true;
        }

        private void botonjugar_click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Equals("Principiante"))
            {
                this.btonAvanzado.Enabled = false;
                habilitarBotones();
            }
            else
            {
                this.btonPrincipiante.Enabled = false;
                habilitarBotones();
            }

            Random r = new Random();
            string ruta = "..\\..\\";
            archivo = new StreamReader(ruta+"REFRANES.txt");
            int numAhora = r.Next(5);
            while (numActual == numAhora)
            {
                numAhora = r.Next(9);
            }
            numActual = numAhora;
            for (int k = 0; k < numActual; k++)
            {
                refran = archivo.ReadLine();
            }
     
            palabra = refran.ToCharArray();            

            termino = new char[palabra.Length];            
            txtJuego.Text = "";
            for (int i = 0; i < termino.Length; i++)
            {
                if (palabra[i] == ' ')
                {
                    termino[i] = ' ';                    
                    txtJuego.Text += termino[i] + "  ";
                }else if(palabra[i] == ','){
                    termino[i] = ',';
                    txtJuego.Text += termino[i] + "  ";
                }
                else if (palabra[i] == '.')
                {
                    termino[i] = '.';
                    txtJuego.Text += termino[i] + "  ";
                }else
                {
                    termino[i] = '_';                    
                    txtJuego.Text += termino[i] + "  ";
                }
            }
            mostrarControles();
            this.lblOportunidades.Text = this.oportuRestantes.ToString();            
        }

        private void boton_letra_click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            encontrada = false;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (((Button)sender).Name.Equals(palabra[i].ToString()) || ((Button)sender).Text.Equals(palabra[i].ToString()))
                {

                    termino[i] = palabra[i];
                    encontrada = true;
                    this.lblEncontro.Visible = true;
                    this.lblNoEncontro.Visible = false;                   
                }
            }
            txtJuego.Text = "";            
            for (int j = 0; j < termino.Length; j++)
            {
                txtJuego.Text += termino[j].ToString() + "  ";                
            }
            if (encontrada == false)
            {                
                this.lblEncontro.Visible = false;
                oportuRestantes++;
                this.lblOportunidades.Text = this.oportuRestantes.ToString();
                this.lblNoEncontro.Visible = true;
                colocarMalo();
                Perdio();
                if (this.perdio)
                {

                    MessageBox.Show("  La palabra a encontrar era:  " + this.refran, "PERDISTE!!", MessageBoxButtons.OK);
                    DialogResult result = MessageBox.Show("Deseas Jugar de nuevo?", "Ahorcahito", MessageBoxButtons.YesNo);
                    if (result.ToString().Equals("No"))
                    {
                        this.Close();
                    }
                    else
                    {
                        Limpiar();
                    }

                }
            }
            else
            {
                gano = Gano();
                if (gano)
                {
                    MessageBox.Show("GANASTE!!", "ENHORABUENA", MessageBoxButtons.OK);
                    DialogResult result = MessageBox.Show("Deseas Jugar de nuevo?", "Ahorcahito", MessageBoxButtons.YesNo);
                    if (result.ToString().Equals("No"))
                    {
                        this.Close();
                    }
                    else
                    {
                        Limpiar();
                       
                    }
                }
            }

        }

        private Boolean Gano()
        {
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] != termino[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void colocarMalo()
        {
            switch (oportuRestantes)
            {
                case 1:
                    this.image1.Visible = true;
                    break;
                case 2:
                    this.image2.Visible = true;
                    break;
                case 3:
                    this.image3.Visible = true;
                    break;
                case 4:
                    this.image4.Visible = true;
                    break;
                case 5:
                    this.pictureBox1.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void Perdio()
        {
            if (oportuRestantes == numOportunidades)
            {
                this.perdio = true;
            }
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            numOportunidades = 5;
            oportuRestantes = 0;
            gano = false;
            perdio = false;
        }

        private Boolean yaEsta(char letra)
        {
            for (int i = 0; i < termino.Length; i++)
            {
                if (termino[i] == letra)
                {
                    return  true;
                }
            }
            return false;
        }

        private void Generar_Letra_click(object sender, EventArgs e)
        {
            if (palabra.Length > 0)
            {
                Random r = new Random();
                Char letra;
                do
                {
                    int Aleatorio = r.Next(palabra.Length);
                    letra = palabra[Aleatorio];
                    yaesta = yaEsta(letra);
                } while (yaesta);
                txtJuego.Text = "";                
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i].Equals(letra))
                    {
                        termino[i] = palabra[i];
                    }
                    txtJuego.Text += termino[i] + "  ";                   
                }
                gano = Gano();
                if (gano)
                {
                    MessageBox.Show("GANASTE!!", "ENHORABUENA", MessageBoxButtons.OK);
                    DialogResult result = MessageBox.Show("Deseas Jugar de nuevo?", "Ahorcahito", MessageBoxButtons.YesNo);
                    if (result.ToString().Equals("No"))
                    {
                        this.Close();
                    }
                    else
                    {
                        Limpiar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debes Iniciar El juego", "Advertencia", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();            
        }
    }
}
