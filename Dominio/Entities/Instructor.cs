using System;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Instructor
    {
        public Guid InstructorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Grado { get; set; }
        public byte[] FotoPerfil { get; set; }
        public ICollection<CursoInstructor> CursoInstructor { get; set; }
    }
}
