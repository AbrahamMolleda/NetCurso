using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SqlServerCursosOnlineContext _sqlServerContext;
        private readonly MySqlCursosOnlineContext _mySqlServerContext;
        public WeatherForecastController(SqlServerCursosOnlineContext sqlServerContext, MySqlCursosOnlineContext mySqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
            _mySqlServerContext = mySqlServerContext;
        }
        
        [HttpGet("sql")]
        public IEnumerable<Curso> GetSql()
        {
            return _sqlServerContext.Curso.ToList();

        }

        [HttpGet("mysql")]
        public IEnumerable<Curso> GetMySql()
        {
            return _mySqlServerContext.Curso.ToList();

        }
    }
}
