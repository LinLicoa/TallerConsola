// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using TallerConsola74.Models;
using TallerConsola74.Repositories;



var optionsBuilder = new DbContextOptionsBuilder<TallerContext>();
optionsBuilder.UseSqlServer(@"Server=DESKTOP-PC-LIN\SQLEXPRESS;Database=TallerConsola74;Trusted_Connection=True;Encrypt=False;");

var tallerContext = new TallerContext(optionsBuilder.Options);

try
{
    //tallerContext.Database.Migrate(); 
    EstudianteRepository estudianteRepository = new EstudianteRepository(tallerContext);

    Console.WriteLine("Ingrese los datos del estudiante");

    Console.Write("Cédula: ");
    string cedula = Console.ReadLine();

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Apellido: ");
    string apellido = Console.ReadLine();

    Console.Write("Curso ID: ");
    int cursoId;
    while (!int.TryParse(Console.ReadLine(), out cursoId))
    {
        Console.Write("Por favor ingrese un número válido para el Curso ID: ");
    }

    var estudiante = new Estudiante()
    {
        Cedula = cedula,
        Nombre = nombre,
        Apellido = apellido,
        CursoId = cursoId
    };

    estudianteRepository.AgregarEstudiante(estudiante);
    Console.WriteLine($"Estudiante {estudiante.Nombre} {estudiante.Apellido} agregado con id {estudiante.EstudianteId}");

    //consultar estudiante por id   
    Console.WriteLine("Ingrese el id del estudiante a consultar");
    int id;
    while (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.Write("Por favor ingrese un número válido para el ID: ");
    }
    var estudianteConsultado = estudianteRepository.ConsultarEstudiantePorId(id);
    Console.WriteLine($"Estudiante consultado {estudianteConsultado.Nombre} {estudianteConsultado.Apellido}");

    //consultar todos los estudiantes
    var estudiantes = estudianteRepository.ConsultarEstudiantes();

    Console.WriteLine("Estudiantes registrados:\n");
    for (int i = 0; i < estudiantes.Count; i++)
    {
        Console.WriteLine($"Estudiante {estudiantes[i].Nombre} {estudiantes[i].Apellido}"); 
    }

    int totalEstudiante = estudianteRepository.ContarEstudiantes();
    Console.WriteLine("Total de estudiantes: " + totalEstudiante.ToString());

    var primerEstudiante = estudianteRepository.ObtenerPrimerEstudiante();
    Console.WriteLine("Primer elemento de la tabla: " + primerEstudiante.Cedula + "-" + primerEstudiante.Nombre);

    // Consulta que devuelve a los estudiantes con id mayor que 2 y que el nombre sea igual a Anita
    Console.WriteLine("Consulta que devuelve a los estudiantes con id mayor que 2 y que el nombre sea igual a Anita\r\n");
    var anita = estudianteRepository.TraerAnita();
    foreach (var item in anita)
    {
        Console.WriteLine("Codigo: " + item.EstudianteId + " Nombre: " + item.Nombre);
    }

    // Consulta que devuelve a los estudiantes donde el nombre sea igual Patty o Anita
    Console.WriteLine("Consulta que devuelve a los estudiantes donde el nombre sea igual Patty o Anita");
    var alumnas = estudianteRepository.TraerPattyAnita();
    foreach (var item in alumnas)
    {
        Console.WriteLine("Codigo: " + item.EstudianteId + " Nombre: " + item.Nombre);
    }

    // Consulta que devuelve a los estudiantes que su nombre comienzan con la letra A
    Console.WriteLine("Consulta que devuelve a los estudiantes que su nombre comienzan con la letra A");
    var A = estudianteRepository.EstudiantesA();
    foreach (var item in A)
    {
        Console.WriteLine("Codigo: " + item.EstudianteId + " Nombre: " + item.Nombre);
    }

    //var grupoEstudiante = estudianteRepository.GrupoEstudiantes;

    //foreach (var resultado in grupoEstudiante)
    //{
    //    Console.WriteLine($"Nombre: {resultado.Nombre}, Cantidad: {resultado.Cantidad}");
    //}



}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

finally
{
    if (tallerContext != null)
    {
        tallerContext.Dispose();
    }
}
