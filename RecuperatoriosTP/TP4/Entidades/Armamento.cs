using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Armamento
    {
        #region Atributos
        ETipo tipoArmamento;
        private int id;
        private string nombre;
        private string origen;
        private int precio;
        private int stock;
        #endregion

        #region Enumerados
        public enum ETipo
        {
            fusil,
            pistola,
            dron,
            explosivo
        }
        #endregion

        #region Propiedades
        public static List<Armamento> Armas
        {
            get
            {
                List<Armamento> armas = new List<Armamento>();
                AccesoDatos data = new AccesoDatos();

                return armas = data.ObtenerListaDato();

            }
        }

        public int Id 
        {
            get
            {
                return this.id;
            }
        }

        public string Nombre 
        {
            get
            { 
                return this.nombre; 
            }

            set
            {
                this.nombre = value; 
            } 
        }

        public ETipo TipoArmamento
        {
            get 
            { 
                return this.tipoArmamento; 
            }

            set 
            { 
                this.tipoArmamento = value; 
            }
        }

        public string Origen
        {
            get
            {
                return this.origen;
            }

            set
            {
                this.origen = value;
            }
        }

        public int Precio
        {
            get
            {
                return this.precio;
            }

            set
            {
                this.precio = value;
            }
        }

        public int Stock
        {
            get
            {
                return this.stock;
            }

            set
            {
                this.stock = value;
            }
        }

        #endregion

        #region Constructores
        public Armamento()
        {
        }

        public Armamento(string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
        {
            this.nombre = nombre;
            this.tipoArmamento = tipoArmamento;
            this.origen = origen;
            this.precio = precio;
            this.stock = stock;
        }

        public Armamento(int id, string nombre, ETipo tipoArmamento, string origen, int precio, int stock)
            : this(nombre, tipoArmamento, origen, precio, stock)
        {
            this.id = id;
        }
        #endregion

        #region Sobrecarga
        public static bool operator ==(List<Armamento> armas, Armamento arma)
        {
            bool isEqual = false;

            foreach (Armamento itemArma in armas)
            {
                if(itemArma.id == arma.id)
                {
                    isEqual = true;
                }
            }

            return isEqual;
        }

        public static bool operator !=(List<Armamento> armas, Armamento arma)
        {
            return !(armas == arma);
        }

        public static bool operator + (List<Armamento> armas, Armamento arma)
        {
            bool added = false;

            if(armas != arma)
            {
                arma.Save();
                added = true;
            }

            return added; 
        }

        #endregion

        #region Métodos

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Origen: {this.origen}");
            sb.AppendLine($"Precio: {this.precio}");
            sb.AppendLine($"Stock: {this.stock}");

            return sb.ToString();
        }

        public bool Save()
        {
            string cadena = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            AccesoDatos data = new AccesoDatos(cadena);
            return data.AgregarDato(this);
        }

        #endregion

        

    }
}
