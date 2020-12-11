using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adopciones.ApplicationService;
using Adopciones.DataContext;
using Adopciones.Models;

namespace Adopciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefugioController : Controller
    {
        private readonly AdopcionDataContext _baseDatos;
        private readonly RefugioAppService _refugioAppService;
        public RefugioController(AdopcionDataContext _context, RefugioAppService refugioAppService)
        {
            _baseDatos = _context;
            _refugioAppService = refugioAppService;

            if (_baseDatos.Refugios.Count() == 0)
            {
                _baseDatos.Refugios.Add(new Refugio { nombre = "SOS Rescate Animal", correoElectronico = "sosrescate@gmail.com", contrasena = "contrasena123", imagenURL = "https://miro.medium.com/max/11520/1*MKkufG0eyT0IQ5wZ70qKxQ.jpeg"});
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Refugio>>> GetRefugios()
        {
            return await _baseDatos.Refugios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Refugio>> GetRefugio(int id)
        {
            var respuestaRefugioAppService = await _refugioAppService.GetRefugioApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaRefugioAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Refugios.FirstOrDefaultAsync(q => q.id == id);
            }
            return BadRequest(respuestaRefugioAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Refugio>> PostRefugio(Refugio refugio)
        {
            var respuestaRefugioAppService = await _refugioAppService.PostRefugioApplicationService(refugio);

            bool noHayErroresEnValidaciones = respuestaRefugioAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetRefugio), new { id = refugio.id }, refugio);
            }
            return BadRequest(respuestaRefugioAppService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefugio(int id, Refugio refugio)
        {
            var respuestaRefugioAppService = await _refugioAppService.PutRefugioApplicationService(id, refugio);

            bool noHayErroresEnValidaciones = respuestaRefugioAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaRefugioAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefugio(int id)
        {
            var respuestaRefugioAppService = await _refugioAppService.DeleteRefugioApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaRefugioAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaRefugioAppService);
        }
    }
}
