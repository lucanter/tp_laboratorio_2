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

            //Dado que no se puede retornar string/bool en Operar ni el enunciado permite crear métodos, se valida 
            //en esta instancia que la división por cero resulte en error matemático.
            if( (numero2 == "" || numero2 == "0") && operador == "/")
            {
                this.lblResultado.Text = "Error.";
            }
            else
            { 
                this.lblResultado.Text = (Operar(numero1, numero2, operador)).ToString();
            }

            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
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
            char operadorChar;

            //Debido a que ToChar espera como parámetro una cadena de longitud 1, se valida que string operador sea de longitud 1.
            //Si no es de longitud 1, se le asignará el operador suma por default.
            if (operador.Length == 0 || operador.Length>1)
            {
                operadorChar = '+';
            }
            else 
            {
                operadorChar = Convert.ToChar(operador);
            }
            
            return Calculadora.Operar(n1, n2, operadorChar);
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

            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
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

            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Llama a Limpiar(FormCalculadora)
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = true;
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
        /// Llama al método Limpiar.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Evento Closing, pregunta al usuario si está seguro (botones SI y NO, con ícono de pregunta).
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Botones SI y NO con icono de pregunta
            //Como aparece en la imagen, el boton SI es el predeterminado
            DialogResult salida = MessageBox.Show("¿Seguro que quiere salir?", "Salir",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                                    MessageBoxDefaultButton.Button1);  

            if (salida == DialogResult.No) 
                e.Cancel = true;
        }
    }    
}
