﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerData.Entities
{
    public class CursoInstructor
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}