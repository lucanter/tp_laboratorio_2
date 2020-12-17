using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;
using Archivos;
using Excepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TP4 de Luciano Cantero 2A";
            Fusil a1 = new Fusil("Kilo 101", Armamento.ETipo.fusil, "alemán", 300, 3);
            Pistola a2 = new Pistola("Glock", Armamento.ETipo.pistola, "austríaco", 250, 7);            
            Dron a3 = new Dron("MQ-9 Reaper", Armamento.ETipo.dron, "americano", 200, 10);
            Explosivo a4 = new Explosivo("Nobel 808", Armamento.ETipo.explosivo, "británico", 180, 9);

            Venta venta = new Venta();

            try
            {
                Console.WriteLine("\nCarga de armas:\n");

                if (Inventario.Armas + a1)
                    Console.WriteLine($"El {a1.TipoArmamento} {a1.Nombre} de origen {a1.Origen} ha sido cargado con exito.");
                if (Inventario.Armas + a2)
                    Console.WriteLine($"El {a2.TipoArmamento} {a2.Nombre} de origen {a2.Origen} ha sido cargado con exito.");
                if (Inventario.Armas + a3)
                    Console.WriteLine($"El {a3.TipoArmamento} {a3.Nombre} de origen {a3.Origen} ha sido cargado con exito.");
                if (Inventario.Armas + a4)
                    Console.WriteLine($"El {a4.TipoArmamento} {a4.Nombre} de origen {a4.Origen} ha sido cargado con exito.");
            }
            catch (ArmamentosException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nProductos en la base de datos:\n");
                Console.WriteLine(Inventario.MostrarArmas());
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nVenta:\n");

                venta += 1;
                venta += 2;
                venta += 3;
            }
            catch (CargarVentaException e)
            {

                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nSe ha generado la venta.\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nImpresión del ticket de venta:\n");

                if (Inventario.Ventas + venta)
                    Console.WriteLine($"Venta guardada con exito. Ticket Nro: {venta.Ticket}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("\nArchivo XML con el listado de ventas:\n");
                if (Inventario.Guardar(Inventario.Ventas))
                    Console.WriteLine("Se ha guardado el listado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Presione cualquier tecla para finalizar el test de consola...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}