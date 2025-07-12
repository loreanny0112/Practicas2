using System.Collections.Generic;

public class Categoria
{
    public string Nombre { get; set; }
    public List<Categoria> Subcategorias { get; set; } = new List<Categoria>();
    public List<Producto> Productos { get; set; } = new List<Producto>();

    public Categoria(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarSubcategoria(Categoria subcategoria)
    {
        Subcategorias.Add(subcategoria);
    }

    public void AgregarProducto(Producto producto)
    {
        Productos.Add(producto);
    }
}