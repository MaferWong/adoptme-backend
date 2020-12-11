using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adopciones.Models;

namespace Adopciones.DomainService
{
    public class RefugioDomainService
    {
        public string GetRefugioDomainService(int id, Refugio refugio)
        {
            if (refugio == null)
            {
                return "El refugio no existe.";
            }
            return null;
        }
        public string PostRefugioDomainService(Refugio refugio)
        {
            if (refugio.nombre == "")
            {
                return "Se necesita el nombre del refugio.";
            }
            return null;
        }
        public string PutRefugioDomainService(int id, Refugio refugio)
        {
            if (id != refugio.id)
            {
                return "El refugio no existe.";
            }
            if (refugio.nombre == "")
            {
                return "Se necesita el nombre del refugio.";
            }
            return null;
        }
        public string DeleteRefugioDomainService(int id, Refugio refugio)
        {
            if (refugio == null)
            {
                return "El refugio no existe.";
            }
            return null;
        }
    }
}
