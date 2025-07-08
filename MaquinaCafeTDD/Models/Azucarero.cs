namespace MaquinaCafeTDD.Models
{
    public class Azucarero
    {
        public int CantidadAzucar { get; set; } // En cucharadas

        public Azucarero(int cantidadAzucar)
        {
            CantidadAzucar = cantidadAzucar;
        }

        public bool HayAzucarDisponible(int cucharadas)
        {
            return CantidadAzucar >= cucharadas;
        }

        public void UsarAzucar(int cucharadas)
        {
            if (CantidadAzucar >= cucharadas)
                CantidadAzucar -= cucharadas;
        }
    }
}
