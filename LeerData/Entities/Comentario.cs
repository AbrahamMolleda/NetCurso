﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerData.Entities
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Alumno { get; set; }
        public int Puntaje { get; set; }
        public string ComentarioTexto { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
