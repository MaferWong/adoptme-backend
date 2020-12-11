using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adopciones.DataContext;
using Adopciones.DomainService;
using Adopciones.Models;

namespace Adopciones.ApplicationService
{
    public class MascotaAppService
    {
        private readonly AdopcionDataContext _baseDatos;
        private readonly MascotaDomainService _mascotaDomainService;
        public MascotaAppService(AdopcionDataContext _context, MascotaDomainService mascotaDomainService)
        {
            _baseDatos = _context;
            _mascotaDomainService = mascotaDomainService;
        }
        public async Task<string> GetMascotaApplicationService(int id)
        {
            var mascota = await _baseDatos.Mascotas.Include(q => q.Refugio).FirstOrDefaultAsync(q => q.id == id);

            var respuestaDomainService = _mascotaDomainService.GetMascotaDomainService(id, mascota);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostMascotaApplicationService(Mascota mascota)
        {
            var respuestaDomainService = _mascotaDomainService.PostMascotaDomainService(mascota);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Mascotas.Add(mascota);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutMascotaApplicationService(int id, Mascota mascota)
        {
            Refugio refugio = await _baseDatos.Refugios.FirstOrDefaultAsync(q => q.id == mascota.refugioId);

            var respuestaDomainService = _mascotaDomainService.PutMascotaDomainService(id, mascota, refugio);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(mascota).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteMascotaApplicationService(int id)
        {
            var mascota = await _baseDatos.Mascotas.FindAsync(id);

            var respuestaDomainService = _mascotaDomainService.DeleteMascotaDomainService(id, mascota);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Mascotas.Remove(mascota);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}