using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adopciones.Models;

namespace Adopciones.DomainService
{
    public class MascotaDomainService
    {
        public string GetMascotaDomainService(int id, Mascota mascota)
        {
            if (mascota == null)
            {
                return "La mascota no existe.";
            }
            return null;
        }
        public string PostMascotaDomainService(Mascota mascota)
        {
            if (mascota.nombre == "")
            {
                return "Se necesita el nombre de la mascota.";
            }
            return null;
        }
        public string PutMascotaDomainService(int id, Mascota mascota, Refugio refugio)
        {
            if (id != mascota.id)
            {
                return "La mascota no existe.";
            }
            if (refugio == null)
            {
                return "El refugio no existe.";
            }
            return null;
        }
        public string DeleteMascotaDomainService(int id, Mascota mascota)
        {
            if (mascota == null)
            {
                return "La mascota no existe.";
            }
            return null;
        }
    }
}
