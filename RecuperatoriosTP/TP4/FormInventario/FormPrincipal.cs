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
using System.Runtime.InteropServices;
using Entidades;
using Excepciones;
using Archivos;

namespace FormInventario
{
    public partial class FormPrincipal : Form
    {
        #region Atributos
        private Bitmap slid;
        protected Thread hilo;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
        }
        #endregion


        public void slider()
        {
            int cantSlides = 40;
            do
            {
                for (int i = 1; i <= cantSlides; i++)
                {
                    this.slide($@"slider{i}.png");
                    Thread.Sleep(210);
                }
            } while (true);
        }

        public void slide(string path)
        {
            try
            { 
                this.slid = new Bitmap(path);
                pictureBox1.Image = (Image)this.slid;
            }
            catch
            {
                MessageBox.Show("Error: Ruta del archivo inexistente");
            }
        }

        #region Load
        /// <summary>
        /// Se inicia el hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Cantero Luciano 2A";
            this.hilo = new Thread(this.slider);
            if (!this.hilo.IsAlive)
                this.hilo.Start();
        }
        #endregion

        #region GUI
        /// <summary>
        /// Permitirá abrir los forms dentro de este
        /// </summary>
        /// <param name="formhijo"></param>
        private void AbrirFormHijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fh = formhijo as Form;

            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        #endregion

        #region Botones

        /// <summary>
        /// Cierra todos los forms contenidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.panelContenedor.Controls.Clear();
        }

        /// <summary>
        /// Se abre el form de carga dentro de este
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FormCarga());
        }

        /// <summary>
        /// Se abre el form de venta dentro de este
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FormArmamento());
        }
        #endregion

        #region Evento

        /// <summary>
        /// Evento Closing, pregunta al usuario si está seguro (botones SI y NO, con ícono de pregunta).
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult salida = MessageBox.Show("¿Seguro que quiere salir?", "Salir",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1);

            if (salida == DialogResult.Yes)
            {
                //Dipose();                
                Environment.Exit(0);                
            }
            else
            {
                e.Cancel = true;
            }


        }

        #endregion

    }
}
