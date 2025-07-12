using System;

class Program
{
    static void Main(string[] args)
    {
        Categoria raiz = new Categoria("Catálogo Principal");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== MENÚ DE CATÁLOGO ====");
            Console.WriteLine("1. Agregar categoría");
            Console.WriteLine("2. Agregar producto");
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Mostrar catálogo completo");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    AgregarCategoria(raiz);
                    break;
                case "2":
                    AgregarProducto(raiz);
                    break;
                case "3":
                    Console.Write("Nombre del producto a buscar: ");
                    string busqueda = Console.ReadLine()!;
                    BuscarProducto(raiz, busqueda);
                    break;
                case "4":
                    MostrarCatalogo(raiz, 0);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Presiona Enter para continuar.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AgregarCategoria(Categoria actual)
    {
        Console.Write("Nombre de la nueva categoría: ");
        string nombre = Console.ReadLine()!;
        Categoria nueva = new Categoria(nombre);

        Categoria padre = SeleccionarCategoria(actual, "Selecciona la categoría padre:");
        padre.AgregarSubcategoria(nueva);
        Console.WriteLine("Categoría agregada con éxito. Presiona Enter.");
        Console.ReadLine();
    }

    static void AgregarProducto(Categoria actual)
    {
        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine()!;
        Console.Write("Precio del producto: ");
        decimal precio = decimal.Parse(Console.ReadLine()!);

        Producto producto = new Producto(nombre, precio);
        Categoria destino = SeleccionarCategoria(actual, "Selecciona la categoría donde agregar el producto:");
        destino.AgregarProducto(producto);
        Console.WriteLine("Producto agregado con éxito. Presiona Enter.");
        Console.ReadLine();
    }

    static Categoria SeleccionarCategoria(Categoria actual, string mensaje)
    {
        Console.WriteLine(mensaje);
        return SeleccionarCategoriaRecursivo(actual, "");
    }

    static Categoria SeleccionarCategoriaRecursivo(Categoria categoria, string indent)
    {
        Console.WriteLine($"{indent}- {categoria.Nombre}");
        for (int i = 0; i < categoria.Subcategorias.Count; i++)
        {
            Console.WriteLine($"{indent}  {i + 1}. {categoria.Subcategorias[i].Nombre}");
        }

        Console.Write($"{indent}Elige subcategoría (0 para esta categoría): ");
        int opcion = int.Parse(Console.ReadLine()!);

        if (opcion == 0 || opcion > categoria.Subcategorias.Count)
        {
            return categoria;
        }

        return SeleccionarCategoriaRecursivo(categoria.Subcategorias[opcion - 1], indent + "  ");
    }

    static void BuscarProducto(Categoria categoria, string nombre)
    {
        bool encontrado = false;
        BuscarProductoRecursivo(categoria, nombre.ToLower(), ref encontrado);

        if (!encontrado)
        {
            Console.WriteLine("Producto no encontrado.");
        }

        Console.WriteLine("Presiona Enter para continuar.");
        Console.ReadLine();
    }

    static void BuscarProductoRecursivo(Categoria categoria, string nombre, ref bool encontrado)
    {
        foreach (var producto in categoria.Productos)
        {
            if (producto.Nombre.ToLower().Contains(nombre))
            {
                Console.WriteLine($"Encontrado en '{categoria.Nombre}': {producto}");
                encontrado = true;
            }
        }

        foreach (var sub in categoria.Subcategorias)
        {
            BuscarProductoRecursivo(sub, nombre, ref encontrado);
        }
    }

    static void MostrarCatalogo(Categoria categoria, int nivel)
    {
        string indent = new string(' ', nivel * 2);
        Console.WriteLine($"{indent}- {categoria.Nombre}");

        foreach (var producto in categoria.Productos)
        {
            Console.WriteLine($"{indent}  • {producto}");
        }

        foreach (var sub in categoria.Subcategorias)
        {
            MostrarCatalogo(sub, nivel + 1);
        }

        if (nivel == 0)
        {
            Console.WriteLine("\nPresiona Enter para continuar.");
            Console.ReadLine();
        }
    }
}