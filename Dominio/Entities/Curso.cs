using System;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public  class Curso
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public byte[] FotoPortada { get; set; }
        public Precio Precio { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<CursoInstructor> CursoInstructor { get; set; }
    }
}
