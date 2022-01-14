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
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaPublicacion { get; set; }
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
                var cuso = new Curso
                {
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion
                };

                _sqlServerCursosOnlineContext.Curso.Add(cuso);
                var valor = await _sqlServerCursosOnlineContext.SaveChangesAsync();

                if(valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el curso");
            }
        }

    }
}
