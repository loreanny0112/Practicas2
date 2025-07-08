namespace MaquinaCafeTDD.Models
{
    public class Cafetera
    {
        public int CantidadCafe { get; set; } // En onzas

        public Cafetera(int cantidadCafe)
        {
            CantidadCafe = cantidadCafe;
        }

        public bool HayCafeDisponible(int onzasSolicitadas)
        {
            return CantidadCafe >= onzasSolicitadas;
        }

        public void UsarCafe(int onzas)
        {
            if (CantidadCafe >= onzas)
                CantidadCafe -= onzas;
        }
    }
}
