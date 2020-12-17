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
using Excepciones;
using Archivos;
using System.Data.SqlClient;

namespace FormInventario
{
    public partial class FormArmamento : Form
    {

        #region Atributos

        public SqlDataAdapter dA;
        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;
        protected Armamento arma;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por default
        /// </summary>
        public FormArmamento()
        {
            InitializeComponent();
            this.cn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=arsenal;Trusted_Connection=True;");
            this.dt = new DataTable("Arsenal");

            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;

            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;

            this.dt.Columns.Add("nombre", typeof(string));
            this.dt.Columns.Add("tipo", typeof(string));
            this.dt.Columns.Add("origen", typeof(string));
            this.dt.Columns.Add("precio", typeof(int));
            this.dt.Columns.Add("stock", typeof(int));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.da = new SqlDataAdapter();
            this.da.SelectCommand = new SqlCommand("SELECT id, nombre, tipo, origen, precio, stock FROM [arsenal].[dbo].[armamento]", cn);

            this.da.Fill(this.dt);
            this.dgvGrilla.DataSource = this.dt;
        }

        #endregion

        #region Load

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormArmamento_Load(object sender, EventArgs e)
        {
            this.Text = "Cantero Luciano 2A";
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
        }

        #endregion

        #region Botones

        /// <summary>
        /// Inicia  un producto abriendo otro form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            FormCarga formNuevo = new FormCarga();     

            formNuevo.StartPosition = FormStartPosition.CenterScreen;

            if (formNuevo.ShowDialog() == DialogResult.OK)     
            {
                DataRow fila = this.dt.NewRow(); 

                    fila["nombre"] = formNuevo.Armamento.Nombre;
                    fila["tipo"] = formNuevo.Armamento.TipoArmamento;
                    fila["origen"] = formNuevo.Armamento.Origen;
                    fila["precio"] = formNuevo.Armamento.Precio;
                    fila["stock"] = formNuevo.Armamento.Stock;
                this.dt.Rows.Add(fila);    
            }
        }

        /// <summary>
        /// Abrirá el formulario Vender,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;
            DataRow fila = this.dt.Rows[i];

            if (fila["tipo"].ToString() == "Fusil")
            {
                arma = new Fusil(int.Parse(fila["id"].ToString()),fila["nombre"].ToString(), Armamento.ETipo.fusil, fila["origen"].ToString(),
                    int.Parse(fila["precio"].ToString()), int.Parse(fila["stock"].ToString()));
            }
            else if (fila["tipo"].ToString() == "Pistola")
            {
                arma = new Pistola(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), Armamento.ETipo.pistola, fila["origen"].ToString(),
                    int.Parse(fila["precio"].ToString()), int.Parse(fila["stock"].ToString()));
            }
            else if (fila["tipo"].ToString() == "Dron")
            {
                arma = new Dron(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), Armamento.ETipo.dron, fila["origen"].ToString(),
                    int.Parse(fila["precio"].ToString()), int.Parse(fila["stock"].ToString()));
            }
            else if (fila["tipo"].ToString() == "Explosivo")
            {
                arma = new Explosivo(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), Armamento.ETipo.explosivo, fila["origen"].ToString(),
                    int.Parse(fila["precio"].ToString()), int.Parse(fila["stock"].ToString()));
            }

            FormVenta frm = new FormVenta(arma);
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)                  
            {
                dgvGrilla.Update();
                dgvGrilla.Refresh();
            }
        }

        #endregion

    }
}
