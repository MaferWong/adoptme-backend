using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adopciones.DomainService;
using Adopciones.Models;

namespace UnitTestAdopciones
{
    [TestClass]
    public class UnitTestMascota
    {
        [TestMethod]
        public void PruebaParaValidarSiMascotaExiste()
        {
            var mascota = new Mascota();
            var id = new int();
            mascota = null;

            var mascotaDomainService = new MascotaDomainService();
            var resultado = mascotaDomainService.GetMascotaDomainService(id, mascota);

            Assert.AreEqual("La mascota no existe.", resultado);
        }

        [TestMethod]
        public void PruebaParaValidarSiHayNombreMascota()
        {
            var mascota = new Mascota();
            mascota.nombre = "";

            var mascotaDomainService = new MascotaDomainService();
            var resultado = mascotaDomainService.PostMascotaDomainService(mascota);

            Assert.AreEqual("Se necesita el nombre de la mascota.", resultado);
        }

        [TestMethod]
        public void PruebaParaValidadSiRefugioExiste()
        {
            var mascota = new Mascota();
            var id = new int();
            var refugio = new Refugio();
            refugio = null;

            var mascotaDomainService = new MascotaDomainService();
            var resultado = mascotaDomainService.PutMascotaDomainService(id, mascota, refugio);

            Assert.AreEqual("El refugio no existe.", resultado);
        }

        [TestMethod]
        public void PruebaParaValidarSiMascotaExisteParaEliminar()
        {
            var mascota = new Mascota();
            var id = new int();
            mascota = null;

            var mascotaDomainService = new MascotaDomainService();
            var resultado = mascotaDomainService.DeleteMascotaDomainService(id, mascota);

            Assert.AreEqual("La mascota no existe.", resultado);
        }
    }
}
