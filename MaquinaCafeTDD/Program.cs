using System;
using System.Collections.Generic;
using MaquinaCafeTDD.Models;
using MaquinaCafeTDD.Services;

namespace MaquinaCafeTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear vasos disponibles
            var vasos = new Dictionary<string, Vaso>(StringComparer.OrdinalIgnoreCase)
            {
                { "pequeño", new Vaso("Pequeño", cantidad: 5, onzas: 3) },
                { "mediano", new Vaso("Mediano", cantidad: 5, onzas: 5) },
                { "grande",  new Vaso("Grande", cantidad: 5, onzas: 7) }
            };

            // Crear cafetera y azucarero
            var cafetera = new Cafetera(100);
            var azucarero = new Azucarero(50);

            var maquina = new MaquinaCafe(vasos, cafetera, azucarero);

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("==== MÁQUINA DE CAFÉ ====");
                Console.WriteLine("Tamaños disponibles: Pequeño (3 oz), Mediano (5 oz), Grande (7 oz)");

                Console.Write("Seleccione el tamaño del vaso: ");
                string tamaño = Console.ReadLine()?.Trim().ToLowerInvariant()!;

                Console.Write("Ingrese la cantidad de azúcar (cucharadas): ");
                if (!int.TryParse(Console.ReadLine(), out int cucharadasAzucar))
                {
                    Console.WriteLine("Entrada inválida para el azúcar. Presione Enter para continuar...");
                    Console.ReadLine();
                    continue;
                }

                string resultado = maquina.ServirCafe(tamaño, cucharadasAzucar);
                Console.WriteLine("\n" + resultado);

                // Preguntar si desea otro café
                Console.Write("\n¿Desea otro café? (s/n): ");
                string opcion = Console.ReadLine()?.Trim().ToLower()!;

                if (opcion != "s" && opcion != "sí" && opcion != "si")
                {
                    continuar = false;
                }
            }

                Console.WriteLine("¡Gracias por usar nuestra máquina de café!");
        }
    }
}
