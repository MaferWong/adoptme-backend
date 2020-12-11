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
    public class RefugioAppService
    {
        private readonly AdopcionDataContext _baseDatos;
        private readonly RefugioDomainService _refugioDomainService;
        public RefugioAppService(AdopcionDataContext _context, RefugioDomainService refugioDomainService)
        {
            _baseDatos = _context;
            _refugioDomainService = refugioDomainService;
        }
        public async Task<string> GetRefugioApplicationService(int id)
        {
            var refugio = await _baseDatos.Refugios.FirstOrDefaultAsync(q => q.id == id);

            var respuestaDomainService = _refugioDomainService.GetRefugioDomainService(id, refugio);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostRefugioApplicationService(Refugio refugio)
        {
            var respuestaDomainService = _refugioDomainService.PostRefugioDomainService(refugio);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Refugios.Add(refugio);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutRefugioApplicationService(int id, Refugio refugio)
        {
            var respuestaDomainService = _refugioDomainService.PutRefugioDomainService(id, refugio);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(refugio).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteRefugioApplicationService(int id)
        {
            var refugio = await _baseDatos.Refugios.FindAsync(id);

            var respuestaDomainService = _refugioDomainService.DeleteRefugioDomainService(id, refugio);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Refugios.Remove(refugio);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}