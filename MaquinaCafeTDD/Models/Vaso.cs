namespace MaquinaCafeTDD.Models
{
    public class Vaso
    {
        public string Tamaño { get; set; }
        public int Cantidad { get; set; }
        public int Onzas { get; set; }

        public Vaso(string tamaño, int cantidad, int onzas)
        {
            Tamaño = tamaño;
            Cantidad = cantidad;
            Onzas = onzas;
        }

        public bool HayVasosDisponibles()
        {
            return Cantidad > 0;
        }

        public void UsarVaso()
        {
            if (Cantidad > 0)
                Cantidad--;
        }
    }
}
