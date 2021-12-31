using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistencia;
using System;

namespace LeerData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.- Leemos configuraciones
            IConfigurationBuilder config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
              .AddEnvironmentVariables();
            IConfigurationRoot configurationRoot = config.Build();

            // 2) Inyectamos todos los servicios que queramos usar

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configurationRoot)
                .AddDbContext<SqlServerCursosOnlineContext>(opt =>
                {
                    opt.UseSqlServer(configurationRoot.GetSection("SqlConnections:SqlServer").Value);
                })
                .AddDbContext<MySqlCursosOnlineContext>(opt =>
                {
                    opt.UseMySql(configurationRoot.GetSection("SqlConnections:MySql").Value, new MySqlServerVersion(new Version(8, 5, 64)));
                })
                .BuildServiceProvider();

            serviceProvider.GetService<ILoggerFactory>();

            using (var db = serviceProvider.GetService<SqlServerCursosOnlineContext>())
            {
                var cursos = db.Curso
                    .Include(p => p.Precio)
                    .Include(c => c.Comentarios)
                    .Include(c => c.CursoInstructor).ThenInclude(ci => ci.Instructor)
                    .AsNoTracking();
                foreach (var curso in cursos)
                {
                    Console.WriteLine($"{curso.CursoId}.- {curso.Titulo} \nPrecio: {curso.Precio.PrecioActual}");
                    Console.WriteLine("Comentarios: ");
                    foreach (var comentario in curso.Comentarios)
                    {
                        Console.WriteLine($"{comentario.ComentarioId}.- {comentario.Alumno}: {comentario.ComentarioTexto}");
                    }
                    Console.WriteLine("Instructores: ");
                    foreach (var insLink in curso.CursoInstructor)
                    {
                        Console.WriteLine($"{insLink.Instructor.InstructorId}.- {insLink.Instructor.Nombre}");
                    }
                }
            }

            using (var db = serviceProvider.GetService<MySqlCursosOnlineContext>())
            {
                var cursos = db.Curso
                    .Include(p => p.Precio)
                    .Include(c => c.Comentarios)
                    .Include(c => c.CursoInstructor).ThenInclude(ci => ci.Instructor)
                    .AsNoTracking();
                foreach (var curso in cursos)
                {
                    Console.WriteLine($"{curso.CursoId}.- {curso.Titulo} \nPrecio: {curso.Precio.PrecioActual}");
                    Console.WriteLine("Comentarios: ");
                    foreach (var comentario in curso.Comentarios)
                    {
                        Console.WriteLine($"{comentario.ComentarioId}.- {comentario.Alumno}: {comentario.ComentarioTexto}");
                    }
                    Console.WriteLine("Instructores: ");
                    foreach (var insLink in curso.CursoInstructor)
                    {
                        Console.WriteLine($"{insLink.Instructor.InstructorId}.- {insLink.Instructor.Nombre}");
                    }
                }
            }
        }
    }
}
