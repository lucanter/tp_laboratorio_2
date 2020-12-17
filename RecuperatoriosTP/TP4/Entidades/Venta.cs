using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Archivos;
using Excepciones;

namespace Entidades
{
    public class Venta
    {
        #region Atributos

        public delegate bool delegado (Venta venta);
        private string ticket;
        private List<Armamento> armas;
        private double monto;
        public static event delegado evento;
        public string destinatario;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor métodos al delegado.
        /// </summary>
        static Venta()
        {
            evento += Inventario.restarStock;
            evento += Inventario.cargarVenta;
        }

        /// <summary>
        /// Constructor default
        /// </summary>
        public Venta()
        {
            armas = new List<Armamento>();
            ticket = "0";
            monto = 0;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Getter y Setter de ticket
        /// </summary>
        public string Ticket 
        {
            get
            {
                return  this.ticket;
            }
            set
            {
                this.ticket = value;
            }
        }

        /// <summary>
        /// Getter y Setter de la lista Armas
        /// </summary>
        public List<Armamento> Armas 
        {
            get
            {
                return this.armas;
            }
            set 
            { 
                this.armas = value; 
            }
        }

        /// <summary>
        /// Getter y Setter de Monto
        /// </summary>
        public double Monto
        {
            get 
            { 
                return this.monto; 
            }
            set 
            { 
                this.monto = value;        
            }
        }

        public string Destinatario
        {
            get 
            {
                return this.destinatario;
            }
            set
            {
                this.destinatario = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Imprime el ticket en formato de texto
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>Retorna booleano (true) si se imprimio el ticket o (false) si no.</returns>
        public static bool imprimirTicket(Venta venta)
        {
            string ticket = DateTime.Now.ToString("ddMMyyHHmmss");
            string ruta;

            venta.ticket = ticket;
            venta.ticket += "_UTN.txt";

            ruta = AppDomain.CurrentDomain.BaseDirectory + venta.ticket;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ticket de venta: {venta.ticket}");

            foreach (Armamento item in venta.armas)
            {
                sb.AppendLine(String.Format("Se ha vendido un {0} {1} de origen {2} por el precio de ${3: #,###} USD.", item.TipoArmamento, item.Nombre, item.Origen, item.Precio));
            }

            if (venta.destinatario != "0")
            {
                sb.AppendLine(String.Format($"Para el destinatario: {venta.destinatario}"));
            }
            else
            {
                sb.AppendLine(String.Format($"Para el destinatario: Anónimo (venta ilegal de armas, notificar a la policía!)."));
            }

            sb.AppendLine(String.Format("Monto total: ${0: #,###} USD", venta.monto));
            sb.AppendLine("___________________________________________");

            Texto texto = new Texto();

            return texto.Guardar(ruta, sb.ToString());
        }

        /// <summary>
        /// Calcula el monto de una venta
        /// </summary>
        /// <param name="venta"></param>
        /// <returns>Retorna booleano (true) si se calculó y cargó el monto, o (false) si no.</returns>
        public static bool calcularMonto(Venta venta)
        {
            bool loaded = false;

            if (venta != null)
            {
                foreach (Armamento arma in venta.armas)
                {
                    venta.monto += arma.Precio;
                }

                loaded = true;
            }

            return loaded;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica la existencia del arma en la base de datos mediante su id
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="id"></param>
        /// <returns>Retornará (Armamento) el arma si existe, si no retornará null.</returns>
        public static Armamento operator ==(Venta venta, int id)
        {
            Armamento arma = null;

            foreach (var item in Inventario.Armas)
            {
                if (item.Id == id)
                {
                    arma = item;
                    break;
                }
            }

            return arma;
        }

        /// <summary>
        /// Retornará la primer arma de la lista que no tenga el id pasado como parámetro
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="id"></param>
        /// <returns>Retornará (Armamento) el arma que no tenga el id pasado.</returns>
        public static Armamento operator !=(Venta venta, int id)
        {
            Armamento arma = null;

            foreach (var item in Inventario.Armas)
            {
                if (item.Id != id)
                {
                    arma = item;
                    break;
                }
            }

            return arma;
        }

        /// <summary>
        /// Añade una nueva arma a la venta.
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="id"></param>
        /// <returns>Retorna (Venta) la venta con el arma.</returns>
        public static Venta operator +(Venta venta, int id)
        {
            Armamento arma = (venta == id);

            if (arma != null)
            {
                venta.armas.Add(arma);
            }
            else
            {
                throw new CargarVentaException("Error: El arma no ha podido ser cargada a la lista.");
            }

            return venta;
        }

        /// <summary>
        /// Igualdad entre lista de objeto y objeto, verifica si la venta ya está en la lista
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <param name="v"></param>
        /// <returns>Retorna booleano (true) si la venta está en la lista o (false) si no.</returns>
        public static bool operator ==(List<Venta> listaVentas, Venta v)
        {
            foreach (Venta item in listaVentas)
            {
                if (item.Ticket == v.Ticket)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Desigualdad entre lista de objeto y objeto, verifica si el objeto venta no está en la lista
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <param name="v"></param>
        /// <returns>Retorna booleano (false) si la venta no se encuentra en la lista o (true) si no.</returns>
        public static bool operator !=(List<Venta> listaVentas, Venta v)
        {
            return !(listaVentas == v);
        }

        /// <summary>
        /// Suma de lista de objeto y objeto, verifica si la venta no esta cargado en la lista. Si no está, a través del 
        /// delegado la agregará a la lista y restará el stock del arma comprada; calculará el monto e imprimirá el ticket.
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <param name="venta"></param>
        /// <returns>Retorna booleado (false) si la venta no se cargó o (true) si no</returns>
        public static bool operator +(List<Venta> listaVentas, Venta venta)
        {
            bool loaded = false;
            if (listaVentas != venta)
            {
                calcularMonto(venta);
                evento.Invoke(venta);
                imprimirTicket(venta);

                loaded = true;
            }
            else
            {
                throw new CargarVentaException("Error: Ha ocurrido un error con la venta. Intentelo nuevamente.");
            }

            return loaded;
        }

        #endregion

    }
}
