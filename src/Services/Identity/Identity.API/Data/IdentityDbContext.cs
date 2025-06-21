using Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.API.Data
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options):base(options)
        { }
    }
}
