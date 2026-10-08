using System;
using System.Collections.Generic;

namespace ColasDePrioridad_Nombre_Apellido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinHeap heap = new MinHeap();
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                Console.Write("Seleccione una opción: ");
                string? opcion = Console.ReadLine();

                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        RegistrarTicket(heap);
                        break;
                    case "2":
                        MostrarSiguienteTicket(heap);
                        break;
                    case "3":
                        AtenderTicket(heap);
                        break;
                    case "4":
                        MostrarCola(heap);
                        break;
                    case "5":
                        BuscarTicket(heap);
                        break;
                    case "6":
                        MostrarCantidad(heap);
                        break;
                    case "7":
                        salir = true;
                        Console.WriteLine("Programa finalizado. ¡Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Seleccione una opción del 1 al 7.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione ENTER para regresar al menú...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("       COLA DE PRIORIDAD - MIN HEAP");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Registrar Ticket");
            Console.WriteLine("2. Mostrar Siguiente Ticket");
            Console.WriteLine("3. Atender Ticket");
            Console.WriteLine("4. Mostrar Cola de Prioridad");
            Console.WriteLine("5. Buscar Ticket");
            Console.WriteLine("6. Mostrar cantidad de Tickets");
            Console.WriteLine("7. Salir");
            Console.WriteLine("==============================================");
        }

        static void RegistrarTicket(MinHeap heap)
        {
            Console.WriteLine("========== REGISTRAR TICKET ==========\n");

            string codigo;
            while (true)
            {
                Console.Write("Código del Ticket (TCK + 4 dígitos): ");
                codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (!EsCodigoValido(codigo))
                {
                    Console.WriteLine("Error: el código debe tener el formato TCK0001.");
                    continue;
                }

                if (heap.Buscar(codigo) != null)
                {
                    Console.WriteLine("Error: el código ya existe. No se permiten duplicados.");
                    continue;
                }

                break;
            }

            string cliente;
            do
            {
                Console.Write("Nombre del Cliente: ");
                cliente = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(cliente))
                    Console.WriteLine("Error: el nombre del cliente no puede estar vacío.");
            } while (string.IsNullOrWhiteSpace(cliente));

            string descripcion;
            do
            {
                Console.Write("Descripción del Problema: ");
                descripcion = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(descripcion))
                    Console.WriteLine("Error: la descripción no puede estar vacía.");
            } while (string.IsNullOrWhiteSpace(descripcion));

            int prioridad = LeerPrioridad();

            Ticket ticket = new Ticket(codigo, cliente, descripcion, prioridad);
            heap.Insertar(ticket);

            Console.WriteLine("\nTicket registrado correctamente.");
            MostrarTicket(ticket);
        }

        static int LeerPrioridad()
        {
            while (true)
            {
                Console.WriteLine("\nNiveles de prioridad:");
                Console.WriteLine("1 - Crítica");
                Console.WriteLine("2 - Alta");
                Console.WriteLine("3 - Media");
                Console.WriteLine("4 - Baja");
                Console.WriteLine("5 - Muy Baja");
                Console.Write("Nivel de Prioridad (1-5): ");

                if (int.TryParse(Console.ReadLine(), out int prioridad) &&
                    prioridad >= 1 && prioridad <= 5)
                {
                    return prioridad;
                }

                Console.WriteLine("Error: la prioridad debe ser un número entre 1 y 5.");
            }
        }

        static void MostrarSiguienteTicket(MinHeap heap)
        {
            Console.WriteLine("========== SIGUIENTE TICKET ==========\n");

            Ticket? ticket = heap.Peek();

            if (ticket == null)
            {
                Console.WriteLine("La Cola de Prioridad está vacía.");
                return;
            }

            Console.WriteLine("Ticket con mayor prioridad:");
            MostrarTicket(ticket);
        }

        static void AtenderTicket(MinHeap heap)
        {
            Console.WriteLine("========== ATENDER TICKET ==========\n");

            Ticket? ticket = heap.ExtractMin();

            if (ticket == null)
            {
                Console.WriteLine("La Cola de Prioridad está vacía.");
                return;
            }

            Console.WriteLine("Ticket atendido correctamente:");
            MostrarTicket(ticket);
        }

        static void MostrarCola(MinHeap heap)
        {
            Console.WriteLine("========== COLA DE PRIORIDAD ==========\n");

            if (heap.Cantidad == 0)
            {
                Console.WriteLine("La Cola de Prioridad está vacía.");
                return;
            }

            Console.WriteLine("Tickets en el orden actual del Min Heap:\n");
            Console.WriteLine(
                "{0,-10} {1,-22} {2,-45} {3,-10}",
                "Código", "Cliente", "Descripción", "Prioridad");
            Console.WriteLine(new string('-', 95));

            foreach (Ticket ticket in heap.ObtenerElementos())
            {
                Console.WriteLine(
                    "{0,-10} {1,-22} {2,-45} {3,-10}",
                    ticket.Codigo,
                    Truncar(ticket.Cliente, 20),
                    Truncar(ticket.Descripcion, 43),
                    ticket.Prioridad);
            }

            Console.WriteLine("\nNota: se muestran según la estructura actual del Heap,");
            Console.WriteLine("no necesariamente en orden completo de prioridad.");
        }

        static void BuscarTicket(MinHeap heap)
        {
            Console.WriteLine("========== BUSCAR TICKET ==========\n");
            Console.Write("Ingrese el código del ticket: ");
            string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

            Ticket? ticket = heap.Buscar(codigo);

            if (ticket == null)
            {
                Console.WriteLine($"No se encontró el ticket con código {codigo}.");
                return;
            }

            Console.WriteLine("\nTicket encontrado:");
            MostrarTicket(ticket);
        }

        static void MostrarCantidad(MinHeap heap)
        {
            Console.WriteLine("========== CANTIDAD DE TICKETS ==========\n");
            Console.WriteLine($"Cantidad actual de tickets: {heap.Cantidad}");
        }

        static void MostrarTicket(Ticket ticket)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Código      : {ticket.Codigo}");
            Console.WriteLine($"Cliente     : {ticket.Cliente}");
            Console.WriteLine($"Descripción : {ticket.Descripcion}");
            Console.WriteLine($"Prioridad   : {ticket.Prioridad} - {ObtenerNombrePrioridad(ticket.Prioridad)}");
            Console.WriteLine("----------------------------------------------");
        }

        static string ObtenerNombrePrioridad(int prioridad)
        {
            return prioridad switch
            {
                1 => "Crítica",
                2 => "Alta",
                3 => "Media",
                4 => "Baja",
                5 => "Muy Baja",
                _ => "Desconocida"
            };
        }

        static bool EsCodigoValido(string codigo)
        {
            if (codigo.Length != 7)
                return false;

            if (!codigo.StartsWith("TCK"))
                return false;

            return int.TryParse(codigo.Substring(3, 4), out _);
        }

        static string Truncar(string texto, int maximo)
        {
            if (texto.Length <= maximo)
                return texto;

            return texto.Substring(0, maximo - 3) + "...";
        }
    }
}
