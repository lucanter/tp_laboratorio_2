using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TP4 de Luciano Cantero 2A [EN CONSTRUCCION - FALTAN DETALLITOS]";
                     
            string cadena = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            AccesoDatos ad = new AccesoDatos(cadena);

            if (ad.ProbarConexion())
            {
                Console.WriteLine("se conectó");
            }
            else
            {
                Console.WriteLine("no se conectó");
            }

            List<Armamento> lista = ad.ObtenerListaDato();

            Console.WriteLine("CARGA DE ARMAMENTO:");
            Armamento arma1 = new Fusil("H&K416", Armamento.ETipo.fusil, "alemán", 85000, 250);
            Armamento arma2 = new Pistola("Desert Eagle", Armamento.ETipo.pistola, "americana", 5600, 300);
            Armamento arma3 = new Dron("Avenger", Armamento.ETipo.dron, "americano", 3000000, 5);
            Armamento arma4 = new Explosivo("M18A1 Claymore", Armamento.ETipo.explosivo, "americano", 15000, 30);

            if (lista + arma1)
            {
                Console.WriteLine($"Se han cargado {arma1.Stock} {arma1.Nombre} ({arma1.TipoArmamento.ToString()} de origen {arma1.Origen}) de valor ${arma1.Precio}");
            }
            if (lista + arma2)
            {
                Console.WriteLine($"Se han cargado {arma2.Stock} {arma2.Nombre} ({arma2.TipoArmamento.ToString()} de origen {arma2.Origen}) de valor ${arma2.Precio}");
            }
            if (lista + arma3)
            {
                Console.WriteLine($"Se han cargado {arma3.Stock} {arma3.Nombre} ({arma3.TipoArmamento.ToString()} de origen {arma3.Origen}) de valor ${arma3.Precio}");
            }
            if (lista + arma4)
            {
                Console.WriteLine($"Se han cargado {arma4.Stock} {arma4.Nombre} ({arma4.TipoArmamento.ToString()} de origen {arma4.Origen}) de valor ${arma4.Precio}");
            }

            Console.WriteLine("LISTA DE ARMAMENTO:");

            foreach (Armamento item in lista)
            {
                Console.WriteLine($"Id: {item.Id} - Nombre: {item.Nombre} - Tipo: {item.TipoArmamento.ToString()} - Origen: {item.Origen} - Precio: ${item.Precio} - Stock: {item.Stock}");
            }

            Console.WriteLine("CARGA DE OTRA ARMA:");
            Fusil arma5 = new Fusil("AK47", Armamento.ETipo.fusil, "soviético", 14000, 11);

            if (lista + arma5)
            {
                Console.WriteLine($"Se han cargado {arma5.Stock} {arma5.Nombre} ({arma5.TipoArmamento.ToString()} de origen {arma5.Origen}) de valor ${arma5.Precio}");
            }

            Console.WriteLine("LISTA DE ARMAMENTO ACTUALIZADA:");

            foreach (Armamento item in lista)
            {
                Console.WriteLine($"Id: {item.Id} - Nombre: {item.Nombre} - Tipo: {item.TipoArmamento.ToString()} - Origen: {item.Origen} - Precio: ${item.Precio} - Stock: {item.Stock}");
            }
            /*
            Console.WriteLine("SE MODIFICA LA ÚLTIMA ARMA:");

            bool modifico = ad.ModificarDato(arma5);

            if (modifico)
            {
                Console.WriteLine("se modificó");
            }
            else
            {
                Console.WriteLine("no se modificó");
            }

            lista = ad.ObtenerListaDato();

            foreach (Armamento item in lista)
            {
                Console.WriteLine($"Id: {item.Id} - Nombre: {item.Nombre} - Tipo: {item.TipoArmamento.ToString()} - Origen: {item.Origen} - Precio: ${item.Precio} - Stock: {item.Stock}");
            }


            bool elimino = ad.EliminarDato(6);

            if (elimino)
            {
                Console.WriteLine("se eliminó");
            }
            else
            {
                Console.WriteLine("no se eliminó");
            }

            lista = ad.ObtenerListaDato();

            foreach (Armamento item in lista)
            {
                Console.WriteLine("Id: {0} - Nombre: {1} - Tipo: {2} - Origen: {3} - Precio ${4} - Stock {5}", item.Id.ToString(), item.Nombre, item.TipoArmamento.ToString(), item.Origen, item.Precio, item.Stock);
            }*/

            Console.ReadLine();
        }
    }
}
