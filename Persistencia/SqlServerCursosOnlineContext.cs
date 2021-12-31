﻿using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class SqlServerCursosOnlineContext : DbContext
    {
        public SqlServerCursosOnlineContext(DbContextOptions<SqlServerCursosOnlineContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => new { ci.InstructorId, ci.CursoId });
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<CursoInstructor> CursoInstructor { get; set; }
    }

}
