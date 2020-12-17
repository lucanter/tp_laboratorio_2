using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Entidades
{
    /// <summary>
    /// Clase conexión y puente con base de datos
    /// </summary>
    public class ArmamentoBD
    {
        #region Atributos
        private SqlConnection conexion;
        private SqlCommand comando;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor default
        /// </summary>
        public ArmamentoBD()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
            conexion.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=arsenal;Integrated Security=True;";
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// ExecuteNonQuery() para los INSERT, UPDATE o DELETE, en una conexion SQL
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns>Retorna booleano (true) si se ejecuto en una conexión o (false) si no.</returns>
        public bool EjecutarNonQuery(string SQL)
        {
            bool executed = false;

            try
            {
                comando.CommandText = SQL;
                conexion.Open();
                comando.ExecuteNonQuery();
                executed = true;
            }
            catch (Exception e)
            {
                executed = false;
                throw new ArchivosException("Error: No se puede ejecutar instrucciones en la base de datos", e);
            }
            finally
            {
                conexion.Close();
            }

            return executed;
        }

        /// <summary>
        /// Añade (INSERT) un arma a la base de datos
        /// </summary>
        /// <param name="arma"></param>
        /// <returns>Retorna booleano (true) si se insertó el arma a la base de datos o (false) si no.</returns>
        public bool InsertarArma(Armamento arma)
        {
            //try
            //{
            
            string SQL = "INSERT INTO armamento(nombre, tipo, origen, precio, stock) VALUES (@nombre, @tipo, @origen, @precio, @stock)";

            comando.Parameters.Add(new SqlParameter("@nombre", arma.Nombre));

            if (arma.TipoArmamento.ToString() == "fusil")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Fusil"));
            }
            else if(arma.TipoArmamento.ToString() == "pistola")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Pistola"));
            }
            else if (arma.TipoArmamento.ToString() == "dron")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Dron"));
            }
            else if (arma.TipoArmamento.ToString() == "explosivo")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Explosivo"));
            }

            comando.Parameters.Add(new SqlParameter("@origen", arma.Origen));
            comando.Parameters.Add(new SqlParameter("@precio", arma.Precio));
            comando.Parameters.Add(new SqlParameter("@stock", arma.Stock));

            return EjecutarNonQuery(SQL);
        }

        /// <summary>
        /// Modifica/Actualiza (UPDATE) los datos de un arma en la base de datos
        /// </summary>
        /// <param name="arma"></param>
        /// <returns>Retorna booleano (true) si se actualizó el arma en la base de datos o (false) si no.</returns>
        public bool ModificarArma(Armamento arma)
        {
            string SQL = "UPDATE armamento SET nombre = @nombre, tipo = @tipo, origen = @origen, precio = @precio, stock = @stock WHERE id = @id";

            comando.Parameters.Add(new SqlParameter("@id", arma.Id));
            comando.Parameters.Add(new SqlParameter("@nombre", arma.Nombre));

            if (arma.TipoArmamento.ToString() == "fusil")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Fusil"));
            }
            else if (arma.TipoArmamento.ToString() == "pistola")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Pistola"));
            }
            else if (arma.TipoArmamento.ToString() == "dron")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Dron"));
            }
            else if (arma.TipoArmamento.ToString() == "explosivo")
            {
                comando.Parameters.Add(new SqlParameter("@tipo", "Explosivo"));
            }

            comando.Parameters.Add(new SqlParameter("@origen", arma.Origen));
            comando.Parameters.Add(new SqlParameter("@precio", arma.Precio));
            comando.Parameters.Add(new SqlParameter("@stock", arma.Stock));

            return EjecutarNonQuery(SQL);
        }

        /// <summary>
        /// Elimina (DELETE) un arma de la base de datos
        /// </summary>
        /// <param name="arma"></param>
        /// <returns>Retorna booleano (true) si se eliminó el arma de la base de datos o (false) si no.</returns>
        public bool EliminarArma(Armamento arma)
        {
            string SQL = "DELETE armamento WHERE id = @id";
            comando.Parameters.Add(new SqlParameter("@id", arma.Id));


            return EjecutarNonQuery(SQL);
        }

        /// <summary>
        /// Selecciona todas las armas de la base de datos y las muestra (SELECT * FROM)
        /// </summary>
        /// <returns></returns>
        public List<Armamento> Leer()
        {
            List<Armamento> armas = new List<Armamento>();

            try
            {
                comando.CommandText = "SELECT * FROM armamento";
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["tipo"].ToString();

                    if (tipo == "Fusil")
                    {
                        armas.Add(new Fusil(int.Parse(reader["id"].ToString()), reader["nombre"].ToString(), Armamento.ETipo.fusil, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString())));
                    }
                    else if (tipo == "Pistola")
                    {
                        armas.Add(new Pistola(int.Parse(reader["id"].ToString()), reader["nombre"].ToString(), Armamento.ETipo.pistola, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString())));
                    }
                    else if (tipo == "Dron")
                    {
                        armas.Add(new Dron(int.Parse(reader["id"].ToString()), reader["nombre"].ToString(), Armamento.ETipo.dron, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString())));
                    }
                    else if (tipo == "Explosivo")
                    {
                        armas.Add(new Explosivo(int.Parse(reader["id"].ToString()), reader["nombre"].ToString(), Armamento.ETipo.explosivo, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString())));
                    }
                }

                reader.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error: No se puede leer la base de datos", e);
            }
            finally
            {
                conexion.Close();
            }

            return armas;
        }

        /// <summary>
        /// Selecciona el arma de la base de datos con el id especificado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Armamento LeerPorID(int id)
        {
            Armamento arma = null;

            try
            {
                comando.CommandText = "SELECT * FROM armamento WHERE id = " + id.ToString();

                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader["tipo"].ToString();

                    if (tipo == "Fusil")
                    {
                        arma = new Fusil(reader["nombre"].ToString(), Armamento.ETipo.fusil, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString()));
                    }
                    else if (tipo == "Pistola")
                    {
                        arma = new Pistola(reader["nombre"].ToString(), Armamento.ETipo.pistola, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString()));
                    }
                    else if (tipo == "Dron")
                    {
                        arma = new Dron(reader["nombre"].ToString(), Armamento.ETipo.dron, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString()));
                    }
                    else if (tipo == "Explosivo")
                    {
                        arma = new Explosivo(reader["nombre"].ToString(), Armamento.ETipo.explosivo, reader["origen"].ToString(),
                        int.Parse(reader["precio"].ToString()), int.Parse(reader["stock"].ToString()));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error: No se puede leer la base de datos", e);
            }
            finally
            {
                conexion.Close();
            }

            return arma;
        }

        #endregion
    }
}

