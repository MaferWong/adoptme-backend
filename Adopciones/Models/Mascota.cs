using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopciones.Models
{
    public class Mascota
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagenURL { get; set; }
        public int refugioId { get; set; }
        public Refugio Refugio { get; set; }
    }
}
