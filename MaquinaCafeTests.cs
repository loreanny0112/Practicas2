using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaquinaCafeTDD.Models;
using MaquinaCafeTDD.Services;
using System.Collections.Generic;

namespace MaquinaCafeTDD.Tests
{
    [TestClass]
    public class MaquinaCafeTests
    {
        private Dictionary<string, Vaso> _vasos;
        private Cafetera _cafetera;
        private Azucarero _azucarero;
        private MaquinaCafe _maquina;

        [TestInitialize]
        public void Inicializar()
        {
            _vasos = new Dictionary<string, Vaso>
            {
                { "pequeño", new Vaso("Pequeño", 1, 3) },
                { "mediano", new Vaso("Mediano", 1, 5) },
                { "grande", new Vaso("Grande", 1, 7) }
            };

            _cafetera = new Cafetera(100); // suficiente café
            _azucarero = new Azucarero(50); // suficiente azúcar
            _maquina = new MaquinaCafe(_vasos, _cafetera, _azucarero);
        }

        [TestMethod]
        public void DebeServirCafeCorrectamente()
        {
            var resultado = _maquina.ServirCafe("mediano", 2);
            Assert.AreEqual("Aquí tiene su café mediano con 2 cucharadas de azúcar.", resultado);
        }

        [TestMethod]
        public void NoDebeServirCafeSiNoHayCafe()
        {
            _cafetera = new Cafetera(0);
            _maquina = new MaquinaCafe(_vasos, _cafetera, _azucarero);

            var resultado = _maquina.ServirCafe("pequeño", 1);
            Assert.AreEqual("No hay café disponible.", resultado);
        }

        [TestMethod]
        public void NoDebeServirCafeSiNoHayVasos()
        {
            _vasos["mediano"] = new Vaso("Mediano", 0, 5);
            _maquina = new MaquinaCafe(_vasos, _cafetera, _azucarero);

            var resultado = _maquina.ServirCafe("mediano", 2);
            Assert.AreEqual("No hay vasos disponibles.", resultado);
        }

        [TestMethod]
        public void NoDebeServirCafeSiNoHayAzucar()
        {
            _azucarero = new Azucarero(0);
            _maquina = new MaquinaCafe(_vasos, _cafetera, _azucarero);

            var resultado = _maquina.ServirCafe("grande", 2);
            Assert.AreEqual("No hay azúcar suficiente.", resultado);
        }

        [TestMethod]
        public void DebeDetectarTamañoInvalido()
        {
            var resultado = _maquina.ServirCafe("extra grande", 1);
            Assert.AreEqual("Tamaño de vaso inválido.", resultado);
        }
    }
}
