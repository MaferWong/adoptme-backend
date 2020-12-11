using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopciones.Models
{
    public class Refugio
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correoElectronico { get; set; }
        public string contrasena { get; set; }
        public string imagenURL { get; set; } 
        public List<Mascota> Mascotas { get; set; }
    }
}
