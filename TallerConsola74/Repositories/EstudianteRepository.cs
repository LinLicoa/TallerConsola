using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerConsola74.Migrations;
using TallerConsola74.Models;

namespace TallerConsola74.Repositories
{
    public class EstudianteRepository
    {
        private readonly TallerContext _context;

        public EstudianteRepository(TallerContext context)
        {
            _context = context;
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
        }   

        public Estudiante ConsultarEstudiantePorId(int id)
        {
            return _context.Estudiantes.Find(id);
        }

        public List<Estudiante> ConsultarEstudiantes()
        {
            return _context.Estudiantes.ToList();
        }

        public Estudiante ObtenerPrimerEstudiante()
        {
            return _context.Estudiantes.First();
        }

        public int ContarEstudiantes()
        {
            return _context.Estudiantes.Count();
        }

        public List<Estudiante> TraerAnita()
        {
            // Consulta que devuelve a los estudiantes con id mayor que 2 y que el nombre sea igual a Anita
            return _context.Estudiantes.Where(e => e.EstudianteId > 2 && e.Nombre == "Anita").ToList();
        }

        public List<Estudiante> TraerPattyAnita()
        {
            // Consulta que devuelve a los estudiantes donde el nombre sea igual Patty o Anita
            return _context.Estudiantes.Where(e => e.Nombre == "Anita" || e.Nombre == "Patty").ToList();
        }


        public List<Estudiante> EstudiantesA()
        {
            // Consulta que devuelve a los estudiantes que su nombre comienzan con la letra A
            return _context.Estudiantes.Where(e => e.Nombre.StartsWith("A")).ToList();
        }

        public List<Estudiante> GrupoEstudiantes()
        {
            // Uso de GroupBy
            return _context.Estudiantes
                .GroupBy(e => e.Nombre)
                .Select(grupo => new Estudiante
                {
                    Nombre = grupo.Key,
                    Cantidad = grupo.Count()
                }).ToList();
        }

    }
}
