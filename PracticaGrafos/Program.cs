using System;
using System.Collections.Generic;

class Program
{
    static List<string> personas = new List<string>();
    static int[,] matriz;

    static void Main(string[] args)
    {
        Console.Write("¿Cuántas personas quieres registrar en la red? ");
        int cantidad = int.Parse(Console.ReadLine()!);
        matriz = new int[cantidad, cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write($"Nombre de la persona {i + 1}: ");
            personas.Add(Console.ReadLine()!);
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ RED SOCIAL ===");
            Console.WriteLine("1. Crear amistad entre dos personas");
            Console.WriteLine("2. Mostrar amigos de una persona");
            Console.WriteLine("3. Buscar amigos en común entre dos personas");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    CrearAmistad();
                    break;
                case "2":
                    MostrarAmigos();
                    break;
                case "3":
                    BuscarAmigosEnComun();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Presiona Enter.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CrearAmistad()
    {
        int a = SeleccionarPersona("Selecciona la primera persona: ");
        int b = SeleccionarPersona("Selecciona la segunda persona: ");

        if (a == b)
        {
            Console.WriteLine("Una persona no puede ser amiga de sí misma.");
        }
        else
        {
            matriz[a, b] = 1;
            matriz[b, a] = 1;
            Console.WriteLine("¡Amistad creada!");
        }

        Console.WriteLine("Presiona Enter para continuar.");
        Console.ReadLine();
    }

    static void MostrarAmigos()
    {
        int idx = SeleccionarPersona("Selecciona una persona para ver sus amigos:");
        Console.WriteLine($"Amigos de {personas[idx]}:");

        bool tieneAmigos = false;
        for (int i = 0; i < personas.Count; i++)
        {
            if (matriz[idx, i] == 1)
            {
                Console.WriteLine("- " + personas[i]);
                tieneAmigos = true;
            }
        }

        if (!tieneAmigos)
        {
            Console.WriteLine("No tiene amigos registrados.");
        }

        Console.WriteLine("Presiona Enter para continuar.");
        Console.ReadLine();
    }

    static void BuscarAmigosEnComun()
    {
        int a = SeleccionarPersona("Selecciona la primera persona: ");
        int b = SeleccionarPersona("Selecciona la segunda persona: ");

        Console.WriteLine($"Amigos en común entre {personas[a]} y {personas[b]}:");
        bool tieneComunes = false;

        for (int i = 0; i < personas.Count; i++)
        {
            if (matriz[a, i] == 1 && matriz[b, i] == 1)
            {
                Console.WriteLine("- " + personas[i]);
                tieneComunes = true;
            }
        }

        if (!tieneComunes)
        {
            Console.WriteLine("No tienen amigos en común.");
        }

        Console.WriteLine("Presiona Enter para continuar.");
        Console.ReadLine();
    }

    static int SeleccionarPersona(string mensaje)
    {
        Console.WriteLine(mensaje);
        for (int i = 0; i < personas.Count; i++)
        {
            Console.WriteLine($"{i}. {personas[i]}");
        }

        int index;
        while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= personas.Count)
        {
            Console.Write("Índice inválido. Intenta de nuevo: ");
        }

        return index;
    }
}
