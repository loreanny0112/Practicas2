using System;
using System.Collections.Generic; 

namespace ContactApp
{
    public class ContactManager
    {
        // tabla Hash para almacenar contactos: clave = nombre, valor = teléfono
        private Dictionary<string, string> contacts;

        // constructor: se ejecuta cuando creamos un ContactManager
        public ContactManager()
        {
            contacts = new Dictionary<string, string>();
        }

        // para agregar un contacto
        public void AddContact(string name, string phone)
        {
            // para verificar si ya existe
            if (!contacts.ContainsKey(name))
            {
                contacts[name] = phone;
                Console.WriteLine("Contacto agregado correctamente.");
            }
            else
            {
                Console.WriteLine("El contacto ya existe.");
            }
        }

        // para buscar un contacto
        public void SearchContact(string name)
        {
            if (contacts.ContainsKey(name))
            {
                Console.WriteLine($"Teléfono de {name}: {contacts[name]}");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }

        // para eliminar un contacto
        public void RemoveContact(string name)
        {
            if (contacts.Remove(name))
            {
                Console.WriteLine("Contacto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el contacto.");
            }
        }
    }
}
