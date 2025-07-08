using MaquinaCafeTDD.Models;
using System.Collections.Generic;

namespace MaquinaCafeTDD.Services
{
    public class MaquinaCafe
    {
        private readonly Dictionary<string, Vaso> _vasos;
        private readonly Cafetera _cafetera;
        private readonly Azucarero _azucarero;

        public MaquinaCafe(Dictionary<string, Vaso> vasos, Cafetera cafetera, Azucarero azucarero)
        {
            _vasos = vasos;
            _cafetera = cafetera;
            _azucarero = azucarero;
        }

        public string ServirCafe(string tamaño, int cucharadasAzucar)
        {
            if (!_vasos.ContainsKey(tamaño))
                return "Tamaño de vaso inválido.";

            Vaso vasoSeleccionado = _vasos[tamaño];

            if (!vasoSeleccionado.HayVasosDisponibles())
                return "No hay vasos disponibles.";

            if (!_cafetera.HayCafeDisponible(vasoSeleccionado.Onzas))
                return "No hay café disponible.";

            if (!_azucarero.HayAzucarDisponible(cucharadasAzucar))
                return "No hay azúcar suficiente.";

            // Servir el café
            vasoSeleccionado.UsarVaso();
            _cafetera.UsarCafe(vasoSeleccionado.Onzas);
            _azucarero.UsarAzucar(cucharadasAzucar);

            return $"Aquí tiene su café {tamaño.ToLower()} con {cucharadasAzucar} cucharadas de azúcar.";
        }
    }
}
