using Microsoft.AspNetCore.Identity;

namespace Dominio.Entities
{
    public class Usuario : IdentityUser
    {
        public string NombreCompleto { get; set; }

    }
}
