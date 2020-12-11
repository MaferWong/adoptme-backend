using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adopciones.DomainService;
using Adopciones.Models;

namespace UnitTestAdopciones
{
    [TestClass]
    public class UnitTestRefugio
    {
        [TestMethod]
        public void PruebaParaValidarSiRefugioExiste()
        {
            var refugio = new Refugio();
            var id = new int();
            refugio = null;
            
            var refugioDomainService = new RefugioDomainService();
            var resultado = refugioDomainService.GetRefugioDomainService(id, refugio);
            
            Assert.AreEqual("El refugio no existe.", resultado);
        }

        [TestMethod]
        public void PruebaParaValidarSiHayNombreRefugio()
        {
            var refugio = new Refugio();
            refugio.nombre = "";
            
            var refugioDomainService = new RefugioDomainService();
            var resultado = refugioDomainService.PostRefugioDomainService(refugio);
            
            Assert.AreEqual("Se necesita el nombre del refugio.", resultado);
        }

        [TestMethod]
        public void PruebaParaValidarSiRefugioExisteParaEliminar()
        {
            var refugio = new Refugio();
            var id = new int();
            refugio = null;
            
            var refugioDomainService = new RefugioDomainService();
            var resultado = refugioDomainService.DeleteRefugioDomainService(id, refugio);
            
            Assert.AreEqual("El refugio no existe.", resultado);
        }
    }
}