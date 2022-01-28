using Microsoft.EntityFrameworkCore;
using SMSLite_Portal.Shared.Models;

namespace SMSLite_Portal.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Mdl_Faculty> faculty { get; set; }    //Table Name
        
    }
}
