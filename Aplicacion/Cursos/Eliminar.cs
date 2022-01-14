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
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly SqlServerCursosOnlineContext _sqlServerCursosOnlineContext;
            public Manejador(SqlServerCursosOnlineContext sqlServerCursosOnlineContext)
            {
                _sqlServerCursosOnlineContext = sqlServerCursosOnlineContext;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = await _sqlServerCursosOnlineContext.Curso.FindAsync(request.Id);
                if (curso == null)
                {
                    throw new Exception("No se pudo encontrar el curso");
                }
                _sqlServerCursosOnlineContext.Remove(curso);
                var resultado = await _sqlServerCursosOnlineContext.SaveChangesAsync();
                if(resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el curso");
            }
        }
    }
}
