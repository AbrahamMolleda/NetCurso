using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<Curso>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<CursoUnico, Curso>
        {
            private readonly SqlServerCursosOnlineContext _sqlServerCursosOnlineContext;
            public Manejador(SqlServerCursosOnlineContext sqlServerCursosOnlineContext)
            {
                _sqlServerCursosOnlineContext = sqlServerCursosOnlineContext;
            }

            public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var curso = await _sqlServerCursosOnlineContext.Curso.FindAsync(request.Id);
                return curso;
            }
        }
    }
}
