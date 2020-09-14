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

        /// <summary>
        /// Llama a Operar(FormCalculadora) con los parámetros numero1(txtNumero1), numero2(txtNumero2) y operador(cmbOperador)
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            this.lblResultado.Text = (Operar(numero1, numero2, operador)).ToString();

            btnConversion(btnConvertirABinario, btnConvertirADecimal); //instantaneamente luego de recibir el resultado, desactivo el boton para convertir a decimal
        }

        /// <summary>
        /// Llama a Operar(Calculadora) con los parámetros n1(txtNumero1), n22(txtNumero2) y operador(cmbOperador)
        /// </summary>
        /// <param name="numero1">string</param>
        /// <param name="numero2">string</param>
        /// <param name="operador">string</param>
        /// <returns>double</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operador);
        }

        /// <summary>
        /// Llama a DecimalBinario(Numero) con el parámetro numero(lblResultado), activa/desactiva botones de conversión
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero = this.lblResultado.Text;
            this.lblResultado.Text = Numero.DecimalBinario(numero);

            btnConversion(btnConvertirADecimal, btnConvertirABinario);
        }

        /// <summary>
        /// Llama a BinarioDecimal(Numero) con el parámetro binario(lblResultado), activa/desactiva botones de conversión
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string binario = this.lblResultado.Text;
            this.lblResultado.Text = Numero.BinarioDecimal(binario);
            btnConversion(btnConvertirABinario, btnConvertirADecimal);
        }

        /// <summary>
        /// Llama a Limpiar(FormCalculadora)
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirADecimal.Enabled = true; //instantaneamente luego de que termine de ejecutarse Limpiar, activo nuevamente el boton para convertir a decimal
            btnConvertirABinario.Enabled = true; //instantaneamente luego de que termine de ejecutarse Limpiar, activo nuevamente el boton para convertir a binario
        }

        /// <summary>
        /// Vacía todos los valores de los TextBox y el ComboBox
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            cmbOperador.Text = "";
            txtNumero2.Text = "";            
            lblResultado.Text="";
        }

        /// <summary>
        /// Llama a Dispose
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Activa y desactiva botones (para reutilizar código)
        /// </summary>
        /// <param name="activar">Button</param>
        /// <param name="desactivar">Button</param>
        private static void btnConversion(Button activar, Button desactivar)
        {
            activar.Enabled = true; 
            desactivar.Enabled = false; 
        }
    }
}
