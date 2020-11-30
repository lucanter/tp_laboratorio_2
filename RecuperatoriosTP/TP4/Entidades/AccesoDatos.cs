using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class AccesoDatos
    {
        #region Atributos

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        #endregion

        #region Constructor
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
            this.conexion.ConnectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            this.comando = new SqlCommand();
            this.comando.Connection = conexion;
            this.comando.CommandType = CommandType.Text;
        }

        public AccesoDatos(string cadenaConexion)
        {
            this.conexion = new SqlConnection(cadenaConexion);
        }

        #endregion

        #region Métodos

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State != ConnectionState.Closed)
                    this.conexion.Close();
            }

            return rta;
        }

        public List<Armamento> ObtenerListaDato()
        {
            List<Armamento> lista = new List<Armamento>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM armas";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    string tipo = lector["tipo"].ToString();

                    switch (tipo)
                    {
                        case "fusil":
                            lista.Add(new Armamento(int.Parse(lector["id"].ToString()), lector["nombre"].ToString(),
                                Armamento.ETipo.fusil, lector["origen"].ToString(), int.Parse(lector["precio"].ToString()),
                                int.Parse(lector["stock"].ToString())));
                            break;

                        case "pistola":
                            lista.Add(new Armamento(int.Parse(lector["id"].ToString()), lector["nombre"].ToString(),
                                Armamento.ETipo.pistola, lector["origen"].ToString(), int.Parse(lector["precio"].ToString()),
                                int.Parse(lector["stock"].ToString())));
                            break;

                        case "dron":
                            lista.Add(new Armamento(int.Parse(lector["id"].ToString()), lector["nombre"].ToString(),
                                Armamento.ETipo.dron, lector["origen"].ToString(), int.Parse(lector["precio"].ToString()),
                                int.Parse(lector["stock"].ToString())));
                            break;

                        case "explosivo":
                            lista.Add(new Armamento(int.Parse(lector["id"].ToString()), lector["nombre"].ToString(),
                                Armamento.ETipo.explosivo, lector["origen"].ToString(), int.Parse(lector["precio"].ToString()),
                                int.Parse(lector["stock"].ToString())));
                            break;
                        default:
                            break;
                    }
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State != ConnectionState.Closed)
                    this.conexion.Close();
            }

            return lista;
        }

        public bool AgregarDato(Armamento param)
        {
            bool dataAdded = false;

            string sql = "INSERT INTO armas (nombre, tipo, origen, precio, stock) ";
            sql += "VALUES (@nombre, @tipo, @origen, @precio, @stock)";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.Add(new SqlParameter("@nombre", param.Nombre));
                this.comando.Parameters.Add(new SqlParameter("@tipo", param.TipoArmamento.ToString() ));
                this.comando.Parameters.Add(new SqlParameter("@origen", param.Origen));
                this.comando.Parameters.Add(new SqlParameter("@precio", param.Precio));
                this.comando.Parameters.Add(new SqlParameter("@stock", param.Stock));

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                dataAdded = true;
            }
            catch (Exception)
            {
                dataAdded = false;
            }
            finally
            {
                if (this.conexion.State != ConnectionState.Closed)
                    this.conexion.Close();
            }

            return dataAdded;
        }

        public bool ModificarDato(Armamento param)
        {
            bool dataChanged = false;

            string sql = "UPDATE armas";
            sql += "SET nombre = @nombre, tipo = @tipo, origen = @origen, precio = @precio, stock = @stock";
            sql += "WHERE id = @id";

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@id", param.Id);
                this.comando.Parameters.AddWithValue("@nombre", param.Nombre);
                this.comando.Parameters.AddWithValue("@tipo", param.TipoArmamento.ToString());
                this.comando.Parameters.AddWithValue("@origen", param.Origen);
                this.comando.Parameters.AddWithValue("@precio", param.Precio);
                this.comando.Parameters.AddWithValue("@stock", param.Stock);
                               
                this.comando.CommandText = sql;

                this.conexion.Open();
                this.comando.ExecuteNonQuery();

                dataChanged = true;
            }
            catch (Exception)
            {                
                dataChanged = false;
            }
            finally
            {
                if (this.conexion.State != ConnectionState.Closed)
                    this.conexion.Close();
            }

            return dataChanged;
        }

        public bool EliminarDato(int id)
        {
            bool dataDeleted = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@id", id);

                string sql = "DELETE FROM armas";
                sql += "WHERE id = @id";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                    dataDeleted = false;

            }
            catch (Exception)
            {
                dataDeleted = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return dataDeleted;
        }
        #endregion

    }
}