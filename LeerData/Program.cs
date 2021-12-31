using LeerData.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LeerData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SqlAppVentasCursosContext())
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

            using (var db = new MySqlAppVentasCursosContext())
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
