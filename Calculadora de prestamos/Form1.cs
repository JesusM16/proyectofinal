using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_prestamos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double TasaI;

        public static Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox4.Enabled = true;
                textBox4.Focus();
            }
            else
            {
                textBox4.Text = "0";
                textBox4.Enabled = false;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            TasaI = 0.12;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            TasaI = 0.235;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea salir?","SALIR",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NomEmpre;
            double MontoInic = 0;
            double MontoFIn = 0;
            int tiempo;

            NomEmpre = textBox1.Text;
            NomEmpre = NomEmpre.Trim();
            if(NomEmpre.Length == 0)
            {
                MessageBox.Show("Debe iniciar Nombre de la empresa", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (!(IsNumeric(textBox2.Text)))
            {
                MessageBox.Show("El valor del monto es incorrecto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
            else
            {
                MontoInic = Convert.ToDouble(textBox2.Text);
                if(!(MontoInic > 0))
                {
                    MessageBox.Show("El valor del monto no puede ser negativo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                    return;
                }
            }

            tiempo = Convert.ToInt32(textBox3.Text);
            textBox4.Text = textBox4.Text.Trim();
            if(radioButton3.Checked == true)
            {
                if(textBox4.Text.Length < 0)
                {
                    MessageBox.Show("Tasa de interés incorrecto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Text = "0";
                    textBox4.Focus();
                    return;
                }
                else
                {
                    TasaI = Convert.ToDouble(textBox4.Text) / 100;
                }
            }
            
            MontoFIn = (1 + TasaI);
            MontoFIn = MontoInic * (Math.Pow(Convert.ToDouble(MontoFIn), tiempo));
            TasaI *= 100;
            listBox1.Items.Clear();
            listBox1.Items.Add("Empresa: " + textBox1.Text);
            listBox1.Items.Add("Monto: $" + MontoInic + " Tasa Anual " + TasaI);
            listBox1.Items.Add("Monto a Pagar: $" + MontoFIn);



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
