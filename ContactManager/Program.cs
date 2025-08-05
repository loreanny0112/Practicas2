using System;

namespace ContactApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager manager = new ContactManager();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- MENÚ DE CONTACTOS ---");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Buscar contacto");
                Console.WriteLine("3. Eliminar contacto");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        Console.Write("Nombre: ");
                        string name = Console.ReadLine()!;
                        Console.Write("Teléfono: ");
                        string phone = Console.ReadLine()!;
                        manager.AddContact(name, phone);
                        break;

                    case "2":
                        Console.Write("Nombre a buscar: ");
                        string searchName = Console.ReadLine()!;
                        manager.SearchContact(searchName);
                        break;

                    case "3":
                        Console.Write("Nombre a eliminar: ");
                        string removeName = Console.ReadLine()!;
                        manager.RemoveContact(removeName);
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}