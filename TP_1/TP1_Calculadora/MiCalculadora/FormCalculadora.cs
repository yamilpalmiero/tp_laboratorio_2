using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lblResultado.Text = string.Empty;
            lstOperaciones.Items.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero1.Text) || string.IsNullOrWhiteSpace(txtNumero2.Text) || string.IsNullOrWhiteSpace(cmbOperador.SelectedItem.ToString()))
            {
                MessageBox.Show("Ingrese ambos numeros y operador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }

            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = resultado.ToString();

            lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.SelectedItem.ToString()} {txtNumero2.Text} = {lblResultado.Text}");
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                lblResultado.Text = new Operando().DecimalBinario(lblResultado.Text);
                lstOperaciones.Items.Add(lblResultado.Text);
            }

            else
            {
                MessageBox.Show("Primero debe realizar una operacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();

            if (!(string.IsNullOrEmpty(lblResultado.Text)))
            {
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
                lstOperaciones.Items.Add(lblResultado.Text);
            }

            else
            {
                MessageBox.Show("Primero debe realizar una operacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
