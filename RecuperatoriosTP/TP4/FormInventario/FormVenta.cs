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
using Excepciones;
using Archivos;

namespace FormInventario
{
    public partial class FormVenta : Form
    {
        #region Atributos
        protected Armamento a;
        protected Venta v;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor default
        /// </summary>
        public FormVenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="arma"></param>
        public FormVenta(Armamento arma) 
            : this()
        {            
            this.a = arma;
            this.lblNombreVenta.Text = arma.Nombre;
            this.lblTipoVenta.Text = arma.TipoArmamento.ToString();
            this.lblOrigenVenta.Text = arma.Origen;
            this.lblPrecioVenta.Text = arma.Precio.ToString();
            this.lblStockVenta.Text = arma.Stock.ToString();
        }
        #endregion

        #region Botones

        /// <summary>
        /// Validará que el número de cantidad ingresado sea mayor al número de stock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {   
            v = new Venta();
            try
            {
                int cant;
                int dest;

                if (int.TryParse(this.txtCantidad.Text, out cant))
                {
                    if(!(int.TryParse(this.txtDestinatario.Text, out dest)))
                    {
                        if (a.Stock <= 0 || int.Parse(this.txtCantidad.Text) > a.Stock)
                        {
                            MessageBox.Show("No hay stock suficiente para la venta!", "Carga de cantidad");
                            this.txtCantidad.Clear();
                        }
                        else
                        {
                            if (this.txtDestinatario.Text != "")
                            {
                                v.Destinatario = this.txtDestinatario.Text;
                            }
                            else
                            {
                                v.Destinatario = "0";
                            }

                            for (int i = 0; i < int.Parse(this.txtCantidad.Text); i++)
                            {
                                v += a.Id;
                            }

                            if (Inventario.Ventas + v)
                                MessageBox.Show($"Venta guardada con exito en el ticket: {v.Ticket}");
                            this.txtCantidad.Clear();                            
                        }

                        this.txtCantidad.Clear();
                    }
                    else 
                    {
                        MessageBox.Show("Error: El destinatario no puede ser un número", "Carga de destinatario");
                        this.txtCantidad.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Verifique campos numericos", "Carga de cantidad");
                    this.txtCantidad.Clear();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.txtCantidad.Clear();
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
