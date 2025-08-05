using System;
using System.Collections.Generic;

namespace ListaGenerica
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> lista = new List<object>();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Agregar elemento");
                Console.WriteLine("2. Eliminar elemento");
                Console.WriteLine("3. Buscar elemento");
                Console.WriteLine("4. Mostrar lista");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        Console.Write("Introduce el elemento (número o palabra): ");
                        string entrada = Console.ReadLine()!;

                        if (int.TryParse(entrada, out int numero))
                            lista.Add(numero);
                        else
                            lista.Add(entrada);

                        Console.WriteLine("Elemento agregado.");
                        break;

                    case "2":
                        Console.Write("Introduce el elemento a eliminar: ");
                        string eliminar = Console.ReadLine()!;

                        if (int.TryParse(eliminar, out int numEliminar))
                            lista.Remove(numEliminar);
                        else
                            lista.Remove(eliminar);

                        Console.WriteLine("Si existía, fue eliminado.");
                        break;

                    case "3":
                        Console.Write("Introduce el elemento a buscar: ");
                        string buscar = Console.ReadLine();

                        bool encontrado;
                        if (int.TryParse(buscar, out int numBuscar))
                            encontrado = lista.Contains(numBuscar);
                        else
                            encontrado = lista.Contains(buscar);

                        Console.WriteLine(encontrado ? "Elemento encontrado." : "Elemento no encontrado.");
                        break;

                    case "4":
                        Console.WriteLine("\nContenido de la lista:");
                        foreach (var item in lista)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "5":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
