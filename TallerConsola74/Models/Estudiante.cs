using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerConsola74.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CursoId { get; set; }
        
    }
}
