using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualizacionTallerApuntes.Models
{
    public class Miembro
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string DeporteFavorito { get; set; }
        public string Foto { get; set; } // Ruta local o URL
    }
}
