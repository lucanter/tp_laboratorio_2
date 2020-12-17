using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Archivos;
using Excepciones;

namespace FormInventario
{
    public partial class FormCarga : Form
    {
        #region Atributo

        public delegate void Delegado();
        public event Delegado evento;
        protected Armamento a;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedades de lectura
        /// </summary>
        public Armamento Armamento
        {
            get 
            { 
                return this.a; 
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor default
        /// </summary>
        public FormCarga()
        {
            InitializeComponent();
            this.a = new Armamento();
            evento += this.Limpiar;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="a"></param>
        public FormCarga(Armamento a) 
            : this()
        {
            this.a = a;

            this.txtNombre.Text = a.Nombre;
            this.cmbTipo.Text = a.TipoArmamento.ToString();
            this.txtOrigen.Text = a.Origen;
            this.txtPrecio.Text = a.Precio.ToString();
            this.txtStock.Text = a.Stock.ToString();
        }

        #endregion

        #region Load

        /// <summary>
        /// Origen de datos del combo box (Armamento.ETipo)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCarga_Load(object sender, EventArgs e)
        {
            this.cmbTipo.DataSource = Enum.GetValues(typeof(Armamento.ETipo));
        }

        #endregion

        #region Botones

        /// <summary>
        /// Limpia todo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.evento.Invoke();
        }

        
        /// <summary>
        /// Crea un objeto de tipo Producto y lo agrega a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                int precio;
                int stock;

                this.txtPrecio.Text = this.txtPrecio.Text.Replace(".", ",");

                if (int.TryParse(this.txtPrecio.Text, out precio) && int.TryParse(this.txtStock.Text, out stock))
                {
                    if (precio >= 0 && stock >= 0)
                    {
                        if ((Armamento.ETipo)this.cmbTipo.SelectedValue == Armamento.ETipo.fusil)
                        {
                            a = new Fusil(this.txtNombre.Text, Armamento.ETipo.fusil, this.txtOrigen.Text, precio, stock);

                            if (Inventario.Armas + a)
                            {
                                MessageBox.Show("Cargado con exito");
                                MessageBox.Show(a.ToString());
                            }
                        }
                        else if ((Armamento.ETipo)this.cmbTipo.SelectedValue == Armamento.ETipo.pistola)
                        {
                            a = new Pistola(this.txtNombre.Text, Armamento.ETipo.pistola, this.txtOrigen.Text, precio, stock);

                            if (Inventario.Armas + a)
                            {
                                MessageBox.Show("Cargado con exito");
                                MessageBox.Show(a.ToString());
                            }
                        }
                        else if ((Armamento.ETipo)this.cmbTipo.SelectedValue == Armamento.ETipo.dron)
                        {
                            a = new Dron(this.txtNombre.Text, Armamento.ETipo.dron, this.txtOrigen.Text, precio, stock);

                            if (Inventario.Armas + a)
                            {
                                MessageBox.Show("Cargado con exito");
                                MessageBox.Show(a.ToString());
                            }
                        }
                        else if ((Armamento.ETipo)this.cmbTipo.SelectedValue == Armamento.ETipo.explosivo)
                        {
                            a = new Explosivo(this.txtNombre.Text, Armamento.ETipo.explosivo, this.txtOrigen.Text, precio, stock);

                            if (Inventario.Armas + a)
                            {
                                MessageBox.Show("Cargado con exito");
                                MessageBox.Show(a.ToString());
                            }
                        }
                        this.evento.Invoke();
                    }
                    else
                    {
                        if (int.Parse(this.txtPrecio.Text) < 0)
                       {
                            MessageBox.Show("Error: El precio no puede ser negativo.");
                            this.txtPrecio.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Error: El stock no puede ser negativo.");
                            this.txtStock.Clear();
                        }
                    }
                }
                else
                {
                    if(int.TryParse(this.txtPrecio.Text, out precio))
                    {
                        MessageBox.Show("Error: Verifique que el stock sea un número.");
                        this.txtStock.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error: Verifique que el precio sea un número.");
                        this.txtPrecio.Clear();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.evento.Invoke();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion


        #region Método

        /// <summary>
        /// Limpia los textboxes
        /// </summary>
        private void Limpiar()
        {
            this.txtNombre.Clear();
            this.txtOrigen.Clear();
            this.txtPrecio.Clear();
            this.txtStock.Clear();
        }

        #endregion
    }
}