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
    public class MascotaController : Controller
    {
        private readonly AdopcionDataContext _baseDatos;
        private readonly MascotaAppService _mascotaAppService;
        public MascotaController(AdopcionDataContext _context, MascotaAppService mascotaAppService)
        {
            _baseDatos = _context;
            _mascotaAppService = mascotaAppService;

            if (_baseDatos.Mascotas.Count() == 0)
            {
                _baseDatos.Mascotas.Add(new Mascota { nombre = "Ellie", descripcion = "Very cute 3 year-old cat.", imagenURL = "https://www.infobae.com/new-resizer/H2YD9fPh4_fFfmg3_ujr3Y1SST0=/420x236/filters:format(jpg):quality(85)/s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2019/01/20085328/Boo-perrito-mas-lindo-del-mundo-7.jpg", refugioId = 1 });
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetMascotas()
        {
            return await _baseDatos.Mascotas.Include(q => q.Refugio).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> GetMascota(int id)
        {
            var respuestaMascotaAppService = await _mascotaAppService.GetMascotaApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaMascotaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Mascotas.Include(q => q.Refugio).FirstOrDefaultAsync(q => q.id == id);
            }
            return BadRequest(respuestaMascotaAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Mascota>> PostMascota(Mascota mascota)
        {
            var respuestaMascotaAppService = await _mascotaAppService.PostMascotaApplicationService(mascota);

            bool noHayErroresEnValidaciones = respuestaMascotaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetMascota), new { id = mascota.id }, mascota);
            }
            return BadRequest(respuestaMascotaAppService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota(int id, Mascota mascota)
        {
            var respuestaMascotaAppService = await _mascotaAppService.PutMascotaApplicationService(id, mascota);

            bool noHayErroresEnValidaciones = respuestaMascotaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaMascotaAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            var respuestaMascotaAppService = await _mascotaAppService.DeleteMascotaApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaMascotaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaMascotaAppService);
        }
    }
}
