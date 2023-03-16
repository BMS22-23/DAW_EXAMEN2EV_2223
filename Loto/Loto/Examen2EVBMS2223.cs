using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotoClassNS;

namespace ExamenLoto
{
    public partial class Examen2EVBMS2223 : Form
    {
        public BMS2223 miLoto, miGanadora;
        public const int NUMEROMAXIMONUMEROS = 6;
        private TextBox[] combinacion = new TextBox[NUMEROMAXIMONUMEROS]; // Estos arrays se usan para recorrer de manera más sencilla los controles
        private TextBox[] ganadora = new TextBox[NUMEROMAXIMONUMEROS];
        public Examen2EVBMS2223()
        {
            InitializeComponent();
            combinacion[0] = txtNumero1; ganadora[0] = txtGanadora1;
            combinacion[1] = txtNumero2; ganadora[1] = txtGanadora2;
            combinacion[2] = txtNumero3; ganadora[2] = txtGanadora3;
            combinacion[3] = txtNumero4; ganadora[3] = txtGanadora4;
            combinacion[4] = txtNumero5; ganadora[4] = txtGanadora5;
            combinacion[5] = txtNumero6; ganadora[5] = txtGanadora6;
            miGanadora = new BMS2223(); // generamos la combinación ganadora
            for (int i = 0; i < NUMEROMAXIMONUMEROS; i++)
                ganadora[i].Text = Convert.ToString(miGanadora.Nums[i]);

        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            miLoto = new BMS2223(); // usamos constructor vacío, se genera combinación aleatoria
            for ( int i=0; i< NUMEROMAXIMONUMEROS; i++ )
                combinacion[i].Text = Convert.ToString(miLoto.Nums[i]);
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            int[] nums = new int[NUMEROMAXIMONUMEROS];    
            for (int i = 0; i < NUMEROMAXIMONUMEROS; i++)
                nums[i] = Convert.ToInt32(combinacion[i].Text);
            miLoto = new BMS2223(nums);
            if (miLoto.esCombinacionValida)
                MessageBox.Show("Combinación válida");
            else
                MessageBox.Show("Combinación no válida");
        }

        private void btComprobar_Click(object sender, EventArgs e)
        {
            int[] nums = new int[NUMEROMAXIMONUMEROS];
            for (int i = 0; i < NUMEROMAXIMONUMEROS; i++)
                nums[i] = Convert.ToInt32(combinacion[i].Text);
            miLoto = new BMS2223(nums);
            if (miLoto.esCombinacionValida)
            {
                nums = new int[NUMEROMAXIMONUMEROS];
                for (int i = 0; i < NUMEROMAXIMONUMEROS; i++)
                    nums[i] = Convert.ToInt32(combinacion[i].Text);
                int aciertos = miGanadora.Comprobar(nums);
                if (aciertos < 3)
                    MessageBox.Show("No ha resultado premiada");
                else
                    MessageBox.Show("¡Enhorabuena! Tiene una combinación con " + Convert.ToString(aciertos) + " aciertos");
            }
            else
                MessageBox.Show("La combinación introducida no es válida");
        }
    }
}
